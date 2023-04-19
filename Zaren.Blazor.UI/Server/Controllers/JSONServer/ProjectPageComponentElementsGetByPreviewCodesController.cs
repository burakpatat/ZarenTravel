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
    public partial class ProjectPageComponentElementsGetByPreviewCodesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByPreviewCodesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByPreviewCodesFunc(PreviewCode={PreviewCode})")]
        public IActionResult ProjectPageComponentElementsGetByPreviewCodesFunc([FromODataUri] string PreviewCode)
        {
            this.OnProjectPageComponentElementsGetByPreviewCodesDefaultParams(ref PreviewCode);

            var items = this.context.ProjectPageComponentElementsGetByPreviewCodes.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByPreviewCode] @PreviewCode={0}", PreviewCode).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByPreviewCodesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByPreviewCodesDefaultParams(ref string PreviewCode);

        partial void OnProjectPageComponentElementsGetByPreviewCodesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByPreviewCode> items);
    }
}
