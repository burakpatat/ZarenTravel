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
    public partial class ProgrammingCodeTemplatesGetByIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProgrammingCodeTemplatesGetByIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProgrammingCodeTemplatesGetByIdsFunc(Id={Id})")]
        public IActionResult ProgrammingCodeTemplatesGetByIdsFunc([FromODataUri] int? Id)
        {
            this.OnProgrammingCodeTemplatesGetByIdsDefaultParams(ref Id);

            var items = this.context.ProgrammingCodeTemplatesGetByIds.FromSqlRaw("EXEC [dbo].[ProgrammingCodeTemplatesGetByID] @Id={0}", Id).ToList().AsQueryable();

            this.OnProgrammingCodeTemplatesGetByIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProgrammingCodeTemplatesGetByIdsDefaultParams(ref int? Id);

        partial void OnProgrammingCodeTemplatesGetByIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProgrammingCodeTemplatesGetById> items);
    }
}
