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
    public partial class ProjectTableColumnsGetByColumnNameI18SController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTableColumnsGetByColumnNameI18SController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTableColumnsGetByColumnNameI18SFunc(ColumnNameI18={ColumnNameI18})")]
        public IActionResult ProjectTableColumnsGetByColumnNameI18SFunc([FromODataUri] string ColumnNameI18)
        {
            this.OnProjectTableColumnsGetByColumnNameI18SDefaultParams(ref ColumnNameI18);

            var items = this.context.ProjectTableColumnsGetByColumnNameI18S.FromSqlRaw("EXEC [dbo].[ProjectTableColumnsGetByColumnNameI18] @ColumnNameI18={0}", ColumnNameI18).ToList().AsQueryable();

            this.OnProjectTableColumnsGetByColumnNameI18SInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTableColumnsGetByColumnNameI18SDefaultParams(ref string ColumnNameI18);

        partial void OnProjectTableColumnsGetByColumnNameI18SInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByColumnNameI18> items);
    }
}
