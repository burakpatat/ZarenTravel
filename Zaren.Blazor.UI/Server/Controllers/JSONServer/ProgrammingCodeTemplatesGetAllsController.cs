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
    public partial class ProgrammingCodeTemplatesGetAllsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProgrammingCodeTemplatesGetAllsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProgrammingCodeTemplatesGetAllsFunc()")]
        public IActionResult ProgrammingCodeTemplatesGetAllsFunc()
        {
            this.OnProgrammingCodeTemplatesGetAllsDefaultParams();

            var items = this.context.ProgrammingCodeTemplatesGetAlls.FromSqlRaw("EXEC [dbo].[ProgrammingCodeTemplatesGetAll] ").ToList().AsQueryable();

            this.OnProgrammingCodeTemplatesGetAllsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProgrammingCodeTemplatesGetAllsDefaultParams();

        partial void OnProgrammingCodeTemplatesGetAllsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProgrammingCodeTemplatesGetAll> items);
    }
}
