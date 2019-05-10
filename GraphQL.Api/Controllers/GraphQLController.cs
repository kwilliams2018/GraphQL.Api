using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GraphQL.Types;
using GraphQL.Api.Context;
using GraphQL.Api.Queries;

namespace GraphQL.Api.Controllers
{
    [Route("1.0")]
    [ApiController]
    public class GraphQLController : Controller
    {
        private readonly GraphQLDataContext _context;

        public GraphQLController(GraphQLDataContext context) => _context = context;

        [HttpPost]
        public async Task<IActionResult> Query([FromBody] GraphQLQuery query)
        {
            var inputs = query.Variables.ToInputs();

            var schema = new Schema
            {
                Query = new CRMQuery(_context)
            };

            var result = await new DocumentExecuter().ExecuteAsync(x =>
            {
                x.Schema = schema;
                x.Query = query.Query;
                //x.OperationName = query.OperationName;
                x.Inputs = inputs;
            });

            if (result.Errors?.Count > 0)
                return Ok(result.Errors);

            return Ok(result);
        }
    }
}
