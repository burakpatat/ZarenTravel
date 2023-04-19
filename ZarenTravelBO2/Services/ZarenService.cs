using System;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Radzen;

using ZarenBO2.Data;

namespace ZarenBO2
{
    public partial class ZarenService
    {
        ZarenContext Context
        {
           get
           {
             return this.context;
           }
        }

        private readonly ZarenContext context;
        private readonly NavigationManager navigationManager;

        public ZarenService(ZarenContext context, NavigationManager navigationManager)
        {
            this.context = context;
            this.navigationManager = navigationManager;
        }

        public void Reset() => Context.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);


        public async Task ExportAccountLikesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/accountlikes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/accountlikes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAccountLikesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/accountlikes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/accountlikes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAccountLikesRead(ref IQueryable<ZarenBO2.Models.Zaren.AccountLike> items);

        public async Task<IQueryable<ZarenBO2.Models.Zaren.AccountLike>> GetAccountLikes(Query query = null)
        {
            var items = Context.AccountLikes.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnAccountLikesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAccountLikeGet(ZarenBO2.Models.Zaren.AccountLike item);

        public async Task<ZarenBO2.Models.Zaren.AccountLike> GetAccountLikeById(int id)
        {
            var items = Context.AccountLikes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAccountLikeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAccountLikeCreated(ZarenBO2.Models.Zaren.AccountLike item);
        partial void OnAfterAccountLikeCreated(ZarenBO2.Models.Zaren.AccountLike item);

        public async Task<ZarenBO2.Models.Zaren.AccountLike> CreateAccountLike(ZarenBO2.Models.Zaren.AccountLike accountlike)
        {
            OnAccountLikeCreated(accountlike);

            var existingItem = Context.AccountLikes
                              .Where(i => i.Id == accountlike.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AccountLikes.Add(accountlike);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(accountlike).State = EntityState.Detached;
                throw;
            }

            OnAfterAccountLikeCreated(accountlike);

            return accountlike;
        }

        public async Task<ZarenBO2.Models.Zaren.AccountLike> CancelAccountLikeChanges(ZarenBO2.Models.Zaren.AccountLike item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAccountLikeUpdated(ZarenBO2.Models.Zaren.AccountLike item);
        partial void OnAfterAccountLikeUpdated(ZarenBO2.Models.Zaren.AccountLike item);

        public async Task<ZarenBO2.Models.Zaren.AccountLike> UpdateAccountLike(int id, ZarenBO2.Models.Zaren.AccountLike accountlike)
        {
            OnAccountLikeUpdated(accountlike);

            var itemToUpdate = Context.AccountLikes
                              .Where(i => i.Id == accountlike.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(accountlike).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAccountLikeUpdated(accountlike);

            return accountlike;
        }

        partial void OnAccountLikeDeleted(ZarenBO2.Models.Zaren.AccountLike item);
        partial void OnAfterAccountLikeDeleted(ZarenBO2.Models.Zaren.AccountLike item);

        public async Task<ZarenBO2.Models.Zaren.AccountLike> DeleteAccountLike(int id)
        {
            var itemToDelete = Context.AccountLikes
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAccountLikeDeleted(itemToDelete);

            Reset();

            Context.AccountLikes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAccountLikeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAutoCompletesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/autocompletes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/autocompletes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAutoCompletesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/autocompletes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/autocompletes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAutoCompletesRead(ref IQueryable<ZarenBO2.Models.Zaren.AutoComplete> items);

        public async Task<IQueryable<ZarenBO2.Models.Zaren.AutoComplete>> GetAutoCompletes(Query query = null)
        {
            var items = Context.AutoCompletes.AsQueryable();

            items = items.Include(i => i.AutoCompleteType);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnAutoCompletesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAutoCompleteGet(ZarenBO2.Models.Zaren.AutoComplete item);

        public async Task<ZarenBO2.Models.Zaren.AutoComplete> GetAutoCompleteById(int id)
        {
            var items = Context.AutoCompletes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.AutoCompleteType);
  
            var itemToReturn = items.FirstOrDefault();

            OnAutoCompleteGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAutoCompleteCreated(ZarenBO2.Models.Zaren.AutoComplete item);
        partial void OnAfterAutoCompleteCreated(ZarenBO2.Models.Zaren.AutoComplete item);

        public async Task<ZarenBO2.Models.Zaren.AutoComplete> CreateAutoComplete(ZarenBO2.Models.Zaren.AutoComplete autocomplete)
        {
            OnAutoCompleteCreated(autocomplete);

            var existingItem = Context.AutoCompletes
                              .Where(i => i.Id == autocomplete.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AutoCompletes.Add(autocomplete);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(autocomplete).State = EntityState.Detached;
                throw;
            }

            OnAfterAutoCompleteCreated(autocomplete);

            return autocomplete;
        }

        public async Task<ZarenBO2.Models.Zaren.AutoComplete> CancelAutoCompleteChanges(ZarenBO2.Models.Zaren.AutoComplete item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAutoCompleteUpdated(ZarenBO2.Models.Zaren.AutoComplete item);
        partial void OnAfterAutoCompleteUpdated(ZarenBO2.Models.Zaren.AutoComplete item);

        public async Task<ZarenBO2.Models.Zaren.AutoComplete> UpdateAutoComplete(int id, ZarenBO2.Models.Zaren.AutoComplete autocomplete)
        {
            OnAutoCompleteUpdated(autocomplete);

            var itemToUpdate = Context.AutoCompletes
                              .Where(i => i.Id == autocomplete.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            autocomplete.AutoCompleteType = null;

            Context.Attach(autocomplete).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAutoCompleteUpdated(autocomplete);

            return autocomplete;
        }

        partial void OnAutoCompleteDeleted(ZarenBO2.Models.Zaren.AutoComplete item);
        partial void OnAfterAutoCompleteDeleted(ZarenBO2.Models.Zaren.AutoComplete item);

        public async Task<ZarenBO2.Models.Zaren.AutoComplete> DeleteAutoComplete(int id)
        {
            var itemToDelete = Context.AutoCompletes
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAutoCompleteDeleted(itemToDelete);

            Reset();

            Context.AutoCompletes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAutoCompleteDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAutoCompleteTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/autocompletetypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/autocompletetypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAutoCompleteTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/autocompletetypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/autocompletetypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAutoCompleteTypesRead(ref IQueryable<ZarenBO2.Models.Zaren.AutoCompleteType> items);

        public async Task<IQueryable<ZarenBO2.Models.Zaren.AutoCompleteType>> GetAutoCompleteTypes(Query query = null)
        {
            var items = Context.AutoCompleteTypes.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnAutoCompleteTypesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAutoCompleteTypeGet(ZarenBO2.Models.Zaren.AutoCompleteType item);

        public async Task<ZarenBO2.Models.Zaren.AutoCompleteType> GetAutoCompleteTypeById(int id)
        {
            var items = Context.AutoCompleteTypes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAutoCompleteTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAutoCompleteTypeCreated(ZarenBO2.Models.Zaren.AutoCompleteType item);
        partial void OnAfterAutoCompleteTypeCreated(ZarenBO2.Models.Zaren.AutoCompleteType item);

        public async Task<ZarenBO2.Models.Zaren.AutoCompleteType> CreateAutoCompleteType(ZarenBO2.Models.Zaren.AutoCompleteType autocompletetype)
        {
            OnAutoCompleteTypeCreated(autocompletetype);

            var existingItem = Context.AutoCompleteTypes
                              .Where(i => i.Id == autocompletetype.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AutoCompleteTypes.Add(autocompletetype);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(autocompletetype).State = EntityState.Detached;
                throw;
            }

            OnAfterAutoCompleteTypeCreated(autocompletetype);

            return autocompletetype;
        }

        public async Task<ZarenBO2.Models.Zaren.AutoCompleteType> CancelAutoCompleteTypeChanges(ZarenBO2.Models.Zaren.AutoCompleteType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAutoCompleteTypeUpdated(ZarenBO2.Models.Zaren.AutoCompleteType item);
        partial void OnAfterAutoCompleteTypeUpdated(ZarenBO2.Models.Zaren.AutoCompleteType item);

        public async Task<ZarenBO2.Models.Zaren.AutoCompleteType> UpdateAutoCompleteType(int id, ZarenBO2.Models.Zaren.AutoCompleteType autocompletetype)
        {
            OnAutoCompleteTypeUpdated(autocompletetype);

            var itemToUpdate = Context.AutoCompleteTypes
                              .Where(i => i.Id == autocompletetype.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(autocompletetype).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAutoCompleteTypeUpdated(autocompletetype);

            return autocompletetype;
        }

        partial void OnAutoCompleteTypeDeleted(ZarenBO2.Models.Zaren.AutoCompleteType item);
        partial void OnAfterAutoCompleteTypeDeleted(ZarenBO2.Models.Zaren.AutoCompleteType item);

        public async Task<ZarenBO2.Models.Zaren.AutoCompleteType> DeleteAutoCompleteType(int id)
        {
            var itemToDelete = Context.AutoCompleteTypes
                              .Where(i => i.Id == id)
                              .Include(i => i.AutoCompletes)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAutoCompleteTypeDeleted(itemToDelete);

            Reset();

            Context.AutoCompleteTypes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAutoCompleteTypeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportBookingReservationsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/bookingreservations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/bookingreservations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportBookingReservationsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/bookingreservations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/bookingreservations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnBookingReservationsRead(ref IQueryable<ZarenBO2.Models.Zaren.BookingReservation> items);

        public async Task<IQueryable<ZarenBO2.Models.Zaren.BookingReservation>> GetBookingReservations(Query query = null)
        {
            var items = Context.BookingReservations.AsQueryable();

            items = items.Include(i => i.AspNetUser);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnBookingReservationsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnBookingReservationGet(ZarenBO2.Models.Zaren.BookingReservation item);

        public async Task<ZarenBO2.Models.Zaren.BookingReservation> GetBookingReservationById(int id)
        {
            var items = Context.BookingReservations
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.AspNetUser);
  
            var itemToReturn = items.FirstOrDefault();

            OnBookingReservationGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnBookingReservationCreated(ZarenBO2.Models.Zaren.BookingReservation item);
        partial void OnAfterBookingReservationCreated(ZarenBO2.Models.Zaren.BookingReservation item);

        public async Task<ZarenBO2.Models.Zaren.BookingReservation> CreateBookingReservation(ZarenBO2.Models.Zaren.BookingReservation bookingreservation)
        {
            OnBookingReservationCreated(bookingreservation);

            var existingItem = Context.BookingReservations
                              .Where(i => i.Id == bookingreservation.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.BookingReservations.Add(bookingreservation);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(bookingreservation).State = EntityState.Detached;
                throw;
            }

            OnAfterBookingReservationCreated(bookingreservation);

            return bookingreservation;
        }

        public async Task<ZarenBO2.Models.Zaren.BookingReservation> CancelBookingReservationChanges(ZarenBO2.Models.Zaren.BookingReservation item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnBookingReservationUpdated(ZarenBO2.Models.Zaren.BookingReservation item);
        partial void OnAfterBookingReservationUpdated(ZarenBO2.Models.Zaren.BookingReservation item);

        public async Task<ZarenBO2.Models.Zaren.BookingReservation> UpdateBookingReservation(int id, ZarenBO2.Models.Zaren.BookingReservation bookingreservation)
        {
            OnBookingReservationUpdated(bookingreservation);

            var itemToUpdate = Context.BookingReservations
                              .Where(i => i.Id == bookingreservation.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            bookingreservation.AspNetUser = null;

            Context.Attach(bookingreservation).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterBookingReservationUpdated(bookingreservation);

            return bookingreservation;
        }

        partial void OnBookingReservationDeleted(ZarenBO2.Models.Zaren.BookingReservation item);
        partial void OnAfterBookingReservationDeleted(ZarenBO2.Models.Zaren.BookingReservation item);

        public async Task<ZarenBO2.Models.Zaren.BookingReservation> DeleteBookingReservation(int id)
        {
            var itemToDelete = Context.BookingReservations
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnBookingReservationDeleted(itemToDelete);

            Reset();

            Context.BookingReservations.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterBookingReservationDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportBookingTravellersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/bookingtravellers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/bookingtravellers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportBookingTravellersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/bookingtravellers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/bookingtravellers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnBookingTravellersRead(ref IQueryable<ZarenBO2.Models.Zaren.BookingTraveller> items);

        public async Task<IQueryable<ZarenBO2.Models.Zaren.BookingTraveller>> GetBookingTravellers(Query query = null)
        {
            var items = Context.BookingTravellers.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnBookingTravellersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnBookingTravellerGet(ZarenBO2.Models.Zaren.BookingTraveller item);

        public async Task<ZarenBO2.Models.Zaren.BookingTraveller> GetBookingTravellerById(int id)
        {
            var items = Context.BookingTravellers
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnBookingTravellerGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnBookingTravellerCreated(ZarenBO2.Models.Zaren.BookingTraveller item);
        partial void OnAfterBookingTravellerCreated(ZarenBO2.Models.Zaren.BookingTraveller item);

        public async Task<ZarenBO2.Models.Zaren.BookingTraveller> CreateBookingTraveller(ZarenBO2.Models.Zaren.BookingTraveller bookingtraveller)
        {
            OnBookingTravellerCreated(bookingtraveller);

            var existingItem = Context.BookingTravellers
                              .Where(i => i.Id == bookingtraveller.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.BookingTravellers.Add(bookingtraveller);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(bookingtraveller).State = EntityState.Detached;
                throw;
            }

            OnAfterBookingTravellerCreated(bookingtraveller);

            return bookingtraveller;
        }

        public async Task<ZarenBO2.Models.Zaren.BookingTraveller> CancelBookingTravellerChanges(ZarenBO2.Models.Zaren.BookingTraveller item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnBookingTravellerUpdated(ZarenBO2.Models.Zaren.BookingTraveller item);
        partial void OnAfterBookingTravellerUpdated(ZarenBO2.Models.Zaren.BookingTraveller item);

        public async Task<ZarenBO2.Models.Zaren.BookingTraveller> UpdateBookingTraveller(int id, ZarenBO2.Models.Zaren.BookingTraveller bookingtraveller)
        {
            OnBookingTravellerUpdated(bookingtraveller);

            var itemToUpdate = Context.BookingTravellers
                              .Where(i => i.Id == bookingtraveller.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(bookingtraveller).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterBookingTravellerUpdated(bookingtraveller);

            return bookingtraveller;
        }

        partial void OnBookingTravellerDeleted(ZarenBO2.Models.Zaren.BookingTraveller item);
        partial void OnAfterBookingTravellerDeleted(ZarenBO2.Models.Zaren.BookingTraveller item);

        public async Task<ZarenBO2.Models.Zaren.BookingTraveller> DeleteBookingTraveller(int id)
        {
            var itemToDelete = Context.BookingTravellers
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnBookingTravellerDeleted(itemToDelete);

            Reset();

            Context.BookingTravellers.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterBookingTravellerDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCommissionsForDomainsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/commissionsfordomains/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/commissionsfordomains/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCommissionsForDomainsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/commissionsfordomains/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/commissionsfordomains/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCommissionsForDomainsRead(ref IQueryable<ZarenBO2.Models.Zaren.CommissionsForDomain> items);

        public async Task<IQueryable<ZarenBO2.Models.Zaren.CommissionsForDomain>> GetCommissionsForDomains(Query query = null)
        {
            var items = Context.CommissionsForDomains.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnCommissionsForDomainsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCommissionsForDomainGet(ZarenBO2.Models.Zaren.CommissionsForDomain item);

        public async Task<ZarenBO2.Models.Zaren.CommissionsForDomain> GetCommissionsForDomainById(int id)
        {
            var items = Context.CommissionsForDomains
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnCommissionsForDomainGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCommissionsForDomainCreated(ZarenBO2.Models.Zaren.CommissionsForDomain item);
        partial void OnAfterCommissionsForDomainCreated(ZarenBO2.Models.Zaren.CommissionsForDomain item);

        public async Task<ZarenBO2.Models.Zaren.CommissionsForDomain> CreateCommissionsForDomain(ZarenBO2.Models.Zaren.CommissionsForDomain commissionsfordomain)
        {
            OnCommissionsForDomainCreated(commissionsfordomain);

            var existingItem = Context.CommissionsForDomains
                              .Where(i => i.Id == commissionsfordomain.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.CommissionsForDomains.Add(commissionsfordomain);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(commissionsfordomain).State = EntityState.Detached;
                throw;
            }

            OnAfterCommissionsForDomainCreated(commissionsfordomain);

            return commissionsfordomain;
        }

        public async Task<ZarenBO2.Models.Zaren.CommissionsForDomain> CancelCommissionsForDomainChanges(ZarenBO2.Models.Zaren.CommissionsForDomain item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCommissionsForDomainUpdated(ZarenBO2.Models.Zaren.CommissionsForDomain item);
        partial void OnAfterCommissionsForDomainUpdated(ZarenBO2.Models.Zaren.CommissionsForDomain item);

        public async Task<ZarenBO2.Models.Zaren.CommissionsForDomain> UpdateCommissionsForDomain(int id, ZarenBO2.Models.Zaren.CommissionsForDomain commissionsfordomain)
        {
            OnCommissionsForDomainUpdated(commissionsfordomain);

            var itemToUpdate = Context.CommissionsForDomains
                              .Where(i => i.Id == commissionsfordomain.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(commissionsfordomain).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCommissionsForDomainUpdated(commissionsfordomain);

            return commissionsfordomain;
        }

        partial void OnCommissionsForDomainDeleted(ZarenBO2.Models.Zaren.CommissionsForDomain item);
        partial void OnAfterCommissionsForDomainDeleted(ZarenBO2.Models.Zaren.CommissionsForDomain item);

        public async Task<ZarenBO2.Models.Zaren.CommissionsForDomain> DeleteCommissionsForDomain(int id)
        {
            var itemToDelete = Context.CommissionsForDomains
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCommissionsForDomainDeleted(itemToDelete);

            Reset();

            Context.CommissionsForDomains.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCommissionsForDomainDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCountriesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/countries/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/countries/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCountriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/countries/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/countries/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCountriesRead(ref IQueryable<ZarenBO2.Models.Zaren.Country> items);

        public async Task<IQueryable<ZarenBO2.Models.Zaren.Country>> GetCountries(Query query = null)
        {
            var items = Context.Countries.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnCountriesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCountryGet(ZarenBO2.Models.Zaren.Country item);

        public async Task<ZarenBO2.Models.Zaren.Country> GetCountryById(int id)
        {
            var items = Context.Countries
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnCountryGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCountryCreated(ZarenBO2.Models.Zaren.Country item);
        partial void OnAfterCountryCreated(ZarenBO2.Models.Zaren.Country item);

        public async Task<ZarenBO2.Models.Zaren.Country> CreateCountry(ZarenBO2.Models.Zaren.Country country)
        {
            OnCountryCreated(country);

            var existingItem = Context.Countries
                              .Where(i => i.Id == country.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Countries.Add(country);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(country).State = EntityState.Detached;
                throw;
            }

            OnAfterCountryCreated(country);

            return country;
        }

        public async Task<ZarenBO2.Models.Zaren.Country> CancelCountryChanges(ZarenBO2.Models.Zaren.Country item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCountryUpdated(ZarenBO2.Models.Zaren.Country item);
        partial void OnAfterCountryUpdated(ZarenBO2.Models.Zaren.Country item);

        public async Task<ZarenBO2.Models.Zaren.Country> UpdateCountry(int id, ZarenBO2.Models.Zaren.Country country)
        {
            OnCountryUpdated(country);

            var itemToUpdate = Context.Countries
                              .Where(i => i.Id == country.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(country).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCountryUpdated(country);

            return country;
        }

        partial void OnCountryDeleted(ZarenBO2.Models.Zaren.Country item);
        partial void OnAfterCountryDeleted(ZarenBO2.Models.Zaren.Country item);

        public async Task<ZarenBO2.Models.Zaren.Country> DeleteCountry(int id)
        {
            var itemToDelete = Context.Countries
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCountryDeleted(itemToDelete);

            Reset();

            Context.Countries.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCountryDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCurrenciesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/currencies/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/currencies/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCurrenciesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/currencies/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/currencies/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCurrenciesRead(ref IQueryable<ZarenBO2.Models.Zaren.Currency> items);

        public async Task<IQueryable<ZarenBO2.Models.Zaren.Currency>> GetCurrencies(Query query = null)
        {
            var items = Context.Currencies.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnCurrenciesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCurrencyGet(ZarenBO2.Models.Zaren.Currency item);

        public async Task<ZarenBO2.Models.Zaren.Currency> GetCurrencyById(int id)
        {
            var items = Context.Currencies
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnCurrencyGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCurrencyCreated(ZarenBO2.Models.Zaren.Currency item);
        partial void OnAfterCurrencyCreated(ZarenBO2.Models.Zaren.Currency item);

        public async Task<ZarenBO2.Models.Zaren.Currency> CreateCurrency(ZarenBO2.Models.Zaren.Currency currency)
        {
            OnCurrencyCreated(currency);

            var existingItem = Context.Currencies
                              .Where(i => i.Id == currency.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Currencies.Add(currency);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(currency).State = EntityState.Detached;
                throw;
            }

            OnAfterCurrencyCreated(currency);

            return currency;
        }

        public async Task<ZarenBO2.Models.Zaren.Currency> CancelCurrencyChanges(ZarenBO2.Models.Zaren.Currency item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCurrencyUpdated(ZarenBO2.Models.Zaren.Currency item);
        partial void OnAfterCurrencyUpdated(ZarenBO2.Models.Zaren.Currency item);

        public async Task<ZarenBO2.Models.Zaren.Currency> UpdateCurrency(int id, ZarenBO2.Models.Zaren.Currency currency)
        {
            OnCurrencyUpdated(currency);

            var itemToUpdate = Context.Currencies
                              .Where(i => i.Id == currency.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(currency).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCurrencyUpdated(currency);

            return currency;
        }

        partial void OnCurrencyDeleted(ZarenBO2.Models.Zaren.Currency item);
        partial void OnAfterCurrencyDeleted(ZarenBO2.Models.Zaren.Currency item);

        public async Task<ZarenBO2.Models.Zaren.Currency> DeleteCurrency(int id)
        {
            var itemToDelete = Context.Currencies
                              .Where(i => i.Id == id)
                              .Include(i => i.Transactions)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCurrencyDeleted(itemToDelete);

            Reset();

            Context.Currencies.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCurrencyDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportLanguagesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/languages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/languages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportLanguagesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/languages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/languages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnLanguagesRead(ref IQueryable<ZarenBO2.Models.Zaren.Language> items);

        public async Task<IQueryable<ZarenBO2.Models.Zaren.Language>> GetLanguages(Query query = null)
        {
            var items = Context.Languages.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnLanguagesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnLanguageGet(ZarenBO2.Models.Zaren.Language item);

        public async Task<ZarenBO2.Models.Zaren.Language> GetLanguageById(int id)
        {
            var items = Context.Languages
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnLanguageGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnLanguageCreated(ZarenBO2.Models.Zaren.Language item);
        partial void OnAfterLanguageCreated(ZarenBO2.Models.Zaren.Language item);

        public async Task<ZarenBO2.Models.Zaren.Language> CreateLanguage(ZarenBO2.Models.Zaren.Language language)
        {
            OnLanguageCreated(language);

            var existingItem = Context.Languages
                              .Where(i => i.Id == language.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Languages.Add(language);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(language).State = EntityState.Detached;
                throw;
            }

            OnAfterLanguageCreated(language);

            return language;
        }

        public async Task<ZarenBO2.Models.Zaren.Language> CancelLanguageChanges(ZarenBO2.Models.Zaren.Language item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnLanguageUpdated(ZarenBO2.Models.Zaren.Language item);
        partial void OnAfterLanguageUpdated(ZarenBO2.Models.Zaren.Language item);

        public async Task<ZarenBO2.Models.Zaren.Language> UpdateLanguage(int id, ZarenBO2.Models.Zaren.Language language)
        {
            OnLanguageUpdated(language);

            var itemToUpdate = Context.Languages
                              .Where(i => i.Id == language.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(language).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterLanguageUpdated(language);

            return language;
        }

        partial void OnLanguageDeleted(ZarenBO2.Models.Zaren.Language item);
        partial void OnAfterLanguageDeleted(ZarenBO2.Models.Zaren.Language item);

        public async Task<ZarenBO2.Models.Zaren.Language> DeleteLanguage(int id)
        {
            var itemToDelete = Context.Languages
                              .Where(i => i.Id == id)
                              .Include(i => i.PaymentConfigurations)
                              .Include(i => i.Transactions)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnLanguageDeleted(itemToDelete);

            Reset();

            Context.Languages.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterLanguageDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportPaymentConfigurationsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/paymentconfigurations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/paymentconfigurations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPaymentConfigurationsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/paymentconfigurations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/paymentconfigurations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPaymentConfigurationsRead(ref IQueryable<ZarenBO2.Models.Zaren.PaymentConfiguration> items);

        public async Task<IQueryable<ZarenBO2.Models.Zaren.PaymentConfiguration>> GetPaymentConfigurations(Query query = null)
        {
            var items = Context.PaymentConfigurations.AsQueryable();

            items = items.Include(i => i.Language1);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPaymentConfigurationsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnPaymentConfigurationGet(ZarenBO2.Models.Zaren.PaymentConfiguration item);

        public async Task<ZarenBO2.Models.Zaren.PaymentConfiguration> GetPaymentConfigurationById(int id)
        {
            var items = Context.PaymentConfigurations
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Language1);
  
            var itemToReturn = items.FirstOrDefault();

            OnPaymentConfigurationGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnPaymentConfigurationCreated(ZarenBO2.Models.Zaren.PaymentConfiguration item);
        partial void OnAfterPaymentConfigurationCreated(ZarenBO2.Models.Zaren.PaymentConfiguration item);

        public async Task<ZarenBO2.Models.Zaren.PaymentConfiguration> CreatePaymentConfiguration(ZarenBO2.Models.Zaren.PaymentConfiguration paymentconfiguration)
        {
            OnPaymentConfigurationCreated(paymentconfiguration);

            var existingItem = Context.PaymentConfigurations
                              .Where(i => i.Id == paymentconfiguration.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.PaymentConfigurations.Add(paymentconfiguration);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(paymentconfiguration).State = EntityState.Detached;
                throw;
            }

            OnAfterPaymentConfigurationCreated(paymentconfiguration);

            return paymentconfiguration;
        }

        public async Task<ZarenBO2.Models.Zaren.PaymentConfiguration> CancelPaymentConfigurationChanges(ZarenBO2.Models.Zaren.PaymentConfiguration item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnPaymentConfigurationUpdated(ZarenBO2.Models.Zaren.PaymentConfiguration item);
        partial void OnAfterPaymentConfigurationUpdated(ZarenBO2.Models.Zaren.PaymentConfiguration item);

        public async Task<ZarenBO2.Models.Zaren.PaymentConfiguration> UpdatePaymentConfiguration(int id, ZarenBO2.Models.Zaren.PaymentConfiguration paymentconfiguration)
        {
            OnPaymentConfigurationUpdated(paymentconfiguration);

            var itemToUpdate = Context.PaymentConfigurations
                              .Where(i => i.Id == paymentconfiguration.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            paymentconfiguration.Language1 = null;

            Context.Attach(paymentconfiguration).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterPaymentConfigurationUpdated(paymentconfiguration);

            return paymentconfiguration;
        }

        partial void OnPaymentConfigurationDeleted(ZarenBO2.Models.Zaren.PaymentConfiguration item);
        partial void OnAfterPaymentConfigurationDeleted(ZarenBO2.Models.Zaren.PaymentConfiguration item);

        public async Task<ZarenBO2.Models.Zaren.PaymentConfiguration> DeletePaymentConfiguration(int id)
        {
            var itemToDelete = Context.PaymentConfigurations
                              .Where(i => i.Id == id)
                              .Include(i => i.TestCards)
                              .Include(i => i.Transactions)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnPaymentConfigurationDeleted(itemToDelete);

            Reset();

            Context.PaymentConfigurations.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterPaymentConfigurationDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportPaymentLogsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/paymentlogs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/paymentlogs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPaymentLogsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/paymentlogs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/paymentlogs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPaymentLogsRead(ref IQueryable<ZarenBO2.Models.Zaren.PaymentLog> items);

        public async Task<IQueryable<ZarenBO2.Models.Zaren.PaymentLog>> GetPaymentLogs(Query query = null)
        {
            var items = Context.PaymentLogs.AsQueryable();

            items = items.Include(i => i.Transaction);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPaymentLogsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnPaymentLogGet(ZarenBO2.Models.Zaren.PaymentLog item);

        public async Task<ZarenBO2.Models.Zaren.PaymentLog> GetPaymentLogById(int id)
        {
            var items = Context.PaymentLogs
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Transaction);
  
            var itemToReturn = items.FirstOrDefault();

            OnPaymentLogGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnPaymentLogCreated(ZarenBO2.Models.Zaren.PaymentLog item);
        partial void OnAfterPaymentLogCreated(ZarenBO2.Models.Zaren.PaymentLog item);

        public async Task<ZarenBO2.Models.Zaren.PaymentLog> CreatePaymentLog(ZarenBO2.Models.Zaren.PaymentLog paymentlog)
        {
            OnPaymentLogCreated(paymentlog);

            var existingItem = Context.PaymentLogs
                              .Where(i => i.Id == paymentlog.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.PaymentLogs.Add(paymentlog);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(paymentlog).State = EntityState.Detached;
                throw;
            }

            OnAfterPaymentLogCreated(paymentlog);

            return paymentlog;
        }

        public async Task<ZarenBO2.Models.Zaren.PaymentLog> CancelPaymentLogChanges(ZarenBO2.Models.Zaren.PaymentLog item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnPaymentLogUpdated(ZarenBO2.Models.Zaren.PaymentLog item);
        partial void OnAfterPaymentLogUpdated(ZarenBO2.Models.Zaren.PaymentLog item);

        public async Task<ZarenBO2.Models.Zaren.PaymentLog> UpdatePaymentLog(int id, ZarenBO2.Models.Zaren.PaymentLog paymentlog)
        {
            OnPaymentLogUpdated(paymentlog);

            var itemToUpdate = Context.PaymentLogs
                              .Where(i => i.Id == paymentlog.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            paymentlog.Transaction = null;

            Context.Attach(paymentlog).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterPaymentLogUpdated(paymentlog);

            return paymentlog;
        }

        partial void OnPaymentLogDeleted(ZarenBO2.Models.Zaren.PaymentLog item);
        partial void OnAfterPaymentLogDeleted(ZarenBO2.Models.Zaren.PaymentLog item);

        public async Task<ZarenBO2.Models.Zaren.PaymentLog> DeletePaymentLog(int id)
        {
            var itemToDelete = Context.PaymentLogs
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnPaymentLogDeleted(itemToDelete);

            Reset();

            Context.PaymentLogs.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterPaymentLogDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportPossibleQueriesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/possiblequeries/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/possiblequeries/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPossibleQueriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/possiblequeries/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/possiblequeries/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPossibleQueriesRead(ref IQueryable<ZarenBO2.Models.Zaren.PossibleQuery> items);

        public async Task<IQueryable<ZarenBO2.Models.Zaren.PossibleQuery>> GetPossibleQueries(Query query = null)
        {
            var items = Context.PossibleQueries.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPossibleQueriesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnPossibleQueryGet(ZarenBO2.Models.Zaren.PossibleQuery item);

        public async Task<ZarenBO2.Models.Zaren.PossibleQuery> GetPossibleQueryById(int id)
        {
            var items = Context.PossibleQueries
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnPossibleQueryGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnPossibleQueryCreated(ZarenBO2.Models.Zaren.PossibleQuery item);
        partial void OnAfterPossibleQueryCreated(ZarenBO2.Models.Zaren.PossibleQuery item);

        public async Task<ZarenBO2.Models.Zaren.PossibleQuery> CreatePossibleQuery(ZarenBO2.Models.Zaren.PossibleQuery possiblequery)
        {
            OnPossibleQueryCreated(possiblequery);

            var existingItem = Context.PossibleQueries
                              .Where(i => i.Id == possiblequery.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.PossibleQueries.Add(possiblequery);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(possiblequery).State = EntityState.Detached;
                throw;
            }

            OnAfterPossibleQueryCreated(possiblequery);

            return possiblequery;
        }

        public async Task<ZarenBO2.Models.Zaren.PossibleQuery> CancelPossibleQueryChanges(ZarenBO2.Models.Zaren.PossibleQuery item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnPossibleQueryUpdated(ZarenBO2.Models.Zaren.PossibleQuery item);
        partial void OnAfterPossibleQueryUpdated(ZarenBO2.Models.Zaren.PossibleQuery item);

        public async Task<ZarenBO2.Models.Zaren.PossibleQuery> UpdatePossibleQuery(int id, ZarenBO2.Models.Zaren.PossibleQuery possiblequery)
        {
            OnPossibleQueryUpdated(possiblequery);

            var itemToUpdate = Context.PossibleQueries
                              .Where(i => i.Id == possiblequery.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(possiblequery).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterPossibleQueryUpdated(possiblequery);

            return possiblequery;
        }

        partial void OnPossibleQueryDeleted(ZarenBO2.Models.Zaren.PossibleQuery item);
        partial void OnAfterPossibleQueryDeleted(ZarenBO2.Models.Zaren.PossibleQuery item);

        public async Task<ZarenBO2.Models.Zaren.PossibleQuery> DeletePossibleQuery(int id)
        {
            var itemToDelete = Context.PossibleQueries
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnPossibleQueryDeleted(itemToDelete);

            Reset();

            Context.PossibleQueries.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterPossibleQueryDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportResourcesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/resources/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/resources/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportResourcesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/resources/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/resources/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnResourcesRead(ref IQueryable<ZarenBO2.Models.Zaren.Resource> items);

        public async Task<IQueryable<ZarenBO2.Models.Zaren.Resource>> GetResources(Query query = null)
        {
            var items = Context.Resources.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnResourcesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnResourceGet(ZarenBO2.Models.Zaren.Resource item);

        public async Task<ZarenBO2.Models.Zaren.Resource> GetResourceById(int id)
        {
            var items = Context.Resources
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnResourceGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnResourceCreated(ZarenBO2.Models.Zaren.Resource item);
        partial void OnAfterResourceCreated(ZarenBO2.Models.Zaren.Resource item);

        public async Task<ZarenBO2.Models.Zaren.Resource> CreateResource(ZarenBO2.Models.Zaren.Resource resource)
        {
            OnResourceCreated(resource);

            var existingItem = Context.Resources
                              .Where(i => i.Id == resource.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Resources.Add(resource);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(resource).State = EntityState.Detached;
                throw;
            }

            OnAfterResourceCreated(resource);

            return resource;
        }

        public async Task<ZarenBO2.Models.Zaren.Resource> CancelResourceChanges(ZarenBO2.Models.Zaren.Resource item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnResourceUpdated(ZarenBO2.Models.Zaren.Resource item);
        partial void OnAfterResourceUpdated(ZarenBO2.Models.Zaren.Resource item);

        public async Task<ZarenBO2.Models.Zaren.Resource> UpdateResource(int id, ZarenBO2.Models.Zaren.Resource resource)
        {
            OnResourceUpdated(resource);

            var itemToUpdate = Context.Resources
                              .Where(i => i.Id == resource.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(resource).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterResourceUpdated(resource);

            return resource;
        }

        partial void OnResourceDeleted(ZarenBO2.Models.Zaren.Resource item);
        partial void OnAfterResourceDeleted(ZarenBO2.Models.Zaren.Resource item);

        public async Task<ZarenBO2.Models.Zaren.Resource> DeleteResource(int id)
        {
            var itemToDelete = Context.Resources
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnResourceDeleted(itemToDelete);

            Reset();

            Context.Resources.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterResourceDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTestCardsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/testcards/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/testcards/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTestCardsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/testcards/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/testcards/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTestCardsRead(ref IQueryable<ZarenBO2.Models.Zaren.TestCard> items);

        public async Task<IQueryable<ZarenBO2.Models.Zaren.TestCard>> GetTestCards(Query query = null)
        {
            var items = Context.TestCards.AsQueryable();

            items = items.Include(i => i.PaymentConfiguration);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTestCardsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTestCardGet(ZarenBO2.Models.Zaren.TestCard item);

        public async Task<ZarenBO2.Models.Zaren.TestCard> GetTestCardById(int id)
        {
            var items = Context.TestCards
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.PaymentConfiguration);
  
            var itemToReturn = items.FirstOrDefault();

            OnTestCardGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTestCardCreated(ZarenBO2.Models.Zaren.TestCard item);
        partial void OnAfterTestCardCreated(ZarenBO2.Models.Zaren.TestCard item);

        public async Task<ZarenBO2.Models.Zaren.TestCard> CreateTestCard(ZarenBO2.Models.Zaren.TestCard testcard)
        {
            OnTestCardCreated(testcard);

            var existingItem = Context.TestCards
                              .Where(i => i.Id == testcard.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TestCards.Add(testcard);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(testcard).State = EntityState.Detached;
                throw;
            }

            OnAfterTestCardCreated(testcard);

            return testcard;
        }

        public async Task<ZarenBO2.Models.Zaren.TestCard> CancelTestCardChanges(ZarenBO2.Models.Zaren.TestCard item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTestCardUpdated(ZarenBO2.Models.Zaren.TestCard item);
        partial void OnAfterTestCardUpdated(ZarenBO2.Models.Zaren.TestCard item);

        public async Task<ZarenBO2.Models.Zaren.TestCard> UpdateTestCard(int id, ZarenBO2.Models.Zaren.TestCard testcard)
        {
            OnTestCardUpdated(testcard);

            var itemToUpdate = Context.TestCards
                              .Where(i => i.Id == testcard.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            testcard.PaymentConfiguration = null;

            Context.Attach(testcard).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTestCardUpdated(testcard);

            return testcard;
        }

        partial void OnTestCardDeleted(ZarenBO2.Models.Zaren.TestCard item);
        partial void OnAfterTestCardDeleted(ZarenBO2.Models.Zaren.TestCard item);

        public async Task<ZarenBO2.Models.Zaren.TestCard> DeleteTestCard(int id)
        {
            var itemToDelete = Context.TestCards
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTestCardDeleted(itemToDelete);

            Reset();

            Context.TestCards.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTestCardDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTransactionDetailsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/transactiondetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/transactiondetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTransactionDetailsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/transactiondetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/transactiondetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTransactionDetailsRead(ref IQueryable<ZarenBO2.Models.Zaren.TransactionDetail> items);

        public async Task<IQueryable<ZarenBO2.Models.Zaren.TransactionDetail>> GetTransactionDetails(Query query = null)
        {
            var items = Context.TransactionDetails.AsQueryable();

            items = items.Include(i => i.Transaction);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTransactionDetailsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTransactionDetailGet(ZarenBO2.Models.Zaren.TransactionDetail item);

        public async Task<ZarenBO2.Models.Zaren.TransactionDetail> GetTransactionDetailById(int id)
        {
            var items = Context.TransactionDetails
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Transaction);
  
            var itemToReturn = items.FirstOrDefault();

            OnTransactionDetailGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTransactionDetailCreated(ZarenBO2.Models.Zaren.TransactionDetail item);
        partial void OnAfterTransactionDetailCreated(ZarenBO2.Models.Zaren.TransactionDetail item);

        public async Task<ZarenBO2.Models.Zaren.TransactionDetail> CreateTransactionDetail(ZarenBO2.Models.Zaren.TransactionDetail transactiondetail)
        {
            OnTransactionDetailCreated(transactiondetail);

            var existingItem = Context.TransactionDetails
                              .Where(i => i.Id == transactiondetail.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TransactionDetails.Add(transactiondetail);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(transactiondetail).State = EntityState.Detached;
                throw;
            }

            OnAfterTransactionDetailCreated(transactiondetail);

            return transactiondetail;
        }

        public async Task<ZarenBO2.Models.Zaren.TransactionDetail> CancelTransactionDetailChanges(ZarenBO2.Models.Zaren.TransactionDetail item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTransactionDetailUpdated(ZarenBO2.Models.Zaren.TransactionDetail item);
        partial void OnAfterTransactionDetailUpdated(ZarenBO2.Models.Zaren.TransactionDetail item);

        public async Task<ZarenBO2.Models.Zaren.TransactionDetail> UpdateTransactionDetail(int id, ZarenBO2.Models.Zaren.TransactionDetail transactiondetail)
        {
            OnTransactionDetailUpdated(transactiondetail);

            var itemToUpdate = Context.TransactionDetails
                              .Where(i => i.Id == transactiondetail.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            transactiondetail.Transaction = null;

            Context.Attach(transactiondetail).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTransactionDetailUpdated(transactiondetail);

            return transactiondetail;
        }

        partial void OnTransactionDetailDeleted(ZarenBO2.Models.Zaren.TransactionDetail item);
        partial void OnAfterTransactionDetailDeleted(ZarenBO2.Models.Zaren.TransactionDetail item);

        public async Task<ZarenBO2.Models.Zaren.TransactionDetail> DeleteTransactionDetail(int id)
        {
            var itemToDelete = Context.TransactionDetails
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTransactionDetailDeleted(itemToDelete);

            Reset();

            Context.TransactionDetails.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTransactionDetailDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTransactionsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/transactions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/transactions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTransactionsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/transactions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/transactions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTransactionsRead(ref IQueryable<ZarenBO2.Models.Zaren.Transaction> items);

        public async Task<IQueryable<ZarenBO2.Models.Zaren.Transaction>> GetTransactions(Query query = null)
        {
            var items = Context.Transactions.AsQueryable();

            items = items.Include(i => i.Currency1);
            items = items.Include(i => i.Language1);
            items = items.Include(i => i.PaymentConfiguration);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTransactionsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTransactionGet(ZarenBO2.Models.Zaren.Transaction item);

        public async Task<ZarenBO2.Models.Zaren.Transaction> GetTransactionById(int id)
        {
            var items = Context.Transactions
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Currency1);
            items = items.Include(i => i.Language1);
            items = items.Include(i => i.PaymentConfiguration);
  
            var itemToReturn = items.FirstOrDefault();

            OnTransactionGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTransactionCreated(ZarenBO2.Models.Zaren.Transaction item);
        partial void OnAfterTransactionCreated(ZarenBO2.Models.Zaren.Transaction item);

        public async Task<ZarenBO2.Models.Zaren.Transaction> CreateTransaction(ZarenBO2.Models.Zaren.Transaction transaction)
        {
            OnTransactionCreated(transaction);

            var existingItem = Context.Transactions
                              .Where(i => i.Id == transaction.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Transactions.Add(transaction);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(transaction).State = EntityState.Detached;
                throw;
            }

            OnAfterTransactionCreated(transaction);

            return transaction;
        }

        public async Task<ZarenBO2.Models.Zaren.Transaction> CancelTransactionChanges(ZarenBO2.Models.Zaren.Transaction item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTransactionUpdated(ZarenBO2.Models.Zaren.Transaction item);
        partial void OnAfterTransactionUpdated(ZarenBO2.Models.Zaren.Transaction item);

        public async Task<ZarenBO2.Models.Zaren.Transaction> UpdateTransaction(int id, ZarenBO2.Models.Zaren.Transaction transaction)
        {
            OnTransactionUpdated(transaction);

            var itemToUpdate = Context.Transactions
                              .Where(i => i.Id == transaction.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            transaction.Currency1 = null;
            transaction.Language1 = null;
            transaction.PaymentConfiguration = null;

            Context.Attach(transaction).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTransactionUpdated(transaction);

            return transaction;
        }

        partial void OnTransactionDeleted(ZarenBO2.Models.Zaren.Transaction item);
        partial void OnAfterTransactionDeleted(ZarenBO2.Models.Zaren.Transaction item);

        public async Task<ZarenBO2.Models.Zaren.Transaction> DeleteTransaction(int id)
        {
            var itemToDelete = Context.Transactions
                              .Where(i => i.Id == id)
                              .Include(i => i.PaymentLogs)
                              .Include(i => i.TransactionDetails)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTransactionDeleted(itemToDelete);

            Reset();

            Context.Transactions.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTransactionDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportPaymentOptionsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/paymentoptions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/paymentoptions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPaymentOptionsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/paymentoptions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/paymentoptions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPaymentOptionsRead(ref IQueryable<ZarenBO2.Models.Zaren.PaymentOption> items);

        public async Task<IQueryable<ZarenBO2.Models.Zaren.PaymentOption>> GetPaymentOptions(Query query = null)
        {
            var items = Context.PaymentOptions.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPaymentOptionsRead(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportPaymentProvidersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/paymentproviders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/paymentproviders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPaymentProvidersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/paymentproviders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/paymentproviders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPaymentProvidersRead(ref IQueryable<ZarenBO2.Models.Zaren.PaymentProvider> items);

        public async Task<IQueryable<ZarenBO2.Models.Zaren.PaymentProvider>> GetPaymentProviders(Query query = null)
        {
            var items = Context.PaymentProviders.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPaymentProvidersRead(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportPaymentReservationStatusesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/paymentreservationstatuses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/paymentreservationstatuses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPaymentReservationStatusesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/paymentreservationstatuses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/paymentreservationstatuses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPaymentReservationStatusesRead(ref IQueryable<ZarenBO2.Models.Zaren.PaymentReservationStatus> items);

        public async Task<IQueryable<ZarenBO2.Models.Zaren.PaymentReservationStatus>> GetPaymentReservationStatuses(Query query = null)
        {
            var items = Context.PaymentReservationStatuses.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPaymentReservationStatusesRead(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportPaymentStatusesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/paymentstatuses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/paymentstatuses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPaymentStatusesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/paymentstatuses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/paymentstatuses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPaymentStatusesRead(ref IQueryable<ZarenBO2.Models.Zaren.PaymentStatus> items);

        public async Task<IQueryable<ZarenBO2.Models.Zaren.PaymentStatus>> GetPaymentStatuses(Query query = null)
        {
            var items = Context.PaymentStatuses.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPaymentStatusesRead(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportPaymentTransactionResponseTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/paymenttransactionresponsetypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/paymenttransactionresponsetypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPaymentTransactionResponseTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/paymenttransactionresponsetypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/paymenttransactionresponsetypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPaymentTransactionResponseTypesRead(ref IQueryable<ZarenBO2.Models.Zaren.PaymentTransactionResponseType> items);

        public async Task<IQueryable<ZarenBO2.Models.Zaren.PaymentTransactionResponseType>> GetPaymentTransactionResponseTypes(Query query = null)
        {
            var items = Context.PaymentTransactionResponseTypes.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPaymentTransactionResponseTypesRead(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportPaymentTransactionStatusesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/paymenttransactionstatuses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/paymenttransactionstatuses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPaymentTransactionStatusesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/paymenttransactionstatuses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/paymenttransactionstatuses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPaymentTransactionStatusesRead(ref IQueryable<ZarenBO2.Models.Zaren.PaymentTransactionStatus> items);

        public async Task<IQueryable<ZarenBO2.Models.Zaren.PaymentTransactionStatus>> GetPaymentTransactionStatuses(Query query = null)
        {
            var items = Context.PaymentTransactionStatuses.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPaymentTransactionStatusesRead(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportPaymentTransactionTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/paymenttransactiontypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/paymenttransactiontypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPaymentTransactionTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/paymenttransactiontypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/paymenttransactiontypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPaymentTransactionTypesRead(ref IQueryable<ZarenBO2.Models.Zaren.PaymentTransactionType> items);

        public async Task<IQueryable<ZarenBO2.Models.Zaren.PaymentTransactionType>> GetPaymentTransactionTypes(Query query = null)
        {
            var items = Context.PaymentTransactionTypes.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPaymentTransactionTypesRead(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportAspNetRoleClaimsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/aspnetroleclaims/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/aspnetroleclaims/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAspNetRoleClaimsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/aspnetroleclaims/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/aspnetroleclaims/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAspNetRoleClaimsRead(ref IQueryable<ZarenBO2.Models.Zaren.AspNetRoleClaim> items);

        public async Task<IQueryable<ZarenBO2.Models.Zaren.AspNetRoleClaim>> GetAspNetRoleClaims(Query query = null)
        {
            var items = Context.AspNetRoleClaims.AsQueryable();

            items = items.Include(i => i.AspNetRole);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnAspNetRoleClaimsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAspNetRoleClaimGet(ZarenBO2.Models.Zaren.AspNetRoleClaim item);

        public async Task<ZarenBO2.Models.Zaren.AspNetRoleClaim> GetAspNetRoleClaimById(int id)
        {
            var items = Context.AspNetRoleClaims
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.AspNetRole);
  
            var itemToReturn = items.FirstOrDefault();

            OnAspNetRoleClaimGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAspNetRoleClaimCreated(ZarenBO2.Models.Zaren.AspNetRoleClaim item);
        partial void OnAfterAspNetRoleClaimCreated(ZarenBO2.Models.Zaren.AspNetRoleClaim item);

        public async Task<ZarenBO2.Models.Zaren.AspNetRoleClaim> CreateAspNetRoleClaim(ZarenBO2.Models.Zaren.AspNetRoleClaim aspnetroleclaim)
        {
            OnAspNetRoleClaimCreated(aspnetroleclaim);

            var existingItem = Context.AspNetRoleClaims
                              .Where(i => i.Id == aspnetroleclaim.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AspNetRoleClaims.Add(aspnetroleclaim);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(aspnetroleclaim).State = EntityState.Detached;
                throw;
            }

            OnAfterAspNetRoleClaimCreated(aspnetroleclaim);

            return aspnetroleclaim;
        }

        public async Task<ZarenBO2.Models.Zaren.AspNetRoleClaim> CancelAspNetRoleClaimChanges(ZarenBO2.Models.Zaren.AspNetRoleClaim item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAspNetRoleClaimUpdated(ZarenBO2.Models.Zaren.AspNetRoleClaim item);
        partial void OnAfterAspNetRoleClaimUpdated(ZarenBO2.Models.Zaren.AspNetRoleClaim item);

        public async Task<ZarenBO2.Models.Zaren.AspNetRoleClaim> UpdateAspNetRoleClaim(int id, ZarenBO2.Models.Zaren.AspNetRoleClaim aspnetroleclaim)
        {
            OnAspNetRoleClaimUpdated(aspnetroleclaim);

            var itemToUpdate = Context.AspNetRoleClaims
                              .Where(i => i.Id == aspnetroleclaim.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            aspnetroleclaim.AspNetRole = null;

            Context.Attach(aspnetroleclaim).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAspNetRoleClaimUpdated(aspnetroleclaim);

            return aspnetroleclaim;
        }

        partial void OnAspNetRoleClaimDeleted(ZarenBO2.Models.Zaren.AspNetRoleClaim item);
        partial void OnAfterAspNetRoleClaimDeleted(ZarenBO2.Models.Zaren.AspNetRoleClaim item);

        public async Task<ZarenBO2.Models.Zaren.AspNetRoleClaim> DeleteAspNetRoleClaim(int id)
        {
            var itemToDelete = Context.AspNetRoleClaims
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAspNetRoleClaimDeleted(itemToDelete);

            Reset();

            Context.AspNetRoleClaims.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAspNetRoleClaimDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAspNetRolesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/aspnetroles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/aspnetroles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAspNetRolesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/aspnetroles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/aspnetroles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAspNetRolesRead(ref IQueryable<ZarenBO2.Models.Zaren.AspNetRole> items);

        public async Task<IQueryable<ZarenBO2.Models.Zaren.AspNetRole>> GetAspNetRoles(Query query = null)
        {
            var items = Context.AspNetRoles.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnAspNetRolesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAspNetRoleGet(ZarenBO2.Models.Zaren.AspNetRole item);

        public async Task<ZarenBO2.Models.Zaren.AspNetRole> GetAspNetRoleById(string id)
        {
            var items = Context.AspNetRoles
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAspNetRoleGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAspNetRoleCreated(ZarenBO2.Models.Zaren.AspNetRole item);
        partial void OnAfterAspNetRoleCreated(ZarenBO2.Models.Zaren.AspNetRole item);

        public async Task<ZarenBO2.Models.Zaren.AspNetRole> CreateAspNetRole(ZarenBO2.Models.Zaren.AspNetRole aspnetrole)
        {
            OnAspNetRoleCreated(aspnetrole);

            var existingItem = Context.AspNetRoles
                              .Where(i => i.Id == aspnetrole.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AspNetRoles.Add(aspnetrole);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(aspnetrole).State = EntityState.Detached;
                throw;
            }

            OnAfterAspNetRoleCreated(aspnetrole);

            return aspnetrole;
        }

        public async Task<ZarenBO2.Models.Zaren.AspNetRole> CancelAspNetRoleChanges(ZarenBO2.Models.Zaren.AspNetRole item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAspNetRoleUpdated(ZarenBO2.Models.Zaren.AspNetRole item);
        partial void OnAfterAspNetRoleUpdated(ZarenBO2.Models.Zaren.AspNetRole item);

        public async Task<ZarenBO2.Models.Zaren.AspNetRole> UpdateAspNetRole(string id, ZarenBO2.Models.Zaren.AspNetRole aspnetrole)
        {
            OnAspNetRoleUpdated(aspnetrole);

            var itemToUpdate = Context.AspNetRoles
                              .Where(i => i.Id == aspnetrole.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(aspnetrole).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAspNetRoleUpdated(aspnetrole);

            return aspnetrole;
        }

        partial void OnAspNetRoleDeleted(ZarenBO2.Models.Zaren.AspNetRole item);
        partial void OnAfterAspNetRoleDeleted(ZarenBO2.Models.Zaren.AspNetRole item);

        public async Task<ZarenBO2.Models.Zaren.AspNetRole> DeleteAspNetRole(string id)
        {
            var itemToDelete = Context.AspNetRoles
                              .Where(i => i.Id == id)
                              .Include(i => i.AspNetRoleClaims)
                              .Include(i => i.AspNetUserRoles)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAspNetRoleDeleted(itemToDelete);

            Reset();

            Context.AspNetRoles.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAspNetRoleDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAspNetUserClaimsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/aspnetuserclaims/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/aspnetuserclaims/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAspNetUserClaimsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/aspnetuserclaims/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/aspnetuserclaims/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAspNetUserClaimsRead(ref IQueryable<ZarenBO2.Models.Zaren.AspNetUserClaim> items);

        public async Task<IQueryable<ZarenBO2.Models.Zaren.AspNetUserClaim>> GetAspNetUserClaims(Query query = null)
        {
            var items = Context.AspNetUserClaims.AsQueryable();

            items = items.Include(i => i.AspNetUser);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnAspNetUserClaimsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAspNetUserClaimGet(ZarenBO2.Models.Zaren.AspNetUserClaim item);

        public async Task<ZarenBO2.Models.Zaren.AspNetUserClaim> GetAspNetUserClaimById(int id)
        {
            var items = Context.AspNetUserClaims
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.AspNetUser);
  
            var itemToReturn = items.FirstOrDefault();

            OnAspNetUserClaimGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAspNetUserClaimCreated(ZarenBO2.Models.Zaren.AspNetUserClaim item);
        partial void OnAfterAspNetUserClaimCreated(ZarenBO2.Models.Zaren.AspNetUserClaim item);

        public async Task<ZarenBO2.Models.Zaren.AspNetUserClaim> CreateAspNetUserClaim(ZarenBO2.Models.Zaren.AspNetUserClaim aspnetuserclaim)
        {
            OnAspNetUserClaimCreated(aspnetuserclaim);

            var existingItem = Context.AspNetUserClaims
                              .Where(i => i.Id == aspnetuserclaim.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AspNetUserClaims.Add(aspnetuserclaim);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(aspnetuserclaim).State = EntityState.Detached;
                throw;
            }

            OnAfterAspNetUserClaimCreated(aspnetuserclaim);

            return aspnetuserclaim;
        }

        public async Task<ZarenBO2.Models.Zaren.AspNetUserClaim> CancelAspNetUserClaimChanges(ZarenBO2.Models.Zaren.AspNetUserClaim item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAspNetUserClaimUpdated(ZarenBO2.Models.Zaren.AspNetUserClaim item);
        partial void OnAfterAspNetUserClaimUpdated(ZarenBO2.Models.Zaren.AspNetUserClaim item);

        public async Task<ZarenBO2.Models.Zaren.AspNetUserClaim> UpdateAspNetUserClaim(int id, ZarenBO2.Models.Zaren.AspNetUserClaim aspnetuserclaim)
        {
            OnAspNetUserClaimUpdated(aspnetuserclaim);

            var itemToUpdate = Context.AspNetUserClaims
                              .Where(i => i.Id == aspnetuserclaim.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            aspnetuserclaim.AspNetUser = null;

            Context.Attach(aspnetuserclaim).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAspNetUserClaimUpdated(aspnetuserclaim);

            return aspnetuserclaim;
        }

        partial void OnAspNetUserClaimDeleted(ZarenBO2.Models.Zaren.AspNetUserClaim item);
        partial void OnAfterAspNetUserClaimDeleted(ZarenBO2.Models.Zaren.AspNetUserClaim item);

        public async Task<ZarenBO2.Models.Zaren.AspNetUserClaim> DeleteAspNetUserClaim(int id)
        {
            var itemToDelete = Context.AspNetUserClaims
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAspNetUserClaimDeleted(itemToDelete);

            Reset();

            Context.AspNetUserClaims.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAspNetUserClaimDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAspNetUserLoginsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/aspnetuserlogins/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/aspnetuserlogins/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAspNetUserLoginsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/aspnetuserlogins/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/aspnetuserlogins/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAspNetUserLoginsRead(ref IQueryable<ZarenBO2.Models.Zaren.AspNetUserLogin> items);

        public async Task<IQueryable<ZarenBO2.Models.Zaren.AspNetUserLogin>> GetAspNetUserLogins(Query query = null)
        {
            var items = Context.AspNetUserLogins.AsQueryable();

            items = items.Include(i => i.AspNetUser);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnAspNetUserLoginsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAspNetUserLoginGet(ZarenBO2.Models.Zaren.AspNetUserLogin item);

        public async Task<ZarenBO2.Models.Zaren.AspNetUserLogin> GetAspNetUserLoginByLoginProviderAndProviderKey(string loginprovider, string providerkey)
        {
            var items = Context.AspNetUserLogins
                              .AsNoTracking()
                              .Where(i => i.LoginProvider == loginprovider && i.ProviderKey == providerkey);

            items = items.Include(i => i.AspNetUser);
  
            var itemToReturn = items.FirstOrDefault();

            OnAspNetUserLoginGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAspNetUserLoginCreated(ZarenBO2.Models.Zaren.AspNetUserLogin item);
        partial void OnAfterAspNetUserLoginCreated(ZarenBO2.Models.Zaren.AspNetUserLogin item);

        public async Task<ZarenBO2.Models.Zaren.AspNetUserLogin> CreateAspNetUserLogin(ZarenBO2.Models.Zaren.AspNetUserLogin aspnetuserlogin)
        {
            OnAspNetUserLoginCreated(aspnetuserlogin);

            var existingItem = Context.AspNetUserLogins
                              .Where(i => i.LoginProvider == aspnetuserlogin.LoginProvider && i.ProviderKey == aspnetuserlogin.ProviderKey)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AspNetUserLogins.Add(aspnetuserlogin);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(aspnetuserlogin).State = EntityState.Detached;
                throw;
            }

            OnAfterAspNetUserLoginCreated(aspnetuserlogin);

            return aspnetuserlogin;
        }

        public async Task<ZarenBO2.Models.Zaren.AspNetUserLogin> CancelAspNetUserLoginChanges(ZarenBO2.Models.Zaren.AspNetUserLogin item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAspNetUserLoginUpdated(ZarenBO2.Models.Zaren.AspNetUserLogin item);
        partial void OnAfterAspNetUserLoginUpdated(ZarenBO2.Models.Zaren.AspNetUserLogin item);

        public async Task<ZarenBO2.Models.Zaren.AspNetUserLogin> UpdateAspNetUserLogin(string loginprovider, string providerkey, ZarenBO2.Models.Zaren.AspNetUserLogin aspnetuserlogin)
        {
            OnAspNetUserLoginUpdated(aspnetuserlogin);

            var itemToUpdate = Context.AspNetUserLogins
                              .Where(i => i.LoginProvider == aspnetuserlogin.LoginProvider && i.ProviderKey == aspnetuserlogin.ProviderKey)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            aspnetuserlogin.AspNetUser = null;

            Context.Attach(aspnetuserlogin).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAspNetUserLoginUpdated(aspnetuserlogin);

            return aspnetuserlogin;
        }

        partial void OnAspNetUserLoginDeleted(ZarenBO2.Models.Zaren.AspNetUserLogin item);
        partial void OnAfterAspNetUserLoginDeleted(ZarenBO2.Models.Zaren.AspNetUserLogin item);

        public async Task<ZarenBO2.Models.Zaren.AspNetUserLogin> DeleteAspNetUserLogin(string loginprovider, string providerkey)
        {
            var itemToDelete = Context.AspNetUserLogins
                              .Where(i => i.LoginProvider == loginprovider && i.ProviderKey == providerkey)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAspNetUserLoginDeleted(itemToDelete);

            Reset();

            Context.AspNetUserLogins.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAspNetUserLoginDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAspNetUserRolesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/aspnetuserroles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/aspnetuserroles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAspNetUserRolesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/aspnetuserroles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/aspnetuserroles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAspNetUserRolesRead(ref IQueryable<ZarenBO2.Models.Zaren.AspNetUserRole> items);

        public async Task<IQueryable<ZarenBO2.Models.Zaren.AspNetUserRole>> GetAspNetUserRoles(Query query = null)
        {
            var items = Context.AspNetUserRoles.AsQueryable();

            items = items.Include(i => i.AspNetRole);
            items = items.Include(i => i.AspNetUser);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnAspNetUserRolesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAspNetUserRoleGet(ZarenBO2.Models.Zaren.AspNetUserRole item);

        public async Task<ZarenBO2.Models.Zaren.AspNetUserRole> GetAspNetUserRoleByUserIdAndRoleId(string userid, string roleid)
        {
            var items = Context.AspNetUserRoles
                              .AsNoTracking()
                              .Where(i => i.UserId == userid && i.RoleId == roleid);

            items = items.Include(i => i.AspNetRole);
            items = items.Include(i => i.AspNetUser);
  
            var itemToReturn = items.FirstOrDefault();

            OnAspNetUserRoleGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAspNetUserRoleCreated(ZarenBO2.Models.Zaren.AspNetUserRole item);
        partial void OnAfterAspNetUserRoleCreated(ZarenBO2.Models.Zaren.AspNetUserRole item);

        public async Task<ZarenBO2.Models.Zaren.AspNetUserRole> CreateAspNetUserRole(ZarenBO2.Models.Zaren.AspNetUserRole aspnetuserrole)
        {
            OnAspNetUserRoleCreated(aspnetuserrole);

            var existingItem = Context.AspNetUserRoles
                              .Where(i => i.UserId == aspnetuserrole.UserId && i.RoleId == aspnetuserrole.RoleId)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AspNetUserRoles.Add(aspnetuserrole);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(aspnetuserrole).State = EntityState.Detached;
                throw;
            }

            OnAfterAspNetUserRoleCreated(aspnetuserrole);

            return aspnetuserrole;
        }

        public async Task<ZarenBO2.Models.Zaren.AspNetUserRole> CancelAspNetUserRoleChanges(ZarenBO2.Models.Zaren.AspNetUserRole item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAspNetUserRoleUpdated(ZarenBO2.Models.Zaren.AspNetUserRole item);
        partial void OnAfterAspNetUserRoleUpdated(ZarenBO2.Models.Zaren.AspNetUserRole item);

        public async Task<ZarenBO2.Models.Zaren.AspNetUserRole> UpdateAspNetUserRole(string userid, string roleid, ZarenBO2.Models.Zaren.AspNetUserRole aspnetuserrole)
        {
            OnAspNetUserRoleUpdated(aspnetuserrole);

            var itemToUpdate = Context.AspNetUserRoles
                              .Where(i => i.UserId == aspnetuserrole.UserId && i.RoleId == aspnetuserrole.RoleId)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            aspnetuserrole.AspNetRole = null;
            aspnetuserrole.AspNetUser = null;

            Context.Attach(aspnetuserrole).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAspNetUserRoleUpdated(aspnetuserrole);

            return aspnetuserrole;
        }

        partial void OnAspNetUserRoleDeleted(ZarenBO2.Models.Zaren.AspNetUserRole item);
        partial void OnAfterAspNetUserRoleDeleted(ZarenBO2.Models.Zaren.AspNetUserRole item);

        public async Task<ZarenBO2.Models.Zaren.AspNetUserRole> DeleteAspNetUserRole(string userid, string roleid)
        {
            var itemToDelete = Context.AspNetUserRoles
                              .Where(i => i.UserId == userid && i.RoleId == roleid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAspNetUserRoleDeleted(itemToDelete);

            Reset();

            Context.AspNetUserRoles.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAspNetUserRoleDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAspNetUsersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/aspnetusers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/aspnetusers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAspNetUsersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/aspnetusers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/aspnetusers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAspNetUsersRead(ref IQueryable<ZarenBO2.Models.Zaren.AspNetUser> items);

        public async Task<IQueryable<ZarenBO2.Models.Zaren.AspNetUser>> GetAspNetUsers(Query query = null)
        {
            var items = Context.AspNetUsers.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnAspNetUsersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAspNetUserGet(ZarenBO2.Models.Zaren.AspNetUser item);

        public async Task<ZarenBO2.Models.Zaren.AspNetUser> GetAspNetUserById(string id)
        {
            var items = Context.AspNetUsers
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAspNetUserGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAspNetUserCreated(ZarenBO2.Models.Zaren.AspNetUser item);
        partial void OnAfterAspNetUserCreated(ZarenBO2.Models.Zaren.AspNetUser item);

        public async Task<ZarenBO2.Models.Zaren.AspNetUser> CreateAspNetUser(ZarenBO2.Models.Zaren.AspNetUser aspnetuser)
        {
            OnAspNetUserCreated(aspnetuser);

            var existingItem = Context.AspNetUsers
                              .Where(i => i.Id == aspnetuser.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AspNetUsers.Add(aspnetuser);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(aspnetuser).State = EntityState.Detached;
                throw;
            }

            OnAfterAspNetUserCreated(aspnetuser);

            return aspnetuser;
        }

        public async Task<ZarenBO2.Models.Zaren.AspNetUser> CancelAspNetUserChanges(ZarenBO2.Models.Zaren.AspNetUser item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAspNetUserUpdated(ZarenBO2.Models.Zaren.AspNetUser item);
        partial void OnAfterAspNetUserUpdated(ZarenBO2.Models.Zaren.AspNetUser item);

        public async Task<ZarenBO2.Models.Zaren.AspNetUser> UpdateAspNetUser(string id, ZarenBO2.Models.Zaren.AspNetUser aspnetuser)
        {
            OnAspNetUserUpdated(aspnetuser);

            var itemToUpdate = Context.AspNetUsers
                              .Where(i => i.Id == aspnetuser.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(aspnetuser).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAspNetUserUpdated(aspnetuser);

            return aspnetuser;
        }

        partial void OnAspNetUserDeleted(ZarenBO2.Models.Zaren.AspNetUser item);
        partial void OnAfterAspNetUserDeleted(ZarenBO2.Models.Zaren.AspNetUser item);

        public async Task<ZarenBO2.Models.Zaren.AspNetUser> DeleteAspNetUser(string id)
        {
            var itemToDelete = Context.AspNetUsers
                              .Where(i => i.Id == id)
                              .Include(i => i.BookingReservations)
                              .Include(i => i.AspNetUserClaims)
                              .Include(i => i.AspNetUserLogins)
                              .Include(i => i.AspNetUserRoles)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAspNetUserDeleted(itemToDelete);

            Reset();

            Context.AspNetUsers.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAspNetUserDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAspNetUserTokensToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/aspnetusertokens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/aspnetusertokens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAspNetUserTokensToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren/aspnetusertokens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren/aspnetusertokens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAspNetUserTokensRead(ref IQueryable<ZarenBO2.Models.Zaren.AspNetUserToken> items);

        public async Task<IQueryable<ZarenBO2.Models.Zaren.AspNetUserToken>> GetAspNetUserTokens(Query query = null)
        {
            var items = Context.AspNetUserTokens.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnAspNetUserTokensRead(ref items);

            return await Task.FromResult(items);
        }
      public async Task<int> InsertToTestTables(string Name)
      {
          OnInsertToTestTablesDefaultParams(ref Name);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@Name", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = Name},

          };

          foreach(var _p in @params)
          {
              if(_p.Direction == ParameterDirection.Input && _p.Value == null)
              {
                  _p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[zaren].[InsertToTestTable] @Name", @params);

          int result = Convert.ToInt32(@params[0].Value);


          OnInsertToTestTablesInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnInsertToTestTablesDefaultParams(ref string Name);
      partial void OnInsertToTestTablesInvoke(ref int result);
    }
}