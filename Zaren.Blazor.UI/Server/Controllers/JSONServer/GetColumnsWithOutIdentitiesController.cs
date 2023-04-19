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
    public partial class GetColumnsWithOutIdentitiesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public GetColumnsWithOutIdentitiesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/GetColumnsWithOutIdentitiesFunc(name={name})")]
        public IActionResult GetColumnsWithOutIdentitiesFunc([FromODataUri] string name)
        {
            this.OnGetColumnsWithOutIdentitiesDefaultParams(ref name);

            var items = this.context.GetColumnsWithOutIdentities.FromSqlRaw("EXEC [dbo].[GetColumnsWithOutIdentity] @name={0}", name).ToList().AsQueryable();

            this.OnGetColumnsWithOutIdentitiesInvoke(ref items);

            return Ok(items);
        }

        partial void OnGetColumnsWithOutIdentitiesDefaultParams(ref string name);

        partial void OnGetColumnsWithOutIdentitiesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.GetColumnsWithOutIdentity> items);
    }
}
