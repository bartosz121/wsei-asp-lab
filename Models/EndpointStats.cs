﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wsei_Lab5.Models
{
    public class EndpointStats
    {
        public string HttpMethod { get; set; }
        public string RequestUrl { get; set; }
        public int RequestCount { get; set; }
    }
}
