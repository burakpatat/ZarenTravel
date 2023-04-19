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
    public partial class FieldsGetByDefaultValuesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public FieldsGetByDefaultValuesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/FieldsGetByDefaultValuesFunc(DefaultValue={DefaultValue})")]
        public IActionResult FieldsGetByDefaultValuesFunc([FromODataUri] string DefaultValue)
        {
            this.OnFieldsGetByDefaultValuesDefaultParams(ref DefaultValue);

            var items = this.context.FieldsGetByDefaultValues.FromSqlRaw("EXEC [dbo].[FieldsGetByDefaultValue] @DefaultValue={0}", DefaultValue).ToList().AsQueryable();

            this.OnFieldsGetByDefaultValuesInvoke(ref items);

            return Ok(items);
        }

        partial void OnFieldsGetByDefaultValuesDefaultParams(ref string DefaultValue);

        partial void OnFieldsGetByDefaultValuesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.FieldsGetByDefaultValue> items);
    }
}
