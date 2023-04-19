using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZarenBlazorAdmin.Utility
{
    public static class Helper
    {
        public static bool Contains(string input, string findMe)
        {
            return string.IsNullOrWhiteSpace(input) ? false : input.IndexOf(findMe, StringComparison.InvariantCultureIgnoreCase) > -1;
        }
    }
}

