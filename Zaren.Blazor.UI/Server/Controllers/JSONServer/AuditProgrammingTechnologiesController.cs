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
    [Route("odata/JSONServer/AuditProgrammingTechnologies")]
    public partial class AuditProgrammingTechnologiesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public AuditProgrammingTechnologiesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.JSONServer.AuditProgrammingTechnology> GetAuditProgrammingTechnologies()
        {
            var items = this.context.AuditProgrammingTechnologies.AsQueryable<ZarenUI.Server.Models.JSONServer.AuditProgrammingTechnology>();
            this.OnAuditProgrammingTechnologiesRead(ref items);

            return items;
        }

        partial void OnAuditProgrammingTechnologiesRead(ref IQueryable<ZarenUI.Server.Models.JSONServer.AuditProgrammingTechnology> items);

        partial void OnAuditProgrammingTechnologyGet(ref SingleResult<ZarenUI.Server.Models.JSONServer.AuditProgrammingTechnology> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/JSONServer/AuditProgrammingTechnologies(LogID={LogID})")]
        public SingleResult<ZarenUI.Server.Models.JSONServer.AuditProgrammingTechnology> GetAuditProgrammingTechnology(long key)
        {
            var items = this.context.AuditProgrammingTechnologies.Where(i => i.LogID == key);
            var result = SingleResult.Create(items);

            OnAuditProgrammingTechnologyGet(ref result);

            return result;
        }
        partial void OnAuditProgrammingTechnologyDeleted(ZarenUI.Server.Models.JSONServer.AuditProgrammingTechnology item);
        partial void OnAfterAuditProgrammingTechnologyDeleted(ZarenUI.Server.Models.JSONServer.AuditProgrammingTechnology item);

        [HttpDelete("/odata/JSONServer/AuditProgrammingTechnologies(LogID={LogID})")]
        public IActionResult DeleteAuditProgrammingTechnology(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.AuditProgrammingTechnologies
                    .Where(i => i.LogID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnAuditProgrammingTechnologyDeleted(item);
                this.context.AuditProgrammingTechnologies.Remove(item);
                this.context.SaveChanges();
                this.OnAfterAuditProgrammingTechnologyDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditProgrammingTechnologyUpdated(ZarenUI.Server.Models.JSONServer.AuditProgrammingTechnology item);
        partial void OnAfterAuditProgrammingTechnologyUpdated(ZarenUI.Server.Models.JSONServer.AuditProgrammingTechnology item);

        [HttpPut("/odata/JSONServer/AuditProgrammingTechnologies(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutAuditProgrammingTechnology(long key, [FromBody]ZarenUI.Server.Models.JSONServer.AuditProgrammingTechnology item)
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
                this.OnAuditProgrammingTechnologyUpdated(item);
                this.context.AuditProgrammingTechnologies.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProgrammingTechnologies.Where(i => i.LogID == key);
                ;
                this.OnAfterAuditProgrammingTechnologyUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/JSONServer/AuditProgrammingTechnologies(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchAuditProgrammingTechnology(long key, [FromBody]Delta<ZarenUI.Server.Models.JSONServer.AuditProgrammingTechnology> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.AuditProgrammingTechnologies.Where(i => i.LogID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnAuditProgrammingTechnologyUpdated(item);
                this.context.AuditProgrammingTechnologies.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProgrammingTechnologies.Where(i => i.LogID == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditProgrammingTechnologyCreated(ZarenUI.Server.Models.JSONServer.AuditProgrammingTechnology item);
        partial void OnAfterAuditProgrammingTechnologyCreated(ZarenUI.Server.Models.JSONServer.AuditProgrammingTechnology item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.JSONServer.AuditProgrammingTechnology item)
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

                this.OnAuditProgrammingTechnologyCreated(item);
                this.context.AuditProgrammingTechnologies.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProgrammingTechnologies.Where(i => i.LogID == item.LogID);

                ;

                this.OnAfterAuditProgrammingTechnologyCreated(item);

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
