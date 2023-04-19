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
    public partial class CountryGetByIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryGetByIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryGetByIdsFunc(Id={Id})")]
        public IActionResult CountryGetByIdsFunc([FromODataUri] int? Id)
        {
            this.OnCountryGetByIdsDefaultParams(ref Id);

            var items = this.context.CountryGetByIds.FromSqlRaw("EXEC [dbo].[CountryGetByID] @Id={0}", Id).ToList().AsQueryable();

            this.OnCountryGetByIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryGetByIdsDefaultParams(ref int? Id);

        partial void OnCountryGetByIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryGetById> items);
    }
}
