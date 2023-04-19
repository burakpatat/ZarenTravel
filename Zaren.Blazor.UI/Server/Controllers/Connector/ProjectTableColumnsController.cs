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
    [Route("odata/Connector/ProjectTableColumns")]
    public partial class ProjectTableColumnsController : ODataController
    {
        private ZarenUI.Server.Data.ConnectorContext context;

        public ProjectTableColumnsController(ZarenUI.Server.Data.ConnectorContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.Connector.ProjectTableColumn> GetProjectTableColumns()
        {
            var items = this.context.ProjectTableColumns.AsQueryable<ZarenUI.Server.Models.Connector.ProjectTableColumn>();
            this.OnProjectTableColumnsRead(ref items);

            return items;
        }

        partial void OnProjectTableColumnsRead(ref IQueryable<ZarenUI.Server.Models.Connector.ProjectTableColumn> items);

        partial void OnProjectTableColumnGet(ref SingleResult<ZarenUI.Server.Models.Connector.ProjectTableColumn> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Connector/ProjectTableColumns(Id={Id})")]
        public SingleResult<ZarenUI.Server.Models.Connector.ProjectTableColumn> GetProjectTableColumn(int key)
        {
            var items = this.context.ProjectTableColumns.Where(i => i.Id == key);
            var result = SingleResult.Create(items);

            OnProjectTableColumnGet(ref result);

            return result;
        }
        partial void OnProjectTableColumnDeleted(ZarenUI.Server.Models.Connector.ProjectTableColumn item);
        partial void OnAfterProjectTableColumnDeleted(ZarenUI.Server.Models.Connector.ProjectTableColumn item);

        [HttpDelete("/odata/Connector/ProjectTableColumns(Id={Id})")]
        public IActionResult DeleteProjectTableColumn(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.ProjectTableColumns
                    .Where(i => i.Id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnProjectTableColumnDeleted(item);
                this.context.ProjectTableColumns.Remove(item);
                this.context.SaveChanges();
                this.OnAfterProjectTableColumnDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnProjectTableColumnUpdated(ZarenUI.Server.Models.Connector.ProjectTableColumn item);
        partial void OnAfterProjectTableColumnUpdated(ZarenUI.Server.Models.Connector.ProjectTableColumn item);

        [HttpPut("/odata/Connector/ProjectTableColumns(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutProjectTableColumn(int key, [FromBody]ZarenUI.Server.Models.Connector.ProjectTableColumn item)
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
                this.OnProjectTableColumnUpdated(item);
                this.context.ProjectTableColumns.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProjectTableColumns.Where(i => i.Id == key);
                ;
                this.OnAfterProjectTableColumnUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Connector/ProjectTableColumns(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchProjectTableColumn(int key, [FromBody]Delta<ZarenUI.Server.Models.Connector.ProjectTableColumn> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.ProjectTableColumns.Where(i => i.Id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnProjectTableColumnUpdated(item);
                this.context.ProjectTableColumns.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProjectTableColumns.Where(i => i.Id == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnProjectTableColumnCreated(ZarenUI.Server.Models.Connector.ProjectTableColumn item);
        partial void OnAfterProjectTableColumnCreated(ZarenUI.Server.Models.Connector.ProjectTableColumn item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.Connector.ProjectTableColumn item)
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

                this.OnProjectTableColumnCreated(item);
                this.context.ProjectTableColumns.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProjectTableColumns.Where(i => i.Id == item.Id);

                ;

                this.OnAfterProjectTableColumnCreated(item);

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
