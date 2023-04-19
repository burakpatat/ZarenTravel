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
    [Route("odata/JSONServer/AuditFields")]
    public partial class AuditFieldsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public AuditFieldsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.JSONServer.AuditField> GetAuditFields()
        {
            var items = this.context.AuditFields.AsQueryable<ZarenUI.Server.Models.JSONServer.AuditField>();
            this.OnAuditFieldsRead(ref items);

            return items;
        }

        partial void OnAuditFieldsRead(ref IQueryable<ZarenUI.Server.Models.JSONServer.AuditField> items);

        partial void OnAuditFieldGet(ref SingleResult<ZarenUI.Server.Models.JSONServer.AuditField> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/JSONServer/AuditFields(LogID={LogID})")]
        public SingleResult<ZarenUI.Server.Models.JSONServer.AuditField> GetAuditField(long key)
        {
            var items = this.context.AuditFields.Where(i => i.LogID == key);
            var result = SingleResult.Create(items);

            OnAuditFieldGet(ref result);

            return result;
        }
        partial void OnAuditFieldDeleted(ZarenUI.Server.Models.JSONServer.AuditField item);
        partial void OnAfterAuditFieldDeleted(ZarenUI.Server.Models.JSONServer.AuditField item);

        [HttpDelete("/odata/JSONServer/AuditFields(LogID={LogID})")]
        public IActionResult DeleteAuditField(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.AuditFields
                    .Where(i => i.LogID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnAuditFieldDeleted(item);
                this.context.AuditFields.Remove(item);
                this.context.SaveChanges();
                this.OnAfterAuditFieldDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditFieldUpdated(ZarenUI.Server.Models.JSONServer.AuditField item);
        partial void OnAfterAuditFieldUpdated(ZarenUI.Server.Models.JSONServer.AuditField item);

        [HttpPut("/odata/JSONServer/AuditFields(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutAuditField(long key, [FromBody]ZarenUI.Server.Models.JSONServer.AuditField item)
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
                this.OnAuditFieldUpdated(item);
                this.context.AuditFields.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditFields.Where(i => i.LogID == key);
                ;
                this.OnAfterAuditFieldUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/JSONServer/AuditFields(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchAuditField(long key, [FromBody]Delta<ZarenUI.Server.Models.JSONServer.AuditField> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.AuditFields.Where(i => i.LogID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnAuditFieldUpdated(item);
                this.context.AuditFields.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditFields.Where(i => i.LogID == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditFieldCreated(ZarenUI.Server.Models.JSONServer.AuditField item);
        partial void OnAfterAuditFieldCreated(ZarenUI.Server.Models.JSONServer.AuditField item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.JSONServer.AuditField item)
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

                this.OnAuditFieldCreated(item);
                this.context.AuditFields.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditFields.Where(i => i.LogID == item.LogID);

                ;

                this.OnAfterAuditFieldCreated(item);

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
