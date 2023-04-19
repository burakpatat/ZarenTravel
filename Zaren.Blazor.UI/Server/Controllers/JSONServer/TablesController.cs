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
    [Route("odata/JSONServer/Tables")]
    public partial class TablesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public TablesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.JSONServer.Table> GetTables()
        {
            var items = this.context.Tables.AsQueryable<ZarenUI.Server.Models.JSONServer.Table>();
            this.OnTablesRead(ref items);

            return items;
        }

        partial void OnTablesRead(ref IQueryable<ZarenUI.Server.Models.JSONServer.Table> items);

        partial void OnTableGet(ref SingleResult<ZarenUI.Server.Models.JSONServer.Table> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/JSONServer/Tables(Id={Id})")]
        public SingleResult<ZarenUI.Server.Models.JSONServer.Table> GetTable(long key)
        {
            var items = this.context.Tables.Where(i => i.Id == key);
            var result = SingleResult.Create(items);

            OnTableGet(ref result);

            return result;
        }
        partial void OnTableDeleted(ZarenUI.Server.Models.JSONServer.Table item);
        partial void OnAfterTableDeleted(ZarenUI.Server.Models.JSONServer.Table item);

        [HttpDelete("/odata/JSONServer/Tables(Id={Id})")]
        public IActionResult DeleteTable(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.Tables
                    .Where(i => i.Id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTableDeleted(item);
                this.context.Tables.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTableDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTableUpdated(ZarenUI.Server.Models.JSONServer.Table item);
        partial void OnAfterTableUpdated(ZarenUI.Server.Models.JSONServer.Table item);

        [HttpPut("/odata/JSONServer/Tables(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTable(long key, [FromBody]ZarenUI.Server.Models.JSONServer.Table item)
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
                this.OnTableUpdated(item);
                this.context.Tables.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Tables.Where(i => i.Id == key);
                ;
                this.OnAfterTableUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/JSONServer/Tables(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTable(long key, [FromBody]Delta<ZarenUI.Server.Models.JSONServer.Table> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.Tables.Where(i => i.Id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTableUpdated(item);
                this.context.Tables.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Tables.Where(i => i.Id == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTableCreated(ZarenUI.Server.Models.JSONServer.Table item);
        partial void OnAfterTableCreated(ZarenUI.Server.Models.JSONServer.Table item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.JSONServer.Table item)
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

                this.OnTableCreated(item);
                this.context.Tables.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Tables.Where(i => i.Id == item.Id);

                ;

                this.OnAfterTableCreated(item);

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
