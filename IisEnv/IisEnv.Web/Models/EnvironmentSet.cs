using System.Collections;

namespace IisEnv.Web.Models
{
    public class EnvironmentSet
    {
        public IDictionary MachineVariables { get; set; }

        public IDictionary ProcessVariables { get; set; }

        public IDictionary UserVariables { get; set; }
    }
}