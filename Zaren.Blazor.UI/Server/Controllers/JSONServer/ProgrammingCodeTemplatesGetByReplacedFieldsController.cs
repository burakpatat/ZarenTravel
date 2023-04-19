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
    public partial class ProgrammingCodeTemplatesGetByReplacedFieldsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProgrammingCodeTemplatesGetByReplacedFieldsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProgrammingCodeTemplatesGetByReplacedFieldsFunc(ReplacedFields={ReplacedFields})")]
        public IActionResult ProgrammingCodeTemplatesGetByReplacedFieldsFunc([FromODataUri] string ReplacedFields)
        {
            this.OnProgrammingCodeTemplatesGetByReplacedFieldsDefaultParams(ref ReplacedFields);

            var items = this.context.ProgrammingCodeTemplatesGetByReplacedFields.FromSqlRaw("EXEC [dbo].[ProgrammingCodeTemplatesGetByReplacedFields] @ReplacedFields={0}", ReplacedFields).ToList().AsQueryable();

            this.OnProgrammingCodeTemplatesGetByReplacedFieldsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProgrammingCodeTemplatesGetByReplacedFieldsDefaultParams(ref string ReplacedFields);

        partial void OnProgrammingCodeTemplatesGetByReplacedFieldsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProgrammingCodeTemplatesGetByReplacedField> items);
    }
}
