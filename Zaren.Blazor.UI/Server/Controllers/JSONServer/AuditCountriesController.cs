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
    [Route("odata/JSONServer/AuditCountries")]
    public partial class AuditCountriesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public AuditCountriesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.JSONServer.AuditCountry> GetAuditCountries()
        {
            var items = this.context.AuditCountries.AsQueryable<ZarenUI.Server.Models.JSONServer.AuditCountry>();
            this.OnAuditCountriesRead(ref items);

            return items;
        }

        partial void OnAuditCountriesRead(ref IQueryable<ZarenUI.Server.Models.JSONServer.AuditCountry> items);

        partial void OnAuditCountryGet(ref SingleResult<ZarenUI.Server.Models.JSONServer.AuditCountry> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/JSONServer/AuditCountries(LogID={LogID})")]
        public SingleResult<ZarenUI.Server.Models.JSONServer.AuditCountry> GetAuditCountry(long key)
        {
            var items = this.context.AuditCountries.Where(i => i.LogID == key);
            var result = SingleResult.Create(items);

            OnAuditCountryGet(ref result);

            return result;
        }
        partial void OnAuditCountryDeleted(ZarenUI.Server.Models.JSONServer.AuditCountry item);
        partial void OnAfterAuditCountryDeleted(ZarenUI.Server.Models.JSONServer.AuditCountry item);

        [HttpDelete("/odata/JSONServer/AuditCountries(LogID={LogID})")]
        public IActionResult DeleteAuditCountry(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.AuditCountries
                    .Where(i => i.LogID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnAuditCountryDeleted(item);
                this.context.AuditCountries.Remove(item);
                this.context.SaveChanges();
                this.OnAfterAuditCountryDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditCountryUpdated(ZarenUI.Server.Models.JSONServer.AuditCountry item);
        partial void OnAfterAuditCountryUpdated(ZarenUI.Server.Models.JSONServer.AuditCountry item);

        [HttpPut("/odata/JSONServer/AuditCountries(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutAuditCountry(long key, [FromBody]ZarenUI.Server.Models.JSONServer.AuditCountry item)
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
                this.OnAuditCountryUpdated(item);
                this.context.AuditCountries.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditCountries.Where(i => i.LogID == key);
                ;
                this.OnAfterAuditCountryUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/JSONServer/AuditCountries(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchAuditCountry(long key, [FromBody]Delta<ZarenUI.Server.Models.JSONServer.AuditCountry> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.AuditCountries.Where(i => i.LogID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnAuditCountryUpdated(item);
                this.context.AuditCountries.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditCountries.Where(i => i.LogID == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditCountryCreated(ZarenUI.Server.Models.JSONServer.AuditCountry item);
        partial void OnAfterAuditCountryCreated(ZarenUI.Server.Models.JSONServer.AuditCountry item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.JSONServer.AuditCountry item)
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

                this.OnAuditCountryCreated(item);
                this.context.AuditCountries.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditCountries.Where(i => i.LogID == item.LogID);

                ;

                this.OnAfterAuditCountryCreated(item);

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
