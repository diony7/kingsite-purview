using System;
using System.Collections.Generic;

using System.Text;

namespace KingSite.Purview.Domain {

    /// <summary><c>Sys_UserInRole</c> </summary>
    [Serializable]
    public class Sys_UserInRole {

        public Int32 Id { get; set; }
        public String ApplicationName { get; set; }
        public String UserName { get; set; }
        public String RoleName { get; set; }

    }
}
