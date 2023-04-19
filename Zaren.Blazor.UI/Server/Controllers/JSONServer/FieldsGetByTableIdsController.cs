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
    public partial class FieldsGetByTableIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public FieldsGetByTableIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/FieldsGetByTableIdsFunc(TableId={TableId})")]
        public IActionResult FieldsGetByTableIdsFunc([FromODataUri] long? TableId)
        {
            this.OnFieldsGetByTableIdsDefaultParams(ref TableId);

            var items = this.context.FieldsGetByTableIds.FromSqlRaw("EXEC [dbo].[FieldsGetByTableId] @TableId={0}", TableId).ToList().AsQueryable();

            this.OnFieldsGetByTableIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnFieldsGetByTableIdsDefaultParams(ref long? TableId);

        partial void OnFieldsGetByTableIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.FieldsGetByTableId> items);
    }
}
