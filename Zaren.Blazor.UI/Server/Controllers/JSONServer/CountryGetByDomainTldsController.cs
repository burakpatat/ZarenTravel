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
    public partial class CountryGetByDomainTldsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryGetByDomainTldsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryGetByDomainTldsFunc(DomainTld={DomainTld})")]
        public IActionResult CountryGetByDomainTldsFunc([FromODataUri] string DomainTld)
        {
            this.OnCountryGetByDomainTldsDefaultParams(ref DomainTld);

            var items = this.context.CountryGetByDomainTlds.FromSqlRaw("EXEC [dbo].[CountryGetByDomainTld] @DomainTld={0}", DomainTld).ToList().AsQueryable();

            this.OnCountryGetByDomainTldsInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryGetByDomainTldsDefaultParams(ref string DomainTld);

        partial void OnCountryGetByDomainTldsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryGetByDomainTld> items);
    }
}
