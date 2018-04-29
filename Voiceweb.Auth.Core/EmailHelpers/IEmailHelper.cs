using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Voiceweb.Auth.Core.EmailHelpers
{
    public interface IEmailHelper
    {
        Task<string> Send(EmailRequestModel model, IConfiguration config);
    }
}
