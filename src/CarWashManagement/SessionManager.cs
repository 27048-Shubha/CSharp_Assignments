using CarWashManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashManagement
{
    /// <summary>
    /// Handles session based on the user.
    /// </summary>
    public static class SessionManager
    {
        /// <summary>
        /// Data of current logged in user.
        /// </summary>
        /// <value> User data </value>
        public static User CurrentUser { get; set; }
    }
}
