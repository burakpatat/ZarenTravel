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
    public partial class DevicesGetByIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DevicesGetByIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DevicesGetByIdsFunc(Id={Id})")]
        public IActionResult DevicesGetByIdsFunc([FromODataUri] int? Id)
        {
            this.OnDevicesGetByIdsDefaultParams(ref Id);

            var items = this.context.DevicesGetByIds.FromSqlRaw("EXEC [dbo].[DevicesGetByID] @Id={0}", Id).ToList().AsQueryable();

            this.OnDevicesGetByIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnDevicesGetByIdsDefaultParams(ref int? Id);

        partial void OnDevicesGetByIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DevicesGetById> items);
    }
}
