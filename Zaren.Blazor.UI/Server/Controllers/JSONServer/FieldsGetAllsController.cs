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
    public partial class FieldsGetAllsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public FieldsGetAllsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/FieldsGetAllsFunc()")]
        public IActionResult FieldsGetAllsFunc()
        {
            this.OnFieldsGetAllsDefaultParams();

            var items = this.context.FieldsGetAlls.FromSqlRaw("EXEC [dbo].[FieldsGetAll] ").ToList().AsQueryable();

            this.OnFieldsGetAllsInvoke(ref items);

            return Ok(items);
        }

        partial void OnFieldsGetAllsDefaultParams();

        partial void OnFieldsGetAllsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.FieldsGetAll> items);
    }
}
