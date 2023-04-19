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
    public partial class CountryUpdatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryUpdatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryUpdatesFunc(Id={Id},Name={Name},ShortName={ShortName},Temperature={Temperature},Area={Area},Religion={Religion},Location={Location},Population={Population},Density={Density},Symbol={Symbol},Abbreviation={Abbreviation},FlagBase64={FlagBase64},Expectancy={Expectancy},Dish={Dish},LanguagesJSON={LanguagesJSON},Landlocked={Landlocked},Iso={Iso},Independence={Independence},Government={Government},North={North},South={South},West={West},East={East},Elevation={Elevation},DomainTld={DomainTld},CurrencyName={CurrencyName},CurrencyCode={CurrencyCode},CostLine={CostLine},Continent={Continent},City={City},CallingCode={CallingCode},Barcode={Barcode},Height={Height},DefaultLanguageId={DefaultLanguageId})")]
        public IActionResult CountryUpdatesFunc([FromODataUri] int? Id, [FromODataUri] string Name, [FromODataUri] string ShortName, [FromODataUri] string Temperature, [FromODataUri] string Area, [FromODataUri] string Religion, [FromODataUri] string Location, [FromODataUri] string Population, [FromODataUri] string Density, [FromODataUri] string Symbol, [FromODataUri] string Abbreviation, [FromODataUri] string FlagBase64, [FromODataUri] string Expectancy, [FromODataUri] string Dish, [FromODataUri] string LanguagesJSON, [FromODataUri] string Landlocked, [FromODataUri] string Iso, [FromODataUri] string Independence, [FromODataUri] string Government, [FromODataUri] string North, [FromODataUri] string South, [FromODataUri] string West, [FromODataUri] string East, [FromODataUri] string Elevation, [FromODataUri] string DomainTld, [FromODataUri] string CurrencyName, [FromODataUri] string CurrencyCode, [FromODataUri] string CostLine, [FromODataUri] string Continent, [FromODataUri] string City, [FromODataUri] string CallingCode, [FromODataUri] string Barcode, [FromODataUri] string Height, [FromODataUri] int? DefaultLanguageId)
        {
            this.OnCountryUpdatesDefaultParams(ref Id, ref Name, ref ShortName, ref Temperature, ref Area, ref Religion, ref Location, ref Population, ref Density, ref Symbol, ref Abbreviation, ref FlagBase64, ref Expectancy, ref Dish, ref LanguagesJSON, ref Landlocked, ref Iso, ref Independence, ref Government, ref North, ref South, ref West, ref East, ref Elevation, ref DomainTld, ref CurrencyName, ref CurrencyCode, ref CostLine, ref Continent, ref City, ref CallingCode, ref Barcode, ref Height, ref DefaultLanguageId);

            var items = this.context.CountryUpdates.FromSqlRaw("EXEC [dbo].[CountryUpdate] @Id={0}, @Name={1}, @ShortName={2}, @Temperature={3}, @Area={4}, @Religion={5}, @Location={6}, @Population={7}, @Density={8}, @Symbol={9}, @Abbreviation={10}, @FlagBase64={11}, @Expectancy={12}, @Dish={13}, @LanguagesJSON={14}, @Landlocked={15}, @Iso={16}, @Independence={17}, @Government={18}, @North={19}, @South={20}, @West={21}, @East={22}, @Elevation={23}, @DomainTld={24}, @CurrencyName={25}, @CurrencyCode={26}, @CostLine={27}, @Continent={28}, @City={29}, @CallingCode={30}, @Barcode={31}, @Height={32}, @DefaultLanguageId={33}", Id, Name, ShortName, Temperature, Area, Religion, Location, Population, Density, Symbol, Abbreviation, FlagBase64, Expectancy, Dish, LanguagesJSON, Landlocked, Iso, Independence, Government, North, South, West, East, Elevation, DomainTld, CurrencyName, CurrencyCode, CostLine, Continent, City, CallingCode, Barcode, Height, DefaultLanguageId).ToList().AsQueryable();

            this.OnCountryUpdatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryUpdatesDefaultParams(ref int? Id, ref string Name, ref string ShortName, ref string Temperature, ref string Area, ref string Religion, ref string Location, ref string Population, ref string Density, ref string Symbol, ref string Abbreviation, ref string FlagBase64, ref string Expectancy, ref string Dish, ref string LanguagesJSON, ref string Landlocked, ref string Iso, ref string Independence, ref string Government, ref string North, ref string South, ref string West, ref string East, ref string Elevation, ref string DomainTld, ref string CurrencyName, ref string CurrencyCode, ref string CostLine, ref string Continent, ref string City, ref string CallingCode, ref string Barcode, ref string Height, ref int? DefaultLanguageId);

        partial void OnCountryUpdatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryUpdate> items);
    }
}
