using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingSite.Purview.Domain.LogicModel {
    
    public class NavTreeMenu {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public int ParentId { get; set; }
        public bool Leaf { get; set; }
        public string IconName { get; set; }
        public string PathLocation { get; set; }

    }
}
