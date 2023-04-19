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
    [Route("odata/JSONServer/Schemes")]
    public partial class SchemesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public SchemesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.JSONServer.Scheme> GetSchemes()
        {
            var items = this.context.Schemes.AsQueryable<ZarenUI.Server.Models.JSONServer.Scheme>();
            this.OnSchemesRead(ref items);

            return items;
        }

        partial void OnSchemesRead(ref IQueryable<ZarenUI.Server.Models.JSONServer.Scheme> items);

        partial void OnSchemeGet(ref SingleResult<ZarenUI.Server.Models.JSONServer.Scheme> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/JSONServer/Schemes(Id={Id})")]
        public SingleResult<ZarenUI.Server.Models.JSONServer.Scheme> GetScheme(long key)
        {
            var items = this.context.Schemes.Where(i => i.Id == key);
            var result = SingleResult.Create(items);

            OnSchemeGet(ref result);

            return result;
        }
        partial void OnSchemeDeleted(ZarenUI.Server.Models.JSONServer.Scheme item);
        partial void OnAfterSchemeDeleted(ZarenUI.Server.Models.JSONServer.Scheme item);

        [HttpDelete("/odata/JSONServer/Schemes(Id={Id})")]
        public IActionResult DeleteScheme(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.Schemes
                    .Where(i => i.Id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnSchemeDeleted(item);
                this.context.Schemes.Remove(item);
                this.context.SaveChanges();
                this.OnAfterSchemeDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnSchemeUpdated(ZarenUI.Server.Models.JSONServer.Scheme item);
        partial void OnAfterSchemeUpdated(ZarenUI.Server.Models.JSONServer.Scheme item);

        [HttpPut("/odata/JSONServer/Schemes(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutScheme(long key, [FromBody]ZarenUI.Server.Models.JSONServer.Scheme item)
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
                this.OnSchemeUpdated(item);
                this.context.Schemes.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Schemes.Where(i => i.Id == key);
                ;
                this.OnAfterSchemeUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/JSONServer/Schemes(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchScheme(long key, [FromBody]Delta<ZarenUI.Server.Models.JSONServer.Scheme> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.Schemes.Where(i => i.Id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnSchemeUpdated(item);
                this.context.Schemes.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Schemes.Where(i => i.Id == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnSchemeCreated(ZarenUI.Server.Models.JSONServer.Scheme item);
        partial void OnAfterSchemeCreated(ZarenUI.Server.Models.JSONServer.Scheme item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.JSONServer.Scheme item)
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

                this.OnSchemeCreated(item);
                this.context.Schemes.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Schemes.Where(i => i.Id == item.Id);

                ;

                this.OnAfterSchemeCreated(item);

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
