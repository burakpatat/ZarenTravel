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
    [Route("odata/JSONServer/ProjectPageComponents")]
    public partial class ProjectPageComponentsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.JSONServer.ProjectPageComponent> GetProjectPageComponents()
        {
            var items = this.context.ProjectPageComponents.AsQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponent>();
            this.OnProjectPageComponentsRead(ref items);

            return items;
        }

        partial void OnProjectPageComponentsRead(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponent> items);

        partial void OnProjectPageComponentGet(ref SingleResult<ZarenUI.Server.Models.JSONServer.ProjectPageComponent> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/JSONServer/ProjectPageComponents(Id={Id})")]
        public SingleResult<ZarenUI.Server.Models.JSONServer.ProjectPageComponent> GetProjectPageComponent(int key)
        {
            var items = this.context.ProjectPageComponents.Where(i => i.Id == key);
            var result = SingleResult.Create(items);

            OnProjectPageComponentGet(ref result);

            return result;
        }
        partial void OnProjectPageComponentDeleted(ZarenUI.Server.Models.JSONServer.ProjectPageComponent item);
        partial void OnAfterProjectPageComponentDeleted(ZarenUI.Server.Models.JSONServer.ProjectPageComponent item);

        [HttpDelete("/odata/JSONServer/ProjectPageComponents(Id={Id})")]
        public IActionResult DeleteProjectPageComponent(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.ProjectPageComponents
                    .Where(i => i.Id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnProjectPageComponentDeleted(item);
                this.context.ProjectPageComponents.Remove(item);
                this.context.SaveChanges();
                this.OnAfterProjectPageComponentDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnProjectPageComponentUpdated(ZarenUI.Server.Models.JSONServer.ProjectPageComponent item);
        partial void OnAfterProjectPageComponentUpdated(ZarenUI.Server.Models.JSONServer.ProjectPageComponent item);

        [HttpPut("/odata/JSONServer/ProjectPageComponents(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutProjectPageComponent(int key, [FromBody]ZarenUI.Server.Models.JSONServer.ProjectPageComponent item)
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
                this.OnProjectPageComponentUpdated(item);
                this.context.ProjectPageComponents.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProjectPageComponents.Where(i => i.Id == key);
                ;
                this.OnAfterProjectPageComponentUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/JSONServer/ProjectPageComponents(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchProjectPageComponent(int key, [FromBody]Delta<ZarenUI.Server.Models.JSONServer.ProjectPageComponent> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.ProjectPageComponents.Where(i => i.Id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnProjectPageComponentUpdated(item);
                this.context.ProjectPageComponents.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProjectPageComponents.Where(i => i.Id == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnProjectPageComponentCreated(ZarenUI.Server.Models.JSONServer.ProjectPageComponent item);
        partial void OnAfterProjectPageComponentCreated(ZarenUI.Server.Models.JSONServer.ProjectPageComponent item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.JSONServer.ProjectPageComponent item)
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

                this.OnProjectPageComponentCreated(item);
                this.context.ProjectPageComponents.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProjectPageComponents.Where(i => i.Id == item.Id);

                ;

                this.OnAfterProjectPageComponentCreated(item);

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
