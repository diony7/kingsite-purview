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

    public sealed class KSPMembershipExProvider :MembershipExProvider {
        private string _applicationName;
        public string ApplicationName {
            get { return _applicationName; }
            set { _applicationName = value; }
        }

        ISys_RoleRepository _roleRepository;
        ISys_UserInRoleRepository _uirRepository;
        ISys_RoleInFunctionRepository _rifRepository;
        ISys_FunctionRepository _frRepository;

        public KSPMembershipExProvider()
        {
            _roleRepository = new Sys_RoleRepository();
            _uirRepository = new Sys_UserInRoleRepository();
            _rifRepository = new Sys_RoleInFunctionRepository();
            _frRepository = new Sys_FunctionRepository();
            _applicationName = Config.GetApplicationName();
        }
        
        public override bool CanDo(string userName, string controllerName, string actionName) {
            bool result = false;
            IList<Sys_RoleInFunction> list = _rifRepository.FindByUCA(_applicationName, userName, controllerName, actionName);
            if (list.Count > 0) {
                result = true;
            }
            return result;
        }

        private IList<Sys_Role> GetRoleList(string userName) {
            IList<Sys_Role> result = new List<Sys_Role>();
            IList<Sys_UserInRole> list1 = _uirRepository.GetRolesForUser(_applicationName, userName);
            string roleName = string.Empty;
            foreach (Sys_UserInRole uir in list1) {
                Sys_Role r = _roleRepository.Find(_applicationName, uir.RoleName);
                result.Add(r);
            }
            return result;
        }


        private string GetRoleNames(string userName) {
            IList<Sys_UserInRole> list1 = _uirRepository.GetRolesForUser(_applicationName, userName);
            string roleName = string.Empty;
            foreach (Sys_UserInRole uir in list1) {
                roleName += string.Format("'{0}',", uir.RoleName);
            }
            roleName = roleName.Remove(roleName.Length - 1, 1);
            return roleName;
        }

        private IList<Sys_Function> GetFunctions(string userName) {
            string roleName = GetRoleNames(userName);
            IList<Sys_RoleInFunction> list2 = _rifRepository.FindByRoleName(_applicationName, roleName);
            string functionIds = string.Empty;
            foreach (Sys_RoleInFunction rif in list2) {
                functionIds += string.Format("{0},", rif.FunctionId);
            }
            if (!string.IsNullOrEmpty(functionIds)) {
                functionIds = functionIds.Remove(functionIds.Length - 1, 1);
                IList<Sys_Function> list3 = _frRepository.FindByIds(functionIds);
                return list3;
            }
            else {
                return new List<Sys_Function>();
            }
        }
    }
}
