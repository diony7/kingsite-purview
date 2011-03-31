using System;
using System.Collections.Generic;

using System.Text;
using System.Configuration;
using System.Security.Cryptography;
using KingSite.Purview.Core.Repository;
using KingSite.Purview.Repository;
using System.Web.Security;
using System.Configuration.Provider;
using System.Collections.Specialized;
using KingSite.Purview.Domain;
using KingSite.BaseRepository;
using KingSite.Purview.Common;

namespace KingSite.Purview {

    public sealed class KSPMembershipProvider : MembershipProvider {

        ISys_UserRepository _userRepository;
        ISys_ApplicationRepository _appRepository;

        #region 属性
        private string _ApplicationName;
        public override string ApplicationName {
            get { return _ApplicationName; }
            set { _ApplicationName = value; }
        }

        private int _MaxInvalidPasswordAttempts;
        public override int MaxInvalidPasswordAttempts {
            get { return _MaxInvalidPasswordAttempts; }
        }

        private int _MinRequiredNonAlphanumericCharacters;
        public override int MinRequiredNonAlphanumericCharacters {
            get { return _MinRequiredNonAlphanumericCharacters; }
        }

        private int _MinRequiredPasswordLength;
        public override int MinRequiredPasswordLength {
            get { return _MinRequiredPasswordLength; }
        }

        private int _PasswordAttemptWindow;
        public override int PasswordAttemptWindow {
            get { return _PasswordAttemptWindow; }
        }

        private MembershipPasswordFormat _PasswordFormat;
        public override MembershipPasswordFormat PasswordFormat {
            get { return _PasswordFormat; }
        }

        private string _PasswordStrengthRegularExpression;
        public override string PasswordStrengthRegularExpression {
            get { return _PasswordStrengthRegularExpression; }
        }

        private bool _RequiresQuestionAndAnswer;
        public override bool RequiresQuestionAndAnswer {
            get { return _RequiresQuestionAndAnswer; }
        }

        private bool _RequiresUniqueEmail;
        public override bool RequiresUniqueEmail {
            get { return _RequiresUniqueEmail; }
        }

        private bool _EnablePasswordReset;
        public override bool EnablePasswordReset {
            get { return _EnablePasswordReset; }
        }

        private bool _EnablePasswordRetrieval;
        public override bool EnablePasswordRetrieval {
            get { return _EnablePasswordRetrieval; }
        }

        private bool _WriteExceptionsToEventLog;
        public bool WriteExceptionsToEventLog {
            get { return _WriteExceptionsToEventLog; }
            set { _WriteExceptionsToEventLog = value; }
        }

        private DBType _KSPDBType;
        public DBType KSPDBType {
            get { return _KSPDBType; }
            set { _KSPDBType = value; }
        }

        private string _ConnectionStringName;
        public string ConnectionStringName {
            get { return _ConnectionStringName; }
            set { _ConnectionStringName = value; }
        }

        #endregion

        private int newPasswordLength = 8;
        private string eventSource = "KSPMembershipProvider";
        private string eventLog = "Application";
        private string exceptionMessage = "An exception occurred. Please check the Event Log.";

        private const string encryptionKey = "63AFDC28A1BF4B2F";



        public override void Initialize(string name, NameValueCollection config) {
            //
            // Initialize values from web.config.
            //

            if (config == null)
                throw new ArgumentNullException("config");

            if (name == null || name.Length == 0)
                name = "KSP MembershipProvider";

            if (String.IsNullOrEmpty(config["description"])) {
                config.Remove("description");
                config.Add("description", "KSP MembershipProvider for sqlserver/mysql/oracle");
            }

            // Initialize the abstract base class.
            base.Initialize(name, config);

            _ApplicationName = Config.GetApplicationName();
            _KSPDBType = Config.GetDBType();
            _ConnectionStringName = Config.GetConnectionName();

            _MaxInvalidPasswordAttempts = Convert.ToInt32(GetConfigValue(config["maxInvalidPasswordAttempts"], "5"));
            _PasswordAttemptWindow = Convert.ToInt32(GetConfigValue(config["passwordAttemptWindow"], "10"));
            _MinRequiredNonAlphanumericCharacters = Convert.ToInt32(GetConfigValue(config["minRequiredNonAlphanumericCharacters"], "1"));
            _MinRequiredPasswordLength = Convert.ToInt32(GetConfigValue(config["minRequiredPasswordLength"], "7"));
            _PasswordStrengthRegularExpression = Convert.ToString(GetConfigValue(config["passwordStrengthRegularExpression"], ""));
            _EnablePasswordReset = Convert.ToBoolean(GetConfigValue(config["enablePasswordReset"], "true"));
            _EnablePasswordRetrieval = Convert.ToBoolean(GetConfigValue(config["enablePasswordRetrieval"], "true"));
            _RequiresQuestionAndAnswer = Convert.ToBoolean(GetConfigValue(config["requiresQuestionAndAnswer"], "false"));
            _RequiresUniqueEmail = Convert.ToBoolean(GetConfigValue(config["requiresUniqueEmail"], "true"));
            _WriteExceptionsToEventLog = Convert.ToBoolean(GetConfigValue(config["writeExceptionsToEventLog"], "true"));

            string temp_format = config["passwordFormat"];
            if (temp_format == null) {
                temp_format = "Hashed";
            }
            switch (temp_format) {
                case "Hashed":
                    _PasswordFormat = MembershipPasswordFormat.Hashed;
                    break;
                case "Encrypted":
                    _PasswordFormat = MembershipPasswordFormat.Encrypted;
                    break;
                case "Clear":
                    _PasswordFormat = MembershipPasswordFormat.Clear;
                    break;
                default:
                    throw new ProviderException("Password format not supported.");
            }

            InitRepostory();
            InsertApplication();
        }

        private void InitRepostory() {
            _userRepository = new Sys_UserRepository(ConnectionStringName, _KSPDBType);
            _appRepository = new Sys_ApplicationRepository(ConnectionStringName, _KSPDBType);
        }

        private void InsertApplication() {
            Sys_Application app = _appRepository.FindByName(ApplicationName);
            if (app == null) {
                app = new Sys_Application();
                app.Name = ApplicationName;
                app.Description = string.Empty;
                _appRepository.Insert(app);
            }
        }


        //
        // A helper function to retrieve config values from the configuration file.
        //
        private string GetConfigValue(string configValue, string defaultValue) {
            if (String.IsNullOrEmpty(configValue))
                return defaultValue;

            return configValue;
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword) {
            if (!ValidateUser(username, oldPassword))
                return false;
            ValidatePasswordEventArgs args =
              new ValidatePasswordEventArgs(username, newPassword, true);

            OnValidatingPassword(args);

            if (args.Cancel)
                if (args.FailureInformation != null)
                    throw args.FailureInformation;
                else
                    throw new MembershipPasswordException("Change password canceled due to new password validation failure.");
            string passwordKey = GenerateSalt();
            string newPass = EncodePassword(newPassword, passwordKey);
            bool result = _userRepository.UpdatePassword(ApplicationName, username, newPass, passwordKey, DateTime.Now);
            return result;
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer) {
            if (!ValidateUser(username, password))
                return false;
            bool result = _userRepository.UpdatePasswordQuestionAndAnswer(ApplicationName, username, newPasswordQuestion, newPasswordAnswer);
            return result;
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status) {
            ValidatePasswordEventArgs args =
              new ValidatePasswordEventArgs(username, password, true);

            OnValidatingPassword(args);

            if (args.Cancel) {
                status = MembershipCreateStatus.InvalidPassword;
                return null;
            }

            if (RequiresUniqueEmail && GetUserNameByEmail(email) != "") {
                status = MembershipCreateStatus.DuplicateEmail;
                return null;
            }

            MembershipUser u = GetUser(username, false);

            if (u == null) {
                DateTime createDate = DateTime.Now;

                if (providerUserKey == null) {
                    providerUserKey = Guid.NewGuid();
                }
                else {
                    if (!(providerUserKey is Guid)) {
                        status = MembershipCreateStatus.InvalidProviderUserKey;
                        return null;
                    }
                }
                Sys_User user = new Sys_User();
                user.Id = providerUserKey.ToString();
                user.Name = username;
                user.DisplayName = username;
                user.PasswordKey = GenerateSalt();
                user.Password = EncodePassword(password, user.PasswordKey);
                user.Email = email;
                user.PasswordQuestion = passwordQuestion;
                user.PasswordAnswer = passwordAnswer == null ? null : EncodePassword(passwordAnswer, user.PasswordKey);
                user.IsApproved = isApproved == true ? short.Parse("1") : short.Parse("0");
                user.Comment = string.Empty;
                user.CreationDate = createDate;
                user.LastPasswordChangedDate = createDate;
                user.LastActivityDate = createDate;
                user.LastLoginDate = createDate;
                user.ApplicationName = _ApplicationName;
                user.IsLockedOut = 0;
                user.LastLockedOutDate = createDate;
                user.FailedPasswordAttemptCount = 0;
                user.FailedPasswordAttemptWindowStart = createDate;
                user.FailedPasswordAnswerAttemptCount = 0;
                user.FailedPasswordAnswerAttemptWindowStart = createDate;

                bool result = _userRepository.Insert(user);
                if (result) {
                    status = MembershipCreateStatus.Success;
                }
                else {
                    status = MembershipCreateStatus.UserRejected;
                }
                return GetUser(username, false);
            }
            else {
                status = MembershipCreateStatus.DuplicateUserName;
            }

            return null;
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData) {
            bool result = _userRepository.Delete(ApplicationName, username);
            if (deleteAllRelatedData) {
                // Process commands to delete all data for the user in the database.
            }
            return result;
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords) {
            MembershipUserCollection users = new MembershipUserCollection();

            IList<Sys_User> list = _userRepository.FindUsersByEmail(ApplicationName, emailToMatch, pageIndex, pageSize, out totalRecords);
            foreach (Sys_User user in list) {
                users.Add(GetUserFromSys_User(user));
            }

            return users;
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords) {
            MembershipUserCollection users = new MembershipUserCollection();

            IList<Sys_User> list = _userRepository.FindUsersByName(ApplicationName, usernameToMatch, pageIndex, pageSize, out totalRecords);
            foreach (Sys_User user in list) {
                users.Add(GetUserFromSys_User(user));
            }

            return users;
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords) {
            MembershipUserCollection users = new MembershipUserCollection();

            IList<Sys_User> list = _userRepository.GetAllUsers(ApplicationName, pageIndex, pageSize, out totalRecords);
            foreach (Sys_User user in list) {
                users.Add(GetUserFromSys_User(user));
            }

            return users;
        }

        public override int GetNumberOfUsersOnline() {

            TimeSpan onlineSpan = new TimeSpan(0, System.Web.Security.Membership.UserIsOnlineTimeWindow, 0);
            DateTime compareTime = DateTime.Now.Subtract(onlineSpan);
            int result = _userRepository.GetNumberOfUsersOnline(ApplicationName, compareTime);
            return result;
        }

        public override string GetPassword(string username, string answer) {
            if (!EnablePasswordRetrieval) {
                throw new ProviderException("Password Retrieval Not Enabled.");
            }

            if (PasswordFormat == MembershipPasswordFormat.Hashed) {
                throw new ProviderException("Cannot retrieve Hashed passwords.");
            }

            Sys_User user = _userRepository.GetUser(ApplicationName, username);
            if (user != null) {
                if (user.IsLockedOut == short.Parse("1")) {
                    throw new MembershipPasswordException("The supplied user is locked out.");
                }
            }
            else {
                throw new MembershipPasswordException("The supplied user name is not found.");
            }

            if (RequiresQuestionAndAnswer && !CheckPasswordAnswer(answer, user.PasswordAnswer)) {
                UpdateFailureCount(username, "passwordAnswer");

                throw new MembershipPasswordException("Incorrect password answer.");
            }

            string password = user.Password;
            if (PasswordFormat == MembershipPasswordFormat.Encrypted) {
                password = UnEncodePassword(password);
            }

            return password;
        }

        public override MembershipUser GetUser(string username, bool userIsOnline) {
            Sys_User user = _userRepository.GetUser(ApplicationName, username);
            MembershipUser u = null;
            u = GetUserFromSys_User(user);
            if (userIsOnline) {
                _userRepository.UpdateActiveDate(ApplicationName, username, DateTime.Now);
            }
            return u;
        }

        private MembershipUser GetUserFromSys_User(Sys_User user) {
            if (user == null) return null;
            MembershipUser u = new MembershipUser(this.Name,
                user.Name, user.Id, user.Email, user.PasswordQuestion,
                user.Comment, user.IsApproved == 1 ? true : false, user.IsLockedOut == 1 ? true : false, user.CreationDate,
                user.LastLoginDate, user.LastActivityDate, user.LastPasswordChangedDate, user.LastLockedOutDate);
            return u;
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline) {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email) {
            return _userRepository.GetUserNameByEmail(ApplicationName, email);
        }


        public override string ResetPassword(string username, string answer) {
            if (!EnablePasswordReset) {
                throw new NotSupportedException("Password reset is not enabled.");
            }

            if (answer == null && RequiresQuestionAndAnswer) {
                UpdateFailureCount(username, "passwordAnswer");

                throw new ProviderException("Password answer required for password reset.");
            }

            string newPassword =
              System.Web.Security.Membership.GeneratePassword(newPasswordLength, MinRequiredNonAlphanumericCharacters);

            ValidatePasswordEventArgs args =
              new ValidatePasswordEventArgs(username, newPassword, true);

            OnValidatingPassword(args);

            if (args.Cancel)
                if (args.FailureInformation != null)
                    throw args.FailureInformation;
                else
                    throw new MembershipPasswordException("Reset password canceled due to password validation failure.");

            Sys_User user = _userRepository.GetUser(ApplicationName, username);
            if (user != null) {
                if (user.IsLockedOut == 1) {
                    throw new MembershipPasswordException("The supplied user is locked out.");
                }
            }
            else {
                throw new MembershipPasswordException("The supplied user name is not found.");
            }
            string passwordAnswer = user.PasswordAnswer;
            if (RequiresQuestionAndAnswer && !CheckPasswordAnswer(answer, passwordAnswer)) {
                UpdateFailureCount(username, "passwordAnswer");

                throw new MembershipPasswordException("Incorrect password answer.");
            }
            string passwordKey = GenerateSalt();
            string newpass = EncodePassword(newPassword,passwordKey);
            bool result = _userRepository.UpdatePassword(ApplicationName, username, newpass, passwordKey, DateTime.Now);

            if (result) {
                return newPassword;
            }
            else {
                throw new MembershipPasswordException("User not found, or user is locked out. Password not Reset.");
            }
        }

        public override bool UnlockUser(string userName) {

            bool result = _userRepository.UnlockUser(ApplicationName, userName, DateTime.Now);
            return result;
        }

        public override void UpdateUser(MembershipUser user) {
            Sys_User u = new Sys_User();
            u.Email = user.Email;
            u.Comment = user.Comment;
            u.IsApproved = user.IsApproved == true ? short.Parse("1") : short.Parse("0");
            u.ApplicationName = ApplicationName;
            u.Name = user.UserName;
            bool result = _userRepository.UpdateForMembershipUser(u);
        }

        public override bool ValidateUser(string username, string password) {
            bool isValid = false;
            bool isApproved = false;
            Sys_User user = _userRepository.GetUser_IsNotLockedOut(ApplicationName, username);
            if (user == null) return false;
            string pwd = user.Password;
            isApproved = user.IsApproved == 1 ? true : false;
            if (CheckPassword(password, pwd, user.PasswordKey)) {
                if (isApproved) {
                    isValid = true;
                    _userRepository.UpdateLogonDate(ApplicationName, username, DateTime.Now, DateTime.Now);
                }
            }
            else {
                UpdateFailureCount(username, "password");
            }


            return isValid;
        }

        //
        // CheckPassword
        //   Compares password values based on the MembershipPasswordFormat.
        //
        private bool CheckPassword(string password, string dbpassword, string passwordKey) {
            string pass1 = password;
            string pass2 = dbpassword;

            switch (PasswordFormat) {
                case MembershipPasswordFormat.Encrypted:
                    pass2 = UnEncodePassword(dbpassword);
                    break;
                case MembershipPasswordFormat.Hashed:
                    pass1 = EncodePassword(password, passwordKey);
                    break;
                default:
                    break;
            }

            if (pass1 == pass2) {
                return true;
            }

            return false;
        }


        private bool CheckPasswordAnswer(string password, string answer) {
            string pass1 = password;
            string pass2 = answer;

            switch (PasswordFormat) {
                case MembershipPasswordFormat.Encrypted:
                    pass2 = UnEncodePassword(answer);
                    break;
                case MembershipPasswordFormat.Hashed:
                    pass1 = EncodePasswordAnswer(password);
                    break;
                default:
                    break;
            }

            if (pass1 == pass2) {
                return true;
            }

            return false;
        }

        //
        // EncodePassword
        //   Encrypts, Hashes, or leaves the password clear based on the PasswordFormat.
        //
        private string EncodePasswordAnswer(string password) {
            string encodedPassword = password;
            switch (PasswordFormat) {
                case MembershipPasswordFormat.Clear:
                    break;
                case MembershipPasswordFormat.Encrypted:
                    encodedPassword =
                      Convert.ToBase64String(EncryptPassword(Encoding.Unicode.GetBytes(password)));
                    break;
                case MembershipPasswordFormat.Hashed:
                    HMACSHA1 hash = new HMACSHA1();
                    hash.Key = HexToByte(encryptionKey);
                    encodedPassword =
                      Convert.ToBase64String(hash.ComputeHash(Encoding.Unicode.GetBytes(password)));
                    break;
                default:
                    throw new ProviderException("Unsupported password format.");
            }
            return encodedPassword;
        }

        private string EncodePassword(string password,string salt) {
            string encodedPassword = password;

            byte[] dst = MergePassAndSale(password, salt);

            switch (PasswordFormat) {
                case MembershipPasswordFormat.Clear:
                    break;
                case MembershipPasswordFormat.Encrypted:
                    encodedPassword =
                      Convert.ToBase64String(EncryptPassword(Encoding.Unicode.GetBytes(password)));
                    break;
                case MembershipPasswordFormat.Hashed:
                    HMACSHA1 hash = new HMACSHA1();
                    hash.Key = HexToByte(encryptionKey);
                    encodedPassword =
                      Convert.ToBase64String(hash.ComputeHash(dst));
                    break;
                default:
                    throw new ProviderException("Unsupported password format.");
            }
            return encodedPassword;
        }
        
        private static byte[] MergePassAndSale(string password, string salt) {
            // 将密码和salt值转换成字节形式并连接起来
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] src = Convert.FromBase64String(salt);
            byte[] dst = new byte[src.Length + bytes.Length];
            Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);
            return dst;
        }

        internal string GenerateSalt() {
            byte[] data = new byte[0x10];
            new RNGCryptoServiceProvider().GetBytes(data);
            return Convert.ToBase64String(data);
        }
        //
        // UnEncodePassword
        //   Decrypts or leaves the password clear based on the PasswordFormat.
        //
        private string UnEncodePassword(string encodedPassword) {
            string password = encodedPassword;

            switch (PasswordFormat) {
                case MembershipPasswordFormat.Clear:
                    break;
                case MembershipPasswordFormat.Encrypted:
                    password =
                      Encoding.Unicode.GetString(DecryptPassword(Convert.FromBase64String(password)));
                    break;
                case MembershipPasswordFormat.Hashed:
                    throw new ProviderException("Cannot unencode a hashed password.");
                default:
                    throw new ProviderException("Unsupported password format.");
            }

            return password;
        }

        //
        // HexToByte
        //   Converts a hexadecimal string to a byte array. Used to convert encryption
        // key values from the configuration.
        //
        private byte[] HexToByte(string hexString) {
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        private void UpdateFailureCount(string username, string failureType) {

            Sys_User user = _userRepository.GetUser(ApplicationName, username);

            DateTime windowStart = new DateTime();
            int failureCount = 0;
            if (user != null) {

                if (failureType == "password") {
                    failureCount = user.FailedPasswordAttemptCount;
                    windowStart = user.FailedPasswordAttemptWindowStart;
                }

                if (failureType == "passwordAnswer") {
                    failureCount = user.FailedPasswordAnswerAttemptCount;
                    windowStart = user.FailedPasswordAnswerAttemptWindowStart;
                }
            }

            DateTime windowEnd = windowStart.AddMinutes(PasswordAttemptWindow);

            if (failureCount == 0 || DateTime.Now > windowEnd) {
                // First password failure or outside of PasswordAttemptWindow. 
                // Start a new password failure count from 1 and a new window starting now.
                bool result = false;

                if (failureType == "password")
                    result = _userRepository.UpdateFailedPassword(ApplicationName, username, 1, DateTime.Now);


                if (failureType == "passwordAnswer")
                    result = _userRepository.UpdateFailedPasswordAnswer(ApplicationName, username, 1, DateTime.Now);


                if (!result)
                    throw new ProviderException("Unable to update failure count and window start.");
            }
            else {
                if (failureCount++ >= MaxInvalidPasswordAttempts) {
                    // Password attempts have exceeded the failure threshold. Lock out
                    // the user.
                    bool result = _userRepository.LockUser(ApplicationName, username, DateTime.Now);

                    if (!result)
                        throw new ProviderException("Unable to lock out user.");
                }
                else {
                    // Password attempts have not exceeded the failure threshold. Update
                    // the failure counts. Leave the window the same.
                    Sys_User u = _userRepository.GetUser(ApplicationName, username);
                    bool result = false;
                    if (failureType == "password")
                        result = _userRepository.UpdateFailedPassword(ApplicationName, username, failureCount, u.FailedPasswordAttemptWindowStart);

                    if (failureType == "passwordAnswer")
                        result = _userRepository.UpdateFailedPasswordAnswer(ApplicationName, username, failureCount, u.FailedPasswordAttemptWindowStart);

                    if (!result)
                        throw new ProviderException("Unable to update failure count.");
                }
            }
            
        }

    }

}
