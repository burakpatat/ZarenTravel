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
    [Route("odata/JSONServer/ConstraintRules")]
    public partial class ConstraintRulesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ConstraintRulesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.JSONServer.ConstraintRule> GetConstraintRules()
        {
            var items = this.context.ConstraintRules.AsQueryable<ZarenUI.Server.Models.JSONServer.ConstraintRule>();
            this.OnConstraintRulesRead(ref items);

            return items;
        }

        partial void OnConstraintRulesRead(ref IQueryable<ZarenUI.Server.Models.JSONServer.ConstraintRule> items);

        partial void OnConstraintRuleGet(ref SingleResult<ZarenUI.Server.Models.JSONServer.ConstraintRule> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/JSONServer/ConstraintRules(Id={Id})")]
        public SingleResult<ZarenUI.Server.Models.JSONServer.ConstraintRule> GetConstraintRule(long key)
        {
            var items = this.context.ConstraintRules.Where(i => i.Id == key);
            var result = SingleResult.Create(items);

            OnConstraintRuleGet(ref result);

            return result;
        }
        partial void OnConstraintRuleDeleted(ZarenUI.Server.Models.JSONServer.ConstraintRule item);
        partial void OnAfterConstraintRuleDeleted(ZarenUI.Server.Models.JSONServer.ConstraintRule item);

        [HttpDelete("/odata/JSONServer/ConstraintRules(Id={Id})")]
        public IActionResult DeleteConstraintRule(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.ConstraintRules
                    .Where(i => i.Id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnConstraintRuleDeleted(item);
                this.context.ConstraintRules.Remove(item);
                this.context.SaveChanges();
                this.OnAfterConstraintRuleDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnConstraintRuleUpdated(ZarenUI.Server.Models.JSONServer.ConstraintRule item);
        partial void OnAfterConstraintRuleUpdated(ZarenUI.Server.Models.JSONServer.ConstraintRule item);

        [HttpPut("/odata/JSONServer/ConstraintRules(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutConstraintRule(long key, [FromBody]ZarenUI.Server.Models.JSONServer.ConstraintRule item)
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
                this.OnConstraintRuleUpdated(item);
                this.context.ConstraintRules.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ConstraintRules.Where(i => i.Id == key);
                ;
                this.OnAfterConstraintRuleUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/JSONServer/ConstraintRules(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchConstraintRule(long key, [FromBody]Delta<ZarenUI.Server.Models.JSONServer.ConstraintRule> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.ConstraintRules.Where(i => i.Id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnConstraintRuleUpdated(item);
                this.context.ConstraintRules.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ConstraintRules.Where(i => i.Id == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnConstraintRuleCreated(ZarenUI.Server.Models.JSONServer.ConstraintRule item);
        partial void OnAfterConstraintRuleCreated(ZarenUI.Server.Models.JSONServer.ConstraintRule item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.JSONServer.ConstraintRule item)
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

                this.OnConstraintRuleCreated(item);
                this.context.ConstraintRules.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ConstraintRules.Where(i => i.Id == item.Id);

                ;

                this.OnAfterConstraintRuleCreated(item);

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
