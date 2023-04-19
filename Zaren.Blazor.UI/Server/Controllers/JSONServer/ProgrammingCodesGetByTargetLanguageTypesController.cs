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
    public partial class ProgrammingCodesGetByTargetLanguageTypesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProgrammingCodesGetByTargetLanguageTypesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProgrammingCodesGetByTargetLanguageTypesFunc(TargetLanguageType={TargetLanguageType})")]
        public IActionResult ProgrammingCodesGetByTargetLanguageTypesFunc([FromODataUri] int? TargetLanguageType)
        {
            this.OnProgrammingCodesGetByTargetLanguageTypesDefaultParams(ref TargetLanguageType);

            var items = this.context.ProgrammingCodesGetByTargetLanguageTypes.FromSqlRaw("EXEC [dbo].[ProgrammingCodesGetByTargetLanguageType] @TargetLanguageType={0}", TargetLanguageType).ToList().AsQueryable();

            this.OnProgrammingCodesGetByTargetLanguageTypesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProgrammingCodesGetByTargetLanguageTypesDefaultParams(ref int? TargetLanguageType);

        partial void OnProgrammingCodesGetByTargetLanguageTypesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProgrammingCodesGetByTargetLanguageType> items);
    }
}
