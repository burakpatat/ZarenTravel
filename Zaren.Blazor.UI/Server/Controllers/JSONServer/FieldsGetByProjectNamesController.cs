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
    public partial class FieldsGetByProjectNamesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public FieldsGetByProjectNamesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/FieldsGetByProjectNamesFunc(ProjectName={ProjectName})")]
        public IActionResult FieldsGetByProjectNamesFunc([FromODataUri] string ProjectName)
        {
            this.OnFieldsGetByProjectNamesDefaultParams(ref ProjectName);

            var items = this.context.FieldsGetByProjectNames.FromSqlRaw("EXEC [dbo].[FieldsGetByProjectName] @ProjectName={0}", ProjectName).ToList().AsQueryable();

            this.OnFieldsGetByProjectNamesInvoke(ref items);

            return Ok(items);
        }

        partial void OnFieldsGetByProjectNamesDefaultParams(ref string ProjectName);

        partial void OnFieldsGetByProjectNamesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.FieldsGetByProjectName> items);
    }
}
