using System;


public class LogModel
{
    public Guid Id { get; set; }
    public long? UserId { get; set; }
    public string Request { get; set; }
    public string Method { get; set; }
    public int ResponseCode { get; set; }
    public string Response { get; set; }
    public string Url { get; set; }
    public string Ip { get; set; }
    public string UserAgent { get; set; }
    public Guid? UniqId { get; set; }
    public DateTime? RequestDate { get; set; }
    public DateTime? ResponseDate { get; set; }
    public int? Duration { get; set; }
}