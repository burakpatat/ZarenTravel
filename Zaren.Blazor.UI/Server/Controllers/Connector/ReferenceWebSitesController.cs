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

namespace ZarenUI.Server.Controllers.Connector
{
    [Route("odata/Connector/ReferenceWebSites")]
    public partial class ReferenceWebSitesController : ODataController
    {
        private ZarenUI.Server.Data.ConnectorContext context;

        public ReferenceWebSitesController(ZarenUI.Server.Data.ConnectorContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.Connector.ReferenceWebSite> GetReferenceWebSites()
        {
            var items = this.context.ReferenceWebSites.AsQueryable<ZarenUI.Server.Models.Connector.ReferenceWebSite>();
            this.OnReferenceWebSitesRead(ref items);

            return items;
        }

        partial void OnReferenceWebSitesRead(ref IQueryable<ZarenUI.Server.Models.Connector.ReferenceWebSite> items);

        partial void OnReferenceWebSiteGet(ref SingleResult<ZarenUI.Server.Models.Connector.ReferenceWebSite> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Connector/ReferenceWebSites(Id={Id})")]
        public SingleResult<ZarenUI.Server.Models.Connector.ReferenceWebSite> GetReferenceWebSite(int key)
        {
            var items = this.context.ReferenceWebSites.Where(i => i.Id == key);
            var result = SingleResult.Create(items);

            OnReferenceWebSiteGet(ref result);

            return result;
        }
        partial void OnReferenceWebSiteDeleted(ZarenUI.Server.Models.Connector.ReferenceWebSite item);
        partial void OnAfterReferenceWebSiteDeleted(ZarenUI.Server.Models.Connector.ReferenceWebSite item);

        [HttpDelete("/odata/Connector/ReferenceWebSites(Id={Id})")]
        public IActionResult DeleteReferenceWebSite(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.ReferenceWebSites
                    .Where(i => i.Id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnReferenceWebSiteDeleted(item);
                this.context.ReferenceWebSites.Remove(item);
                this.context.SaveChanges();
                this.OnAfterReferenceWebSiteDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnReferenceWebSiteUpdated(ZarenUI.Server.Models.Connector.ReferenceWebSite item);
        partial void OnAfterReferenceWebSiteUpdated(ZarenUI.Server.Models.Connector.ReferenceWebSite item);

        [HttpPut("/odata/Connector/ReferenceWebSites(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutReferenceWebSite(int key, [FromBody]ZarenUI.Server.Models.Connector.ReferenceWebSite item)
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
                this.OnReferenceWebSiteUpdated(item);
                this.context.ReferenceWebSites.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ReferenceWebSites.Where(i => i.Id == key);
                ;
                this.OnAfterReferenceWebSiteUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Connector/ReferenceWebSites(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchReferenceWebSite(int key, [FromBody]Delta<ZarenUI.Server.Models.Connector.ReferenceWebSite> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.ReferenceWebSites.Where(i => i.Id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnReferenceWebSiteUpdated(item);
                this.context.ReferenceWebSites.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ReferenceWebSites.Where(i => i.Id == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnReferenceWebSiteCreated(ZarenUI.Server.Models.Connector.ReferenceWebSite item);
        partial void OnAfterReferenceWebSiteCreated(ZarenUI.Server.Models.Connector.ReferenceWebSite item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.Connector.ReferenceWebSite item)
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

                this.OnReferenceWebSiteCreated(item);
                this.context.ReferenceWebSites.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ReferenceWebSites.Where(i => i.Id == item.Id);

                ;

                this.OnAfterReferenceWebSiteCreated(item);

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
