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
    public partial class CountryLanguagesDeletesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryLanguagesDeletesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [Route("odata/JSONServer/CountryLanguagesDeletesFunc(Id={Id})")]
        public IActionResult CountryLanguagesDeletesFunc([FromODataUri] int? Id)
        {
            this.OnCountryLanguagesDeletesDefaultParams(ref Id);


            SqlParameter[] @params =
            {
                new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@Id", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = Id},

            };

            foreach(var _p in @params)
            {
                if(_p.Direction == ParameterDirection.Input && _p.Value == null)
                {
                    _p.Value = DBNull.Value;
                }
            }

            this.context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[CountryLanguagesDelete] @Id", @params);

            int result = Convert.ToInt32(@params[0].Value);

            this.OnCountryLanguagesDeletesInvoke(ref result);

            return Ok(result);
        }

        partial void OnCountryLanguagesDeletesDefaultParams(ref int? Id);
      partial void OnCountryLanguagesDeletesInvoke(ref int result);
    }
}
