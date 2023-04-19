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
    [Route("odata/JSONServer/AuditCountryLanguages")]
    public partial class AuditCountryLanguagesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public AuditCountryLanguagesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.JSONServer.AuditCountryLanguage> GetAuditCountryLanguages()
        {
            var items = this.context.AuditCountryLanguages.AsQueryable<ZarenUI.Server.Models.JSONServer.AuditCountryLanguage>();
            this.OnAuditCountryLanguagesRead(ref items);

            return items;
        }

        partial void OnAuditCountryLanguagesRead(ref IQueryable<ZarenUI.Server.Models.JSONServer.AuditCountryLanguage> items);

        partial void OnAuditCountryLanguageGet(ref SingleResult<ZarenUI.Server.Models.JSONServer.AuditCountryLanguage> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/JSONServer/AuditCountryLanguages(LogID={LogID})")]
        public SingleResult<ZarenUI.Server.Models.JSONServer.AuditCountryLanguage> GetAuditCountryLanguage(long key)
        {
            var items = this.context.AuditCountryLanguages.Where(i => i.LogID == key);
            var result = SingleResult.Create(items);

            OnAuditCountryLanguageGet(ref result);

            return result;
        }
        partial void OnAuditCountryLanguageDeleted(ZarenUI.Server.Models.JSONServer.AuditCountryLanguage item);
        partial void OnAfterAuditCountryLanguageDeleted(ZarenUI.Server.Models.JSONServer.AuditCountryLanguage item);

        [HttpDelete("/odata/JSONServer/AuditCountryLanguages(LogID={LogID})")]
        public IActionResult DeleteAuditCountryLanguage(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.AuditCountryLanguages
                    .Where(i => i.LogID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnAuditCountryLanguageDeleted(item);
                this.context.AuditCountryLanguages.Remove(item);
                this.context.SaveChanges();
                this.OnAfterAuditCountryLanguageDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditCountryLanguageUpdated(ZarenUI.Server.Models.JSONServer.AuditCountryLanguage item);
        partial void OnAfterAuditCountryLanguageUpdated(ZarenUI.Server.Models.JSONServer.AuditCountryLanguage item);

        [HttpPut("/odata/JSONServer/AuditCountryLanguages(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutAuditCountryLanguage(long key, [FromBody]ZarenUI.Server.Models.JSONServer.AuditCountryLanguage item)
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
                this.OnAuditCountryLanguageUpdated(item);
                this.context.AuditCountryLanguages.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditCountryLanguages.Where(i => i.LogID == key);
                ;
                this.OnAfterAuditCountryLanguageUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/JSONServer/AuditCountryLanguages(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchAuditCountryLanguage(long key, [FromBody]Delta<ZarenUI.Server.Models.JSONServer.AuditCountryLanguage> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.AuditCountryLanguages.Where(i => i.LogID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnAuditCountryLanguageUpdated(item);
                this.context.AuditCountryLanguages.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditCountryLanguages.Where(i => i.LogID == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditCountryLanguageCreated(ZarenUI.Server.Models.JSONServer.AuditCountryLanguage item);
        partial void OnAfterAuditCountryLanguageCreated(ZarenUI.Server.Models.JSONServer.AuditCountryLanguage item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.JSONServer.AuditCountryLanguage item)
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

                this.OnAuditCountryLanguageCreated(item);
                this.context.AuditCountryLanguages.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditCountryLanguages.Where(i => i.LogID == item.LogID);

                ;

                this.OnAfterAuditCountryLanguageCreated(item);

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
