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
    public partial class CountryGetByCallingCodesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryGetByCallingCodesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryGetByCallingCodesFunc(CallingCode={CallingCode})")]
        public IActionResult CountryGetByCallingCodesFunc([FromODataUri] string CallingCode)
        {
            this.OnCountryGetByCallingCodesDefaultParams(ref CallingCode);

            var items = this.context.CountryGetByCallingCodes.FromSqlRaw("EXEC [dbo].[CountryGetByCallingCode] @CallingCode={0}", CallingCode).ToList().AsQueryable();

            this.OnCountryGetByCallingCodesInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryGetByCallingCodesDefaultParams(ref string CallingCode);

        partial void OnCountryGetByCallingCodesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryGetByCallingCode> items);
    }
}
