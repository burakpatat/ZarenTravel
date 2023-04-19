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
    public partial class ProjectTableColumnsGetByCommissionsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTableColumnsGetByCommissionsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTableColumnsGetByCommissionsFunc(Commission={Commission})")]
        public IActionResult ProjectTableColumnsGetByCommissionsFunc([FromODataUri] decimal? Commission)
        {
            this.OnProjectTableColumnsGetByCommissionsDefaultParams(ref Commission);

            var items = this.context.ProjectTableColumnsGetByCommissions.FromSqlRaw("EXEC [dbo].[ProjectTableColumnsGetByCommission] @Commission={0}", Commission).ToList().AsQueryable();

            this.OnProjectTableColumnsGetByCommissionsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTableColumnsGetByCommissionsDefaultParams(ref decimal? Commission);

        partial void OnProjectTableColumnsGetByCommissionsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByCommission> items);
    }
}
