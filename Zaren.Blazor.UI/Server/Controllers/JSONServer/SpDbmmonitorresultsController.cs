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
    public partial class SpDbmmonitorresultsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public SpDbmmonitorresultsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [Route("odata/JSONServer/SpDbmmonitorresultsFunc(database_name={database_name},mode={mode},update_table={update_table})")]
        public IActionResult SpDbmmonitorresultsFunc([FromODataUri] string database_name, [FromODataUri] int? mode, [FromODataUri] int? update_table)
        {
            this.OnSpDbmmonitorresultsDefaultParams(ref database_name, ref mode, ref update_table);


            SqlParameter[] @params =
            {
                new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@database_name", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = database_name},
              new SqlParameter("@mode", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = mode},
              new SqlParameter("@update_table", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = update_table},

            };

            foreach(var _p in @params)
            {
                if(_p.Direction == ParameterDirection.Input && _p.Value == null)
                {
                    _p.Value = DBNull.Value;
                }
            }

            this.context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[sp_dbmmonitorresults] @database_name, @mode, @update_table", @params);

            int result = Convert.ToInt32(@params[0].Value);

            this.OnSpDbmmonitorresultsInvoke(ref result);

            return Ok(result);
        }

        partial void OnSpDbmmonitorresultsDefaultParams(ref string database_name, ref int? mode, ref int? update_table);
      partial void OnSpDbmmonitorresultsInvoke(ref int result);
    }
}
