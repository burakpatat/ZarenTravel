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
    [Route("odata/Connector/ProjectConfigurations")]
    public partial class ProjectConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.ConnectorContext context;

        public ProjectConfigurationsController(ZarenUI.Server.Data.ConnectorContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.Connector.ProjectConfiguration> GetProjectConfigurations()
        {
            var items = this.context.ProjectConfigurations.AsQueryable<ZarenUI.Server.Models.Connector.ProjectConfiguration>();
            this.OnProjectConfigurationsRead(ref items);

            return items;
        }

        partial void OnProjectConfigurationsRead(ref IQueryable<ZarenUI.Server.Models.Connector.ProjectConfiguration> items);

        partial void OnProjectConfigurationGet(ref SingleResult<ZarenUI.Server.Models.Connector.ProjectConfiguration> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Connector/ProjectConfigurations(Id={Id})")]
        public SingleResult<ZarenUI.Server.Models.Connector.ProjectConfiguration> GetProjectConfiguration(int key)
        {
            var items = this.context.ProjectConfigurations.Where(i => i.Id == key);
            var result = SingleResult.Create(items);

            OnProjectConfigurationGet(ref result);

            return result;
        }
        partial void OnProjectConfigurationDeleted(ZarenUI.Server.Models.Connector.ProjectConfiguration item);
        partial void OnAfterProjectConfigurationDeleted(ZarenUI.Server.Models.Connector.ProjectConfiguration item);

        [HttpDelete("/odata/Connector/ProjectConfigurations(Id={Id})")]
        public IActionResult DeleteProjectConfiguration(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.ProjectConfigurations
                    .Where(i => i.Id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnProjectConfigurationDeleted(item);
                this.context.ProjectConfigurations.Remove(item);
                this.context.SaveChanges();
                this.OnAfterProjectConfigurationDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnProjectConfigurationUpdated(ZarenUI.Server.Models.Connector.ProjectConfiguration item);
        partial void OnAfterProjectConfigurationUpdated(ZarenUI.Server.Models.Connector.ProjectConfiguration item);

        [HttpPut("/odata/Connector/ProjectConfigurations(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutProjectConfiguration(int key, [FromBody]ZarenUI.Server.Models.Connector.ProjectConfiguration item)
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
                this.OnProjectConfigurationUpdated(item);
                this.context.ProjectConfigurations.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProjectConfigurations.Where(i => i.Id == key);
                ;
                this.OnAfterProjectConfigurationUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Connector/ProjectConfigurations(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchProjectConfiguration(int key, [FromBody]Delta<ZarenUI.Server.Models.Connector.ProjectConfiguration> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.ProjectConfigurations.Where(i => i.Id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnProjectConfigurationUpdated(item);
                this.context.ProjectConfigurations.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProjectConfigurations.Where(i => i.Id == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnProjectConfigurationCreated(ZarenUI.Server.Models.Connector.ProjectConfiguration item);
        partial void OnAfterProjectConfigurationCreated(ZarenUI.Server.Models.Connector.ProjectConfiguration item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.Connector.ProjectConfiguration item)
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

                this.OnProjectConfigurationCreated(item);
                this.context.ProjectConfigurations.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProjectConfigurations.Where(i => i.Id == item.Id);

                ;

                this.OnAfterProjectConfigurationCreated(item);

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
