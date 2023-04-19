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
    [Route("odata/JSONServer/AuditSchemes")]
    public partial class AuditSchemesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public AuditSchemesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.JSONServer.AuditScheme> GetAuditSchemes()
        {
            var items = this.context.AuditSchemes.AsQueryable<ZarenUI.Server.Models.JSONServer.AuditScheme>();
            this.OnAuditSchemesRead(ref items);

            return items;
        }

        partial void OnAuditSchemesRead(ref IQueryable<ZarenUI.Server.Models.JSONServer.AuditScheme> items);

        partial void OnAuditSchemeGet(ref SingleResult<ZarenUI.Server.Models.JSONServer.AuditScheme> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/JSONServer/AuditSchemes(LogID={LogID})")]
        public SingleResult<ZarenUI.Server.Models.JSONServer.AuditScheme> GetAuditScheme(long key)
        {
            var items = this.context.AuditSchemes.Where(i => i.LogID == key);
            var result = SingleResult.Create(items);

            OnAuditSchemeGet(ref result);

            return result;
        }
        partial void OnAuditSchemeDeleted(ZarenUI.Server.Models.JSONServer.AuditScheme item);
        partial void OnAfterAuditSchemeDeleted(ZarenUI.Server.Models.JSONServer.AuditScheme item);

        [HttpDelete("/odata/JSONServer/AuditSchemes(LogID={LogID})")]
        public IActionResult DeleteAuditScheme(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.AuditSchemes
                    .Where(i => i.LogID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnAuditSchemeDeleted(item);
                this.context.AuditSchemes.Remove(item);
                this.context.SaveChanges();
                this.OnAfterAuditSchemeDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditSchemeUpdated(ZarenUI.Server.Models.JSONServer.AuditScheme item);
        partial void OnAfterAuditSchemeUpdated(ZarenUI.Server.Models.JSONServer.AuditScheme item);

        [HttpPut("/odata/JSONServer/AuditSchemes(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutAuditScheme(long key, [FromBody]ZarenUI.Server.Models.JSONServer.AuditScheme item)
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
                this.OnAuditSchemeUpdated(item);
                this.context.AuditSchemes.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditSchemes.Where(i => i.LogID == key);
                ;
                this.OnAfterAuditSchemeUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/JSONServer/AuditSchemes(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchAuditScheme(long key, [FromBody]Delta<ZarenUI.Server.Models.JSONServer.AuditScheme> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.AuditSchemes.Where(i => i.LogID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnAuditSchemeUpdated(item);
                this.context.AuditSchemes.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditSchemes.Where(i => i.LogID == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditSchemeCreated(ZarenUI.Server.Models.JSONServer.AuditScheme item);
        partial void OnAfterAuditSchemeCreated(ZarenUI.Server.Models.JSONServer.AuditScheme item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.JSONServer.AuditScheme item)
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

                this.OnAuditSchemeCreated(item);
                this.context.AuditSchemes.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditSchemes.Where(i => i.LogID == item.LogID);

                ;

                this.OnAfterAuditSchemeCreated(item);

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
