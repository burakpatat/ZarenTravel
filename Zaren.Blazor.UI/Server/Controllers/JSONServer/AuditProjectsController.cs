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
    [Route("odata/JSONServer/AuditProjects")]
    public partial class AuditProjectsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public AuditProjectsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.JSONServer.AuditProject> GetAuditProjects()
        {
            var items = this.context.AuditProjects.AsQueryable<ZarenUI.Server.Models.JSONServer.AuditProject>();
            this.OnAuditProjectsRead(ref items);

            return items;
        }

        partial void OnAuditProjectsRead(ref IQueryable<ZarenUI.Server.Models.JSONServer.AuditProject> items);

        partial void OnAuditProjectGet(ref SingleResult<ZarenUI.Server.Models.JSONServer.AuditProject> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/JSONServer/AuditProjects(LogID={LogID})")]
        public SingleResult<ZarenUI.Server.Models.JSONServer.AuditProject> GetAuditProject(long key)
        {
            var items = this.context.AuditProjects.Where(i => i.LogID == key);
            var result = SingleResult.Create(items);

            OnAuditProjectGet(ref result);

            return result;
        }
        partial void OnAuditProjectDeleted(ZarenUI.Server.Models.JSONServer.AuditProject item);
        partial void OnAfterAuditProjectDeleted(ZarenUI.Server.Models.JSONServer.AuditProject item);

        [HttpDelete("/odata/JSONServer/AuditProjects(LogID={LogID})")]
        public IActionResult DeleteAuditProject(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.AuditProjects
                    .Where(i => i.LogID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnAuditProjectDeleted(item);
                this.context.AuditProjects.Remove(item);
                this.context.SaveChanges();
                this.OnAfterAuditProjectDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditProjectUpdated(ZarenUI.Server.Models.JSONServer.AuditProject item);
        partial void OnAfterAuditProjectUpdated(ZarenUI.Server.Models.JSONServer.AuditProject item);

        [HttpPut("/odata/JSONServer/AuditProjects(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutAuditProject(long key, [FromBody]ZarenUI.Server.Models.JSONServer.AuditProject item)
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
                this.OnAuditProjectUpdated(item);
                this.context.AuditProjects.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProjects.Where(i => i.LogID == key);
                ;
                this.OnAfterAuditProjectUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/JSONServer/AuditProjects(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchAuditProject(long key, [FromBody]Delta<ZarenUI.Server.Models.JSONServer.AuditProject> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.AuditProjects.Where(i => i.LogID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnAuditProjectUpdated(item);
                this.context.AuditProjects.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProjects.Where(i => i.LogID == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditProjectCreated(ZarenUI.Server.Models.JSONServer.AuditProject item);
        partial void OnAfterAuditProjectCreated(ZarenUI.Server.Models.JSONServer.AuditProject item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.JSONServer.AuditProject item)
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

                this.OnAuditProjectCreated(item);
                this.context.AuditProjects.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProjects.Where(i => i.LogID == item.LogID);

                ;

                this.OnAfterAuditProjectCreated(item);

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
