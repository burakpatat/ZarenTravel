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
    public partial class CountryGetByCostLinesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryGetByCostLinesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryGetByCostLinesFunc(CostLine={CostLine})")]
        public IActionResult CountryGetByCostLinesFunc([FromODataUri] string CostLine)
        {
            this.OnCountryGetByCostLinesDefaultParams(ref CostLine);

            var items = this.context.CountryGetByCostLines.FromSqlRaw("EXEC [dbo].[CountryGetByCostLine] @CostLine={0}", CostLine).ToList().AsQueryable();

            this.OnCountryGetByCostLinesInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryGetByCostLinesDefaultParams(ref string CostLine);

        partial void OnCountryGetByCostLinesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryGetByCostLine> items);
    }
}
