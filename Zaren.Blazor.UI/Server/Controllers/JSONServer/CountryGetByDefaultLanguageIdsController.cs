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
    public partial class CountryGetByDefaultLanguageIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryGetByDefaultLanguageIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryGetByDefaultLanguageIdsFunc(DefaultLanguageId={DefaultLanguageId})")]
        public IActionResult CountryGetByDefaultLanguageIdsFunc([FromODataUri] int? DefaultLanguageId)
        {
            this.OnCountryGetByDefaultLanguageIdsDefaultParams(ref DefaultLanguageId);

            var items = this.context.CountryGetByDefaultLanguageIds.FromSqlRaw("EXEC [dbo].[CountryGetByDefaultLanguageId] @DefaultLanguageId={0}", DefaultLanguageId).ToList().AsQueryable();

            this.OnCountryGetByDefaultLanguageIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryGetByDefaultLanguageIdsDefaultParams(ref int? DefaultLanguageId);

        partial void OnCountryGetByDefaultLanguageIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryGetByDefaultLanguageId> items);
    }
}
