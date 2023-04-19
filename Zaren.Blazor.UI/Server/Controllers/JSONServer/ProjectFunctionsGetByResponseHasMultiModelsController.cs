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
    public partial class ProjectFunctionsGetByResponseHasMultiModelsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByResponseHasMultiModelsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByResponseHasMultiModelsFunc(ResponseHasMultiModel={ResponseHasMultiModel})")]
        public IActionResult ProjectFunctionsGetByResponseHasMultiModelsFunc([FromODataUri] bool? ResponseHasMultiModel)
        {
            this.OnProjectFunctionsGetByResponseHasMultiModelsDefaultParams(ref ResponseHasMultiModel);

            var items = this.context.ProjectFunctionsGetByResponseHasMultiModels.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByResponseHasMultiModel] @ResponseHasMultiModel={0}", ResponseHasMultiModel).ToList().AsQueryable();

            this.OnProjectFunctionsGetByResponseHasMultiModelsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByResponseHasMultiModelsDefaultParams(ref bool? ResponseHasMultiModel);

        partial void OnProjectFunctionsGetByResponseHasMultiModelsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByResponseHasMultiModel> items);
    }
}
