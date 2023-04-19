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
    public partial class ProgrammingTechnologyGetByCodeTypesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProgrammingTechnologyGetByCodeTypesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProgrammingTechnologyGetByCodeTypesFunc(CodeType={CodeType})")]
        public IActionResult ProgrammingTechnologyGetByCodeTypesFunc([FromODataUri] string CodeType)
        {
            this.OnProgrammingTechnologyGetByCodeTypesDefaultParams(ref CodeType);

            var items = this.context.ProgrammingTechnologyGetByCodeTypes.FromSqlRaw("EXEC [dbo].[ProgrammingTechnologyGetByCodeType] @CodeType={0}", CodeType).ToList().AsQueryable();

            this.OnProgrammingTechnologyGetByCodeTypesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProgrammingTechnologyGetByCodeTypesDefaultParams(ref string CodeType);

        partial void OnProgrammingTechnologyGetByCodeTypesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProgrammingTechnologyGetByCodeType> items);
    }
}
