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
    public partial class ColorGroupsGetByRgbCodesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ColorGroupsGetByRgbCodesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ColorGroupsGetByRgbCodesFunc(RGBCode={RGBCode})")]
        public IActionResult ColorGroupsGetByRgbCodesFunc([FromODataUri] string RGBCode)
        {
            this.OnColorGroupsGetByRgbCodesDefaultParams(ref RGBCode);

            var items = this.context.ColorGroupsGetByRgbCodes.FromSqlRaw("EXEC [dbo].[ColorGroupsGetByRGBCode] @RGBCode={0}", RGBCode).ToList().AsQueryable();

            this.OnColorGroupsGetByRgbCodesInvoke(ref items);

            return Ok(items);
        }

        partial void OnColorGroupsGetByRgbCodesDefaultParams(ref string RGBCode);

        partial void OnColorGroupsGetByRgbCodesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ColorGroupsGetByRgbCode> items);
    }
}
