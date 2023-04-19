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
    [Route("odata/Connector/Tables")]
    public partial class TablesController : ODataController
    {
        private ZarenUI.Server.Data.ConnectorContext context;

        public TablesController(ZarenUI.Server.Data.ConnectorContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.Connector.Table> GetTables()
        {
            var items = this.context.Tables.AsQueryable<ZarenUI.Server.Models.Connector.Table>();
            this.OnTablesRead(ref items);

            return items;
        }

        partial void OnTablesRead(ref IQueryable<ZarenUI.Server.Models.Connector.Table> items);

        partial void OnTableGet(ref SingleResult<ZarenUI.Server.Models.Connector.Table> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Connector/Tables(Id={Id})")]
        public SingleResult<ZarenUI.Server.Models.Connector.Table> GetTable(int key)
        {
            var items = this.context.Tables.Where(i => i.Id == key);
            var result = SingleResult.Create(items);

            OnTableGet(ref result);

            return result;
        }
        partial void OnTableDeleted(ZarenUI.Server.Models.Connector.Table item);
        partial void OnAfterTableDeleted(ZarenUI.Server.Models.Connector.Table item);

        [HttpDelete("/odata/Connector/Tables(Id={Id})")]
        public IActionResult DeleteTable(int key)
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

        partial void OnTableUpdated(ZarenUI.Server.Models.Connector.Table item);
        partial void OnAfterTableUpdated(ZarenUI.Server.Models.Connector.Table item);

        [HttpPut("/odata/Connector/Tables(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTable(int key, [FromBody]ZarenUI.Server.Models.Connector.Table item)
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

        [HttpPatch("/odata/Connector/Tables(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTable(int key, [FromBody]Delta<ZarenUI.Server.Models.Connector.Table> patch)
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

        partial void OnTableCreated(ZarenUI.Server.Models.Connector.Table item);
        partial void OnAfterTableCreated(ZarenUI.Server.Models.Connector.Table item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.Connector.Table item)
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
