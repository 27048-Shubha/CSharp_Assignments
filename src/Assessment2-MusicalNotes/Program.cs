using Assessment2_MusicalNotes;

namespace Assignments
{
    /// <summary>
    /// Entry point of execution.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry method point of execution.
        /// </summary>
        public static void Main()
        {
            PlaybackService service = new PlaybackService();
            service.AddDefaultNotes();

            while (true)
            {
                Console.WriteLine("Supported Notes: C#, D, D#, E, F, F#, G, G#, A ,A#, B");
                Console.WriteLine("Enter any note: ");
                string note = Console.ReadLine();

                if (service.CheckIfNoteExists(note))
                {
                    service.PlaySequence(note);
                }
                else 
                {
                    Console.WriteLine("Enter only supported notes");
                }
            }
        }
    }
}