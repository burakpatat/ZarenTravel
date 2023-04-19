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
    public partial class ProjectTableColumnsGetByFkDetailsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTableColumnsGetByFkDetailsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTableColumnsGetByFkDetailsFunc(FKDetails={FKDetails})")]
        public IActionResult ProjectTableColumnsGetByFkDetailsFunc([FromODataUri] string FKDetails)
        {
            this.OnProjectTableColumnsGetByFkDetailsDefaultParams(ref FKDetails);

            var items = this.context.ProjectTableColumnsGetByFkDetails.FromSqlRaw("EXEC [dbo].[ProjectTableColumnsGetByFKDetails] @FKDetails={0}", FKDetails).ToList().AsQueryable();

            this.OnProjectTableColumnsGetByFkDetailsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTableColumnsGetByFkDetailsDefaultParams(ref string FKDetails);

        partial void OnProjectTableColumnsGetByFkDetailsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByFkDetail> items);
    }
}
