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
    public partial class ProgrammingCodesInsertsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProgrammingCodesInsertsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProgrammingCodesInsertsFunc(LanguageType={LanguageType},Code={Code},TargetLanguageType={TargetLanguageType},TargetLanguageCode={TargetLanguageCode},ExampleCodes={ExampleCodes})")]
        public IActionResult ProgrammingCodesInsertsFunc([FromODataUri] int? LanguageType, [FromODataUri] string Code, [FromODataUri] int? TargetLanguageType, [FromODataUri] string TargetLanguageCode, [FromODataUri] string ExampleCodes)
        {
            this.OnProgrammingCodesInsertsDefaultParams(ref LanguageType, ref Code, ref TargetLanguageType, ref TargetLanguageCode, ref ExampleCodes);

            var items = this.context.ProgrammingCodesInserts.FromSqlRaw("EXEC [dbo].[ProgrammingCodesInsert] @LanguageType={0}, @Code={1}, @TargetLanguageType={2}, @TargetLanguageCode={3}, @ExampleCodes={4}", LanguageType, Code, TargetLanguageType, TargetLanguageCode, ExampleCodes).ToList().AsQueryable();

            this.OnProgrammingCodesInsertsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProgrammingCodesInsertsDefaultParams(ref int? LanguageType, ref string Code, ref int? TargetLanguageType, ref string TargetLanguageCode, ref string ExampleCodes);

        partial void OnProgrammingCodesInsertsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProgrammingCodesInsert> items);
    }
}
