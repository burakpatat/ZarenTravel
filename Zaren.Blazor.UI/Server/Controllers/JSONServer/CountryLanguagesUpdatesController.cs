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
    public partial class CountryLanguagesUpdatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryLanguagesUpdatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryLanguagesUpdatesFunc(Id={Id},CountryId={CountryId},CountryName={CountryName},LanguageName={LanguageName})")]
        public IActionResult CountryLanguagesUpdatesFunc([FromODataUri] int? Id, [FromODataUri] int? CountryId, [FromODataUri] string CountryName, [FromODataUri] string LanguageName)
        {
            this.OnCountryLanguagesUpdatesDefaultParams(ref Id, ref CountryId, ref CountryName, ref LanguageName);

            var items = this.context.CountryLanguagesUpdates.FromSqlRaw("EXEC [dbo].[CountryLanguagesUpdate] @Id={0}, @CountryId={1}, @CountryName={2}, @LanguageName={3}", Id, CountryId, CountryName, LanguageName).ToList().AsQueryable();

            this.OnCountryLanguagesUpdatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryLanguagesUpdatesDefaultParams(ref int? Id, ref int? CountryId, ref string CountryName, ref string LanguageName);

        partial void OnCountryLanguagesUpdatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryLanguagesUpdate> items);
    }
}
