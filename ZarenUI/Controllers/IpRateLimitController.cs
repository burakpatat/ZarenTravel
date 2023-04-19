using AspNetCoreRateLimit;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Math;
using Microsoft.AspNetCore.Mvc;
using MimeKit.Cryptography;

namespace ZarenUI.Controllers
{
    public class IpRateLimitController : Controller
    {
        private readonly IpRateLimitOptions _options;
        private readonly IIpPolicyStore _ipPolicyStore;
        public IpRateLimitController(IpRateLimitOptions options, IIpPolicyStore ipPolicyStore)
        {
            _options = options;
            _ipPolicyStore = ipPolicyStore;
        }

        [HttpGet]
        async public Task<IpRateLimitPolicies> Get()
        {
            return await _ipPolicyStore.GetAsync(_options.IpPolicyPrefix);
        }

        [HttpPost]
        async public void Post()
        {
            var pol = await _ipPolicyStore.GetAsync(_options.IpPolicyPrefix);

            pol.IpRules.Add(new IpRateLimitPolicy
            {
                Ip = "::1",
                Rules = new List<RateLimitRule>(new RateLimitRule[] {
            new RateLimitRule {
                Endpoint = "*",
                Limit = 3,
                Period = "1s" }
        })
            });

            await _ipPolicyStore.SetAsync(_options.IpPolicyPrefix, pol);
        }
    }
}

