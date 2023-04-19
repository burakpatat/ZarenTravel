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
    public partial class ProjectTableColumnsGetByColumnNameCryptosController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTableColumnsGetByColumnNameCryptosController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTableColumnsGetByColumnNameCryptosFunc(ColumnNameCrypto={ColumnNameCrypto})")]
        public IActionResult ProjectTableColumnsGetByColumnNameCryptosFunc([FromODataUri] string ColumnNameCrypto)
        {
            this.OnProjectTableColumnsGetByColumnNameCryptosDefaultParams(ref ColumnNameCrypto);

            var items = this.context.ProjectTableColumnsGetByColumnNameCryptos.FromSqlRaw("EXEC [dbo].[ProjectTableColumnsGetByColumnNameCrypto] @ColumnNameCrypto={0}", ColumnNameCrypto).ToList().AsQueryable();

            this.OnProjectTableColumnsGetByColumnNameCryptosInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTableColumnsGetByColumnNameCryptosDefaultParams(ref string ColumnNameCrypto);

        partial void OnProjectTableColumnsGetByColumnNameCryptosInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByColumnNameCrypto> items);
    }
}
