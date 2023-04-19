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
    public partial class ProjectPagesGetByJsonCodesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPagesGetByJsonCodesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPagesGetByJsonCodesFunc(JsonCode={JsonCode})")]
        public IActionResult ProjectPagesGetByJsonCodesFunc([FromODataUri] string JsonCode)
        {
            this.OnProjectPagesGetByJsonCodesDefaultParams(ref JsonCode);

            var items = this.context.ProjectPagesGetByJsonCodes.FromSqlRaw("EXEC [dbo].[ProjectPagesGetByJsonCode] @JsonCode={0}", JsonCode).ToList().AsQueryable();

            this.OnProjectPagesGetByJsonCodesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPagesGetByJsonCodesDefaultParams(ref string JsonCode);

        partial void OnProjectPagesGetByJsonCodesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByJsonCode> items);
    }
}
