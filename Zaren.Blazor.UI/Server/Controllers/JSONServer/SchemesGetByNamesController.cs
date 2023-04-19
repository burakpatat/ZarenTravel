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
    public partial class SchemesGetByNamesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public SchemesGetByNamesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/SchemesGetByNamesFunc(Name={Name})")]
        public IActionResult SchemesGetByNamesFunc([FromODataUri] string Name)
        {
            this.OnSchemesGetByNamesDefaultParams(ref Name);

            var items = this.context.SchemesGetByNames.FromSqlRaw("EXEC [dbo].[SchemesGetByName] @Name={0}", Name).ToList().AsQueryable();

            this.OnSchemesGetByNamesInvoke(ref items);

            return Ok(items);
        }

        partial void OnSchemesGetByNamesDefaultParams(ref string Name);

        partial void OnSchemesGetByNamesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.SchemesGetByName> items);
    }
}
