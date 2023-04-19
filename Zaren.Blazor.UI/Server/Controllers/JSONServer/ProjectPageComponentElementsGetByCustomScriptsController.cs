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
    public partial class ProjectPageComponentElementsGetByCustomScriptsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByCustomScriptsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByCustomScriptsFunc(CustomScript={CustomScript})")]
        public IActionResult ProjectPageComponentElementsGetByCustomScriptsFunc([FromODataUri] string CustomScript)
        {
            this.OnProjectPageComponentElementsGetByCustomScriptsDefaultParams(ref CustomScript);

            var items = this.context.ProjectPageComponentElementsGetByCustomScripts.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByCustomScript] @CustomScript={0}", CustomScript).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByCustomScriptsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByCustomScriptsDefaultParams(ref string CustomScript);

        partial void OnProjectPageComponentElementsGetByCustomScriptsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByCustomScript> items);
    }
}
