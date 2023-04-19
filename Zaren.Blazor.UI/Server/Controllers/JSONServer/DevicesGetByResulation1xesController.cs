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
    public partial class DevicesGetByResulation1xesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DevicesGetByResulation1xesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DevicesGetByResulation1xesFunc(Resulation1x={Resulation1x})")]
        public IActionResult DevicesGetByResulation1xesFunc([FromODataUri] string Resulation1x)
        {
            this.OnDevicesGetByResulation1xesDefaultParams(ref Resulation1x);

            var items = this.context.DevicesGetByResulation1xes.FromSqlRaw("EXEC [dbo].[DevicesGetByResulation1x] @Resulation1x={0}", Resulation1x).ToList().AsQueryable();

            this.OnDevicesGetByResulation1xesInvoke(ref items);

            return Ok(items);
        }

        partial void OnDevicesGetByResulation1xesDefaultParams(ref string Resulation1x);

        partial void OnDevicesGetByResulation1xesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DevicesGetByResulation1x> items);
    }
}
