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
    public partial class ReferenceWebSitesGetValidDateBetweensController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ReferenceWebSitesGetValidDateBetweensController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ReferenceWebSitesGetValidDateBetweensFunc(ValidDateStart={ValidDateStart},ValidDateEnd={ValidDateEnd})")]
        public IActionResult ReferenceWebSitesGetValidDateBetweensFunc([FromODataUri] string ValidDateStart, [FromODataUri] string ValidDateEnd)
        {
            this.OnReferenceWebSitesGetValidDateBetweensDefaultParams(ref ValidDateStart, ref ValidDateEnd);

            var items = this.context.ReferenceWebSitesGetValidDateBetweens.FromSqlRaw("EXEC [dbo].[ReferenceWebSitesGetValidDateBetween] @ValidDateStart={0}, @ValidDateEnd={1}", ValidDateStart, ValidDateEnd).ToList().AsQueryable();

            this.OnReferenceWebSitesGetValidDateBetweensInvoke(ref items);

            return Ok(items);
        }

        partial void OnReferenceWebSitesGetValidDateBetweensDefaultParams(ref string ValidDateStart, ref string ValidDateEnd);

        partial void OnReferenceWebSitesGetValidDateBetweensInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetValidDateBetween> items);
    }
}
