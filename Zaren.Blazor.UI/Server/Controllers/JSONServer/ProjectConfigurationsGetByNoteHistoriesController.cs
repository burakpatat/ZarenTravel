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
    public partial class ProjectConfigurationsGetByNoteHistoriesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByNoteHistoriesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByNoteHistoriesFunc(NoteHistory={NoteHistory})")]
        public IActionResult ProjectConfigurationsGetByNoteHistoriesFunc([FromODataUri] string NoteHistory)
        {
            this.OnProjectConfigurationsGetByNoteHistoriesDefaultParams(ref NoteHistory);

            var items = this.context.ProjectConfigurationsGetByNoteHistories.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByNoteHistory] @NoteHistory={0}", NoteHistory).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByNoteHistoriesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByNoteHistoriesDefaultParams(ref string NoteHistory);

        partial void OnProjectConfigurationsGetByNoteHistoriesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByNoteHistory> items);
    }
}
