using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace RimDev.AspNet.Diagnostics.HealthChecks
{
    public class HealthCheckConfig
    {
        public string Name { get; set; }
        public IHealthCheck HealthCheck { get; set; }

        public HealthCheckConfig(string name, IHealthCheck healthCheck)
        {
            this.Name = name;
            this.HealthCheck = healthCheck;
        }
    }
}
