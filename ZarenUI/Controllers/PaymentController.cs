using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Model.Concrete;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;
using ZarenUI;
using ZarenUI.Services.Models.CreditCart;

public class PaymentController : Controller
{
    [Inject]
    protected SecurityService Security { get; set; }
    [Inject]
    protected BookingReservationsRepository BookingReservationsRepository { get; set; }
    [Inject]
    protected TransactionsRepository TransactionsRepository { get; set; }
    [Inject]
    protected TransactionDetailsRepository TransactionDetailsRepository { get; set; }
    [Inject]
    protected PaymentConfigurationRepository PaymentConfigurationRepository { get; set; }
    [Inject]
    protected CurrenciesRepository CurrenciesRepository { get; set; }

    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IConfiguration _configuration;
    private IDistributedCache _cache;
    private TokenHelper _tokenHelper;
    public PaymentController(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IDistributedCache cache)
    {
        _cache = cache;
        _httpContextAccessor = httpContextAccessor;
        _configuration = configuration;
        _tokenHelper = new TokenHelper(httpContextAccessor, configuration, _cache);
    }


    [HttpGet("~/api/BeginTransaction/{culture}/{currency}")]
    public ActionResult<string> BeginTransaction([FromQuery] string offerId, string culture, string currency)
    {
        var cookie = _httpContextAccessor.HttpContext.Request.Cookies["ZtUser"];
        AspNetUsersRepository AspNetUsersRepository = new AspNetUsersRepository(_configuration);
        var appUser = AspNetUsersRepository.GetUserByToken(cookie);
        if (appUser != null)
        {
            return _tokenHelper.BeginTransaction(offerId, appUser.Id, currency, culture).ToJson();
        }
        else
        {
            return _tokenHelper.BeginTransaction(offerId, null, currency, culture).ToJson();
        }

    }


    [HttpGet("~/api/SetReservationInfo/{transactionId}")]
    public ActionResult<string> SetReservationInfo(string transactionId)
    {
        return _tokenHelper.SetReservationInfo(transactionId).ToJson();
    }

    [HttpGet("~/api/GetReservationDetail/{ReservationNumber}")]
    public ActionResult<string> GetReservationDetail(string ReservationNumber)
    {
        return _tokenHelper.GetReservationDetail(ReservationNumber).ToJson();
    }

    [HttpPost("~/api/paycard/{transactionId}/{culture}/{currency}")]
    public ActionResult<string> PaymentWithCreditCard(string culture, string currency, string transactionId, [FromBody] Dictionary<string, object> CardInfo)
    {

        string json = CardInfo.objectDictionaryToJson();
        var card = JsonConvert.DeserializeObject<CreditCartRequest>(json);
        return _tokenHelper.BeginPaymentTransaction(transactionId, card.CardInfo).ToJson();
    }

    private string CreateHash(PaymentRequestModel request, string apiKey)
    {
        string s = apiKey + request.UserCode + request.Rnd + request.TxnType + request.TotalAmount + request.CustomerId + request.OrderId + request.OkUrl + request.FailUrl;
        SHA512 sHA = SHA512.Create();
        UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
        byte[] array = sHA.ComputeHash(unicodeEncoding.GetBytes(s));
        return BitConverter.ToString(array).Replace("-", "");
    }
    public void OnPost(string transactionId, PaymentRequestModel paymentRequestModel)
    {
        decimal TotalAmount = 0;
        var cookie = _httpContextAccessor.HttpContext.Request.Cookies["ZtUser"];
        if (cookie != null)
        {

            var basketList = BookingReservationsRepository.GetByCookie(cookie);
            foreach (var itemBasket in basketList)
                TotalAmount += itemBasket.TotalAmount;

            CurrenciesRepository.GetByCurrencyCode(cookie);
            var transaction = TransactionsRepository.GetByIdGuid(transactionId).FirstOrDefault();
            if (transaction != null)
            {
                var config = PaymentConfigurationRepository.GetByID(transaction.PaymentConfigurationId.ToInt32());
                if (config != null)
                {
                    string paymentUrl;
                    string text;
                    paymentUrl = config.TestPaymentUrl;
                    text = config.TestSecurityUrl;

                    string cardnumber = paymentRequestModel.CardNumber;
                    string ExpiryDateMonth = paymentRequestModel.ExpiryDateMonth;
                    string expiryDateYear = paymentRequestModel.ExpiryDateYear;
                    string cvv = paymentRequestModel.Cvv;
                    string cardHolderName = paymentRequestModel.CardHolderName;
                    string customerid = paymentRequestModel.CustomerId;


                    HttpClient client = new HttpClient();
                    var loginRequest = new
                    {
                        email = config.Email,
                        lang = config.Language,
                        ApiKey = config.Password
                    };

                    string content = JsonConvert.SerializeObject(loginRequest);
                    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    ByteArrayContent byteContent = new ByteArrayContent(buffer);
                    HttpResponseMessage req = client.PostAsync(text, byteContent).Result;
                    string contents = req.Content.ReadAsStringAsync().Result;
                    LoginResponse obj = JsonConvert.DeserializeObject<LoginResponse>(contents);

                    paymentRequestModel.CardNumber = cardnumber.Replace(" ", "");
                    paymentRequestModel.ExpiryDateMonth = ExpiryDateMonth;
                    paymentRequestModel.ExpiryDateYear = expiryDateYear;
                    paymentRequestModel.Cvv = cvv;
                    paymentRequestModel.CardHolderName = cardHolderName;
                    paymentRequestModel.TotalAmount = (TotalAmount * 100).ToString();
                    paymentRequestModel.Currency = "233";
                    paymentRequestModel.MerchantId = long.Parse(config.MerchantId);

                    paymentRequestModel.Rnd = RandomWord(harf: true);
                    paymentRequestModel.OrderId = RandomWord(harf: false);
                    paymentRequestModel.InstallmentCount = "1";
                    paymentRequestModel.TxnType = config.TxnType;
                    paymentRequestModel.UserCode = config.Email;
                    paymentRequestModel.memberId = 1;
                    paymentRequestModel.Use3D = true;
                    paymentRequestModel.OkUrl = config.OkUrl + "&process=" + transactionId;
                    paymentRequestModel.FailUrl = config.FailUrl + "&process=" + transactionId;
                    PaymentRequestModel paymentRequestModel2 = paymentRequestModel;
                    string text3 = (paymentRequestModel2.Hash = CreateHash(paymentRequestModel2, config.HashPassword));
                    paymentRequestModel.Hash = text3;


                    Transactions transactions = new Transactions()
                    {
                        IdGuid = transactionId,
                        CreatedDate = DateTime.Now,
                        TotalAmount = TotalAmount.ToDecimal(),
                        UserId = "",
                        Email = "",
                        Address = "",
                        BillingAddress = "",
                        Currency = 233,
                        IsSuccess = true,
                        NameSurname = "",
                        Language = "1",
                        City = "",
                        CompanyName = "",
                        HasKvkkPermission = true,
                        HasPrivacy = true,
                        Is3D = false,
                        Phone = "",
                        Provience = "",
                        PaymentConfigurationId = 2,
                        PaymentUrl = "https://payment3.zarentravel.com/?process=" + transactionId
                        //CurrencyInfo=
                    };
                    var result = TransactionsRepository.Insert(transactions);
                    paymentRequestModel.CustomerId = transactions.Email;

                    result.ToString();
                }
            }
        }


    }


    private static string RandomWord(bool harf)
    {
        if (harf)
        {
            string text = "";
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                text += (char)random.Next(65, 90);
            }
            return text;
        }
        string text2 = "";
        Random random2 = new Random();
        for (int j = 0; j < 6; j++)
        {
            text2 += (char)random2.Next(48, 57);
        }
        return text2;
    }

    [HttpPost("~/api/pay/{transactionId}/{culture}/{currency}")]
    public ActionResult<string> PaymentWithCreditCard2(string culture, string currency, string transactionId, [FromBody] Dictionary<string, object> CardInfo)
    {

        string json = CardInfo.objectDictionaryToJson();
        var card = JsonConvert.DeserializeObject<CreditCartRequest>(json);
        var _result = _tokenHelper.AgencyCredit(transactionId, currency, culture);

        var result = _tokenHelper.CheckPayment(_result.Body.PaymentTransactionId);

        if (result.Body.Status == 1)
            return "Complete";
        else if (result.Body.Status == 2)
            return "Errored";
        else if (result.Body.Status == 3)
            return "Voided";
        else if (result.Body.Status == 4)
            return "Refunded";
        else return "InComplete";

    }




    [HttpPost("~/api/CheckPayment/{paymentTransactionId}")]
    public ActionResult<string> CheckPayment(string culture, string currency, string paymentTransactionId)
    {

        var result = _tokenHelper.CheckPayment(paymentTransactionId);
        if (result.Body.Status == 0)
            return "InComplete";
        else if (result.Body.Status == 1)
            return "Complete";
        else if (result.Body.Status == 2)
            return "Errored";
        else if (result.Body.Status == 3)
            return "Voided";
        else if (result.Body.Status == 4)
            return "Refunded";

        return result.ToJson();
    }

    [HttpGet("~/api/getpaymentoptions/{transactionId}")]
    public ActionResult<string> GetPaymentOptions(string transactionId)
    {
        return _tokenHelper.GetPaymentOptions(transactionId).ToJson();
    }

    [HttpGet("~/api/GetPaymentTypes/{culture}/{transactionId}")]
    public ActionResult<string> GetPaymentTypes(string transactionId, string culture)
    {
        return _tokenHelper.GetPaymentTypes(transactionId, culture).ToJson();
    }


}
