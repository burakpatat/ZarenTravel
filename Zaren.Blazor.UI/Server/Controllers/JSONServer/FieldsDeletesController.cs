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
    public partial class FieldsDeletesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public FieldsDeletesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [Route("odata/JSONServer/FieldsDeletesFunc(Id={Id})")]
        public IActionResult FieldsDeletesFunc([FromODataUri] long? Id)
        {
            this.OnFieldsDeletesDefaultParams(ref Id);


            SqlParameter[] @params =
            {
                new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@Id", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = Id},

            };

            foreach(var _p in @params)
            {
                if(_p.Direction == ParameterDirection.Input && _p.Value == null)
                {
                    _p.Value = DBNull.Value;
                }
            }

            this.context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[FieldsDelete] @Id", @params);

            int result = Convert.ToInt32(@params[0].Value);

            this.OnFieldsDeletesInvoke(ref result);

            return Ok(result);
        }

        partial void OnFieldsDeletesDefaultParams(ref long? Id);
      partial void OnFieldsDeletesInvoke(ref int result);
    }
}
