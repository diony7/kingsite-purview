using System;
using System.Collections.Generic;

using System.Text;

namespace KingSite.Purview.Domain {
    /// <summary><c>Sys_Application</c> </summary>
    [Serializable]
    public class Sys_Application {

        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }

    }
}
