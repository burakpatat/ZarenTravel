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
    public partial class ReferenceWebSitesGetByIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ReferenceWebSitesGetByIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ReferenceWebSitesGetByIdsFunc(Id={Id})")]
        public IActionResult ReferenceWebSitesGetByIdsFunc([FromODataUri] int? Id)
        {
            this.OnReferenceWebSitesGetByIdsDefaultParams(ref Id);

            var items = this.context.ReferenceWebSitesGetByIds.FromSqlRaw("EXEC [dbo].[ReferenceWebSitesGetByID] @Id={0}", Id).ToList().AsQueryable();

            this.OnReferenceWebSitesGetByIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnReferenceWebSitesGetByIdsDefaultParams(ref int? Id);

        partial void OnReferenceWebSitesGetByIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetById> items);
    }
}
