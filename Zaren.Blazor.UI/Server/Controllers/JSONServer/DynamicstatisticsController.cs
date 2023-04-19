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
    public partial class DynamicstatisticsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DynamicstatisticsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [Route("odata/JSONServer/DynamicstatisticsFunc()")]
        public IActionResult DynamicstatisticsFunc()
        {
            this.OnDynamicstatisticsDefaultParams();


            SqlParameter[] @params =
            {
                new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},

            };

            foreach(var _p in @params)
            {
                if(_p.Direction == ParameterDirection.Input && _p.Value == null)
                {
                    _p.Value = DBNull.Value;
                }
            }

            this.context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[Dynamicstatistics] ", @params);

            int result = Convert.ToInt32(@params[0].Value);

            this.OnDynamicstatisticsInvoke(ref result);

            return Ok(result);
        }

        partial void OnDynamicstatisticsDefaultParams();
      partial void OnDynamicstatisticsInvoke(ref int result);
    }
}
