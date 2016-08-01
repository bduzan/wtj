using System;

namespace WillingToJoin.Shared.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class ImportAttribute : Attribute
    {
        public string SourceField { get; set; }

        public Type TargetType { get; set; }
    }
}
