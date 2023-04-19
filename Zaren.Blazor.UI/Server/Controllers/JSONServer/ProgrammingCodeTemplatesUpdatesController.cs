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
    public partial class ProgrammingCodeTemplatesUpdatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProgrammingCodeTemplatesUpdatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProgrammingCodeTemplatesUpdatesFunc(Id={Id},ProgrammingLanguage={ProgrammingLanguage},Template={Template},ReplacedFields={ReplacedFields})")]
        public IActionResult ProgrammingCodeTemplatesUpdatesFunc([FromODataUri] int? Id, [FromODataUri] int? ProgrammingLanguage, [FromODataUri] string Template, [FromODataUri] string ReplacedFields)
        {
            this.OnProgrammingCodeTemplatesUpdatesDefaultParams(ref Id, ref ProgrammingLanguage, ref Template, ref ReplacedFields);

            var items = this.context.ProgrammingCodeTemplatesUpdates.FromSqlRaw("EXEC [dbo].[ProgrammingCodeTemplatesUpdate] @Id={0}, @ProgrammingLanguage={1}, @Template={2}, @ReplacedFields={3}", Id, ProgrammingLanguage, Template, ReplacedFields).ToList().AsQueryable();

            this.OnProgrammingCodeTemplatesUpdatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProgrammingCodeTemplatesUpdatesDefaultParams(ref int? Id, ref int? ProgrammingLanguage, ref string Template, ref string ReplacedFields);

        partial void OnProgrammingCodeTemplatesUpdatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProgrammingCodeTemplatesUpdate> items);
    }
}
