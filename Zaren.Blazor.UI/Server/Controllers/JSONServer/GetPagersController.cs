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
    public partial class GetPagersController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public GetPagersController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [Route("odata/JSONServer/GetPagersFunc(pageSize={pageSize},pageNum={pageNum},tableName={tableName},where={where},orderBy={orderBy},orderWithAsc={orderWithAsc},columnList={columnList},take={take})")]
        public IActionResult GetPagersFunc([FromODataUri] int? pageSize, [FromODataUri] int? pageNum, [FromODataUri] string tableName, [FromODataUri] string where, [FromODataUri] string orderBy, [FromODataUri] string orderWithAsc, [FromODataUri] string columnList, [FromODataUri] int? take)
        {
            this.OnGetPagersDefaultParams(ref pageSize, ref pageNum, ref tableName, ref where, ref orderBy, ref orderWithAsc, ref columnList, ref take);


            SqlParameter[] @params =
            {
                new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@pageSize", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = pageSize},
              new SqlParameter("@pageNum", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = pageNum},
              new SqlParameter("@tableName", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = tableName},
              new SqlParameter("@where", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = where},
              new SqlParameter("@orderBy", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = orderBy},
              new SqlParameter("@orderWithAsc", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = orderWithAsc},
              new SqlParameter("@columnList", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = columnList},
              new SqlParameter("@take", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = take},

            };

            foreach(var _p in @params)
            {
                if(_p.Direction == ParameterDirection.Input && _p.Value == null)
                {
                    _p.Value = DBNull.Value;
                }
            }

            this.context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[GetPager] @pageSize, @pageNum, @tableName, @where, @orderBy, @orderWithAsc, @columnList, @take", @params);

            int result = Convert.ToInt32(@params[0].Value);

            this.OnGetPagersInvoke(ref result);

            return Ok(result);
        }

        partial void OnGetPagersDefaultParams(ref int? pageSize, ref int? pageNum, ref string tableName, ref string where, ref string orderBy, ref string orderWithAsc, ref string columnList, ref int? take);
      partial void OnGetPagersInvoke(ref int result);
    }
}
