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
    public partial class ProgrammingCategoryUpdatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProgrammingCategoryUpdatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProgrammingCategoryUpdatesFunc(Id={Id},TypeName={TypeName})")]
        public IActionResult ProgrammingCategoryUpdatesFunc([FromODataUri] int? Id, [FromODataUri] string TypeName)
        {
            this.OnProgrammingCategoryUpdatesDefaultParams(ref Id, ref TypeName);

            var items = this.context.ProgrammingCategoryUpdates.FromSqlRaw("EXEC [dbo].[ProgrammingCategoryUpdate] @Id={0}, @TypeName={1}", Id, TypeName).ToList().AsQueryable();

            this.OnProgrammingCategoryUpdatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProgrammingCategoryUpdatesDefaultParams(ref int? Id, ref string TypeName);

        partial void OnProgrammingCategoryUpdatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProgrammingCategoryUpdate> items);
    }
}
