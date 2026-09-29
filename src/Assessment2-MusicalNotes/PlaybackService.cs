using Assessment2_MusicalNotes.Models;

namespace Assessment2_MusicalNotes
{
    /// <summary>
    /// Demonstrate playback service for musical note demonstration.
    /// </summary>
    public class PlaybackService
    {
        /// <summary>
        /// Represents list of musical notes.
        /// </summary>
        public List<String> Notes = new List<string>();

        /// <summary>
        /// Adds default notes to the list.
        /// </summary>
        public void AddDefaultNotes()
        {
            this.Notes.Add("C#");
            this.Notes.Add("D");
            this.Notes.Add("D#");
            this.Notes.Add("E");
            this.Notes.Add("F");
            this.Notes.Add("F#");
            this.Notes.Add("G");
            this.Notes.Add("G#");
            this.Notes.Add("A");
            this.Notes.Add("A#");
            this.Notes.Add("B");
            this.Notes.Add("C#");
        }

        /// <summary>
        /// Checks whether a note exists
        /// </summary>
        /// <param name="note">Note to be checked</param>
        /// <returns>True if note exists, else false.</returns>
        public bool CheckIfNoteExists(string note)
        {
            return Notes.FindIndex(musicalNote => musicalNote == note) != -1;
        }

        /// <summary>
        /// Plays sequence of notes.
        /// </summary>
        /// <param name="name">Note to be played.</param>
        public void PlaySequence(string name)
        {
            MusicalNote note = new MusicalNote();
            note.Name = name;
            note.Frequency = this.FetchFrequency(note.Name);
            note.Duration = this.FetchPlayTime(note.Name);

            Console.WriteLine($"Playing note: {note.Name}");
            Console.Beep((int)note.Frequency, (int)note.Duration);
        }

        /// <summary>
        /// Fetches frequency of a note.
        /// </summary>
        /// <param name="noteName">Note entered by the user.</param>
        /// <returns>Frequency of a note.</returns>
        public decimal FetchFrequency(string noteName)
        {
            switch (noteName)
            {
                case "C":
                    return 261.63m;

                case "C#":
                    return 277.18m;

                case "D":
                    return 293.66m;

                case "D#":
                    return 311.13m;

                case "E":
                    return 329.63m;

                case "F":
                    return 349.23m;

                case "F#":
                    return 369.99m;

                case "G":
                    return 392.00m;

                case "G#":
                    return 415.30m;

                case "A":
                    return 440.00m;

                case "A#":
                    return 466.16m;

                case "B":
                    return 493.88m;

                default:
                    return 500m;
            }
        }

        /// <summary>
        /// Fetches playtime of a note.
        /// </summary>
        /// <param name="noteName">Note entered by the user.</param>
        /// <returns>Playtime of a note.</returns>
        public decimal FetchPlayTime(string noteName)
        {
            switch (noteName)
            {
                case "C":
                    return 200;

                case "C#":
                    return 100;

                case "D":
                    return 300;

                default:
                    return 120;
            }
        }
    }
}
