using System;
using System.Collections.Generic;
using System.Text;

namespace Weable.TMS.Model.Enumeration
{
    public enum Role
    {
        Admin,
        Staff
    }

    public static class RoleExtensions
    {
        public static string GetRoleName(this Role role)
        {
            return role.ToString();
        }
    }

}
