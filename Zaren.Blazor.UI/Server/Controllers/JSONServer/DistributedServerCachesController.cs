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
    [Route("odata/JSONServer/DistributedServerCaches")]
    public partial class DistributedServerCachesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DistributedServerCachesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.JSONServer.DistributedServerCache> GetDistributedServerCaches()
        {
            var items = this.context.DistributedServerCaches.AsQueryable<ZarenUI.Server.Models.JSONServer.DistributedServerCache>();
            this.OnDistributedServerCachesRead(ref items);

            return items;
        }

        partial void OnDistributedServerCachesRead(ref IQueryable<ZarenUI.Server.Models.JSONServer.DistributedServerCache> items);

        partial void OnDistributedServerCacheGet(ref SingleResult<ZarenUI.Server.Models.JSONServer.DistributedServerCache> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/JSONServer/DistributedServerCaches(Id={Id})")]
        public SingleResult<ZarenUI.Server.Models.JSONServer.DistributedServerCache> GetDistributedServerCache(string key)
        {
            var items = this.context.DistributedServerCaches.Where(i => i.Id == Uri.UnescapeDataString(key));
            var result = SingleResult.Create(items);

            OnDistributedServerCacheGet(ref result);

            return result;
        }
        partial void OnDistributedServerCacheDeleted(ZarenUI.Server.Models.JSONServer.DistributedServerCache item);
        partial void OnAfterDistributedServerCacheDeleted(ZarenUI.Server.Models.JSONServer.DistributedServerCache item);

        [HttpDelete("/odata/JSONServer/DistributedServerCaches(Id={Id})")]
        public IActionResult DeleteDistributedServerCache(string key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.DistributedServerCaches
                    .Where(i => i.Id == Uri.UnescapeDataString(key))
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnDistributedServerCacheDeleted(item);
                this.context.DistributedServerCaches.Remove(item);
                this.context.SaveChanges();
                this.OnAfterDistributedServerCacheDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnDistributedServerCacheUpdated(ZarenUI.Server.Models.JSONServer.DistributedServerCache item);
        partial void OnAfterDistributedServerCacheUpdated(ZarenUI.Server.Models.JSONServer.DistributedServerCache item);

        [HttpPut("/odata/JSONServer/DistributedServerCaches(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutDistributedServerCache(string key, [FromBody]ZarenUI.Server.Models.JSONServer.DistributedServerCache item)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (item == null || (item.Id != Uri.UnescapeDataString(key)))
                {
                    return BadRequest();
                }
                this.OnDistributedServerCacheUpdated(item);
                this.context.DistributedServerCaches.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.DistributedServerCaches.Where(i => i.Id == Uri.UnescapeDataString(key));
                ;
                this.OnAfterDistributedServerCacheUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/JSONServer/DistributedServerCaches(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchDistributedServerCache(string key, [FromBody]Delta<ZarenUI.Server.Models.JSONServer.DistributedServerCache> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.DistributedServerCaches.Where(i => i.Id == Uri.UnescapeDataString(key)).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnDistributedServerCacheUpdated(item);
                this.context.DistributedServerCaches.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.DistributedServerCaches.Where(i => i.Id == Uri.UnescapeDataString(key));
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnDistributedServerCacheCreated(ZarenUI.Server.Models.JSONServer.DistributedServerCache item);
        partial void OnAfterDistributedServerCacheCreated(ZarenUI.Server.Models.JSONServer.DistributedServerCache item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.JSONServer.DistributedServerCache item)
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

                this.OnDistributedServerCacheCreated(item);
                this.context.DistributedServerCaches.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.DistributedServerCaches.Where(i => i.Id == item.Id);

                ;

                this.OnAfterDistributedServerCacheCreated(item);

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
