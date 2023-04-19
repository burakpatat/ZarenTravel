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
    [Route("odata/Connector/ProjectFunctions")]
    public partial class ProjectFunctionsController : ODataController
    {
        private ZarenUI.Server.Data.ConnectorContext context;

        public ProjectFunctionsController(ZarenUI.Server.Data.ConnectorContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.Connector.ProjectFunction> GetProjectFunctions()
        {
            var items = this.context.ProjectFunctions.AsQueryable<ZarenUI.Server.Models.Connector.ProjectFunction>();
            this.OnProjectFunctionsRead(ref items);

            return items;
        }

        partial void OnProjectFunctionsRead(ref IQueryable<ZarenUI.Server.Models.Connector.ProjectFunction> items);

        partial void OnProjectFunctionGet(ref SingleResult<ZarenUI.Server.Models.Connector.ProjectFunction> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Connector/ProjectFunctions(Id={Id})")]
        public SingleResult<ZarenUI.Server.Models.Connector.ProjectFunction> GetProjectFunction(int key)
        {
            var items = this.context.ProjectFunctions.Where(i => i.Id == key);
            var result = SingleResult.Create(items);

            OnProjectFunctionGet(ref result);

            return result;
        }
        partial void OnProjectFunctionDeleted(ZarenUI.Server.Models.Connector.ProjectFunction item);
        partial void OnAfterProjectFunctionDeleted(ZarenUI.Server.Models.Connector.ProjectFunction item);

        [HttpDelete("/odata/Connector/ProjectFunctions(Id={Id})")]
        public IActionResult DeleteProjectFunction(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.ProjectFunctions
                    .Where(i => i.Id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnProjectFunctionDeleted(item);
                this.context.ProjectFunctions.Remove(item);
                this.context.SaveChanges();
                this.OnAfterProjectFunctionDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnProjectFunctionUpdated(ZarenUI.Server.Models.Connector.ProjectFunction item);
        partial void OnAfterProjectFunctionUpdated(ZarenUI.Server.Models.Connector.ProjectFunction item);

        [HttpPut("/odata/Connector/ProjectFunctions(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutProjectFunction(int key, [FromBody]ZarenUI.Server.Models.Connector.ProjectFunction item)
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
                this.OnProjectFunctionUpdated(item);
                this.context.ProjectFunctions.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProjectFunctions.Where(i => i.Id == key);
                ;
                this.OnAfterProjectFunctionUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Connector/ProjectFunctions(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchProjectFunction(int key, [FromBody]Delta<ZarenUI.Server.Models.Connector.ProjectFunction> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.ProjectFunctions.Where(i => i.Id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnProjectFunctionUpdated(item);
                this.context.ProjectFunctions.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProjectFunctions.Where(i => i.Id == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnProjectFunctionCreated(ZarenUI.Server.Models.Connector.ProjectFunction item);
        partial void OnAfterProjectFunctionCreated(ZarenUI.Server.Models.Connector.ProjectFunction item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.Connector.ProjectFunction item)
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

                this.OnProjectFunctionCreated(item);
                this.context.ProjectFunctions.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProjectFunctions.Where(i => i.Id == item.Id);

                ;

                this.OnAfterProjectFunctionCreated(item);

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
