using System;
using System.Collections.Generic;
using System.Text;

namespace Voiceweb.Auth.Core.Initializers
{
    /// <summary>
    /// Implement a customzied loader
    /// </summary>
    public interface IInitializationLoader
    {
        int Priority { get; }
        void Initialize();
    }
}
