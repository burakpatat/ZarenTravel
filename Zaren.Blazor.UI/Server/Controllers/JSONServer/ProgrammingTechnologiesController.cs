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
    [Route("odata/JSONServer/ProgrammingTechnologies")]
    public partial class ProgrammingTechnologiesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProgrammingTechnologiesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.JSONServer.ProgrammingTechnology> GetProgrammingTechnologies()
        {
            var items = this.context.ProgrammingTechnologies.AsQueryable<ZarenUI.Server.Models.JSONServer.ProgrammingTechnology>();
            this.OnProgrammingTechnologiesRead(ref items);

            return items;
        }

        partial void OnProgrammingTechnologiesRead(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProgrammingTechnology> items);

        partial void OnProgrammingTechnologyGet(ref SingleResult<ZarenUI.Server.Models.JSONServer.ProgrammingTechnology> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/JSONServer/ProgrammingTechnologies(Id={Id})")]
        public SingleResult<ZarenUI.Server.Models.JSONServer.ProgrammingTechnology> GetProgrammingTechnology(int key)
        {
            var items = this.context.ProgrammingTechnologies.Where(i => i.Id == key);
            var result = SingleResult.Create(items);

            OnProgrammingTechnologyGet(ref result);

            return result;
        }
        partial void OnProgrammingTechnologyDeleted(ZarenUI.Server.Models.JSONServer.ProgrammingTechnology item);
        partial void OnAfterProgrammingTechnologyDeleted(ZarenUI.Server.Models.JSONServer.ProgrammingTechnology item);

        [HttpDelete("/odata/JSONServer/ProgrammingTechnologies(Id={Id})")]
        public IActionResult DeleteProgrammingTechnology(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.ProgrammingTechnologies
                    .Where(i => i.Id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnProgrammingTechnologyDeleted(item);
                this.context.ProgrammingTechnologies.Remove(item);
                this.context.SaveChanges();
                this.OnAfterProgrammingTechnologyDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnProgrammingTechnologyUpdated(ZarenUI.Server.Models.JSONServer.ProgrammingTechnology item);
        partial void OnAfterProgrammingTechnologyUpdated(ZarenUI.Server.Models.JSONServer.ProgrammingTechnology item);

        [HttpPut("/odata/JSONServer/ProgrammingTechnologies(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutProgrammingTechnology(int key, [FromBody]ZarenUI.Server.Models.JSONServer.ProgrammingTechnology item)
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
                this.OnProgrammingTechnologyUpdated(item);
                this.context.ProgrammingTechnologies.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProgrammingTechnologies.Where(i => i.Id == key);
                ;
                this.OnAfterProgrammingTechnologyUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/JSONServer/ProgrammingTechnologies(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchProgrammingTechnology(int key, [FromBody]Delta<ZarenUI.Server.Models.JSONServer.ProgrammingTechnology> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.ProgrammingTechnologies.Where(i => i.Id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnProgrammingTechnologyUpdated(item);
                this.context.ProgrammingTechnologies.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProgrammingTechnologies.Where(i => i.Id == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnProgrammingTechnologyCreated(ZarenUI.Server.Models.JSONServer.ProgrammingTechnology item);
        partial void OnAfterProgrammingTechnologyCreated(ZarenUI.Server.Models.JSONServer.ProgrammingTechnology item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.JSONServer.ProgrammingTechnology item)
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

                this.OnProgrammingTechnologyCreated(item);
                this.context.ProgrammingTechnologies.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProgrammingTechnologies.Where(i => i.Id == item.Id);

                ;

                this.OnAfterProgrammingTechnologyCreated(item);

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
