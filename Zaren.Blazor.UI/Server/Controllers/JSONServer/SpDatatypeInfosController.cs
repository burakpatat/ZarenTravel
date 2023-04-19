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
    public partial class SpDatatypeInfosController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public SpDatatypeInfosController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/SpDatatypeInfosFunc(data_type={data_type},ODBCVer={ODBCVer})")]
        public IActionResult SpDatatypeInfosFunc([FromODataUri] int? data_type, [FromODataUri] byte? ODBCVer)
        {
            this.OnSpDatatypeInfosDefaultParams(ref data_type, ref ODBCVer);

            var items = this.context.SpDatatypeInfos.FromSqlRaw("EXEC [dbo].[sp_datatype_info] @data_type={0}, @ODBCVer={1}", data_type, ODBCVer).ToList().AsQueryable();

            this.OnSpDatatypeInfosInvoke(ref items);

            return Ok(items);
        }

        partial void OnSpDatatypeInfosDefaultParams(ref int? data_type, ref byte? ODBCVer);

        partial void OnSpDatatypeInfosInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.SpDatatypeInfo> items);
    }
}
