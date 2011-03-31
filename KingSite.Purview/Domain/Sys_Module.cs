using System;
using System.Collections.Generic;

using System.Text;

namespace KingSite.Purview.Domain {

    /// <summary><c>Sys_Module</c> Business Object.</summary>
    [Serializable]
    public class Sys_Module {

        public Int32 Id { get; set; }
        public String ApplicatonName { get; set; }
        public String Name { get; set; }
        public String DisplayName { get; set; }

    }
}
