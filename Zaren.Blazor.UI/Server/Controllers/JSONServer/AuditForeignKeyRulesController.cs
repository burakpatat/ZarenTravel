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
    [Route("odata/JSONServer/AuditForeignKeyRules")]
    public partial class AuditForeignKeyRulesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public AuditForeignKeyRulesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.JSONServer.AuditForeignKeyRule> GetAuditForeignKeyRules()
        {
            var items = this.context.AuditForeignKeyRules.AsQueryable<ZarenUI.Server.Models.JSONServer.AuditForeignKeyRule>();
            this.OnAuditForeignKeyRulesRead(ref items);

            return items;
        }

        partial void OnAuditForeignKeyRulesRead(ref IQueryable<ZarenUI.Server.Models.JSONServer.AuditForeignKeyRule> items);

        partial void OnAuditForeignKeyRuleGet(ref SingleResult<ZarenUI.Server.Models.JSONServer.AuditForeignKeyRule> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/JSONServer/AuditForeignKeyRules(LogID={LogID})")]
        public SingleResult<ZarenUI.Server.Models.JSONServer.AuditForeignKeyRule> GetAuditForeignKeyRule(long key)
        {
            var items = this.context.AuditForeignKeyRules.Where(i => i.LogID == key);
            var result = SingleResult.Create(items);

            OnAuditForeignKeyRuleGet(ref result);

            return result;
        }
        partial void OnAuditForeignKeyRuleDeleted(ZarenUI.Server.Models.JSONServer.AuditForeignKeyRule item);
        partial void OnAfterAuditForeignKeyRuleDeleted(ZarenUI.Server.Models.JSONServer.AuditForeignKeyRule item);

        [HttpDelete("/odata/JSONServer/AuditForeignKeyRules(LogID={LogID})")]
        public IActionResult DeleteAuditForeignKeyRule(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.AuditForeignKeyRules
                    .Where(i => i.LogID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnAuditForeignKeyRuleDeleted(item);
                this.context.AuditForeignKeyRules.Remove(item);
                this.context.SaveChanges();
                this.OnAfterAuditForeignKeyRuleDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditForeignKeyRuleUpdated(ZarenUI.Server.Models.JSONServer.AuditForeignKeyRule item);
        partial void OnAfterAuditForeignKeyRuleUpdated(ZarenUI.Server.Models.JSONServer.AuditForeignKeyRule item);

        [HttpPut("/odata/JSONServer/AuditForeignKeyRules(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutAuditForeignKeyRule(long key, [FromBody]ZarenUI.Server.Models.JSONServer.AuditForeignKeyRule item)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (item == null || (item.LogID != key))
                {
                    return BadRequest();
                }
                this.OnAuditForeignKeyRuleUpdated(item);
                this.context.AuditForeignKeyRules.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditForeignKeyRules.Where(i => i.LogID == key);
                ;
                this.OnAfterAuditForeignKeyRuleUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/JSONServer/AuditForeignKeyRules(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchAuditForeignKeyRule(long key, [FromBody]Delta<ZarenUI.Server.Models.JSONServer.AuditForeignKeyRule> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.AuditForeignKeyRules.Where(i => i.LogID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnAuditForeignKeyRuleUpdated(item);
                this.context.AuditForeignKeyRules.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditForeignKeyRules.Where(i => i.LogID == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditForeignKeyRuleCreated(ZarenUI.Server.Models.JSONServer.AuditForeignKeyRule item);
        partial void OnAfterAuditForeignKeyRuleCreated(ZarenUI.Server.Models.JSONServer.AuditForeignKeyRule item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.JSONServer.AuditForeignKeyRule item)
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

                this.OnAuditForeignKeyRuleCreated(item);
                this.context.AuditForeignKeyRules.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditForeignKeyRules.Where(i => i.LogID == item.LogID);

                ;

                this.OnAfterAuditForeignKeyRuleCreated(item);

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
