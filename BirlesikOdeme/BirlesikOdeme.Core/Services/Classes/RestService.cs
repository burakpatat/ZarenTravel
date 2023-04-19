using BirlesikOdeme.Core.Entities.Payment;
using BirlesikOdeme.Core.Entities.Security;
using BirlesikOdeme.Core.Exceptions;
using BirlesikOdeme.Core.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BirlesikOdeme.Core.Services.Classes
{
    public class RestService : IRestService
    {
        private readonly string securityUrl;
        private readonly string paymentUrl;
        private readonly IConfiguration _configuration;


        public RestService(IConfiguration configuration)
        {
            _configuration = configuration;
            securityUrl = _configuration["BirlesikOdemeUrl:SecurityUrl"];
            paymentUrl = _configuration["BirlesikOdemeUrl:PaymentUrl"];
        }

        private async Task<SecurityResponseModel> Login()
        {
            try
            {
                var client = new RestClient(securityUrl);
                var request = new RestRequest(string.Empty, Method.Post);
                request.AddHeader("Content-Type", "application/json");
                var body = JsonSerializer.Serialize(new SecurityRequestModel());
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                var response = await client.PostAsync<SecurityResponseModel>(request);
                return response;
            }
            catch (Exception)
            {
                throw new BirlesikOdemeException("Birleşik Ödeme servisiyle bağlantı yapılamadı.");
            }
        }

        public async Task<PaymentResponseModel> Sales(SalesModel salesModel)
        {
            var customer = await Login();
            if (customer.fail)
            {
                throw new BirlesikOdemeException("Birleşik Ödeme servisiyle bağlantı yapılamadı.");
            }
            string paymentHash = PaymentHash(new PaymentHash());
            try
            {
                var client = new RestClient(paymentUrl);
                var request = new RestRequest("", Method.Post);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", "Bearer " + customer.result.token);
                var paymentRequest = new PaymentRequestModel 
                {
                    cardNumber = salesModel.KartNumarasi,
                    expiryDateMonth = salesModel.KartSonKullanmaAyi,
                    expiryDateYear = salesModel.KartSonKullanmaYili,
                    hash = paymentHash 
                };               
                var body = JsonSerializer.Serialize(paymentRequest);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                var response = await client.PostAsync<PaymentResponseModel>(request);
                return response;

            }
            catch (Exception ex )
            {
                throw new BirlesikOdemeException("Birleşik Ödeme servisiyle bağlantı yapılamadı." +ex);
            }

        }

        private static string PaymentHash(PaymentHash request)
        {
            var hashString = $"{request.HashPassword}{request.UserCode}{request.Rnd}{request.txnType}{request.TotalAmount}{request.CustomerId}{request.OrderId}{request.OkUrl}{request.FailUrl}"; //okurl failurl nedir bilmiyorum. dokumanlarda göremedim
            var s512 = SHA512.Create();
            var byteConverter = new UnicodeEncoding();
            var bytes = s512.ComputeHash(byteConverter.GetBytes(hashString));
            var hash = BitConverter.ToString(bytes).Replace("-", "");
            return hash;
        }


    }
}
