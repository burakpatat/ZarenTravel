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
    public partial class CountryGetByLandlockedsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryGetByLandlockedsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryGetByLandlockedsFunc(Landlocked={Landlocked})")]
        public IActionResult CountryGetByLandlockedsFunc([FromODataUri] string Landlocked)
        {
            this.OnCountryGetByLandlockedsDefaultParams(ref Landlocked);

            var items = this.context.CountryGetByLandlockeds.FromSqlRaw("EXEC [dbo].[CountryGetByLandlocked] @Landlocked={0}", Landlocked).ToList().AsQueryable();

            this.OnCountryGetByLandlockedsInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryGetByLandlockedsDefaultParams(ref string Landlocked);

        partial void OnCountryGetByLandlockedsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryGetByLandlocked> items);
    }
}
