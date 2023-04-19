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
    public partial class GetExtendedRemovesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public GetExtendedRemovesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [Route("odata/JSONServer/GetExtendedRemovesFunc(pname={pname},plevel1name={plevel1name},plevel2name={plevel2name})")]
        public IActionResult GetExtendedRemovesFunc([FromODataUri] string pname, [FromODataUri] string plevel1name, [FromODataUri] string plevel2name)
        {
            this.OnGetExtendedRemovesDefaultParams(ref pname, ref plevel1name, ref plevel2name);


            SqlParameter[] @params =
            {
                new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@pname", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = pname},
              new SqlParameter("@plevel1name", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = plevel1name},
              new SqlParameter("@plevel2name", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = plevel2name},

            };

            foreach(var _p in @params)
            {
                if(_p.Direction == ParameterDirection.Input && _p.Value == null)
                {
                    _p.Value = DBNull.Value;
                }
            }

            this.context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[GetExtendedRemove] @pname, @plevel1name, @plevel2name", @params);

            int result = Convert.ToInt32(@params[0].Value);

            this.OnGetExtendedRemovesInvoke(ref result);

            return Ok(result);
        }

        partial void OnGetExtendedRemovesDefaultParams(ref string pname, ref string plevel1name, ref string plevel2name);
      partial void OnGetExtendedRemovesInvoke(ref int result);
    }
}
