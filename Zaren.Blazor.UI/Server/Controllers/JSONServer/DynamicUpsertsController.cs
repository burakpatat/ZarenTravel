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
    public partial class DynamicUpsertsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DynamicUpsertsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [Route("odata/JSONServer/DynamicUpsertsFunc(tablename={tablename},tableschema={tableschema})")]
        public IActionResult DynamicUpsertsFunc([FromODataUri] string tablename, [FromODataUri] string tableschema)
        {
            this.OnDynamicUpsertsDefaultParams(ref tablename, ref tableschema);


            SqlParameter[] @params =
            {
                new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@tablename", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = tablename},
              new SqlParameter("@tableschema", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = tableschema},

            };

            foreach(var _p in @params)
            {
                if(_p.Direction == ParameterDirection.Input && _p.Value == null)
                {
                    _p.Value = DBNull.Value;
                }
            }

            this.context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[DynamicUpsert] @tablename, @tableschema", @params);

            int result = Convert.ToInt32(@params[0].Value);

            this.OnDynamicUpsertsInvoke(ref result);

            return Ok(result);
        }

        partial void OnDynamicUpsertsDefaultParams(ref string tablename, ref string tableschema);
      partial void OnDynamicUpsertsInvoke(ref int result);
    }
}
