using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Enums
{
    /// <summary>
    /// Represents the type of a storage.
    /// </summary>
    internal enum Storage
    {
        /// <summary>
        /// Represents inmemory storage.
        /// </summary>
        InMemory = 1,

        /// <summary>
        /// Represents json file storage.
        /// </summary>
        JsonFile,
    }
}
