namespace CarWashManagement.Service
{
    using CarWashManagement.Models;
    using CarWashManagement.Repository;

    /// <summary>
    /// Handles user service.
    /// </summary>
    public class UserService
    {
        private readonly UserRepository _repository = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="repository">Object to handle user repository operation.</param>
        internal UserService(UserRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Registers user.
        /// </summary>
        /// <param name="firstName">First name of the user.</param>
        /// <param name="lastName">Last name of the user.</param>
        /// <param name="emailId">Email id of the user.</param>
        /// <param name="phoneNumber">Phone number of the user.</param>
        /// <param name="password">Password of the user.</param>
        public void Register(string firstName, string lastName, string emailId, string phoneNumber, string password)
        {
            User user = new User();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.EmailId = emailId;
            user.PhoneNumber = phoneNumber;
            user.Password = password;
            this._repository.Add(user);
        }

        /// <summary>
        /// Fetches password from the user file.
        /// </summary>
        /// <param name="emailId">Email id whose password to be fetched.</param>
        /// <returns>Password retrieved from the user.</returns>
        public string FetchPassword(string emailId) => this._repository.FetchPassword(emailId);

        /// <summary>
        /// Checks whether email id exists in file storage.
        /// </summary>
        /// <param name="emailId">Email id entered by the user.</param>
        /// <returns>True if email id exists, else False.</returns>
        public bool IsEmailIdExists(string emailId)
        {
            return this._repository.GetUserData(emailId) != null;
        }

        /// <summary>
        /// Fetches user data from the repository.
        /// </summary>
        /// <param name="emailId">Email id of the user.</param>
        /// <returns>User data fetched from the repository</returns>
        public User GetUserData(string emailId) => _repository.GetUserData(emailId);
    }
}
