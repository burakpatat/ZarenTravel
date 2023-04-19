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
    public partial class ProgrammingCodesGetAllsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProgrammingCodesGetAllsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProgrammingCodesGetAllsFunc()")]
        public IActionResult ProgrammingCodesGetAllsFunc()
        {
            this.OnProgrammingCodesGetAllsDefaultParams();

            var items = this.context.ProgrammingCodesGetAlls.FromSqlRaw("EXEC [dbo].[ProgrammingCodesGetAll] ").ToList().AsQueryable();

            this.OnProgrammingCodesGetAllsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProgrammingCodesGetAllsDefaultParams();

        partial void OnProgrammingCodesGetAllsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProgrammingCodesGetAll> items);
    }
}
