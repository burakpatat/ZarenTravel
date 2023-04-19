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
    public partial class ProjectFunctionsGetBySuccessNotificationTemplatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetBySuccessNotificationTemplatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetBySuccessNotificationTemplatesFunc(SuccessNotificationTemplate={SuccessNotificationTemplate})")]
        public IActionResult ProjectFunctionsGetBySuccessNotificationTemplatesFunc([FromODataUri] string SuccessNotificationTemplate)
        {
            this.OnProjectFunctionsGetBySuccessNotificationTemplatesDefaultParams(ref SuccessNotificationTemplate);

            var items = this.context.ProjectFunctionsGetBySuccessNotificationTemplates.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetBySuccessNotificationTemplate] @SuccessNotificationTemplate={0}", SuccessNotificationTemplate).ToList().AsQueryable();

            this.OnProjectFunctionsGetBySuccessNotificationTemplatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetBySuccessNotificationTemplatesDefaultParams(ref string SuccessNotificationTemplate);

        partial void OnProjectFunctionsGetBySuccessNotificationTemplatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetBySuccessNotificationTemplate> items);
    }
}
