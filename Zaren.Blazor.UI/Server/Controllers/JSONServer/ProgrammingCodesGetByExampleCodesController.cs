using System;
using System.Net;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ZarenUI.Server.Controllers.JSONServer
{
    public partial class ProgrammingCodesGetByExampleCodesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProgrammingCodesGetByExampleCodesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProgrammingCodesGetByExampleCodesFunc(ExampleCodes={ExampleCodes})")]
        public IActionResult ProgrammingCodesGetByExampleCodesFunc([FromODataUri] string ExampleCodes)
        {
            this.OnProgrammingCodesGetByExampleCodesDefaultParams(ref ExampleCodes);

            var items = this.context.ProgrammingCodesGetByExampleCodes.FromSqlRaw("EXEC [dbo].[ProgrammingCodesGetByExampleCodes] @ExampleCodes={0}", ExampleCodes).ToList().AsQueryable();

            this.OnProgrammingCodesGetByExampleCodesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProgrammingCodesGetByExampleCodesDefaultParams(ref string ExampleCodes);

        partial void OnProgrammingCodesGetByExampleCodesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProgrammingCodesGetByExampleCode> items);
    }
}
