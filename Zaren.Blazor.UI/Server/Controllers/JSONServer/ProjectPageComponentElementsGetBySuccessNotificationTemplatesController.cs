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
    public partial class ProjectPageComponentElementsGetBySuccessNotificationTemplatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetBySuccessNotificationTemplatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetBySuccessNotificationTemplatesFunc(SuccessNotificationTemplate={SuccessNotificationTemplate})")]
        public IActionResult ProjectPageComponentElementsGetBySuccessNotificationTemplatesFunc([FromODataUri] string SuccessNotificationTemplate)
        {
            this.OnProjectPageComponentElementsGetBySuccessNotificationTemplatesDefaultParams(ref SuccessNotificationTemplate);

            var items = this.context.ProjectPageComponentElementsGetBySuccessNotificationTemplates.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetBySuccessNotificationTemplate] @SuccessNotificationTemplate={0}", SuccessNotificationTemplate).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetBySuccessNotificationTemplatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetBySuccessNotificationTemplatesDefaultParams(ref string SuccessNotificationTemplate);

        partial void OnProjectPageComponentElementsGetBySuccessNotificationTemplatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetBySuccessNotificationTemplate> items);
    }
}
