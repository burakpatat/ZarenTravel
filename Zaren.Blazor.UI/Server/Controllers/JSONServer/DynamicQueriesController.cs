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
    public partial class DynamicQueriesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DynamicQueriesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [Route("odata/JSONServer/DynamicQueriesFunc(Query={Query})")]
        public IActionResult DynamicQueriesFunc([FromODataUri] string Query)
        {
            this.OnDynamicQueriesDefaultParams(ref Query);


            SqlParameter[] @params =
            {
                new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@Query", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = Query},

            };

            foreach(var _p in @params)
            {
                if(_p.Direction == ParameterDirection.Input && _p.Value == null)
                {
                    _p.Value = DBNull.Value;
                }
            }

            this.context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[DynamicQuery] @Query", @params);

            int result = Convert.ToInt32(@params[0].Value);

            this.OnDynamicQueriesInvoke(ref result);

            return Ok(result);
        }

        partial void OnDynamicQueriesDefaultParams(ref string Query);
      partial void OnDynamicQueriesInvoke(ref int result);
    }
}
