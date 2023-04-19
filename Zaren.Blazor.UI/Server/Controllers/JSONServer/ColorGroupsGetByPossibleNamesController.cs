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
    public partial class ColorGroupsGetByPossibleNamesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ColorGroupsGetByPossibleNamesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ColorGroupsGetByPossibleNamesFunc(PossibleName={PossibleName})")]
        public IActionResult ColorGroupsGetByPossibleNamesFunc([FromODataUri] string PossibleName)
        {
            this.OnColorGroupsGetByPossibleNamesDefaultParams(ref PossibleName);

            var items = this.context.ColorGroupsGetByPossibleNames.FromSqlRaw("EXEC [dbo].[ColorGroupsGetByPossibleName] @PossibleName={0}", PossibleName).ToList().AsQueryable();

            this.OnColorGroupsGetByPossibleNamesInvoke(ref items);

            return Ok(items);
        }

        partial void OnColorGroupsGetByPossibleNamesDefaultParams(ref string PossibleName);

        partial void OnColorGroupsGetByPossibleNamesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ColorGroupsGetByPossibleName> items);
    }
}
