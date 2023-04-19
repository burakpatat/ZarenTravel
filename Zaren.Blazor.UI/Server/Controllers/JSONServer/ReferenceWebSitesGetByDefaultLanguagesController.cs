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
    public partial class ReferenceWebSitesGetByDefaultLanguagesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ReferenceWebSitesGetByDefaultLanguagesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ReferenceWebSitesGetByDefaultLanguagesFunc(DefaultLanguage={DefaultLanguage})")]
        public IActionResult ReferenceWebSitesGetByDefaultLanguagesFunc([FromODataUri] int? DefaultLanguage)
        {
            this.OnReferenceWebSitesGetByDefaultLanguagesDefaultParams(ref DefaultLanguage);

            var items = this.context.ReferenceWebSitesGetByDefaultLanguages.FromSqlRaw("EXEC [dbo].[ReferenceWebSitesGetByDefaultLanguage] @DefaultLanguage={0}", DefaultLanguage).ToList().AsQueryable();

            this.OnReferenceWebSitesGetByDefaultLanguagesInvoke(ref items);

            return Ok(items);
        }

        partial void OnReferenceWebSitesGetByDefaultLanguagesDefaultParams(ref int? DefaultLanguage);

        partial void OnReferenceWebSitesGetByDefaultLanguagesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByDefaultLanguage> items);
    }
}
