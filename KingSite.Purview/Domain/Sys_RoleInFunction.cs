using System;
using System.Collections.Generic;

using System.Text;

namespace KingSite.Purview.Domain {

    /// <summary><c>Sys_RoleInFunction</c> Business Object.</summary>
    [Serializable]
    public class Sys_RoleInFunction {

        public Int32 Id { get; set; }
        public Int32 RoleId { get; set; }
        public Int32 FunctionId { get; set; }

    }
}
