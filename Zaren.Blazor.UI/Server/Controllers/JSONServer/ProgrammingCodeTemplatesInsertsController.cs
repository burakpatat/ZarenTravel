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
    public partial class ProgrammingCodeTemplatesInsertsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProgrammingCodeTemplatesInsertsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProgrammingCodeTemplatesInsertsFunc(ProgrammingLanguage={ProgrammingLanguage},Template={Template},ReplacedFields={ReplacedFields})")]
        public IActionResult ProgrammingCodeTemplatesInsertsFunc([FromODataUri] int? ProgrammingLanguage, [FromODataUri] string Template, [FromODataUri] string ReplacedFields)
        {
            this.OnProgrammingCodeTemplatesInsertsDefaultParams(ref ProgrammingLanguage, ref Template, ref ReplacedFields);

            var items = this.context.ProgrammingCodeTemplatesInserts.FromSqlRaw("EXEC [dbo].[ProgrammingCodeTemplatesInsert] @ProgrammingLanguage={0}, @Template={1}, @ReplacedFields={2}", ProgrammingLanguage, Template, ReplacedFields).ToList().AsQueryable();

            this.OnProgrammingCodeTemplatesInsertsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProgrammingCodeTemplatesInsertsDefaultParams(ref int? ProgrammingLanguage, ref string Template, ref string ReplacedFields);

        partial void OnProgrammingCodeTemplatesInsertsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProgrammingCodeTemplatesInsert> items);
    }
}
