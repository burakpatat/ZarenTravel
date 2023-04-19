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
    [Route("odata/JSONServer/ForeignKeyRules")]
    public partial class ForeignKeyRulesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ForeignKeyRulesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.JSONServer.ForeignKeyRule> GetForeignKeyRules()
        {
            var items = this.context.ForeignKeyRules.AsQueryable<ZarenUI.Server.Models.JSONServer.ForeignKeyRule>();
            this.OnForeignKeyRulesRead(ref items);

            return items;
        }

        partial void OnForeignKeyRulesRead(ref IQueryable<ZarenUI.Server.Models.JSONServer.ForeignKeyRule> items);

        partial void OnForeignKeyRuleGet(ref SingleResult<ZarenUI.Server.Models.JSONServer.ForeignKeyRule> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/JSONServer/ForeignKeyRules(Id={Id})")]
        public SingleResult<ZarenUI.Server.Models.JSONServer.ForeignKeyRule> GetForeignKeyRule(long key)
        {
            var items = this.context.ForeignKeyRules.Where(i => i.Id == key);
            var result = SingleResult.Create(items);

            OnForeignKeyRuleGet(ref result);

            return result;
        }
        partial void OnForeignKeyRuleDeleted(ZarenUI.Server.Models.JSONServer.ForeignKeyRule item);
        partial void OnAfterForeignKeyRuleDeleted(ZarenUI.Server.Models.JSONServer.ForeignKeyRule item);

        [HttpDelete("/odata/JSONServer/ForeignKeyRules(Id={Id})")]
        public IActionResult DeleteForeignKeyRule(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.ForeignKeyRules
                    .Where(i => i.Id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnForeignKeyRuleDeleted(item);
                this.context.ForeignKeyRules.Remove(item);
                this.context.SaveChanges();
                this.OnAfterForeignKeyRuleDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnForeignKeyRuleUpdated(ZarenUI.Server.Models.JSONServer.ForeignKeyRule item);
        partial void OnAfterForeignKeyRuleUpdated(ZarenUI.Server.Models.JSONServer.ForeignKeyRule item);

        [HttpPut("/odata/JSONServer/ForeignKeyRules(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutForeignKeyRule(long key, [FromBody]ZarenUI.Server.Models.JSONServer.ForeignKeyRule item)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (item == null || (item.Id != key))
                {
                    return BadRequest();
                }
                this.OnForeignKeyRuleUpdated(item);
                this.context.ForeignKeyRules.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ForeignKeyRules.Where(i => i.Id == key);
                ;
                this.OnAfterForeignKeyRuleUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/JSONServer/ForeignKeyRules(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchForeignKeyRule(long key, [FromBody]Delta<ZarenUI.Server.Models.JSONServer.ForeignKeyRule> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.ForeignKeyRules.Where(i => i.Id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnForeignKeyRuleUpdated(item);
                this.context.ForeignKeyRules.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ForeignKeyRules.Where(i => i.Id == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnForeignKeyRuleCreated(ZarenUI.Server.Models.JSONServer.ForeignKeyRule item);
        partial void OnAfterForeignKeyRuleCreated(ZarenUI.Server.Models.JSONServer.ForeignKeyRule item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.JSONServer.ForeignKeyRule item)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (item == null)
                {
                    return BadRequest();
                }

                this.OnForeignKeyRuleCreated(item);
                this.context.ForeignKeyRules.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ForeignKeyRules.Where(i => i.Id == item.Id);

                ;

                this.OnAfterForeignKeyRuleCreated(item);

                return new ObjectResult(SingleResult.Create(itemToReturn))
                {
                    StatusCode = 201
                };
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
