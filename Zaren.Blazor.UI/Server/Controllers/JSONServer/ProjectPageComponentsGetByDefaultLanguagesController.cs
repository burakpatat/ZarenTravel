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
    public partial class ProjectPageComponentsGetByDefaultLanguagesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentsGetByDefaultLanguagesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentsGetByDefaultLanguagesFunc(DefaultLanguage={DefaultLanguage})")]
        public IActionResult ProjectPageComponentsGetByDefaultLanguagesFunc([FromODataUri] int? DefaultLanguage)
        {
            this.OnProjectPageComponentsGetByDefaultLanguagesDefaultParams(ref DefaultLanguage);

            var items = this.context.ProjectPageComponentsGetByDefaultLanguages.FromSqlRaw("EXEC [dbo].[ProjectPageComponentsGetByDefaultLanguage] @DefaultLanguage={0}", DefaultLanguage).ToList().AsQueryable();

            this.OnProjectPageComponentsGetByDefaultLanguagesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentsGetByDefaultLanguagesDefaultParams(ref int? DefaultLanguage);

        partial void OnProjectPageComponentsGetByDefaultLanguagesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByDefaultLanguage> items);
    }
}
