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
    public partial class DevicesUpdatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DevicesUpdatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DevicesUpdatesFunc(Id={Id},DeviceName={DeviceName},DeviceGroupId={DeviceGroupId},Width={Width},Height={Height},Brand={Brand},Img={Img},IsLandScape={IsLandScape},Resulation1x={Resulation1x},Resulation2x={Resulation2x},Resulation3x={Resulation3x})")]
        public IActionResult DevicesUpdatesFunc([FromODataUri] int? Id, [FromODataUri] string DeviceName, [FromODataUri] int? DeviceGroupId, [FromODataUri] int? Width, [FromODataUri] int? Height, [FromODataUri] string Brand, [FromODataUri] string Img, [FromODataUri] bool? IsLandScape, [FromODataUri] string Resulation1x, [FromODataUri] string Resulation2x, [FromODataUri] string Resulation3x)
        {
            this.OnDevicesUpdatesDefaultParams(ref Id, ref DeviceName, ref DeviceGroupId, ref Width, ref Height, ref Brand, ref Img, ref IsLandScape, ref Resulation1x, ref Resulation2x, ref Resulation3x);

            var items = this.context.DevicesUpdates.FromSqlRaw("EXEC [dbo].[DevicesUpdate] @Id={0}, @DeviceName={1}, @DeviceGroupId={2}, @Width={3}, @Height={4}, @Brand={5}, @Img={6}, @IsLandScape={7}, @Resulation1x={8}, @Resulation2x={9}, @Resulation3x={10}", Id, DeviceName, DeviceGroupId, Width, Height, Brand, Img, IsLandScape, Resulation1x, Resulation2x, Resulation3x).ToList().AsQueryable();

            this.OnDevicesUpdatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnDevicesUpdatesDefaultParams(ref int? Id, ref string DeviceName, ref int? DeviceGroupId, ref int? Width, ref int? Height, ref string Brand, ref string Img, ref bool? IsLandScape, ref string Resulation1x, ref string Resulation2x, ref string Resulation3x);

        partial void OnDevicesUpdatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DevicesUpdate> items);
    }
}
