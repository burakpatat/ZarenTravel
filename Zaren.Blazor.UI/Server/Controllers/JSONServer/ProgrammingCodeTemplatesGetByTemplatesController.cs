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
    public partial class ProgrammingCodeTemplatesGetByTemplatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProgrammingCodeTemplatesGetByTemplatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProgrammingCodeTemplatesGetByTemplatesFunc(Template={Template})")]
        public IActionResult ProgrammingCodeTemplatesGetByTemplatesFunc([FromODataUri] string Template)
        {
            this.OnProgrammingCodeTemplatesGetByTemplatesDefaultParams(ref Template);

            var items = this.context.ProgrammingCodeTemplatesGetByTemplates.FromSqlRaw("EXEC [dbo].[ProgrammingCodeTemplatesGetByTemplate] @Template={0}", Template).ToList().AsQueryable();

            this.OnProgrammingCodeTemplatesGetByTemplatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProgrammingCodeTemplatesGetByTemplatesDefaultParams(ref string Template);

        partial void OnProgrammingCodeTemplatesGetByTemplatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProgrammingCodeTemplatesGetByTemplate> items);
    }
}
