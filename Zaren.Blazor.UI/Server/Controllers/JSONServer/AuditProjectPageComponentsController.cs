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
    [Route("odata/JSONServer/AuditProjectPageComponents")]
    public partial class AuditProjectPageComponentsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public AuditProjectPageComponentsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.JSONServer.AuditProjectPageComponent> GetAuditProjectPageComponents()
        {
            var items = this.context.AuditProjectPageComponents.AsQueryable<ZarenUI.Server.Models.JSONServer.AuditProjectPageComponent>();
            this.OnAuditProjectPageComponentsRead(ref items);

            return items;
        }

        partial void OnAuditProjectPageComponentsRead(ref IQueryable<ZarenUI.Server.Models.JSONServer.AuditProjectPageComponent> items);

        partial void OnAuditProjectPageComponentGet(ref SingleResult<ZarenUI.Server.Models.JSONServer.AuditProjectPageComponent> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/JSONServer/AuditProjectPageComponents(LogID={LogID})")]
        public SingleResult<ZarenUI.Server.Models.JSONServer.AuditProjectPageComponent> GetAuditProjectPageComponent(long key)
        {
            var items = this.context.AuditProjectPageComponents.Where(i => i.LogID == key);
            var result = SingleResult.Create(items);

            OnAuditProjectPageComponentGet(ref result);

            return result;
        }
        partial void OnAuditProjectPageComponentDeleted(ZarenUI.Server.Models.JSONServer.AuditProjectPageComponent item);
        partial void OnAfterAuditProjectPageComponentDeleted(ZarenUI.Server.Models.JSONServer.AuditProjectPageComponent item);

        [HttpDelete("/odata/JSONServer/AuditProjectPageComponents(LogID={LogID})")]
        public IActionResult DeleteAuditProjectPageComponent(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.AuditProjectPageComponents
                    .Where(i => i.LogID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnAuditProjectPageComponentDeleted(item);
                this.context.AuditProjectPageComponents.Remove(item);
                this.context.SaveChanges();
                this.OnAfterAuditProjectPageComponentDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditProjectPageComponentUpdated(ZarenUI.Server.Models.JSONServer.AuditProjectPageComponent item);
        partial void OnAfterAuditProjectPageComponentUpdated(ZarenUI.Server.Models.JSONServer.AuditProjectPageComponent item);

        [HttpPut("/odata/JSONServer/AuditProjectPageComponents(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutAuditProjectPageComponent(long key, [FromBody]ZarenUI.Server.Models.JSONServer.AuditProjectPageComponent item)
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
                this.OnAuditProjectPageComponentUpdated(item);
                this.context.AuditProjectPageComponents.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProjectPageComponents.Where(i => i.LogID == key);
                ;
                this.OnAfterAuditProjectPageComponentUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/JSONServer/AuditProjectPageComponents(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchAuditProjectPageComponent(long key, [FromBody]Delta<ZarenUI.Server.Models.JSONServer.AuditProjectPageComponent> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.AuditProjectPageComponents.Where(i => i.LogID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnAuditProjectPageComponentUpdated(item);
                this.context.AuditProjectPageComponents.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProjectPageComponents.Where(i => i.LogID == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditProjectPageComponentCreated(ZarenUI.Server.Models.JSONServer.AuditProjectPageComponent item);
        partial void OnAfterAuditProjectPageComponentCreated(ZarenUI.Server.Models.JSONServer.AuditProjectPageComponent item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.JSONServer.AuditProjectPageComponent item)
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

                this.OnAuditProjectPageComponentCreated(item);
                this.context.AuditProjectPageComponents.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProjectPageComponents.Where(i => i.LogID == item.LogID);

                ;

                this.OnAfterAuditProjectPageComponentCreated(item);

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
