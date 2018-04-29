using System;
using System.Collections.Generic;
using System.Text;

namespace Voiceweb.Auth.Core.EmailHelpers
{
    public class EmailRequestModel
    {
        public string Subject { get; set; }
        /// <summary>
        /// Support mutiple addresses seperated by comma
        /// </summary>
        public string ToAddresses { get; set; }
        public string Body { get; set; }
        public string From { get; set; }
        public string Bcc { get; set; }
        public string Cc { get; set; }
        /// <summary>
        /// Template file name
        /// </summary>
        public string Template { get; set; }
    }
}
