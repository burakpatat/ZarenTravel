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
    public partial class ProjectPagesGetByIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPagesGetByIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPagesGetByIdsFunc(Id={Id})")]
        public IActionResult ProjectPagesGetByIdsFunc([FromODataUri] int? Id)
        {
            this.OnProjectPagesGetByIdsDefaultParams(ref Id);

            var items = this.context.ProjectPagesGetByIds.FromSqlRaw("EXEC [dbo].[ProjectPagesGetByID] @Id={0}", Id).ToList().AsQueryable();

            this.OnProjectPagesGetByIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPagesGetByIdsDefaultParams(ref int? Id);

        partial void OnProjectPagesGetByIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPagesGetById> items);
    }
}
