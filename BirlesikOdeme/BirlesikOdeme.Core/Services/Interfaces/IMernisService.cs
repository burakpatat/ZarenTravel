using BirlesikOdeme.Core.Entities.Mernis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikOdeme.Core.Services.Interfaces
{
    public interface IMernisService
    {
        Task<string> CheckTCNumber(Citizen input);
    }
}
