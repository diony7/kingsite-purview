using System;
using System.Collections.Generic;

using System.Text;

namespace KingSite.Purview.Domain {

    /// <summary><c>Sys_User</c> </summary>
    [Serializable]
    public class Sys_User {
        
        public String Id { get; set; }
        public String ApplicationName { get; set; }
        public String Name { get; set; }
        public String DisplayName { get; set; }
        public String Email { get; set; }
        public String Comment { get; set; }
        public String Password { get; set; }
        public String PasswordKey { get; set; }
        public String PasswordQuestion { get; set; }
        public String PasswordAnswer { get; set; }
        public short IsApproved { get; set; }
        public DateTime LastActivityDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public DateTime LastPasswordChangedDate { get; set; }
        public DateTime CreationDate { get; set; }
        public short IsLockedOut { get; set; }
        public DateTime LastLockedOutDate { get; set; }
        public short IsOnLine { get; set; }
        public int FailedPasswordAttemptCount { get; set; }
        public DateTime FailedPasswordAttemptWindowStart { get; set; }
        public int FailedPasswordAnswerAttemptCount { get; set; }
        public DateTime FailedPasswordAnswerAttemptWindowStart { get; set; }

    }


}
