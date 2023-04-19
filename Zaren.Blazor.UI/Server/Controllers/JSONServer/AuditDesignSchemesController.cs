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
    [Route("odata/JSONServer/AuditDesignSchemes")]
    public partial class AuditDesignSchemesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public AuditDesignSchemesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.JSONServer.AuditDesignScheme> GetAuditDesignSchemes()
        {
            var items = this.context.AuditDesignSchemes.AsQueryable<ZarenUI.Server.Models.JSONServer.AuditDesignScheme>();
            this.OnAuditDesignSchemesRead(ref items);

            return items;
        }

        partial void OnAuditDesignSchemesRead(ref IQueryable<ZarenUI.Server.Models.JSONServer.AuditDesignScheme> items);

        partial void OnAuditDesignSchemeGet(ref SingleResult<ZarenUI.Server.Models.JSONServer.AuditDesignScheme> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/JSONServer/AuditDesignSchemes(LogID={LogID})")]
        public SingleResult<ZarenUI.Server.Models.JSONServer.AuditDesignScheme> GetAuditDesignScheme(long key)
        {
            var items = this.context.AuditDesignSchemes.Where(i => i.LogID == key);
            var result = SingleResult.Create(items);

            OnAuditDesignSchemeGet(ref result);

            return result;
        }
        partial void OnAuditDesignSchemeDeleted(ZarenUI.Server.Models.JSONServer.AuditDesignScheme item);
        partial void OnAfterAuditDesignSchemeDeleted(ZarenUI.Server.Models.JSONServer.AuditDesignScheme item);

        [HttpDelete("/odata/JSONServer/AuditDesignSchemes(LogID={LogID})")]
        public IActionResult DeleteAuditDesignScheme(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.AuditDesignSchemes
                    .Where(i => i.LogID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnAuditDesignSchemeDeleted(item);
                this.context.AuditDesignSchemes.Remove(item);
                this.context.SaveChanges();
                this.OnAfterAuditDesignSchemeDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditDesignSchemeUpdated(ZarenUI.Server.Models.JSONServer.AuditDesignScheme item);
        partial void OnAfterAuditDesignSchemeUpdated(ZarenUI.Server.Models.JSONServer.AuditDesignScheme item);

        [HttpPut("/odata/JSONServer/AuditDesignSchemes(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutAuditDesignScheme(long key, [FromBody]ZarenUI.Server.Models.JSONServer.AuditDesignScheme item)
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
                this.OnAuditDesignSchemeUpdated(item);
                this.context.AuditDesignSchemes.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditDesignSchemes.Where(i => i.LogID == key);
                ;
                this.OnAfterAuditDesignSchemeUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/JSONServer/AuditDesignSchemes(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchAuditDesignScheme(long key, [FromBody]Delta<ZarenUI.Server.Models.JSONServer.AuditDesignScheme> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.AuditDesignSchemes.Where(i => i.LogID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnAuditDesignSchemeUpdated(item);
                this.context.AuditDesignSchemes.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditDesignSchemes.Where(i => i.LogID == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditDesignSchemeCreated(ZarenUI.Server.Models.JSONServer.AuditDesignScheme item);
        partial void OnAfterAuditDesignSchemeCreated(ZarenUI.Server.Models.JSONServer.AuditDesignScheme item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.JSONServer.AuditDesignScheme item)
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

                this.OnAuditDesignSchemeCreated(item);
                this.context.AuditDesignSchemes.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditDesignSchemes.Where(i => i.LogID == item.LogID);

                ;

                this.OnAfterAuditDesignSchemeCreated(item);

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
