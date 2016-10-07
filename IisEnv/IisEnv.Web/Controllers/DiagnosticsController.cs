using IisEnv.Web.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Web.Http;

namespace IisEnv.Web.Controllers
{
    public class DiagnosticsController : ApiController
    {
        public DiagnosticsModel Get()
        {
            var diagnostics = new DiagnosticsModel("IIS env test");

            try
            {
                diagnostics.MachineDate = DateTime.Now;
                diagnostics.MachineName = Environment.MachineName;
                diagnostics.MachineCulture = $"{CultureInfo.CurrentCulture.DisplayName} - {CultureInfo.CurrentCulture.Name}";
                diagnostics.MachineTimeZone = TimeZone.CurrentTimeZone.IsDaylightSavingTime(diagnostics.MachineDate) ?
                                              TimeZone.CurrentTimeZone.DaylightName :
                                              TimeZone.CurrentTimeZone.StandardName;
                diagnostics.DnsHostName = Dns.GetHostName();
                diagnostics.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;

                diagnostics.ApplicationVersionNumber = this.GetType().Assembly.GetName().Version.ToString();
                diagnostics.IpAddressList = GetIpAddressList(diagnostics);
                diagnostics.Environment.MachineVariables = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Machine);
                diagnostics.Environment.ProcessVariables = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Process);
                diagnostics.Environment.UserVariables = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.User);
                diagnostics.Status = "OK";
            }
            catch (Exception ex)
            {
                diagnostics.Status = $"FAIL - diagnostic check threw error: {ex}";
            }

            return diagnostics;
        }

        private static IEnumerable<string> GetIpAddressList(DiagnosticsModel model)
        {
            var ipHost = Dns.GetHostEntry(model.DnsHostName);
            var ipList = new List<string>(ipHost.AddressList.Length);
            foreach (var ipAddress in ipHost.AddressList)
            {
                ipList.Add(ipAddress.ToString());
            }
            return ipList;
        }        
    }
}