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
    public partial class ProjectsUpdatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectsUpdatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectsUpdatesFunc(Id={Id},UserId={UserId},Name={Name},Guid={Guid},Tables={Tables},Configuration={Configuration},TableGroups={TableGroups},EnumLists={EnumLists},Endpoints={Endpoints},LanguageDefinations={LanguageDefinations},Lookups={Lookups},ConnectionSettings={ConnectionSettings},DatabaseSchemas={DatabaseSchemas},RuleGroups={RuleGroups})")]
        public IActionResult ProjectsUpdatesFunc([FromODataUri] int? Id, [FromODataUri] int? UserId, [FromODataUri] string Name, [FromODataUri] string Guid, [FromODataUri] string Tables, [FromODataUri] string Configuration, [FromODataUri] object TableGroups, [FromODataUri] object EnumLists, [FromODataUri] object Endpoints, [FromODataUri] object LanguageDefinations, [FromODataUri] object Lookups, [FromODataUri] object ConnectionSettings, [FromODataUri] string DatabaseSchemas, [FromODataUri] string RuleGroups)
        {
            this.OnProjectsUpdatesDefaultParams(ref Id, ref UserId, ref Name, ref Guid, ref Tables, ref Configuration, ref TableGroups, ref EnumLists, ref Endpoints, ref LanguageDefinations, ref Lookups, ref ConnectionSettings, ref DatabaseSchemas, ref RuleGroups);

            var items = this.context.ProjectsUpdates.FromSqlRaw("EXEC [dbo].[ProjectsUpdate] @Id={0}, @UserId={1}, @Name={2}, @Guid={3}, @Tables={4}, @Configuration={5}, @TableGroups={6}, @EnumLists={7}, @Endpoints={8}, @LanguageDefinations={9}, @Lookups={10}, @ConnectionSettings={11}, @DatabaseSchemas={12}, @RuleGroups={13}", Id, UserId, Name, Guid, Tables, Configuration, TableGroups, EnumLists, Endpoints, LanguageDefinations, Lookups, ConnectionSettings, DatabaseSchemas, RuleGroups).ToList().AsQueryable();

            this.OnProjectsUpdatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectsUpdatesDefaultParams(ref int? Id, ref int? UserId, ref string Name, ref string Guid, ref string Tables, ref string Configuration, ref object TableGroups, ref object EnumLists, ref object Endpoints, ref object LanguageDefinations, ref object Lookups, ref object ConnectionSettings, ref string DatabaseSchemas, ref string RuleGroups);

        partial void OnProjectsUpdatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectsUpdate> items);
    }
}
