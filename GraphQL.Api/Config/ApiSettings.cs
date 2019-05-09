﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Api.Config
{
    public class ApiSettings
    {
        public string[] CORS { get; set; }
        public Dictionary<string, string> ConnectionStrings { get; set; }
    }
}
