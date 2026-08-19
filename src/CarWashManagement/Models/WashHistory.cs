using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashManagement.Models
{
    /// <summary>
    /// Represents data model about the vehicle wash history.
    /// </summary>
    public class WashHistory
    {
        /// <summary>
        /// Unique entry number for the wash schedule of the vehicle.
        /// </summary>
        private Guid _entryNumber;

        /// <summary>
        /// Unique registration id of the vehicle.
        /// </summary>
        private Guid _registerNumber;

        /// <summary>
        /// Start time of the vechilce wash.
        /// </summary>
        private DateTime _startTime;

        /// <summary>
        /// End time of the vehicle wash.
        /// </summary>
        private DateTime _endTime;

        /// <summary>
        /// Flag to indicate status whether vehicle is under wash.
        /// </summary>
        private bool _isUnderWash;

        /// <summary>
        /// Gets or initializes unique entry number for washing schedule of the vehicle.
        /// </summary>
        /// <value>Unique entry number indicating wash schedule of the vehicle.</value>
        public Guid EntryNumber { get; init; }

        /// <summary>
        /// Gets or sets registration number of the vehicle.
        /// </summary>
        /// <value>Unique registration number given to the vehicle.</value>
        public Guid RegisterNumber { get; set; }

        /// <summary>
        /// Gets or sets starting time of the washing schedule.
        /// </summary>
        /// <value>Start time of the vehicle wash operation.</value>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Gets or sets ending time of the washing schedule.
        /// </summary>
        /// <value>End time of the vehicle wash operation.</value>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the vehicle is under washing operation.
        /// </summary>
        /// <value>Flag to indicate whether the vehicle is under washing operation.</value>
        public bool IsUnderWash { get; set; }
    }
}
