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
    [Route("odata/JSONServer/AuditProjectCategories")]
    public partial class AuditProjectCategoriesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public AuditProjectCategoriesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.JSONServer.AuditProjectCategory> GetAuditProjectCategories()
        {
            var items = this.context.AuditProjectCategories.AsQueryable<ZarenUI.Server.Models.JSONServer.AuditProjectCategory>();
            this.OnAuditProjectCategoriesRead(ref items);

            return items;
        }

        partial void OnAuditProjectCategoriesRead(ref IQueryable<ZarenUI.Server.Models.JSONServer.AuditProjectCategory> items);

        partial void OnAuditProjectCategoryGet(ref SingleResult<ZarenUI.Server.Models.JSONServer.AuditProjectCategory> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/JSONServer/AuditProjectCategories(LogID={LogID})")]
        public SingleResult<ZarenUI.Server.Models.JSONServer.AuditProjectCategory> GetAuditProjectCategory(long key)
        {
            var items = this.context.AuditProjectCategories.Where(i => i.LogID == key);
            var result = SingleResult.Create(items);

            OnAuditProjectCategoryGet(ref result);

            return result;
        }
        partial void OnAuditProjectCategoryDeleted(ZarenUI.Server.Models.JSONServer.AuditProjectCategory item);
        partial void OnAfterAuditProjectCategoryDeleted(ZarenUI.Server.Models.JSONServer.AuditProjectCategory item);

        [HttpDelete("/odata/JSONServer/AuditProjectCategories(LogID={LogID})")]
        public IActionResult DeleteAuditProjectCategory(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.AuditProjectCategories
                    .Where(i => i.LogID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnAuditProjectCategoryDeleted(item);
                this.context.AuditProjectCategories.Remove(item);
                this.context.SaveChanges();
                this.OnAfterAuditProjectCategoryDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditProjectCategoryUpdated(ZarenUI.Server.Models.JSONServer.AuditProjectCategory item);
        partial void OnAfterAuditProjectCategoryUpdated(ZarenUI.Server.Models.JSONServer.AuditProjectCategory item);

        [HttpPut("/odata/JSONServer/AuditProjectCategories(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutAuditProjectCategory(long key, [FromBody]ZarenUI.Server.Models.JSONServer.AuditProjectCategory item)
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
                this.OnAuditProjectCategoryUpdated(item);
                this.context.AuditProjectCategories.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProjectCategories.Where(i => i.LogID == key);
                ;
                this.OnAfterAuditProjectCategoryUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/JSONServer/AuditProjectCategories(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchAuditProjectCategory(long key, [FromBody]Delta<ZarenUI.Server.Models.JSONServer.AuditProjectCategory> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.AuditProjectCategories.Where(i => i.LogID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnAuditProjectCategoryUpdated(item);
                this.context.AuditProjectCategories.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProjectCategories.Where(i => i.LogID == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditProjectCategoryCreated(ZarenUI.Server.Models.JSONServer.AuditProjectCategory item);
        partial void OnAfterAuditProjectCategoryCreated(ZarenUI.Server.Models.JSONServer.AuditProjectCategory item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.JSONServer.AuditProjectCategory item)
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

                this.OnAuditProjectCategoryCreated(item);
                this.context.AuditProjectCategories.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProjectCategories.Where(i => i.LogID == item.LogID);

                ;

                this.OnAfterAuditProjectCategoryCreated(item);

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
