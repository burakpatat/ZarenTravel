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
    [Route("odata/JSONServer/AuditReferenceWebSites")]
    public partial class AuditReferenceWebSitesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public AuditReferenceWebSitesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.JSONServer.AuditReferenceWebSite> GetAuditReferenceWebSites()
        {
            var items = this.context.AuditReferenceWebSites.AsQueryable<ZarenUI.Server.Models.JSONServer.AuditReferenceWebSite>();
            this.OnAuditReferenceWebSitesRead(ref items);

            return items;
        }

        partial void OnAuditReferenceWebSitesRead(ref IQueryable<ZarenUI.Server.Models.JSONServer.AuditReferenceWebSite> items);

        partial void OnAuditReferenceWebSiteGet(ref SingleResult<ZarenUI.Server.Models.JSONServer.AuditReferenceWebSite> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/JSONServer/AuditReferenceWebSites(LogID={LogID})")]
        public SingleResult<ZarenUI.Server.Models.JSONServer.AuditReferenceWebSite> GetAuditReferenceWebSite(long key)
        {
            var items = this.context.AuditReferenceWebSites.Where(i => i.LogID == key);
            var result = SingleResult.Create(items);

            OnAuditReferenceWebSiteGet(ref result);

            return result;
        }
        partial void OnAuditReferenceWebSiteDeleted(ZarenUI.Server.Models.JSONServer.AuditReferenceWebSite item);
        partial void OnAfterAuditReferenceWebSiteDeleted(ZarenUI.Server.Models.JSONServer.AuditReferenceWebSite item);

        [HttpDelete("/odata/JSONServer/AuditReferenceWebSites(LogID={LogID})")]
        public IActionResult DeleteAuditReferenceWebSite(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.AuditReferenceWebSites
                    .Where(i => i.LogID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnAuditReferenceWebSiteDeleted(item);
                this.context.AuditReferenceWebSites.Remove(item);
                this.context.SaveChanges();
                this.OnAfterAuditReferenceWebSiteDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditReferenceWebSiteUpdated(ZarenUI.Server.Models.JSONServer.AuditReferenceWebSite item);
        partial void OnAfterAuditReferenceWebSiteUpdated(ZarenUI.Server.Models.JSONServer.AuditReferenceWebSite item);

        [HttpPut("/odata/JSONServer/AuditReferenceWebSites(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutAuditReferenceWebSite(long key, [FromBody]ZarenUI.Server.Models.JSONServer.AuditReferenceWebSite item)
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
                this.OnAuditReferenceWebSiteUpdated(item);
                this.context.AuditReferenceWebSites.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditReferenceWebSites.Where(i => i.LogID == key);
                ;
                this.OnAfterAuditReferenceWebSiteUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/JSONServer/AuditReferenceWebSites(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchAuditReferenceWebSite(long key, [FromBody]Delta<ZarenUI.Server.Models.JSONServer.AuditReferenceWebSite> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.AuditReferenceWebSites.Where(i => i.LogID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnAuditReferenceWebSiteUpdated(item);
                this.context.AuditReferenceWebSites.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditReferenceWebSites.Where(i => i.LogID == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditReferenceWebSiteCreated(ZarenUI.Server.Models.JSONServer.AuditReferenceWebSite item);
        partial void OnAfterAuditReferenceWebSiteCreated(ZarenUI.Server.Models.JSONServer.AuditReferenceWebSite item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.JSONServer.AuditReferenceWebSite item)
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

                this.OnAuditReferenceWebSiteCreated(item);
                this.context.AuditReferenceWebSites.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditReferenceWebSites.Where(i => i.LogID == item.LogID);

                ;

                this.OnAfterAuditReferenceWebSiteCreated(item);

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
