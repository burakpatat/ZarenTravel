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
    public partial class ProjectTableColumnsGetByIsPrimariesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTableColumnsGetByIsPrimariesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTableColumnsGetByIsPrimariesFunc(IsPrimary={IsPrimary})")]
        public IActionResult ProjectTableColumnsGetByIsPrimariesFunc([FromODataUri] bool? IsPrimary)
        {
            this.OnProjectTableColumnsGetByIsPrimariesDefaultParams(ref IsPrimary);

            var items = this.context.ProjectTableColumnsGetByIsPrimaries.FromSqlRaw("EXEC [dbo].[ProjectTableColumnsGetByIsPrimary] @IsPrimary={0}", IsPrimary).ToList().AsQueryable();

            this.OnProjectTableColumnsGetByIsPrimariesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTableColumnsGetByIsPrimariesDefaultParams(ref bool? IsPrimary);

        partial void OnProjectTableColumnsGetByIsPrimariesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByIsPrimary> items);
    }
}
