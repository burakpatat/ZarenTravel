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
    public class UsersRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public UsersRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Users Users)
    {
        try
        {
            return connection.Insert(Users);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Users Users)
    {
        try
        {
       return  connection.Update(Users);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Users Users)
        {
            try
            {
            return  connection.Delete<Users>(Users);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Users> GetAll(){
            try
            {
                return connection.Query<Users>("UsersGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Users> GetBirthDateBetween(DateTime BirthDateStart,DateTime BirthDateEnd){
            try
            {
                return connection.Query<Users>("UsersGetBirthDateBetween", new
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
public List<Users> GetByBirthDate(DateTime BirthDate){
            try
            {
                return connection.Query<Users>("UsersGetByBirthDate", new
                {
BirthDate = BirthDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Users> GetByBirthPlace(string BirthPlace){
            try
            {
                return connection.Query<Users>("UsersGetByBirthPlace", new
                {
BirthPlace = BirthPlace
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Users> GetByCreateDate(DateTime CreateDate){
            try
            {
                return connection.Query<Users>("UsersGetByCreateDate", new
                {
CreateDate = CreateDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Users> GetByEmail(string Email){
            try
            {
                return connection.Query<Users>("UsersGetByEmail", new
                {
Email = Email
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Users> GetByGender(int Gender){
            try
            {
                return connection.Query<Users>("UsersGetByGender", new
                {
Gender = Gender
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Users> GetByGovernmentID(string GovernmentID){
            try
            {
                return connection.Query<Users>("UsersGetByGovernmentID", new
                {
GovernmentID = GovernmentID
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Users GetByID(int ID){
            try
            {
                return connection.QueryFirstOrDefault<Users>("UsersGetByID", new
                {
ID = ID
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Users> GetByIsMaster(bool IsMaster){
            try
            {
                return connection.Query<Users>("UsersGetByIsMaster", new
                {
IsMaster = IsMaster
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Users> GetByIsSuperAdmin(bool IsSuperAdmin){
            try
            {
                return connection.Query<Users>("UsersGetByIsSuperAdmin", new
                {
IsSuperAdmin = IsSuperAdmin
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Users> GetByMaritalStatus(int MaritalStatus){
            try
            {
                return connection.Query<Users>("UsersGetByMaritalStatus", new
                {
MaritalStatus = MaritalStatus
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Users> GetByMotherName(string MotherName){
            try
            {
                return connection.Query<Users>("UsersGetByMotherName", new
                {
MotherName = MotherName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Users> GetByName(string Name){
            try
            {
                return connection.Query<Users>("UsersGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Users> GetByPassword(string Password){
            try
            {
                return connection.Query<Users>("UsersGetByPassword", new
                {
Password = Password
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Users> GetByProducts(int Products){
            try
            {
                return connection.Query<Users>("UsersGetByProducts", new
                {
Products = Products
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Users> GetByStatus(int Status){
            try
            {
                return connection.Query<Users>("UsersGetByStatus", new
                {
Status = Status
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Users> GetBySurname(string Surname){
            try
            {
                return connection.Query<Users>("UsersGetBySurname", new
                {
Surname = Surname
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Users> GetByUserName(string UserName){
            try
            {
                return connection.Query<Users>("UsersGetByUserName", new
                {
UserName = UserName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Users> GetByUserType(int UserType){
            try
            {
                return connection.Query<Users>("UsersGetByUserType", new
                {
UserType = UserType
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Users> GetCreateDateBetween(DateTime CreateDateStart,DateTime CreateDateEnd){
            try
            {
                return connection.Query<Users>("UsersGetCreateDateBetween", new
                {
CreateDateStart = CreateDateStart
,CreateDateEnd = CreateDateEnd
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
