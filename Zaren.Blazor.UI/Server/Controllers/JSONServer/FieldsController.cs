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
    [Route("odata/JSONServer/Fields")]
    public partial class FieldsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public FieldsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.JSONServer.Field> GetFields()
        {
            var items = this.context.Fields.AsQueryable<ZarenUI.Server.Models.JSONServer.Field>();
            this.OnFieldsRead(ref items);

            return items;
        }

        partial void OnFieldsRead(ref IQueryable<ZarenUI.Server.Models.JSONServer.Field> items);

        partial void OnFieldGet(ref SingleResult<ZarenUI.Server.Models.JSONServer.Field> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/JSONServer/Fields(Id={Id})")]
        public SingleResult<ZarenUI.Server.Models.JSONServer.Field> GetField(long key)
        {
            var items = this.context.Fields.Where(i => i.Id == key);
            var result = SingleResult.Create(items);

            OnFieldGet(ref result);

            return result;
        }
        partial void OnFieldDeleted(ZarenUI.Server.Models.JSONServer.Field item);
        partial void OnAfterFieldDeleted(ZarenUI.Server.Models.JSONServer.Field item);

        [HttpDelete("/odata/JSONServer/Fields(Id={Id})")]
        public IActionResult DeleteField(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.Fields
                    .Where(i => i.Id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnFieldDeleted(item);
                this.context.Fields.Remove(item);
                this.context.SaveChanges();
                this.OnAfterFieldDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnFieldUpdated(ZarenUI.Server.Models.JSONServer.Field item);
        partial void OnAfterFieldUpdated(ZarenUI.Server.Models.JSONServer.Field item);

        [HttpPut("/odata/JSONServer/Fields(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutField(long key, [FromBody]ZarenUI.Server.Models.JSONServer.Field item)
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
                this.OnFieldUpdated(item);
                this.context.Fields.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Fields.Where(i => i.Id == key);
                ;
                this.OnAfterFieldUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/JSONServer/Fields(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchField(long key, [FromBody]Delta<ZarenUI.Server.Models.JSONServer.Field> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.Fields.Where(i => i.Id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnFieldUpdated(item);
                this.context.Fields.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Fields.Where(i => i.Id == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnFieldCreated(ZarenUI.Server.Models.JSONServer.Field item);
        partial void OnAfterFieldCreated(ZarenUI.Server.Models.JSONServer.Field item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.JSONServer.Field item)
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

                this.OnFieldCreated(item);
                this.context.Fields.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Fields.Where(i => i.Id == item.Id);

                ;

                this.OnAfterFieldCreated(item);

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
