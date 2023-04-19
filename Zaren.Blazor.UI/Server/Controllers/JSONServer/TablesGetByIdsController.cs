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
    public partial class TablesGetByIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public TablesGetByIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/TablesGetByIdsFunc(Id={Id})")]
        public IActionResult TablesGetByIdsFunc([FromODataUri] long? Id)
        {
            this.OnTablesGetByIdsDefaultParams(ref Id);

            var items = this.context.TablesGetByIds.FromSqlRaw("EXEC [dbo].[TablesGetByID] @Id={0}", Id).ToList().AsQueryable();

            this.OnTablesGetByIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnTablesGetByIdsDefaultParams(ref long? Id);

        partial void OnTablesGetByIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.TablesGetById> items);
    }
}
