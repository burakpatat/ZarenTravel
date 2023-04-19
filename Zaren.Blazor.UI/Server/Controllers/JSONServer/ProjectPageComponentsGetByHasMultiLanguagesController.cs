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
    public partial class ProjectPageComponentsGetByHasMultiLanguagesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentsGetByHasMultiLanguagesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentsGetByHasMultiLanguagesFunc(HasMultiLanguage={HasMultiLanguage})")]
        public IActionResult ProjectPageComponentsGetByHasMultiLanguagesFunc([FromODataUri] string HasMultiLanguage)
        {
            this.OnProjectPageComponentsGetByHasMultiLanguagesDefaultParams(ref HasMultiLanguage);

            var items = this.context.ProjectPageComponentsGetByHasMultiLanguages.FromSqlRaw("EXEC [dbo].[ProjectPageComponentsGetByHasMultiLanguage] @HasMultiLanguage={0}", HasMultiLanguage).ToList().AsQueryable();

            this.OnProjectPageComponentsGetByHasMultiLanguagesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentsGetByHasMultiLanguagesDefaultParams(ref string HasMultiLanguage);

        partial void OnProjectPageComponentsGetByHasMultiLanguagesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByHasMultiLanguage> items);
    }
}
