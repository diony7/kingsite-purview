using System;
using System.Collections.Generic;

using System.Text;

namespace KingSite.Purview.Domain {

    /// <summary><c>Sys_Function</c> Business Object.</summary>
    [Serializable]
    public class Sys_Function {

        public Int32 Id { get; set; }
        public String ApplicationName { get; set; }
        public String ModuleName { get; set; }
        public String ControllerName { get; set; }
        public String ActionName { get; set; }
        public String ControllerDisplayName { get; set; }
        public String ActionDisplayName { get; set; }

    }
}
