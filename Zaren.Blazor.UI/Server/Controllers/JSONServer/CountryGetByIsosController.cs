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
    public partial class CountryGetByIsosController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryGetByIsosController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryGetByIsosFunc(Iso={Iso})")]
        public IActionResult CountryGetByIsosFunc([FromODataUri] string Iso)
        {
            this.OnCountryGetByIsosDefaultParams(ref Iso);

            var items = this.context.CountryGetByIsos.FromSqlRaw("EXEC [dbo].[CountryGetByIso] @Iso={0}", Iso).ToList().AsQueryable();

            this.OnCountryGetByIsosInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryGetByIsosDefaultParams(ref string Iso);

        partial void OnCountryGetByIsosInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryGetByIso> items);
    }
}
