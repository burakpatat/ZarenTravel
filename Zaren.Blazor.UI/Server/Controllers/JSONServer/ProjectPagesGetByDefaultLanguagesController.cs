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
    public partial class ProjectPagesGetByDefaultLanguagesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPagesGetByDefaultLanguagesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPagesGetByDefaultLanguagesFunc(DefaultLanguage={DefaultLanguage})")]
        public IActionResult ProjectPagesGetByDefaultLanguagesFunc([FromODataUri] int? DefaultLanguage)
        {
            this.OnProjectPagesGetByDefaultLanguagesDefaultParams(ref DefaultLanguage);

            var items = this.context.ProjectPagesGetByDefaultLanguages.FromSqlRaw("EXEC [dbo].[ProjectPagesGetByDefaultLanguage] @DefaultLanguage={0}", DefaultLanguage).ToList().AsQueryable();

            this.OnProjectPagesGetByDefaultLanguagesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPagesGetByDefaultLanguagesDefaultParams(ref int? DefaultLanguage);

        partial void OnProjectPagesGetByDefaultLanguagesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByDefaultLanguage> items);
    }
}
