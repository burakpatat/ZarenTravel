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
    public partial class DevicesGetByBrandsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DevicesGetByBrandsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DevicesGetByBrandsFunc(Brand={Brand})")]
        public IActionResult DevicesGetByBrandsFunc([FromODataUri] string Brand)
        {
            this.OnDevicesGetByBrandsDefaultParams(ref Brand);

            var items = this.context.DevicesGetByBrands.FromSqlRaw("EXEC [dbo].[DevicesGetByBrand] @Brand={0}", Brand).ToList().AsQueryable();

            this.OnDevicesGetByBrandsInvoke(ref items);

            return Ok(items);
        }

        partial void OnDevicesGetByBrandsDefaultParams(ref string Brand);

        partial void OnDevicesGetByBrandsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DevicesGetByBrand> items);
    }
}
