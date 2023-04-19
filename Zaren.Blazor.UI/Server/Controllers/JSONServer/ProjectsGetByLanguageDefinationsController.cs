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
    public partial class ProjectsGetByLanguageDefinationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectsGetByLanguageDefinationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectsGetByLanguageDefinationsFunc(LanguageDefinations={LanguageDefinations})")]
        public IActionResult ProjectsGetByLanguageDefinationsFunc([FromODataUri] object LanguageDefinations)
        {
            this.OnProjectsGetByLanguageDefinationsDefaultParams(ref LanguageDefinations);

            var items = this.context.ProjectsGetByLanguageDefinations.FromSqlRaw("EXEC [dbo].[ProjectsGetByLanguageDefinations] @LanguageDefinations={0}", LanguageDefinations).ToList().AsQueryable();

            this.OnProjectsGetByLanguageDefinationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectsGetByLanguageDefinationsDefaultParams(ref object LanguageDefinations);

        partial void OnProjectsGetByLanguageDefinationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectsGetByLanguageDefination> items);
    }
}
