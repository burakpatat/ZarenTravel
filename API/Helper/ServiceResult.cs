using System;


[Serializable]
public class ServiceResult
{
    public int ResultCode { get; set; }
    public string ResultMessage { get; set; }
    public ServiceResult()
    {
        ResultCode = 0;
        ResultMessage = "";
    }

    public ServiceResult(int resultCode, string resultMessage)
    {
        ResultCode = resultCode;
        ResultMessage = resultMessage;
    }
}

