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
    [Route("odata/JSONServer/AuditProjectPages")]
    public partial class AuditProjectPagesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public AuditProjectPagesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.JSONServer.AuditProjectPage> GetAuditProjectPages()
        {
            var items = this.context.AuditProjectPages.AsQueryable<ZarenUI.Server.Models.JSONServer.AuditProjectPage>();
            this.OnAuditProjectPagesRead(ref items);

            return items;
        }

        partial void OnAuditProjectPagesRead(ref IQueryable<ZarenUI.Server.Models.JSONServer.AuditProjectPage> items);

        partial void OnAuditProjectPageGet(ref SingleResult<ZarenUI.Server.Models.JSONServer.AuditProjectPage> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/JSONServer/AuditProjectPages(LogID={LogID})")]
        public SingleResult<ZarenUI.Server.Models.JSONServer.AuditProjectPage> GetAuditProjectPage(long key)
        {
            var items = this.context.AuditProjectPages.Where(i => i.LogID == key);
            var result = SingleResult.Create(items);

            OnAuditProjectPageGet(ref result);

            return result;
        }
        partial void OnAuditProjectPageDeleted(ZarenUI.Server.Models.JSONServer.AuditProjectPage item);
        partial void OnAfterAuditProjectPageDeleted(ZarenUI.Server.Models.JSONServer.AuditProjectPage item);

        [HttpDelete("/odata/JSONServer/AuditProjectPages(LogID={LogID})")]
        public IActionResult DeleteAuditProjectPage(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.AuditProjectPages
                    .Where(i => i.LogID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnAuditProjectPageDeleted(item);
                this.context.AuditProjectPages.Remove(item);
                this.context.SaveChanges();
                this.OnAfterAuditProjectPageDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditProjectPageUpdated(ZarenUI.Server.Models.JSONServer.AuditProjectPage item);
        partial void OnAfterAuditProjectPageUpdated(ZarenUI.Server.Models.JSONServer.AuditProjectPage item);

        [HttpPut("/odata/JSONServer/AuditProjectPages(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutAuditProjectPage(long key, [FromBody]ZarenUI.Server.Models.JSONServer.AuditProjectPage item)
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
                this.OnAuditProjectPageUpdated(item);
                this.context.AuditProjectPages.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProjectPages.Where(i => i.LogID == key);
                ;
                this.OnAfterAuditProjectPageUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/JSONServer/AuditProjectPages(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchAuditProjectPage(long key, [FromBody]Delta<ZarenUI.Server.Models.JSONServer.AuditProjectPage> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.AuditProjectPages.Where(i => i.LogID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnAuditProjectPageUpdated(item);
                this.context.AuditProjectPages.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProjectPages.Where(i => i.LogID == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditProjectPageCreated(ZarenUI.Server.Models.JSONServer.AuditProjectPage item);
        partial void OnAfterAuditProjectPageCreated(ZarenUI.Server.Models.JSONServer.AuditProjectPage item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.JSONServer.AuditProjectPage item)
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

                this.OnAuditProjectPageCreated(item);
                this.context.AuditProjectPages.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProjectPages.Where(i => i.LogID == item.LogID);

                ;

                this.OnAfterAuditProjectPageCreated(item);

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
