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
    public partial class ProjectTableColumnsGetByMaxLengthsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTableColumnsGetByMaxLengthsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTableColumnsGetByMaxLengthsFunc(MaxLength={MaxLength})")]
        public IActionResult ProjectTableColumnsGetByMaxLengthsFunc([FromODataUri] string MaxLength)
        {
            this.OnProjectTableColumnsGetByMaxLengthsDefaultParams(ref MaxLength);

            var items = this.context.ProjectTableColumnsGetByMaxLengths.FromSqlRaw("EXEC [dbo].[ProjectTableColumnsGetByMaxLength] @MaxLength={0}", MaxLength).ToList().AsQueryable();

            this.OnProjectTableColumnsGetByMaxLengthsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTableColumnsGetByMaxLengthsDefaultParams(ref string MaxLength);

        partial void OnProjectTableColumnsGetByMaxLengthsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByMaxLength> items);
    }
}
