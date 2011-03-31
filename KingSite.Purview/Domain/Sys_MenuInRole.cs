using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingSite.Purview.Domain {

    /// <summary><c>Sys_MenuInRole</c> Business Object.</summary>
    [Serializable]
    public partial class Sys_MenuInRole {

        public Int32 Id { get; set; }
        public Int32 MenuId { get; set; }
        public Int32 RoleId { get; set; }
        public Int32 ParentMenuId { get; set; }

    }
}
