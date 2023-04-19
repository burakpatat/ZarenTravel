using AutoMapper;
using BirlesikOdemeTest.Core;
using BirlesikOdemeTest.Core.Models;
using BirlesikOdemeTest.Core.Models.APIModels;
using BirlesikOdemeTest.Core.Repositories;
using BirlesikOdemeTest.Core.Services;
using BirlesikOdemeTest.Data.Entities.DBEntities;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Transaction = BirlesikOdemeTest.Data.Entities.DBEntities.Transaction;
using BirlesikOdemeTest.Data.DbContexts;

namespace BirlesikOdemeTest.Service.DBServices
{
    public class PaymentService :BaseClient, IPaymentService
    {

        IRepository<DataContext, Transaction> _transactionRespository;


        DataContext _db;
        public PaymentService(IRepository<DataContext, Transaction> transactionRespository, DataContext db)
        {
            _transactionRespository = transactionRespository;
            _db = db;
        }

        public async Task<IServiceResponse> MakePayment(string cardNumber, string expiryDateMonth, string expiryDateYear, string cvv, string cardAlias,int customerId)
        {
            using(IDbContextTransaction a=_db.Database.BeginTransaction())
            {
                try
                {
                    var loginresult=await LogintoApi();
                    if (loginresult != null)
                    {
                        Client.DefaultRequestHeaders.Add("Authorization", "bearer " + loginresult.result.token);
                        List<OrderProductList> orders = new List<OrderProductList>();
                        var order = new OrderProductList
                        {
                            amount = "1",
                            commissionRate = "0",
                            merchantId = long.Parse(loginresult.result.userId),
                            productId = "1",
                            productName = "Bilgisayar"
                        };
                        orders.Add(order);
                       
                        
                        var payment = new PaymentRequest
                        {
                            cardAlias = cardAlias,
                            cardNumber = cardNumber,
                            expiryDateMonth = expiryDateMonth,
                            expiryDateYear = expiryDateYear,
                            cvv = cvv,
                            totalAmount="1",
                            currency= "949",
                            memberId=1,
                            merchantId=long.Parse(loginresult.result.userId),
                            customerId=customerId.ToString(),
                            rnd=RandomWord(true),
                            orderId= RandomWord(false),
                            installmentCount="1",
                            txnType= "Auth",
                            userCode= "test",
                            orderProductList=orders

                        };
                        string hashed = CreateHash(payment);
                        payment.hash = hashed;

                       var paymentresponse= await SendPayment(payment);
                        if (paymentresponse != null)
                        {
                            Transaction _transaction; ;
                            if (paymentresponse.result.responseCode == "00")
                            {
                                _transaction = new Transaction
                                {
                                    Amount = int.Parse(paymentresponse.result.totalAmount),
                                    CardPan = payment.cardNumber,
                                    CustomerId = customerId,
                                    OrderId = payment.orderId,
                                    ResponseCode = paymentresponse.result.responseCode,
                                    ResponseMessage = paymentresponse.result.responseMessage,
                                    Status = 200,
                                    TypeId = "Sale"
                                };
                            }
                            else
                            {
                                _transaction = new Transaction
                                {
                                    Amount = 1,
                                    CardPan = payment.cardNumber,
                                    CustomerId = customerId,
                                    OrderId = payment.orderId,
                                    ResponseCode = paymentresponse.result.responseCode,
                                    ResponseMessage = paymentresponse.result.responseMessage,
                                    Status = 400,
                                    TypeId = "Sale"
                                };
                            }
                                
                            
                                
                            await _transactionRespository.InsertAsync(_transaction);
                           await _db.SaveChangesAsync();
                            a.Commit();
                            if(_transaction.Status == 200)
                            return new ServiceResponse("Satış Başarılı!", 200, true);
                            else
                                return new ServiceResponse("Satışta Hata Oluştu.", 200, true);
                        }else
                            return new ServiceResponse("HATA!", 400, false);

                    }
                    else
                        return new ServiceResponse("HATA!", 400, false);

                   
                    

                }
                catch (Exception)
                {

                    a.Rollback();
                    return new ServiceResponse("Hata",400,false);
                }


            }

            
        }

        private async Task<PaymentResponse> SendPayment(PaymentRequest payment)
        {
           
            var json = await Client.PostAsync("https://ppgpayment-test.birlesikodeme.com:20000/api/ppg/Payment/NoneSecurePayment", new StringContent(JsonConvert.SerializeObject(payment), Encoding.UTF8, "application/json"));
            var content = await json.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<PaymentResponse>(content);
            if (!result.fail)
            {
                return result;
            }
            return null;
        }

        private async Task<LoginResponse> LogintoApi()
        {
            var req = new LoginRequest
            {
                email = "murat.karayilan@dotto.com.tr",
                lang = "TR",
                ApiKey = "kU8@iP3@"
            };
            var json = await Client.PostAsync("https://ppgsecurity-test.birlesikodeme.com:55002/api/ppg/Securities/authenticationMerchant", new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json"));
            var content = await json.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<LoginResponse>(content);
            if (!result.fail)
            {
                return result;
            }
            return null;
        }

        public string CreateHash(PaymentRequest request)
        {
            var apiKey = "SKI0NDHEUP60J7QVCFATP9TJFT2OQFSO"; // Bu bilgi size özel olup kayıtlı kullanıcınıza mail olarak gönderilmiştir.

            var hashString = $"{apiKey}{request.userCode}{request.rnd}{request.txnType}{request.totalAmount}{request.customerId}{request.orderId}";

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
        
    }
}
