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
    [Route("odata/JSONServer/AuditProjectTableColumns")]
    public partial class AuditProjectTableColumnsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public AuditProjectTableColumnsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.JSONServer.AuditProjectTableColumn> GetAuditProjectTableColumns()
        {
            var items = this.context.AuditProjectTableColumns.AsQueryable<ZarenUI.Server.Models.JSONServer.AuditProjectTableColumn>();
            this.OnAuditProjectTableColumnsRead(ref items);

            return items;
        }

        partial void OnAuditProjectTableColumnsRead(ref IQueryable<ZarenUI.Server.Models.JSONServer.AuditProjectTableColumn> items);

        partial void OnAuditProjectTableColumnGet(ref SingleResult<ZarenUI.Server.Models.JSONServer.AuditProjectTableColumn> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/JSONServer/AuditProjectTableColumns(LogID={LogID})")]
        public SingleResult<ZarenUI.Server.Models.JSONServer.AuditProjectTableColumn> GetAuditProjectTableColumn(long key)
        {
            var items = this.context.AuditProjectTableColumns.Where(i => i.LogID == key);
            var result = SingleResult.Create(items);

            OnAuditProjectTableColumnGet(ref result);

            return result;
        }
        partial void OnAuditProjectTableColumnDeleted(ZarenUI.Server.Models.JSONServer.AuditProjectTableColumn item);
        partial void OnAfterAuditProjectTableColumnDeleted(ZarenUI.Server.Models.JSONServer.AuditProjectTableColumn item);

        [HttpDelete("/odata/JSONServer/AuditProjectTableColumns(LogID={LogID})")]
        public IActionResult DeleteAuditProjectTableColumn(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.AuditProjectTableColumns
                    .Where(i => i.LogID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnAuditProjectTableColumnDeleted(item);
                this.context.AuditProjectTableColumns.Remove(item);
                this.context.SaveChanges();
                this.OnAfterAuditProjectTableColumnDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditProjectTableColumnUpdated(ZarenUI.Server.Models.JSONServer.AuditProjectTableColumn item);
        partial void OnAfterAuditProjectTableColumnUpdated(ZarenUI.Server.Models.JSONServer.AuditProjectTableColumn item);

        [HttpPut("/odata/JSONServer/AuditProjectTableColumns(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutAuditProjectTableColumn(long key, [FromBody]ZarenUI.Server.Models.JSONServer.AuditProjectTableColumn item)
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
                this.OnAuditProjectTableColumnUpdated(item);
                this.context.AuditProjectTableColumns.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProjectTableColumns.Where(i => i.LogID == key);
                ;
                this.OnAfterAuditProjectTableColumnUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/JSONServer/AuditProjectTableColumns(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchAuditProjectTableColumn(long key, [FromBody]Delta<ZarenUI.Server.Models.JSONServer.AuditProjectTableColumn> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.AuditProjectTableColumns.Where(i => i.LogID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnAuditProjectTableColumnUpdated(item);
                this.context.AuditProjectTableColumns.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProjectTableColumns.Where(i => i.LogID == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditProjectTableColumnCreated(ZarenUI.Server.Models.JSONServer.AuditProjectTableColumn item);
        partial void OnAfterAuditProjectTableColumnCreated(ZarenUI.Server.Models.JSONServer.AuditProjectTableColumn item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.JSONServer.AuditProjectTableColumn item)
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

                this.OnAuditProjectTableColumnCreated(item);
                this.context.AuditProjectTableColumns.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProjectTableColumns.Where(i => i.LogID == item.LogID);

                ;

                this.OnAfterAuditProjectTableColumnCreated(item);

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
