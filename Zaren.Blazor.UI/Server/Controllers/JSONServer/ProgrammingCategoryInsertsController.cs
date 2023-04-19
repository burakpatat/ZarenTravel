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
    public partial class ProgrammingCategoryInsertsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProgrammingCategoryInsertsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProgrammingCategoryInsertsFunc(TypeName={TypeName})")]
        public IActionResult ProgrammingCategoryInsertsFunc([FromODataUri] string TypeName)
        {
            this.OnProgrammingCategoryInsertsDefaultParams(ref TypeName);

            var items = this.context.ProgrammingCategoryInserts.FromSqlRaw("EXEC [dbo].[ProgrammingCategoryInsert] @TypeName={0}", TypeName).ToList().AsQueryable();

            this.OnProgrammingCategoryInsertsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProgrammingCategoryInsertsDefaultParams(ref string TypeName);

        partial void OnProgrammingCategoryInsertsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProgrammingCategoryInsert> items);
    }
}
