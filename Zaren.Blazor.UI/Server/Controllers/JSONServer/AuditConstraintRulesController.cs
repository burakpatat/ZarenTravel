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
    [Route("odata/JSONServer/AuditConstraintRules")]
    public partial class AuditConstraintRulesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public AuditConstraintRulesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.JSONServer.AuditConstraintRule> GetAuditConstraintRules()
        {
            var items = this.context.AuditConstraintRules.AsQueryable<ZarenUI.Server.Models.JSONServer.AuditConstraintRule>();
            this.OnAuditConstraintRulesRead(ref items);

            return items;
        }

        partial void OnAuditConstraintRulesRead(ref IQueryable<ZarenUI.Server.Models.JSONServer.AuditConstraintRule> items);

        partial void OnAuditConstraintRuleGet(ref SingleResult<ZarenUI.Server.Models.JSONServer.AuditConstraintRule> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/JSONServer/AuditConstraintRules(LogID={LogID})")]
        public SingleResult<ZarenUI.Server.Models.JSONServer.AuditConstraintRule> GetAuditConstraintRule(long key)
        {
            var items = this.context.AuditConstraintRules.Where(i => i.LogID == key);
            var result = SingleResult.Create(items);

            OnAuditConstraintRuleGet(ref result);

            return result;
        }
        partial void OnAuditConstraintRuleDeleted(ZarenUI.Server.Models.JSONServer.AuditConstraintRule item);
        partial void OnAfterAuditConstraintRuleDeleted(ZarenUI.Server.Models.JSONServer.AuditConstraintRule item);

        [HttpDelete("/odata/JSONServer/AuditConstraintRules(LogID={LogID})")]
        public IActionResult DeleteAuditConstraintRule(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.AuditConstraintRules
                    .Where(i => i.LogID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnAuditConstraintRuleDeleted(item);
                this.context.AuditConstraintRules.Remove(item);
                this.context.SaveChanges();
                this.OnAfterAuditConstraintRuleDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditConstraintRuleUpdated(ZarenUI.Server.Models.JSONServer.AuditConstraintRule item);
        partial void OnAfterAuditConstraintRuleUpdated(ZarenUI.Server.Models.JSONServer.AuditConstraintRule item);

        [HttpPut("/odata/JSONServer/AuditConstraintRules(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutAuditConstraintRule(long key, [FromBody]ZarenUI.Server.Models.JSONServer.AuditConstraintRule item)
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
                this.OnAuditConstraintRuleUpdated(item);
                this.context.AuditConstraintRules.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditConstraintRules.Where(i => i.LogID == key);
                ;
                this.OnAfterAuditConstraintRuleUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/JSONServer/AuditConstraintRules(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchAuditConstraintRule(long key, [FromBody]Delta<ZarenUI.Server.Models.JSONServer.AuditConstraintRule> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.AuditConstraintRules.Where(i => i.LogID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnAuditConstraintRuleUpdated(item);
                this.context.AuditConstraintRules.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditConstraintRules.Where(i => i.LogID == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditConstraintRuleCreated(ZarenUI.Server.Models.JSONServer.AuditConstraintRule item);
        partial void OnAfterAuditConstraintRuleCreated(ZarenUI.Server.Models.JSONServer.AuditConstraintRule item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.JSONServer.AuditConstraintRule item)
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

                this.OnAuditConstraintRuleCreated(item);
                this.context.AuditConstraintRules.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditConstraintRules.Where(i => i.LogID == item.LogID);

                ;

                this.OnAfterAuditConstraintRuleCreated(item);

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
