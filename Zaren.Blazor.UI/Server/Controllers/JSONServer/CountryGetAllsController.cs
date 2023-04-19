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
    public partial class CountryGetAllsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryGetAllsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryGetAllsFunc()")]
        public IActionResult CountryGetAllsFunc()
        {
            this.OnCountryGetAllsDefaultParams();

            var items = this.context.CountryGetAlls.FromSqlRaw("EXEC [dbo].[CountryGetAll] ").ToList().AsQueryable();

            this.OnCountryGetAllsInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryGetAllsDefaultParams();

        partial void OnCountryGetAllsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryGetAll> items);
    }
}
