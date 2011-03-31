using System;
using System.Collections.Generic;
using System.Text;

namespace KingSite.Purview {

    public abstract class MembershipExProvider {
        public abstract bool CanDo(string userName, string controllerName, string actionName);
    }
}
