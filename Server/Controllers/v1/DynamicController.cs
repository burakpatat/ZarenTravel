using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model.Concrete;
using System.IO;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using Newtonsoft.Json;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using OfficeOpenXml;
using WordyWellHero.Server.Controllers;
using SqlBuilder = WordyWell.Api.Helper.SqlBuilder;

[Produces("application/json", "application/xml")]
[ProducesResponseType(500)]
[Route("[controller]")]
public class DynamicController : BaseApiController<DynamicController>
{

    private readonly string _environment;
    private const string _prodEnvironment = "PROD";
    private readonly string _MethodPath;
    private readonly string _Type;
    private readonly string _key;
    private readonly string _strConnString;
    private readonly string _tblconfig;
    private readonly SqlConnection connection = new SqlConnection();
    private IDistributedCache _cache;
    private static DatabaseHelper helper;



    public DynamicController(IConfiguration configuration, IDistributedCache cache)
    {
        _strConnString = MyConfiguration.Configuration.GetConnectionString("DefaultConnection");
        connection = new SqlConnection(_strConnString);
        _cache = cache;
        _environment = MyConfiguration.Configuration.GetSection("Env").Value;
        _key = MyConfiguration.Configuration.GetSection("ApiKey").Value;
        _MethodPath = MyConfiguration.Configuration.GetSection("MethodPath").Value;
        _Type = MyConfiguration.Configuration.GetSection("Type").Value;
        _tblconfig = MyConfiguration.Configuration.GetSection("TableConfiguration").Value;
        helper = new DatabaseHelper();

    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="table"></param>
    /// <param name="RequestMethod"></param>
    /// <returns></returns>
    [HttpPut]

    [Route("update/{table}")]
    public async Task<ActionResult<ServiceResponse<dynamic>>> Put(string table, [FromBody] Dictionary<string, object?> Columns, [FromHeader] string key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        ServiceResponse<dynamic> response = new ServiceResponse<dynamic>();
        if (key == null || (key != null && key != _key))
        {
            response = new ServiceResponse<dynamic>("No key");
            return response;
        }

        try
        {
            Dictionary<string, object> newVals = new Dictionary<string, object>();
            string filePathDomain = Path.Combine(_tblconfig, table + "\\" + "config.json");
            var tableConfig = JsonConvert.DeserializeObject<Table>(System.IO.File.ReadAllText(filePathDomain));
            foreach (var item in tableConfig.Columns)
            {
                foreach (var itemdic in Columns)
                {
                    if (item.ColumnName.ToLowerInvariant() == itemdic.Key.ToLowerInvariant())
                    {
                        if (item.DbType.ReturnNetType().ToLowerInvariant() == "string")
                            newVals.Add(item.ColumnName, itemdic.Value.ToString());
                        else if (item.DbType.ReturnNetType().ToLowerInvariant() == "bool")
                            newVals.Add(item.ColumnName, itemdic.Value.ToBool());
                        else if (item.DbType.ReturnNetType().ToLowerInvariant() == "datetime")
                            newVals.Add(item.ColumnName, Convert.ToDateTime(itemdic.Value));
                        else if (item.DbType.ReturnNetType().ToLowerInvariant() == "datetimeoffset")
                            newVals.Add(item.ColumnName, itemdic.Value.ToString());
                        else if (item.DbType.ReturnNetType().ToLowerInvariant().Contains("date"))
                            newVals.Add(item.ColumnName, Convert.ToDateTime(itemdic.Value));
                        else if (item.DbType.ReturnNetType().ToLowerInvariant() == "decimal")
                            newVals.Add(item.ColumnName, itemdic.Value.ToDecimal());
                        else if (item.DbType.ReturnNetType().ToLowerInvariant() == "guid")
                            newVals.Add(item.ColumnName, new Guid(itemdic.Value.ToString()));
                        else if (item.DbType.ReturnNetType().ToLowerInvariant() == "int")
                            newVals.Add(item.ColumnName, itemdic.Value.ToInt32());
                        else if (item.DbType.ReturnNetType().ToLowerInvariant() == "long")
                            newVals.Add(item.ColumnName, itemdic.Value.ToInt64());
                        else if (item.DbType.ReturnNetType().ToLowerInvariant() == "small")
                            newVals.Add(item.ColumnName, itemdic.Value.ToInt16());
                        else if (item.DbType.ReturnNetType().ToLowerInvariant() == "float")
                            newVals.Add(item.ColumnName, Convert.ToDecimal(itemdic.Value));
                        else if (item.DbType.ReturnNetType().ToLowerInvariant() == "object")
                            newVals.Add(item.ColumnName, itemdic.Value);
                        else
                            newVals.Add(item.ColumnName, itemdic.Value);
                    }
                }

            }

            var _response = connection.Query(table + "Update", newVals, commandType: CommandType.StoredProcedure);
            response = new ServiceResponse<dynamic>(_response);

        }
        catch (Exception ex)
        {
            response = new ServiceResponse<dynamic>(ex);
        }
        return response;
    }



    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <param name="where"></param>
    /// <param name="Scheme"></param>
    /// <returns></returns>
    [ProducesResponseType(typeof(List<Table>), 200)]
    [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
    [HttpPost]
    [Route("info/byschema")]
    public async Task<ActionResult<ServiceResponse<List<Table>>>> DefiningServer([FromHeader] string key, [FromHeader] string where)
    {
        ServiceResponse<List<Table>> response = new ServiceResponse<List<Table>>();
        if (key == null || (key != null && key != _key))
        {
            response = new ServiceResponse<List<Table>>(new Exception("No Key"));

        }
        await Task.Run(async () =>
        {
            var encKey = Request.HttpContext.Connection.RemoteIpAddress.ToString().ClearTextFilterForJson();
            string strConnection = EncryptionHelper.DecryptData(where, encKey);
            var result = await helper.GetAllTablesAsync();

            response = new ServiceResponse<List<Table>>();
        }).ConfigureAwait(continueOnCapturedContext: false);

        return response;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="table"></param>
    /// <param name="key"></param> 
    /// <returns></returns>
    [HttpPost]
    [Route("info/bytable/{table}")]
    public async Task<ActionResult<ServiceResponse<List<Table>>>> SchemeTable(string table, [FromHeader] string key)
    {
        ServiceResponse<List<Table>> response = new ServiceResponse<List<Table>>();
        if (key == null || (key != null && key != _key))
        {
            response = new ServiceResponse<List<Table>>(new Exception("No Key"));
            return response;
        }


        response = new ServiceResponse<List<Table>>((await helper.GetAllTablesAsync()).Where(a => a.TableName == table).ToList());
        return response;
    }



    /// <summary>
    /// 
    /// </summary>
    /// <param name="table"></param>
    /// <param name="Columns"></param>
    /// <param name="key"></param> 
    /// <returns></returns>
    [HttpPost]
    [Route("insert/{table}")]
    public async Task<ActionResult<ServiceResponse<dynamic>>> Post(string table, [FromBody] Dictionary<string, object?> Columns, [FromHeader] string key)
    {
        ServiceResponse<dynamic> response = new ServiceResponse<dynamic>();
        if (key == null || (key != null && key != _key))
            return new ServiceResponse<dynamic>(new Exception("No Key"));
        Dictionary<string, object> newVals = new Dictionary<string, object>();
        try
        {
            var encKey = Request.HttpContext.Connection.RemoteIpAddress.ToString().ClearTextFilterForJson();
            string strConnection = EncryptionHelper.DecryptData(key, encKey);

            foreach (var item in helper.GetColumnsByTable(table).Where(a => a.IsPrimary != true))
            {
                foreach (var itemdic in Columns)
                {
                    if (item.ColumnName.ToLowerInvariant() == itemdic.Key.ToLowerInvariant())
                    {
                        if (item.DbType.ReturnNetType().ToLowerInvariant() == "string")
                            newVals.Add(item.ColumnName, itemdic.Value.ToString());
                        else if (item.DbType.ReturnNetType().ToLowerInvariant() == "bool")
                            newVals.Add(item.ColumnName, itemdic.Value.ToBool());
                        else if (item.DbType.ReturnNetType().ToLowerInvariant() == "datetime")
                            newVals.Add(item.ColumnName, Convert.ToDateTime(itemdic.Value));
                        else if (item.DbType.ReturnNetType().ToLowerInvariant() == "datetimeoffset")
                            newVals.Add(item.ColumnName, itemdic.Value.ToString());
                        else if (item.DbType.ReturnNetType().ToLowerInvariant().Contains("date"))
                            newVals.Add(item.ColumnName, Convert.ToDateTime(itemdic.Value));
                        else if (item.DbType.ReturnNetType().ToLowerInvariant() == "decimal")
                            newVals.Add(item.ColumnName, itemdic.Value.ToDecimal());
                        else if (item.DbType.ReturnNetType().ToLowerInvariant() == "guid")
                            newVals.Add(item.ColumnName, new Guid(itemdic.Value.ToString()));
                        else if (item.DbType.ReturnNetType().ToLowerInvariant() == "int")
                            newVals.Add(item.ColumnName, itemdic.Value.ToInt32());
                        else if (item.DbType.ReturnNetType().ToLowerInvariant() == "long")
                            newVals.Add(item.ColumnName, itemdic.Value.ToInt64());
                        else if (item.DbType.ReturnNetType().ToLowerInvariant() == "small")
                            newVals.Add(item.ColumnName, itemdic.Value.ToInt16());
                        else if (item.DbType.ReturnNetType().ToLowerInvariant() == "float")
                            newVals.Add(item.ColumnName, Convert.ToDecimal(itemdic.Value));
                        else if (item.DbType.ReturnNetType().ToLowerInvariant() == "object")
                            newVals.Add(item.ColumnName, itemdic.Value);
                        else
                            newVals.Add(item.ColumnName, itemdic.Value);
                    }
                }

            }

            var _response = await connection.QueryAsync(table + "Insert", newVals, commandType: CommandType.StoredProcedure);
            response = new ServiceResponse<dynamic>(_response);
            return response;
        }
        catch (Exception ex)
        {
            return new ServiceResponse<dynamic>(ex);
        }
    }


    /// <summary>
    /// Generate New Procedure from existing table
    /// </summary>
    /// <param name="procedure"></param>
    /// <param name="Columns"></param>
    /// <param name="key"></param> 
    /// <returns></returns>
    [HttpPost]
    [Route("run/{procedure}")]
    public async Task<ActionResult<ServiceResponse<dynamic>>> RunPostProcedure(string procedure, [FromBody] Dictionary<string, object?> Columns, [FromHeader] string key)
    {

        ServiceResponse<dynamic> response = new ServiceResponse<dynamic>();
        if (key == null || (key != null && key != _key))
            return new ServiceResponse<dynamic>(new Exception("No Key"));
        Dictionary<string, object> newVals = new Dictionary<string, object>();
        try
        {
            if (Columns.Count > 0)
            {
                var parameters = await helper.GetRequestParamsForProcedure(procedure);
                foreach (var item in parameters)
                {
                    item.ColumnName = item.ColumnName.TrimStart('@');
                    foreach (var itemdic in Columns)
                    {
                        if (item.ColumnName.ToLowerInvariant() == itemdic.Key.ToLowerInvariant())
                        {
                            if (item.DbType.ReturnNetType().ToLowerInvariant() == "string")
                                newVals.Add(item.ColumnName, itemdic.Value.ToString());
                            else if (item.DbType.ReturnNetType().ToLowerInvariant() == "bool")
                                newVals.Add(item.ColumnName, itemdic.Value.ToBool());
                            else if (item.DbType.ReturnNetType().ToLowerInvariant() == "datetime")
                                newVals.Add(item.ColumnName, Convert.ToDateTime(itemdic.Value));
                            else if (item.DbType.ReturnNetType().ToLowerInvariant() == "datetimeoffset")
                                newVals.Add(item.ColumnName, itemdic.Value.ToString());
                            else if (item.DbType.ReturnNetType().ToLowerInvariant().Contains("date"))
                                newVals.Add(item.ColumnName, Convert.ToDateTime(itemdic.Value));
                            else if (item.DbType.ReturnNetType().ToLowerInvariant() == "decimal")
                                newVals.Add(item.ColumnName, itemdic.Value.ToDecimal());
                            else if (item.DbType.ReturnNetType().ToLowerInvariant() == "guid")
                                newVals.Add(item.ColumnName, new Guid(itemdic.Value.ToString()));
                            else if (item.DbType.ReturnNetType().ToLowerInvariant() == "int")
                                newVals.Add(item.ColumnName, itemdic.Value.ToInt32());
                            else if (item.DbType.ReturnNetType().ToLowerInvariant() == "long")
                                newVals.Add(item.ColumnName, itemdic.Value.ToInt64());
                            else if (item.DbType.ReturnNetType().ToLowerInvariant() == "small")
                                newVals.Add(item.ColumnName, itemdic.Value.ToInt16());
                            else if (item.DbType.ReturnNetType().ToLowerInvariant() == "float")
                                newVals.Add(item.ColumnName, Convert.ToDecimal(itemdic.Value));
                            else if (item.DbType.ReturnNetType().ToLowerInvariant() == "object")
                                newVals.Add(item.ColumnName, itemdic.Value);
                            else
                                newVals.Add(item.ColumnName, itemdic.Value);
                        }
                    }
                }

                var _response = await connection.QueryAsync(procedure, newVals, commandType: CommandType.StoredProcedure);
                response = new ServiceResponse<dynamic>(_response);
                return response;
            }
            else
            {
                var _response = await connection.QueryAsync(procedure, commandType: CommandType.StoredProcedure);
                response = new ServiceResponse<dynamic>(_response);
                return response;
            }

        }
        catch (Exception ex)
        {
            return response = new ServiceResponse<dynamic>(ex);
        }
    }



    /// <summary>
    /// 
    /// </summary>
    /// <param name="table"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("data/{table}")]
    public async Task<ActionResult<ServiceResponse<dynamic>>> Data(string table, [FromHeader] string key)
    {

        ServiceResponse<dynamic> response = new ServiceResponse<dynamic>();
        if (key == null || key != null && key != _key)
            return response;
        try
        {
            response = new ServiceResponse<dynamic>(await connection.QueryAsync(" select top 10 * from " + table));
        }
        catch (Exception ex)
        {
            response = new ServiceResponse<dynamic>(ex);

        }
        return response;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="table"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("get/{table}/{id}")]
    public async Task<ActionResult<string>> GetByPrimary(string table, string id)
    {
        ServiceResponse<dynamic> response = new ServiceResponse<dynamic>();
        string filePathDomain = Path.Combine(_tblconfig, table + "\\" + "config.json");
        var tableConfig = JsonConvert.DeserializeObject<Table>(System.IO.File.ReadAllText(filePathDomain));
        if (tableConfig != null)
        {

            try
            {
                var hasPrimary = tableConfig.Columns.Where(a => a.IsPrimary.ToBool()).FirstOrDefault();
                if (hasPrimary != null)
                    response = new ServiceResponse<dynamic>(await connection.QueryAsync(" select top 1 * from " + table + " where " + hasPrimary.ColumnName + "=" + id));
                else
                    response = new ServiceResponse<dynamic>(await connection.QueryAsync(" select  top 1 *  from " + table + " where Id=" + id));


                return response.ToJson();
            }
            catch { }
        }
        return response.ToJson();
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="table"></param>
    /// <param name="key"></param>
    /// <param name="QueryStrings"></param>
    /// <param name="Columns"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("list/{table}/pager")]
    public async Task<ActionResult<ServiceResponse<dynamic>>> GetDapperPager(string table, [FromHeader] string key, [FromQuery] QueryStringsVisible QueryStrings, [FromBody] Dictionary<string, object?> Columns)
    {
        ServiceResponse<dynamic> response = new ServiceResponse<dynamic>();
        if (key != null && key == _key)
        {
            var builder = new SqlBuilder();
            var selectTemplate = builder.AddTemplate(@"select X.* from ( select us.*, ROW_NUMBER() OVER (/**orderby**/) AS RowNumber from dbo." + table + " us /**where**/  ) as X where RowNumber between @start and @finish", new { QueryStrings.Start, QueryStrings.Finish });

            foreach (var item in Columns)
            {
                if (item.Value != null)
                    builder.Where("t." + item.Key + " = " + item.Value);
            }
            builder.OrderBy(string.Format("t.id {0}", QueryStrings.OrderDesc ? "desc" : "asc"));

            try
            {
                response = new ServiceResponse<dynamic>(await connection.QueryAsync(selectTemplate.RawSql, selectTemplate.Parameters));

            }
            catch (Exception ex)
            {
                response = new ServiceResponse<dynamic>(ex);
            }
        }
        return response;
    }




    /// <summary>
    /// 
    /// </summary>
    /// <param name="RequestMethod"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("header")]
    public async Task<ActionResult<ServiceResponse<dynamic>>> RunWithHeader([FromBody] RequestMethod RequestMethod)
    {
        string q = "";
        ServiceResponse<dynamic> response = new ServiceResponse<dynamic>();
        try
        {
            foreach (var item in RequestMethod.Method.HeaderParameters)
            {
                if (Request.Headers[item.Key].ToString() != null && Request.Headers[item.Key].ToString() != "")
                {
                    if (item.Value != "" && item.Value.Contains("q."))
                        q += item.Value.Replace("q.", "");

                    if (item.Value != "" && item.Value.Contains("JWT."))
                        q += item.Value.Replace("JWT.", "");
                }
            }
            var user = Request.Headers["X-REQUEST-ID"];

            var user2 = Request.Headers["X-REQUEST-ID"];

            var userLangs = "tr";
            if (Request.Headers["Accept-Language"] != "")
                userLangs = Request.Headers["Accept-Language"];

            var _response = await connection.QueryAsync(RequestMethod.Method.Name, RequestMethod.Method.Request, commandType: CommandType.StoredProcedure);
            response = new ServiceResponse<dynamic>(_response);
        }
        catch (Exception ex)
        {
            response = new ServiceResponse<dynamic>(ex);
        }

        return response;
    }


    /// <summary>
    /// Run a Query and save procedure
    /// </summary>
    /// <param name="RequestMethod"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("run-it")]
    public async Task<ActionResult<ServiceResponse<dynamic>>> RunQuery([FromBody] RequestMethod RequestMethod)
    {
        ServiceResponse<dynamic> response = new ServiceResponse<dynamic>();
        if (RequestMethod.Key != null && RequestMethod.Key == _key)
        {
            try
            {
                if (_environment != _prodEnvironment && RequestMethod.Method.IsMagic)
                {
                    helper.GenerateProcedure(RequestMethod);

                    RequestMethod.Method.Query = helper.GenerateProcedureQuery(RequestMethod);

                    string filePathDomain = Path.Combine(_MethodPath, RequestMethod.Method.Name.ClearTextFilterForJson() + ".json");
                    await System.IO.File.WriteAllTextAsync(filePathDomain, JsonConvert.SerializeObject(RequestMethod));
                }

                var _response = await connection.QueryAsync(RequestMethod.Method.Query, commandType: CommandType.Text);
                response = new ServiceResponse<dynamic>(_response);

            }
            catch (Exception ex)
            {
                response = new ServiceResponse<dynamic>(ex);

            }
        }
        return response;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="RequestMethod"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("create-procedure")]
    public async Task<ActionResult<string>> QueryNewSp([FromBody] RequestMethod RequestMethod)
    {
        ServiceResponse<dynamic> response = new ServiceResponse<dynamic>();
        if (RequestMethod.Key != null && RequestMethod.Key == _key)
        {
            try
            {
                helper.GenerateProcedure(RequestMethod);
                string filePathDomain = Path.Combine(_MethodPath, RequestMethod.Method.Name + ".json");
                RequestMethod.Method.Query = helper.GenerateProcedureQuery(RequestMethod);
                await System.IO.File.WriteAllTextAsync(filePathDomain, JsonConvert.SerializeObject(RequestMethod));
                response = new ServiceResponse<dynamic>(JsonConvert.SerializeObject(RequestMethod));
                return response.ToJson();
            }
            catch (Exception ex)
            {
                response = new ServiceResponse<dynamic>(ex.ToJson());

            }
        }
        return response.ToJson();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="RequestMethod"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("create-and-run")]
    public async Task<ActionResult<string>> CreateAndRunProcedure([FromBody] RequestMethod RequestMethod)
    {
        ServiceResponse<dynamic> response = new ServiceResponse<dynamic>();
        if (RequestMethod.Key != null && RequestMethod.Key == _key)
        {
            try
            {
                if (RequestMethod.Method.Name != "" && (RequestMethod.Method.Request != null || RequestMethod.Method.Response != null))
                {
                    helper.GenerateProcedure(RequestMethod);
                    string filePathDomain = Path.Combine(_MethodPath, RequestMethod.Method.Name + ".json");
                    RequestMethod.Method.Query = helper.GenerateProcedureQuery(RequestMethod);
                    await System.IO.File.WriteAllTextAsync(filePathDomain, JsonConvert.SerializeObject(RequestMethod));
                    response = new ServiceResponse<dynamic>(JsonConvert.SerializeObject(RequestMethod));
                }
                return response.ToJson();
            }
            catch (Exception ex)
            {
                response = new ServiceResponse<dynamic>(ex.ToJson());

            }
        }
        return response.ToJson();

    }

    /// <summary>
    /// Run a Query and save procedure
    /// </summary>
    /// <param name="RequestMethod"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("run-procedure/{procedure}")]
    public async Task<ActionResult<ServiceResponse<dynamic>>> runProcedure(string procedure, [FromHeader] string key, [FromBody] Dictionary<string, object?> Columns)
    {
        ServiceResponse<dynamic> response = new ServiceResponse<dynamic>();
        if (key != null && key == _key)
        {
            try
            {
                var _response = await connection.QueryAsync(procedure, Columns, commandType: CommandType.StoredProcedure);
                response = new ServiceResponse<dynamic>(_response);
                return response;
            }
            catch
            {

            }
        }

        return response;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("upload")]
    public async Task<ActionResult<ServiceResponse<string>>> UploadAsync([FromForm] Upload request)
    {
        string permissionListForMimeTypes = MyConfiguration.Configuration.GetSection("AllowedFiles").Value;
        string allowedMaxSize = MyConfiguration.Configuration.GetSection("ContentLengthLimit").Value;
        string localPath = MyConfiguration.Configuration.GetSection("FileUploadFolder").Value;
        string serverPath = MyConfiguration.Configuration.GetSection("FileUploadFolderDomain").Value;
        string uiPath = MyConfiguration.Configuration.GetSection("UIPathFile").Value;
        string environment = MyConfiguration.Configuration.GetSection("Env").Value;

        if (request == null || request.File == null || request.File.Length <= 0)
        {
            return StatusCode(Constants.ErrorResultCode, "File null");
        }

        if (!permissionListForMimeTypes.Contains(request.File.ContentType))
        {
            return StatusCode(Constants.ErrorResultCode, "Geçersiz veri tipi, video ya da image formatında yükleme yapınız. Type: " + request.File.ContentType);
        }

        try
        {
            long fileSize = request.File.Length;
            if (allowedMaxSize != null && Convert.ToDouble(allowedMaxSize) > 0)
            {
                if (Convert.ToDouble(allowedMaxSize) < fileSize.ConvertBytesToMegabytes())
                {
                    return StatusCode(Constants.ErrorResultCode, "Maximum dosya boyutu 150 MB olabilir: " + fileSize.ConvertBytesToMegabytes());
                }
            }
            else
            {
                if (150 < fileSize.ConvertBytesToMegabytes())
                {
                    return StatusCode(Constants.ErrorResultCode, "Maximum dosya boyutu 150 MB olabilir: " + fileSize.ConvertBytesToMegabytes());
                }
            }

            string format = Path.GetExtension(request.File.FileName);
            string name = string.Concat(Guid.NewGuid().ToString(), format);
            if (environment != _prodEnvironment)
            {
                string filePath = Path.Combine(localPath, name);
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    await request.File.CopyToAsync(stream);
                }

                return StatusCode(Constants.SuccessResultCode, new ServiceResponse<string>(uiPath + name));
            }
            else
            {
                string filePathDomain = Path.Combine(serverPath, name);
                using (FileStream stream = new FileStream(filePathDomain, FileMode.Create))
                {
                    await request.File.CopyToAsync(stream);
                }

                return StatusCode(Constants.SuccessResultCode, new ServiceResponse<string>(uiPath + name));
            }
        }
        catch (Exception ex)
        {
            ServiceResult Result = new ServiceResult
            {
                ResultCode = -1
            };
            if (_environment != _prodEnvironment)
            {
                Result.ResultMessage = ex.Message;
            }
            else
            {
                Result.ResultMessage = "Beklenmedik bir hata oluştu.";
            }

            return StatusCode(200, new ServiceResponse<ServiceResult>(Result));
        }
    }



    [HttpPost]
    [Route("encrypt")]
    public async Task<ActionResult<ServiceResponse<List<string>>>> EncryptData([FromHeader] string key)
    {
        List<string> userList = new List<string>();
        string localPath = MyConfiguration.Configuration.GetSection("KeyPath").Value;
        var encKey = Request.HttpContext.Connection.RemoteIpAddress.ToString().ClearTextFilterForJson();

        if (_cache.GetString(encKey) == null)
        {
            userList.Add(EncryptionHelper.EncryptData(key, encKey));
            _cache.SetString(encKey, userList.ToJson());
        }
        else
        {
            var existingList = _cache.GetString(encKey).FromJson() as List<string>;
            userList.Add(EncryptionHelper.EncryptData(key, encKey));
            userList.AddRange(existingList);
        }

        string filePath = Path.Combine(localPath, encKey + ".json");
        System.IO.File.WriteAllText(filePath, userList.ToJson());
        ServiceResponse<List<string>> response = new ServiceResponse<List<string>>(userList);

        return response;
    }



    /// <summary>
    /// 
    /// </summary>
    /// <param name="SendOffer"></param>
    /// <returns></returns>
    [AcceptVerbs("POST")]
    [Route("export/{ExportType}")]
    public IActionResult ExportToUrl(Dictionary<string, object?> rowJKeyAndValue, int exportType, string sheetName, string filename = "")
    {
        string uiPath = MyConfiguration.Configuration.GetSection("UIPathFile").Value;
        string returnUrl = "";
        string localPath = MyConfiguration.Configuration.GetSection("FileUploadFolder").Value;
        string serverPath = MyConfiguration.Configuration.GetSection("FileUploadFolderDomain").Value;
        string environment = MyConfiguration.Configuration.GetSection("Env").Value;
        var templateFileInfo = new FileInfo(Path.Combine(serverPath, filename + ".xlsx"));
        if (environment != _prodEnvironment)
            templateFileInfo = new FileInfo(Path.Combine(localPath, filename + ".xlsx"));
        Stream stream = new MemoryStream();

        if (exportType == 1)
        {
            using (var xlPackage = new ExcelPackage(templateFileInfo))
            {
                var worksheet = xlPackage.Workbook.Worksheets[sheetName];

                string filepath = "";

                foreach (var item in rowJKeyAndValue)
                {
                    worksheet.Cells[item.Key].Value = item.Value;
                }

                xlPackage.SaveAs(stream);
                stream.Position = 0;
                using (FileStream fs = new FileStream(filepath, FileMode.Create))
                {
                    stream.CopyTo(fs);
                }
            }
            return StatusCode(200, new ServiceResponse<string>(returnUrl));
        }
        else
        {
            // var f = File(null.ToStreamReport<object>(ReportTypes.PdfReport), "application/pdf", filename + ".pdf");

            return StatusCode(200, new ServiceResponse<string>(Path.Combine(localPath, filename + ".pdf")));
        }
    }



}
