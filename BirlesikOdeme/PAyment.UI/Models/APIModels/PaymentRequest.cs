﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

 
 



public class BillingInfo
{
    [JsonPropertyName("taxNo")]
    public string TaxNo { get; set; }

    [JsonPropertyName("taxOffice")]
    public string TaxOffice { get; set; }

    [JsonPropertyName("firmName")]
    public string FirmName { get; set; }

    [JsonPropertyName("identityNumber")]
    public string IdentityNumber { get; set; }

    [JsonPropertyName("fullName")]
    public string FullName { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("phone")]
    public string Phone { get; set; }

    [JsonPropertyName("address")]
    public string Address { get; set; }

    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("town")]
    public string Town { get; set; }

    [JsonPropertyName("zipCode")]
    public string ZipCode { get; set; }
}

public class Campaign
{
    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("value")]
    public string Value { get; set; }
}

public class DeliveryInfo
{
    [JsonPropertyName("taxNo")]
    public string TaxNo { get; set; }

    [JsonPropertyName("taxOffice")]
    public string TaxOffice { get; set; }

    [JsonPropertyName("firmName")]
    public string FirmName { get; set; }

    [JsonPropertyName("identityNumber")]
    public string IdentityNumber { get; set; }

    [JsonPropertyName("fullName")]
    public string FullName { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("phone")]
    public string Phone { get; set; }

    [JsonPropertyName("address")]
    public string Address { get; set; }

    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("town")]
    public string Town { get; set; }

    [JsonPropertyName("zipCode")]
    public string ZipCode { get; set; }
}

public class OrderProductList
{
    [JsonPropertyName("merchantId")]
    public long MerchantId { get; set; }

    [JsonPropertyName("productId")]
    public string ProductId { get; set; }

    [JsonPropertyName("amount")]
    public string Amount { get; set; }

    [JsonPropertyName("productName")]
    public string ProductName { get; set; }

    [JsonPropertyName("commissionRate")]
    public string CommissionRate { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }
}

public class PaymentRequestModel
{
    [JsonPropertyName("insertCard")]
    public bool InsertCard { get; set; }

    [JsonPropertyName("use3D")]
    public bool Use3D { get; set; }

    [JsonPropertyName("merchantId")]
    public long MerchantId { get; set; }

    [JsonPropertyName("customerId")]
    public string CustomerId { get; set; }

    [JsonPropertyName("cardNumber")]
    public string CardNumber { get; set; }

    [JsonPropertyName("expiryDateMonth")]
    public string ExpiryDateMonth { get; set; }

    [JsonPropertyName("expiryDateYear")]
    public string ExpiryDateYear { get; set; }

    [JsonPropertyName("cvv")]
    public string Cvv { get; set; }

    [JsonPropertyName("secureDataId")]
    public int SecureDataId { get; set; }

    [JsonPropertyName("cardAlias")]
    public string CardAlias { get; set; }

    [JsonPropertyName("userCode")]
    public string UserCode { get; set; }

    [JsonPropertyName("txnType")]
    public string TxnType { get; set; }

    [JsonPropertyName("installmentCount")]
    public string InstallmentCount { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; }

    [JsonPropertyName("okUrl")]
    public string OkUrl { get; set; }

    [JsonPropertyName("failUrl")]
    public string FailUrl { get; set; }

    [JsonPropertyName("orderId")]
    public string OrderId { get; set; }

    [JsonPropertyName("totalAmount")]
    public string TotalAmount { get; set; }

    [JsonPropertyName("pointAmount")]
    public string PointAmount { get; set; }

    [JsonPropertyName("rnd")]
    public string Rnd { get; set; }

    [JsonPropertyName("hash")]
    public string Hash { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("requestIp")]
    public string RequestIp { get; set; }

    [JsonPropertyName("cardHolderName")]
    public string CardHolderName { get; set; }

    [JsonPropertyName("extraData")]
    public string ExtraData { get; set; }

    [JsonPropertyName("campaign")]
    public Campaign Campaign { get; set; }

    [JsonPropertyName("billingInfo")]
    public BillingInfo BillingInfo { get; set; }

    [JsonPropertyName("deliveryInfo")]
    public DeliveryInfo DeliveryInfo { get; set; }

    [JsonPropertyName("memberId")]
    public int memberId { get; set; }

    [JsonPropertyName("maturityPeriod")]
    public string MaturityPeriod { get; set; }

    [JsonPropertyName("paymentFrequency")]
    public string PaymentFrequency { get; set; }
}
