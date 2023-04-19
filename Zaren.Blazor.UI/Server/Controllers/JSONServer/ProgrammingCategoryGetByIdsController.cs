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
    public partial class ProgrammingCategoryGetByIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProgrammingCategoryGetByIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProgrammingCategoryGetByIdsFunc(Id={Id})")]
        public IActionResult ProgrammingCategoryGetByIdsFunc([FromODataUri] int? Id)
        {
            this.OnProgrammingCategoryGetByIdsDefaultParams(ref Id);

            var items = this.context.ProgrammingCategoryGetByIds.FromSqlRaw("EXEC [dbo].[ProgrammingCategoryGetByID] @Id={0}", Id).ToList().AsQueryable();

            this.OnProgrammingCategoryGetByIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProgrammingCategoryGetByIdsDefaultParams(ref int? Id);

        partial void OnProgrammingCategoryGetByIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProgrammingCategoryGetById> items);
    }
}
