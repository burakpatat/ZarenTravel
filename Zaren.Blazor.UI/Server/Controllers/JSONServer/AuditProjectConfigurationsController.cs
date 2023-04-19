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
    [Route("odata/JSONServer/AuditProjectConfigurations")]
    public partial class AuditProjectConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public AuditProjectConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.JSONServer.AuditProjectConfiguration> GetAuditProjectConfigurations()
        {
            var items = this.context.AuditProjectConfigurations.AsQueryable<ZarenUI.Server.Models.JSONServer.AuditProjectConfiguration>();
            this.OnAuditProjectConfigurationsRead(ref items);

            return items;
        }

        partial void OnAuditProjectConfigurationsRead(ref IQueryable<ZarenUI.Server.Models.JSONServer.AuditProjectConfiguration> items);

        partial void OnAuditProjectConfigurationGet(ref SingleResult<ZarenUI.Server.Models.JSONServer.AuditProjectConfiguration> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/JSONServer/AuditProjectConfigurations(LogID={LogID})")]
        public SingleResult<ZarenUI.Server.Models.JSONServer.AuditProjectConfiguration> GetAuditProjectConfiguration(long key)
        {
            var items = this.context.AuditProjectConfigurations.Where(i => i.LogID == key);
            var result = SingleResult.Create(items);

            OnAuditProjectConfigurationGet(ref result);

            return result;
        }
        partial void OnAuditProjectConfigurationDeleted(ZarenUI.Server.Models.JSONServer.AuditProjectConfiguration item);
        partial void OnAfterAuditProjectConfigurationDeleted(ZarenUI.Server.Models.JSONServer.AuditProjectConfiguration item);

        [HttpDelete("/odata/JSONServer/AuditProjectConfigurations(LogID={LogID})")]
        public IActionResult DeleteAuditProjectConfiguration(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.AuditProjectConfigurations
                    .Where(i => i.LogID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnAuditProjectConfigurationDeleted(item);
                this.context.AuditProjectConfigurations.Remove(item);
                this.context.SaveChanges();
                this.OnAfterAuditProjectConfigurationDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditProjectConfigurationUpdated(ZarenUI.Server.Models.JSONServer.AuditProjectConfiguration item);
        partial void OnAfterAuditProjectConfigurationUpdated(ZarenUI.Server.Models.JSONServer.AuditProjectConfiguration item);

        [HttpPut("/odata/JSONServer/AuditProjectConfigurations(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutAuditProjectConfiguration(long key, [FromBody]ZarenUI.Server.Models.JSONServer.AuditProjectConfiguration item)
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
                this.OnAuditProjectConfigurationUpdated(item);
                this.context.AuditProjectConfigurations.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProjectConfigurations.Where(i => i.LogID == key);
                ;
                this.OnAfterAuditProjectConfigurationUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/JSONServer/AuditProjectConfigurations(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchAuditProjectConfiguration(long key, [FromBody]Delta<ZarenUI.Server.Models.JSONServer.AuditProjectConfiguration> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.AuditProjectConfigurations.Where(i => i.LogID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnAuditProjectConfigurationUpdated(item);
                this.context.AuditProjectConfigurations.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProjectConfigurations.Where(i => i.LogID == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditProjectConfigurationCreated(ZarenUI.Server.Models.JSONServer.AuditProjectConfiguration item);
        partial void OnAfterAuditProjectConfigurationCreated(ZarenUI.Server.Models.JSONServer.AuditProjectConfiguration item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.JSONServer.AuditProjectConfiguration item)
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

                this.OnAuditProjectConfigurationCreated(item);
                this.context.AuditProjectConfigurations.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProjectConfigurations.Where(i => i.LogID == item.LogID);

                ;

                this.OnAfterAuditProjectConfigurationCreated(item);

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
