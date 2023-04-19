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
    public partial class ProjectPageComponentsGetModifyDateBetweensController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentsGetModifyDateBetweensController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentsGetModifyDateBetweensFunc(ModifyDateStart={ModifyDateStart},ModifyDateEnd={ModifyDateEnd})")]
        public IActionResult ProjectPageComponentsGetModifyDateBetweensFunc([FromODataUri] string ModifyDateStart, [FromODataUri] string ModifyDateEnd)
        {
            this.OnProjectPageComponentsGetModifyDateBetweensDefaultParams(ref ModifyDateStart, ref ModifyDateEnd);

            var items = this.context.ProjectPageComponentsGetModifyDateBetweens.FromSqlRaw("EXEC [dbo].[ProjectPageComponentsGetModifyDateBetween] @ModifyDateStart={0}, @ModifyDateEnd={1}", ModifyDateStart, ModifyDateEnd).ToList().AsQueryable();

            this.OnProjectPageComponentsGetModifyDateBetweensInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentsGetModifyDateBetweensDefaultParams(ref string ModifyDateStart, ref string ModifyDateEnd);

        partial void OnProjectPageComponentsGetModifyDateBetweensInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetModifyDateBetween> items);
    }
}
