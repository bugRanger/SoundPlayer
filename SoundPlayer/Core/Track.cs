namespace SoundPlayer.Core
{
    using System.Collections;
    using System.Collections.Generic;

    public class Track : IEnumerable<Note>
    {
        private readonly IEnumerable<Note> _notes;

        public string Name { get; }

        public Track(IEnumerable<Note> notes) 
        {
            _notes = notes;
            //Name = name;
        }

        public IEnumerator<Note> GetEnumerator() => _notes.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
