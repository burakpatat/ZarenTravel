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
    public partial class ColorGroupsUpdatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ColorGroupsUpdatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ColorGroupsUpdatesFunc(Id={Id},HexCode={HexCode},RGBCode={RGBCode},GroupList={GroupList},BrightnessValue={BrightnessValue},IsDark={IsDark},PossibleName={PossibleName})")]
        public IActionResult ColorGroupsUpdatesFunc([FromODataUri] int? Id, [FromODataUri] string HexCode, [FromODataUri] string RGBCode, [FromODataUri] string GroupList, [FromODataUri] double? BrightnessValue, [FromODataUri] bool? IsDark, [FromODataUri] string PossibleName)
        {
            this.OnColorGroupsUpdatesDefaultParams(ref Id, ref HexCode, ref RGBCode, ref GroupList, ref BrightnessValue, ref IsDark, ref PossibleName);

            var items = this.context.ColorGroupsUpdates.FromSqlRaw("EXEC [dbo].[ColorGroupsUpdate] @Id={0}, @HexCode={1}, @RGBCode={2}, @GroupList={3}, @BrightnessValue={4}, @IsDark={5}, @PossibleName={6}", Id, HexCode, RGBCode, GroupList, BrightnessValue, IsDark, PossibleName).ToList().AsQueryable();

            this.OnColorGroupsUpdatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnColorGroupsUpdatesDefaultParams(ref int? Id, ref string HexCode, ref string RGBCode, ref string GroupList, ref double? BrightnessValue, ref bool? IsDark, ref string PossibleName);

        partial void OnColorGroupsUpdatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ColorGroupsUpdate> items);
    }
}
