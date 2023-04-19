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
    public partial class ProjectPageComponentElementsGetBySoftwareLanguageIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetBySoftwareLanguageIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetBySoftwareLanguageIdsFunc(SoftwareLanguageId={SoftwareLanguageId})")]
        public IActionResult ProjectPageComponentElementsGetBySoftwareLanguageIdsFunc([FromODataUri] int? SoftwareLanguageId)
        {
            this.OnProjectPageComponentElementsGetBySoftwareLanguageIdsDefaultParams(ref SoftwareLanguageId);

            var items = this.context.ProjectPageComponentElementsGetBySoftwareLanguageIds.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetBySoftwareLanguageId] @SoftwareLanguageId={0}", SoftwareLanguageId).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetBySoftwareLanguageIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetBySoftwareLanguageIdsDefaultParams(ref int? SoftwareLanguageId);

        partial void OnProjectPageComponentElementsGetBySoftwareLanguageIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetBySoftwareLanguageId> items);
    }
}
