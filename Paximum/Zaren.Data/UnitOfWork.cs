using Microsoft.Extensions.Logging;
using Zaren.Data.Repositories;
using Zaren.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zaren.Data
{
    public interface IUnitOfWork : IDisposable
    {
        public IUsersRepository UsersRepository { get; }
        public IReservationRepository ReservationsRepository { get; }
        void Complete();
    }
    public  class UnitOfWork : IUnitOfWork
    {
        public readonly SanProjectDBContext _context;
        public IUsersRepository UsersRepository { get; private set; }
        public IReservationRepository ReservationsRepository { get; private set; }
        public UnitOfWork(SanProjectDBContext context)
        {
            _context=context;
            UsersRepository = new UsersRepository(context);
            ReservationsRepository = new ReservationRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}
