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
    public class AgencyUsersRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyUsersRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyUsers AgencyUsers)
    {
        try
        {
            return connection.Insert(AgencyUsers);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyUsers AgencyUsers)
    {
        try
        {
       return  connection.Update(AgencyUsers);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyUsers AgencyUsers)
        {
            try
            {
            return  connection.Delete<AgencyUsers>(AgencyUsers);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyUsers> GetAll(){
            try
            {
                return connection.Query<AgencyUsers>("AgencyUsersGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyUsers> GetBirthDateBetween(DateTime BirthDateStart,DateTime BirthDateEnd){
            try
            {
                return connection.Query<AgencyUsers>("AgencyUsersGetBirthDateBetween", new
                {
BirthDateStart = BirthDateStart
,BirthDateEnd = BirthDateEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyUsers> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<AgencyUsers>("AgencyUsersGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyUsers> GetByBirthDate(DateTime BirthDate){
            try
            {
                return connection.Query<AgencyUsers>("AgencyUsersGetByBirthDate", new
                {
BirthDate = BirthDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyUsers> GetByCountry(int Country){
            try
            {
                return connection.Query<AgencyUsers>("AgencyUsersGetByCountry", new
                {
Country = Country
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyUsers> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<AgencyUsers>("AgencyUsersGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyUsers> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<AgencyUsers>("AgencyUsersGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyUsers> GetByDocumentNumber(string DocumentNumber){
            try
            {
                return connection.Query<AgencyUsers>("AgencyUsersGetByDocumentNumber", new
                {
DocumentNumber = DocumentNumber
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyUsers> GetByEmail(string Email){
            try
            {
                return connection.Query<AgencyUsers>("AgencyUsersGetByEmail", new
                {
Email = Email
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyUsers> GetByExternalCode(string ExternalCode){
            try
            {
                return connection.Query<AgencyUsers>("AgencyUsersGetByExternalCode", new
                {
ExternalCode = ExternalCode
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyUsers> GetByForwardToEmail(string ForwardToEmail){
            try
            {
                return connection.Query<AgencyUsers>("AgencyUsersGetByForwardToEmail", new
                {
ForwardToEmail = ForwardToEmail
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyUsers> GetByGender(int Gender){
            try
            {
                return connection.Query<AgencyUsers>("AgencyUsersGetByGender", new
                {
Gender = Gender
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyUsers GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyUsers>("AgencyUsersGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyUsers> GetByIsB2B(bool IsB2B){
            try
            {
                return connection.Query<AgencyUsers>("AgencyUsersGetByIsB2B", new
                {
IsB2B = IsB2B
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyUsers> GetByIsB2C(bool IsB2C){
            try
            {
                return connection.Query<AgencyUsers>("AgencyUsersGetByIsB2C", new
                {
IsB2C = IsB2C
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyUsers> GetByManagementFeeAmount(decimal ManagementFeeAmount){
            try
            {
                return connection.Query<AgencyUsers>("AgencyUsersGetByManagementFeeAmount", new
                {
ManagementFeeAmount = ManagementFeeAmount
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyUsers> GetByManagementFeeByPercentage(bool ManagementFeeByPercentage){
            try
            {
                return connection.Query<AgencyUsers>("AgencyUsersGetByManagementFeeByPercentage", new
                {
ManagementFeeByPercentage = ManagementFeeByPercentage
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyUsers> GetByManagementFeeCurrencyId(int ManagementFeeCurrencyId){
            try
            {
                return connection.Query<AgencyUsers>("AgencyUsersGetByManagementFeeCurrencyId", new
                {
ManagementFeeCurrencyId = ManagementFeeCurrencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyUsers> GetByName(string Name){
            try
            {
                return connection.Query<AgencyUsers>("AgencyUsersGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyUsers> GetByPassword(string Password){
            try
            {
                return connection.Query<AgencyUsers>("AgencyUsersGetByPassword", new
                {
Password = Password
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyUsers> GetByPhone(string Phone){
            try
            {
                return connection.Query<AgencyUsers>("AgencyUsersGetByPhone", new
                {
Phone = Phone
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyUsers> GetByRemark(string Remark){
            try
            {
                return connection.Query<AgencyUsers>("AgencyUsersGetByRemark", new
                {
Remark = Remark
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyUsers> GetByStatu(int Statu){
            try
            {
                return connection.Query<AgencyUsers>("AgencyUsersGetByStatu", new
                {
Statu = Statu
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyUsers> GetBySurname(string Surname){
            try
            {
                return connection.Query<AgencyUsers>("AgencyUsersGetBySurname", new
                {
Surname = Surname
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyUsers> GetByUserName(string UserName){
            try
            {
                return connection.Query<AgencyUsers>("AgencyUsersGetByUserName", new
                {
UserName = UserName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyUsers> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<AgencyUsers>("AgencyUsersGetCreatedDateBetween", new
                {
CreatedDateStart = CreatedDateStart
,CreatedDateEnd = CreatedDateEnd
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
