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
    public partial class CountryGetByGovernmentsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryGetByGovernmentsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryGetByGovernmentsFunc(Government={Government})")]
        public IActionResult CountryGetByGovernmentsFunc([FromODataUri] string Government)
        {
            this.OnCountryGetByGovernmentsDefaultParams(ref Government);

            var items = this.context.CountryGetByGovernments.FromSqlRaw("EXEC [dbo].[CountryGetByGovernment] @Government={0}", Government).ToList().AsQueryable();

            this.OnCountryGetByGovernmentsInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryGetByGovernmentsDefaultParams(ref string Government);

        partial void OnCountryGetByGovernmentsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryGetByGovernment> items);
    }
}
