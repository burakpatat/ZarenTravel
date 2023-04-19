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
    public partial class ProjectPagesGetByJsCodesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPagesGetByJsCodesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPagesGetByJsCodesFunc(JsCode={JsCode})")]
        public IActionResult ProjectPagesGetByJsCodesFunc([FromODataUri] string JsCode)
        {
            this.OnProjectPagesGetByJsCodesDefaultParams(ref JsCode);

            var items = this.context.ProjectPagesGetByJsCodes.FromSqlRaw("EXEC [dbo].[ProjectPagesGetByJsCode] @JsCode={0}", JsCode).ToList().AsQueryable();

            this.OnProjectPagesGetByJsCodesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPagesGetByJsCodesDefaultParams(ref string JsCode);

        partial void OnProjectPagesGetByJsCodesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByJsCode> items);
    }
}
