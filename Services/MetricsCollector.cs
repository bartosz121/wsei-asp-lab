using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wsei_Lab5.Models;

namespace Wsei_Lab5.Services
{
    public class MetricsCollector : IMetricsCollector
    {
        public readonly List<CollectedRequestModel> _requests = new List<CollectedRequestModel>();

        public void Record(string httpMethod, string requestUrl, int responseCode) {
            var request = new CollectedRequestModel
            {
                HttpMethod = httpMethod,
                RequestUrl = requestUrl,
                ResponseCode = responseCode,
            };

            _requests.Add(request);
        }

        public IEnumerable<EndpointStats> GetEndpointStats()
        {
            var requestsByMethodAndUrl = _requests.GroupBy(x => new { x.HttpMethod, x.RequestUrl});
            var requestsCounts = requestsByMethodAndUrl.Select(x => new EndpointStats 
            { 
                HttpMethod = x.Key.HttpMethod,
                RequestUrl = x.Key.RequestUrl,
                RequestCount = x.Count(),
            });

            return requestsCounts;
        }
    }
}
