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
    public partial class DynamicTablePagersController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DynamicTablePagersController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [Route("odata/JSONServer/DynamicTablePagersFunc(PageSize={PageSize},PageNum={PageNum},TableName={TableName},where={where},orderBy={orderBy},orderWithAsc={orderWithAsc})")]
        public IActionResult DynamicTablePagersFunc([FromODataUri] int? PageSize, [FromODataUri] int? PageNum, [FromODataUri] string TableName, [FromODataUri] string where, [FromODataUri] string orderBy, [FromODataUri] string orderWithAsc)
        {
            this.OnDynamicTablePagersDefaultParams(ref PageSize, ref PageNum, ref TableName, ref where, ref orderBy, ref orderWithAsc);


            SqlParameter[] @params =
            {
                new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@PageSize", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = PageSize},
              new SqlParameter("@PageNum", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = PageNum},
              new SqlParameter("@TableName", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = TableName},
              new SqlParameter("@where", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = where},
              new SqlParameter("@orderBy", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = orderBy},
              new SqlParameter("@orderWithAsc", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = orderWithAsc},

            };

            foreach(var _p in @params)
            {
                if(_p.Direction == ParameterDirection.Input && _p.Value == null)
                {
                    _p.Value = DBNull.Value;
                }
            }

            this.context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[DynamicTablePager] @PageSize, @PageNum, @TableName, @where, @orderBy, @orderWithAsc", @params);

            int result = Convert.ToInt32(@params[0].Value);

            this.OnDynamicTablePagersInvoke(ref result);

            return Ok(result);
        }

        partial void OnDynamicTablePagersDefaultParams(ref int? PageSize, ref int? PageNum, ref string TableName, ref string where, ref string orderBy, ref string orderWithAsc);
      partial void OnDynamicTablePagersInvoke(ref int result);
    }
}
