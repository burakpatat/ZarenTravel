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
    [Route("odata/Connector/ProjectPages")]
    public partial class ProjectPagesController : ODataController
    {
        private ZarenUI.Server.Data.ConnectorContext context;

        public ProjectPagesController(ZarenUI.Server.Data.ConnectorContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.Connector.ProjectPage> GetProjectPages()
        {
            var items = this.context.ProjectPages.AsQueryable<ZarenUI.Server.Models.Connector.ProjectPage>();
            this.OnProjectPagesRead(ref items);

            return items;
        }

        partial void OnProjectPagesRead(ref IQueryable<ZarenUI.Server.Models.Connector.ProjectPage> items);

        partial void OnProjectPageGet(ref SingleResult<ZarenUI.Server.Models.Connector.ProjectPage> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Connector/ProjectPages(Id={Id})")]
        public SingleResult<ZarenUI.Server.Models.Connector.ProjectPage> GetProjectPage(int key)
        {
            var items = this.context.ProjectPages.Where(i => i.Id == key);
            var result = SingleResult.Create(items);

            OnProjectPageGet(ref result);

            return result;
        }
        partial void OnProjectPageDeleted(ZarenUI.Server.Models.Connector.ProjectPage item);
        partial void OnAfterProjectPageDeleted(ZarenUI.Server.Models.Connector.ProjectPage item);

        [HttpDelete("/odata/Connector/ProjectPages(Id={Id})")]
        public IActionResult DeleteProjectPage(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.ProjectPages
                    .Where(i => i.Id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnProjectPageDeleted(item);
                this.context.ProjectPages.Remove(item);
                this.context.SaveChanges();
                this.OnAfterProjectPageDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnProjectPageUpdated(ZarenUI.Server.Models.Connector.ProjectPage item);
        partial void OnAfterProjectPageUpdated(ZarenUI.Server.Models.Connector.ProjectPage item);

        [HttpPut("/odata/Connector/ProjectPages(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutProjectPage(int key, [FromBody]ZarenUI.Server.Models.Connector.ProjectPage item)
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
                this.OnProjectPageUpdated(item);
                this.context.ProjectPages.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProjectPages.Where(i => i.Id == key);
                ;
                this.OnAfterProjectPageUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Connector/ProjectPages(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchProjectPage(int key, [FromBody]Delta<ZarenUI.Server.Models.Connector.ProjectPage> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.ProjectPages.Where(i => i.Id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnProjectPageUpdated(item);
                this.context.ProjectPages.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProjectPages.Where(i => i.Id == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnProjectPageCreated(ZarenUI.Server.Models.Connector.ProjectPage item);
        partial void OnAfterProjectPageCreated(ZarenUI.Server.Models.Connector.ProjectPage item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.Connector.ProjectPage item)
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

                this.OnProjectPageCreated(item);
                this.context.ProjectPages.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProjectPages.Where(i => i.Id == item.Id);

                ;

                this.OnAfterProjectPageCreated(item);

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
