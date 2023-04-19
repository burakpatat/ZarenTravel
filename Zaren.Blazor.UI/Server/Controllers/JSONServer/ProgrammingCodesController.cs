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
    [Route("odata/JSONServer/ProgrammingCodes")]
    public partial class ProgrammingCodesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProgrammingCodesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.JSONServer.ProgrammingCode> GetProgrammingCodes()
        {
            var items = this.context.ProgrammingCodes.AsQueryable<ZarenUI.Server.Models.JSONServer.ProgrammingCode>();
            this.OnProgrammingCodesRead(ref items);

            return items;
        }

        partial void OnProgrammingCodesRead(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProgrammingCode> items);

        partial void OnProgrammingCodeGet(ref SingleResult<ZarenUI.Server.Models.JSONServer.ProgrammingCode> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/JSONServer/ProgrammingCodes(Id={Id})")]
        public SingleResult<ZarenUI.Server.Models.JSONServer.ProgrammingCode> GetProgrammingCode(int key)
        {
            var items = this.context.ProgrammingCodes.Where(i => i.Id == key);
            var result = SingleResult.Create(items);

            OnProgrammingCodeGet(ref result);

            return result;
        }
        partial void OnProgrammingCodeDeleted(ZarenUI.Server.Models.JSONServer.ProgrammingCode item);
        partial void OnAfterProgrammingCodeDeleted(ZarenUI.Server.Models.JSONServer.ProgrammingCode item);

        [HttpDelete("/odata/JSONServer/ProgrammingCodes(Id={Id})")]
        public IActionResult DeleteProgrammingCode(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.ProgrammingCodes
                    .Where(i => i.Id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnProgrammingCodeDeleted(item);
                this.context.ProgrammingCodes.Remove(item);
                this.context.SaveChanges();
                this.OnAfterProgrammingCodeDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnProgrammingCodeUpdated(ZarenUI.Server.Models.JSONServer.ProgrammingCode item);
        partial void OnAfterProgrammingCodeUpdated(ZarenUI.Server.Models.JSONServer.ProgrammingCode item);

        [HttpPut("/odata/JSONServer/ProgrammingCodes(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutProgrammingCode(int key, [FromBody]ZarenUI.Server.Models.JSONServer.ProgrammingCode item)
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
                this.OnProgrammingCodeUpdated(item);
                this.context.ProgrammingCodes.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProgrammingCodes.Where(i => i.Id == key);
                ;
                this.OnAfterProgrammingCodeUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/JSONServer/ProgrammingCodes(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchProgrammingCode(int key, [FromBody]Delta<ZarenUI.Server.Models.JSONServer.ProgrammingCode> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.ProgrammingCodes.Where(i => i.Id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnProgrammingCodeUpdated(item);
                this.context.ProgrammingCodes.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProgrammingCodes.Where(i => i.Id == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnProgrammingCodeCreated(ZarenUI.Server.Models.JSONServer.ProgrammingCode item);
        partial void OnAfterProgrammingCodeCreated(ZarenUI.Server.Models.JSONServer.ProgrammingCode item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.JSONServer.ProgrammingCode item)
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

                this.OnProgrammingCodeCreated(item);
                this.context.ProgrammingCodes.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProgrammingCodes.Where(i => i.Id == item.Id);

                ;

                this.OnAfterProgrammingCodeCreated(item);

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
