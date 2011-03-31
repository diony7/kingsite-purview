using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingSite.Purview.Domain {

    /// <summary><c>Sys_Menu</c> Business Object.</summary>
    [Serializable]
    public partial class Sys_Menu {

        public Int32 Id { get; set; }
        public String ApplicationName { get; set; }
        public String MenuName { get; set; }
        public String PathLocation { get; set; }

    }
}
