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
    public partial class DevicesGetAllsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DevicesGetAllsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DevicesGetAllsFunc()")]
        public IActionResult DevicesGetAllsFunc()
        {
            this.OnDevicesGetAllsDefaultParams();

            var items = this.context.DevicesGetAlls.FromSqlRaw("EXEC [dbo].[DevicesGetAll] ").ToList().AsQueryable();

            this.OnDevicesGetAllsInvoke(ref items);

            return Ok(items);
        }

        partial void OnDevicesGetAllsDefaultParams();

        partial void OnDevicesGetAllsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DevicesGetAll> items);
    }
}
