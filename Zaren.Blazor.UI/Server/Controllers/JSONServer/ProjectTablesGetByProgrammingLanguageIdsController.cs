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
    public partial class ProjectTablesGetByProgrammingLanguageIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTablesGetByProgrammingLanguageIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTablesGetByProgrammingLanguageIdsFunc(ProgrammingLanguageId={ProgrammingLanguageId})")]
        public IActionResult ProjectTablesGetByProgrammingLanguageIdsFunc([FromODataUri] int? ProgrammingLanguageId)
        {
            this.OnProjectTablesGetByProgrammingLanguageIdsDefaultParams(ref ProgrammingLanguageId);

            var items = this.context.ProjectTablesGetByProgrammingLanguageIds.FromSqlRaw("EXEC [dbo].[ProjectTablesGetByProgrammingLanguageId] @ProgrammingLanguageId={0}", ProgrammingLanguageId).ToList().AsQueryable();

            this.OnProjectTablesGetByProgrammingLanguageIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTablesGetByProgrammingLanguageIdsDefaultParams(ref int? ProgrammingLanguageId);

        partial void OnProjectTablesGetByProgrammingLanguageIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByProgrammingLanguageId> items);
    }
}
