using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikOdeme.Core.Entities.Payment
{
    public class SalesModel
    {
        public string BankaAdi { get; set; }
        public string KartNumarasi { get; set; }
        public string KartSonKullanmaAyi { get; set; }
        public string KartSonKullanmaYili { get; set; }

    }
}
