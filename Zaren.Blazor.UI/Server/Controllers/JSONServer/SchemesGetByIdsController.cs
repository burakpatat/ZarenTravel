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
    public partial class SchemesGetByIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public SchemesGetByIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/SchemesGetByIdsFunc(Id={Id})")]
        public IActionResult SchemesGetByIdsFunc([FromODataUri] long? Id)
        {
            this.OnSchemesGetByIdsDefaultParams(ref Id);

            var items = this.context.SchemesGetByIds.FromSqlRaw("EXEC [dbo].[SchemesGetByID] @Id={0}", Id).ToList().AsQueryable();

            this.OnSchemesGetByIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnSchemesGetByIdsDefaultParams(ref long? Id);

        partial void OnSchemesGetByIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.SchemesGetById> items);
    }
}
