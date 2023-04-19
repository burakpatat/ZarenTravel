﻿using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;
using Dapper;
using Model.Concrete;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
public class LanguagesRepository : IDisposable
{
    private SqlConnection connection;
    private readonly string strConnString;
    private IConfiguration configuration;

    public LanguagesRepository()
    {
        strConnString = configuration.GetSection("ConnectionString").Value;
        connection = new SqlConnection(strConnString);
    }
    public long Insert(Languages Languages)
    {
        try
        {
            return connection.Insert(Languages);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Update(Languages Languages)
    {
        try
        {
            return connection.Update(Languages);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Delete(Languages Languages)
    {
        try
        {
            return connection.Delete<Languages>(Languages);
        }
        catch (Exception)
        {
            return false;
        }
    }
    public List<Languages> GetAll()
    {
        try
        {
            return connection.Query<Languages>("LanguagesGetAll", commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public Languages GetByID(int Id)
    {
        try
        {
            return connection.QueryFirstOrDefault<Languages>("LanguagesGetByID", new
            {
                Id = Id
            }, commandType: CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Languages> GetByLanguageCode(string LanguageCode)
    {
        try
        {
            return connection.Query<Languages>("LanguagesGetByLanguageCode", new
            {
                LanguageCode = LanguageCode
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Languages> GetByLanguageName(string LanguageName)
    {
        try
        {
            return connection.Query<Languages>("LanguagesGetByLanguageName", new
            {
                LanguageName = LanguageName
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
