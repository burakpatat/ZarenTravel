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
    public partial class ProgrammingTechnologyInsertsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProgrammingTechnologyInsertsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProgrammingTechnologyInsertsFunc(CodeFamilyName={CodeFamilyName},CodeType={CodeType},IDE={IDE})")]
        public IActionResult ProgrammingTechnologyInsertsFunc([FromODataUri] string CodeFamilyName, [FromODataUri] string CodeType, [FromODataUri] string IDE)
        {
            this.OnProgrammingTechnologyInsertsDefaultParams(ref CodeFamilyName, ref CodeType, ref IDE);

            var items = this.context.ProgrammingTechnologyInserts.FromSqlRaw("EXEC [dbo].[ProgrammingTechnologyInsert] @CodeFamilyName={0}, @CodeType={1}, @IDE={2}", CodeFamilyName, CodeType, IDE).ToList().AsQueryable();

            this.OnProgrammingTechnologyInsertsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProgrammingTechnologyInsertsDefaultParams(ref string CodeFamilyName, ref string CodeType, ref string IDE);

        partial void OnProgrammingTechnologyInsertsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProgrammingTechnologyInsert> items);
    }
}
