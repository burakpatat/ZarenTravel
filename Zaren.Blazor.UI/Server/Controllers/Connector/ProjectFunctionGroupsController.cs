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
    [Route("odata/Connector/ProjectFunctionGroups")]
    public partial class ProjectFunctionGroupsController : ODataController
    {
        private ZarenUI.Server.Data.ConnectorContext context;

        public ProjectFunctionGroupsController(ZarenUI.Server.Data.ConnectorContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.Connector.ProjectFunctionGroup> GetProjectFunctionGroups()
        {
            var items = this.context.ProjectFunctionGroups.AsQueryable<ZarenUI.Server.Models.Connector.ProjectFunctionGroup>();
            this.OnProjectFunctionGroupsRead(ref items);

            return items;
        }

        partial void OnProjectFunctionGroupsRead(ref IQueryable<ZarenUI.Server.Models.Connector.ProjectFunctionGroup> items);

        partial void OnProjectFunctionGroupGet(ref SingleResult<ZarenUI.Server.Models.Connector.ProjectFunctionGroup> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Connector/ProjectFunctionGroups(Id={Id})")]
        public SingleResult<ZarenUI.Server.Models.Connector.ProjectFunctionGroup> GetProjectFunctionGroup(int key)
        {
            var items = this.context.ProjectFunctionGroups.Where(i => i.Id == key);
            var result = SingleResult.Create(items);

            OnProjectFunctionGroupGet(ref result);

            return result;
        }
        partial void OnProjectFunctionGroupDeleted(ZarenUI.Server.Models.Connector.ProjectFunctionGroup item);
        partial void OnAfterProjectFunctionGroupDeleted(ZarenUI.Server.Models.Connector.ProjectFunctionGroup item);

        [HttpDelete("/odata/Connector/ProjectFunctionGroups(Id={Id})")]
        public IActionResult DeleteProjectFunctionGroup(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.ProjectFunctionGroups
                    .Where(i => i.Id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnProjectFunctionGroupDeleted(item);
                this.context.ProjectFunctionGroups.Remove(item);
                this.context.SaveChanges();
                this.OnAfterProjectFunctionGroupDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnProjectFunctionGroupUpdated(ZarenUI.Server.Models.Connector.ProjectFunctionGroup item);
        partial void OnAfterProjectFunctionGroupUpdated(ZarenUI.Server.Models.Connector.ProjectFunctionGroup item);

        [HttpPut("/odata/Connector/ProjectFunctionGroups(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutProjectFunctionGroup(int key, [FromBody]ZarenUI.Server.Models.Connector.ProjectFunctionGroup item)
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
                this.OnProjectFunctionGroupUpdated(item);
                this.context.ProjectFunctionGroups.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProjectFunctionGroups.Where(i => i.Id == key);
                ;
                this.OnAfterProjectFunctionGroupUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Connector/ProjectFunctionGroups(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchProjectFunctionGroup(int key, [FromBody]Delta<ZarenUI.Server.Models.Connector.ProjectFunctionGroup> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.ProjectFunctionGroups.Where(i => i.Id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnProjectFunctionGroupUpdated(item);
                this.context.ProjectFunctionGroups.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProjectFunctionGroups.Where(i => i.Id == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnProjectFunctionGroupCreated(ZarenUI.Server.Models.Connector.ProjectFunctionGroup item);
        partial void OnAfterProjectFunctionGroupCreated(ZarenUI.Server.Models.Connector.ProjectFunctionGroup item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.Connector.ProjectFunctionGroup item)
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

                this.OnProjectFunctionGroupCreated(item);
                this.context.ProjectFunctionGroups.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProjectFunctionGroups.Where(i => i.Id == item.Id);

                ;

                this.OnAfterProjectFunctionGroupCreated(item);

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
