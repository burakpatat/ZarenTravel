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
    public partial class DevicesGetByIsLandScapesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DevicesGetByIsLandScapesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DevicesGetByIsLandScapesFunc(IsLandScape={IsLandScape})")]
        public IActionResult DevicesGetByIsLandScapesFunc([FromODataUri] bool? IsLandScape)
        {
            this.OnDevicesGetByIsLandScapesDefaultParams(ref IsLandScape);

            var items = this.context.DevicesGetByIsLandScapes.FromSqlRaw("EXEC [dbo].[DevicesGetByIsLandScape] @IsLandScape={0}", IsLandScape).ToList().AsQueryable();

            this.OnDevicesGetByIsLandScapesInvoke(ref items);

            return Ok(items);
        }

        partial void OnDevicesGetByIsLandScapesDefaultParams(ref bool? IsLandScape);

        partial void OnDevicesGetByIsLandScapesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DevicesGetByIsLandScape> items);
    }
}
