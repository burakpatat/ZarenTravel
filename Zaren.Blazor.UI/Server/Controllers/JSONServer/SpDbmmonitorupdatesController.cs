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
    public partial class SpDbmmonitorupdatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public SpDbmmonitorupdatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [Route("odata/JSONServer/SpDbmmonitorupdatesFunc(database_name={database_name})")]
        public IActionResult SpDbmmonitorupdatesFunc([FromODataUri] string database_name)
        {
            this.OnSpDbmmonitorupdatesDefaultParams(ref database_name);


            SqlParameter[] @params =
            {
                new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@database_name", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = database_name},

            };

            foreach(var _p in @params)
            {
                if(_p.Direction == ParameterDirection.Input && _p.Value == null)
                {
                    _p.Value = DBNull.Value;
                }
            }

            this.context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[sp_dbmmonitorupdate] @database_name", @params);

            int result = Convert.ToInt32(@params[0].Value);

            this.OnSpDbmmonitorupdatesInvoke(ref result);

            return Ok(result);
        }

        partial void OnSpDbmmonitorupdatesDefaultParams(ref string database_name);
      partial void OnSpDbmmonitorupdatesInvoke(ref int result);
    }
}
