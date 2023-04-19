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
    public partial class ProjectsGetByRuleGroupsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectsGetByRuleGroupsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectsGetByRuleGroupsFunc(RuleGroups={RuleGroups})")]
        public IActionResult ProjectsGetByRuleGroupsFunc([FromODataUri] string RuleGroups)
        {
            this.OnProjectsGetByRuleGroupsDefaultParams(ref RuleGroups);

            var items = this.context.ProjectsGetByRuleGroups.FromSqlRaw("EXEC [dbo].[ProjectsGetByRuleGroups] @RuleGroups={0}", RuleGroups).ToList().AsQueryable();

            this.OnProjectsGetByRuleGroupsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectsGetByRuleGroupsDefaultParams(ref string RuleGroups);

        partial void OnProjectsGetByRuleGroupsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectsGetByRuleGroup> items);
    }
}
