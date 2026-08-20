namespace CarWashManagement.Service
{
    using CarWashManagement.Models;
    using CarWashManagement.Repository;

    public class UserService
    {
        private readonly UserRepository _repository = null;

        internal UserService(UserRepository repository)
        {
            this._repository = repository;
        }

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

        public string FetchPassword(string emailId) => this._repository.FetchPassword(emailId);

        public bool IsEmailIdExists(string emailId)
        {
            return this._repository.GetUserData(emailId) != null;
        }

        public User GetUserData(string emailId) => _repository.GetUserData(emailId);
    }
}
