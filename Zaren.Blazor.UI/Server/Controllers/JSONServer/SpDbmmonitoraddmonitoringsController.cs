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
    public partial class SpDbmmonitoraddmonitoringsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public SpDbmmonitoraddmonitoringsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [Route("odata/JSONServer/SpDbmmonitoraddmonitoringsFunc(update_period={update_period})")]
        public IActionResult SpDbmmonitoraddmonitoringsFunc([FromODataUri] int? update_period)
        {
            this.OnSpDbmmonitoraddmonitoringsDefaultParams(ref update_period);


            SqlParameter[] @params =
            {
                new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@update_period", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = update_period},

            };

            foreach(var _p in @params)
            {
                if(_p.Direction == ParameterDirection.Input && _p.Value == null)
                {
                    _p.Value = DBNull.Value;
                }
            }

            this.context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[sp_dbmmonitoraddmonitoring] @update_period", @params);

            int result = Convert.ToInt32(@params[0].Value);

            this.OnSpDbmmonitoraddmonitoringsInvoke(ref result);

            return Ok(result);
        }

        partial void OnSpDbmmonitoraddmonitoringsDefaultParams(ref int? update_period);
      partial void OnSpDbmmonitoraddmonitoringsInvoke(ref int result);
    }
}
