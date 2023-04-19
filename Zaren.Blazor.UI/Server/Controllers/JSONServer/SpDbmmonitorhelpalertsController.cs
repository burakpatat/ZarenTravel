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
    public partial class SpDbmmonitorhelpalertsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public SpDbmmonitorhelpalertsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/SpDbmmonitorhelpalertsFunc(database_name={database_name},alert_id={alert_id})")]
        public IActionResult SpDbmmonitorhelpalertsFunc([FromODataUri] string database_name, [FromODataUri] int? alert_id)
        {
            this.OnSpDbmmonitorhelpalertsDefaultParams(ref database_name, ref alert_id);

            var items = this.context.SpDbmmonitorhelpalerts.FromSqlRaw("EXEC [dbo].[sp_dbmmonitorhelpalert] @database_name={0}, @alert_id={1}", database_name, alert_id).ToList().AsQueryable();

            this.OnSpDbmmonitorhelpalertsInvoke(ref items);

            return Ok(items);
        }

        partial void OnSpDbmmonitorhelpalertsDefaultParams(ref string database_name, ref int? alert_id);

        partial void OnSpDbmmonitorhelpalertsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.SpDbmmonitorhelpalert> items);
    }
}
