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
    public partial class ProgrammingCodeTemplatesGetByProgrammingLanguagesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProgrammingCodeTemplatesGetByProgrammingLanguagesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProgrammingCodeTemplatesGetByProgrammingLanguagesFunc(ProgrammingLanguage={ProgrammingLanguage})")]
        public IActionResult ProgrammingCodeTemplatesGetByProgrammingLanguagesFunc([FromODataUri] int? ProgrammingLanguage)
        {
            this.OnProgrammingCodeTemplatesGetByProgrammingLanguagesDefaultParams(ref ProgrammingLanguage);

            var items = this.context.ProgrammingCodeTemplatesGetByProgrammingLanguages.FromSqlRaw("EXEC [dbo].[ProgrammingCodeTemplatesGetByProgrammingLanguage] @ProgrammingLanguage={0}", ProgrammingLanguage).ToList().AsQueryable();

            this.OnProgrammingCodeTemplatesGetByProgrammingLanguagesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProgrammingCodeTemplatesGetByProgrammingLanguagesDefaultParams(ref int? ProgrammingLanguage);

        partial void OnProgrammingCodeTemplatesGetByProgrammingLanguagesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProgrammingCodeTemplatesGetByProgrammingLanguage> items);
    }
}
