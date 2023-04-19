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
    public partial class FieldsGetByIsPrimariesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public FieldsGetByIsPrimariesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/FieldsGetByIsPrimariesFunc(IsPrimary={IsPrimary})")]
        public IActionResult FieldsGetByIsPrimariesFunc([FromODataUri] bool? IsPrimary)
        {
            this.OnFieldsGetByIsPrimariesDefaultParams(ref IsPrimary);

            var items = this.context.FieldsGetByIsPrimaries.FromSqlRaw("EXEC [dbo].[FieldsGetByIsPrimary] @IsPrimary={0}", IsPrimary).ToList().AsQueryable();

            this.OnFieldsGetByIsPrimariesInvoke(ref items);

            return Ok(items);
        }

        partial void OnFieldsGetByIsPrimariesDefaultParams(ref bool? IsPrimary);

        partial void OnFieldsGetByIsPrimariesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.FieldsGetByIsPrimary> items);
    }
}
