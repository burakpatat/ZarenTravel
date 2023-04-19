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
    [Route("odata/JSONServer/AuditProgrammingCategories")]
    public partial class AuditProgrammingCategoriesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public AuditProgrammingCategoriesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.JSONServer.AuditProgrammingCategory> GetAuditProgrammingCategories()
        {
            var items = this.context.AuditProgrammingCategories.AsQueryable<ZarenUI.Server.Models.JSONServer.AuditProgrammingCategory>();
            this.OnAuditProgrammingCategoriesRead(ref items);

            return items;
        }

        partial void OnAuditProgrammingCategoriesRead(ref IQueryable<ZarenUI.Server.Models.JSONServer.AuditProgrammingCategory> items);

        partial void OnAuditProgrammingCategoryGet(ref SingleResult<ZarenUI.Server.Models.JSONServer.AuditProgrammingCategory> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/JSONServer/AuditProgrammingCategories(LogID={LogID})")]
        public SingleResult<ZarenUI.Server.Models.JSONServer.AuditProgrammingCategory> GetAuditProgrammingCategory(long key)
        {
            var items = this.context.AuditProgrammingCategories.Where(i => i.LogID == key);
            var result = SingleResult.Create(items);

            OnAuditProgrammingCategoryGet(ref result);

            return result;
        }
        partial void OnAuditProgrammingCategoryDeleted(ZarenUI.Server.Models.JSONServer.AuditProgrammingCategory item);
        partial void OnAfterAuditProgrammingCategoryDeleted(ZarenUI.Server.Models.JSONServer.AuditProgrammingCategory item);

        [HttpDelete("/odata/JSONServer/AuditProgrammingCategories(LogID={LogID})")]
        public IActionResult DeleteAuditProgrammingCategory(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.AuditProgrammingCategories
                    .Where(i => i.LogID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnAuditProgrammingCategoryDeleted(item);
                this.context.AuditProgrammingCategories.Remove(item);
                this.context.SaveChanges();
                this.OnAfterAuditProgrammingCategoryDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditProgrammingCategoryUpdated(ZarenUI.Server.Models.JSONServer.AuditProgrammingCategory item);
        partial void OnAfterAuditProgrammingCategoryUpdated(ZarenUI.Server.Models.JSONServer.AuditProgrammingCategory item);

        [HttpPut("/odata/JSONServer/AuditProgrammingCategories(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutAuditProgrammingCategory(long key, [FromBody]ZarenUI.Server.Models.JSONServer.AuditProgrammingCategory item)
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
                this.OnAuditProgrammingCategoryUpdated(item);
                this.context.AuditProgrammingCategories.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProgrammingCategories.Where(i => i.LogID == key);
                ;
                this.OnAfterAuditProgrammingCategoryUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/JSONServer/AuditProgrammingCategories(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchAuditProgrammingCategory(long key, [FromBody]Delta<ZarenUI.Server.Models.JSONServer.AuditProgrammingCategory> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.AuditProgrammingCategories.Where(i => i.LogID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnAuditProgrammingCategoryUpdated(item);
                this.context.AuditProgrammingCategories.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProgrammingCategories.Where(i => i.LogID == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditProgrammingCategoryCreated(ZarenUI.Server.Models.JSONServer.AuditProgrammingCategory item);
        partial void OnAfterAuditProgrammingCategoryCreated(ZarenUI.Server.Models.JSONServer.AuditProgrammingCategory item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.JSONServer.AuditProgrammingCategory item)
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

                this.OnAuditProgrammingCategoryCreated(item);
                this.context.AuditProgrammingCategories.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProgrammingCategories.Where(i => i.LogID == item.LogID);

                ;

                this.OnAfterAuditProgrammingCategoryCreated(item);

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
