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
    public partial class SpKillOldestTransactionOnSecondariesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public SpKillOldestTransactionOnSecondariesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [Route("odata/JSONServer/SpKillOldestTransactionOnSecondariesFunc(database_name={database_name},kill_all={kill_all},killed_xdests={killed_xdests})")]
        public IActionResult SpKillOldestTransactionOnSecondariesFunc([FromODataUri] string database_name, [FromODataUri] bool? kill_all, [FromODataUri] long? killed_xdests)
        {
            this.OnSpKillOldestTransactionOnSecondariesDefaultParams(ref database_name, ref kill_all, ref killed_xdests);


            SqlParameter[] @params =
            {
                new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@database_name", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = database_name},
              new SqlParameter("@kill_all", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = kill_all},
              new SqlParameter("@killed_xdests", SqlDbType.BigInt) {Direction = ParameterDirection.InputOutput}, 

            };

            foreach(var _p in @params)
            {
                if(_p.Direction == ParameterDirection.Input && _p.Value == null)
                {
                    _p.Value = DBNull.Value;
                }
            }

            this.context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[sp_kill_oldest_transaction_on_secondary] @database_name, @kill_all, @killed_xdests out", @params);

            var result = new ZarenUI.Server.Models.JSONServer.SpKillOldestTransactionOnSecondaryResult();

            foreach(var _p in @params)
            {
                if(_p.Direction == ParameterDirection.Output && _p.Value == DBNull.Value)
                {
                    _p.Value = null;
                }
            }
                
            result.returnValue = Convert.ToInt32(@params[0].Value);
          result.killed_xdests = Convert.ToInt64(@params[3].Value);

            this.OnSpKillOldestTransactionOnSecondariesInvoke(ref result);

            return Ok(result);
        }

        partial void OnSpKillOldestTransactionOnSecondariesDefaultParams(ref string database_name, ref bool? kill_all, ref long? killed_xdests);
      partial void OnSpKillOldestTransactionOnSecondariesInvoke(ref ZarenUI.Server.Models.JSONServer.SpKillOldestTransactionOnSecondaryResult result);
    }
}
