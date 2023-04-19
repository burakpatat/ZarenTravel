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
    public partial class CountryLanguagesInsertsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryLanguagesInsertsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryLanguagesInsertsFunc(CountryId={CountryId},CountryName={CountryName},LanguageName={LanguageName})")]
        public IActionResult CountryLanguagesInsertsFunc([FromODataUri] int? CountryId, [FromODataUri] string CountryName, [FromODataUri] string LanguageName)
        {
            this.OnCountryLanguagesInsertsDefaultParams(ref CountryId, ref CountryName, ref LanguageName);

            var items = this.context.CountryLanguagesInserts.FromSqlRaw("EXEC [dbo].[CountryLanguagesInsert] @CountryId={0}, @CountryName={1}, @LanguageName={2}", CountryId, CountryName, LanguageName).ToList().AsQueryable();

            this.OnCountryLanguagesInsertsInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryLanguagesInsertsDefaultParams(ref int? CountryId, ref string CountryName, ref string LanguageName);

        partial void OnCountryLanguagesInsertsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryLanguagesInsert> items);
    }
}
