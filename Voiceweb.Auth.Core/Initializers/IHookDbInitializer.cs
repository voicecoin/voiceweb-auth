using EntityFrameworkCore.BootKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Voiceweb.Auth.Core.Initializers
{
    /// <summary>
    /// Initialize data for modules
    /// </summary>
    public interface IHookDbInitializer
    {
        /// <summary>
        /// value smaller is higher priority
        /// </summary>
        int Priority { get; }
        void Load(Database dc);
    }
}
