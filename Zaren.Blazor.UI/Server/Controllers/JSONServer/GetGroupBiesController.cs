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
    public partial class GetGroupBiesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public GetGroupBiesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [Route("odata/JSONServer/GetGroupBiesFunc(column={column},where={where},groupBy={groupBy},havingClause={havingClause},tableName={tableName})")]
        public IActionResult GetGroupBiesFunc([FromODataUri] string column, [FromODataUri] string where, [FromODataUri] string groupBy, [FromODataUri] string havingClause, [FromODataUri] string tableName)
        {
            this.OnGetGroupBiesDefaultParams(ref column, ref where, ref groupBy, ref havingClause, ref tableName);


            SqlParameter[] @params =
            {
                new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@column", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = column},
              new SqlParameter("@where", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = where},
              new SqlParameter("@groupBy", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = groupBy},
              new SqlParameter("@havingClause", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = havingClause},
              new SqlParameter("@tableName", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = tableName},

            };

            foreach(var _p in @params)
            {
                if(_p.Direction == ParameterDirection.Input && _p.Value == null)
                {
                    _p.Value = DBNull.Value;
                }
            }

            this.context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[GetGroupBy] @column, @where, @groupBy, @havingClause, @tableName", @params);

            int result = Convert.ToInt32(@params[0].Value);

            this.OnGetGroupBiesInvoke(ref result);

            return Ok(result);
        }

        partial void OnGetGroupBiesDefaultParams(ref string column, ref string where, ref string groupBy, ref string havingClause, ref string tableName);
      partial void OnGetGroupBiesInvoke(ref int result);
    }
}
