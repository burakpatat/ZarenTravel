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
    public partial class ReferenceWebSitesGetByLogosController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ReferenceWebSitesGetByLogosController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ReferenceWebSitesGetByLogosFunc(Logo={Logo})")]
        public IActionResult ReferenceWebSitesGetByLogosFunc([FromODataUri] string Logo)
        {
            this.OnReferenceWebSitesGetByLogosDefaultParams(ref Logo);

            var items = this.context.ReferenceWebSitesGetByLogos.FromSqlRaw("EXEC [dbo].[ReferenceWebSitesGetByLogo] @Logo={0}", Logo).ToList().AsQueryable();

            this.OnReferenceWebSitesGetByLogosInvoke(ref items);

            return Ok(items);
        }

        partial void OnReferenceWebSitesGetByLogosDefaultParams(ref string Logo);

        partial void OnReferenceWebSitesGetByLogosInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByLogo> items);
    }
}
