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
    [Route("odata/Connector/Countries")]
    public partial class CountriesController : ODataController
    {
        private ZarenUI.Server.Data.ConnectorContext context;

        public CountriesController(ZarenUI.Server.Data.ConnectorContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.Connector.Country> GetCountries()
        {
            var items = this.context.Countries.AsQueryable<ZarenUI.Server.Models.Connector.Country>();
            this.OnCountriesRead(ref items);

            return items;
        }

        partial void OnCountriesRead(ref IQueryable<ZarenUI.Server.Models.Connector.Country> items);

        partial void OnCountryGet(ref SingleResult<ZarenUI.Server.Models.Connector.Country> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Connector/Countries(Id={Id})")]
        public SingleResult<ZarenUI.Server.Models.Connector.Country> GetCountry(int key)
        {
            var items = this.context.Countries.Where(i => i.Id == key);
            var result = SingleResult.Create(items);

            OnCountryGet(ref result);

            return result;
        }
        partial void OnCountryDeleted(ZarenUI.Server.Models.Connector.Country item);
        partial void OnAfterCountryDeleted(ZarenUI.Server.Models.Connector.Country item);

        [HttpDelete("/odata/Connector/Countries(Id={Id})")]
        public IActionResult DeleteCountry(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.Countries
                    .Where(i => i.Id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnCountryDeleted(item);
                this.context.Countries.Remove(item);
                this.context.SaveChanges();
                this.OnAfterCountryDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnCountryUpdated(ZarenUI.Server.Models.Connector.Country item);
        partial void OnAfterCountryUpdated(ZarenUI.Server.Models.Connector.Country item);

        [HttpPut("/odata/Connector/Countries(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutCountry(int key, [FromBody]ZarenUI.Server.Models.Connector.Country item)
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
                this.OnCountryUpdated(item);
                this.context.Countries.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Countries.Where(i => i.Id == key);
                ;
                this.OnAfterCountryUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Connector/Countries(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchCountry(int key, [FromBody]Delta<ZarenUI.Server.Models.Connector.Country> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.Countries.Where(i => i.Id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnCountryUpdated(item);
                this.context.Countries.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Countries.Where(i => i.Id == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnCountryCreated(ZarenUI.Server.Models.Connector.Country item);
        partial void OnAfterCountryCreated(ZarenUI.Server.Models.Connector.Country item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.Connector.Country item)
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

                this.OnCountryCreated(item);
                this.context.Countries.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Countries.Where(i => i.Id == item.Id);

                ;

                this.OnAfterCountryCreated(item);

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
