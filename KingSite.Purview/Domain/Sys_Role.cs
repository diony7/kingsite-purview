using System;
using System.Collections.Generic;

using System.Text;

namespace KingSite.Purview.Domain {

    /// <summary><c>Sys_Role</c> </summary>
    [Serializable]
    public class Sys_Role {
   
        public Int32 Id { get; set; }	
        public String ApplicationName { get; set; }
        public String RoleName { get; set; }

    }
}
