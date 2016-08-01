﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WillingToJoin.Shared.Utils
{
    public static class HelperUtil
    {
        public static IEnumerable<SelectListItem> ProvinceList
        {
            get
            {
                return new List<SelectListItem>
                {
                    new SelectListItem {Value = "Alberta", Text = "Alberta"},
                    new SelectListItem {Value = "British Columbia", Text = "British Columbia"},
                    new SelectListItem {Value = "Manitoba", Text = "Manitoba"},
                    new SelectListItem {Value = "New Brunswick", Text = "New Brunswick"},
                    new SelectListItem {Value = "New Foundland", Text = "New Foundland"},
                    new SelectListItem {Value = "Northwest Territories", Text = "Northwest Territories"},
                    new SelectListItem {Value = "Nova Scotia", Text = "Nova Scotia"},
                    new SelectListItem {Value = "Ontario", Text = "Ontario"},
                    new SelectListItem {Value = "Prince Edward Island", Text = "Prince Edward Island"},
                    new SelectListItem {Value = "Quebec", Text = "Quebec"},
                    new SelectListItem {Value = "Saskatchewan", Text = "Saskatchewan"},
                    new SelectListItem {Value = "Yukon Territories", Text = "Yukon Territories"}
                };
            }
        }

        public static IEnumerable<SelectListItem> StateList
        {
            get
            {
                return new List<SelectListItem>()
                {
                    new SelectListItem {Value = "AL", Text = "Alabama"},
                    new SelectListItem {Value = "AK", Text = "Alaska"},
                    new SelectListItem {Value = "AZ", Text = "Arizona"},
                    new SelectListItem {Value = "AR", Text = "Arkansas"},
                    new SelectListItem {Value = "CA", Text = "California"},
                    new SelectListItem {Value = "CO", Text = "Colorado"},
                    new SelectListItem {Value = "CT", Text = "Connecticut"},
                    new SelectListItem {Value = "DE", Text = "Delaware"},
                    new SelectListItem {Value = "DC", Text = "District of Columbia"},
                    new SelectListItem {Value = "FL", Text = "Florida"},
                    new SelectListItem {Value = "GA", Text = "Georgia"},
                    new SelectListItem {Value = "HI", Text = "Hawaii"},
                    new SelectListItem {Value = "ID", Text = "Idaho"},
                    new SelectListItem {Value = "IL", Text = "Illinois"},
                    new SelectListItem {Value = "IN", Text = "Indiana"},
                    new SelectListItem {Value = "IA", Text = "Iowa"},
                    new SelectListItem {Value = "KS", Text = "Kansas"},
                    new SelectListItem {Value = "KY", Text = "Kentucky"},
                    new SelectListItem {Value = "LA", Text = "Louisiana"},
                    new SelectListItem {Value = "ME", Text = "Maine"},
                    new SelectListItem {Value = "MD", Text = "Maryland"},
                    new SelectListItem {Value = "MA", Text = "Massachusetts"},
                    new SelectListItem {Value = "MI", Text = "Michigan"},
                    new SelectListItem {Value = "MN", Text = "Minnesota"},
                    new SelectListItem {Value = "MS", Text = "Mississippi"},
                    new SelectListItem {Value = "MO", Text = "Missouri"},
                    new SelectListItem {Value = "MT", Text = "Montana"},
                    new SelectListItem {Value = "NE", Text = "Nebraska"},
                    new SelectListItem {Value = "NV", Text = "Nevada"},
                    new SelectListItem {Value = "NH", Text = "New Hampshire"},
                    new SelectListItem {Value = "NJ", Text = "New Jersey"},
                    new SelectListItem {Value = "NM", Text = "New Mexico"},
                    new SelectListItem {Value = "NY", Text = "New York"},
                    new SelectListItem {Value = "NC", Text = "North Carolina"},
                    new SelectListItem {Value = "ND", Text = "North Dakota"},
                    new SelectListItem {Value = "OH", Text = "Ohio"},
                    new SelectListItem {Value = "OK", Text = "Oklahoma"},
                    new SelectListItem {Value = "OR", Text = "Oregon"},
                    new SelectListItem {Value = "PA", Text = "Pennsylvania"},
                    new SelectListItem {Value = "RI", Text = "Rhode Island"},
                    new SelectListItem {Value = "SC", Text = "South Carolina"},
                    new SelectListItem {Value = "SD", Text = "South Dakota"},
                    new SelectListItem {Value = "TN", Text = "Tennessee"},
                    new SelectListItem {Value = "TX", Text = "Texas"},
                    new SelectListItem {Value = "UT", Text = "Utah"},
                    new SelectListItem {Value = "VT", Text = "Vermont"},
                    new SelectListItem {Value = "VA", Text = "Virginia"},
                    new SelectListItem {Value = "WA", Text = "Washington"},
                    new SelectListItem {Value = "WV", Text = "West Virginia"},
                    new SelectListItem {Value = "WI", Text = "Wisconsin"},
                    new SelectListItem {Value = "WY", Text = "Wyoming"}
                };
            }
        }
    }
}
