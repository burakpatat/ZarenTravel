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
    public partial class DynamicTablesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DynamicTablesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [Route("odata/JSONServer/DynamicTablesFunc(AllColumns={AllColumns},SelectTop={SelectTop},GetCount={GetCount},HasWhere={HasWhere},HasOrder={HasOrder},HasGroupBy={HasGroupBy},HasHaving={HasHaving},HasDirect={HasDirect},LeftJoin={LeftJoin},LeftJoinTable={LeftJoinTable},LeftJoinTableSelectColumn={LeftJoinTableSelectColumn},RightJoin={RightJoin},RightJoinTable={RightJoinTable},RightJoinTableSelectColumn={RightJoinTableSelectColumn},InnerJoin={InnerJoin},InnerJoinTable={InnerJoinTable},InnerJoinTableSelectColumn={InnerJoinTableSelectColumn},Table={Table},ColumnNames={ColumnNames},PrimaryKey={PrimaryKey},SelectTopCount={SelectTopCount},OrderColumn={OrderColumn},GroupByColumn={GroupByColumn},JoinTable={JoinTable},WhereClause={WhereClause},HavingClause={HavingClause},DirectQuery={DirectQuery})")]
        public IActionResult DynamicTablesFunc([FromODataUri] bool? AllColumns, [FromODataUri] bool? SelectTop, [FromODataUri] bool? GetCount, [FromODataUri] bool? HasWhere, [FromODataUri] bool? HasOrder, [FromODataUri] bool? HasGroupBy, [FromODataUri] bool? HasHaving, [FromODataUri] bool? HasDirect, [FromODataUri] bool? LeftJoin, [FromODataUri] string LeftJoinTable, [FromODataUri] string LeftJoinTableSelectColumn, [FromODataUri] bool? RightJoin, [FromODataUri] string RightJoinTable, [FromODataUri] string RightJoinTableSelectColumn, [FromODataUri] bool? InnerJoin, [FromODataUri] string InnerJoinTable, [FromODataUri] string InnerJoinTableSelectColumn, [FromODataUri] string Table, [FromODataUri] string ColumnNames, [FromODataUri] string PrimaryKey, [FromODataUri] int? SelectTopCount, [FromODataUri] string OrderColumn, [FromODataUri] string GroupByColumn, [FromODataUri] string JoinTable, [FromODataUri] string WhereClause, [FromODataUri] string HavingClause, [FromODataUri] string DirectQuery)
        {
            this.OnDynamicTablesDefaultParams(ref AllColumns, ref SelectTop, ref GetCount, ref HasWhere, ref HasOrder, ref HasGroupBy, ref HasHaving, ref HasDirect, ref LeftJoin, ref LeftJoinTable, ref LeftJoinTableSelectColumn, ref RightJoin, ref RightJoinTable, ref RightJoinTableSelectColumn, ref InnerJoin, ref InnerJoinTable, ref InnerJoinTableSelectColumn, ref Table, ref ColumnNames, ref PrimaryKey, ref SelectTopCount, ref OrderColumn, ref GroupByColumn, ref JoinTable, ref WhereClause, ref HavingClause, ref DirectQuery);


            SqlParameter[] @params =
            {
                new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@AllColumns", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = AllColumns},
              new SqlParameter("@SelectTop", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = SelectTop},
              new SqlParameter("@GetCount", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = GetCount},
              new SqlParameter("@HasWhere", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = HasWhere},
              new SqlParameter("@HasOrder", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = HasOrder},
              new SqlParameter("@HasGroupBy", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = HasGroupBy},
              new SqlParameter("@HasHaving", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = HasHaving},
              new SqlParameter("@HasDirect", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = HasDirect},
              new SqlParameter("@LeftJoin", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = LeftJoin},
              new SqlParameter("@LeftJoinTable", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = LeftJoinTable},
              new SqlParameter("@LeftJoinTableSelectColumn", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = LeftJoinTableSelectColumn},
              new SqlParameter("@RightJoin", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = RightJoin},
              new SqlParameter("@RightJoinTable", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = RightJoinTable},
              new SqlParameter("@RightJoinTableSelectColumn", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = RightJoinTableSelectColumn},
              new SqlParameter("@InnerJoin", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = InnerJoin},
              new SqlParameter("@InnerJoinTable", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = InnerJoinTable},
              new SqlParameter("@InnerJoinTableSelectColumn", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = InnerJoinTableSelectColumn},
              new SqlParameter("@Table", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = Table},
              new SqlParameter("@ColumnNames", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = ColumnNames},
              new SqlParameter("@PrimaryKey", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = PrimaryKey},
              new SqlParameter("@SelectTopCount", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = SelectTopCount},
              new SqlParameter("@OrderColumn", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = OrderColumn},
              new SqlParameter("@GroupByColumn", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = GroupByColumn},
              new SqlParameter("@JoinTable", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = JoinTable},
              new SqlParameter("@WhereClause", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = WhereClause},
              new SqlParameter("@HavingClause", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = HavingClause},
              new SqlParameter("@DirectQuery", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = DirectQuery},

            };

            foreach(var _p in @params)
            {
                if(_p.Direction == ParameterDirection.Input && _p.Value == null)
                {
                    _p.Value = DBNull.Value;
                }
            }

            this.context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[DynamicTable] @AllColumns, @SelectTop, @GetCount, @HasWhere, @HasOrder, @HasGroupBy, @HasHaving, @HasDirect, @LeftJoin, @LeftJoinTable, @LeftJoinTableSelectColumn, @RightJoin, @RightJoinTable, @RightJoinTableSelectColumn, @InnerJoin, @InnerJoinTable, @InnerJoinTableSelectColumn, @Table, @ColumnNames, @PrimaryKey, @SelectTopCount, @OrderColumn, @GroupByColumn, @JoinTable, @WhereClause, @HavingClause, @DirectQuery", @params);

            int result = Convert.ToInt32(@params[0].Value);

            this.OnDynamicTablesInvoke(ref result);

            return Ok(result);
        }

        partial void OnDynamicTablesDefaultParams(ref bool? AllColumns, ref bool? SelectTop, ref bool? GetCount, ref bool? HasWhere, ref bool? HasOrder, ref bool? HasGroupBy, ref bool? HasHaving, ref bool? HasDirect, ref bool? LeftJoin, ref string LeftJoinTable, ref string LeftJoinTableSelectColumn, ref bool? RightJoin, ref string RightJoinTable, ref string RightJoinTableSelectColumn, ref bool? InnerJoin, ref string InnerJoinTable, ref string InnerJoinTableSelectColumn, ref string Table, ref string ColumnNames, ref string PrimaryKey, ref int? SelectTopCount, ref string OrderColumn, ref string GroupByColumn, ref string JoinTable, ref string WhereClause, ref string HavingClause, ref string DirectQuery);
      partial void OnDynamicTablesInvoke(ref int result);
    }
}
