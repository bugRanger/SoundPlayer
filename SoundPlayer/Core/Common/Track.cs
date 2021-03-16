namespace SoundPlayer.Core.Common
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class Track : IEnumerable<Note>
    {
        #region Fields

        private readonly IEnumerable<Note> _notes;

        #endregion Fields

        #region Properties

        public string Name { get; }

        #endregion Properties

        #region Constructor

        public Track(string name, IEnumerable<Note> notes)
        {
            _notes = notes;

            Name = name;
        }

        #endregion Constructor

        #region Methods

        public IEnumerator<Note> GetEnumerator() => _notes.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion Methods
    }
}
