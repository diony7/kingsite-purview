using System;
using System.Collections.Generic;

using System.Text;
using KingSite.Purview.Core.Repository;
using IBatisNet.DataMapper;
using KingSite.Purview.Domain;
using System.Collections;
using KingSite.BaseRepository;


namespace KingSite.Purview.Repository {
    internal class Sys_UserRepository : BaseProvider, ISys_UserRepository {

        public Sys_UserRepository(string connectionStringName, DBType dbType)
            : base(connectionStringName, dbType) {
        }

        public int GetCount(string applicationName) {
            String stmtId = "Sys_User.GetCount";
            Sys_User user = new Sys_User();
            user.ApplicationName = applicationName;
            int result = SqlMapper.QueryForObject<int>(stmtId, user);
            return result;
        }

        public Sys_User Find(int id) {
            throw new NotImplementedException();
        }

        public IList<Sys_User> FindAll() {
            throw new NotImplementedException();
        }

        public bool Insert(Sys_User obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "Sys_User.Insert";
            if (SqlMapper.Update(stmtId, obj) > 0) {
                return true;
            }
            else return false;
        }

        public bool Update(Sys_User obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "Sys_User.Update";
            if (SqlMapper.Update(stmtId, obj) > 0) {
                return true;
            }
            else return false;
        }

        public void Delete(Sys_User obj) {
            throw new NotImplementedException();
        }

        public bool ValidateUser(string applicationName, string userName, string password) {
            String stmtId = "Sys_User.ValidateUser";
            Sys_User user = new Sys_User();
            user.ApplicationName = applicationName;
            user.Name = userName;
            user.Password = password;
            int result = SqlMapper.QueryForObject<int>(stmtId, user);
            if (result == 1) {
                return true;
            }
            else {
                return false;
            }

        }

        public Sys_User GetUser_IsNotLockedOut(string applicationName, string userName) {
            String stmtId = "Sys_User.GetUser_IsNotLockedOut";
            Sys_User user = new Sys_User();
            user.ApplicationName = applicationName;
            user.Name = userName;
            Sys_User result = SqlMapper.QueryForObject<Sys_User>(stmtId, user);
            return result;
        }

        public Sys_User GetUser(string applicationName, string userName) {
            String stmtId = "Sys_User.GetUser";
            Sys_User user = new Sys_User();
            user.ApplicationName = applicationName;
            user.Name = userName;
            Sys_User result = SqlMapper.QueryForObject<Sys_User>(stmtId, user);
            return result;
        }

        public void UpdateLogonDate(string applicationName, string userName, DateTime LastLoginDate, DateTime LastActivityDate) {
            String stmtId = "Sys_User.UpdateLogonDate";
            Sys_User user = new Sys_User();
            user.ApplicationName = applicationName;
            user.Name = userName;
            user.LastLoginDate = LastLoginDate;
            user.LastActivityDate = LastActivityDate;
            SqlMapper.Update(stmtId, user);
        }

        public void UpdateActiveDate(string applicationName, string userName, DateTime LastActivityDate) {
            String stmtId = "Sys_User.UpdateActiveDate";
            Sys_User user = new Sys_User();
            user.ApplicationName = applicationName;
            user.Name = userName;
            user.LastActivityDate = LastActivityDate;
            SqlMapper.Update(stmtId, user);
        }

        public bool UpdatePassword(string applicationName, string userName, string Password, string passwordKey, DateTime LastPasswordChangedDate) {
            String stmtId = "Sys_User.UpdatePassword";
            Sys_User user = new Sys_User();
            user.ApplicationName = applicationName;
            user.Name = userName;
            user.Password = Password;
            user.PasswordKey = passwordKey;
            user.LastPasswordChangedDate = LastPasswordChangedDate;
            if (SqlMapper.Update(stmtId, user) > 0) {
                return true;
            }
            else return false;
        }

        public bool UpdatePasswordQuestionAndAnswer(string applicationName, string userName, string passwordQuestion, string passwordAnswer) {
            String stmtId = "Sys_User.UpdatePasswordQuestionAndAnswer";
            Sys_User user = new Sys_User();
            user.ApplicationName = applicationName;
            user.Name = userName;
            user.PasswordQuestion = passwordQuestion;
            user.PasswordAnswer = passwordAnswer;
            if (SqlMapper.Update(stmtId, user) > 0) {
                return true;
            }
            else return false;
        }

        public bool Delete(string applicationName, string userName) {
            String stmtId = "Sys_User.Delete";
            Sys_User user = new Sys_User();
            user.ApplicationName = applicationName;
            user.Name = userName;
            if (SqlMapper.Update(stmtId, user) > 0) {
                return true;
            }
            else return false;
        }

        public bool LockUser(string applicationName, string userName, DateTime LastLockedOutDate) {
            String stmtId = "Sys_User.LockUser";
            Sys_User user = new Sys_User();
            user.ApplicationName = applicationName;
            user.Name = userName;
            user.LastLockedOutDate = LastLockedOutDate;
            if (SqlMapper.Update(stmtId, user) > 0) {
                return true;
            }
            else return false;
        }

        public bool UnlockUser(string applicationName, string userName, DateTime LastLockedOutDate) {
            String stmtId = "Sys_User.UnlockUser";
            Sys_User user = new Sys_User();
            user.ApplicationName = applicationName;
            user.Name = userName;
            user.LastLockedOutDate = LastLockedOutDate;
            if (SqlMapper.Update(stmtId, user) > 0) {
                return true;
            }
            else return false;
        }

        public bool UpdateForMembershipUser(Sys_User obj) {
            String stmtId = "Sys_User.UpdateForMembershipUser";
            if (SqlMapper.Update(stmtId, obj) > 0) {
                return true;
            }
            else return false;
        }

        public bool UpdateFailedPassword(string applicationName, string userName, int FailedPasswordAttemptCount, DateTime FailedPasswordAttemptWindowStart) {
            String stmtId = "Sys_User.UpdateFailedPassword";
            Sys_User user = new Sys_User();
            user.ApplicationName = applicationName;
            user.Name = userName;
            user.FailedPasswordAttemptCount = FailedPasswordAttemptCount;
            user.FailedPasswordAttemptWindowStart = FailedPasswordAttemptWindowStart;
            if (SqlMapper.Update(stmtId, user) > 0) {
                return true;
            }
            else return false;
        }

        public bool UpdateFailedPasswordAnswer(string applicationName, string userName, int FailedPasswordAnswerAttemptCount, DateTime FailedPasswordAnswerAttemptWindowStart) {
            String stmtId = "Sys_User.UpdateFailedPasswordAnswer";
            Sys_User user = new Sys_User();
            user.ApplicationName = applicationName;
            user.Name = userName;
            user.FailedPasswordAnswerAttemptCount = FailedPasswordAnswerAttemptCount;
            user.FailedPasswordAnswerAttemptWindowStart = FailedPasswordAnswerAttemptWindowStart;
            if (SqlMapper.Update(stmtId, user) > 0) {
                return true;
            }
            else return false;
        }

        public string GetUserNameByEmail(string applicationName, string email) {
            String stmtId = "Sys_User.GetUserNameByEmail";
            Sys_User user = new Sys_User();
            user.ApplicationName = applicationName;
            user.Email = email;
            Sys_User result = SqlMapper.QueryForObject<Sys_User>(stmtId, user);
            if (result != null)
                return result.Name;
            else return string.Empty;
        }

        public int GetNumberOfUsersOnline(string applicationName, DateTime LastActivityDate) {
            String stmtId = "Sys_User.GetNumberOfUsersOnline";
            Sys_User user = new Sys_User();
            user.ApplicationName = applicationName;
            user.LastActivityDate = LastActivityDate;
            int result = SqlMapper.QueryForObject<int>(stmtId, user);
            return result;
        }

        public IList<Sys_User> GetAllUsers(string applicationName, int pageIndex, int pageSize, out int totalRecords) {
            String stmtId = "Sys_User.GetAllUsers";
            totalRecords = GetCount(applicationName);
            Hashtable ht = new Hashtable();
            int startRow, endRow;
            CPage(pageIndex, pageSize, totalRecords, out startRow, out endRow);
            ht["StartRow"] = startRow;
            ht["EndRow"] = endRow;
            ht["ApplicationName"] = applicationName;
            IList<Sys_User> result = SqlMapper.QueryForList<Sys_User>(stmtId, ht);
            return result;
        }

        public IList<Sys_User> FindUsersByEmail(string applicationName, string emailToMatch, int pageIndex, int pageSize, out int totalRecords) {
            String stmtId = "Sys_User.FindUsersByEmail";
            totalRecords = GetCount(applicationName);
            Hashtable ht = new Hashtable();
            int startRow, endRow;
            CPage(pageIndex, pageSize, totalRecords, out startRow, out endRow);
            ht["StartRow"] = startRow;
            ht["EndRow"] = endRow;
            ht["ApplicationName"] = applicationName;
            ht["EmailToMatch"] = emailToMatch;
            IList<Sys_User> result = SqlMapper.QueryForList<Sys_User>(stmtId, ht);
            return result;
        }

        public IList<Sys_User> FindUsersByName(string applicationName, string usernameToMatch, int pageIndex, int pageSize, out int totalRecords) {
            String stmtId = "Sys_User.FindUsersByName";
            totalRecords = GetCount(applicationName);
            Hashtable ht = new Hashtable();
            int startRow, endRow;
            CPage(pageIndex, pageSize, totalRecords, out startRow, out endRow);
            ht["StartRow"] = startRow;
            ht["EndRow"] = endRow;
            ht["ApplicationName"] = applicationName;
            ht["UserNameToMatch"] = usernameToMatch;
            IList<Sys_User> result = SqlMapper.QueryForList<Sys_User>(stmtId, ht);
            return result;

        }
    }
}
