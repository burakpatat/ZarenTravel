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
    public partial class ProjectTableColumnsGetByIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTableColumnsGetByIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTableColumnsGetByIdsFunc(Id={Id})")]
        public IActionResult ProjectTableColumnsGetByIdsFunc([FromODataUri] int? Id)
        {
            this.OnProjectTableColumnsGetByIdsDefaultParams(ref Id);

            var items = this.context.ProjectTableColumnsGetByIds.FromSqlRaw("EXEC [dbo].[ProjectTableColumnsGetByID] @Id={0}", Id).ToList().AsQueryable();

            this.OnProjectTableColumnsGetByIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTableColumnsGetByIdsDefaultParams(ref int? Id);

        partial void OnProjectTableColumnsGetByIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetById> items);
    }
}
