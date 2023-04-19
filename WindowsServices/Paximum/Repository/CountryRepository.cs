using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;
using Dapper;
using Model.Concrete;
using Dapper.Contrib.Extensions;
    public class CountryRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public CountryRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Country Country)
    {
        try
        {
            return connection.Insert(Country);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Country Country)
    {
        try
        {
       return  connection.Update(Country);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Country Country)
        {
            try
            {
            return  connection.Delete<Country>(Country);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Country> GetAll(){
            try
            {
                return connection.Query<Country>("CountryGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Country> GetByAbbreviation(string Abbreviation){
            try
            {
                return connection.Query<Country>("CountryGetByAbbreviation", new
                {
Abbreviation = Abbreviation
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Country> GetByArea(string Area){
            try
            {
                return connection.Query<Country>("CountryGetByArea", new
                {
Area = Area
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Country> GetByBarcode(string Barcode){
            try
            {
                return connection.Query<Country>("CountryGetByBarcode", new
                {
Barcode = Barcode
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Country> GetByCallingCode(string CallingCode){
            try
            {
                return connection.Query<Country>("CountryGetByCallingCode", new
                {
CallingCode = CallingCode
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Country> GetByCity(string City){
            try
            {
                return connection.Query<Country>("CountryGetByCity", new
                {
City = City
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Country> GetByContinent(string Continent){
            try
            {
                return connection.Query<Country>("CountryGetByContinent", new
                {
Continent = Continent
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Country> GetByCostLine(string CostLine){
            try
            {
                return connection.Query<Country>("CountryGetByCostLine", new
                {
CostLine = CostLine
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Country> GetByCurrencyCode(string CurrencyCode){
            try
            {
                return connection.Query<Country>("CountryGetByCurrencyCode", new
                {
CurrencyCode = CurrencyCode
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Country> GetByCurrencyName(string CurrencyName){
            try
            {
                return connection.Query<Country>("CountryGetByCurrencyName", new
                {
CurrencyName = CurrencyName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Country> GetByDefaultLanguageId(int DefaultLanguageId){
            try
            {
                return connection.Query<Country>("CountryGetByDefaultLanguageId", new
                {
DefaultLanguageId = DefaultLanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Country> GetByDensity(string Density){
            try
            {
                return connection.Query<Country>("CountryGetByDensity", new
                {
Density = Density
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Country> GetByDish(string Dish){
            try
            {
                return connection.Query<Country>("CountryGetByDish", new
                {
Dish = Dish
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Country> GetByDomainTld(string DomainTld){
            try
            {
                return connection.Query<Country>("CountryGetByDomainTld", new
                {
DomainTld = DomainTld
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Country> GetByEast(string East){
            try
            {
                return connection.Query<Country>("CountryGetByEast", new
                {
East = East
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Country> GetByElevation(string Elevation){
            try
            {
                return connection.Query<Country>("CountryGetByElevation", new
                {
Elevation = Elevation
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Country> GetByExpectancy(string Expectancy){
            try
            {
                return connection.Query<Country>("CountryGetByExpectancy", new
                {
Expectancy = Expectancy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Country> GetByFlagBase64(string FlagBase64){
            try
            {
                return connection.Query<Country>("CountryGetByFlagBase64", new
                {
FlagBase64 = FlagBase64
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Country> GetByGovernment(string Government){
            try
            {
                return connection.Query<Country>("CountryGetByGovernment", new
                {
Government = Government
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Country> GetByHasFraudRisk(bool HasFraudRisk){
            try
            {
                return connection.Query<Country>("CountryGetByHasFraudRisk", new
                {
HasFraudRisk = HasFraudRisk
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Country> GetByHasManuelRegistration(bool HasManuelRegistration){
            try
            {
                return connection.Query<Country>("CountryGetByHasManuelRegistration", new
                {
HasManuelRegistration = HasManuelRegistration
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Country> GetByHeight(string Height){
            try
            {
                return connection.Query<Country>("CountryGetByHeight", new
                {
Height = Height
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Country GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Country>("CountryGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Country> GetByIndependence(string Independence){
            try
            {
                return connection.Query<Country>("CountryGetByIndependence", new
                {
Independence = Independence
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Country> GetByIso(string Iso){
            try
            {
                return connection.Query<Country>("CountryGetByIso", new
                {
Iso = Iso
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Country> GetByLandlocked(string Landlocked){
            try
            {
                return connection.Query<Country>("CountryGetByLandlocked", new
                {
Landlocked = Landlocked
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Country> GetByLanguagesJSON(string LanguagesJSON){
            try
            {
                return connection.Query<Country>("CountryGetByLanguagesJSON", new
                {
LanguagesJSON = LanguagesJSON
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Country> GetByLocation(string Location){
            try
            {
                return connection.Query<Country>("CountryGetByLocation", new
                {
Location = Location
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Country> GetByName(string Name){
            try
            {
                return connection.Query<Country>("CountryGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Country> GetByNorth(string North){
            try
            {
                return connection.Query<Country>("CountryGetByNorth", new
                {
North = North
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Country> GetByPopulation(string Population){
            try
            {
                return connection.Query<Country>("CountryGetByPopulation", new
                {
Population = Population
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Country> GetByReligion(string Religion){
            try
            {
                return connection.Query<Country>("CountryGetByReligion", new
                {
Religion = Religion
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Country> GetByShortName(string ShortName){
            try
            {
                return connection.Query<Country>("CountryGetByShortName", new
                {
ShortName = ShortName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Country> GetBySouth(string South){
            try
            {
                return connection.Query<Country>("CountryGetBySouth", new
                {
South = South
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Country> GetBySymbol(string Symbol){
            try
            {
                return connection.Query<Country>("CountryGetBySymbol", new
                {
Symbol = Symbol
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Country> GetByTemperature(string Temperature){
            try
            {
                return connection.Query<Country>("CountryGetByTemperature", new
                {
Temperature = Temperature
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Country> GetByWest(string West){
            try
            {
                return connection.Query<Country>("CountryGetByWest", new
                {
West = West
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
 public void Dispose()
            {
                GC.SuppressFinalize(this);
            }
    }
