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
    public partial class FieldsGetByCommentsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public FieldsGetByCommentsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/FieldsGetByCommentsFunc(Comment={Comment})")]
        public IActionResult FieldsGetByCommentsFunc([FromODataUri] string Comment)
        {
            this.OnFieldsGetByCommentsDefaultParams(ref Comment);

            var items = this.context.FieldsGetByComments.FromSqlRaw("EXEC [dbo].[FieldsGetByComment] @Comment={0}", Comment).ToList().AsQueryable();

            this.OnFieldsGetByCommentsInvoke(ref items);

            return Ok(items);
        }

        partial void OnFieldsGetByCommentsDefaultParams(ref string Comment);

        partial void OnFieldsGetByCommentsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.FieldsGetByComment> items);
    }
}
