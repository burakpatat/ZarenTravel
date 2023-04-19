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
    public partial class ProjectTablesGetByTableNameCryptosController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTablesGetByTableNameCryptosController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTablesGetByTableNameCryptosFunc(TableNameCrypto={TableNameCrypto})")]
        public IActionResult ProjectTablesGetByTableNameCryptosFunc([FromODataUri] string TableNameCrypto)
        {
            this.OnProjectTablesGetByTableNameCryptosDefaultParams(ref TableNameCrypto);

            var items = this.context.ProjectTablesGetByTableNameCryptos.FromSqlRaw("EXEC [dbo].[ProjectTablesGetByTableNameCrypto] @TableNameCrypto={0}", TableNameCrypto).ToList().AsQueryable();

            this.OnProjectTablesGetByTableNameCryptosInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTablesGetByTableNameCryptosDefaultParams(ref string TableNameCrypto);

        partial void OnProjectTablesGetByTableNameCryptosInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByTableNameCrypto> items);
    }
}
