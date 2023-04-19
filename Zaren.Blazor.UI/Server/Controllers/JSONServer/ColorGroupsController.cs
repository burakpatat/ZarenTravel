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
    [Route("odata/JSONServer/ColorGroups")]
    public partial class ColorGroupsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ColorGroupsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.JSONServer.ColorGroup> GetColorGroups()
        {
            var items = this.context.ColorGroups.AsQueryable<ZarenUI.Server.Models.JSONServer.ColorGroup>();
            this.OnColorGroupsRead(ref items);

            return items;
        }

        partial void OnColorGroupsRead(ref IQueryable<ZarenUI.Server.Models.JSONServer.ColorGroup> items);

        partial void OnColorGroupGet(ref SingleResult<ZarenUI.Server.Models.JSONServer.ColorGroup> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/JSONServer/ColorGroups(Id={Id})")]
        public SingleResult<ZarenUI.Server.Models.JSONServer.ColorGroup> GetColorGroup(int key)
        {
            var items = this.context.ColorGroups.Where(i => i.Id == key);
            var result = SingleResult.Create(items);

            OnColorGroupGet(ref result);

            return result;
        }
        partial void OnColorGroupDeleted(ZarenUI.Server.Models.JSONServer.ColorGroup item);
        partial void OnAfterColorGroupDeleted(ZarenUI.Server.Models.JSONServer.ColorGroup item);

        [HttpDelete("/odata/JSONServer/ColorGroups(Id={Id})")]
        public IActionResult DeleteColorGroup(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.ColorGroups
                    .Where(i => i.Id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnColorGroupDeleted(item);
                this.context.ColorGroups.Remove(item);
                this.context.SaveChanges();
                this.OnAfterColorGroupDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnColorGroupUpdated(ZarenUI.Server.Models.JSONServer.ColorGroup item);
        partial void OnAfterColorGroupUpdated(ZarenUI.Server.Models.JSONServer.ColorGroup item);

        [HttpPut("/odata/JSONServer/ColorGroups(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutColorGroup(int key, [FromBody]ZarenUI.Server.Models.JSONServer.ColorGroup item)
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
                this.OnColorGroupUpdated(item);
                this.context.ColorGroups.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ColorGroups.Where(i => i.Id == key);
                ;
                this.OnAfterColorGroupUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/JSONServer/ColorGroups(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchColorGroup(int key, [FromBody]Delta<ZarenUI.Server.Models.JSONServer.ColorGroup> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.ColorGroups.Where(i => i.Id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnColorGroupUpdated(item);
                this.context.ColorGroups.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ColorGroups.Where(i => i.Id == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnColorGroupCreated(ZarenUI.Server.Models.JSONServer.ColorGroup item);
        partial void OnAfterColorGroupCreated(ZarenUI.Server.Models.JSONServer.ColorGroup item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.JSONServer.ColorGroup item)
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

                this.OnColorGroupCreated(item);
                this.context.ColorGroups.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ColorGroups.Where(i => i.Id == item.Id);

                ;

                this.OnAfterColorGroupCreated(item);

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
