namespace SoundPlayer
{
    using System;
    using System.IO;
    using System.Threading;

    using Core;
    using Core.Common;
    using Core.Player;

    partial class Program
    {
        private const string FOLDER_FOR_TRACKS = "Traks";

        private static ConsolePlayer _device;
        private static AudioRepository _repository;

        static void Main(string[] args)
        {
            Console.WriteLine("Press \"Q\" for exit");

            string path = Path.Combine(Directory.GetCurrentDirectory(), FOLDER_FOR_TRACKS);

            _device = new ConsolePlayer();
            _repository = new AudioRepository(path);
            _repository.Init();

            int i = 0;
            _repository.Save(new Track($"{++i}", Zelda));
            _repository.Save(new Track($"{++i}", Sun));
            _repository.Save(new Track($"{++i}", Water));
            _repository.Save(new Track($"{++i}", Fire));
            _repository.Save(new Track($"{++i}", Shadow));
            _repository.Save(new Track($"{++i}", JBells));

            // TODO: M - make audio track.
            // TODO: P - play audio track.
            // TODO: R - recorder audio track.
            // TODO: S - stop audio track.
            // TODO: save audio track config.
            CancellationTokenSource sourceToken = null;
            
            while (true)
            {
                var pressKey = Console.ReadKey();
                switch (pressKey.Key)
                {
                    case ConsoleKey.Q:
                        return;

                    case ConsoleKey.M:
                        // TODO: Use strategy.
                        // TODO: Print console make rule. 
                        Console.WriteLine("Enter track name ");

                        do
                        {
                            Console.WriteLine("Enter note tone ");
                            Console.WriteLine("Enter note durotation ");

                            // TODO: read key.
                        } 
                        while (true);

                        // TODO: Make note.
                        // TODO: Add note list.

                        break;

                    case ConsoleKey.P:

                        Track track;
                        do
                        {
                            // TODO: Print play list for select.
                            Console.WriteLine();
                            Console.Write("Enter number track: ");
                        }
                        // TODO: Scan select track.
                        while (!_repository.TryGetValue(Console.ReadLine(), out track));

                        sourceToken?.Cancel();
                        sourceToken = new CancellationTokenSource();

                        _ = _device.Play(track, sourceToken.Token);
                        break;

                    case ConsoleKey.S:
                        sourceToken?.Cancel();
                        break;

                    default:
                        break;
                }
            }
        }


        // TODO: Move config file.
        public static Note[] Zelda =
        {
            new Note(Tone.D, Duration.HALF),
            new Note(Tone.E, Duration.EIGHTH),
            new Note(Tone.C, Duration.QUARTER),
            new Note(Tone.D, Duration.HALF),
            new Note(Tone.E, Duration.EIGHTH),
            new Note(Tone.C, Duration.QUARTER),
        };

        public static Note[] Epona =
        {
            new Note(Tone.E, Duration.QUARTER),
            new Note(Tone.D, Duration.QUARTER),
            new Note(Tone.C, Duration.QUARTER),
            new Note(Tone.E, Duration.QUARTER),
            new Note(Tone.D, Duration.QUARTER),
            new Note(Tone.C, Duration.QUARTER),
        };

        public static Note[] Saria =
        {
            new Note(Tone.B, Duration.QUARTER),
            new Note(Tone.C, Duration.QUARTER),
            new Note(Tone.D, Duration.QUARTER),
            new Note(Tone.B, Duration.QUARTER),
            new Note(Tone.C, Duration.QUARTER),
            new Note(Tone.D, Duration.QUARTER),
        };

        public static Note[] Sun =
        {
            new Note(Tone.C, Duration.QUARTER),
            new Note(Tone.B, Duration.QUARTER),
            new Note(Tone.E, Duration.QUARTER),
            new Note(Tone.C, Duration.QUARTER),
            new Note(Tone.B, Duration.QUARTER),
            new Note(Tone.E, Duration.QUARTER),
        };

        public static Note[] Time =
        {
            new Note(Tone.C, Duration.QUARTER),
            new Note(Tone.A, Duration.QUARTER),
            new Note(Tone.B, Duration.QUARTER),
            new Note(Tone.C, Duration.QUARTER),
            new Note(Tone.A, Duration.QUARTER),
            new Note(Tone.B, Duration.QUARTER),
        };

        public static Note[] Storm =
        {
            new Note(Tone.A, Duration.QUARTER),
            new Note(Tone.B, Duration.QUARTER),
            new Note(Tone.E, Duration.QUARTER),
            new Note(Tone.A, Duration.QUARTER),
            new Note(Tone.B, Duration.QUARTER),
            new Note(Tone.E, Duration.QUARTER),
        };

        public static Note[] Forest =
        {
            new Note(Tone.A, Duration.QUARTER),
            new Note(Tone.E, Duration.QUARTER),
            new Note(Tone.D, Duration.QUARTER),
            new Note(Tone.C, Duration.QUARTER),
            new Note(Tone.D, Duration.QUARTER),
            new Note(Tone.C, Duration.QUARTER),
        };

        public static Note[] Fire =
        {
            new Note(Tone.B, Duration.QUARTER),
            new Note(Tone.A, Duration.QUARTER),
            new Note(Tone.B, Duration.QUARTER),
            new Note(Tone.A, Duration.QUARTER),
            new Note(Tone.C, Duration.QUARTER),
            new Note(Tone.B, Duration.QUARTER),
            new Note(Tone.C, Duration.QUARTER),
            new Note(Tone.B, Duration.QUARTER),
        };

        public static Note[] Water =
        {
            new Note(Tone.A, Duration.QUARTER),
            new Note(Tone.B, Duration.QUARTER),
            new Note(Tone.C, Duration.QUARTER),
            new Note(Tone.C, Duration.QUARTER),
            new Note(Tone.D, Duration.QUARTER),
        };

        public static Note[] Spirit =
        {
            new Note(Tone.A, Duration.QUARTER),
            new Note(Tone.B, Duration.QUARTER),
            new Note(Tone.A, Duration.QUARTER),
            new Note(Tone.C, Duration.QUARTER),
            new Note(Tone.B, Duration.QUARTER),
            new Note(Tone.A, Duration.QUARTER),
        };

        public static Note[] Shadow =
        {
            new Note(Tone.D, Duration.QUARTER),
            new Note(Tone.C, Duration.QUARTER),
            new Note(Tone.C, Duration.QUARTER),
            new Note(Tone.A, Duration.QUARTER),
            new Note(Tone.D, Duration.QUARTER),
            new Note(Tone.C, Duration.QUARTER),
            new Note(Tone.B, Duration.QUARTER),
        };

        public static Note[] Light =
        {
            new Note(Tone.E, Duration.QUARTER),
            new Note(Tone.C, Duration.QUARTER),
            new Note(Tone.E, Duration.QUARTER),
            new Note(Tone.C, Duration.QUARTER),
            new Note(Tone.D, Duration.QUARTER),
            new Note(Tone.E, Duration.QUARTER),
        };

        public static Note[] JBells =
        {
            new Note(Tone.E, Duration.QUARTER),
            new Note(Tone.E, Duration.QUARTER),
            new Note(Tone.E, Duration.HALF),

            new Note(Tone.E, Duration.QUARTER),
            new Note(Tone.E, Duration.QUARTER),
            new Note(Tone.E, Duration.HALF),

            new Note(Tone.E, Duration.QUARTER),
            new Note(Tone.Gsharp, Duration.QUARTER),
            new Note(Tone.C, Duration.QUARTER),
            new Note(Tone.D, Duration.QUARTER),

            new Note(Tone.E, Duration.WHOLE),

            new Note(Tone.F, Duration.QUARTER),
            new Note(Tone.F, Duration.QUARTER),
            new Note(Tone.F, Duration.QUARTER),
            new Note(Tone.F, Duration.QUARTER),

            new Note(Tone.F, Duration.QUARTER),
            new Note(Tone.E, Duration.QUARTER),
            new Note(Tone.E, Duration.QUARTER),
            new Note(Tone.E, Duration.QUARTER),

        };
    }
}
