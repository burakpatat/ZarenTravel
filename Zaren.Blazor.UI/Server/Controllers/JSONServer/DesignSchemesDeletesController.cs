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
    public partial class DesignSchemesDeletesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignSchemesDeletesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [Route("odata/JSONServer/DesignSchemesDeletesFunc(colors_body_background={colors_body_background})")]
        public IActionResult DesignSchemesDeletesFunc([FromODataUri] string colors_body_background)
        {
            this.OnDesignSchemesDeletesDefaultParams(ref colors_body_background);


            SqlParameter[] @params =
            {
                new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@colors_body_background", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = colors_body_background},

            };

            foreach(var _p in @params)
            {
                if(_p.Direction == ParameterDirection.Input && _p.Value == null)
                {
                    _p.Value = DBNull.Value;
                }
            }

            this.context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[DesignSchemesDelete] @colors_body_background", @params);

            int result = Convert.ToInt32(@params[0].Value);

            this.OnDesignSchemesDeletesInvoke(ref result);

            return Ok(result);
        }

        partial void OnDesignSchemesDeletesDefaultParams(ref string colors_body_background);
      partial void OnDesignSchemesDeletesInvoke(ref int result);
    }
}
