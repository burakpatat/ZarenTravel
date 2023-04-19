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
    [Route("odata/Connector/CountryLanguages")]
    public partial class CountryLanguagesController : ODataController
    {
        private ZarenUI.Server.Data.ConnectorContext context;

        public CountryLanguagesController(ZarenUI.Server.Data.ConnectorContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.Connector.CountryLanguage> GetCountryLanguages()
        {
            var items = this.context.CountryLanguages.AsQueryable<ZarenUI.Server.Models.Connector.CountryLanguage>();
            this.OnCountryLanguagesRead(ref items);

            return items;
        }

        partial void OnCountryLanguagesRead(ref IQueryable<ZarenUI.Server.Models.Connector.CountryLanguage> items);

        partial void OnCountryLanguageGet(ref SingleResult<ZarenUI.Server.Models.Connector.CountryLanguage> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Connector/CountryLanguages(Id={Id})")]
        public SingleResult<ZarenUI.Server.Models.Connector.CountryLanguage> GetCountryLanguage(int key)
        {
            var items = this.context.CountryLanguages.Where(i => i.Id == key);
            var result = SingleResult.Create(items);

            OnCountryLanguageGet(ref result);

            return result;
        }
        partial void OnCountryLanguageDeleted(ZarenUI.Server.Models.Connector.CountryLanguage item);
        partial void OnAfterCountryLanguageDeleted(ZarenUI.Server.Models.Connector.CountryLanguage item);

        [HttpDelete("/odata/Connector/CountryLanguages(Id={Id})")]
        public IActionResult DeleteCountryLanguage(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.CountryLanguages
                    .Where(i => i.Id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnCountryLanguageDeleted(item);
                this.context.CountryLanguages.Remove(item);
                this.context.SaveChanges();
                this.OnAfterCountryLanguageDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnCountryLanguageUpdated(ZarenUI.Server.Models.Connector.CountryLanguage item);
        partial void OnAfterCountryLanguageUpdated(ZarenUI.Server.Models.Connector.CountryLanguage item);

        [HttpPut("/odata/Connector/CountryLanguages(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutCountryLanguage(int key, [FromBody]ZarenUI.Server.Models.Connector.CountryLanguage item)
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
                this.OnCountryLanguageUpdated(item);
                this.context.CountryLanguages.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.CountryLanguages.Where(i => i.Id == key);
                ;
                this.OnAfterCountryLanguageUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Connector/CountryLanguages(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchCountryLanguage(int key, [FromBody]Delta<ZarenUI.Server.Models.Connector.CountryLanguage> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.CountryLanguages.Where(i => i.Id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnCountryLanguageUpdated(item);
                this.context.CountryLanguages.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.CountryLanguages.Where(i => i.Id == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnCountryLanguageCreated(ZarenUI.Server.Models.Connector.CountryLanguage item);
        partial void OnAfterCountryLanguageCreated(ZarenUI.Server.Models.Connector.CountryLanguage item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.Connector.CountryLanguage item)
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

                this.OnCountryLanguageCreated(item);
                this.context.CountryLanguages.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.CountryLanguages.Where(i => i.Id == item.Id);

                ;

                this.OnAfterCountryLanguageCreated(item);

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
