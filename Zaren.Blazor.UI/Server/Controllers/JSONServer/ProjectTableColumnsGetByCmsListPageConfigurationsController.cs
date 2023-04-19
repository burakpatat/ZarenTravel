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
    public partial class ProjectTableColumnsGetByCmsListPageConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTableColumnsGetByCmsListPageConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTableColumnsGetByCmsListPageConfigurationsFunc(CMSListPageConfiguration={CMSListPageConfiguration})")]
        public IActionResult ProjectTableColumnsGetByCmsListPageConfigurationsFunc([FromODataUri] string CMSListPageConfiguration)
        {
            this.OnProjectTableColumnsGetByCmsListPageConfigurationsDefaultParams(ref CMSListPageConfiguration);

            var items = this.context.ProjectTableColumnsGetByCmsListPageConfigurations.FromSqlRaw("EXEC [dbo].[ProjectTableColumnsGetByCMSListPageConfiguration] @CMSListPageConfiguration={0}", CMSListPageConfiguration).ToList().AsQueryable();

            this.OnProjectTableColumnsGetByCmsListPageConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTableColumnsGetByCmsListPageConfigurationsDefaultParams(ref string CMSListPageConfiguration);

        partial void OnProjectTableColumnsGetByCmsListPageConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByCmsListPageConfiguration> items);
    }
}
