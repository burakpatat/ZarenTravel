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
    public partial class ProjectPageComponentsGetByScannedLanguagesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentsGetByScannedLanguagesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentsGetByScannedLanguagesFunc(ScannedLanguage={ScannedLanguage})")]
        public IActionResult ProjectPageComponentsGetByScannedLanguagesFunc([FromODataUri] int? ScannedLanguage)
        {
            this.OnProjectPageComponentsGetByScannedLanguagesDefaultParams(ref ScannedLanguage);

            var items = this.context.ProjectPageComponentsGetByScannedLanguages.FromSqlRaw("EXEC [dbo].[ProjectPageComponentsGetByScannedLanguage] @ScannedLanguage={0}", ScannedLanguage).ToList().AsQueryable();

            this.OnProjectPageComponentsGetByScannedLanguagesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentsGetByScannedLanguagesDefaultParams(ref int? ScannedLanguage);

        partial void OnProjectPageComponentsGetByScannedLanguagesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByScannedLanguage> items);
    }
}
