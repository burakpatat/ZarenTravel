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
    public partial class ProgrammingTechnologyGetAllsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProgrammingTechnologyGetAllsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProgrammingTechnologyGetAllsFunc()")]
        public IActionResult ProgrammingTechnologyGetAllsFunc()
        {
            this.OnProgrammingTechnologyGetAllsDefaultParams();

            var items = this.context.ProgrammingTechnologyGetAlls.FromSqlRaw("EXEC [dbo].[ProgrammingTechnologyGetAll] ").ToList().AsQueryable();

            this.OnProgrammingTechnologyGetAllsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProgrammingTechnologyGetAllsDefaultParams();

        partial void OnProgrammingTechnologyGetAllsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProgrammingTechnologyGetAll> items);
    }
}
