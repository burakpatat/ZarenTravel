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
    public partial class ProgrammingCodesGetByIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProgrammingCodesGetByIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProgrammingCodesGetByIdsFunc(Id={Id})")]
        public IActionResult ProgrammingCodesGetByIdsFunc([FromODataUri] int? Id)
        {
            this.OnProgrammingCodesGetByIdsDefaultParams(ref Id);

            var items = this.context.ProgrammingCodesGetByIds.FromSqlRaw("EXEC [dbo].[ProgrammingCodesGetByID] @Id={0}", Id).ToList().AsQueryable();

            this.OnProgrammingCodesGetByIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProgrammingCodesGetByIdsDefaultParams(ref int? Id);

        partial void OnProgrammingCodesGetByIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProgrammingCodesGetById> items);
    }
}
