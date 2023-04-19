using System;


[Serializable]
public class ServiceResponse<T>
{
    public ServiceResult Result { get; set; }

    public T ReturnObject { get; set; }

    public ServiceResponse()
    {
        Result = new ServiceResult(0, "");
    }

    public ServiceResponse(Exception ex)
    {

        if (ex != null)
        {
            string message = string.Empty;
            message = message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += string.Format("Message: {0}", ex.Message);
            message += Environment.NewLine;
            message += string.Format("StackTrace: {0}", ex.StackTrace);
            message += Environment.NewLine;
            message += string.Format("Source: {0}", ex.Source);
            message += Environment.NewLine;
            message += string.Format("TargetSite: {0}", ex.TargetSite?.ToString());
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += ex.InnerException?.Message;
            message += Environment.NewLine;
            Result = new ServiceResult(-1, message);
        }
    }

    public ServiceResponse(int resultCode, string resultMessage)
    {
        Result = new ServiceResult(resultCode, resultMessage);
    }

    public ServiceResponse(int resultCode, string resultMessage, T returnObject)
    {
        Result = new ServiceResult(resultCode, resultMessage);
        ReturnObject = returnObject;
    }

    public ServiceResponse(T returnObject)
    {
        ReturnObject = returnObject;
        Result = new ServiceResult(0, "");
    }
}

[Serializable]
public class ServiceResponse
{
    public ServiceResult Result { get; set; }

    public ServiceResponse()
    {
        Result = new ServiceResult(0, "");
    }

    public ServiceResponse(Exception ex)
    {
        if (ex != null)
        {
            string message = string.Empty;
            message = message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += string.Format("Message: {0}", ex.Message);
            message += Environment.NewLine;
            message += string.Format("StackTrace: {0}", ex.StackTrace);
            message += Environment.NewLine;
            message += string.Format("Source: {0}", ex.Source);
            message += Environment.NewLine;
            message += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Inner Exception: {0}", ex.InnerException?.Message.ToString());
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            Result = new ServiceResult(-1, message);
        }
    }

    public ServiceResponse(int resultCode, string resultMessage)
    {
        Result = new ServiceResult(resultCode, resultMessage);
    }
}
