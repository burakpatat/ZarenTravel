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
    public partial class ColorGroupsInsertsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ColorGroupsInsertsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ColorGroupsInsertsFunc(HexCode={HexCode},RGBCode={RGBCode},GroupList={GroupList},BrightnessValue={BrightnessValue},IsDark={IsDark},PossibleName={PossibleName})")]
        public IActionResult ColorGroupsInsertsFunc([FromODataUri] string HexCode, [FromODataUri] string RGBCode, [FromODataUri] string GroupList, [FromODataUri] double? BrightnessValue, [FromODataUri] bool? IsDark, [FromODataUri] string PossibleName)
        {
            this.OnColorGroupsInsertsDefaultParams(ref HexCode, ref RGBCode, ref GroupList, ref BrightnessValue, ref IsDark, ref PossibleName);

            var items = this.context.ColorGroupsInserts.FromSqlRaw("EXEC [dbo].[ColorGroupsInsert] @HexCode={0}, @RGBCode={1}, @GroupList={2}, @BrightnessValue={3}, @IsDark={4}, @PossibleName={5}", HexCode, RGBCode, GroupList, BrightnessValue, IsDark, PossibleName).ToList().AsQueryable();

            this.OnColorGroupsInsertsInvoke(ref items);

            return Ok(items);
        }

        partial void OnColorGroupsInsertsDefaultParams(ref string HexCode, ref string RGBCode, ref string GroupList, ref double? BrightnessValue, ref bool? IsDark, ref string PossibleName);

        partial void OnColorGroupsInsertsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ColorGroupsInsert> items);
    }
}
