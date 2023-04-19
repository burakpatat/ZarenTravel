using System;


public class UserPolicy
{


    private long? _UserId;

    public long? UserId
    {
        get { return _UserId; }
        set { _UserId = value; }
    }
    private string _Name;

    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }
    private string _Surname;

    public string Surname
    {
        get { return _Surname; }
        set { _Surname = value; }
    }

    private string _UserName;

    public string UserName
    {
        get { return _UserName; }
        set { _UserName = value; }
    }
    private bool? _IsVerified;

    public bool? IsVerified
    {
        get { return _IsVerified; }
        set { _IsVerified = value; }
    }
    private string _Language;

    public string Language
    {
        get { return _Language; }
        set { _Language = value; }
    }
    private bool? _IsDeleted;

    public bool? IsDeleted
    {
        get { return _IsDeleted; }
        set { _IsDeleted = value; }
    }
    private Guid? _Guid;

    public Guid? Guid
    {
        get { return _Guid; }
        set { _Guid = value; }
    }

    private DateTime? _CreatedDate;

    public DateTime? CreatedDate
    {
        get { return _CreatedDate; }
        set { _CreatedDate = value; }
    }
    private bool? _HasSentNotifyOnComment;

    public bool? HasSentNotifyOnComment
    {
        get { return _HasSentNotifyOnComment; }
        set { _HasSentNotifyOnComment = value; }
    }

    private int? _RoleCategory;

    public int? RoleCategory
    {
        get { return _RoleCategory; }
        set { _RoleCategory = value; }
    }
    private int? _RoleId;

    public int? RoleId
    {
        get { return _RoleId; }
        set { _RoleId = value; }
    }
    private string _Password;

    public string Password
    {
        get { return _Password; }
        set { _Password = value; }
    }
    private DateTime? _Birthday;

    public DateTime? Birthday
    {
        get { return _Birthday; }
        set { _Birthday = value; }
    }
    private string _PhoneNumber;

    public string PhoneNumber
    {
        get { return _PhoneNumber; }
        set { _PhoneNumber = value; }
    }
    private string _Email;

    public string Email
    {
        get { return _Email; }
        set { _Email = value; }
    }
    private int? _Currency;

    public int? Currency
    {
        get { return _Currency; }
        set { _Currency = value; }
    }
    private string _GoogleId;

    public string GoogleId
    {
        get { return _GoogleId; }
        set { _GoogleId = value; }
    }
    private string _AppleId;

    public string AppleId
    {
        get { return _AppleId; }
        set { _AppleId = value; }
    }
    private int? _CountryId;

    public int? CountryId
    {
        get { return _CountryId; }
        set { _CountryId = value; }
    }

    public string EncryptKey { get; internal set; }
    public string UserIP { get; internal set; }
    public string UserAgent { get; internal set; }
    public DateTime Start { get; internal set; }
    public bool IsBlockedIp { get; internal set; }
    public long DeviceId { get; internal set; }
    public DateTime Expire { get; internal set; }
}
