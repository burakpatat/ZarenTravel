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
    public partial class ReferenceWebSitesGetCreatedDateBetweensController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ReferenceWebSitesGetCreatedDateBetweensController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ReferenceWebSitesGetCreatedDateBetweensFunc(CreatedDateStart={CreatedDateStart},CreatedDateEnd={CreatedDateEnd})")]
        public IActionResult ReferenceWebSitesGetCreatedDateBetweensFunc([FromODataUri] string CreatedDateStart, [FromODataUri] string CreatedDateEnd)
        {
            this.OnReferenceWebSitesGetCreatedDateBetweensDefaultParams(ref CreatedDateStart, ref CreatedDateEnd);

            var items = this.context.ReferenceWebSitesGetCreatedDateBetweens.FromSqlRaw("EXEC [dbo].[ReferenceWebSitesGetCreatedDateBetween] @CreatedDateStart={0}, @CreatedDateEnd={1}", CreatedDateStart, CreatedDateEnd).ToList().AsQueryable();

            this.OnReferenceWebSitesGetCreatedDateBetweensInvoke(ref items);

            return Ok(items);
        }

        partial void OnReferenceWebSitesGetCreatedDateBetweensDefaultParams(ref string CreatedDateStart, ref string CreatedDateEnd);

        partial void OnReferenceWebSitesGetCreatedDateBetweensInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetCreatedDateBetween> items);
    }
}
