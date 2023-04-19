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
    public partial class ProjectPagesGetByScannedLanguagesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPagesGetByScannedLanguagesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPagesGetByScannedLanguagesFunc(ScannedLanguage={ScannedLanguage})")]
        public IActionResult ProjectPagesGetByScannedLanguagesFunc([FromODataUri] int? ScannedLanguage)
        {
            this.OnProjectPagesGetByScannedLanguagesDefaultParams(ref ScannedLanguage);

            var items = this.context.ProjectPagesGetByScannedLanguages.FromSqlRaw("EXEC [dbo].[ProjectPagesGetByScannedLanguage] @ScannedLanguage={0}", ScannedLanguage).ToList().AsQueryable();

            this.OnProjectPagesGetByScannedLanguagesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPagesGetByScannedLanguagesDefaultParams(ref int? ScannedLanguage);

        partial void OnProjectPagesGetByScannedLanguagesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByScannedLanguage> items);
    }
}
