using BirlesikOdeme.Core.Entities.Mernis;
using BirlesikOdeme.Core.Exceptions;
using BirlesikOdeme.Core.Helpers;
using BirlesikOdeme.Core.Services.Interfaces;
using static MernisWebService.KPSPublicSoapClient;

namespace BirlesikOdeme.Core.Services.Classes
{
    public class MernisService : IMernisService
    {
        public async Task<string> CheckTCNumber(Citizen input)
        {
            try
            {
                if(!TCHelper.CheckTc(input.TcKimlikNo))
                {
                    return "TC Kimlik algoritmasına göre hatalı bir numara girdiniz.";
                }
                var mernisClient = new MernisWebService.KPSPublicSoapClient(EndpointConfiguration.KPSPublicSoap);
                var tcKimlikDogrulamaServisResponse = await mernisClient.TCKimlikNoDogrulaAsync(input.TcKimlikNo, input.Ad, input.Soyad, input.DogumTarihi);
                bool result = tcKimlikDogrulamaServisResponse.Body.TCKimlikNoDogrulaResult;
                return result ? "Başarılı" : "Başarısız";
            }
            catch (Exception)
            {
                throw new BirlesikOdemeException("Mernis servisiyle bağlantı yapılamadı.");
            }          
            
        } 
       
    }
}
