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
    public partial class GetModifyDatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public GetModifyDatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/GetModifyDatesFunc(name={name})")]
        public IActionResult GetModifyDatesFunc([FromODataUri] string name)
        {
            this.OnGetModifyDatesDefaultParams(ref name);

            var items = this.context.GetModifyDates.FromSqlRaw("EXEC [dbo].[GetModifyDate] @name={0}", name).ToList().AsQueryable();

            this.OnGetModifyDatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnGetModifyDatesDefaultParams(ref string name);

        partial void OnGetModifyDatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.GetModifyDate> items);
    }
}
