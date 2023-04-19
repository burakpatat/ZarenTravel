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
    public partial class CountryLanguagesGetByLanguageNamesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryLanguagesGetByLanguageNamesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryLanguagesGetByLanguageNamesFunc(LanguageName={LanguageName})")]
        public IActionResult CountryLanguagesGetByLanguageNamesFunc([FromODataUri] string LanguageName)
        {
            this.OnCountryLanguagesGetByLanguageNamesDefaultParams(ref LanguageName);

            var items = this.context.CountryLanguagesGetByLanguageNames.FromSqlRaw("EXEC [dbo].[CountryLanguagesGetByLanguageName] @LanguageName={0}", LanguageName).ToList().AsQueryable();

            this.OnCountryLanguagesGetByLanguageNamesInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryLanguagesGetByLanguageNamesDefaultParams(ref string LanguageName);

        partial void OnCountryLanguagesGetByLanguageNamesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryLanguagesGetByLanguageName> items);
    }
}
