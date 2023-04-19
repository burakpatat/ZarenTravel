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
    public partial class CountryGetByBarcodesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryGetByBarcodesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryGetByBarcodesFunc(Barcode={Barcode})")]
        public IActionResult CountryGetByBarcodesFunc([FromODataUri] string Barcode)
        {
            this.OnCountryGetByBarcodesDefaultParams(ref Barcode);

            var items = this.context.CountryGetByBarcodes.FromSqlRaw("EXEC [dbo].[CountryGetByBarcode] @Barcode={0}", Barcode).ToList().AsQueryable();

            this.OnCountryGetByBarcodesInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryGetByBarcodesDefaultParams(ref string Barcode);

        partial void OnCountryGetByBarcodesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryGetByBarcode> items);
    }
}
