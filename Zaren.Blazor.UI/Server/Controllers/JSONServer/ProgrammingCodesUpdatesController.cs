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
    public partial class ProgrammingCodesUpdatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProgrammingCodesUpdatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProgrammingCodesUpdatesFunc(Id={Id},LanguageType={LanguageType},Code={Code},TargetLanguageType={TargetLanguageType},TargetLanguageCode={TargetLanguageCode},ExampleCodes={ExampleCodes})")]
        public IActionResult ProgrammingCodesUpdatesFunc([FromODataUri] int? Id, [FromODataUri] int? LanguageType, [FromODataUri] string Code, [FromODataUri] int? TargetLanguageType, [FromODataUri] string TargetLanguageCode, [FromODataUri] string ExampleCodes)
        {
            this.OnProgrammingCodesUpdatesDefaultParams(ref Id, ref LanguageType, ref Code, ref TargetLanguageType, ref TargetLanguageCode, ref ExampleCodes);

            var items = this.context.ProgrammingCodesUpdates.FromSqlRaw("EXEC [dbo].[ProgrammingCodesUpdate] @Id={0}, @LanguageType={1}, @Code={2}, @TargetLanguageType={3}, @TargetLanguageCode={4}, @ExampleCodes={5}", Id, LanguageType, Code, TargetLanguageType, TargetLanguageCode, ExampleCodes).ToList().AsQueryable();

            this.OnProgrammingCodesUpdatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProgrammingCodesUpdatesDefaultParams(ref int? Id, ref int? LanguageType, ref string Code, ref int? TargetLanguageType, ref string TargetLanguageCode, ref string ExampleCodes);

        partial void OnProgrammingCodesUpdatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProgrammingCodesUpdate> items);
    }
}
