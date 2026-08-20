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

        /// <summary>
        /// Gets data from json file.
        /// </summary>
        /// <param name="userEmail">Email id of the user whose data to be fetched.</param>
        /// <returns>User data</returns>
        public User GetUserData(string userEmail)
        {
            this._users = this.ReadFromJson();
            return _users.Find(user => user.EmailId == userEmail);
        }

        /// <summary>
        /// Adds new user to the json file.
        /// </summary>
        /// <param name="newUserData">New user to be added to the json file.</param>
        public void Add(User newUserData)
        {
            List<User> existingUsers = ReadFromJson();
            this._users.Add(newUserData);
            File.WriteAllText(_filePath, JsonSerializer.Serialize(this._users));
        }

        /// <summary>
        /// Fetches password from the json file.
        /// </summary>
        /// <param name="inputEmail">Email id of the user whose password to be fetched.</param>
        /// <returns>Password of the respectived email id.</returns>
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

        /// <summary>
        /// Returns list of users from json file.
        /// </summary>
        /// <returns>List of users stored in json file.</returns>
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
