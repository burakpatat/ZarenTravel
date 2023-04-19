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
    public partial class DevicesGetByResulation3xesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DevicesGetByResulation3xesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DevicesGetByResulation3xesFunc(Resulation3x={Resulation3x})")]
        public IActionResult DevicesGetByResulation3xesFunc([FromODataUri] string Resulation3x)
        {
            this.OnDevicesGetByResulation3xesDefaultParams(ref Resulation3x);

            var items = this.context.DevicesGetByResulation3xes.FromSqlRaw("EXEC [dbo].[DevicesGetByResulation3x] @Resulation3x={0}", Resulation3x).ToList().AsQueryable();

            this.OnDevicesGetByResulation3xesInvoke(ref items);

            return Ok(items);
        }

        partial void OnDevicesGetByResulation3xesDefaultParams(ref string Resulation3x);

        partial void OnDevicesGetByResulation3xesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DevicesGetByResulation3x> items);
    }
}
