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
    public partial class GetAniesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public GetAniesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [Route("odata/JSONServer/GetAniesFunc(columnList={columnList},where={where},orderBy={orderBy},orderWithAsc={orderWithAsc},take={take},tableName={tableName})")]
        public IActionResult GetAniesFunc([FromODataUri] string columnList, [FromODataUri] string where, [FromODataUri] string orderBy, [FromODataUri] bool? orderWithAsc, [FromODataUri] int? take, [FromODataUri] string tableName)
        {
            this.OnGetAniesDefaultParams(ref columnList, ref where, ref orderBy, ref orderWithAsc, ref take, ref tableName);


            SqlParameter[] @params =
            {
                new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@columnList", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = columnList},
              new SqlParameter("@where", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = where},
              new SqlParameter("@orderBy", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = orderBy},
              new SqlParameter("@orderWithAsc", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = orderWithAsc},
              new SqlParameter("@take", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = take},
              new SqlParameter("@tableName", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = tableName},

            };

            foreach(var _p in @params)
            {
                if(_p.Direction == ParameterDirection.Input && _p.Value == null)
                {
                    _p.Value = DBNull.Value;
                }
            }

            this.context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[GetAny] @columnList, @where, @orderBy, @orderWithAsc, @take, @tableName", @params);

            int result = Convert.ToInt32(@params[0].Value);

            this.OnGetAniesInvoke(ref result);

            return Ok(result);
        }

        partial void OnGetAniesDefaultParams(ref string columnList, ref string where, ref string orderBy, ref bool? orderWithAsc, ref int? take, ref string tableName);
      partial void OnGetAniesInvoke(ref int result);
    }
}
