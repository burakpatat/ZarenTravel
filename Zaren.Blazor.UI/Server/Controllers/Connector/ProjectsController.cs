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
    [Route("odata/Connector/Projects")]
    public partial class ProjectsController : ODataController
    {
        private ZarenUI.Server.Data.ConnectorContext context;

        public ProjectsController(ZarenUI.Server.Data.ConnectorContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.Connector.Project> GetProjects()
        {
            var items = this.context.Projects.AsQueryable<ZarenUI.Server.Models.Connector.Project>();
            this.OnProjectsRead(ref items);

            return items;
        }

        partial void OnProjectsRead(ref IQueryable<ZarenUI.Server.Models.Connector.Project> items);

        partial void OnProjectGet(ref SingleResult<ZarenUI.Server.Models.Connector.Project> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Connector/Projects(Id={Id})")]
        public SingleResult<ZarenUI.Server.Models.Connector.Project> GetProject(int key)
        {
            var items = this.context.Projects.Where(i => i.Id == key);
            var result = SingleResult.Create(items);

            OnProjectGet(ref result);

            return result;
        }
        partial void OnProjectDeleted(ZarenUI.Server.Models.Connector.Project item);
        partial void OnAfterProjectDeleted(ZarenUI.Server.Models.Connector.Project item);

        [HttpDelete("/odata/Connector/Projects(Id={Id})")]
        public IActionResult DeleteProject(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.Projects
                    .Where(i => i.Id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnProjectDeleted(item);
                this.context.Projects.Remove(item);
                this.context.SaveChanges();
                this.OnAfterProjectDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnProjectUpdated(ZarenUI.Server.Models.Connector.Project item);
        partial void OnAfterProjectUpdated(ZarenUI.Server.Models.Connector.Project item);

        [HttpPut("/odata/Connector/Projects(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutProject(int key, [FromBody]ZarenUI.Server.Models.Connector.Project item)
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
                this.OnProjectUpdated(item);
                this.context.Projects.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Projects.Where(i => i.Id == key);
                ;
                this.OnAfterProjectUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Connector/Projects(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchProject(int key, [FromBody]Delta<ZarenUI.Server.Models.Connector.Project> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.Projects.Where(i => i.Id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnProjectUpdated(item);
                this.context.Projects.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Projects.Where(i => i.Id == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnProjectCreated(ZarenUI.Server.Models.Connector.Project item);
        partial void OnAfterProjectCreated(ZarenUI.Server.Models.Connector.Project item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.Connector.Project item)
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

                this.OnProjectCreated(item);
                this.context.Projects.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Projects.Where(i => i.Id == item.Id);

                ;

                this.OnAfterProjectCreated(item);

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
