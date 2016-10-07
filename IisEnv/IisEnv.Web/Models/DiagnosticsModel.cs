using System;
using System.Collections.Generic;

namespace IisEnv.Web.Models
{
    public class DiagnosticsModel
    {
        public string ApplicationName { get; set; }

        public string ApplicationVersionNumber { get; set; }

        public string Status { get; set; }

        public string WorkingDirectory { get; set; }

        public string DnsHostName { get; set; }

        public string MachineName { get; set; }

        public DateTime MachineDate { get; set; }

        public string MachineCulture { get; set; }

        public string MachineTimeZone { get; set; }

        public IEnumerable<string> IpAddressList { get; set; }

        public EnvironmentSet Environment { get; set; }
        
        public DiagnosticsModel(string applicationName)
        {
            ApplicationName = applicationName;
            Environment = new EnvironmentSet();
        }
    }
}