using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_poc_sr.helpers
{
    public static partial class Tools
    {
        private static readonly Dictionary<string, string> States = new Dictionary<string, string>()
        {
            {"AL","ALABAMA"},
            {"AK","ALASKA"},
            {"AS","AMERICAN SAMOA"},
            {"AZ","ARIZONA"},
            {"AR","ARKANSAS"},
            {"CA","CALIFORNIA"},
            {"CO","COLORADO"},
            {"CT","CONNECTICUT"},
            {"DE","DELAWARE"},
            {"DC","DISTRICT OF COLUMBIA"},
            {"FL","FLORIDA"},
            {"GA","GEORGIA"},
            {"GU","GUAM"},
            {"HI","HAWAII"},
            {"ID","IDAHO"},
            {"IL","ILLINOIS"},
            {"IN","INDIANA"},
            {"IA","IOWA"},
            {"KS","KANSAS"},
            {"KY","KENTUCKY"},
            {"LA","LOUISIANA"},
            {"ME","MAINE"},
            {"MD","MARYLAND"},
            {"MA","MASSACHUSETTS"},
            {"MI","MICHIGAN"},
            {"MN","MINNESOTA"},
            {"MS","MISSISSIPPI"},
            {"MO","MISSOURI"},
            {"MT","MONTANA"},
            {"NE","NEBRASKA"},
            {"NV","NEVADA"},
            {"NH","NEW HAMPSHIRE"},
            {"NJ","NEW JERSEY"},
            {"NM","NEW MEXICO"},
            {"NY","NEW YORK"},
            {"NC","NORTH CAROLINA"},
            {"ND","NORTH DAKOTA"},
            {"MP","NORTHERN MARIANA IS"},
            {"OH","OHIO"},
            {"OK","OKLAHOMA"},
            {"OR","OREGON"},
            {"PA","PENNSYLVANIA"},
            {"PR","PUERTO RICO"},
            {"RI","RHODE ISLAND"},
            {"SC","SOUTH CAROLINA"},
            {"SD","SOUTH DAKOTA"},
            {"TN","TENNESSEE"},
            {"TX","TEXAS"},
            {"UT","UTAH"},
            {"VT","VERMONT"},
            {"VA","VIRGINIA"},
            {"VI","VIRGIN ISLANDS"},
            {"WA","WASHINGTON"},
            {"WV","WEST VIRGINIA"},
            {"WI","WISCONSIN"},
            {"WY","WYOMING"}
        };
        public static string DecodeUSState(string code)
        {
            return States.ContainsKey(code.Trim().ToUpper()) ? States[code.Trim().ToUpper()] : "Unkown state";
        }
    }
}
