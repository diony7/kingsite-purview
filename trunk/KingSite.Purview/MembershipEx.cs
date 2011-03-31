using System;
using System.Collections.Generic;

using System.Text;
using KingSite.Purview.Core.Repository;
using KingSite.Purview.Repository;
using KingSite.Purview.Domain;
using System.Data;
using System.Collections;
using KingSite.Purview.Common;

namespace KingSite.Purview {

    public static class MembershipEx {
        public static MembershipExProvider _provider;
        static MembershipEx() {
            Initialize();
        }

        private static void Initialize() {
            _provider = new KSPMembershipExProvider();
        }

        public static bool CanDo(string userName, string controllerName, string actionName) {
            return _provider.CanDo(userName, controllerName, actionName);
        }
    }
}
