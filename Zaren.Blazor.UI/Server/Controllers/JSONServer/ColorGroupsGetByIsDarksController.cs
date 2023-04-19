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
    public partial class ColorGroupsGetByIsDarksController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ColorGroupsGetByIsDarksController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ColorGroupsGetByIsDarksFunc(IsDark={IsDark})")]
        public IActionResult ColorGroupsGetByIsDarksFunc([FromODataUri] bool? IsDark)
        {
            this.OnColorGroupsGetByIsDarksDefaultParams(ref IsDark);

            var items = this.context.ColorGroupsGetByIsDarks.FromSqlRaw("EXEC [dbo].[ColorGroupsGetByIsDark] @IsDark={0}", IsDark).ToList().AsQueryable();

            this.OnColorGroupsGetByIsDarksInvoke(ref items);

            return Ok(items);
        }

        partial void OnColorGroupsGetByIsDarksDefaultParams(ref bool? IsDark);

        partial void OnColorGroupsGetByIsDarksInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ColorGroupsGetByIsDark> items);
    }
}
