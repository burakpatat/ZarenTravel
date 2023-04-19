using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikOdeme.Core.Entities.Dtos
{
    public class SalesRequestModel
    {
        public string BankaAdi { get; set; }
        public string KartNumarasi { get; set; }
        public string KartSonKullanmaAyi { get; set; }
        public string KartSonKullanmaYili { get; set; }
    }
}
