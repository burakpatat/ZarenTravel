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
    public partial class ColorGroupsGetByHexCodesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ColorGroupsGetByHexCodesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ColorGroupsGetByHexCodesFunc(HexCode={HexCode})")]
        public IActionResult ColorGroupsGetByHexCodesFunc([FromODataUri] string HexCode)
        {
            this.OnColorGroupsGetByHexCodesDefaultParams(ref HexCode);

            var items = this.context.ColorGroupsGetByHexCodes.FromSqlRaw("EXEC [dbo].[ColorGroupsGetByHexCode] @HexCode={0}", HexCode).ToList().AsQueryable();

            this.OnColorGroupsGetByHexCodesInvoke(ref items);

            return Ok(items);
        }

        partial void OnColorGroupsGetByHexCodesDefaultParams(ref string HexCode);

        partial void OnColorGroupsGetByHexCodesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ColorGroupsGetByHexCode> items);
    }
}
