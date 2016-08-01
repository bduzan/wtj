using System;
using System.Linq;
using ClosedXML.Excel;
using System.Collections.Generic;
using System.Reflection;
using WillingToJoin.Shared.Attributes;
using WillingToJoin.Shared.Context;
using EntityFramework.BulkInsert.Extensions;
using System.IO;
using System.Configuration;
using WillingToJoin.Shared.Domain;
using AutoMapper;

// https://closedxml.codeplex.com/wikipage?title=Cell%20Values
namespace WillingToJoin.Util
{
	class ExtendedContact : Contact
	{
		[Import(SourceField = "HOUSEHOLD_FAMILY_ROLE__C", TargetType = typeof(string))]
		public string ExtendedContactHouseholdFamilyRole { get; set; }
	}

	class Program
	{
		static void Main(string[] args)
		{
			// switched off
			//return;

			var dataDirectory = ConfigurationManager.AppSettings["DataDirectory"];
			var absoluteDataDirectory = Path.GetFullPath(dataDirectory);
			AppDomain.CurrentDomain.SetData("DataDirectory", absoluteDataDirectory);


			Console.WriteLine("Import Accounts");
			var accounts = GetFilledEntities<Account>(@"DataExtract\Account.xlsx");
			BulkInsert(new DatabaseContext(), accounts);

			Console.WriteLine("Import Households");
			var households = GetFilledEntities<Household>(@"DataExtract\Household.xlsx");
			BulkInsert(new DatabaseContext(), households);

			Console.WriteLine("Import Contacts");
			var extendedContacts = GetFilledEntities<ExtendedContact>(@"DataExtract\Contact.xlsx");
			int householdFamilyRoleID = 0;
			var householdFamilyRoles = extendedContacts.OrderBy(o => o.ExtendedContactHouseholdFamilyRole).GroupBy(d => d.ExtendedContactHouseholdFamilyRole).Select(s => new HouseholdFamilyRole { HouseholdFamilyRoleID = householdFamilyRoleID++, Name = s.First().ExtendedContactHouseholdFamilyRole }).ToList();
			BulkInsert(new DatabaseContext(), householdFamilyRoles);

			var householdFamilyRoleEntities = GetAll<HouseholdFamilyRole>(new DatabaseContext());
			var accountEntities = GetAll<Account>(new DatabaseContext());
			var householdEntities = GetAll<Household>(new DatabaseContext());
			var defaultHouseholdFamilyRoleID = householdFamilyRoleEntities.FirstOrDefault().HouseholdFamilyRoleID;
			var mapperConfiguration = new MapperConfiguration(cfg => { cfg.CreateMap<Contact, ExtendedContact>().ReverseMap(); });
			IMapper mapper = mapperConfiguration.CreateMapper();
			var contacts = extendedContacts.Select(s =>
			{
				s.HouseholdFamilyRoleID = defaultHouseholdFamilyRoleID;
				var householdFamilyRole = householdFamilyRoleEntities.FirstOrDefault(x => x.Name == s.ExtendedContactHouseholdFamilyRole);
				if (householdFamilyRole != null)
					s.HouseholdFamilyRoleID = householdFamilyRole.HouseholdFamilyRoleID;

				var account = accountEntities.FirstOrDefault(x => x.ImportedID.Trim() == s.AccountImportedID.Trim());
				s.AccountID = account != null ? (int?)account.ID : null;

				var household = householdEntities.FirstOrDefault(x => x.ImportedID.Trim() == s.HouseholdImportedID.Trim());
				s.HouseholdID = household != null ? (int?)household.ID : null;

				return mapper.Map<Contact>(s);
			}).ToList();
			BulkInsert(new DatabaseContext(), contacts);

			Console.WriteLine("Done");
			Console.Read();
		}

		////Console.WriteLine("UpdateIndexFields in Contacts");
		////UpdateIndexFields(new DatabaseContext());
		//private static void UpdateIndexFields(DatabaseContext context)
		//{
		//    context.Database.ExecuteSqlCommand(
		//        @"MERGE INTO Contacts
		//        USING Accounts
		//            ON Contacts.AccountImportedID = Accounts.ImportedID
		//        WHEN MATCHED THEN
		//        UPDATE
		//            SET AccountID = Accounts.ID;");

		//    context.Database.ExecuteSqlCommand(
		//        @"MERGE INTO Contacts
		//        USING Households
		//            ON Contacts.HouseholdImportedID = Households.ImportedID
		//        WHEN MATCHED THEN
		//        UPDATE
		//            SET HouseholdID = Households.ID;");
		//}

		private static List<T> GetFilledEntities<T>(string filePath)
			where T : new()
		{
			var entities = new List<T>();
			using (XLWorkbook workBook = new XLWorkbook(filePath))
			{
				IXLWorksheet workSheet = workBook.Worksheet(1);
				var range = workSheet.RangeUsed();
				var table = range.AsTable();
				Dictionary<int, TargetProperty> targetProperties = new Dictionary<int, TargetProperty>();
				bool firstRow = true;
				int cellNotEmptyCount = 0;
				foreach (IXLRangeRow row in table.Rows())
				{
					if (firstRow)
					{
						int cellCount = row.CellCount();
						if (cellCount > 0)
							for (int i = 1; i <= cellCount; i++)
							{
								string name = row.Cell(i).Value.ToString();
								if (!string.IsNullOrEmpty(name))
								{
									TargetProperty targetProperty = GetTargetProperty<T>(name);
									if (targetProperty != null)
									{
										targetProperties.Add(i, targetProperty);
										cellNotEmptyCount = i;
									}
								}
							}
						firstRow = false;
					}
					else
						if (cellNotEmptyCount > 0)
					{
						T household = new T();
						for (int i = 1; i <= cellNotEmptyCount; i++)
							if (targetProperties.ContainsKey(i))
							{
								IXLCell cell = row.Cell(i);
								UpdateProperty(household, targetProperties[i], cell.Value.ToString());
							}
						entities.Add(household);
					}
				}
			}
			return entities;
		}

		private static void BulkInsert<T>(DatabaseContext context, List<T> entities)
			where T : new()
		{
			using (var transaction = context.Database.BeginTransaction())
			{
				context.Configuration.AutoDetectChangesEnabled = false;
				context.BulkInsert(entities);
				context.Configuration.AutoDetectChangesEnabled = true;
				context.SaveChanges();
				transaction.Commit();
			}
		}

		private static List<T> GetAll<T>(DatabaseContext context)
			where T : class
		{
			var entities = context.Set(typeof(T)).Cast<T>();
			return entities.ToList();
		}

		private class TargetProperty
		{
			public PropertyInfo Property { get; set; }
			public Type Type { get; set; }
		}

		private static TargetProperty GetTargetProperty<T>(string fieldName)
		{
			TargetProperty targetProperty = null;

			foreach (PropertyInfo property in typeof(T).GetProperties())
			{
				var importAttribute = property.GetCustomAttributes<ImportAttribute>().FirstOrDefault();
				if (importAttribute != null)
					if (importAttribute.SourceField == fieldName)
						targetProperty = new TargetProperty
						{
							Property = property,
							Type = importAttribute.TargetType
						};
			}
			return targetProperty;
		}

		private static void UpdateProperty(object entity, TargetProperty targetProperty, string value)
		{
			try
			{
				object currentValue = value;
				if (targetProperty.Type == typeof(bool))
				{
					bool result = false;
					if (bool.TryParse(value, out result))
						currentValue = result;
				}
				targetProperty.Property.SetValue(entity, currentValue);
			}
			catch { }
		}
	}
}
