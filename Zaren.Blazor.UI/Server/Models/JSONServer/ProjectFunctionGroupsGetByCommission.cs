using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    public partial class ProjectFunctionGroupsGetByCommission
    {
        public int Id { get; set; }

        public string FunctionGroupName { get; set; }

        public int? CallAfterFunctionsSuccessfullResponse { get; set; }

        public int? SoftWareLanguageId { get; set; }

        public int? CurrencyId { get; set; }

        public decimal? Price { get; set; }

        public decimal? Commission { get; set; }

    }
}