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
    public partial class ProjectPageComponentElementsGetByResponseHasMultiModelsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByResponseHasMultiModelsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByResponseHasMultiModelsFunc(ResponseHasMultiModel={ResponseHasMultiModel})")]
        public IActionResult ProjectPageComponentElementsGetByResponseHasMultiModelsFunc([FromODataUri] bool? ResponseHasMultiModel)
        {
            this.OnProjectPageComponentElementsGetByResponseHasMultiModelsDefaultParams(ref ResponseHasMultiModel);

            var items = this.context.ProjectPageComponentElementsGetByResponseHasMultiModels.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByResponseHasMultiModel] @ResponseHasMultiModel={0}", ResponseHasMultiModel).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByResponseHasMultiModelsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByResponseHasMultiModelsDefaultParams(ref bool? ResponseHasMultiModel);

        partial void OnProjectPageComponentElementsGetByResponseHasMultiModelsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByResponseHasMultiModel> items);
    }
}
