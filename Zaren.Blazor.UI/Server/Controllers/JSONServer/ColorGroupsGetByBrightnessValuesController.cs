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
    public partial class ColorGroupsGetByBrightnessValuesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ColorGroupsGetByBrightnessValuesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ColorGroupsGetByBrightnessValuesFunc(BrightnessValue={BrightnessValue})")]
        public IActionResult ColorGroupsGetByBrightnessValuesFunc([FromODataUri] double? BrightnessValue)
        {
            this.OnColorGroupsGetByBrightnessValuesDefaultParams(ref BrightnessValue);

            var items = this.context.ColorGroupsGetByBrightnessValues.FromSqlRaw("EXEC [dbo].[ColorGroupsGetByBrightnessValue] @BrightnessValue={0}", BrightnessValue).ToList().AsQueryable();

            this.OnColorGroupsGetByBrightnessValuesInvoke(ref items);

            return Ok(items);
        }

        partial void OnColorGroupsGetByBrightnessValuesDefaultParams(ref double? BrightnessValue);

        partial void OnColorGroupsGetByBrightnessValuesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ColorGroupsGetByBrightnessValue> items);
    }
}
