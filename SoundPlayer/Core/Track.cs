namespace SoundPlayer.Core
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class Track
    {
        private Note[] _notes;

        public Track(Note[] notes) 
        {
            _notes = notes;
        }

        public async void Play(ISoundDevice device, CancellationToken token)
        {
            new Thread(() =>
            //await Task.Run(async () =>
            {
                foreach (Note note in _notes)
                {
                    //if (token.IsCancellationRequested)
                    //    break;
                    //else 
                    if (note.Tone == Tone.REST)
                        Thread.Sleep((int)note.Duration);
                    else
                        device.Play(note);
                }
            }).Start();
            //token);
        }
    }
}
