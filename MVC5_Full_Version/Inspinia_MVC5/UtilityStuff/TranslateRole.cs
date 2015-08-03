using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inspinia_MVC5.Utility
{
    public class TranslateRole
    {
        public static int GetRoleId(string role)
        {
            if (role.Equals("SuperAdmin"))
                return 1;
            else if (role.Equals("Admin"))
                return 2;
            else if (role.Equals("Manager"))
                return 3;
            else if (role.Equals("Supporter"))
                return 4;
            return 0;
        }
    }
}