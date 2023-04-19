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
    public partial class DynamicJsonsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DynamicJsonsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [Route("odata/JSONServer/DynamicJsonsFunc(json={json})")]
        public IActionResult DynamicJsonsFunc([FromODataUri] string json)
        {
            this.OnDynamicJsonsDefaultParams(ref json);


            SqlParameter[] @params =
            {
                new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@json", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = json},

            };

            foreach(var _p in @params)
            {
                if(_p.Direction == ParameterDirection.Input && _p.Value == null)
                {
                    _p.Value = DBNull.Value;
                }
            }

            this.context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[DynamicJson] @json", @params);

            int result = Convert.ToInt32(@params[0].Value);

            this.OnDynamicJsonsInvoke(ref result);

            return Ok(result);
        }

        partial void OnDynamicJsonsDefaultParams(ref string json);
      partial void OnDynamicJsonsInvoke(ref int result);
    }
}
