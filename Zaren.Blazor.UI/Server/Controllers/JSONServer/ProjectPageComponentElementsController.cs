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
    [Route("odata/JSONServer/ProjectPageComponentElements")]
    public partial class ProjectPageComponentElementsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElement> GetProjectPageComponentElements()
        {
            var items = this.context.ProjectPageComponentElements.AsQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElement>();
            this.OnProjectPageComponentElementsRead(ref items);

            return items;
        }

        partial void OnProjectPageComponentElementsRead(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElement> items);

        partial void OnProjectPageComponentElementGet(ref SingleResult<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElement> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/JSONServer/ProjectPageComponentElements(Id={Id})")]
        public SingleResult<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElement> GetProjectPageComponentElement(int key)
        {
            var items = this.context.ProjectPageComponentElements.Where(i => i.Id == key);
            var result = SingleResult.Create(items);

            OnProjectPageComponentElementGet(ref result);

            return result;
        }
        partial void OnProjectPageComponentElementDeleted(ZarenUI.Server.Models.JSONServer.ProjectPageComponentElement item);
        partial void OnAfterProjectPageComponentElementDeleted(ZarenUI.Server.Models.JSONServer.ProjectPageComponentElement item);

        [HttpDelete("/odata/JSONServer/ProjectPageComponentElements(Id={Id})")]
        public IActionResult DeleteProjectPageComponentElement(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.ProjectPageComponentElements
                    .Where(i => i.Id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnProjectPageComponentElementDeleted(item);
                this.context.ProjectPageComponentElements.Remove(item);
                this.context.SaveChanges();
                this.OnAfterProjectPageComponentElementDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnProjectPageComponentElementUpdated(ZarenUI.Server.Models.JSONServer.ProjectPageComponentElement item);
        partial void OnAfterProjectPageComponentElementUpdated(ZarenUI.Server.Models.JSONServer.ProjectPageComponentElement item);

        [HttpPut("/odata/JSONServer/ProjectPageComponentElements(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutProjectPageComponentElement(int key, [FromBody]ZarenUI.Server.Models.JSONServer.ProjectPageComponentElement item)
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
                this.OnProjectPageComponentElementUpdated(item);
                this.context.ProjectPageComponentElements.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProjectPageComponentElements.Where(i => i.Id == key);
                ;
                this.OnAfterProjectPageComponentElementUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/JSONServer/ProjectPageComponentElements(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchProjectPageComponentElement(int key, [FromBody]Delta<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElement> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.ProjectPageComponentElements.Where(i => i.Id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnProjectPageComponentElementUpdated(item);
                this.context.ProjectPageComponentElements.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProjectPageComponentElements.Where(i => i.Id == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnProjectPageComponentElementCreated(ZarenUI.Server.Models.JSONServer.ProjectPageComponentElement item);
        partial void OnAfterProjectPageComponentElementCreated(ZarenUI.Server.Models.JSONServer.ProjectPageComponentElement item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.JSONServer.ProjectPageComponentElement item)
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

                this.OnProjectPageComponentElementCreated(item);
                this.context.ProjectPageComponentElements.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProjectPageComponentElements.Where(i => i.Id == item.Id);

                ;

                this.OnAfterProjectPageComponentElementCreated(item);

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
