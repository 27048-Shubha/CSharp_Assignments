namespace ContactManager.Enums
{
    /// <summary>
    /// Enum indicating status of inputs.
    /// </summary>
    internal enum Status
    {
        /// <summary>
        /// Indicates input already exists.
        /// </summary>
        DuplicateExists = -1,

        /// <summary>
        /// Indicates input is null
        /// </summary>
        NullInput = -2,

        /// <summary>
        /// Indicates input phone number is invalid.
        /// </summary>
        InvalidPhoneNumber = -3,

        /// <summary>
        /// Indicates input email id is invalid.
        /// </summary>
        InvalidEmailId = -4,

        /// <summary>
        /// Indicates the input is not found.
        /// </summary>
        NotFound = -5,

        /// <summary>
        /// Indicates that input is invalid.
        /// </summary>
        InvalidInput = -6,

        /// <summary>
        /// Indicates successful acceptance of the input.
        /// </summary>
        Success,
    }
}
