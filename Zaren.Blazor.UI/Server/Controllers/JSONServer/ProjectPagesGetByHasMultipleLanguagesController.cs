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
    public partial class ProjectPagesGetByHasMultipleLanguagesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPagesGetByHasMultipleLanguagesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPagesGetByHasMultipleLanguagesFunc(HasMultipleLanguage={HasMultipleLanguage})")]
        public IActionResult ProjectPagesGetByHasMultipleLanguagesFunc([FromODataUri] bool? HasMultipleLanguage)
        {
            this.OnProjectPagesGetByHasMultipleLanguagesDefaultParams(ref HasMultipleLanguage);

            var items = this.context.ProjectPagesGetByHasMultipleLanguages.FromSqlRaw("EXEC [dbo].[ProjectPagesGetByHasMultipleLanguage] @HasMultipleLanguage={0}", HasMultipleLanguage).ToList().AsQueryable();

            this.OnProjectPagesGetByHasMultipleLanguagesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPagesGetByHasMultipleLanguagesDefaultParams(ref bool? HasMultipleLanguage);

        partial void OnProjectPagesGetByHasMultipleLanguagesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByHasMultipleLanguage> items);
    }
}
