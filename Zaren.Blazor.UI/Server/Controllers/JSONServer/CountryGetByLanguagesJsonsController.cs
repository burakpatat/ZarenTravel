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
    public partial class CountryGetByLanguagesJsonsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryGetByLanguagesJsonsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryGetByLanguagesJsonsFunc(LanguagesJSON={LanguagesJSON})")]
        public IActionResult CountryGetByLanguagesJsonsFunc([FromODataUri] string LanguagesJSON)
        {
            this.OnCountryGetByLanguagesJsonsDefaultParams(ref LanguagesJSON);

            var items = this.context.CountryGetByLanguagesJsons.FromSqlRaw("EXEC [dbo].[CountryGetByLanguagesJSON] @LanguagesJSON={0}", LanguagesJSON).ToList().AsQueryable();

            this.OnCountryGetByLanguagesJsonsInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryGetByLanguagesJsonsDefaultParams(ref string LanguagesJSON);

        partial void OnCountryGetByLanguagesJsonsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryGetByLanguagesJson> items);
    }
}
