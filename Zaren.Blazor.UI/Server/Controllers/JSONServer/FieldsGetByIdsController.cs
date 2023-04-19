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
    public partial class FieldsGetByIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public FieldsGetByIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/FieldsGetByIdsFunc(Id={Id})")]
        public IActionResult FieldsGetByIdsFunc([FromODataUri] long? Id)
        {
            this.OnFieldsGetByIdsDefaultParams(ref Id);

            var items = this.context.FieldsGetByIds.FromSqlRaw("EXEC [dbo].[FieldsGetByID] @Id={0}", Id).ToList().AsQueryable();

            this.OnFieldsGetByIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnFieldsGetByIdsDefaultParams(ref long? Id);

        partial void OnFieldsGetByIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.FieldsGetById> items);
    }
}
