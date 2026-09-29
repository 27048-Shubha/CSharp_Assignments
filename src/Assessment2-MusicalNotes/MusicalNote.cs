namespace Assessment2_MusicalNotes.Models
{
    /// <summary>
    /// Represents properties of a musical note.
    /// </summary>
    public class MusicalNote
    {
        /// <summary>
        /// Gets or sets frequency of a musical note.
        /// </summary>
        /// <value>Frequency of a musical note</value>
        public decimal Frequency { get; set; }

        /// <summary>
        /// Gets or sets name of a musical note.
        /// </summary>
        /// <value>Name of a musical note</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets duration of a musical note.
        /// </summary>
        /// <value>Duration of a musical note</value>
        public decimal Duration { get; set; }
    }
}
