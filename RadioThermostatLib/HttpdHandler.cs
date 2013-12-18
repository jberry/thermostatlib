using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThermostatLib
{
    public class HttpdHandler
    {
        /// <summary>Relative Url of the HTTP Handler</summary>
        public string Url;

        /// <summary>Does the handler accept GET requests</summary>
        public bool AllowsGet;

        /// <summary>Does the handler accept POST requests</summary>
        public bool AllowsPost;

    }
}
