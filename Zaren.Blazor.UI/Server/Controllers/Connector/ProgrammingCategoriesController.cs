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
    [Route("odata/Connector/ProgrammingCategories")]
    public partial class ProgrammingCategoriesController : ODataController
    {
        private ZarenUI.Server.Data.ConnectorContext context;

        public ProgrammingCategoriesController(ZarenUI.Server.Data.ConnectorContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.Connector.ProgrammingCategory> GetProgrammingCategories()
        {
            var items = this.context.ProgrammingCategories.AsQueryable<ZarenUI.Server.Models.Connector.ProgrammingCategory>();
            this.OnProgrammingCategoriesRead(ref items);

            return items;
        }

        partial void OnProgrammingCategoriesRead(ref IQueryable<ZarenUI.Server.Models.Connector.ProgrammingCategory> items);

        partial void OnProgrammingCategoryGet(ref SingleResult<ZarenUI.Server.Models.Connector.ProgrammingCategory> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Connector/ProgrammingCategories(Id={Id})")]
        public SingleResult<ZarenUI.Server.Models.Connector.ProgrammingCategory> GetProgrammingCategory(int key)
        {
            var items = this.context.ProgrammingCategories.Where(i => i.Id == key);
            var result = SingleResult.Create(items);

            OnProgrammingCategoryGet(ref result);

            return result;
        }
        partial void OnProgrammingCategoryDeleted(ZarenUI.Server.Models.Connector.ProgrammingCategory item);
        partial void OnAfterProgrammingCategoryDeleted(ZarenUI.Server.Models.Connector.ProgrammingCategory item);

        [HttpDelete("/odata/Connector/ProgrammingCategories(Id={Id})")]
        public IActionResult DeleteProgrammingCategory(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.ProgrammingCategories
                    .Where(i => i.Id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnProgrammingCategoryDeleted(item);
                this.context.ProgrammingCategories.Remove(item);
                this.context.SaveChanges();
                this.OnAfterProgrammingCategoryDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnProgrammingCategoryUpdated(ZarenUI.Server.Models.Connector.ProgrammingCategory item);
        partial void OnAfterProgrammingCategoryUpdated(ZarenUI.Server.Models.Connector.ProgrammingCategory item);

        [HttpPut("/odata/Connector/ProgrammingCategories(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutProgrammingCategory(int key, [FromBody]ZarenUI.Server.Models.Connector.ProgrammingCategory item)
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
                this.OnProgrammingCategoryUpdated(item);
                this.context.ProgrammingCategories.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProgrammingCategories.Where(i => i.Id == key);
                ;
                this.OnAfterProgrammingCategoryUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Connector/ProgrammingCategories(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchProgrammingCategory(int key, [FromBody]Delta<ZarenUI.Server.Models.Connector.ProgrammingCategory> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.ProgrammingCategories.Where(i => i.Id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnProgrammingCategoryUpdated(item);
                this.context.ProgrammingCategories.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProgrammingCategories.Where(i => i.Id == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnProgrammingCategoryCreated(ZarenUI.Server.Models.Connector.ProgrammingCategory item);
        partial void OnAfterProgrammingCategoryCreated(ZarenUI.Server.Models.Connector.ProgrammingCategory item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.Connector.ProgrammingCategory item)
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

                this.OnProgrammingCategoryCreated(item);
                this.context.ProgrammingCategories.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProgrammingCategories.Where(i => i.Id == item.Id);

                ;

                this.OnAfterProgrammingCategoryCreated(item);

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
