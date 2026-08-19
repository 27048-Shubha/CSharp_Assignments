namespace CarWashManagement.Models
{
    /// <summary>
    /// Represents data model about user.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Unique id of the user.
        /// </summary>
        private Guid _userId;

        /// <summary>
        /// First name of the user.
        /// </summary>
        private string _firstName;

        /// <summary>
        /// Last name of the user.
        /// </summary>
        private string _lastName;

        /// <summary>
        /// Unique email id of the user.
        /// </summary>
        private string _emailId;

        /// <summary>
        /// Phone number of the user.
        /// </summary>
        private string _phoneNumber;

        /// <summary>
        /// Password for user account.
        /// </summary>
        private string _password;

        /// <summary>
        /// Gets or initializes Guid for the user.
        /// </summary>
        /// <value>Unique Id</value>
        public Guid UserId { get; init; }

        /// <summary>
        /// Gets or sets first name of the user.
        /// </summary>
        /// <value>First name of the user.</value>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets last name of the user.
        /// </summary>
        /// <value>Last name of the user.</value>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets email id of the user.
        /// </summary>
        /// <value>Email id of the user.</value>
        public string EmailId
        {
            get => this._emailId;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Email Id is mandatory");
                }

                this._emailId = value;
            }
        }

        /// <summary>
        ///  Gets or sets phone number of the user.
        /// </summary>
        /// <value>Phone number of the user.</value>
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        ///  Gets or sets password for the user account.
        /// </summary>
        /// <value>Password for the user account.</value>
        public string Password
        {
            get => this._password;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Password is mandatory");
                }

                this._password = value;
            }
        }
    }
}
