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
    public partial class ProjectTableColumnsGetByCmsCreatePageConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTableColumnsGetByCmsCreatePageConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTableColumnsGetByCmsCreatePageConfigurationsFunc(CMSCreatePageConfiguration={CMSCreatePageConfiguration})")]
        public IActionResult ProjectTableColumnsGetByCmsCreatePageConfigurationsFunc([FromODataUri] string CMSCreatePageConfiguration)
        {
            this.OnProjectTableColumnsGetByCmsCreatePageConfigurationsDefaultParams(ref CMSCreatePageConfiguration);

            var items = this.context.ProjectTableColumnsGetByCmsCreatePageConfigurations.FromSqlRaw("EXEC [dbo].[ProjectTableColumnsGetByCMSCreatePageConfiguration] @CMSCreatePageConfiguration={0}", CMSCreatePageConfiguration).ToList().AsQueryable();

            this.OnProjectTableColumnsGetByCmsCreatePageConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTableColumnsGetByCmsCreatePageConfigurationsDefaultParams(ref string CMSCreatePageConfiguration);

        partial void OnProjectTableColumnsGetByCmsCreatePageConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByCmsCreatePageConfiguration> items);
    }
}
