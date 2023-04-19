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
    [Route("odata/JSONServer/AuditProgrammingCodes")]
    public partial class AuditProgrammingCodesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public AuditProgrammingCodesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.JSONServer.AuditProgrammingCode> GetAuditProgrammingCodes()
        {
            var items = this.context.AuditProgrammingCodes.AsQueryable<ZarenUI.Server.Models.JSONServer.AuditProgrammingCode>();
            this.OnAuditProgrammingCodesRead(ref items);

            return items;
        }

        partial void OnAuditProgrammingCodesRead(ref IQueryable<ZarenUI.Server.Models.JSONServer.AuditProgrammingCode> items);

        partial void OnAuditProgrammingCodeGet(ref SingleResult<ZarenUI.Server.Models.JSONServer.AuditProgrammingCode> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/JSONServer/AuditProgrammingCodes(LogID={LogID})")]
        public SingleResult<ZarenUI.Server.Models.JSONServer.AuditProgrammingCode> GetAuditProgrammingCode(long key)
        {
            var items = this.context.AuditProgrammingCodes.Where(i => i.LogID == key);
            var result = SingleResult.Create(items);

            OnAuditProgrammingCodeGet(ref result);

            return result;
        }
        partial void OnAuditProgrammingCodeDeleted(ZarenUI.Server.Models.JSONServer.AuditProgrammingCode item);
        partial void OnAfterAuditProgrammingCodeDeleted(ZarenUI.Server.Models.JSONServer.AuditProgrammingCode item);

        [HttpDelete("/odata/JSONServer/AuditProgrammingCodes(LogID={LogID})")]
        public IActionResult DeleteAuditProgrammingCode(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.AuditProgrammingCodes
                    .Where(i => i.LogID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnAuditProgrammingCodeDeleted(item);
                this.context.AuditProgrammingCodes.Remove(item);
                this.context.SaveChanges();
                this.OnAfterAuditProgrammingCodeDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditProgrammingCodeUpdated(ZarenUI.Server.Models.JSONServer.AuditProgrammingCode item);
        partial void OnAfterAuditProgrammingCodeUpdated(ZarenUI.Server.Models.JSONServer.AuditProgrammingCode item);

        [HttpPut("/odata/JSONServer/AuditProgrammingCodes(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutAuditProgrammingCode(long key, [FromBody]ZarenUI.Server.Models.JSONServer.AuditProgrammingCode item)
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
                this.OnAuditProgrammingCodeUpdated(item);
                this.context.AuditProgrammingCodes.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProgrammingCodes.Where(i => i.LogID == key);
                ;
                this.OnAfterAuditProgrammingCodeUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/JSONServer/AuditProgrammingCodes(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchAuditProgrammingCode(long key, [FromBody]Delta<ZarenUI.Server.Models.JSONServer.AuditProgrammingCode> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.AuditProgrammingCodes.Where(i => i.LogID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnAuditProgrammingCodeUpdated(item);
                this.context.AuditProgrammingCodes.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProgrammingCodes.Where(i => i.LogID == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditProgrammingCodeCreated(ZarenUI.Server.Models.JSONServer.AuditProgrammingCode item);
        partial void OnAfterAuditProgrammingCodeCreated(ZarenUI.Server.Models.JSONServer.AuditProgrammingCode item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.JSONServer.AuditProgrammingCode item)
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

                this.OnAuditProgrammingCodeCreated(item);
                this.context.AuditProgrammingCodes.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProgrammingCodes.Where(i => i.LogID == item.LogID);

                ;

                this.OnAfterAuditProgrammingCodeCreated(item);

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
