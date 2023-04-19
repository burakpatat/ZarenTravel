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
    public partial class CountryLanguagesGetByCountryIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryLanguagesGetByCountryIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryLanguagesGetByCountryIdsFunc(CountryId={CountryId})")]
        public IActionResult CountryLanguagesGetByCountryIdsFunc([FromODataUri] int? CountryId)
        {
            this.OnCountryLanguagesGetByCountryIdsDefaultParams(ref CountryId);

            var items = this.context.CountryLanguagesGetByCountryIds.FromSqlRaw("EXEC [dbo].[CountryLanguagesGetByCountryId] @CountryId={0}", CountryId).ToList().AsQueryable();

            this.OnCountryLanguagesGetByCountryIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryLanguagesGetByCountryIdsDefaultParams(ref int? CountryId);

        partial void OnCountryLanguagesGetByCountryIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryLanguagesGetByCountryId> items);
    }
}
