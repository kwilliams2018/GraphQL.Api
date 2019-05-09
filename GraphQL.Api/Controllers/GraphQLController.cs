using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using GraphQL.DataModel;
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

        public async Task<IActionResult> Query([FromBody] GraphQLQuery query)
        {
            var inputs = query.Object.ToInputs();

            var schema = new Schema
            {
                Query = new Queries.User(_context)
            };

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query.Query;
                _.OperationName = query.Operation;
                _.Inputs = inputs;
            });

            if (result.Errors?.Count > 0)
                return BadRequest();

            return Ok(result);
        }
    }
}
