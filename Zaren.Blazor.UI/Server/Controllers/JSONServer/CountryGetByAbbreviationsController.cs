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
    public partial class CountryGetByAbbreviationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryGetByAbbreviationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryGetByAbbreviationsFunc(Abbreviation={Abbreviation})")]
        public IActionResult CountryGetByAbbreviationsFunc([FromODataUri] string Abbreviation)
        {
            this.OnCountryGetByAbbreviationsDefaultParams(ref Abbreviation);

            var items = this.context.CountryGetByAbbreviations.FromSqlRaw("EXEC [dbo].[CountryGetByAbbreviation] @Abbreviation={0}", Abbreviation).ToList().AsQueryable();

            this.OnCountryGetByAbbreviationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryGetByAbbreviationsDefaultParams(ref string Abbreviation);

        partial void OnCountryGetByAbbreviationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryGetByAbbreviation> items);
    }
}
