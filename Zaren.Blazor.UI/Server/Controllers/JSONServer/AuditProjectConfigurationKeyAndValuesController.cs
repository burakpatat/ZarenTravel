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
    [Route("odata/JSONServer/AuditProjectConfigurationKeyAndValues")]
    public partial class AuditProjectConfigurationKeyAndValuesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public AuditProjectConfigurationKeyAndValuesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.JSONServer.AuditProjectConfigurationKeyAndValue> GetAuditProjectConfigurationKeyAndValues()
        {
            var items = this.context.AuditProjectConfigurationKeyAndValues.AsQueryable<ZarenUI.Server.Models.JSONServer.AuditProjectConfigurationKeyAndValue>();
            this.OnAuditProjectConfigurationKeyAndValuesRead(ref items);

            return items;
        }

        partial void OnAuditProjectConfigurationKeyAndValuesRead(ref IQueryable<ZarenUI.Server.Models.JSONServer.AuditProjectConfigurationKeyAndValue> items);

        partial void OnAuditProjectConfigurationKeyAndValueGet(ref SingleResult<ZarenUI.Server.Models.JSONServer.AuditProjectConfigurationKeyAndValue> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/JSONServer/AuditProjectConfigurationKeyAndValues(LogID={LogID})")]
        public SingleResult<ZarenUI.Server.Models.JSONServer.AuditProjectConfigurationKeyAndValue> GetAuditProjectConfigurationKeyAndValue(long key)
        {
            var items = this.context.AuditProjectConfigurationKeyAndValues.Where(i => i.LogID == key);
            var result = SingleResult.Create(items);

            OnAuditProjectConfigurationKeyAndValueGet(ref result);

            return result;
        }
        partial void OnAuditProjectConfigurationKeyAndValueDeleted(ZarenUI.Server.Models.JSONServer.AuditProjectConfigurationKeyAndValue item);
        partial void OnAfterAuditProjectConfigurationKeyAndValueDeleted(ZarenUI.Server.Models.JSONServer.AuditProjectConfigurationKeyAndValue item);

        [HttpDelete("/odata/JSONServer/AuditProjectConfigurationKeyAndValues(LogID={LogID})")]
        public IActionResult DeleteAuditProjectConfigurationKeyAndValue(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.AuditProjectConfigurationKeyAndValues
                    .Where(i => i.LogID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnAuditProjectConfigurationKeyAndValueDeleted(item);
                this.context.AuditProjectConfigurationKeyAndValues.Remove(item);
                this.context.SaveChanges();
                this.OnAfterAuditProjectConfigurationKeyAndValueDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditProjectConfigurationKeyAndValueUpdated(ZarenUI.Server.Models.JSONServer.AuditProjectConfigurationKeyAndValue item);
        partial void OnAfterAuditProjectConfigurationKeyAndValueUpdated(ZarenUI.Server.Models.JSONServer.AuditProjectConfigurationKeyAndValue item);

        [HttpPut("/odata/JSONServer/AuditProjectConfigurationKeyAndValues(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutAuditProjectConfigurationKeyAndValue(long key, [FromBody]ZarenUI.Server.Models.JSONServer.AuditProjectConfigurationKeyAndValue item)
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
                this.OnAuditProjectConfigurationKeyAndValueUpdated(item);
                this.context.AuditProjectConfigurationKeyAndValues.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProjectConfigurationKeyAndValues.Where(i => i.LogID == key);
                ;
                this.OnAfterAuditProjectConfigurationKeyAndValueUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/JSONServer/AuditProjectConfigurationKeyAndValues(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchAuditProjectConfigurationKeyAndValue(long key, [FromBody]Delta<ZarenUI.Server.Models.JSONServer.AuditProjectConfigurationKeyAndValue> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.AuditProjectConfigurationKeyAndValues.Where(i => i.LogID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnAuditProjectConfigurationKeyAndValueUpdated(item);
                this.context.AuditProjectConfigurationKeyAndValues.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProjectConfigurationKeyAndValues.Where(i => i.LogID == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditProjectConfigurationKeyAndValueCreated(ZarenUI.Server.Models.JSONServer.AuditProjectConfigurationKeyAndValue item);
        partial void OnAfterAuditProjectConfigurationKeyAndValueCreated(ZarenUI.Server.Models.JSONServer.AuditProjectConfigurationKeyAndValue item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.JSONServer.AuditProjectConfigurationKeyAndValue item)
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

                this.OnAuditProjectConfigurationKeyAndValueCreated(item);
                this.context.AuditProjectConfigurationKeyAndValues.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProjectConfigurationKeyAndValues.Where(i => i.LogID == item.LogID);

                ;

                this.OnAfterAuditProjectConfigurationKeyAndValueCreated(item);

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
