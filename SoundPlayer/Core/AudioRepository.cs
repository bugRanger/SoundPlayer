namespace SoundPlayer.Core
{
    using System;
    using System.IO;
    using System.Text.Json;
    using System.Collections.Generic;

    using NLog;

    using Common;

    public class AudioRepository
    {
        #region Fields

        private readonly ILogger _logger;
        private readonly string _folder;
        private readonly SortedDictionary<string, Track> _tracks;
        private readonly JsonSerializerOptions _jsonOptions;

        #endregion Fields

        #region Constructor

        public AudioRepository(string folder) 
        {
            _logger = LogManager.GetCurrentClassLogger();

            _folder = folder;
            _tracks = new SortedDictionary<string, Track>();
            _jsonOptions = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
            };
        }

        #endregion Constructor

        #region Methods

        public bool TryGetValue(string name, out Track track)
        {
            return _tracks.TryGetValue(name, out track);
        }

        public void Init() 
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_folder))
                    throw new ArgumentNullException(nameof(_folder));

                _tracks.Clear();

                foreach (string file in Directory.EnumerateFiles(_folder))
                {
                    var track = Load(file);
                    if (track == null)
                    {
                        _logger.Warn($"Not loaded: {file}");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }

        public void Save(Track track)
        {
            try
            {
                if (_folder == null)
                    throw new ArgumentNullException(nameof(_folder));

                if (track == null)
                    throw new ArgumentNullException(nameof(track));

                if (string.IsNullOrWhiteSpace(track.Name))
                    throw new ArgumentNullException(nameof(track.Name));

                var path = Path.Combine(_folder, track.Name);
                var content = JsonSerializer.Serialize(track, _jsonOptions);

                if (!Directory.Exists(_folder))
                    Directory.CreateDirectory(_folder);

                using StreamWriter file = File.CreateText(path);
                try
                {
                    file.Write(content);
                }
                finally
                {
                    file.Close();
                }

                _tracks[track.Name] = track;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }

        public Track Load(string name) 
        {
            Track track = null;

            try
            {
                if (_folder == null)
                    throw new ArgumentNullException(nameof(_folder));

                if (string.IsNullOrWhiteSpace(name))
                    throw new ArgumentNullException(nameof(name));

                var path = Path.Combine(_folder, name);
                var content = File.ReadAllBytes(path);

                var notes = JsonSerializer.Deserialize<IEnumerable<Note>>(content, _jsonOptions);

                track = new Track(name, notes);

                _tracks[track.Name] = track;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }

            return track;
        }

        #endregion Methods
    }
}
