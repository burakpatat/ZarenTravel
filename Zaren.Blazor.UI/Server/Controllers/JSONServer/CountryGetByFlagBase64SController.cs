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
    public partial class CountryGetByFlagBase64SController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryGetByFlagBase64SController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryGetByFlagBase64SFunc(FlagBase64={FlagBase64})")]
        public IActionResult CountryGetByFlagBase64SFunc([FromODataUri] string FlagBase64)
        {
            this.OnCountryGetByFlagBase64SDefaultParams(ref FlagBase64);

            var items = this.context.CountryGetByFlagBase64S.FromSqlRaw("EXEC [dbo].[CountryGetByFlagBase64] @FlagBase64={0}", FlagBase64).ToList().AsQueryable();

            this.OnCountryGetByFlagBase64SInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryGetByFlagBase64SDefaultParams(ref string FlagBase64);

        partial void OnCountryGetByFlagBase64SInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryGetByFlagBase64> items);
    }
}
