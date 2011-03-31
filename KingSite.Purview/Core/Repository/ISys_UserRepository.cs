using System;
using System.Collections.Generic;

using System.Text;
using KingSite.Purview.Domain;

namespace KingSite.Purview.Core.Repository {
    /// <summary><c>ISys_UserRepository</c> is the DAO interface for .</summary>
    internal interface ISys_UserRepository {
        
        /// <summary>Returns the total count of objects.</summary>
        int GetCount(string applicationName);

        /// <summary>Finds a <see cref="Sys_User"/> instance by the primary key value.</summary>
        Sys_User Find(Int32 id);

        /// <summary>Finds all Cart instances.</summary>
        IList<Sys_User> FindAll();

        /// <summary>Inserts a new Sys_Application instance into underlying database table.</summary>
        bool Insert(Sys_User obj);

        /// <summary>Update the underlying database record of a Sys_Application instance.</summary>
        bool Update(Sys_User obj);

        /// <summary>Delete the underlying database record of a Sys_Application instance.</summary>
        void Delete(Sys_User obj);

        bool ValidateUser(string applicationName, string userName, string password);

        Sys_User GetUser_IsNotLockedOut(string applicationName, string userName);

        Sys_User GetUser(string applicationName, string userName);

        void UpdateLogonDate(string applicationName, string userName, DateTime LastLoginDate, DateTime LastActivityDate);

        void UpdateActiveDate(string applicationName, string userName, DateTime LastActivityDate);

        bool UpdatePassword(string applicationName, string userName, string Password, string passwordKey, DateTime LastPasswordChangedDate);

        bool UpdatePasswordQuestionAndAnswer(string applicationName, string userName, string PasswordQuestion, string PasswordAnswer);

        bool Delete(string applicationName, string userName);

        bool LockUser(string applicationName, string userName, DateTime LastLockedOutDate);

        bool UnlockUser(string applicationName, string userName,DateTime LastLockedOutDate);

        bool UpdateForMembershipUser(Sys_User obj);

        bool UpdateFailedPassword(string applicationName, string userName, int FailedPasswordAttemptCount, DateTime FailedPasswordAttemptWindowStart);

        bool UpdateFailedPasswordAnswer(string applicationName, string userName, int FailedPasswordAnswerAttemptCount, DateTime FailedPasswordAnswerAttemptWindowStart);

        string GetUserNameByEmail(string applicationName, string email);

        int GetNumberOfUsersOnline(string applicationName, DateTime LastActivityDate);

        IList<Sys_User> GetAllUsers(string applicationName, int pageIndex, int pageSize, out int totalRecords);

        IList<Sys_User> FindUsersByEmail(string applicationName, string emailToMatch, int pageIndex, int pageSize, out int totalRecords);

        IList<Sys_User> FindUsersByName(string applicationName, string usernameToMatch, int pageIndex, int pageSize, out int totalRecords);
    }

}
