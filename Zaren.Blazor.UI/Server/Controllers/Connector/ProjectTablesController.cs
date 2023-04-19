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
    [Route("odata/Connector/ProjectTables")]
    public partial class ProjectTablesController : ODataController
    {
        private ZarenUI.Server.Data.ConnectorContext context;

        public ProjectTablesController(ZarenUI.Server.Data.ConnectorContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.Connector.ProjectTable> GetProjectTables()
        {
            var items = this.context.ProjectTables.AsQueryable<ZarenUI.Server.Models.Connector.ProjectTable>();
            this.OnProjectTablesRead(ref items);

            return items;
        }

        partial void OnProjectTablesRead(ref IQueryable<ZarenUI.Server.Models.Connector.ProjectTable> items);

        partial void OnProjectTableGet(ref SingleResult<ZarenUI.Server.Models.Connector.ProjectTable> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Connector/ProjectTables(Id={Id})")]
        public SingleResult<ZarenUI.Server.Models.Connector.ProjectTable> GetProjectTable(int key)
        {
            var items = this.context.ProjectTables.Where(i => i.Id == key);
            var result = SingleResult.Create(items);

            OnProjectTableGet(ref result);

            return result;
        }
        partial void OnProjectTableDeleted(ZarenUI.Server.Models.Connector.ProjectTable item);
        partial void OnAfterProjectTableDeleted(ZarenUI.Server.Models.Connector.ProjectTable item);

        [HttpDelete("/odata/Connector/ProjectTables(Id={Id})")]
        public IActionResult DeleteProjectTable(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.ProjectTables
                    .Where(i => i.Id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnProjectTableDeleted(item);
                this.context.ProjectTables.Remove(item);
                this.context.SaveChanges();
                this.OnAfterProjectTableDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnProjectTableUpdated(ZarenUI.Server.Models.Connector.ProjectTable item);
        partial void OnAfterProjectTableUpdated(ZarenUI.Server.Models.Connector.ProjectTable item);

        [HttpPut("/odata/Connector/ProjectTables(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutProjectTable(int key, [FromBody]ZarenUI.Server.Models.Connector.ProjectTable item)
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
                this.OnProjectTableUpdated(item);
                this.context.ProjectTables.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProjectTables.Where(i => i.Id == key);
                ;
                this.OnAfterProjectTableUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Connector/ProjectTables(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchProjectTable(int key, [FromBody]Delta<ZarenUI.Server.Models.Connector.ProjectTable> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.ProjectTables.Where(i => i.Id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnProjectTableUpdated(item);
                this.context.ProjectTables.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProjectTables.Where(i => i.Id == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnProjectTableCreated(ZarenUI.Server.Models.Connector.ProjectTable item);
        partial void OnAfterProjectTableCreated(ZarenUI.Server.Models.Connector.ProjectTable item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.Connector.ProjectTable item)
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

                this.OnProjectTableCreated(item);
                this.context.ProjectTables.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProjectTables.Where(i => i.Id == item.Id);

                ;

                this.OnAfterProjectTableCreated(item);

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
