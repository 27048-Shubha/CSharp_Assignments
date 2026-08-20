namespace CarWashManagement.Repository
{
    using CarWashManagement.Models;
    using System.Text.Json;

    /// <summary>
    /// Manages file operations from the user.
    /// </summary>
    public class UserRepository
    {
        private List<User> _users;
        private readonly string _filePath = Path.GetFullPath(Path.Combine(@"../../../Data/Users.json"));

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        internal UserRepository()
        {
            this._users = new List<User>();
        }

        public User GetUserData(string userEmail)
        {
            this._users = this.ReadFromJson();
            return _users.Find(user => user.EmailId == userEmail);
        }

        public void Add(User newUserData)
        {
            List<User> existingUsers = ReadFromJson();
            this._users.Add(newUserData);
            File.WriteAllText(_filePath, JsonSerializer.Serialize(this._users));
        }

        public string FetchPassword(string inputEmail)
        {
            List<User> existingUsers = ReadFromJson();
            User matchedUser = existingUsers.Find(user => user.EmailId == inputEmail);
            if(matchedUser is null)
            {
                return string.Empty;
            }
            else
            {
                return matchedUser.Password;
            }
        }

        public List<User> ReadFromJson()
        {
            string jsonData = File.ReadAllText(_filePath);

            if (string.IsNullOrEmpty(jsonData))
            {
                return new List<User>();
            }
            else if (jsonData.StartsWith("{"))
            {
                return new List<User>() { JsonSerializer.Deserialize<User>(jsonData) ?? new User() };
            }
            else if (jsonData.StartsWith("["))
            {
                List<User> existingUser = JsonSerializer.Deserialize<List<User>>(jsonData);
                return existingUser is null ? new List<User>() : existingUser;
            }

            return new List<User>();
        }
    }
}
