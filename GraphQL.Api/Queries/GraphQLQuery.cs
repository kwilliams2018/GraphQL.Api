using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace GraphQL.Api.Queries
{
    public class GraphQLQuery
    {
        public string Operation { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
        public JObject Object { get; set; }
    }
}
