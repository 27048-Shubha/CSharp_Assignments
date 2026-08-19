namespace CarWashManagement.Models
{
    /// <summary>
    /// Represents data model of the vehicle.
    /// </summary>
    public class Vehicle
    {
        /// <summary>
        /// Unique id to represent vehicle data.
        /// </summary>
        private Guid _vehicleId;

        /// <summary>
        /// Unique registration number of the vehicle.
        /// </summary>
        private string _registerNumber;

        /// <summary>
        /// Name of the vehicle.
        /// </summary>
        private string _vehicleName;

        /// <summary>
        /// Owner of the vehicle.
        /// </summary>
        private Guid _userId;

        /// <summary>
        /// Gets or initializes unique id to the vehicle.
        /// </summary>
        /// <value>Unique id of the vehicle.</value>
        public Guid VehicleId { get; init; }

        /// <summary>
        /// Gets or sets register number of the vehicle.
        /// </summary>
        /// <value>Register number of the vehicle</value>
        public string RegisterNumber
        {
            get => this._registerNumber;
            set
            {
                this._registerNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets name of the vehicle.
        /// </summary>
        /// <value>Name of the vehicle.</value>
        public string VehicleName { get; set; }

        /// <summary>
        /// Gets or sets id of the owner of the vehicle.
        /// </summary>
        /// <value>Id of the owner of the vehicle.</value>
        public Guid UserId { get; set; }
    }
}
