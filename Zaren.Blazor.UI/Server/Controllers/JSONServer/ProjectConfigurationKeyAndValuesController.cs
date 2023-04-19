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
    [Route("odata/JSONServer/ProjectConfigurationKeyAndValues")]
    public partial class ProjectConfigurationKeyAndValuesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationKeyAndValuesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValue> GetProjectConfigurationKeyAndValues()
        {
            var items = this.context.ProjectConfigurationKeyAndValues.AsQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValue>();
            this.OnProjectConfigurationKeyAndValuesRead(ref items);

            return items;
        }

        partial void OnProjectConfigurationKeyAndValuesRead(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValue> items);

        partial void OnProjectConfigurationKeyAndValueGet(ref SingleResult<ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValue> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/JSONServer/ProjectConfigurationKeyAndValues(Id={Id})")]
        public SingleResult<ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValue> GetProjectConfigurationKeyAndValue(int key)
        {
            var items = this.context.ProjectConfigurationKeyAndValues.Where(i => i.Id == key);
            var result = SingleResult.Create(items);

            OnProjectConfigurationKeyAndValueGet(ref result);

            return result;
        }
        partial void OnProjectConfigurationKeyAndValueDeleted(ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValue item);
        partial void OnAfterProjectConfigurationKeyAndValueDeleted(ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValue item);

        [HttpDelete("/odata/JSONServer/ProjectConfigurationKeyAndValues(Id={Id})")]
        public IActionResult DeleteProjectConfigurationKeyAndValue(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.ProjectConfigurationKeyAndValues
                    .Where(i => i.Id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnProjectConfigurationKeyAndValueDeleted(item);
                this.context.ProjectConfigurationKeyAndValues.Remove(item);
                this.context.SaveChanges();
                this.OnAfterProjectConfigurationKeyAndValueDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnProjectConfigurationKeyAndValueUpdated(ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValue item);
        partial void OnAfterProjectConfigurationKeyAndValueUpdated(ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValue item);

        [HttpPut("/odata/JSONServer/ProjectConfigurationKeyAndValues(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutProjectConfigurationKeyAndValue(int key, [FromBody]ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValue item)
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
                this.OnProjectConfigurationKeyAndValueUpdated(item);
                this.context.ProjectConfigurationKeyAndValues.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProjectConfigurationKeyAndValues.Where(i => i.Id == key);
                ;
                this.OnAfterProjectConfigurationKeyAndValueUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/JSONServer/ProjectConfigurationKeyAndValues(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchProjectConfigurationKeyAndValue(int key, [FromBody]Delta<ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValue> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.ProjectConfigurationKeyAndValues.Where(i => i.Id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnProjectConfigurationKeyAndValueUpdated(item);
                this.context.ProjectConfigurationKeyAndValues.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProjectConfigurationKeyAndValues.Where(i => i.Id == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnProjectConfigurationKeyAndValueCreated(ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValue item);
        partial void OnAfterProjectConfigurationKeyAndValueCreated(ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValue item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValue item)
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

                this.OnProjectConfigurationKeyAndValueCreated(item);
                this.context.ProjectConfigurationKeyAndValues.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProjectConfigurationKeyAndValues.Where(i => i.Id == item.Id);

                ;

                this.OnAfterProjectConfigurationKeyAndValueCreated(item);

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
