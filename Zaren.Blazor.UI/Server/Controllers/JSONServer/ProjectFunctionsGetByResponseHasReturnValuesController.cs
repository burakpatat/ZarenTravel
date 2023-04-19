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
    public partial class ProjectFunctionsGetByResponseHasReturnValuesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByResponseHasReturnValuesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByResponseHasReturnValuesFunc(ResponseHasReturnValue={ResponseHasReturnValue})")]
        public IActionResult ProjectFunctionsGetByResponseHasReturnValuesFunc([FromODataUri] bool? ResponseHasReturnValue)
        {
            this.OnProjectFunctionsGetByResponseHasReturnValuesDefaultParams(ref ResponseHasReturnValue);

            var items = this.context.ProjectFunctionsGetByResponseHasReturnValues.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByResponseHasReturnValue] @ResponseHasReturnValue={0}", ResponseHasReturnValue).ToList().AsQueryable();

            this.OnProjectFunctionsGetByResponseHasReturnValuesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByResponseHasReturnValuesDefaultParams(ref bool? ResponseHasReturnValue);

        partial void OnProjectFunctionsGetByResponseHasReturnValuesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByResponseHasReturnValue> items);
    }
}
