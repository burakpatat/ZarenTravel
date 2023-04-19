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
    public partial class DevicesGetByResulation2xesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DevicesGetByResulation2xesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DevicesGetByResulation2xesFunc(Resulation2x={Resulation2x})")]
        public IActionResult DevicesGetByResulation2xesFunc([FromODataUri] string Resulation2x)
        {
            this.OnDevicesGetByResulation2xesDefaultParams(ref Resulation2x);

            var items = this.context.DevicesGetByResulation2xes.FromSqlRaw("EXEC [dbo].[DevicesGetByResulation2x] @Resulation2x={0}", Resulation2x).ToList().AsQueryable();

            this.OnDevicesGetByResulation2xesInvoke(ref items);

            return Ok(items);
        }

        partial void OnDevicesGetByResulation2xesDefaultParams(ref string Resulation2x);

        partial void OnDevicesGetByResulation2xesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DevicesGetByResulation2x> items);
    }
}
