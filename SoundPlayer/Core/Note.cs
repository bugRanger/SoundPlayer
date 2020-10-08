namespace SoundPlayer.Core
{
    // Define a note as a frequency (tone) and the amount of 
    // time (duration) the note plays.
    public class Note
    {
        public Tone Tone { get; }

        public Duration Duration { get; }

        public Note(Tone tone, Duration duration)
        {
            Tone = tone;
            Duration = duration;
        }
    }
}
