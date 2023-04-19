using BirlesikOdeme.Core.Exceptions;
using BirlesikOdemeTest.Core.Models.APIModels;
using Model.Concrete;
using Newtonsoft.Json;
using RestSharp;
using Security;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;
using System.Web.UI;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace PAyment.UI
{
    public partial class _Default : Page
    {
        public string PageInfo;
        public string currency;
        public string language;
        public string totalPrice;
        public string paymentProcess;
        public Transactions transaction = new Transactions();
        public TransactionDTO transactionDTO;

        public HttpClient Client { get; set; }
       
        public HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            PageInfo = Request.QueryString["page"];
            paymentProcess = Request.QueryString["process"];
            transactionDTO = new TransactionDTO();

            if (!IsPostBack)
            {
                if (paymentProcess != null)
                {
                    transaction = new TransactionsRepository().GetByIdGuid(paymentProcess).FirstOrDefault();
                    if (transaction != null)
                    {
                        transactionDTO.NameSurname = txtNameSurname.Text = transaction.NameSurname;
                        transactionDTO.Address = txtAddress.Text = transaction.Address;
                        transactionDTO.City = txtCity.Text = transaction.City;
                        transactionDTO.CompanyName = txtCompany.Text = transaction.CompanyName;
                        transactionDTO.Email = txtEmail.Text = transaction.Email;
                        transactionDTO.Phone = txtPhone.Text = transaction.Phone;
                        transactionDTO.Provience = txtProvience.Text = transaction.Provience;
                        transactionDTO.BillingAddress = txtTaxAddress.Text = transaction.BillingAddress;
                        transactionDTO.Is3D = transaction.Is3D.ToBool();
                        transactionDTO.TotalAmount = transaction.TotalAmount;
                        ch3D.Checked = transaction.Is3D.Value;
                        transactionDTO.HasPrivacy = transaction.HasPrivacy;

                        if (transaction.PaymentConfigurationId == 1)
                        {
                            if (!ConfigurationManager.AppSettings["IsProd"].ToBool())
                            {
                                var paymentInfo = new TestCardsRepository().GetByID(51);
                                if (paymentInfo != null)
                                {
                                    txtCardNumber.Text = paymentInfo.CardNo;
                                    txtCVC.Text = paymentInfo.CVV;
                                    txtCardNameSurname.Text = transaction.NameSurname;

                                    var dates = paymentInfo.ValidDate.Split('/');
                                    if (dates.Count() > 1)
                                    {
                                        drMonth.SelectedValue = dates[0];
                                        drYear.SelectedValue = dates[1];
                                    }
                                }
                            }
                        } 

                        chPolicy.Checked = transaction.HasPrivacy.Value;
                        transactionDTO.CurrencyInfo = new Currencies();
                        using (var currencyContext = new CurrenciesRepository())
                        {
                            transactionDTO.CurrencyInfo = currencyContext.GetByID(transaction.Currency.Value);
                        }

                    }
                    if (PageInfo == null)
                        PageInfo = "personal"; 
                }
            }
        }

        private void fillSelects()
        {

        }

        protected void personalBtn_Click(object sender, EventArgs e)
        {
            transaction = new TransactionsRepository().GetByIdGuid(paymentProcess).FirstOrDefault();
            if (transaction != null)
            {
                transaction.NameSurname = txtNameSurname.Text;
                transaction.Email = txtEmail.Text;
                transaction.Phone = txtPhone.Text;

                var result = new TransactionsRepository().Update(transaction);
                if (result)
                    Response.Redirect("/?page=address&" + "process=" + Request.QueryString["process"] + "&s=1");
                else
                    Response.Redirect("/?page=address&" + "process=" + Request.QueryString["process"] + "&s=0");
            }
        }

        protected void btnAddress_Click(object sender, EventArgs e)
        {
            transaction = new TransactionsRepository().GetByIdGuid(paymentProcess).FirstOrDefault();
            if (transaction != null)
            {
                transaction.Address = txtAddress.Text;
                transaction.BillingAddress = txtTaxAddress.Text;
                transaction.City = txtCity.Text;
                transaction.CompanyName = txtCompany.Text;
                transaction.Provience = txtProvience.Text;

                var result = new TransactionsRepository().Update(transaction);
                if (result)
                    Response.Redirect("/?page=cardinfo&" + "process=" + Request.QueryString["process"] + "&s=1");
                else
                    Response.Redirect("/?page=cardinfo&" + "process=" + Request.QueryString["process"] + "&s=0");
            }
        }

        protected async void paymentBtn_Click(object sender, EventArgs e)
        {

            PaymentConfiguration config = new PaymentConfiguration();
            PaymentConfigurationRepository PaymentConfigurationRepository = new PaymentConfigurationRepository();
            string securityUrl = "";
            string paymentUrl = "";
            transaction = new TransactionsRepository().GetByIdGuid(paymentProcess).FirstOrDefault();
            if (transaction != null)
            {
                transaction.Is3D = ch3D.Checked;
                transaction.HasPrivacy = chPolicy.Checked;
                config = PaymentConfigurationRepository.GetByID(transaction.PaymentConfigurationId.ToInt32());
                if (config != null)
                {

                    if (transaction.PaymentConfigurationId == 1)
                    {
                        if (!ConfigurationManager.AppSettings["IsProd"].ToBool())
                        {
                            paymentUrl = config.TestPaymentUrl;
                            securityUrl = config.TestSecurityUrl;
                        }
                        else
                        {
                            paymentUrl = config.ProdPaymentUrl;
                            securityUrl = config.ProdPaymentUrl;
                        }

                        HttpClientHandler insecureHandler = GetInsecureHandler();
                        Client = new HttpClient(insecureHandler);
                        var req = new LoginRequest
                        {
                            email = config.Email,
                            lang = config.Language,
                            ApiKey = config.Password
                        };
                        var json = await Client.PostAsync(securityUrl, new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json"));
                        var content = await json.Content.ReadAsStringAsync();
                        var loginresult = JsonConvert.DeserializeObject<LoginResponse>(content);

                        if (loginresult.fail)
                        {
                            throw new BirlesikOdemeException("Birleşik Ödeme servisiyle bağlantı yapılamadı.");
                        }
                        else
                        {
                             
                            Client.DefaultRequestHeaders.Add("Authorization", "bearer " + loginresult.result.token);
                            List<OrderProductList> orders = new List<OrderProductList>();
                            var amount = transaction.TotalAmount.ToString().Split(',')[0]; 

                            using (var currencyContext = new CurrenciesRepository())
                                transactionDTO.CurrencyInfo = currencyContext.GetByID(transaction.Currency.Value);
                          
                            var payment = new PaymentRequestModel
                            { 
                                CardNumber = txtCardNumber.Text.Replace(" ",""),
                                ExpiryDateMonth = drMonth.SelectedValue,
                                ExpiryDateYear = drYear.SelectedValue,
                                Cvv = txtCVC.Text,
                                TotalAmount = (amount.ToInt32() * 100).ToString(),
                                Currency = transactionDTO.CurrencyInfo.Number,                                
                                MerchantId = long.Parse(config.MerchantId),
                                CustomerId = transaction.Email,
                                Rnd = RandomWord(true),
                                OrderId = RandomWord(false),
                                InstallmentCount = "1",
                                TxnType = config.TxnType,
                                UserCode = config.Email,
                                memberId = 1,
                                Use3D = true,
                                OkUrl=config.OkUrl,
                                FailUrl=config.FailUrl,
                                

                            };
                            string hashed = CreateHash(payment,config.HashPassword);
                            payment.Hash = hashed; 
                            var jsonPayment = await Client.PostAsync(paymentUrl, new StringContent(JsonConvert.SerializeObject(payment), Encoding.UTF8, "application/json"));
                            var contentPayment = await jsonPayment.Content.ReadAsStringAsync();
                            ltrToast.Text = contentPayment;
                             
                        }
                    }

                }


            }
        }

        void ToastBuilder(string title, string message)
        {
            //Create a new StringBuilder object
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(" <div class=\"toasts-container\">");
            sb.AppendLine("                <div class=\"toast\" data-autohide=\"true\">");
            sb.AppendLine("                    <div class=\"toast-header\">");
            sb.AppendLine("                        <i class=\"far fa-bell text-muted me-2\"></i>");
            sb.AppendLine("                        <strong class=\"me-auto\">" + title + "</strong>");
            sb.AppendLine("                        <small>" + DateTime.Now + "</small>");
            sb.AppendLine("                        <button type=\"button\" class=\"btn-close\" data-bs-dismiss=\"toast\"></button>");
            sb.AppendLine("                    </div>");
            sb.AppendLine("                    <div class=\"toast-body\">");
            sb.AppendLine(message);
            sb.AppendLine("                    </div>");
            sb.AppendLine("                </div>");
            sb.AppendLine("");
            sb.AppendLine("            </div>");

            ltrToast.Text = sb.ToString();

        }


   


        public string CreateHash(PaymentRequestModel request,string apiKey)
        { 
            var hashString = $"{apiKey}{request.UserCode}{request.Rnd}{request.TxnType}{request.TotalAmount}{request.CustomerId}{request.OrderId}{request.OkUrl}{request.FailUrl}"; 
            System.Security.Cryptography.SHA512 s512 = System.Security.Cryptography.SHA512.Create(); 
            System.Text.UnicodeEncoding ByteConverter = new System.Text.UnicodeEncoding(); 
            byte[] bytes = s512.ComputeHash(ByteConverter.GetBytes(hashString)); 
            var hash = System.BitConverter.ToString(bytes).Replace("-", "");

            return hash;
        }
        public static string RandomWord(bool harf)
        {
            if (harf)
            {
                string word = "";
                var rnd = new Random();
                for (int i = 0; i < 6; i++)
                {
                    word += ((char)rnd.Next('A', 'Z')).ToString();
                }

                return word;

            }
            else
            {
                string word = "";
                var rnd = new Random();
                for (int i = 0; i < 6; i++)
                {
                    word += ((char)rnd.Next('0', '9')).ToString();
                }

                return word;
            }

        }

        //public async Task<IServiceResponse> MakePayment(string cardNumber, string expiryDateMonth, string expiryDateYear, string cvv, string cardAlias, int customerId)
        //{
        //    using (IDbContextTransaction a = _db.Database.BeginTransaction())
        //    {
        //        try
        //        {
        //            var loginresult = await LogintoApi();
        //            if (loginresult != null)
        //            {
        //                Client.DefaultRequestHeaders.Add("Authorization", "bearer " + loginresult.result.token);
        //                List<OrderProductList> orders = new List<OrderProductList>();
        //                var order = new OrderProductList
        //                {
        //                    amount = "1",
        //                    commissionRate = "0",
        //                    merchantId = long.Parse(loginresult.result.userId),
        //                    productId = "1",
        //                    productName = "Bilgisayar"
        //                };
        //                orders.Add(order);


        //                var payment = new PaymentRequest
        //                {
        //                    cardAlias = cardAlias,
        //                    cardNumber = cardNumber,
        //                    expiryDateMonth = expiryDateMonth,
        //                    expiryDateYear = expiryDateYear,
        //                    cvv = cvv,
        //                    totalAmount = "1",
        //                    currency = "949",
        //                    memberId = 1,
        //                    merchantId = long.Parse(loginresult.result.userId),
        //                    customerId = customerId.ToString(),
        //                    rnd = RandomWord(true),
        //                    orderId = RandomWord(false),
        //                    installmentCount = "1",
        //                    txnType = "Auth",
        //                    userCode = "test",
        //                    orderProductList = orders

        //                };
        //                string hashed = CreateHash(payment);
        //                payment.hash = hashed;

        //                var paymentresponse = await SendPayment(payment);
        //                if (paymentresponse != null)
        //                {
        //                    Transaction _transaction; ;
        //                    if (paymentresponse.result.responseCode == "00")
        //                    {
        //                        _transaction = new Transaction
        //                        {
        //                            Amount = int.Parse(paymentresponse.result.totalAmount),
        //                            CardPan = payment.cardNumber,
        //                            CustomerId = customerId,
        //                            OrderId = payment.orderId,
        //                            ResponseCode = paymentresponse.result.responseCode,
        //                            ResponseMessage = paymentresponse.result.responseMessage,
        //                            Status = 200,
        //                            TypeId = "Sale"
        //                        };
        //                    }
        //                    else
        //                    {
        //                        _transaction = new Transaction
        //                        {
        //                            Amount = 1,
        //                            CardPan = payment.cardNumber,
        //                            CustomerId = customerId,
        //                            OrderId = payment.orderId,
        //                            ResponseCode = paymentresponse.result.responseCode,
        //                            ResponseMessage = paymentresponse.result.responseMessage,
        //                            Status = 400,
        //                            TypeId = "Sale"
        //                        };
        //                    }



        //                    await _transactionRespository.InsertAsync(_transaction);
        //                    await _db.SaveChangesAsync();
        //                    a.Commit();
        //                    if (_transaction.Status == 200)
        //                        return new ServiceResponse("Satış Başarılı!", 200, true);
        //                    else
        //                        return new ServiceResponse("Satışta Hata Oluştu.", 200, true);
        //                }
        //                else
        //                    return new ServiceResponse("HATA!", 400, false);

        //            }
        //            else
        //                return new ServiceResponse("HATA!", 400, false);
        //        }
        //        catch (Exception)
        //        {

        //            a.Rollback();
        //            return new ServiceResponse("Hata", 400, false);
        //        }


        //    }


        //}

        //private async Task<PaymentResponse> SendPayment(PaymentRequest payment)
        //{

        //    var json = await Client.PostAsync("https://ppgpayment-test.birlesikodeme.com:20000/api/ppg/Payment/NoneSecurePayment", new StringContent(JsonConvert.SerializeObject(payment), Encoding.UTF8, "application/json"));
        //    var content = await json.Content.ReadAsStringAsync();
        //    var result = JsonConvert.DeserializeObject<PaymentResponse>(content);
        //    if (!result.fail)
        //    {
        //        return result;
        //    }
        //    return null;
        //}

        //private async Task<LoginResponse> LogintoApi()
        //{
        //    var req = new LoginRequest
        //    {
        //        email = "murat.karayilan@dotto.com.tr",
        //        lang = "TR",
        //        ApiKey = "kU8@iP3@"
        //    };
        //    var json = await Client.PostAsync("https://ppgsecurity-test.birlesikodeme.com:55002/api/ppg/Securities/authenticationMerchant", new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json"));
        //    var content = await json.Content.ReadAsStringAsync();
        //    var result = JsonConvert.DeserializeObject<LoginResponse>(content);
        //    if (!result.fail)
        //    {
        //        return result;
        //    }
        //    return null;
        //}




    }
}