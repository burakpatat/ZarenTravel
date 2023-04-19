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
    public partial class DynamicTableSearchesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DynamicTableSearchesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [Route("odata/JSONServer/DynamicTableSearchesFunc(Table={Table},TableID={TableID},ColumnName={ColumnName},Query={Query})")]
        public IActionResult DynamicTableSearchesFunc([FromODataUri] string Table, [FromODataUri] int? TableID, [FromODataUri] string ColumnName, [FromODataUri] string Query)
        {
            this.OnDynamicTableSearchesDefaultParams(ref Table, ref TableID, ref ColumnName, ref Query);


            SqlParameter[] @params =
            {
                new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@Table", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = Table},
              new SqlParameter("@TableID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = TableID},
              new SqlParameter("@ColumnName", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = ColumnName},
              new SqlParameter("@Query", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = Query},

            };

            foreach(var _p in @params)
            {
                if(_p.Direction == ParameterDirection.Input && _p.Value == null)
                {
                    _p.Value = DBNull.Value;
                }
            }

            this.context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[DynamicTableSearch] @Table, @TableID, @ColumnName, @Query", @params);

            int result = Convert.ToInt32(@params[0].Value);

            this.OnDynamicTableSearchesInvoke(ref result);

            return Ok(result);
        }

        partial void OnDynamicTableSearchesDefaultParams(ref string Table, ref int? TableID, ref string ColumnName, ref string Query);
      partial void OnDynamicTableSearchesInvoke(ref int result);
    }
}
