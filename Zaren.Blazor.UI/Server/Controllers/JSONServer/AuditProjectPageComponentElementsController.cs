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
    [Route("odata/JSONServer/AuditProjectPageComponentElements")]
    public partial class AuditProjectPageComponentElementsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public AuditProjectPageComponentElementsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.JSONServer.AuditProjectPageComponentElement> GetAuditProjectPageComponentElements()
        {
            var items = this.context.AuditProjectPageComponentElements.AsQueryable<ZarenUI.Server.Models.JSONServer.AuditProjectPageComponentElement>();
            this.OnAuditProjectPageComponentElementsRead(ref items);

            return items;
        }

        partial void OnAuditProjectPageComponentElementsRead(ref IQueryable<ZarenUI.Server.Models.JSONServer.AuditProjectPageComponentElement> items);

        partial void OnAuditProjectPageComponentElementGet(ref SingleResult<ZarenUI.Server.Models.JSONServer.AuditProjectPageComponentElement> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/JSONServer/AuditProjectPageComponentElements(LogID={LogID})")]
        public SingleResult<ZarenUI.Server.Models.JSONServer.AuditProjectPageComponentElement> GetAuditProjectPageComponentElement(long key)
        {
            var items = this.context.AuditProjectPageComponentElements.Where(i => i.LogID == key);
            var result = SingleResult.Create(items);

            OnAuditProjectPageComponentElementGet(ref result);

            return result;
        }
        partial void OnAuditProjectPageComponentElementDeleted(ZarenUI.Server.Models.JSONServer.AuditProjectPageComponentElement item);
        partial void OnAfterAuditProjectPageComponentElementDeleted(ZarenUI.Server.Models.JSONServer.AuditProjectPageComponentElement item);

        [HttpDelete("/odata/JSONServer/AuditProjectPageComponentElements(LogID={LogID})")]
        public IActionResult DeleteAuditProjectPageComponentElement(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.AuditProjectPageComponentElements
                    .Where(i => i.LogID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnAuditProjectPageComponentElementDeleted(item);
                this.context.AuditProjectPageComponentElements.Remove(item);
                this.context.SaveChanges();
                this.OnAfterAuditProjectPageComponentElementDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditProjectPageComponentElementUpdated(ZarenUI.Server.Models.JSONServer.AuditProjectPageComponentElement item);
        partial void OnAfterAuditProjectPageComponentElementUpdated(ZarenUI.Server.Models.JSONServer.AuditProjectPageComponentElement item);

        [HttpPut("/odata/JSONServer/AuditProjectPageComponentElements(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutAuditProjectPageComponentElement(long key, [FromBody]ZarenUI.Server.Models.JSONServer.AuditProjectPageComponentElement item)
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
                this.OnAuditProjectPageComponentElementUpdated(item);
                this.context.AuditProjectPageComponentElements.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProjectPageComponentElements.Where(i => i.LogID == key);
                ;
                this.OnAfterAuditProjectPageComponentElementUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/JSONServer/AuditProjectPageComponentElements(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchAuditProjectPageComponentElement(long key, [FromBody]Delta<ZarenUI.Server.Models.JSONServer.AuditProjectPageComponentElement> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.AuditProjectPageComponentElements.Where(i => i.LogID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnAuditProjectPageComponentElementUpdated(item);
                this.context.AuditProjectPageComponentElements.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProjectPageComponentElements.Where(i => i.LogID == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditProjectPageComponentElementCreated(ZarenUI.Server.Models.JSONServer.AuditProjectPageComponentElement item);
        partial void OnAfterAuditProjectPageComponentElementCreated(ZarenUI.Server.Models.JSONServer.AuditProjectPageComponentElement item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.JSONServer.AuditProjectPageComponentElement item)
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

                this.OnAuditProjectPageComponentElementCreated(item);
                this.context.AuditProjectPageComponentElements.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProjectPageComponentElements.Where(i => i.LogID == item.LogID);

                ;

                this.OnAfterAuditProjectPageComponentElementCreated(item);

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
