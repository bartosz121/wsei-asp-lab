using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wsei_Lab5.Models;

namespace Wsei_Lab5.Services
{
    public interface IMetricsCollector
    {
        void Record(string httpMethod, string requestUrl, int responseCode);

        IEnumerable<EndpointStats> GetEndpointStats();
    }
}
