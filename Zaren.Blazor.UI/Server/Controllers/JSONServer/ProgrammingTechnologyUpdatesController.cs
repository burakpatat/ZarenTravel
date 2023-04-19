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
    public partial class ProgrammingTechnologyUpdatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProgrammingTechnologyUpdatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProgrammingTechnologyUpdatesFunc(Id={Id},CodeFamilyName={CodeFamilyName},CodeType={CodeType},IDE={IDE})")]
        public IActionResult ProgrammingTechnologyUpdatesFunc([FromODataUri] int? Id, [FromODataUri] string CodeFamilyName, [FromODataUri] string CodeType, [FromODataUri] string IDE)
        {
            this.OnProgrammingTechnologyUpdatesDefaultParams(ref Id, ref CodeFamilyName, ref CodeType, ref IDE);

            var items = this.context.ProgrammingTechnologyUpdates.FromSqlRaw("EXEC [dbo].[ProgrammingTechnologyUpdate] @Id={0}, @CodeFamilyName={1}, @CodeType={2}, @IDE={3}", Id, CodeFamilyName, CodeType, IDE).ToList().AsQueryable();

            this.OnProgrammingTechnologyUpdatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProgrammingTechnologyUpdatesDefaultParams(ref int? Id, ref string CodeFamilyName, ref string CodeType, ref string IDE);

        partial void OnProgrammingTechnologyUpdatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProgrammingTechnologyUpdate> items);
    }
}
