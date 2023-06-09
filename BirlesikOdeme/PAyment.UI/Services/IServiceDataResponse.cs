﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikOdemeTest.Core.Services
{
    public interface IServiceDataResponse<T>
    {
        string Message { get; set; }
        IList<T> DataList { get; set; }
        T Data { get; set; }
        int Status { get; set; }
        public bool IsSuccessful { get; set; }
    }
}
