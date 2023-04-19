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
    public partial class CountryLanguagesGetByIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryLanguagesGetByIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryLanguagesGetByIdsFunc(Id={Id})")]
        public IActionResult CountryLanguagesGetByIdsFunc([FromODataUri] int? Id)
        {
            this.OnCountryLanguagesGetByIdsDefaultParams(ref Id);

            var items = this.context.CountryLanguagesGetByIds.FromSqlRaw("EXEC [dbo].[CountryLanguagesGetByID] @Id={0}", Id).ToList().AsQueryable();

            this.OnCountryLanguagesGetByIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryLanguagesGetByIdsDefaultParams(ref int? Id);

        partial void OnCountryLanguagesGetByIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryLanguagesGetById> items);
    }
}
