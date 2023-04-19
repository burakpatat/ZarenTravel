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
    [Route("odata/Connector/ProgrammingCodeTemplates")]
    public partial class ProgrammingCodeTemplatesController : ODataController
    {
        private ZarenUI.Server.Data.ConnectorContext context;

        public ProgrammingCodeTemplatesController(ZarenUI.Server.Data.ConnectorContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate> GetProgrammingCodeTemplates()
        {
            var items = this.context.ProgrammingCodeTemplates.AsQueryable<ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate>();
            this.OnProgrammingCodeTemplatesRead(ref items);

            return items;
        }

        partial void OnProgrammingCodeTemplatesRead(ref IQueryable<ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate> items);

        partial void OnProgrammingCodeTemplateGet(ref SingleResult<ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Connector/ProgrammingCodeTemplates(Id={Id})")]
        public SingleResult<ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate> GetProgrammingCodeTemplate(int key)
        {
            var items = this.context.ProgrammingCodeTemplates.Where(i => i.Id == key);
            var result = SingleResult.Create(items);

            OnProgrammingCodeTemplateGet(ref result);

            return result;
        }
        partial void OnProgrammingCodeTemplateDeleted(ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate item);
        partial void OnAfterProgrammingCodeTemplateDeleted(ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate item);

        [HttpDelete("/odata/Connector/ProgrammingCodeTemplates(Id={Id})")]
        public IActionResult DeleteProgrammingCodeTemplate(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.ProgrammingCodeTemplates
                    .Where(i => i.Id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnProgrammingCodeTemplateDeleted(item);
                this.context.ProgrammingCodeTemplates.Remove(item);
                this.context.SaveChanges();
                this.OnAfterProgrammingCodeTemplateDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnProgrammingCodeTemplateUpdated(ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate item);
        partial void OnAfterProgrammingCodeTemplateUpdated(ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate item);

        [HttpPut("/odata/Connector/ProgrammingCodeTemplates(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutProgrammingCodeTemplate(int key, [FromBody]ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate item)
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
                this.OnProgrammingCodeTemplateUpdated(item);
                this.context.ProgrammingCodeTemplates.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProgrammingCodeTemplates.Where(i => i.Id == key);
                ;
                this.OnAfterProgrammingCodeTemplateUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Connector/ProgrammingCodeTemplates(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchProgrammingCodeTemplate(int key, [FromBody]Delta<ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.ProgrammingCodeTemplates.Where(i => i.Id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnProgrammingCodeTemplateUpdated(item);
                this.context.ProgrammingCodeTemplates.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProgrammingCodeTemplates.Where(i => i.Id == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnProgrammingCodeTemplateCreated(ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate item);
        partial void OnAfterProgrammingCodeTemplateCreated(ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate item)
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

                this.OnProgrammingCodeTemplateCreated(item);
                this.context.ProgrammingCodeTemplates.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProgrammingCodeTemplates.Where(i => i.Id == item.Id);

                ;

                this.OnAfterProgrammingCodeTemplateCreated(item);

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
