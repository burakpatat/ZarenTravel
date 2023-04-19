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
    public partial class ColorGroupsGetByIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ColorGroupsGetByIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ColorGroupsGetByIdsFunc(Id={Id})")]
        public IActionResult ColorGroupsGetByIdsFunc([FromODataUri] int? Id)
        {
            this.OnColorGroupsGetByIdsDefaultParams(ref Id);

            var items = this.context.ColorGroupsGetByIds.FromSqlRaw("EXEC [dbo].[ColorGroupsGetByID] @Id={0}", Id).ToList().AsQueryable();

            this.OnColorGroupsGetByIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnColorGroupsGetByIdsDefaultParams(ref int? Id);

        partial void OnColorGroupsGetByIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ColorGroupsGetById> items);
    }
}
