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
    public partial class ProjectTableColumnsGetByCmsEditPageConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTableColumnsGetByCmsEditPageConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTableColumnsGetByCmsEditPageConfigurationsFunc(CMSEditPageConfiguration={CMSEditPageConfiguration})")]
        public IActionResult ProjectTableColumnsGetByCmsEditPageConfigurationsFunc([FromODataUri] string CMSEditPageConfiguration)
        {
            this.OnProjectTableColumnsGetByCmsEditPageConfigurationsDefaultParams(ref CMSEditPageConfiguration);

            var items = this.context.ProjectTableColumnsGetByCmsEditPageConfigurations.FromSqlRaw("EXEC [dbo].[ProjectTableColumnsGetByCMSEditPageConfiguration] @CMSEditPageConfiguration={0}", CMSEditPageConfiguration).ToList().AsQueryable();

            this.OnProjectTableColumnsGetByCmsEditPageConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTableColumnsGetByCmsEditPageConfigurationsDefaultParams(ref string CMSEditPageConfiguration);

        partial void OnProjectTableColumnsGetByCmsEditPageConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByCmsEditPageConfiguration> items);
    }
}
