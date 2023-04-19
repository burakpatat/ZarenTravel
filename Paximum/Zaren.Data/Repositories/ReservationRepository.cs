using Zaren.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zaren.Data.Repositories
{
    public class ReservationRepository:Repository<ReservationDBDTO>, IReservationRepository
    {
        public ReservationRepository(SanProjectDBContext dBContext) : base(dBContext)
        {

        }


    }
}
