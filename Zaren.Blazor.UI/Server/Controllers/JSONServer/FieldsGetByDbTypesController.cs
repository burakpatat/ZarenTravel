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
    public partial class FieldsGetByDbTypesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public FieldsGetByDbTypesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/FieldsGetByDbTypesFunc(DbType={DbType})")]
        public IActionResult FieldsGetByDbTypesFunc([FromODataUri] string DbType)
        {
            this.OnFieldsGetByDbTypesDefaultParams(ref DbType);

            var items = this.context.FieldsGetByDbTypes.FromSqlRaw("EXEC [dbo].[FieldsGetByDbType] @DbType={0}", DbType).ToList().AsQueryable();

            this.OnFieldsGetByDbTypesInvoke(ref items);

            return Ok(items);
        }

        partial void OnFieldsGetByDbTypesDefaultParams(ref string DbType);

        partial void OnFieldsGetByDbTypesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.FieldsGetByDbType> items);
    }
}
