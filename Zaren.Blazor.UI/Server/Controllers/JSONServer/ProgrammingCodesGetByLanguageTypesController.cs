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
    public partial class ProgrammingCodesGetByLanguageTypesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProgrammingCodesGetByLanguageTypesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProgrammingCodesGetByLanguageTypesFunc(LanguageType={LanguageType})")]
        public IActionResult ProgrammingCodesGetByLanguageTypesFunc([FromODataUri] int? LanguageType)
        {
            this.OnProgrammingCodesGetByLanguageTypesDefaultParams(ref LanguageType);

            var items = this.context.ProgrammingCodesGetByLanguageTypes.FromSqlRaw("EXEC [dbo].[ProgrammingCodesGetByLanguageType] @LanguageType={0}", LanguageType).ToList().AsQueryable();

            this.OnProgrammingCodesGetByLanguageTypesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProgrammingCodesGetByLanguageTypesDefaultParams(ref int? LanguageType);

        partial void OnProgrammingCodesGetByLanguageTypesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProgrammingCodesGetByLanguageType> items);
    }
}
