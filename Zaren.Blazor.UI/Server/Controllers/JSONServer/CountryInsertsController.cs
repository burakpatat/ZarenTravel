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
    public partial class CountryInsertsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryInsertsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryInsertsFunc(Name={Name},ShortName={ShortName},Temperature={Temperature},Area={Area},Religion={Religion},Location={Location},Population={Population},Density={Density},Symbol={Symbol},Abbreviation={Abbreviation},FlagBase64={FlagBase64},Expectancy={Expectancy},Dish={Dish},LanguagesJSON={LanguagesJSON},Landlocked={Landlocked},Iso={Iso},Independence={Independence},Government={Government},North={North},South={South},West={West},East={East},Elevation={Elevation},DomainTld={DomainTld},CurrencyName={CurrencyName},CurrencyCode={CurrencyCode},CostLine={CostLine},Continent={Continent},City={City},CallingCode={CallingCode},Barcode={Barcode},Height={Height},DefaultLanguageId={DefaultLanguageId})")]
        public IActionResult CountryInsertsFunc([FromODataUri] string Name, [FromODataUri] string ShortName, [FromODataUri] string Temperature, [FromODataUri] string Area, [FromODataUri] string Religion, [FromODataUri] string Location, [FromODataUri] string Population, [FromODataUri] string Density, [FromODataUri] string Symbol, [FromODataUri] string Abbreviation, [FromODataUri] string FlagBase64, [FromODataUri] string Expectancy, [FromODataUri] string Dish, [FromODataUri] string LanguagesJSON, [FromODataUri] string Landlocked, [FromODataUri] string Iso, [FromODataUri] string Independence, [FromODataUri] string Government, [FromODataUri] string North, [FromODataUri] string South, [FromODataUri] string West, [FromODataUri] string East, [FromODataUri] string Elevation, [FromODataUri] string DomainTld, [FromODataUri] string CurrencyName, [FromODataUri] string CurrencyCode, [FromODataUri] string CostLine, [FromODataUri] string Continent, [FromODataUri] string City, [FromODataUri] string CallingCode, [FromODataUri] string Barcode, [FromODataUri] string Height, [FromODataUri] int? DefaultLanguageId)
        {
            this.OnCountryInsertsDefaultParams(ref Name, ref ShortName, ref Temperature, ref Area, ref Religion, ref Location, ref Population, ref Density, ref Symbol, ref Abbreviation, ref FlagBase64, ref Expectancy, ref Dish, ref LanguagesJSON, ref Landlocked, ref Iso, ref Independence, ref Government, ref North, ref South, ref West, ref East, ref Elevation, ref DomainTld, ref CurrencyName, ref CurrencyCode, ref CostLine, ref Continent, ref City, ref CallingCode, ref Barcode, ref Height, ref DefaultLanguageId);

            var items = this.context.CountryInserts.FromSqlRaw("EXEC [dbo].[CountryInsert] @Name={0}, @ShortName={1}, @Temperature={2}, @Area={3}, @Religion={4}, @Location={5}, @Population={6}, @Density={7}, @Symbol={8}, @Abbreviation={9}, @FlagBase64={10}, @Expectancy={11}, @Dish={12}, @LanguagesJSON={13}, @Landlocked={14}, @Iso={15}, @Independence={16}, @Government={17}, @North={18}, @South={19}, @West={20}, @East={21}, @Elevation={22}, @DomainTld={23}, @CurrencyName={24}, @CurrencyCode={25}, @CostLine={26}, @Continent={27}, @City={28}, @CallingCode={29}, @Barcode={30}, @Height={31}, @DefaultLanguageId={32}", Name, ShortName, Temperature, Area, Religion, Location, Population, Density, Symbol, Abbreviation, FlagBase64, Expectancy, Dish, LanguagesJSON, Landlocked, Iso, Independence, Government, North, South, West, East, Elevation, DomainTld, CurrencyName, CurrencyCode, CostLine, Continent, City, CallingCode, Barcode, Height, DefaultLanguageId).ToList().AsQueryable();

            this.OnCountryInsertsInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryInsertsDefaultParams(ref string Name, ref string ShortName, ref string Temperature, ref string Area, ref string Religion, ref string Location, ref string Population, ref string Density, ref string Symbol, ref string Abbreviation, ref string FlagBase64, ref string Expectancy, ref string Dish, ref string LanguagesJSON, ref string Landlocked, ref string Iso, ref string Independence, ref string Government, ref string North, ref string South, ref string West, ref string East, ref string Elevation, ref string DomainTld, ref string CurrencyName, ref string CurrencyCode, ref string CostLine, ref string Continent, ref string City, ref string CallingCode, ref string Barcode, ref string Height, ref int? DefaultLanguageId);

        partial void OnCountryInsertsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryInsert> items);
    }
}
