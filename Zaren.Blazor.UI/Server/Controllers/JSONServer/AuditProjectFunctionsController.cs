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
    [Route("odata/JSONServer/AuditProjectFunctions")]
    public partial class AuditProjectFunctionsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public AuditProjectFunctionsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.JSONServer.AuditProjectFunction> GetAuditProjectFunctions()
        {
            var items = this.context.AuditProjectFunctions.AsQueryable<ZarenUI.Server.Models.JSONServer.AuditProjectFunction>();
            this.OnAuditProjectFunctionsRead(ref items);

            return items;
        }

        partial void OnAuditProjectFunctionsRead(ref IQueryable<ZarenUI.Server.Models.JSONServer.AuditProjectFunction> items);

        partial void OnAuditProjectFunctionGet(ref SingleResult<ZarenUI.Server.Models.JSONServer.AuditProjectFunction> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/JSONServer/AuditProjectFunctions(LogID={LogID})")]
        public SingleResult<ZarenUI.Server.Models.JSONServer.AuditProjectFunction> GetAuditProjectFunction(long key)
        {
            var items = this.context.AuditProjectFunctions.Where(i => i.LogID == key);
            var result = SingleResult.Create(items);

            OnAuditProjectFunctionGet(ref result);

            return result;
        }
        partial void OnAuditProjectFunctionDeleted(ZarenUI.Server.Models.JSONServer.AuditProjectFunction item);
        partial void OnAfterAuditProjectFunctionDeleted(ZarenUI.Server.Models.JSONServer.AuditProjectFunction item);

        [HttpDelete("/odata/JSONServer/AuditProjectFunctions(LogID={LogID})")]
        public IActionResult DeleteAuditProjectFunction(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.AuditProjectFunctions
                    .Where(i => i.LogID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnAuditProjectFunctionDeleted(item);
                this.context.AuditProjectFunctions.Remove(item);
                this.context.SaveChanges();
                this.OnAfterAuditProjectFunctionDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditProjectFunctionUpdated(ZarenUI.Server.Models.JSONServer.AuditProjectFunction item);
        partial void OnAfterAuditProjectFunctionUpdated(ZarenUI.Server.Models.JSONServer.AuditProjectFunction item);

        [HttpPut("/odata/JSONServer/AuditProjectFunctions(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutAuditProjectFunction(long key, [FromBody]ZarenUI.Server.Models.JSONServer.AuditProjectFunction item)
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
                this.OnAuditProjectFunctionUpdated(item);
                this.context.AuditProjectFunctions.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProjectFunctions.Where(i => i.LogID == key);
                ;
                this.OnAfterAuditProjectFunctionUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/JSONServer/AuditProjectFunctions(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchAuditProjectFunction(long key, [FromBody]Delta<ZarenUI.Server.Models.JSONServer.AuditProjectFunction> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.AuditProjectFunctions.Where(i => i.LogID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnAuditProjectFunctionUpdated(item);
                this.context.AuditProjectFunctions.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProjectFunctions.Where(i => i.LogID == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditProjectFunctionCreated(ZarenUI.Server.Models.JSONServer.AuditProjectFunction item);
        partial void OnAfterAuditProjectFunctionCreated(ZarenUI.Server.Models.JSONServer.AuditProjectFunction item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.JSONServer.AuditProjectFunction item)
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

                this.OnAuditProjectFunctionCreated(item);
                this.context.AuditProjectFunctions.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProjectFunctions.Where(i => i.LogID == item.LogID);

                ;

                this.OnAfterAuditProjectFunctionCreated(item);

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
