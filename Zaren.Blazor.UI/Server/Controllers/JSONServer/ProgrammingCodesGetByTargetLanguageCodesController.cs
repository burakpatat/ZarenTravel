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
    public partial class ProgrammingCodesGetByTargetLanguageCodesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProgrammingCodesGetByTargetLanguageCodesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProgrammingCodesGetByTargetLanguageCodesFunc(TargetLanguageCode={TargetLanguageCode})")]
        public IActionResult ProgrammingCodesGetByTargetLanguageCodesFunc([FromODataUri] string TargetLanguageCode)
        {
            this.OnProgrammingCodesGetByTargetLanguageCodesDefaultParams(ref TargetLanguageCode);

            var items = this.context.ProgrammingCodesGetByTargetLanguageCodes.FromSqlRaw("EXEC [dbo].[ProgrammingCodesGetByTargetLanguageCode] @TargetLanguageCode={0}", TargetLanguageCode).ToList().AsQueryable();

            this.OnProgrammingCodesGetByTargetLanguageCodesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProgrammingCodesGetByTargetLanguageCodesDefaultParams(ref string TargetLanguageCode);

        partial void OnProgrammingCodesGetByTargetLanguageCodesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProgrammingCodesGetByTargetLanguageCode> items);
    }
}
