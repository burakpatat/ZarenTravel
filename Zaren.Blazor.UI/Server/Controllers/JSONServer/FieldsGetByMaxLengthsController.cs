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
    public partial class FieldsGetByMaxLengthsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public FieldsGetByMaxLengthsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/FieldsGetByMaxLengthsFunc(MaxLength={MaxLength})")]
        public IActionResult FieldsGetByMaxLengthsFunc([FromODataUri] int? MaxLength)
        {
            this.OnFieldsGetByMaxLengthsDefaultParams(ref MaxLength);

            var items = this.context.FieldsGetByMaxLengths.FromSqlRaw("EXEC [dbo].[FieldsGetByMaxLength] @MaxLength={0}", MaxLength).ToList().AsQueryable();

            this.OnFieldsGetByMaxLengthsInvoke(ref items);

            return Ok(items);
        }

        partial void OnFieldsGetByMaxLengthsDefaultParams(ref int? MaxLength);

        partial void OnFieldsGetByMaxLengthsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.FieldsGetByMaxLength> items);
    }
}
