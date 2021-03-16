namespace SoundPlayer.Core.Player
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using Core;
    using Core.Common;

    public class ConsolePlayer : IPlayDevice
    {
        private IEnumerable<Note> _lastNotes;

        public async Task Play(IEnumerable<Note> notes, CancellationToken token)
        {
            _lastNotes = notes;
            await Task.Run(async () =>
            {
                foreach (Note note in _lastNotes)
                {
                    if (token.IsCancellationRequested)
                        break;

                    if (note.Tone != Tone.REST)
                        _ = Task.Run(() => Console.Beep((int)note.Tone, (int)note.Duration + 10));

                    await Task.Delay((int)note.Duration, token);
                }
            },
            token);
        }
    }
}
