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
    [Route("odata/Connector/ProjectCategories")]
    public partial class ProjectCategoriesController : ODataController
    {
        private ZarenUI.Server.Data.ConnectorContext context;

        public ProjectCategoriesController(ZarenUI.Server.Data.ConnectorContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.Connector.ProjectCategory> GetProjectCategories()
        {
            var items = this.context.ProjectCategories.AsQueryable<ZarenUI.Server.Models.Connector.ProjectCategory>();
            this.OnProjectCategoriesRead(ref items);

            return items;
        }

        partial void OnProjectCategoriesRead(ref IQueryable<ZarenUI.Server.Models.Connector.ProjectCategory> items);

        partial void OnProjectCategoryGet(ref SingleResult<ZarenUI.Server.Models.Connector.ProjectCategory> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Connector/ProjectCategories(Id={Id})")]
        public SingleResult<ZarenUI.Server.Models.Connector.ProjectCategory> GetProjectCategory(int key)
        {
            var items = this.context.ProjectCategories.Where(i => i.Id == key);
            var result = SingleResult.Create(items);

            OnProjectCategoryGet(ref result);

            return result;
        }
        partial void OnProjectCategoryDeleted(ZarenUI.Server.Models.Connector.ProjectCategory item);
        partial void OnAfterProjectCategoryDeleted(ZarenUI.Server.Models.Connector.ProjectCategory item);

        [HttpDelete("/odata/Connector/ProjectCategories(Id={Id})")]
        public IActionResult DeleteProjectCategory(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.ProjectCategories
                    .Where(i => i.Id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnProjectCategoryDeleted(item);
                this.context.ProjectCategories.Remove(item);
                this.context.SaveChanges();
                this.OnAfterProjectCategoryDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnProjectCategoryUpdated(ZarenUI.Server.Models.Connector.ProjectCategory item);
        partial void OnAfterProjectCategoryUpdated(ZarenUI.Server.Models.Connector.ProjectCategory item);

        [HttpPut("/odata/Connector/ProjectCategories(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutProjectCategory(int key, [FromBody]ZarenUI.Server.Models.Connector.ProjectCategory item)
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
                this.OnProjectCategoryUpdated(item);
                this.context.ProjectCategories.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProjectCategories.Where(i => i.Id == key);
                ;
                this.OnAfterProjectCategoryUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Connector/ProjectCategories(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchProjectCategory(int key, [FromBody]Delta<ZarenUI.Server.Models.Connector.ProjectCategory> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.ProjectCategories.Where(i => i.Id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnProjectCategoryUpdated(item);
                this.context.ProjectCategories.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProjectCategories.Where(i => i.Id == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnProjectCategoryCreated(ZarenUI.Server.Models.Connector.ProjectCategory item);
        partial void OnAfterProjectCategoryCreated(ZarenUI.Server.Models.Connector.ProjectCategory item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.Connector.ProjectCategory item)
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

                this.OnProjectCategoryCreated(item);
                this.context.ProjectCategories.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProjectCategories.Where(i => i.Id == item.Id);

                ;

                this.OnAfterProjectCategoryCreated(item);

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
