namespace SoundPlayer
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using SoundPlayer.Core.Common;

    public interface IPlayDevice
    {
        #region Methods

        Task Play(IEnumerable<Note> notes, CancellationToken token);

        #endregion Methods
    }
}