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
    [Route("odata/JSONServer/AuditProgrammingCodeTemplates")]
    public partial class AuditProgrammingCodeTemplatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public AuditProgrammingCodeTemplatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.JSONServer.AuditProgrammingCodeTemplate> GetAuditProgrammingCodeTemplates()
        {
            var items = this.context.AuditProgrammingCodeTemplates.AsQueryable<ZarenUI.Server.Models.JSONServer.AuditProgrammingCodeTemplate>();
            this.OnAuditProgrammingCodeTemplatesRead(ref items);

            return items;
        }

        partial void OnAuditProgrammingCodeTemplatesRead(ref IQueryable<ZarenUI.Server.Models.JSONServer.AuditProgrammingCodeTemplate> items);

        partial void OnAuditProgrammingCodeTemplateGet(ref SingleResult<ZarenUI.Server.Models.JSONServer.AuditProgrammingCodeTemplate> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/JSONServer/AuditProgrammingCodeTemplates(LogID={LogID})")]
        public SingleResult<ZarenUI.Server.Models.JSONServer.AuditProgrammingCodeTemplate> GetAuditProgrammingCodeTemplate(long key)
        {
            var items = this.context.AuditProgrammingCodeTemplates.Where(i => i.LogID == key);
            var result = SingleResult.Create(items);

            OnAuditProgrammingCodeTemplateGet(ref result);

            return result;
        }
        partial void OnAuditProgrammingCodeTemplateDeleted(ZarenUI.Server.Models.JSONServer.AuditProgrammingCodeTemplate item);
        partial void OnAfterAuditProgrammingCodeTemplateDeleted(ZarenUI.Server.Models.JSONServer.AuditProgrammingCodeTemplate item);

        [HttpDelete("/odata/JSONServer/AuditProgrammingCodeTemplates(LogID={LogID})")]
        public IActionResult DeleteAuditProgrammingCodeTemplate(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.AuditProgrammingCodeTemplates
                    .Where(i => i.LogID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnAuditProgrammingCodeTemplateDeleted(item);
                this.context.AuditProgrammingCodeTemplates.Remove(item);
                this.context.SaveChanges();
                this.OnAfterAuditProgrammingCodeTemplateDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditProgrammingCodeTemplateUpdated(ZarenUI.Server.Models.JSONServer.AuditProgrammingCodeTemplate item);
        partial void OnAfterAuditProgrammingCodeTemplateUpdated(ZarenUI.Server.Models.JSONServer.AuditProgrammingCodeTemplate item);

        [HttpPut("/odata/JSONServer/AuditProgrammingCodeTemplates(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutAuditProgrammingCodeTemplate(long key, [FromBody]ZarenUI.Server.Models.JSONServer.AuditProgrammingCodeTemplate item)
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
                this.OnAuditProgrammingCodeTemplateUpdated(item);
                this.context.AuditProgrammingCodeTemplates.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProgrammingCodeTemplates.Where(i => i.LogID == key);
                ;
                this.OnAfterAuditProgrammingCodeTemplateUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/JSONServer/AuditProgrammingCodeTemplates(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchAuditProgrammingCodeTemplate(long key, [FromBody]Delta<ZarenUI.Server.Models.JSONServer.AuditProgrammingCodeTemplate> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.AuditProgrammingCodeTemplates.Where(i => i.LogID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnAuditProgrammingCodeTemplateUpdated(item);
                this.context.AuditProgrammingCodeTemplates.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProgrammingCodeTemplates.Where(i => i.LogID == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditProgrammingCodeTemplateCreated(ZarenUI.Server.Models.JSONServer.AuditProgrammingCodeTemplate item);
        partial void OnAfterAuditProgrammingCodeTemplateCreated(ZarenUI.Server.Models.JSONServer.AuditProgrammingCodeTemplate item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.JSONServer.AuditProgrammingCodeTemplate item)
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

                this.OnAuditProgrammingCodeTemplateCreated(item);
                this.context.AuditProgrammingCodeTemplates.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProgrammingCodeTemplates.Where(i => i.LogID == item.LogID);

                ;

                this.OnAfterAuditProgrammingCodeTemplateCreated(item);

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
