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
    public partial class ProgrammingCodesGetByCodesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProgrammingCodesGetByCodesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProgrammingCodesGetByCodesFunc(Code={Code})")]
        public IActionResult ProgrammingCodesGetByCodesFunc([FromODataUri] string Code)
        {
            this.OnProgrammingCodesGetByCodesDefaultParams(ref Code);

            var items = this.context.ProgrammingCodesGetByCodes.FromSqlRaw("EXEC [dbo].[ProgrammingCodesGetByCode] @Code={0}", Code).ToList().AsQueryable();

            this.OnProgrammingCodesGetByCodesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProgrammingCodesGetByCodesDefaultParams(ref string Code);

        partial void OnProgrammingCodesGetByCodesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProgrammingCodesGetByCode> items);
    }
}
