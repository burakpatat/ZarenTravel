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
    public partial class ProjectPagesGetByCustomCodesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPagesGetByCustomCodesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPagesGetByCustomCodesFunc(CustomCode={CustomCode})")]
        public IActionResult ProjectPagesGetByCustomCodesFunc([FromODataUri] string CustomCode)
        {
            this.OnProjectPagesGetByCustomCodesDefaultParams(ref CustomCode);

            var items = this.context.ProjectPagesGetByCustomCodes.FromSqlRaw("EXEC [dbo].[ProjectPagesGetByCustomCode] @CustomCode={0}", CustomCode).ToList().AsQueryable();

            this.OnProjectPagesGetByCustomCodesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPagesGetByCustomCodesDefaultParams(ref string CustomCode);

        partial void OnProjectPagesGetByCustomCodesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByCustomCode> items);
    }
}
