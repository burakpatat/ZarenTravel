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

using ZarenTravelBO.Data;

namespace ZarenTravelBO
{
    public partial class ZarenTravelService
    {
        ZarenTravelContext Context
        {
           get
           {
             return this.context;
           }
        }

        private readonly ZarenTravelContext context;
        private readonly NavigationManager navigationManager;

        public ZarenTravelService(ZarenTravelContext context, NavigationManager navigationManager)
        {
            this.context = context;
            this.navigationManager = navigationManager;
        }

        public void Reset() => Context.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);


        public async Task ExportAgenciesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/agencies/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/agencies/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgenciesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/agencies/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/agencies/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgenciesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.Agency> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.Agency>> GetAgencies(Query query = null)
        {
            var items = Context.Agencies.AsQueryable();

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

            OnAgenciesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyGet(ZarenTravelBO.Models.ZarenTravel.Agency item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Agency> GetAgencyById(int id)
        {
            var items = Context.Agencies
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Contact);
                items = items.Include(i => i.Contact1);
                items = items.Include(i => i.AgencyGroup);
                items = items.Include(i => i.Contact2);
  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyCreated(ZarenTravelBO.Models.ZarenTravel.Agency item);
        partial void OnAfterAgencyCreated(ZarenTravelBO.Models.ZarenTravel.Agency item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Agency> CreateAgency(ZarenTravelBO.Models.ZarenTravel.Agency agency)
        {
            OnAgencyCreated(agency);

            var existingItem = Context.Agencies
                              .Where(i => i.Id == agency.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Agencies.Add(agency);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agency).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyCreated(agency);

            return agency;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.Agency> CancelAgencyChanges(ZarenTravelBO.Models.ZarenTravel.Agency item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyUpdated(ZarenTravelBO.Models.ZarenTravel.Agency item);
        partial void OnAfterAgencyUpdated(ZarenTravelBO.Models.ZarenTravel.Agency item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Agency> UpdateAgency(int id, ZarenTravelBO.Models.ZarenTravel.Agency agency)
        {
            OnAgencyUpdated(agency);

            var itemToUpdate = Context.Agencies
                              .Where(i => i.Id == agency.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(agency);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyUpdated(agency);

            return agency;
        }

        partial void OnAgencyDeleted(ZarenTravelBO.Models.ZarenTravel.Agency item);
        partial void OnAfterAgencyDeleted(ZarenTravelBO.Models.ZarenTravel.Agency item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Agency> DeleteAgency(int id)
        {
            var itemToDelete = Context.Agencies
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyDeleted(itemToDelete);


            Context.Agencies.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyGroupsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/agencygroups/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/agencygroups/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyGroupsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/agencygroups/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/agencygroups/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyGroupsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.AgencyGroup> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.AgencyGroup>> GetAgencyGroups(Query query = null)
        {
            var items = Context.AgencyGroups.AsQueryable();

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

            OnAgencyGroupsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyGroupGet(ZarenTravelBO.Models.ZarenTravel.AgencyGroup item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.AgencyGroup> GetAgencyGroupById(int id)
        {
            var items = Context.AgencyGroups
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyGroupGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyGroupCreated(ZarenTravelBO.Models.ZarenTravel.AgencyGroup item);
        partial void OnAfterAgencyGroupCreated(ZarenTravelBO.Models.ZarenTravel.AgencyGroup item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.AgencyGroup> CreateAgencyGroup(ZarenTravelBO.Models.ZarenTravel.AgencyGroup agencygroup)
        {
            OnAgencyGroupCreated(agencygroup);

            var existingItem = Context.AgencyGroups
                              .Where(i => i.Id == agencygroup.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyGroups.Add(agencygroup);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencygroup).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyGroupCreated(agencygroup);

            return agencygroup;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.AgencyGroup> CancelAgencyGroupChanges(ZarenTravelBO.Models.ZarenTravel.AgencyGroup item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyGroupUpdated(ZarenTravelBO.Models.ZarenTravel.AgencyGroup item);
        partial void OnAfterAgencyGroupUpdated(ZarenTravelBO.Models.ZarenTravel.AgencyGroup item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.AgencyGroup> UpdateAgencyGroup(int id, ZarenTravelBO.Models.ZarenTravel.AgencyGroup agencygroup)
        {
            OnAgencyGroupUpdated(agencygroup);

            var itemToUpdate = Context.AgencyGroups
                              .Where(i => i.Id == agencygroup.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(agencygroup);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyGroupUpdated(agencygroup);

            return agencygroup;
        }

        partial void OnAgencyGroupDeleted(ZarenTravelBO.Models.ZarenTravel.AgencyGroup item);
        partial void OnAfterAgencyGroupDeleted(ZarenTravelBO.Models.ZarenTravel.AgencyGroup item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.AgencyGroup> DeleteAgencyGroup(int id)
        {
            var itemToDelete = Context.AgencyGroups
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyGroupDeleted(itemToDelete);


            Context.AgencyGroups.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyGroupDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgentInformationsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/agentinformations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/agentinformations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgentInformationsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/agentinformations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/agentinformations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgentInformationsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.AgentInformation> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.AgentInformation>> GetAgentInformations(Query query = null)
        {
            var items = Context.AgentInformations.AsQueryable();

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

            OnAgentInformationsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgentInformationGet(ZarenTravelBO.Models.ZarenTravel.AgentInformation item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.AgentInformation> GetAgentInformationByIdAndAgentCode(int id, string agentcode)
        {
            var items = Context.AgentInformations
                              .AsNoTracking()
                              .Where(i => i.Id == id && i.AgentCode == agentcode);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgentInformationGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgentInformationCreated(ZarenTravelBO.Models.ZarenTravel.AgentInformation item);
        partial void OnAfterAgentInformationCreated(ZarenTravelBO.Models.ZarenTravel.AgentInformation item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.AgentInformation> CreateAgentInformation(ZarenTravelBO.Models.ZarenTravel.AgentInformation agentinformation)
        {
            OnAgentInformationCreated(agentinformation);

            var existingItem = Context.AgentInformations
                              .Where(i => i.Id == agentinformation.Id && i.AgentCode == agentinformation.AgentCode)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgentInformations.Add(agentinformation);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agentinformation).State = EntityState.Detached;
                throw;
            }

            OnAfterAgentInformationCreated(agentinformation);

            return agentinformation;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.AgentInformation> CancelAgentInformationChanges(ZarenTravelBO.Models.ZarenTravel.AgentInformation item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgentInformationUpdated(ZarenTravelBO.Models.ZarenTravel.AgentInformation item);
        partial void OnAfterAgentInformationUpdated(ZarenTravelBO.Models.ZarenTravel.AgentInformation item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.AgentInformation> UpdateAgentInformation(int id, string agentcode, ZarenTravelBO.Models.ZarenTravel.AgentInformation agentinformation)
        {
            OnAgentInformationUpdated(agentinformation);

            var itemToUpdate = Context.AgentInformations
                              .Where(i => i.Id == agentinformation.Id && i.AgentCode == agentinformation.AgentCode)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(agentinformation);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgentInformationUpdated(agentinformation);

            return agentinformation;
        }

        partial void OnAgentInformationDeleted(ZarenTravelBO.Models.ZarenTravel.AgentInformation item);
        partial void OnAfterAgentInformationDeleted(ZarenTravelBO.Models.ZarenTravel.AgentInformation item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.AgentInformation> DeleteAgentInformation(int id, string agentcode)
        {
            var itemToDelete = Context.AgentInformations
                              .Where(i => i.Id == id && i.AgentCode == agentcode)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgentInformationDeleted(itemToDelete);


            Context.AgentInformations.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgentInformationDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAirExtrasToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/airextras/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/airextras/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAirExtrasToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/airextras/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/airextras/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAirExtrasRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.AirExtra> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.AirExtra>> GetAirExtras(Query query = null)
        {
            var items = Context.AirExtras.AsQueryable();

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

            OnAirExtrasRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAirExtraGet(ZarenTravelBO.Models.ZarenTravel.AirExtra item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.AirExtra> GetAirExtraById(int id)
        {
            var items = Context.AirExtras
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Air);
                items = items.Include(i => i.ExtrasType);
  
            var itemToReturn = items.FirstOrDefault();

            OnAirExtraGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAirExtraCreated(ZarenTravelBO.Models.ZarenTravel.AirExtra item);
        partial void OnAfterAirExtraCreated(ZarenTravelBO.Models.ZarenTravel.AirExtra item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.AirExtra> CreateAirExtra(ZarenTravelBO.Models.ZarenTravel.AirExtra airextra)
        {
            OnAirExtraCreated(airextra);

            var existingItem = Context.AirExtras
                              .Where(i => i.Id == airextra.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AirExtras.Add(airextra);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(airextra).State = EntityState.Detached;
                throw;
            }

            OnAfterAirExtraCreated(airextra);

            return airextra;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.AirExtra> CancelAirExtraChanges(ZarenTravelBO.Models.ZarenTravel.AirExtra item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAirExtraUpdated(ZarenTravelBO.Models.ZarenTravel.AirExtra item);
        partial void OnAfterAirExtraUpdated(ZarenTravelBO.Models.ZarenTravel.AirExtra item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.AirExtra> UpdateAirExtra(int id, ZarenTravelBO.Models.ZarenTravel.AirExtra airextra)
        {
            OnAirExtraUpdated(airextra);

            var itemToUpdate = Context.AirExtras
                              .Where(i => i.Id == airextra.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(airextra);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAirExtraUpdated(airextra);

            return airextra;
        }

        partial void OnAirExtraDeleted(ZarenTravelBO.Models.ZarenTravel.AirExtra item);
        partial void OnAfterAirExtraDeleted(ZarenTravelBO.Models.ZarenTravel.AirExtra item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.AirExtra> DeleteAirExtra(int id)
        {
            var itemToDelete = Context.AirExtras
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAirExtraDeleted(itemToDelete);


            Context.AirExtras.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAirExtraDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAirlinesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/airlines/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/airlines/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAirlinesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/airlines/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/airlines/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAirlinesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.Airline> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.Airline>> GetAirlines(Query query = null)
        {
            var items = Context.Airlines.AsQueryable();

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

            OnAirlinesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAirlineGet(ZarenTravelBO.Models.ZarenTravel.Airline item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Airline> GetAirlineById(int id)
        {
            var items = Context.Airlines
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAirlineGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAirlineCreated(ZarenTravelBO.Models.ZarenTravel.Airline item);
        partial void OnAfterAirlineCreated(ZarenTravelBO.Models.ZarenTravel.Airline item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Airline> CreateAirline(ZarenTravelBO.Models.ZarenTravel.Airline airline)
        {
            OnAirlineCreated(airline);

            var existingItem = Context.Airlines
                              .Where(i => i.Id == airline.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Airlines.Add(airline);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(airline).State = EntityState.Detached;
                throw;
            }

            OnAfterAirlineCreated(airline);

            return airline;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.Airline> CancelAirlineChanges(ZarenTravelBO.Models.ZarenTravel.Airline item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAirlineUpdated(ZarenTravelBO.Models.ZarenTravel.Airline item);
        partial void OnAfterAirlineUpdated(ZarenTravelBO.Models.ZarenTravel.Airline item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Airline> UpdateAirline(int id, ZarenTravelBO.Models.ZarenTravel.Airline airline)
        {
            OnAirlineUpdated(airline);

            var itemToUpdate = Context.Airlines
                              .Where(i => i.Id == airline.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(airline);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAirlineUpdated(airline);

            return airline;
        }

        partial void OnAirlineDeleted(ZarenTravelBO.Models.ZarenTravel.Airline item);
        partial void OnAfterAirlineDeleted(ZarenTravelBO.Models.ZarenTravel.Airline item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Airline> DeleteAirline(int id)
        {
            var itemToDelete = Context.Airlines
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAirlineDeleted(itemToDelete);


            Context.Airlines.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAirlineDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAirportsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/airports/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/airports/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAirportsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/airports/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/airports/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAirportsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.Airport> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.Airport>> GetAirports(Query query = null)
        {
            var items = Context.Airports.AsQueryable();

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

            OnAirportsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAirportGet(ZarenTravelBO.Models.ZarenTravel.Airport item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Airport> GetAirportById(int id)
        {
            var items = Context.Airports
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Country);
  
            var itemToReturn = items.FirstOrDefault();

            OnAirportGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAirportCreated(ZarenTravelBO.Models.ZarenTravel.Airport item);
        partial void OnAfterAirportCreated(ZarenTravelBO.Models.ZarenTravel.Airport item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Airport> CreateAirport(ZarenTravelBO.Models.ZarenTravel.Airport airport)
        {
            OnAirportCreated(airport);

            var existingItem = Context.Airports
                              .Where(i => i.Id == airport.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Airports.Add(airport);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(airport).State = EntityState.Detached;
                throw;
            }

            OnAfterAirportCreated(airport);

            return airport;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.Airport> CancelAirportChanges(ZarenTravelBO.Models.ZarenTravel.Airport item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAirportUpdated(ZarenTravelBO.Models.ZarenTravel.Airport item);
        partial void OnAfterAirportUpdated(ZarenTravelBO.Models.ZarenTravel.Airport item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Airport> UpdateAirport(int id, ZarenTravelBO.Models.ZarenTravel.Airport airport)
        {
            OnAirportUpdated(airport);

            var itemToUpdate = Context.Airports
                              .Where(i => i.Id == airport.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(airport);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAirportUpdated(airport);

            return airport;
        }

        partial void OnAirportDeleted(ZarenTravelBO.Models.ZarenTravel.Airport item);
        partial void OnAfterAirportDeleted(ZarenTravelBO.Models.ZarenTravel.Airport item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Airport> DeleteAirport(int id)
        {
            var itemToDelete = Context.Airports
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAirportDeleted(itemToDelete);


            Context.Airports.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAirportDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAirsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/airs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/airs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAirsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/airs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/airs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAirsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.Air> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.Air>> GetAirs(Query query = null)
        {
            var items = Context.Airs.AsQueryable();

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

            OnAirsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAirGet(ZarenTravelBO.Models.ZarenTravel.Air item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Air> GetAirById(int id)
        {
            var items = Context.Airs
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Airline);
                items = items.Include(i => i.Broker);
                items = items.Include(i => i.Currency);
  
            var itemToReturn = items.FirstOrDefault();

            OnAirGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAirCreated(ZarenTravelBO.Models.ZarenTravel.Air item);
        partial void OnAfterAirCreated(ZarenTravelBO.Models.ZarenTravel.Air item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Air> CreateAir(ZarenTravelBO.Models.ZarenTravel.Air air)
        {
            OnAirCreated(air);

            var existingItem = Context.Airs
                              .Where(i => i.Id == air.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Airs.Add(air);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(air).State = EntityState.Detached;
                throw;
            }

            OnAfterAirCreated(air);

            return air;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.Air> CancelAirChanges(ZarenTravelBO.Models.ZarenTravel.Air item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAirUpdated(ZarenTravelBO.Models.ZarenTravel.Air item);
        partial void OnAfterAirUpdated(ZarenTravelBO.Models.ZarenTravel.Air item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Air> UpdateAir(int id, ZarenTravelBO.Models.ZarenTravel.Air air)
        {
            OnAirUpdated(air);

            var itemToUpdate = Context.Airs
                              .Where(i => i.Id == air.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(air);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAirUpdated(air);

            return air;
        }

        partial void OnAirDeleted(ZarenTravelBO.Models.ZarenTravel.Air item);
        partial void OnAfterAirDeleted(ZarenTravelBO.Models.ZarenTravel.Air item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Air> DeleteAir(int id)
        {
            var itemToDelete = Context.Airs
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAirDeleted(itemToDelete);


            Context.Airs.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAirDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAirSegmentsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/airsegments/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/airsegments/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAirSegmentsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/airsegments/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/airsegments/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAirSegmentsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.AirSegment> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.AirSegment>> GetAirSegments(Query query = null)
        {
            var items = Context.AirSegments.AsQueryable();

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

            OnAirSegmentsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAirSegmentGet(ZarenTravelBO.Models.ZarenTravel.AirSegment item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.AirSegment> GetAirSegmentById(int id)
        {
            var items = Context.AirSegments
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Air);
                items = items.Include(i => i.Airline);
                items = items.Include(i => i.Airport);
                items = items.Include(i => i.Airport1);
                items = items.Include(i => i.Terminal);
                items = items.Include(i => i.Terminal1);
  
            var itemToReturn = items.FirstOrDefault();

            OnAirSegmentGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAirSegmentCreated(ZarenTravelBO.Models.ZarenTravel.AirSegment item);
        partial void OnAfterAirSegmentCreated(ZarenTravelBO.Models.ZarenTravel.AirSegment item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.AirSegment> CreateAirSegment(ZarenTravelBO.Models.ZarenTravel.AirSegment airsegment)
        {
            OnAirSegmentCreated(airsegment);

            var existingItem = Context.AirSegments
                              .Where(i => i.Id == airsegment.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AirSegments.Add(airsegment);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(airsegment).State = EntityState.Detached;
                throw;
            }

            OnAfterAirSegmentCreated(airsegment);

            return airsegment;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.AirSegment> CancelAirSegmentChanges(ZarenTravelBO.Models.ZarenTravel.AirSegment item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAirSegmentUpdated(ZarenTravelBO.Models.ZarenTravel.AirSegment item);
        partial void OnAfterAirSegmentUpdated(ZarenTravelBO.Models.ZarenTravel.AirSegment item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.AirSegment> UpdateAirSegment(int id, ZarenTravelBO.Models.ZarenTravel.AirSegment airsegment)
        {
            OnAirSegmentUpdated(airsegment);

            var itemToUpdate = Context.AirSegments
                              .Where(i => i.Id == airsegment.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(airsegment);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAirSegmentUpdated(airsegment);

            return airsegment;
        }

        partial void OnAirSegmentDeleted(ZarenTravelBO.Models.ZarenTravel.AirSegment item);
        partial void OnAfterAirSegmentDeleted(ZarenTravelBO.Models.ZarenTravel.AirSegment item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.AirSegment> DeleteAirSegment(int id)
        {
            var itemToDelete = Context.AirSegments
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAirSegmentDeleted(itemToDelete);


            Context.AirSegments.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAirSegmentDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportApisToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/apis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/apis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportApisToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/apis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/apis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnApisRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.Api> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.Api>> GetApis(Query query = null)
        {
            var items = Context.Apis.AsQueryable();

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

            OnApisRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnApiGet(ZarenTravelBO.Models.ZarenTravel.Api item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Api> GetApiById(int id)
        {
            var items = Context.Apis
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnApiGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnApiCreated(ZarenTravelBO.Models.ZarenTravel.Api item);
        partial void OnAfterApiCreated(ZarenTravelBO.Models.ZarenTravel.Api item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Api> CreateApi(ZarenTravelBO.Models.ZarenTravel.Api api)
        {
            OnApiCreated(api);

            var existingItem = Context.Apis
                              .Where(i => i.Id == api.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Apis.Add(api);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(api).State = EntityState.Detached;
                throw;
            }

            OnAfterApiCreated(api);

            return api;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.Api> CancelApiChanges(ZarenTravelBO.Models.ZarenTravel.Api item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnApiUpdated(ZarenTravelBO.Models.ZarenTravel.Api item);
        partial void OnAfterApiUpdated(ZarenTravelBO.Models.ZarenTravel.Api item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Api> UpdateApi(int id, ZarenTravelBO.Models.ZarenTravel.Api api)
        {
            OnApiUpdated(api);

            var itemToUpdate = Context.Apis
                              .Where(i => i.Id == api.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(api);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterApiUpdated(api);

            return api;
        }

        partial void OnApiDeleted(ZarenTravelBO.Models.ZarenTravel.Api item);
        partial void OnAfterApiDeleted(ZarenTravelBO.Models.ZarenTravel.Api item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Api> DeleteApi(int id)
        {
            var itemToDelete = Context.Apis
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnApiDeleted(itemToDelete);


            Context.Apis.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterApiDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAuthorizationTemplatesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/authorizationtemplates/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/authorizationtemplates/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAuthorizationTemplatesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/authorizationtemplates/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/authorizationtemplates/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAuthorizationTemplatesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.AuthorizationTemplate> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.AuthorizationTemplate>> GetAuthorizationTemplates(Query query = null)
        {
            var items = Context.AuthorizationTemplates.AsQueryable();

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

            OnAuthorizationTemplatesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAuthorizationTemplateGet(ZarenTravelBO.Models.ZarenTravel.AuthorizationTemplate item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.AuthorizationTemplate> GetAuthorizationTemplateById(int id)
        {
            var items = Context.AuthorizationTemplates
                              .AsNoTracking()
                              .Where(i => i.ID == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAuthorizationTemplateGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAuthorizationTemplateCreated(ZarenTravelBO.Models.ZarenTravel.AuthorizationTemplate item);
        partial void OnAfterAuthorizationTemplateCreated(ZarenTravelBO.Models.ZarenTravel.AuthorizationTemplate item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.AuthorizationTemplate> CreateAuthorizationTemplate(ZarenTravelBO.Models.ZarenTravel.AuthorizationTemplate authorizationtemplate)
        {
            OnAuthorizationTemplateCreated(authorizationtemplate);

            var existingItem = Context.AuthorizationTemplates
                              .Where(i => i.ID == authorizationtemplate.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AuthorizationTemplates.Add(authorizationtemplate);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(authorizationtemplate).State = EntityState.Detached;
                throw;
            }

            OnAfterAuthorizationTemplateCreated(authorizationtemplate);

            return authorizationtemplate;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.AuthorizationTemplate> CancelAuthorizationTemplateChanges(ZarenTravelBO.Models.ZarenTravel.AuthorizationTemplate item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAuthorizationTemplateUpdated(ZarenTravelBO.Models.ZarenTravel.AuthorizationTemplate item);
        partial void OnAfterAuthorizationTemplateUpdated(ZarenTravelBO.Models.ZarenTravel.AuthorizationTemplate item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.AuthorizationTemplate> UpdateAuthorizationTemplate(int id, ZarenTravelBO.Models.ZarenTravel.AuthorizationTemplate authorizationtemplate)
        {
            OnAuthorizationTemplateUpdated(authorizationtemplate);

            var itemToUpdate = Context.AuthorizationTemplates
                              .Where(i => i.ID == authorizationtemplate.ID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(authorizationtemplate);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAuthorizationTemplateUpdated(authorizationtemplate);

            return authorizationtemplate;
        }

        partial void OnAuthorizationTemplateDeleted(ZarenTravelBO.Models.ZarenTravel.AuthorizationTemplate item);
        partial void OnAfterAuthorizationTemplateDeleted(ZarenTravelBO.Models.ZarenTravel.AuthorizationTemplate item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.AuthorizationTemplate> DeleteAuthorizationTemplate(int id)
        {
            var itemToDelete = Context.AuthorizationTemplates
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAuthorizationTemplateDeleted(itemToDelete);


            Context.AuthorizationTemplates.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAuthorizationTemplateDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAutoCompletesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/autocompletes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/autocompletes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAutoCompletesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/autocompletes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/autocompletes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAutoCompletesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.AutoComplete> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.AutoComplete>> GetAutoCompletes(Query query = null)
        {
            var items = Context.AutoCompletes.AsQueryable();

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

        partial void OnAutoCompleteGet(ZarenTravelBO.Models.ZarenTravel.AutoComplete item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.AutoComplete> GetAutoCompleteById(int id)
        {
            var items = Context.AutoCompletes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Api);
                items = items.Include(i => i.AutoCompleteType);
  
            var itemToReturn = items.FirstOrDefault();

            OnAutoCompleteGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAutoCompleteCreated(ZarenTravelBO.Models.ZarenTravel.AutoComplete item);
        partial void OnAfterAutoCompleteCreated(ZarenTravelBO.Models.ZarenTravel.AutoComplete item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.AutoComplete> CreateAutoComplete(ZarenTravelBO.Models.ZarenTravel.AutoComplete autocomplete)
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

        public async Task<ZarenTravelBO.Models.ZarenTravel.AutoComplete> CancelAutoCompleteChanges(ZarenTravelBO.Models.ZarenTravel.AutoComplete item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAutoCompleteUpdated(ZarenTravelBO.Models.ZarenTravel.AutoComplete item);
        partial void OnAfterAutoCompleteUpdated(ZarenTravelBO.Models.ZarenTravel.AutoComplete item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.AutoComplete> UpdateAutoComplete(int id, ZarenTravelBO.Models.ZarenTravel.AutoComplete autocomplete)
        {
            OnAutoCompleteUpdated(autocomplete);

            var itemToUpdate = Context.AutoCompletes
                              .Where(i => i.Id == autocomplete.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(autocomplete);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAutoCompleteUpdated(autocomplete);

            return autocomplete;
        }

        partial void OnAutoCompleteDeleted(ZarenTravelBO.Models.ZarenTravel.AutoComplete item);
        partial void OnAfterAutoCompleteDeleted(ZarenTravelBO.Models.ZarenTravel.AutoComplete item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.AutoComplete> DeleteAutoComplete(int id)
        {
            var itemToDelete = Context.AutoCompletes
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAutoCompleteDeleted(itemToDelete);


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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/autocompletetypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/autocompletetypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAutoCompleteTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/autocompletetypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/autocompletetypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAutoCompleteTypesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.AutoCompleteType> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.AutoCompleteType>> GetAutoCompleteTypes(Query query = null)
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

        partial void OnAutoCompleteTypeGet(ZarenTravelBO.Models.ZarenTravel.AutoCompleteType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.AutoCompleteType> GetAutoCompleteTypeById(int id)
        {
            var items = Context.AutoCompleteTypes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAutoCompleteTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAutoCompleteTypeCreated(ZarenTravelBO.Models.ZarenTravel.AutoCompleteType item);
        partial void OnAfterAutoCompleteTypeCreated(ZarenTravelBO.Models.ZarenTravel.AutoCompleteType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.AutoCompleteType> CreateAutoCompleteType(ZarenTravelBO.Models.ZarenTravel.AutoCompleteType autocompletetype)
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

        public async Task<ZarenTravelBO.Models.ZarenTravel.AutoCompleteType> CancelAutoCompleteTypeChanges(ZarenTravelBO.Models.ZarenTravel.AutoCompleteType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAutoCompleteTypeUpdated(ZarenTravelBO.Models.ZarenTravel.AutoCompleteType item);
        partial void OnAfterAutoCompleteTypeUpdated(ZarenTravelBO.Models.ZarenTravel.AutoCompleteType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.AutoCompleteType> UpdateAutoCompleteType(int id, ZarenTravelBO.Models.ZarenTravel.AutoCompleteType autocompletetype)
        {
            OnAutoCompleteTypeUpdated(autocompletetype);

            var itemToUpdate = Context.AutoCompleteTypes
                              .Where(i => i.Id == autocompletetype.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(autocompletetype);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAutoCompleteTypeUpdated(autocompletetype);

            return autocompletetype;
        }

        partial void OnAutoCompleteTypeDeleted(ZarenTravelBO.Models.ZarenTravel.AutoCompleteType item);
        partial void OnAfterAutoCompleteTypeDeleted(ZarenTravelBO.Models.ZarenTravel.AutoCompleteType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.AutoCompleteType> DeleteAutoCompleteType(int id)
        {
            var itemToDelete = Context.AutoCompleteTypes
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAutoCompleteTypeDeleted(itemToDelete);


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
    
        public async Task ExportBannersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/banners/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/banners/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportBannersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/banners/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/banners/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnBannersRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.Banner> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.Banner>> GetBanners(Query query = null)
        {
            var items = Context.Banners.AsQueryable();

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

            OnBannersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnBannerGet(ZarenTravelBO.Models.ZarenTravel.Banner item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Banner> GetBannerById(int id)
        {
            var items = Context.Banners
                              .AsNoTracking()
                              .Where(i => i.ID == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnBannerGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnBannerCreated(ZarenTravelBO.Models.ZarenTravel.Banner item);
        partial void OnAfterBannerCreated(ZarenTravelBO.Models.ZarenTravel.Banner item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Banner> CreateBanner(ZarenTravelBO.Models.ZarenTravel.Banner banner)
        {
            OnBannerCreated(banner);

            var existingItem = Context.Banners
                              .Where(i => i.ID == banner.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Banners.Add(banner);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(banner).State = EntityState.Detached;
                throw;
            }

            OnAfterBannerCreated(banner);

            return banner;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.Banner> CancelBannerChanges(ZarenTravelBO.Models.ZarenTravel.Banner item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnBannerUpdated(ZarenTravelBO.Models.ZarenTravel.Banner item);
        partial void OnAfterBannerUpdated(ZarenTravelBO.Models.ZarenTravel.Banner item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Banner> UpdateBanner(int id, ZarenTravelBO.Models.ZarenTravel.Banner banner)
        {
            OnBannerUpdated(banner);

            var itemToUpdate = Context.Banners
                              .Where(i => i.ID == banner.ID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(banner);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterBannerUpdated(banner);

            return banner;
        }

        partial void OnBannerDeleted(ZarenTravelBO.Models.ZarenTravel.Banner item);
        partial void OnAfterBannerDeleted(ZarenTravelBO.Models.ZarenTravel.Banner item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Banner> DeleteBanner(int id)
        {
            var itemToDelete = Context.Banners
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnBannerDeleted(itemToDelete);


            Context.Banners.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterBannerDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportBoardTypeLanguagesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/boardtypelanguages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/boardtypelanguages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportBoardTypeLanguagesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/boardtypelanguages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/boardtypelanguages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnBoardTypeLanguagesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.BoardTypeLanguage> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.BoardTypeLanguage>> GetBoardTypeLanguages(Query query = null)
        {
            var items = Context.BoardTypeLanguages.AsQueryable();

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

            OnBoardTypeLanguagesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnBoardTypeLanguageGet(ZarenTravelBO.Models.ZarenTravel.BoardTypeLanguage item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.BoardTypeLanguage> GetBoardTypeLanguageById(int id)
        {
            var items = Context.BoardTypeLanguages
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.BoardType);
                items = items.Include(i => i.Language);
  
            var itemToReturn = items.FirstOrDefault();

            OnBoardTypeLanguageGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnBoardTypeLanguageCreated(ZarenTravelBO.Models.ZarenTravel.BoardTypeLanguage item);
        partial void OnAfterBoardTypeLanguageCreated(ZarenTravelBO.Models.ZarenTravel.BoardTypeLanguage item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.BoardTypeLanguage> CreateBoardTypeLanguage(ZarenTravelBO.Models.ZarenTravel.BoardTypeLanguage boardtypelanguage)
        {
            OnBoardTypeLanguageCreated(boardtypelanguage);

            var existingItem = Context.BoardTypeLanguages
                              .Where(i => i.Id == boardtypelanguage.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.BoardTypeLanguages.Add(boardtypelanguage);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(boardtypelanguage).State = EntityState.Detached;
                throw;
            }

            OnAfterBoardTypeLanguageCreated(boardtypelanguage);

            return boardtypelanguage;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.BoardTypeLanguage> CancelBoardTypeLanguageChanges(ZarenTravelBO.Models.ZarenTravel.BoardTypeLanguage item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnBoardTypeLanguageUpdated(ZarenTravelBO.Models.ZarenTravel.BoardTypeLanguage item);
        partial void OnAfterBoardTypeLanguageUpdated(ZarenTravelBO.Models.ZarenTravel.BoardTypeLanguage item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.BoardTypeLanguage> UpdateBoardTypeLanguage(int id, ZarenTravelBO.Models.ZarenTravel.BoardTypeLanguage boardtypelanguage)
        {
            OnBoardTypeLanguageUpdated(boardtypelanguage);

            var itemToUpdate = Context.BoardTypeLanguages
                              .Where(i => i.Id == boardtypelanguage.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(boardtypelanguage);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterBoardTypeLanguageUpdated(boardtypelanguage);

            return boardtypelanguage;
        }

        partial void OnBoardTypeLanguageDeleted(ZarenTravelBO.Models.ZarenTravel.BoardTypeLanguage item);
        partial void OnAfterBoardTypeLanguageDeleted(ZarenTravelBO.Models.ZarenTravel.BoardTypeLanguage item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.BoardTypeLanguage> DeleteBoardTypeLanguage(int id)
        {
            var itemToDelete = Context.BoardTypeLanguages
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnBoardTypeLanguageDeleted(itemToDelete);


            Context.BoardTypeLanguages.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterBoardTypeLanguageDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportBoardTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/boardtypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/boardtypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportBoardTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/boardtypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/boardtypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnBoardTypesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.BoardType> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.BoardType>> GetBoardTypes(Query query = null)
        {
            var items = Context.BoardTypes.AsQueryable();

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

            OnBoardTypesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnBoardTypeGet(ZarenTravelBO.Models.ZarenTravel.BoardType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.BoardType> GetBoardTypeById(int id)
        {
            var items = Context.BoardTypes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnBoardTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnBoardTypeCreated(ZarenTravelBO.Models.ZarenTravel.BoardType item);
        partial void OnAfterBoardTypeCreated(ZarenTravelBO.Models.ZarenTravel.BoardType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.BoardType> CreateBoardType(ZarenTravelBO.Models.ZarenTravel.BoardType boardtype)
        {
            OnBoardTypeCreated(boardtype);

            var existingItem = Context.BoardTypes
                              .Where(i => i.Id == boardtype.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.BoardTypes.Add(boardtype);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(boardtype).State = EntityState.Detached;
                throw;
            }

            OnAfterBoardTypeCreated(boardtype);

            return boardtype;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.BoardType> CancelBoardTypeChanges(ZarenTravelBO.Models.ZarenTravel.BoardType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnBoardTypeUpdated(ZarenTravelBO.Models.ZarenTravel.BoardType item);
        partial void OnAfterBoardTypeUpdated(ZarenTravelBO.Models.ZarenTravel.BoardType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.BoardType> UpdateBoardType(int id, ZarenTravelBO.Models.ZarenTravel.BoardType boardtype)
        {
            OnBoardTypeUpdated(boardtype);

            var itemToUpdate = Context.BoardTypes
                              .Where(i => i.Id == boardtype.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(boardtype);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterBoardTypeUpdated(boardtype);

            return boardtype;
        }

        partial void OnBoardTypeDeleted(ZarenTravelBO.Models.ZarenTravel.BoardType item);
        partial void OnAfterBoardTypeDeleted(ZarenTravelBO.Models.ZarenTravel.BoardType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.BoardType> DeleteBoardType(int id)
        {
            var itemToDelete = Context.BoardTypes
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnBoardTypeDeleted(itemToDelete);


            Context.BoardTypes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterBoardTypeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportBookingDealsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/bookingdeals/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/bookingdeals/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportBookingDealsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/bookingdeals/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/bookingdeals/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnBookingDealsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.BookingDeal> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.BookingDeal>> GetBookingDeals(Query query = null)
        {
            var items = Context.BookingDeals.AsQueryable();

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

            OnBookingDealsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnBookingDealGet(ZarenTravelBO.Models.ZarenTravel.BookingDeal item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.BookingDeal> GetBookingDealById(int id)
        {
            var items = Context.BookingDeals
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Booking);
                items = items.Include(i => i.Deal);
  
            var itemToReturn = items.FirstOrDefault();

            OnBookingDealGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnBookingDealCreated(ZarenTravelBO.Models.ZarenTravel.BookingDeal item);
        partial void OnAfterBookingDealCreated(ZarenTravelBO.Models.ZarenTravel.BookingDeal item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.BookingDeal> CreateBookingDeal(ZarenTravelBO.Models.ZarenTravel.BookingDeal bookingdeal)
        {
            OnBookingDealCreated(bookingdeal);

            var existingItem = Context.BookingDeals
                              .Where(i => i.Id == bookingdeal.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.BookingDeals.Add(bookingdeal);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(bookingdeal).State = EntityState.Detached;
                throw;
            }

            OnAfterBookingDealCreated(bookingdeal);

            return bookingdeal;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.BookingDeal> CancelBookingDealChanges(ZarenTravelBO.Models.ZarenTravel.BookingDeal item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnBookingDealUpdated(ZarenTravelBO.Models.ZarenTravel.BookingDeal item);
        partial void OnAfterBookingDealUpdated(ZarenTravelBO.Models.ZarenTravel.BookingDeal item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.BookingDeal> UpdateBookingDeal(int id, ZarenTravelBO.Models.ZarenTravel.BookingDeal bookingdeal)
        {
            OnBookingDealUpdated(bookingdeal);

            var itemToUpdate = Context.BookingDeals
                              .Where(i => i.Id == bookingdeal.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(bookingdeal);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterBookingDealUpdated(bookingdeal);

            return bookingdeal;
        }

        partial void OnBookingDealDeleted(ZarenTravelBO.Models.ZarenTravel.BookingDeal item);
        partial void OnAfterBookingDealDeleted(ZarenTravelBO.Models.ZarenTravel.BookingDeal item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.BookingDeal> DeleteBookingDeal(int id)
        {
            var itemToDelete = Context.BookingDeals
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnBookingDealDeleted(itemToDelete);


            Context.BookingDeals.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterBookingDealDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportBookingRoomsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/bookingrooms/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/bookingrooms/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportBookingRoomsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/bookingrooms/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/bookingrooms/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnBookingRoomsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.BookingRoom> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.BookingRoom>> GetBookingRooms(Query query = null)
        {
            var items = Context.BookingRooms.AsQueryable();

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

            OnBookingRoomsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnBookingRoomGet(ZarenTravelBO.Models.ZarenTravel.BookingRoom item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.BookingRoom> GetBookingRoomById(int id)
        {
            var items = Context.BookingRooms
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.BoardType);
                items = items.Include(i => i.Booking);
                items = items.Include(i => i.HotelRoom);
  
            var itemToReturn = items.FirstOrDefault();

            OnBookingRoomGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnBookingRoomCreated(ZarenTravelBO.Models.ZarenTravel.BookingRoom item);
        partial void OnAfterBookingRoomCreated(ZarenTravelBO.Models.ZarenTravel.BookingRoom item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.BookingRoom> CreateBookingRoom(ZarenTravelBO.Models.ZarenTravel.BookingRoom bookingroom)
        {
            OnBookingRoomCreated(bookingroom);

            var existingItem = Context.BookingRooms
                              .Where(i => i.Id == bookingroom.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.BookingRooms.Add(bookingroom);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(bookingroom).State = EntityState.Detached;
                throw;
            }

            OnAfterBookingRoomCreated(bookingroom);

            return bookingroom;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.BookingRoom> CancelBookingRoomChanges(ZarenTravelBO.Models.ZarenTravel.BookingRoom item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnBookingRoomUpdated(ZarenTravelBO.Models.ZarenTravel.BookingRoom item);
        partial void OnAfterBookingRoomUpdated(ZarenTravelBO.Models.ZarenTravel.BookingRoom item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.BookingRoom> UpdateBookingRoom(int id, ZarenTravelBO.Models.ZarenTravel.BookingRoom bookingroom)
        {
            OnBookingRoomUpdated(bookingroom);

            var itemToUpdate = Context.BookingRooms
                              .Where(i => i.Id == bookingroom.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(bookingroom);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterBookingRoomUpdated(bookingroom);

            return bookingroom;
        }

        partial void OnBookingRoomDeleted(ZarenTravelBO.Models.ZarenTravel.BookingRoom item);
        partial void OnAfterBookingRoomDeleted(ZarenTravelBO.Models.ZarenTravel.BookingRoom item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.BookingRoom> DeleteBookingRoom(int id)
        {
            var itemToDelete = Context.BookingRooms
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnBookingRoomDeleted(itemToDelete);


            Context.BookingRooms.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterBookingRoomDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportBookingsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/bookings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/bookings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportBookingsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/bookings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/bookings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnBookingsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.Booking> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.Booking>> GetBookings(Query query = null)
        {
            var items = Context.Bookings.AsQueryable();

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

            OnBookingsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnBookingGet(ZarenTravelBO.Models.ZarenTravel.Booking item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Booking> GetBookingById(int id)
        {
            var items = Context.Bookings
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Agency);
                items = items.Include(i => i.Hotel);
                items = items.Include(i => i.Provider);
  
            var itemToReturn = items.FirstOrDefault();

            OnBookingGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnBookingCreated(ZarenTravelBO.Models.ZarenTravel.Booking item);
        partial void OnAfterBookingCreated(ZarenTravelBO.Models.ZarenTravel.Booking item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Booking> CreateBooking(ZarenTravelBO.Models.ZarenTravel.Booking booking)
        {
            OnBookingCreated(booking);

            var existingItem = Context.Bookings
                              .Where(i => i.Id == booking.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Bookings.Add(booking);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(booking).State = EntityState.Detached;
                throw;
            }

            OnAfterBookingCreated(booking);

            return booking;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.Booking> CancelBookingChanges(ZarenTravelBO.Models.ZarenTravel.Booking item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnBookingUpdated(ZarenTravelBO.Models.ZarenTravel.Booking item);
        partial void OnAfterBookingUpdated(ZarenTravelBO.Models.ZarenTravel.Booking item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Booking> UpdateBooking(int id, ZarenTravelBO.Models.ZarenTravel.Booking booking)
        {
            OnBookingUpdated(booking);

            var itemToUpdate = Context.Bookings
                              .Where(i => i.Id == booking.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(booking);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterBookingUpdated(booking);

            return booking;
        }

        partial void OnBookingDeleted(ZarenTravelBO.Models.ZarenTravel.Booking item);
        partial void OnAfterBookingDeleted(ZarenTravelBO.Models.ZarenTravel.Booking item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Booking> DeleteBooking(int id)
        {
            var itemToDelete = Context.Bookings
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnBookingDeleted(itemToDelete);


            Context.Bookings.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterBookingDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportBrokersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/brokers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/brokers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportBrokersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/brokers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/brokers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnBrokersRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.Broker> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.Broker>> GetBrokers(Query query = null)
        {
            var items = Context.Brokers.AsQueryable();

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

            OnBrokersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnBrokerGet(ZarenTravelBO.Models.ZarenTravel.Broker item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Broker> GetBrokerById(int id)
        {
            var items = Context.Brokers
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnBrokerGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnBrokerCreated(ZarenTravelBO.Models.ZarenTravel.Broker item);
        partial void OnAfterBrokerCreated(ZarenTravelBO.Models.ZarenTravel.Broker item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Broker> CreateBroker(ZarenTravelBO.Models.ZarenTravel.Broker broker)
        {
            OnBrokerCreated(broker);

            var existingItem = Context.Brokers
                              .Where(i => i.Id == broker.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Brokers.Add(broker);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(broker).State = EntityState.Detached;
                throw;
            }

            OnAfterBrokerCreated(broker);

            return broker;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.Broker> CancelBrokerChanges(ZarenTravelBO.Models.ZarenTravel.Broker item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnBrokerUpdated(ZarenTravelBO.Models.ZarenTravel.Broker item);
        partial void OnAfterBrokerUpdated(ZarenTravelBO.Models.ZarenTravel.Broker item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Broker> UpdateBroker(int id, ZarenTravelBO.Models.ZarenTravel.Broker broker)
        {
            OnBrokerUpdated(broker);

            var itemToUpdate = Context.Brokers
                              .Where(i => i.Id == broker.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(broker);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterBrokerUpdated(broker);

            return broker;
        }

        partial void OnBrokerDeleted(ZarenTravelBO.Models.ZarenTravel.Broker item);
        partial void OnAfterBrokerDeleted(ZarenTravelBO.Models.ZarenTravel.Broker item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Broker> DeleteBroker(int id)
        {
            var itemToDelete = Context.Brokers
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnBrokerDeleted(itemToDelete);


            Context.Brokers.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterBrokerDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportBuyRoomsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/buyrooms/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/buyrooms/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportBuyRoomsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/buyrooms/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/buyrooms/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnBuyRoomsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.BuyRoom> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.BuyRoom>> GetBuyRooms(Query query = null)
        {
            var items = Context.BuyRooms.AsQueryable();

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

            OnBuyRoomsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnBuyRoomGet(ZarenTravelBO.Models.ZarenTravel.BuyRoom item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.BuyRoom> GetBuyRoomById(int id)
        {
            var items = Context.BuyRooms
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnBuyRoomGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnBuyRoomCreated(ZarenTravelBO.Models.ZarenTravel.BuyRoom item);
        partial void OnAfterBuyRoomCreated(ZarenTravelBO.Models.ZarenTravel.BuyRoom item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.BuyRoom> CreateBuyRoom(ZarenTravelBO.Models.ZarenTravel.BuyRoom buyroom)
        {
            OnBuyRoomCreated(buyroom);

            var existingItem = Context.BuyRooms
                              .Where(i => i.Id == buyroom.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.BuyRooms.Add(buyroom);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(buyroom).State = EntityState.Detached;
                throw;
            }

            OnAfterBuyRoomCreated(buyroom);

            return buyroom;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.BuyRoom> CancelBuyRoomChanges(ZarenTravelBO.Models.ZarenTravel.BuyRoom item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnBuyRoomUpdated(ZarenTravelBO.Models.ZarenTravel.BuyRoom item);
        partial void OnAfterBuyRoomUpdated(ZarenTravelBO.Models.ZarenTravel.BuyRoom item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.BuyRoom> UpdateBuyRoom(int id, ZarenTravelBO.Models.ZarenTravel.BuyRoom buyroom)
        {
            OnBuyRoomUpdated(buyroom);

            var itemToUpdate = Context.BuyRooms
                              .Where(i => i.Id == buyroom.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(buyroom);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterBuyRoomUpdated(buyroom);

            return buyroom;
        }

        partial void OnBuyRoomDeleted(ZarenTravelBO.Models.ZarenTravel.BuyRoom item);
        partial void OnAfterBuyRoomDeleted(ZarenTravelBO.Models.ZarenTravel.BuyRoom item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.BuyRoom> DeleteBuyRoom(int id)
        {
            var itemToDelete = Context.BuyRooms
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnBuyRoomDeleted(itemToDelete);


            Context.BuyRooms.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterBuyRoomDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCancelationLanguagesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/cancelationlanguages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/cancelationlanguages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCancelationLanguagesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/cancelationlanguages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/cancelationlanguages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCancelationLanguagesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.CancelationLanguage> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.CancelationLanguage>> GetCancelationLanguages(Query query = null)
        {
            var items = Context.CancelationLanguages.AsQueryable();

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

            OnCancelationLanguagesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCancelationLanguageGet(ZarenTravelBO.Models.ZarenTravel.CancelationLanguage item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.CancelationLanguage> GetCancelationLanguageById(int id)
        {
            var items = Context.CancelationLanguages
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.CancellationRule);
                items = items.Include(i => i.Language);
  
            var itemToReturn = items.FirstOrDefault();

            OnCancelationLanguageGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCancelationLanguageCreated(ZarenTravelBO.Models.ZarenTravel.CancelationLanguage item);
        partial void OnAfterCancelationLanguageCreated(ZarenTravelBO.Models.ZarenTravel.CancelationLanguage item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.CancelationLanguage> CreateCancelationLanguage(ZarenTravelBO.Models.ZarenTravel.CancelationLanguage cancelationlanguage)
        {
            OnCancelationLanguageCreated(cancelationlanguage);

            var existingItem = Context.CancelationLanguages
                              .Where(i => i.Id == cancelationlanguage.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.CancelationLanguages.Add(cancelationlanguage);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(cancelationlanguage).State = EntityState.Detached;
                throw;
            }

            OnAfterCancelationLanguageCreated(cancelationlanguage);

            return cancelationlanguage;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.CancelationLanguage> CancelCancelationLanguageChanges(ZarenTravelBO.Models.ZarenTravel.CancelationLanguage item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCancelationLanguageUpdated(ZarenTravelBO.Models.ZarenTravel.CancelationLanguage item);
        partial void OnAfterCancelationLanguageUpdated(ZarenTravelBO.Models.ZarenTravel.CancelationLanguage item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.CancelationLanguage> UpdateCancelationLanguage(int id, ZarenTravelBO.Models.ZarenTravel.CancelationLanguage cancelationlanguage)
        {
            OnCancelationLanguageUpdated(cancelationlanguage);

            var itemToUpdate = Context.CancelationLanguages
                              .Where(i => i.Id == cancelationlanguage.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(cancelationlanguage);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCancelationLanguageUpdated(cancelationlanguage);

            return cancelationlanguage;
        }

        partial void OnCancelationLanguageDeleted(ZarenTravelBO.Models.ZarenTravel.CancelationLanguage item);
        partial void OnAfterCancelationLanguageDeleted(ZarenTravelBO.Models.ZarenTravel.CancelationLanguage item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.CancelationLanguage> DeleteCancelationLanguage(int id)
        {
            var itemToDelete = Context.CancelationLanguages
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCancelationLanguageDeleted(itemToDelete);


            Context.CancelationLanguages.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCancelationLanguageDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCancellationRulesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/cancellationrules/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/cancellationrules/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCancellationRulesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/cancellationrules/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/cancellationrules/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCancellationRulesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.CancellationRule> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.CancellationRule>> GetCancellationRules(Query query = null)
        {
            var items = Context.CancellationRules.AsQueryable();

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

            OnCancellationRulesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCancellationRuleGet(ZarenTravelBO.Models.ZarenTravel.CancellationRule item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.CancellationRule> GetCancellationRuleById(int id)
        {
            var items = Context.CancellationRules
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.CancellationSeason);
  
            var itemToReturn = items.FirstOrDefault();

            OnCancellationRuleGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCancellationRuleCreated(ZarenTravelBO.Models.ZarenTravel.CancellationRule item);
        partial void OnAfterCancellationRuleCreated(ZarenTravelBO.Models.ZarenTravel.CancellationRule item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.CancellationRule> CreateCancellationRule(ZarenTravelBO.Models.ZarenTravel.CancellationRule cancellationrule)
        {
            OnCancellationRuleCreated(cancellationrule);

            var existingItem = Context.CancellationRules
                              .Where(i => i.Id == cancellationrule.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.CancellationRules.Add(cancellationrule);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(cancellationrule).State = EntityState.Detached;
                throw;
            }

            OnAfterCancellationRuleCreated(cancellationrule);

            return cancellationrule;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.CancellationRule> CancelCancellationRuleChanges(ZarenTravelBO.Models.ZarenTravel.CancellationRule item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCancellationRuleUpdated(ZarenTravelBO.Models.ZarenTravel.CancellationRule item);
        partial void OnAfterCancellationRuleUpdated(ZarenTravelBO.Models.ZarenTravel.CancellationRule item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.CancellationRule> UpdateCancellationRule(int id, ZarenTravelBO.Models.ZarenTravel.CancellationRule cancellationrule)
        {
            OnCancellationRuleUpdated(cancellationrule);

            var itemToUpdate = Context.CancellationRules
                              .Where(i => i.Id == cancellationrule.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(cancellationrule);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCancellationRuleUpdated(cancellationrule);

            return cancellationrule;
        }

        partial void OnCancellationRuleDeleted(ZarenTravelBO.Models.ZarenTravel.CancellationRule item);
        partial void OnAfterCancellationRuleDeleted(ZarenTravelBO.Models.ZarenTravel.CancellationRule item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.CancellationRule> DeleteCancellationRule(int id)
        {
            var itemToDelete = Context.CancellationRules
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCancellationRuleDeleted(itemToDelete);


            Context.CancellationRules.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCancellationRuleDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCancellationSeasonsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/cancellationseasons/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/cancellationseasons/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCancellationSeasonsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/cancellationseasons/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/cancellationseasons/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCancellationSeasonsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.CancellationSeason> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.CancellationSeason>> GetCancellationSeasons(Query query = null)
        {
            var items = Context.CancellationSeasons.AsQueryable();

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

            OnCancellationSeasonsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCancellationSeasonGet(ZarenTravelBO.Models.ZarenTravel.CancellationSeason item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.CancellationSeason> GetCancellationSeasonById(int id)
        {
            var items = Context.CancellationSeasons
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Hotel);
  
            var itemToReturn = items.FirstOrDefault();

            OnCancellationSeasonGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCancellationSeasonCreated(ZarenTravelBO.Models.ZarenTravel.CancellationSeason item);
        partial void OnAfterCancellationSeasonCreated(ZarenTravelBO.Models.ZarenTravel.CancellationSeason item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.CancellationSeason> CreateCancellationSeason(ZarenTravelBO.Models.ZarenTravel.CancellationSeason cancellationseason)
        {
            OnCancellationSeasonCreated(cancellationseason);

            var existingItem = Context.CancellationSeasons
                              .Where(i => i.Id == cancellationseason.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.CancellationSeasons.Add(cancellationseason);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(cancellationseason).State = EntityState.Detached;
                throw;
            }

            OnAfterCancellationSeasonCreated(cancellationseason);

            return cancellationseason;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.CancellationSeason> CancelCancellationSeasonChanges(ZarenTravelBO.Models.ZarenTravel.CancellationSeason item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCancellationSeasonUpdated(ZarenTravelBO.Models.ZarenTravel.CancellationSeason item);
        partial void OnAfterCancellationSeasonUpdated(ZarenTravelBO.Models.ZarenTravel.CancellationSeason item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.CancellationSeason> UpdateCancellationSeason(int id, ZarenTravelBO.Models.ZarenTravel.CancellationSeason cancellationseason)
        {
            OnCancellationSeasonUpdated(cancellationseason);

            var itemToUpdate = Context.CancellationSeasons
                              .Where(i => i.Id == cancellationseason.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(cancellationseason);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCancellationSeasonUpdated(cancellationseason);

            return cancellationseason;
        }

        partial void OnCancellationSeasonDeleted(ZarenTravelBO.Models.ZarenTravel.CancellationSeason item);
        partial void OnAfterCancellationSeasonDeleted(ZarenTravelBO.Models.ZarenTravel.CancellationSeason item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.CancellationSeason> DeleteCancellationSeason(int id)
        {
            var itemToDelete = Context.CancellationSeasons
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCancellationSeasonDeleted(itemToDelete);


            Context.CancellationSeasons.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCancellationSeasonDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCarRentalsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/carrentals/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/carrentals/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCarRentalsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/carrentals/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/carrentals/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCarRentalsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.CarRental> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.CarRental>> GetCarRentals(Query query = null)
        {
            var items = Context.CarRentals.AsQueryable();

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

            OnCarRentalsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCarRentalGet(ZarenTravelBO.Models.ZarenTravel.CarRental item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.CarRental> GetCarRentalById(int id)
        {
            var items = Context.CarRentals
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnCarRentalGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCarRentalCreated(ZarenTravelBO.Models.ZarenTravel.CarRental item);
        partial void OnAfterCarRentalCreated(ZarenTravelBO.Models.ZarenTravel.CarRental item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.CarRental> CreateCarRental(ZarenTravelBO.Models.ZarenTravel.CarRental carrental)
        {
            OnCarRentalCreated(carrental);

            var existingItem = Context.CarRentals
                              .Where(i => i.Id == carrental.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.CarRentals.Add(carrental);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(carrental).State = EntityState.Detached;
                throw;
            }

            OnAfterCarRentalCreated(carrental);

            return carrental;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.CarRental> CancelCarRentalChanges(ZarenTravelBO.Models.ZarenTravel.CarRental item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCarRentalUpdated(ZarenTravelBO.Models.ZarenTravel.CarRental item);
        partial void OnAfterCarRentalUpdated(ZarenTravelBO.Models.ZarenTravel.CarRental item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.CarRental> UpdateCarRental(int id, ZarenTravelBO.Models.ZarenTravel.CarRental carrental)
        {
            OnCarRentalUpdated(carrental);

            var itemToUpdate = Context.CarRentals
                              .Where(i => i.Id == carrental.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(carrental);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCarRentalUpdated(carrental);

            return carrental;
        }

        partial void OnCarRentalDeleted(ZarenTravelBO.Models.ZarenTravel.CarRental item);
        partial void OnAfterCarRentalDeleted(ZarenTravelBO.Models.ZarenTravel.CarRental item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.CarRental> DeleteCarRental(int id)
        {
            var itemToDelete = Context.CarRentals
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCarRentalDeleted(itemToDelete);


            Context.CarRentals.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCarRentalDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCarRentsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/carrents/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/carrents/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCarRentsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/carrents/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/carrents/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCarRentsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.CarRent> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.CarRent>> GetCarRents(Query query = null)
        {
            var items = Context.CarRents.AsQueryable();

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

            OnCarRentsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCarRentGet(ZarenTravelBO.Models.ZarenTravel.CarRent item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.CarRent> GetCarRentById(int id)
        {
            var items = Context.CarRents
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Airport);
                items = items.Include(i => i.Airport1);
                items = items.Include(i => i.CarRental);
                items = items.Include(i => i.CarType);
                items = items.Include(i => i.Currency);
  
            var itemToReturn = items.FirstOrDefault();

            OnCarRentGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCarRentCreated(ZarenTravelBO.Models.ZarenTravel.CarRent item);
        partial void OnAfterCarRentCreated(ZarenTravelBO.Models.ZarenTravel.CarRent item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.CarRent> CreateCarRent(ZarenTravelBO.Models.ZarenTravel.CarRent carrent)
        {
            OnCarRentCreated(carrent);

            var existingItem = Context.CarRents
                              .Where(i => i.Id == carrent.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.CarRents.Add(carrent);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(carrent).State = EntityState.Detached;
                throw;
            }

            OnAfterCarRentCreated(carrent);

            return carrent;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.CarRent> CancelCarRentChanges(ZarenTravelBO.Models.ZarenTravel.CarRent item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCarRentUpdated(ZarenTravelBO.Models.ZarenTravel.CarRent item);
        partial void OnAfterCarRentUpdated(ZarenTravelBO.Models.ZarenTravel.CarRent item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.CarRent> UpdateCarRent(int id, ZarenTravelBO.Models.ZarenTravel.CarRent carrent)
        {
            OnCarRentUpdated(carrent);

            var itemToUpdate = Context.CarRents
                              .Where(i => i.Id == carrent.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(carrent);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCarRentUpdated(carrent);

            return carrent;
        }

        partial void OnCarRentDeleted(ZarenTravelBO.Models.ZarenTravel.CarRent item);
        partial void OnAfterCarRentDeleted(ZarenTravelBO.Models.ZarenTravel.CarRent item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.CarRent> DeleteCarRent(int id)
        {
            var itemToDelete = Context.CarRents
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCarRentDeleted(itemToDelete);


            Context.CarRents.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCarRentDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCarTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/cartypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/cartypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCarTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/cartypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/cartypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCarTypesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.CarType> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.CarType>> GetCarTypes(Query query = null)
        {
            var items = Context.CarTypes.AsQueryable();

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

            OnCarTypesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCarTypeGet(ZarenTravelBO.Models.ZarenTravel.CarType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.CarType> GetCarTypeById(int id)
        {
            var items = Context.CarTypes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnCarTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCarTypeCreated(ZarenTravelBO.Models.ZarenTravel.CarType item);
        partial void OnAfterCarTypeCreated(ZarenTravelBO.Models.ZarenTravel.CarType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.CarType> CreateCarType(ZarenTravelBO.Models.ZarenTravel.CarType cartype)
        {
            OnCarTypeCreated(cartype);

            var existingItem = Context.CarTypes
                              .Where(i => i.Id == cartype.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.CarTypes.Add(cartype);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(cartype).State = EntityState.Detached;
                throw;
            }

            OnAfterCarTypeCreated(cartype);

            return cartype;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.CarType> CancelCarTypeChanges(ZarenTravelBO.Models.ZarenTravel.CarType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCarTypeUpdated(ZarenTravelBO.Models.ZarenTravel.CarType item);
        partial void OnAfterCarTypeUpdated(ZarenTravelBO.Models.ZarenTravel.CarType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.CarType> UpdateCarType(int id, ZarenTravelBO.Models.ZarenTravel.CarType cartype)
        {
            OnCarTypeUpdated(cartype);

            var itemToUpdate = Context.CarTypes
                              .Where(i => i.Id == cartype.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(cartype);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCarTypeUpdated(cartype);

            return cartype;
        }

        partial void OnCarTypeDeleted(ZarenTravelBO.Models.ZarenTravel.CarType item);
        partial void OnAfterCarTypeDeleted(ZarenTravelBO.Models.ZarenTravel.CarType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.CarType> DeleteCarType(int id)
        {
            var itemToDelete = Context.CarTypes
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCarTypeDeleted(itemToDelete);


            Context.CarTypes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCarTypeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCitiesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/cities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/cities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCitiesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/cities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/cities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCitiesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.City> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.City>> GetCities(Query query = null)
        {
            var items = Context.Cities.AsQueryable();

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

            OnCitiesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCityGet(ZarenTravelBO.Models.ZarenTravel.City item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.City> GetCityById(int id)
        {
            var items = Context.Cities
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnCityGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCityCreated(ZarenTravelBO.Models.ZarenTravel.City item);
        partial void OnAfterCityCreated(ZarenTravelBO.Models.ZarenTravel.City item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.City> CreateCity(ZarenTravelBO.Models.ZarenTravel.City city)
        {
            OnCityCreated(city);

            var existingItem = Context.Cities
                              .Where(i => i.Id == city.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Cities.Add(city);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(city).State = EntityState.Detached;
                throw;
            }

            OnAfterCityCreated(city);

            return city;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.City> CancelCityChanges(ZarenTravelBO.Models.ZarenTravel.City item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCityUpdated(ZarenTravelBO.Models.ZarenTravel.City item);
        partial void OnAfterCityUpdated(ZarenTravelBO.Models.ZarenTravel.City item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.City> UpdateCity(int id, ZarenTravelBO.Models.ZarenTravel.City city)
        {
            OnCityUpdated(city);

            var itemToUpdate = Context.Cities
                              .Where(i => i.Id == city.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(city);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCityUpdated(city);

            return city;
        }

        partial void OnCityDeleted(ZarenTravelBO.Models.ZarenTravel.City item);
        partial void OnAfterCityDeleted(ZarenTravelBO.Models.ZarenTravel.City item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.City> DeleteCity(int id)
        {
            var itemToDelete = Context.Cities
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCityDeleted(itemToDelete);


            Context.Cities.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCityDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCityModelsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/citymodels/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/citymodels/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCityModelsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/citymodels/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/citymodels/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCityModelsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.CityModel> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.CityModel>> GetCityModels(Query query = null)
        {
            var items = Context.CityModels.AsQueryable();

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

            OnCityModelsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCityModelGet(ZarenTravelBO.Models.ZarenTravel.CityModel item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.CityModel> GetCityModelByCityId(int cityid)
        {
            var items = Context.CityModels
                              .AsNoTracking()
                              .Where(i => i.CityId == cityid);

  
            var itemToReturn = items.FirstOrDefault();

            OnCityModelGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCityModelCreated(ZarenTravelBO.Models.ZarenTravel.CityModel item);
        partial void OnAfterCityModelCreated(ZarenTravelBO.Models.ZarenTravel.CityModel item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.CityModel> CreateCityModel(ZarenTravelBO.Models.ZarenTravel.CityModel citymodel)
        {
            OnCityModelCreated(citymodel);

            var existingItem = Context.CityModels
                              .Where(i => i.CityId == citymodel.CityId)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.CityModels.Add(citymodel);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(citymodel).State = EntityState.Detached;
                throw;
            }

            OnAfterCityModelCreated(citymodel);

            return citymodel;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.CityModel> CancelCityModelChanges(ZarenTravelBO.Models.ZarenTravel.CityModel item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCityModelUpdated(ZarenTravelBO.Models.ZarenTravel.CityModel item);
        partial void OnAfterCityModelUpdated(ZarenTravelBO.Models.ZarenTravel.CityModel item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.CityModel> UpdateCityModel(int cityid, ZarenTravelBO.Models.ZarenTravel.CityModel citymodel)
        {
            OnCityModelUpdated(citymodel);

            var itemToUpdate = Context.CityModels
                              .Where(i => i.CityId == citymodel.CityId)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(citymodel);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCityModelUpdated(citymodel);

            return citymodel;
        }

        partial void OnCityModelDeleted(ZarenTravelBO.Models.ZarenTravel.CityModel item);
        partial void OnAfterCityModelDeleted(ZarenTravelBO.Models.ZarenTravel.CityModel item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.CityModel> DeleteCityModel(int cityid)
        {
            var itemToDelete = Context.CityModels
                              .Where(i => i.CityId == cityid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCityModelDeleted(itemToDelete);


            Context.CityModels.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCityModelDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCompaniesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/companies/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/companies/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCompaniesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/companies/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/companies/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCompaniesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.Company> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.Company>> GetCompanies(Query query = null)
        {
            var items = Context.Companies.AsQueryable();

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

            OnCompaniesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCompanyGet(ZarenTravelBO.Models.ZarenTravel.Company item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Company> GetCompanyById(int id)
        {
            var items = Context.Companies
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Agency);
                items = items.Include(i => i.Country);
                items = items.Include(i => i.Currency);
                items = items.Include(i => i.Language);
  
            var itemToReturn = items.FirstOrDefault();

            OnCompanyGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCompanyCreated(ZarenTravelBO.Models.ZarenTravel.Company item);
        partial void OnAfterCompanyCreated(ZarenTravelBO.Models.ZarenTravel.Company item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Company> CreateCompany(ZarenTravelBO.Models.ZarenTravel.Company company)
        {
            OnCompanyCreated(company);

            var existingItem = Context.Companies
                              .Where(i => i.Id == company.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Companies.Add(company);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(company).State = EntityState.Detached;
                throw;
            }

            OnAfterCompanyCreated(company);

            return company;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.Company> CancelCompanyChanges(ZarenTravelBO.Models.ZarenTravel.Company item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCompanyUpdated(ZarenTravelBO.Models.ZarenTravel.Company item);
        partial void OnAfterCompanyUpdated(ZarenTravelBO.Models.ZarenTravel.Company item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Company> UpdateCompany(int id, ZarenTravelBO.Models.ZarenTravel.Company company)
        {
            OnCompanyUpdated(company);

            var itemToUpdate = Context.Companies
                              .Where(i => i.Id == company.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(company);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCompanyUpdated(company);

            return company;
        }

        partial void OnCompanyDeleted(ZarenTravelBO.Models.ZarenTravel.Company item);
        partial void OnAfterCompanyDeleted(ZarenTravelBO.Models.ZarenTravel.Company item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Company> DeleteCompany(int id)
        {
            var itemToDelete = Context.Companies
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCompanyDeleted(itemToDelete);


            Context.Companies.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCompanyDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportContactsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/contacts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/contacts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportContactsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/contacts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/contacts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnContactsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.Contact> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.Contact>> GetContacts(Query query = null)
        {
            var items = Context.Contacts.AsQueryable();

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

            OnContactsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnContactGet(ZarenTravelBO.Models.ZarenTravel.Contact item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Contact> GetContactById(int id)
        {
            var items = Context.Contacts
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnContactGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnContactCreated(ZarenTravelBO.Models.ZarenTravel.Contact item);
        partial void OnAfterContactCreated(ZarenTravelBO.Models.ZarenTravel.Contact item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Contact> CreateContact(ZarenTravelBO.Models.ZarenTravel.Contact contact)
        {
            OnContactCreated(contact);

            var existingItem = Context.Contacts
                              .Where(i => i.Id == contact.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Contacts.Add(contact);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(contact).State = EntityState.Detached;
                throw;
            }

            OnAfterContactCreated(contact);

            return contact;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.Contact> CancelContactChanges(ZarenTravelBO.Models.ZarenTravel.Contact item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnContactUpdated(ZarenTravelBO.Models.ZarenTravel.Contact item);
        partial void OnAfterContactUpdated(ZarenTravelBO.Models.ZarenTravel.Contact item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Contact> UpdateContact(int id, ZarenTravelBO.Models.ZarenTravel.Contact contact)
        {
            OnContactUpdated(contact);

            var itemToUpdate = Context.Contacts
                              .Where(i => i.Id == contact.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(contact);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterContactUpdated(contact);

            return contact;
        }

        partial void OnContactDeleted(ZarenTravelBO.Models.ZarenTravel.Contact item);
        partial void OnAfterContactDeleted(ZarenTravelBO.Models.ZarenTravel.Contact item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Contact> DeleteContact(int id)
        {
            var itemToDelete = Context.Contacts
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnContactDeleted(itemToDelete);


            Context.Contacts.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterContactDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCountriesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/countries/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/countries/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCountriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/countries/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/countries/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCountriesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.Country> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.Country>> GetCountries(Query query = null)
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

        partial void OnCountryGet(ZarenTravelBO.Models.ZarenTravel.Country item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Country> GetCountryById(int id)
        {
            var items = Context.Countries
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnCountryGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCountryCreated(ZarenTravelBO.Models.ZarenTravel.Country item);
        partial void OnAfterCountryCreated(ZarenTravelBO.Models.ZarenTravel.Country item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Country> CreateCountry(ZarenTravelBO.Models.ZarenTravel.Country country)
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

        public async Task<ZarenTravelBO.Models.ZarenTravel.Country> CancelCountryChanges(ZarenTravelBO.Models.ZarenTravel.Country item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCountryUpdated(ZarenTravelBO.Models.ZarenTravel.Country item);
        partial void OnAfterCountryUpdated(ZarenTravelBO.Models.ZarenTravel.Country item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Country> UpdateCountry(int id, ZarenTravelBO.Models.ZarenTravel.Country country)
        {
            OnCountryUpdated(country);

            var itemToUpdate = Context.Countries
                              .Where(i => i.Id == country.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(country);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCountryUpdated(country);

            return country;
        }

        partial void OnCountryDeleted(ZarenTravelBO.Models.ZarenTravel.Country item);
        partial void OnAfterCountryDeleted(ZarenTravelBO.Models.ZarenTravel.Country item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Country> DeleteCountry(int id)
        {
            var itemToDelete = Context.Countries
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCountryDeleted(itemToDelete);


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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/currencies/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/currencies/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCurrenciesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/currencies/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/currencies/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCurrenciesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.Currency> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.Currency>> GetCurrencies(Query query = null)
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

        partial void OnCurrencyGet(ZarenTravelBO.Models.ZarenTravel.Currency item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Currency> GetCurrencyById(int id)
        {
            var items = Context.Currencies
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnCurrencyGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCurrencyCreated(ZarenTravelBO.Models.ZarenTravel.Currency item);
        partial void OnAfterCurrencyCreated(ZarenTravelBO.Models.ZarenTravel.Currency item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Currency> CreateCurrency(ZarenTravelBO.Models.ZarenTravel.Currency currency)
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

        public async Task<ZarenTravelBO.Models.ZarenTravel.Currency> CancelCurrencyChanges(ZarenTravelBO.Models.ZarenTravel.Currency item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCurrencyUpdated(ZarenTravelBO.Models.ZarenTravel.Currency item);
        partial void OnAfterCurrencyUpdated(ZarenTravelBO.Models.ZarenTravel.Currency item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Currency> UpdateCurrency(int id, ZarenTravelBO.Models.ZarenTravel.Currency currency)
        {
            OnCurrencyUpdated(currency);

            var itemToUpdate = Context.Currencies
                              .Where(i => i.Id == currency.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(currency);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCurrencyUpdated(currency);

            return currency;
        }

        partial void OnCurrencyDeleted(ZarenTravelBO.Models.ZarenTravel.Currency item);
        partial void OnAfterCurrencyDeleted(ZarenTravelBO.Models.ZarenTravel.Currency item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Currency> DeleteCurrency(int id)
        {
            var itemToDelete = Context.Currencies
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCurrencyDeleted(itemToDelete);


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
    
        public async Task ExportCustomerInformationsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/customerinformations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/customerinformations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCustomerInformationsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/customerinformations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/customerinformations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCustomerInformationsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.CustomerInformation> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.CustomerInformation>> GetCustomerInformations(Query query = null)
        {
            var items = Context.CustomerInformations.AsQueryable();

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

            OnCustomerInformationsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCustomerInformationGet(ZarenTravelBO.Models.ZarenTravel.CustomerInformation item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.CustomerInformation> GetCustomerInformationByIdAndCustomerId(int id, int customerid)
        {
            var items = Context.CustomerInformations
                              .AsNoTracking()
                              .Where(i => i.Id == id && i.CustomerId == customerid);

  
            var itemToReturn = items.FirstOrDefault();

            OnCustomerInformationGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCustomerInformationCreated(ZarenTravelBO.Models.ZarenTravel.CustomerInformation item);
        partial void OnAfterCustomerInformationCreated(ZarenTravelBO.Models.ZarenTravel.CustomerInformation item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.CustomerInformation> CreateCustomerInformation(ZarenTravelBO.Models.ZarenTravel.CustomerInformation customerinformation)
        {
            OnCustomerInformationCreated(customerinformation);

            var existingItem = Context.CustomerInformations
                              .Where(i => i.Id == customerinformation.Id && i.CustomerId == customerinformation.CustomerId)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.CustomerInformations.Add(customerinformation);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(customerinformation).State = EntityState.Detached;
                throw;
            }

            OnAfterCustomerInformationCreated(customerinformation);

            return customerinformation;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.CustomerInformation> CancelCustomerInformationChanges(ZarenTravelBO.Models.ZarenTravel.CustomerInformation item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCustomerInformationUpdated(ZarenTravelBO.Models.ZarenTravel.CustomerInformation item);
        partial void OnAfterCustomerInformationUpdated(ZarenTravelBO.Models.ZarenTravel.CustomerInformation item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.CustomerInformation> UpdateCustomerInformation(int id, int customerid, ZarenTravelBO.Models.ZarenTravel.CustomerInformation customerinformation)
        {
            OnCustomerInformationUpdated(customerinformation);

            var itemToUpdate = Context.CustomerInformations
                              .Where(i => i.Id == customerinformation.Id && i.CustomerId == customerinformation.CustomerId)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(customerinformation);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCustomerInformationUpdated(customerinformation);

            return customerinformation;
        }

        partial void OnCustomerInformationDeleted(ZarenTravelBO.Models.ZarenTravel.CustomerInformation item);
        partial void OnAfterCustomerInformationDeleted(ZarenTravelBO.Models.ZarenTravel.CustomerInformation item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.CustomerInformation> DeleteCustomerInformation(int id, int customerid)
        {
            var itemToDelete = Context.CustomerInformations
                              .Where(i => i.Id == id && i.CustomerId == customerid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCustomerInformationDeleted(itemToDelete);


            Context.CustomerInformations.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCustomerInformationDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportDatabaseColumnsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/databasecolumns/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/databasecolumns/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportDatabaseColumnsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/databasecolumns/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/databasecolumns/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnDatabaseColumnsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.DatabaseColumn> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.DatabaseColumn>> GetDatabaseColumns(Query query = null)
        {
            var items = Context.DatabaseColumns.AsQueryable();

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

            OnDatabaseColumnsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnDatabaseColumnGet(ZarenTravelBO.Models.ZarenTravel.DatabaseColumn item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.DatabaseColumn> GetDatabaseColumnById(int id)
        {
            var items = Context.DatabaseColumns
                              .AsNoTracking()
                              .Where(i => i.ID == id);

                items = items.Include(i => i.DatabaseValueType);
                items = items.Include(i => i.DatabaseTable);
  
            var itemToReturn = items.FirstOrDefault();

            OnDatabaseColumnGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnDatabaseColumnCreated(ZarenTravelBO.Models.ZarenTravel.DatabaseColumn item);
        partial void OnAfterDatabaseColumnCreated(ZarenTravelBO.Models.ZarenTravel.DatabaseColumn item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.DatabaseColumn> CreateDatabaseColumn(ZarenTravelBO.Models.ZarenTravel.DatabaseColumn databasecolumn)
        {
            OnDatabaseColumnCreated(databasecolumn);

            var existingItem = Context.DatabaseColumns
                              .Where(i => i.ID == databasecolumn.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.DatabaseColumns.Add(databasecolumn);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(databasecolumn).State = EntityState.Detached;
                throw;
            }

            OnAfterDatabaseColumnCreated(databasecolumn);

            return databasecolumn;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.DatabaseColumn> CancelDatabaseColumnChanges(ZarenTravelBO.Models.ZarenTravel.DatabaseColumn item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnDatabaseColumnUpdated(ZarenTravelBO.Models.ZarenTravel.DatabaseColumn item);
        partial void OnAfterDatabaseColumnUpdated(ZarenTravelBO.Models.ZarenTravel.DatabaseColumn item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.DatabaseColumn> UpdateDatabaseColumn(int id, ZarenTravelBO.Models.ZarenTravel.DatabaseColumn databasecolumn)
        {
            OnDatabaseColumnUpdated(databasecolumn);

            var itemToUpdate = Context.DatabaseColumns
                              .Where(i => i.ID == databasecolumn.ID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(databasecolumn);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterDatabaseColumnUpdated(databasecolumn);

            return databasecolumn;
        }

        partial void OnDatabaseColumnDeleted(ZarenTravelBO.Models.ZarenTravel.DatabaseColumn item);
        partial void OnAfterDatabaseColumnDeleted(ZarenTravelBO.Models.ZarenTravel.DatabaseColumn item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.DatabaseColumn> DeleteDatabaseColumn(int id)
        {
            var itemToDelete = Context.DatabaseColumns
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnDatabaseColumnDeleted(itemToDelete);


            Context.DatabaseColumns.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterDatabaseColumnDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportDatabaseTablesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/databasetables/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/databasetables/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportDatabaseTablesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/databasetables/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/databasetables/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnDatabaseTablesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.DatabaseTable> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.DatabaseTable>> GetDatabaseTables(Query query = null)
        {
            var items = Context.DatabaseTables.AsQueryable();

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

            OnDatabaseTablesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnDatabaseTableGet(ZarenTravelBO.Models.ZarenTravel.DatabaseTable item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.DatabaseTable> GetDatabaseTableById(int id)
        {
            var items = Context.DatabaseTables
                              .AsNoTracking()
                              .Where(i => i.ID == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnDatabaseTableGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnDatabaseTableCreated(ZarenTravelBO.Models.ZarenTravel.DatabaseTable item);
        partial void OnAfterDatabaseTableCreated(ZarenTravelBO.Models.ZarenTravel.DatabaseTable item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.DatabaseTable> CreateDatabaseTable(ZarenTravelBO.Models.ZarenTravel.DatabaseTable databasetable)
        {
            OnDatabaseTableCreated(databasetable);

            var existingItem = Context.DatabaseTables
                              .Where(i => i.ID == databasetable.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.DatabaseTables.Add(databasetable);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(databasetable).State = EntityState.Detached;
                throw;
            }

            OnAfterDatabaseTableCreated(databasetable);

            return databasetable;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.DatabaseTable> CancelDatabaseTableChanges(ZarenTravelBO.Models.ZarenTravel.DatabaseTable item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnDatabaseTableUpdated(ZarenTravelBO.Models.ZarenTravel.DatabaseTable item);
        partial void OnAfterDatabaseTableUpdated(ZarenTravelBO.Models.ZarenTravel.DatabaseTable item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.DatabaseTable> UpdateDatabaseTable(int id, ZarenTravelBO.Models.ZarenTravel.DatabaseTable databasetable)
        {
            OnDatabaseTableUpdated(databasetable);

            var itemToUpdate = Context.DatabaseTables
                              .Where(i => i.ID == databasetable.ID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(databasetable);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterDatabaseTableUpdated(databasetable);

            return databasetable;
        }

        partial void OnDatabaseTableDeleted(ZarenTravelBO.Models.ZarenTravel.DatabaseTable item);
        partial void OnAfterDatabaseTableDeleted(ZarenTravelBO.Models.ZarenTravel.DatabaseTable item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.DatabaseTable> DeleteDatabaseTable(int id)
        {
            var itemToDelete = Context.DatabaseTables
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnDatabaseTableDeleted(itemToDelete);


            Context.DatabaseTables.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterDatabaseTableDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportDatabaseValueTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/databasevaluetypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/databasevaluetypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportDatabaseValueTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/databasevaluetypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/databasevaluetypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnDatabaseValueTypesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.DatabaseValueType> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.DatabaseValueType>> GetDatabaseValueTypes(Query query = null)
        {
            var items = Context.DatabaseValueTypes.AsQueryable();

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

            OnDatabaseValueTypesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnDatabaseValueTypeGet(ZarenTravelBO.Models.ZarenTravel.DatabaseValueType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.DatabaseValueType> GetDatabaseValueTypeById(int id)
        {
            var items = Context.DatabaseValueTypes
                              .AsNoTracking()
                              .Where(i => i.ID == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnDatabaseValueTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnDatabaseValueTypeCreated(ZarenTravelBO.Models.ZarenTravel.DatabaseValueType item);
        partial void OnAfterDatabaseValueTypeCreated(ZarenTravelBO.Models.ZarenTravel.DatabaseValueType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.DatabaseValueType> CreateDatabaseValueType(ZarenTravelBO.Models.ZarenTravel.DatabaseValueType databasevaluetype)
        {
            OnDatabaseValueTypeCreated(databasevaluetype);

            var existingItem = Context.DatabaseValueTypes
                              .Where(i => i.ID == databasevaluetype.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.DatabaseValueTypes.Add(databasevaluetype);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(databasevaluetype).State = EntityState.Detached;
                throw;
            }

            OnAfterDatabaseValueTypeCreated(databasevaluetype);

            return databasevaluetype;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.DatabaseValueType> CancelDatabaseValueTypeChanges(ZarenTravelBO.Models.ZarenTravel.DatabaseValueType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnDatabaseValueTypeUpdated(ZarenTravelBO.Models.ZarenTravel.DatabaseValueType item);
        partial void OnAfterDatabaseValueTypeUpdated(ZarenTravelBO.Models.ZarenTravel.DatabaseValueType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.DatabaseValueType> UpdateDatabaseValueType(int id, ZarenTravelBO.Models.ZarenTravel.DatabaseValueType databasevaluetype)
        {
            OnDatabaseValueTypeUpdated(databasevaluetype);

            var itemToUpdate = Context.DatabaseValueTypes
                              .Where(i => i.ID == databasevaluetype.ID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(databasevaluetype);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterDatabaseValueTypeUpdated(databasevaluetype);

            return databasevaluetype;
        }

        partial void OnDatabaseValueTypeDeleted(ZarenTravelBO.Models.ZarenTravel.DatabaseValueType item);
        partial void OnAfterDatabaseValueTypeDeleted(ZarenTravelBO.Models.ZarenTravel.DatabaseValueType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.DatabaseValueType> DeleteDatabaseValueType(int id)
        {
            var itemToDelete = Context.DatabaseValueTypes
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnDatabaseValueTypeDeleted(itemToDelete);


            Context.DatabaseValueTypes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterDatabaseValueTypeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportDatatableCmsInputTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/datatablecmsinputtypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/datatablecmsinputtypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportDatatableCmsInputTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/datatablecmsinputtypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/datatablecmsinputtypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnDatatableCmsInputTypesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.DatatableCmsInputType> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.DatatableCmsInputType>> GetDatatableCmsInputTypes(Query query = null)
        {
            var items = Context.DatatableCmsInputTypes.AsQueryable();

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

            OnDatatableCmsInputTypesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnDatatableCmsInputTypeGet(ZarenTravelBO.Models.ZarenTravel.DatatableCmsInputType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.DatatableCmsInputType> GetDatatableCmsInputTypeById(int id)
        {
            var items = Context.DatatableCmsInputTypes
                              .AsNoTracking()
                              .Where(i => i.ID == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnDatatableCmsInputTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnDatatableCmsInputTypeCreated(ZarenTravelBO.Models.ZarenTravel.DatatableCmsInputType item);
        partial void OnAfterDatatableCmsInputTypeCreated(ZarenTravelBO.Models.ZarenTravel.DatatableCmsInputType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.DatatableCmsInputType> CreateDatatableCmsInputType(ZarenTravelBO.Models.ZarenTravel.DatatableCmsInputType datatablecmsinputtype)
        {
            OnDatatableCmsInputTypeCreated(datatablecmsinputtype);

            var existingItem = Context.DatatableCmsInputTypes
                              .Where(i => i.ID == datatablecmsinputtype.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.DatatableCmsInputTypes.Add(datatablecmsinputtype);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(datatablecmsinputtype).State = EntityState.Detached;
                throw;
            }

            OnAfterDatatableCmsInputTypeCreated(datatablecmsinputtype);

            return datatablecmsinputtype;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.DatatableCmsInputType> CancelDatatableCmsInputTypeChanges(ZarenTravelBO.Models.ZarenTravel.DatatableCmsInputType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnDatatableCmsInputTypeUpdated(ZarenTravelBO.Models.ZarenTravel.DatatableCmsInputType item);
        partial void OnAfterDatatableCmsInputTypeUpdated(ZarenTravelBO.Models.ZarenTravel.DatatableCmsInputType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.DatatableCmsInputType> UpdateDatatableCmsInputType(int id, ZarenTravelBO.Models.ZarenTravel.DatatableCmsInputType datatablecmsinputtype)
        {
            OnDatatableCmsInputTypeUpdated(datatablecmsinputtype);

            var itemToUpdate = Context.DatatableCmsInputTypes
                              .Where(i => i.ID == datatablecmsinputtype.ID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(datatablecmsinputtype);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterDatatableCmsInputTypeUpdated(datatablecmsinputtype);

            return datatablecmsinputtype;
        }

        partial void OnDatatableCmsInputTypeDeleted(ZarenTravelBO.Models.ZarenTravel.DatatableCmsInputType item);
        partial void OnAfterDatatableCmsInputTypeDeleted(ZarenTravelBO.Models.ZarenTravel.DatatableCmsInputType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.DatatableCmsInputType> DeleteDatatableCmsInputType(int id)
        {
            var itemToDelete = Context.DatatableCmsInputTypes
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnDatatableCmsInputTypeDeleted(itemToDelete);


            Context.DatatableCmsInputTypes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterDatatableCmsInputTypeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportDealsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/deals/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/deals/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportDealsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/deals/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/deals/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnDealsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.Deal> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.Deal>> GetDeals(Query query = null)
        {
            var items = Context.Deals.AsQueryable();

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

            OnDealsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnDealGet(ZarenTravelBO.Models.ZarenTravel.Deal item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Deal> GetDealById(int id)
        {
            var items = Context.Deals
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.BoardType);
                items = items.Include(i => i.DealType);
                items = items.Include(i => i.HotelRoom);
  
            var itemToReturn = items.FirstOrDefault();

            OnDealGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnDealCreated(ZarenTravelBO.Models.ZarenTravel.Deal item);
        partial void OnAfterDealCreated(ZarenTravelBO.Models.ZarenTravel.Deal item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Deal> CreateDeal(ZarenTravelBO.Models.ZarenTravel.Deal deal)
        {
            OnDealCreated(deal);

            var existingItem = Context.Deals
                              .Where(i => i.Id == deal.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Deals.Add(deal);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(deal).State = EntityState.Detached;
                throw;
            }

            OnAfterDealCreated(deal);

            return deal;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.Deal> CancelDealChanges(ZarenTravelBO.Models.ZarenTravel.Deal item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnDealUpdated(ZarenTravelBO.Models.ZarenTravel.Deal item);
        partial void OnAfterDealUpdated(ZarenTravelBO.Models.ZarenTravel.Deal item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Deal> UpdateDeal(int id, ZarenTravelBO.Models.ZarenTravel.Deal deal)
        {
            OnDealUpdated(deal);

            var itemToUpdate = Context.Deals
                              .Where(i => i.Id == deal.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(deal);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterDealUpdated(deal);

            return deal;
        }

        partial void OnDealDeleted(ZarenTravelBO.Models.ZarenTravel.Deal item);
        partial void OnAfterDealDeleted(ZarenTravelBO.Models.ZarenTravel.Deal item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Deal> DeleteDeal(int id)
        {
            var itemToDelete = Context.Deals
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnDealDeleted(itemToDelete);


            Context.Deals.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterDealDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportDealTypeLanguagesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/dealtypelanguages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/dealtypelanguages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportDealTypeLanguagesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/dealtypelanguages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/dealtypelanguages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnDealTypeLanguagesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.DealTypeLanguage> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.DealTypeLanguage>> GetDealTypeLanguages(Query query = null)
        {
            var items = Context.DealTypeLanguages.AsQueryable();

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

            OnDealTypeLanguagesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnDealTypeLanguageGet(ZarenTravelBO.Models.ZarenTravel.DealTypeLanguage item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.DealTypeLanguage> GetDealTypeLanguageById(int id)
        {
            var items = Context.DealTypeLanguages
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.DealType);
                items = items.Include(i => i.Language);
  
            var itemToReturn = items.FirstOrDefault();

            OnDealTypeLanguageGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnDealTypeLanguageCreated(ZarenTravelBO.Models.ZarenTravel.DealTypeLanguage item);
        partial void OnAfterDealTypeLanguageCreated(ZarenTravelBO.Models.ZarenTravel.DealTypeLanguage item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.DealTypeLanguage> CreateDealTypeLanguage(ZarenTravelBO.Models.ZarenTravel.DealTypeLanguage dealtypelanguage)
        {
            OnDealTypeLanguageCreated(dealtypelanguage);

            var existingItem = Context.DealTypeLanguages
                              .Where(i => i.Id == dealtypelanguage.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.DealTypeLanguages.Add(dealtypelanguage);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(dealtypelanguage).State = EntityState.Detached;
                throw;
            }

            OnAfterDealTypeLanguageCreated(dealtypelanguage);

            return dealtypelanguage;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.DealTypeLanguage> CancelDealTypeLanguageChanges(ZarenTravelBO.Models.ZarenTravel.DealTypeLanguage item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnDealTypeLanguageUpdated(ZarenTravelBO.Models.ZarenTravel.DealTypeLanguage item);
        partial void OnAfterDealTypeLanguageUpdated(ZarenTravelBO.Models.ZarenTravel.DealTypeLanguage item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.DealTypeLanguage> UpdateDealTypeLanguage(int id, ZarenTravelBO.Models.ZarenTravel.DealTypeLanguage dealtypelanguage)
        {
            OnDealTypeLanguageUpdated(dealtypelanguage);

            var itemToUpdate = Context.DealTypeLanguages
                              .Where(i => i.Id == dealtypelanguage.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(dealtypelanguage);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterDealTypeLanguageUpdated(dealtypelanguage);

            return dealtypelanguage;
        }

        partial void OnDealTypeLanguageDeleted(ZarenTravelBO.Models.ZarenTravel.DealTypeLanguage item);
        partial void OnAfterDealTypeLanguageDeleted(ZarenTravelBO.Models.ZarenTravel.DealTypeLanguage item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.DealTypeLanguage> DeleteDealTypeLanguage(int id)
        {
            var itemToDelete = Context.DealTypeLanguages
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnDealTypeLanguageDeleted(itemToDelete);


            Context.DealTypeLanguages.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterDealTypeLanguageDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportDealTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/dealtypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/dealtypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportDealTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/dealtypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/dealtypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnDealTypesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.DealType> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.DealType>> GetDealTypes(Query query = null)
        {
            var items = Context.DealTypes.AsQueryable();

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

            OnDealTypesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnDealTypeGet(ZarenTravelBO.Models.ZarenTravel.DealType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.DealType> GetDealTypeById(int id)
        {
            var items = Context.DealTypes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnDealTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnDealTypeCreated(ZarenTravelBO.Models.ZarenTravel.DealType item);
        partial void OnAfterDealTypeCreated(ZarenTravelBO.Models.ZarenTravel.DealType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.DealType> CreateDealType(ZarenTravelBO.Models.ZarenTravel.DealType dealtype)
        {
            OnDealTypeCreated(dealtype);

            var existingItem = Context.DealTypes
                              .Where(i => i.Id == dealtype.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.DealTypes.Add(dealtype);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(dealtype).State = EntityState.Detached;
                throw;
            }

            OnAfterDealTypeCreated(dealtype);

            return dealtype;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.DealType> CancelDealTypeChanges(ZarenTravelBO.Models.ZarenTravel.DealType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnDealTypeUpdated(ZarenTravelBO.Models.ZarenTravel.DealType item);
        partial void OnAfterDealTypeUpdated(ZarenTravelBO.Models.ZarenTravel.DealType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.DealType> UpdateDealType(int id, ZarenTravelBO.Models.ZarenTravel.DealType dealtype)
        {
            OnDealTypeUpdated(dealtype);

            var itemToUpdate = Context.DealTypes
                              .Where(i => i.Id == dealtype.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(dealtype);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterDealTypeUpdated(dealtype);

            return dealtype;
        }

        partial void OnDealTypeDeleted(ZarenTravelBO.Models.ZarenTravel.DealType item);
        partial void OnAfterDealTypeDeleted(ZarenTravelBO.Models.ZarenTravel.DealType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.DealType> DeleteDealType(int id)
        {
            var itemToDelete = Context.DealTypes
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnDealTypeDeleted(itemToDelete);


            Context.DealTypes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterDealTypeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportExchangeRatesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/exchangerates/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/exchangerates/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportExchangeRatesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/exchangerates/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/exchangerates/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnExchangeRatesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.ExchangeRate> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.ExchangeRate>> GetExchangeRates(Query query = null)
        {
            var items = Context.ExchangeRates.AsQueryable();

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

            OnExchangeRatesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnExchangeRateGet(ZarenTravelBO.Models.ZarenTravel.ExchangeRate item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.ExchangeRate> GetExchangeRateById(int id)
        {
            var items = Context.ExchangeRates
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Currency);
                items = items.Include(i => i.Currency1);
  
            var itemToReturn = items.FirstOrDefault();

            OnExchangeRateGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnExchangeRateCreated(ZarenTravelBO.Models.ZarenTravel.ExchangeRate item);
        partial void OnAfterExchangeRateCreated(ZarenTravelBO.Models.ZarenTravel.ExchangeRate item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.ExchangeRate> CreateExchangeRate(ZarenTravelBO.Models.ZarenTravel.ExchangeRate exchangerate)
        {
            OnExchangeRateCreated(exchangerate);

            var existingItem = Context.ExchangeRates
                              .Where(i => i.Id == exchangerate.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ExchangeRates.Add(exchangerate);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(exchangerate).State = EntityState.Detached;
                throw;
            }

            OnAfterExchangeRateCreated(exchangerate);

            return exchangerate;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.ExchangeRate> CancelExchangeRateChanges(ZarenTravelBO.Models.ZarenTravel.ExchangeRate item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnExchangeRateUpdated(ZarenTravelBO.Models.ZarenTravel.ExchangeRate item);
        partial void OnAfterExchangeRateUpdated(ZarenTravelBO.Models.ZarenTravel.ExchangeRate item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.ExchangeRate> UpdateExchangeRate(int id, ZarenTravelBO.Models.ZarenTravel.ExchangeRate exchangerate)
        {
            OnExchangeRateUpdated(exchangerate);

            var itemToUpdate = Context.ExchangeRates
                              .Where(i => i.Id == exchangerate.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(exchangerate);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterExchangeRateUpdated(exchangerate);

            return exchangerate;
        }

        partial void OnExchangeRateDeleted(ZarenTravelBO.Models.ZarenTravel.ExchangeRate item);
        partial void OnAfterExchangeRateDeleted(ZarenTravelBO.Models.ZarenTravel.ExchangeRate item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.ExchangeRate> DeleteExchangeRate(int id)
        {
            var itemToDelete = Context.ExchangeRates
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnExchangeRateDeleted(itemToDelete);


            Context.ExchangeRates.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterExchangeRateDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportExtensionsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/extensions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/extensions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportExtensionsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/extensions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/extensions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnExtensionsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.Extension> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.Extension>> GetExtensions(Query query = null)
        {
            var items = Context.Extensions.AsQueryable();

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

            OnExtensionsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnExtensionGet(ZarenTravelBO.Models.ZarenTravel.Extension item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Extension> GetExtensionById(int id)
        {
            var items = Context.Extensions
                              .AsNoTracking()
                              .Where(i => i.ID == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnExtensionGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnExtensionCreated(ZarenTravelBO.Models.ZarenTravel.Extension item);
        partial void OnAfterExtensionCreated(ZarenTravelBO.Models.ZarenTravel.Extension item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Extension> CreateExtension(ZarenTravelBO.Models.ZarenTravel.Extension extension)
        {
            OnExtensionCreated(extension);

            var existingItem = Context.Extensions
                              .Where(i => i.ID == extension.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Extensions.Add(extension);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(extension).State = EntityState.Detached;
                throw;
            }

            OnAfterExtensionCreated(extension);

            return extension;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.Extension> CancelExtensionChanges(ZarenTravelBO.Models.ZarenTravel.Extension item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnExtensionUpdated(ZarenTravelBO.Models.ZarenTravel.Extension item);
        partial void OnAfterExtensionUpdated(ZarenTravelBO.Models.ZarenTravel.Extension item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Extension> UpdateExtension(int id, ZarenTravelBO.Models.ZarenTravel.Extension extension)
        {
            OnExtensionUpdated(extension);

            var itemToUpdate = Context.Extensions
                              .Where(i => i.ID == extension.ID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(extension);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterExtensionUpdated(extension);

            return extension;
        }

        partial void OnExtensionDeleted(ZarenTravelBO.Models.ZarenTravel.Extension item);
        partial void OnAfterExtensionDeleted(ZarenTravelBO.Models.ZarenTravel.Extension item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Extension> DeleteExtension(int id)
        {
            var itemToDelete = Context.Extensions
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnExtensionDeleted(itemToDelete);


            Context.Extensions.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterExtensionDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportExtrasTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/extrastypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/extrastypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportExtrasTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/extrastypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/extrastypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnExtrasTypesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.ExtrasType> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.ExtrasType>> GetExtrasTypes(Query query = null)
        {
            var items = Context.ExtrasTypes.AsQueryable();

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

            OnExtrasTypesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnExtrasTypeGet(ZarenTravelBO.Models.ZarenTravel.ExtrasType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.ExtrasType> GetExtrasTypeById(int id)
        {
            var items = Context.ExtrasTypes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnExtrasTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnExtrasTypeCreated(ZarenTravelBO.Models.ZarenTravel.ExtrasType item);
        partial void OnAfterExtrasTypeCreated(ZarenTravelBO.Models.ZarenTravel.ExtrasType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.ExtrasType> CreateExtrasType(ZarenTravelBO.Models.ZarenTravel.ExtrasType extrastype)
        {
            OnExtrasTypeCreated(extrastype);

            var existingItem = Context.ExtrasTypes
                              .Where(i => i.Id == extrastype.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ExtrasTypes.Add(extrastype);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(extrastype).State = EntityState.Detached;
                throw;
            }

            OnAfterExtrasTypeCreated(extrastype);

            return extrastype;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.ExtrasType> CancelExtrasTypeChanges(ZarenTravelBO.Models.ZarenTravel.ExtrasType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnExtrasTypeUpdated(ZarenTravelBO.Models.ZarenTravel.ExtrasType item);
        partial void OnAfterExtrasTypeUpdated(ZarenTravelBO.Models.ZarenTravel.ExtrasType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.ExtrasType> UpdateExtrasType(int id, ZarenTravelBO.Models.ZarenTravel.ExtrasType extrastype)
        {
            OnExtrasTypeUpdated(extrastype);

            var itemToUpdate = Context.ExtrasTypes
                              .Where(i => i.Id == extrastype.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(extrastype);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterExtrasTypeUpdated(extrastype);

            return extrastype;
        }

        partial void OnExtrasTypeDeleted(ZarenTravelBO.Models.ZarenTravel.ExtrasType item);
        partial void OnAfterExtrasTypeDeleted(ZarenTravelBO.Models.ZarenTravel.ExtrasType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.ExtrasType> DeleteExtrasType(int id)
        {
            var itemToDelete = Context.ExtrasTypes
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnExtrasTypeDeleted(itemToDelete);


            Context.ExtrasTypes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterExtrasTypeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportFacilitiesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/facilities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/facilities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportFacilitiesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/facilities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/facilities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnFacilitiesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.Facility> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.Facility>> GetFacilities(Query query = null)
        {
            var items = Context.Facilities.AsQueryable();

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

            OnFacilitiesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnFacilityGet(ZarenTravelBO.Models.ZarenTravel.Facility item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Facility> GetFacilityById(int id)
        {
            var items = Context.Facilities
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnFacilityGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnFacilityCreated(ZarenTravelBO.Models.ZarenTravel.Facility item);
        partial void OnAfterFacilityCreated(ZarenTravelBO.Models.ZarenTravel.Facility item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Facility> CreateFacility(ZarenTravelBO.Models.ZarenTravel.Facility facility)
        {
            OnFacilityCreated(facility);

            var existingItem = Context.Facilities
                              .Where(i => i.Id == facility.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Facilities.Add(facility);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(facility).State = EntityState.Detached;
                throw;
            }

            OnAfterFacilityCreated(facility);

            return facility;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.Facility> CancelFacilityChanges(ZarenTravelBO.Models.ZarenTravel.Facility item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnFacilityUpdated(ZarenTravelBO.Models.ZarenTravel.Facility item);
        partial void OnAfterFacilityUpdated(ZarenTravelBO.Models.ZarenTravel.Facility item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Facility> UpdateFacility(int id, ZarenTravelBO.Models.ZarenTravel.Facility facility)
        {
            OnFacilityUpdated(facility);

            var itemToUpdate = Context.Facilities
                              .Where(i => i.Id == facility.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(facility);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterFacilityUpdated(facility);

            return facility;
        }

        partial void OnFacilityDeleted(ZarenTravelBO.Models.ZarenTravel.Facility item);
        partial void OnAfterFacilityDeleted(ZarenTravelBO.Models.ZarenTravel.Facility item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Facility> DeleteFacility(int id)
        {
            var itemToDelete = Context.Facilities
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnFacilityDeleted(itemToDelete);


            Context.Facilities.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterFacilityDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportFacilitiesHotelsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/facilitieshotels/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/facilitieshotels/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportFacilitiesHotelsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/facilitieshotels/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/facilitieshotels/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnFacilitiesHotelsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.FacilitiesHotel> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.FacilitiesHotel>> GetFacilitiesHotels(Query query = null)
        {
            var items = Context.FacilitiesHotels.AsQueryable();

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

            OnFacilitiesHotelsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnFacilitiesHotelGet(ZarenTravelBO.Models.ZarenTravel.FacilitiesHotel item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.FacilitiesHotel> GetFacilitiesHotelById(int id)
        {
            var items = Context.FacilitiesHotels
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Facility);
                items = items.Include(i => i.Hotel);
                items = items.Include(i => i.HotelRoom);
  
            var itemToReturn = items.FirstOrDefault();

            OnFacilitiesHotelGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnFacilitiesHotelCreated(ZarenTravelBO.Models.ZarenTravel.FacilitiesHotel item);
        partial void OnAfterFacilitiesHotelCreated(ZarenTravelBO.Models.ZarenTravel.FacilitiesHotel item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.FacilitiesHotel> CreateFacilitiesHotel(ZarenTravelBO.Models.ZarenTravel.FacilitiesHotel facilitieshotel)
        {
            OnFacilitiesHotelCreated(facilitieshotel);

            var existingItem = Context.FacilitiesHotels
                              .Where(i => i.Id == facilitieshotel.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.FacilitiesHotels.Add(facilitieshotel);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(facilitieshotel).State = EntityState.Detached;
                throw;
            }

            OnAfterFacilitiesHotelCreated(facilitieshotel);

            return facilitieshotel;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.FacilitiesHotel> CancelFacilitiesHotelChanges(ZarenTravelBO.Models.ZarenTravel.FacilitiesHotel item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnFacilitiesHotelUpdated(ZarenTravelBO.Models.ZarenTravel.FacilitiesHotel item);
        partial void OnAfterFacilitiesHotelUpdated(ZarenTravelBO.Models.ZarenTravel.FacilitiesHotel item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.FacilitiesHotel> UpdateFacilitiesHotel(int id, ZarenTravelBO.Models.ZarenTravel.FacilitiesHotel facilitieshotel)
        {
            OnFacilitiesHotelUpdated(facilitieshotel);

            var itemToUpdate = Context.FacilitiesHotels
                              .Where(i => i.Id == facilitieshotel.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(facilitieshotel);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterFacilitiesHotelUpdated(facilitieshotel);

            return facilitieshotel;
        }

        partial void OnFacilitiesHotelDeleted(ZarenTravelBO.Models.ZarenTravel.FacilitiesHotel item);
        partial void OnAfterFacilitiesHotelDeleted(ZarenTravelBO.Models.ZarenTravel.FacilitiesHotel item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.FacilitiesHotel> DeleteFacilitiesHotel(int id)
        {
            var itemToDelete = Context.FacilitiesHotels
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnFacilitiesHotelDeleted(itemToDelete);


            Context.FacilitiesHotels.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterFacilitiesHotelDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportFacilityLanguagesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/facilitylanguages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/facilitylanguages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportFacilityLanguagesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/facilitylanguages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/facilitylanguages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnFacilityLanguagesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.FacilityLanguage> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.FacilityLanguage>> GetFacilityLanguages(Query query = null)
        {
            var items = Context.FacilityLanguages.AsQueryable();

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

            OnFacilityLanguagesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnFacilityLanguageGet(ZarenTravelBO.Models.ZarenTravel.FacilityLanguage item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.FacilityLanguage> GetFacilityLanguageById(int id)
        {
            var items = Context.FacilityLanguages
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Facility);
                items = items.Include(i => i.Language);
  
            var itemToReturn = items.FirstOrDefault();

            OnFacilityLanguageGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnFacilityLanguageCreated(ZarenTravelBO.Models.ZarenTravel.FacilityLanguage item);
        partial void OnAfterFacilityLanguageCreated(ZarenTravelBO.Models.ZarenTravel.FacilityLanguage item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.FacilityLanguage> CreateFacilityLanguage(ZarenTravelBO.Models.ZarenTravel.FacilityLanguage facilitylanguage)
        {
            OnFacilityLanguageCreated(facilitylanguage);

            var existingItem = Context.FacilityLanguages
                              .Where(i => i.Id == facilitylanguage.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.FacilityLanguages.Add(facilitylanguage);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(facilitylanguage).State = EntityState.Detached;
                throw;
            }

            OnAfterFacilityLanguageCreated(facilitylanguage);

            return facilitylanguage;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.FacilityLanguage> CancelFacilityLanguageChanges(ZarenTravelBO.Models.ZarenTravel.FacilityLanguage item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnFacilityLanguageUpdated(ZarenTravelBO.Models.ZarenTravel.FacilityLanguage item);
        partial void OnAfterFacilityLanguageUpdated(ZarenTravelBO.Models.ZarenTravel.FacilityLanguage item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.FacilityLanguage> UpdateFacilityLanguage(int id, ZarenTravelBO.Models.ZarenTravel.FacilityLanguage facilitylanguage)
        {
            OnFacilityLanguageUpdated(facilitylanguage);

            var itemToUpdate = Context.FacilityLanguages
                              .Where(i => i.Id == facilitylanguage.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(facilitylanguage);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterFacilityLanguageUpdated(facilitylanguage);

            return facilitylanguage;
        }

        partial void OnFacilityLanguageDeleted(ZarenTravelBO.Models.ZarenTravel.FacilityLanguage item);
        partial void OnAfterFacilityLanguageDeleted(ZarenTravelBO.Models.ZarenTravel.FacilityLanguage item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.FacilityLanguage> DeleteFacilityLanguage(int id)
        {
            var itemToDelete = Context.FacilityLanguages
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnFacilityLanguageDeleted(itemToDelete);


            Context.FacilityLanguages.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterFacilityLanguageDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportFieldsTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/fieldstypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/fieldstypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportFieldsTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/fieldstypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/fieldstypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnFieldsTypesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.FieldsType> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.FieldsType>> GetFieldsTypes(Query query = null)
        {
            var items = Context.FieldsTypes.AsQueryable();

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

            OnFieldsTypesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnFieldsTypeGet(ZarenTravelBO.Models.ZarenTravel.FieldsType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.FieldsType> GetFieldsTypeById(int id)
        {
            var items = Context.FieldsTypes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnFieldsTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnFieldsTypeCreated(ZarenTravelBO.Models.ZarenTravel.FieldsType item);
        partial void OnAfterFieldsTypeCreated(ZarenTravelBO.Models.ZarenTravel.FieldsType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.FieldsType> CreateFieldsType(ZarenTravelBO.Models.ZarenTravel.FieldsType fieldstype)
        {
            OnFieldsTypeCreated(fieldstype);

            var existingItem = Context.FieldsTypes
                              .Where(i => i.Id == fieldstype.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.FieldsTypes.Add(fieldstype);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(fieldstype).State = EntityState.Detached;
                throw;
            }

            OnAfterFieldsTypeCreated(fieldstype);

            return fieldstype;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.FieldsType> CancelFieldsTypeChanges(ZarenTravelBO.Models.ZarenTravel.FieldsType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnFieldsTypeUpdated(ZarenTravelBO.Models.ZarenTravel.FieldsType item);
        partial void OnAfterFieldsTypeUpdated(ZarenTravelBO.Models.ZarenTravel.FieldsType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.FieldsType> UpdateFieldsType(int id, ZarenTravelBO.Models.ZarenTravel.FieldsType fieldstype)
        {
            OnFieldsTypeUpdated(fieldstype);

            var itemToUpdate = Context.FieldsTypes
                              .Where(i => i.Id == fieldstype.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(fieldstype);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterFieldsTypeUpdated(fieldstype);

            return fieldstype;
        }

        partial void OnFieldsTypeDeleted(ZarenTravelBO.Models.ZarenTravel.FieldsType item);
        partial void OnAfterFieldsTypeDeleted(ZarenTravelBO.Models.ZarenTravel.FieldsType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.FieldsType> DeleteFieldsType(int id)
        {
            var itemToDelete = Context.FieldsTypes
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnFieldsTypeDeleted(itemToDelete);


            Context.FieldsTypes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterFieldsTypeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportHeaderColorsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/headercolors/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/headercolors/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportHeaderColorsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/headercolors/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/headercolors/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnHeaderColorsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.HeaderColor> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.HeaderColor>> GetHeaderColors(Query query = null)
        {
            var items = Context.HeaderColors.AsQueryable();

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

            OnHeaderColorsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnHeaderColorGet(ZarenTravelBO.Models.ZarenTravel.HeaderColor item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HeaderColor> GetHeaderColorById(int id)
        {
            var items = Context.HeaderColors
                              .AsNoTracking()
                              .Where(i => i.ID == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnHeaderColorGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnHeaderColorCreated(ZarenTravelBO.Models.ZarenTravel.HeaderColor item);
        partial void OnAfterHeaderColorCreated(ZarenTravelBO.Models.ZarenTravel.HeaderColor item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HeaderColor> CreateHeaderColor(ZarenTravelBO.Models.ZarenTravel.HeaderColor headercolor)
        {
            OnHeaderColorCreated(headercolor);

            var existingItem = Context.HeaderColors
                              .Where(i => i.ID == headercolor.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.HeaderColors.Add(headercolor);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(headercolor).State = EntityState.Detached;
                throw;
            }

            OnAfterHeaderColorCreated(headercolor);

            return headercolor;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.HeaderColor> CancelHeaderColorChanges(ZarenTravelBO.Models.ZarenTravel.HeaderColor item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnHeaderColorUpdated(ZarenTravelBO.Models.ZarenTravel.HeaderColor item);
        partial void OnAfterHeaderColorUpdated(ZarenTravelBO.Models.ZarenTravel.HeaderColor item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HeaderColor> UpdateHeaderColor(int id, ZarenTravelBO.Models.ZarenTravel.HeaderColor headercolor)
        {
            OnHeaderColorUpdated(headercolor);

            var itemToUpdate = Context.HeaderColors
                              .Where(i => i.ID == headercolor.ID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(headercolor);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterHeaderColorUpdated(headercolor);

            return headercolor;
        }

        partial void OnHeaderColorDeleted(ZarenTravelBO.Models.ZarenTravel.HeaderColor item);
        partial void OnAfterHeaderColorDeleted(ZarenTravelBO.Models.ZarenTravel.HeaderColor item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HeaderColor> DeleteHeaderColor(int id)
        {
            var itemToDelete = Context.HeaderColors
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnHeaderColorDeleted(itemToDelete);


            Context.HeaderColors.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterHeaderColorDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportHotelAgencyMarkupsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/hotelagencymarkups/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/hotelagencymarkups/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportHotelAgencyMarkupsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/hotelagencymarkups/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/hotelagencymarkups/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnHotelAgencyMarkupsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.HotelAgencyMarkup> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.HotelAgencyMarkup>> GetHotelAgencyMarkups(Query query = null)
        {
            var items = Context.HotelAgencyMarkups.AsQueryable();

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

            OnHotelAgencyMarkupsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnHotelAgencyMarkupGet(ZarenTravelBO.Models.ZarenTravel.HotelAgencyMarkup item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelAgencyMarkup> GetHotelAgencyMarkupById(int id)
        {
            var items = Context.HotelAgencyMarkups
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Agency);
                items = items.Include(i => i.Hotel);
  
            var itemToReturn = items.FirstOrDefault();

            OnHotelAgencyMarkupGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnHotelAgencyMarkupCreated(ZarenTravelBO.Models.ZarenTravel.HotelAgencyMarkup item);
        partial void OnAfterHotelAgencyMarkupCreated(ZarenTravelBO.Models.ZarenTravel.HotelAgencyMarkup item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelAgencyMarkup> CreateHotelAgencyMarkup(ZarenTravelBO.Models.ZarenTravel.HotelAgencyMarkup hotelagencymarkup)
        {
            OnHotelAgencyMarkupCreated(hotelagencymarkup);

            var existingItem = Context.HotelAgencyMarkups
                              .Where(i => i.Id == hotelagencymarkup.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.HotelAgencyMarkups.Add(hotelagencymarkup);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(hotelagencymarkup).State = EntityState.Detached;
                throw;
            }

            OnAfterHotelAgencyMarkupCreated(hotelagencymarkup);

            return hotelagencymarkup;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelAgencyMarkup> CancelHotelAgencyMarkupChanges(ZarenTravelBO.Models.ZarenTravel.HotelAgencyMarkup item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnHotelAgencyMarkupUpdated(ZarenTravelBO.Models.ZarenTravel.HotelAgencyMarkup item);
        partial void OnAfterHotelAgencyMarkupUpdated(ZarenTravelBO.Models.ZarenTravel.HotelAgencyMarkup item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelAgencyMarkup> UpdateHotelAgencyMarkup(int id, ZarenTravelBO.Models.ZarenTravel.HotelAgencyMarkup hotelagencymarkup)
        {
            OnHotelAgencyMarkupUpdated(hotelagencymarkup);

            var itemToUpdate = Context.HotelAgencyMarkups
                              .Where(i => i.Id == hotelagencymarkup.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(hotelagencymarkup);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterHotelAgencyMarkupUpdated(hotelagencymarkup);

            return hotelagencymarkup;
        }

        partial void OnHotelAgencyMarkupDeleted(ZarenTravelBO.Models.ZarenTravel.HotelAgencyMarkup item);
        partial void OnAfterHotelAgencyMarkupDeleted(ZarenTravelBO.Models.ZarenTravel.HotelAgencyMarkup item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelAgencyMarkup> DeleteHotelAgencyMarkup(int id)
        {
            var itemToDelete = Context.HotelAgencyMarkups
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnHotelAgencyMarkupDeleted(itemToDelete);


            Context.HotelAgencyMarkups.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterHotelAgencyMarkupDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportHotelBuyRoomAllotmentsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/hotelbuyroomallotments/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/hotelbuyroomallotments/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportHotelBuyRoomAllotmentsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/hotelbuyroomallotments/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/hotelbuyroomallotments/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnHotelBuyRoomAllotmentsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.HotelBuyRoomAllotment> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.HotelBuyRoomAllotment>> GetHotelBuyRoomAllotments(Query query = null)
        {
            var items = Context.HotelBuyRoomAllotments.AsQueryable();

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

            OnHotelBuyRoomAllotmentsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnHotelBuyRoomAllotmentGet(ZarenTravelBO.Models.ZarenTravel.HotelBuyRoomAllotment item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelBuyRoomAllotment> GetHotelBuyRoomAllotmentById(int id)
        {
            var items = Context.HotelBuyRoomAllotments
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.HotelBuyRoom);
  
            var itemToReturn = items.FirstOrDefault();

            OnHotelBuyRoomAllotmentGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnHotelBuyRoomAllotmentCreated(ZarenTravelBO.Models.ZarenTravel.HotelBuyRoomAllotment item);
        partial void OnAfterHotelBuyRoomAllotmentCreated(ZarenTravelBO.Models.ZarenTravel.HotelBuyRoomAllotment item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelBuyRoomAllotment> CreateHotelBuyRoomAllotment(ZarenTravelBO.Models.ZarenTravel.HotelBuyRoomAllotment hotelbuyroomallotment)
        {
            OnHotelBuyRoomAllotmentCreated(hotelbuyroomallotment);

            var existingItem = Context.HotelBuyRoomAllotments
                              .Where(i => i.Id == hotelbuyroomallotment.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.HotelBuyRoomAllotments.Add(hotelbuyroomallotment);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(hotelbuyroomallotment).State = EntityState.Detached;
                throw;
            }

            OnAfterHotelBuyRoomAllotmentCreated(hotelbuyroomallotment);

            return hotelbuyroomallotment;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelBuyRoomAllotment> CancelHotelBuyRoomAllotmentChanges(ZarenTravelBO.Models.ZarenTravel.HotelBuyRoomAllotment item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnHotelBuyRoomAllotmentUpdated(ZarenTravelBO.Models.ZarenTravel.HotelBuyRoomAllotment item);
        partial void OnAfterHotelBuyRoomAllotmentUpdated(ZarenTravelBO.Models.ZarenTravel.HotelBuyRoomAllotment item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelBuyRoomAllotment> UpdateHotelBuyRoomAllotment(int id, ZarenTravelBO.Models.ZarenTravel.HotelBuyRoomAllotment hotelbuyroomallotment)
        {
            OnHotelBuyRoomAllotmentUpdated(hotelbuyroomallotment);

            var itemToUpdate = Context.HotelBuyRoomAllotments
                              .Where(i => i.Id == hotelbuyroomallotment.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(hotelbuyroomallotment);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterHotelBuyRoomAllotmentUpdated(hotelbuyroomallotment);

            return hotelbuyroomallotment;
        }

        partial void OnHotelBuyRoomAllotmentDeleted(ZarenTravelBO.Models.ZarenTravel.HotelBuyRoomAllotment item);
        partial void OnAfterHotelBuyRoomAllotmentDeleted(ZarenTravelBO.Models.ZarenTravel.HotelBuyRoomAllotment item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelBuyRoomAllotment> DeleteHotelBuyRoomAllotment(int id)
        {
            var itemToDelete = Context.HotelBuyRoomAllotments
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnHotelBuyRoomAllotmentDeleted(itemToDelete);


            Context.HotelBuyRoomAllotments.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterHotelBuyRoomAllotmentDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportHotelBuyRoomsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/hotelbuyrooms/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/hotelbuyrooms/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportHotelBuyRoomsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/hotelbuyrooms/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/hotelbuyrooms/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnHotelBuyRoomsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.HotelBuyRoom> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.HotelBuyRoom>> GetHotelBuyRooms(Query query = null)
        {
            var items = Context.HotelBuyRooms.AsQueryable();

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

            OnHotelBuyRoomsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnHotelBuyRoomGet(ZarenTravelBO.Models.ZarenTravel.HotelBuyRoom item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelBuyRoom> GetHotelBuyRoomById(int id)
        {
            var items = Context.HotelBuyRooms
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.BuyRoom);
                items = items.Include(i => i.Hotel);
  
            var itemToReturn = items.FirstOrDefault();

            OnHotelBuyRoomGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnHotelBuyRoomCreated(ZarenTravelBO.Models.ZarenTravel.HotelBuyRoom item);
        partial void OnAfterHotelBuyRoomCreated(ZarenTravelBO.Models.ZarenTravel.HotelBuyRoom item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelBuyRoom> CreateHotelBuyRoom(ZarenTravelBO.Models.ZarenTravel.HotelBuyRoom hotelbuyroom)
        {
            OnHotelBuyRoomCreated(hotelbuyroom);

            var existingItem = Context.HotelBuyRooms
                              .Where(i => i.Id == hotelbuyroom.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.HotelBuyRooms.Add(hotelbuyroom);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(hotelbuyroom).State = EntityState.Detached;
                throw;
            }

            OnAfterHotelBuyRoomCreated(hotelbuyroom);

            return hotelbuyroom;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelBuyRoom> CancelHotelBuyRoomChanges(ZarenTravelBO.Models.ZarenTravel.HotelBuyRoom item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnHotelBuyRoomUpdated(ZarenTravelBO.Models.ZarenTravel.HotelBuyRoom item);
        partial void OnAfterHotelBuyRoomUpdated(ZarenTravelBO.Models.ZarenTravel.HotelBuyRoom item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelBuyRoom> UpdateHotelBuyRoom(int id, ZarenTravelBO.Models.ZarenTravel.HotelBuyRoom hotelbuyroom)
        {
            OnHotelBuyRoomUpdated(hotelbuyroom);

            var itemToUpdate = Context.HotelBuyRooms
                              .Where(i => i.Id == hotelbuyroom.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(hotelbuyroom);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterHotelBuyRoomUpdated(hotelbuyroom);

            return hotelbuyroom;
        }

        partial void OnHotelBuyRoomDeleted(ZarenTravelBO.Models.ZarenTravel.HotelBuyRoom item);
        partial void OnAfterHotelBuyRoomDeleted(ZarenTravelBO.Models.ZarenTravel.HotelBuyRoom item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelBuyRoom> DeleteHotelBuyRoom(int id)
        {
            var itemToDelete = Context.HotelBuyRooms
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnHotelBuyRoomDeleted(itemToDelete);


            Context.HotelBuyRooms.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterHotelBuyRoomDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportHotelChainsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/hotelchains/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/hotelchains/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportHotelChainsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/hotelchains/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/hotelchains/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnHotelChainsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.HotelChain> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.HotelChain>> GetHotelChains(Query query = null)
        {
            var items = Context.HotelChains.AsQueryable();

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

            OnHotelChainsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnHotelChainGet(ZarenTravelBO.Models.ZarenTravel.HotelChain item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelChain> GetHotelChainById(int id)
        {
            var items = Context.HotelChains
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnHotelChainGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnHotelChainCreated(ZarenTravelBO.Models.ZarenTravel.HotelChain item);
        partial void OnAfterHotelChainCreated(ZarenTravelBO.Models.ZarenTravel.HotelChain item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelChain> CreateHotelChain(ZarenTravelBO.Models.ZarenTravel.HotelChain hotelchain)
        {
            OnHotelChainCreated(hotelchain);

            var existingItem = Context.HotelChains
                              .Where(i => i.Id == hotelchain.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.HotelChains.Add(hotelchain);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(hotelchain).State = EntityState.Detached;
                throw;
            }

            OnAfterHotelChainCreated(hotelchain);

            return hotelchain;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelChain> CancelHotelChainChanges(ZarenTravelBO.Models.ZarenTravel.HotelChain item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnHotelChainUpdated(ZarenTravelBO.Models.ZarenTravel.HotelChain item);
        partial void OnAfterHotelChainUpdated(ZarenTravelBO.Models.ZarenTravel.HotelChain item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelChain> UpdateHotelChain(int id, ZarenTravelBO.Models.ZarenTravel.HotelChain hotelchain)
        {
            OnHotelChainUpdated(hotelchain);

            var itemToUpdate = Context.HotelChains
                              .Where(i => i.Id == hotelchain.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(hotelchain);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterHotelChainUpdated(hotelchain);

            return hotelchain;
        }

        partial void OnHotelChainDeleted(ZarenTravelBO.Models.ZarenTravel.HotelChain item);
        partial void OnAfterHotelChainDeleted(ZarenTravelBO.Models.ZarenTravel.HotelChain item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelChain> DeleteHotelChain(int id)
        {
            var itemToDelete = Context.HotelChains
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnHotelChainDeleted(itemToDelete);


            Context.HotelChains.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterHotelChainDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportHotelDescriptionsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/hoteldescriptions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/hoteldescriptions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportHotelDescriptionsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/hoteldescriptions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/hoteldescriptions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnHotelDescriptionsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.HotelDescription> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.HotelDescription>> GetHotelDescriptions(Query query = null)
        {
            var items = Context.HotelDescriptions.AsQueryable();

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

            OnHotelDescriptionsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnHotelDescriptionGet(ZarenTravelBO.Models.ZarenTravel.HotelDescription item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelDescription> GetHotelDescriptionById(int id)
        {
            var items = Context.HotelDescriptions
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Hotel);
                items = items.Include(i => i.Language);
  
            var itemToReturn = items.FirstOrDefault();

            OnHotelDescriptionGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnHotelDescriptionCreated(ZarenTravelBO.Models.ZarenTravel.HotelDescription item);
        partial void OnAfterHotelDescriptionCreated(ZarenTravelBO.Models.ZarenTravel.HotelDescription item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelDescription> CreateHotelDescription(ZarenTravelBO.Models.ZarenTravel.HotelDescription hoteldescription)
        {
            OnHotelDescriptionCreated(hoteldescription);

            var existingItem = Context.HotelDescriptions
                              .Where(i => i.Id == hoteldescription.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.HotelDescriptions.Add(hoteldescription);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(hoteldescription).State = EntityState.Detached;
                throw;
            }

            OnAfterHotelDescriptionCreated(hoteldescription);

            return hoteldescription;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelDescription> CancelHotelDescriptionChanges(ZarenTravelBO.Models.ZarenTravel.HotelDescription item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnHotelDescriptionUpdated(ZarenTravelBO.Models.ZarenTravel.HotelDescription item);
        partial void OnAfterHotelDescriptionUpdated(ZarenTravelBO.Models.ZarenTravel.HotelDescription item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelDescription> UpdateHotelDescription(int id, ZarenTravelBO.Models.ZarenTravel.HotelDescription hoteldescription)
        {
            OnHotelDescriptionUpdated(hoteldescription);

            var itemToUpdate = Context.HotelDescriptions
                              .Where(i => i.Id == hoteldescription.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(hoteldescription);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterHotelDescriptionUpdated(hoteldescription);

            return hoteldescription;
        }

        partial void OnHotelDescriptionDeleted(ZarenTravelBO.Models.ZarenTravel.HotelDescription item);
        partial void OnAfterHotelDescriptionDeleted(ZarenTravelBO.Models.ZarenTravel.HotelDescription item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelDescription> DeleteHotelDescription(int id)
        {
            var itemToDelete = Context.HotelDescriptions
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnHotelDescriptionDeleted(itemToDelete);


            Context.HotelDescriptions.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterHotelDescriptionDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportHotelPhotoLanguagesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/hotelphotolanguages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/hotelphotolanguages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportHotelPhotoLanguagesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/hotelphotolanguages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/hotelphotolanguages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnHotelPhotoLanguagesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.HotelPhotoLanguage> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.HotelPhotoLanguage>> GetHotelPhotoLanguages(Query query = null)
        {
            var items = Context.HotelPhotoLanguages.AsQueryable();

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

            OnHotelPhotoLanguagesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnHotelPhotoLanguageGet(ZarenTravelBO.Models.ZarenTravel.HotelPhotoLanguage item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelPhotoLanguage> GetHotelPhotoLanguageById(int id)
        {
            var items = Context.HotelPhotoLanguages
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.HotelPhoto);
                items = items.Include(i => i.Language);
  
            var itemToReturn = items.FirstOrDefault();

            OnHotelPhotoLanguageGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnHotelPhotoLanguageCreated(ZarenTravelBO.Models.ZarenTravel.HotelPhotoLanguage item);
        partial void OnAfterHotelPhotoLanguageCreated(ZarenTravelBO.Models.ZarenTravel.HotelPhotoLanguage item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelPhotoLanguage> CreateHotelPhotoLanguage(ZarenTravelBO.Models.ZarenTravel.HotelPhotoLanguage hotelphotolanguage)
        {
            OnHotelPhotoLanguageCreated(hotelphotolanguage);

            var existingItem = Context.HotelPhotoLanguages
                              .Where(i => i.Id == hotelphotolanguage.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.HotelPhotoLanguages.Add(hotelphotolanguage);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(hotelphotolanguage).State = EntityState.Detached;
                throw;
            }

            OnAfterHotelPhotoLanguageCreated(hotelphotolanguage);

            return hotelphotolanguage;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelPhotoLanguage> CancelHotelPhotoLanguageChanges(ZarenTravelBO.Models.ZarenTravel.HotelPhotoLanguage item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnHotelPhotoLanguageUpdated(ZarenTravelBO.Models.ZarenTravel.HotelPhotoLanguage item);
        partial void OnAfterHotelPhotoLanguageUpdated(ZarenTravelBO.Models.ZarenTravel.HotelPhotoLanguage item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelPhotoLanguage> UpdateHotelPhotoLanguage(int id, ZarenTravelBO.Models.ZarenTravel.HotelPhotoLanguage hotelphotolanguage)
        {
            OnHotelPhotoLanguageUpdated(hotelphotolanguage);

            var itemToUpdate = Context.HotelPhotoLanguages
                              .Where(i => i.Id == hotelphotolanguage.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(hotelphotolanguage);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterHotelPhotoLanguageUpdated(hotelphotolanguage);

            return hotelphotolanguage;
        }

        partial void OnHotelPhotoLanguageDeleted(ZarenTravelBO.Models.ZarenTravel.HotelPhotoLanguage item);
        partial void OnAfterHotelPhotoLanguageDeleted(ZarenTravelBO.Models.ZarenTravel.HotelPhotoLanguage item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelPhotoLanguage> DeleteHotelPhotoLanguage(int id)
        {
            var itemToDelete = Context.HotelPhotoLanguages
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnHotelPhotoLanguageDeleted(itemToDelete);


            Context.HotelPhotoLanguages.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterHotelPhotoLanguageDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportHotelPhotosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/hotelphotos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/hotelphotos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportHotelPhotosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/hotelphotos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/hotelphotos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnHotelPhotosRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.HotelPhoto> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.HotelPhoto>> GetHotelPhotos(Query query = null)
        {
            var items = Context.HotelPhotos.AsQueryable();

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

            OnHotelPhotosRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnHotelPhotoGet(ZarenTravelBO.Models.ZarenTravel.HotelPhoto item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelPhoto> GetHotelPhotoById(int id)
        {
            var items = Context.HotelPhotos
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Hotel);
                items = items.Include(i => i.HotelRoom);
  
            var itemToReturn = items.FirstOrDefault();

            OnHotelPhotoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnHotelPhotoCreated(ZarenTravelBO.Models.ZarenTravel.HotelPhoto item);
        partial void OnAfterHotelPhotoCreated(ZarenTravelBO.Models.ZarenTravel.HotelPhoto item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelPhoto> CreateHotelPhoto(ZarenTravelBO.Models.ZarenTravel.HotelPhoto hotelphoto)
        {
            OnHotelPhotoCreated(hotelphoto);

            var existingItem = Context.HotelPhotos
                              .Where(i => i.Id == hotelphoto.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.HotelPhotos.Add(hotelphoto);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(hotelphoto).State = EntityState.Detached;
                throw;
            }

            OnAfterHotelPhotoCreated(hotelphoto);

            return hotelphoto;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelPhoto> CancelHotelPhotoChanges(ZarenTravelBO.Models.ZarenTravel.HotelPhoto item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnHotelPhotoUpdated(ZarenTravelBO.Models.ZarenTravel.HotelPhoto item);
        partial void OnAfterHotelPhotoUpdated(ZarenTravelBO.Models.ZarenTravel.HotelPhoto item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelPhoto> UpdateHotelPhoto(int id, ZarenTravelBO.Models.ZarenTravel.HotelPhoto hotelphoto)
        {
            OnHotelPhotoUpdated(hotelphoto);

            var itemToUpdate = Context.HotelPhotos
                              .Where(i => i.Id == hotelphoto.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(hotelphoto);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterHotelPhotoUpdated(hotelphoto);

            return hotelphoto;
        }

        partial void OnHotelPhotoDeleted(ZarenTravelBO.Models.ZarenTravel.HotelPhoto item);
        partial void OnAfterHotelPhotoDeleted(ZarenTravelBO.Models.ZarenTravel.HotelPhoto item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelPhoto> DeleteHotelPhoto(int id)
        {
            var itemToDelete = Context.HotelPhotos
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnHotelPhotoDeleted(itemToDelete);


            Context.HotelPhotos.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterHotelPhotoDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportHotelRoomDailyPricesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/hotelroomdailyprices/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/hotelroomdailyprices/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportHotelRoomDailyPricesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/hotelroomdailyprices/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/hotelroomdailyprices/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnHotelRoomDailyPricesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.HotelRoomDailyPrice> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.HotelRoomDailyPrice>> GetHotelRoomDailyPrices(Query query = null)
        {
            var items = Context.HotelRoomDailyPrices.AsQueryable();

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

            OnHotelRoomDailyPricesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnHotelRoomDailyPriceGet(ZarenTravelBO.Models.ZarenTravel.HotelRoomDailyPrice item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelRoomDailyPrice> GetHotelRoomDailyPriceById(int id)
        {
            var items = Context.HotelRoomDailyPrices
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.BoardType);
                items = items.Include(i => i.HotelRoom);
  
            var itemToReturn = items.FirstOrDefault();

            OnHotelRoomDailyPriceGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnHotelRoomDailyPriceCreated(ZarenTravelBO.Models.ZarenTravel.HotelRoomDailyPrice item);
        partial void OnAfterHotelRoomDailyPriceCreated(ZarenTravelBO.Models.ZarenTravel.HotelRoomDailyPrice item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelRoomDailyPrice> CreateHotelRoomDailyPrice(ZarenTravelBO.Models.ZarenTravel.HotelRoomDailyPrice hotelroomdailyprice)
        {
            OnHotelRoomDailyPriceCreated(hotelroomdailyprice);

            var existingItem = Context.HotelRoomDailyPrices
                              .Where(i => i.Id == hotelroomdailyprice.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.HotelRoomDailyPrices.Add(hotelroomdailyprice);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(hotelroomdailyprice).State = EntityState.Detached;
                throw;
            }

            OnAfterHotelRoomDailyPriceCreated(hotelroomdailyprice);

            return hotelroomdailyprice;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelRoomDailyPrice> CancelHotelRoomDailyPriceChanges(ZarenTravelBO.Models.ZarenTravel.HotelRoomDailyPrice item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnHotelRoomDailyPriceUpdated(ZarenTravelBO.Models.ZarenTravel.HotelRoomDailyPrice item);
        partial void OnAfterHotelRoomDailyPriceUpdated(ZarenTravelBO.Models.ZarenTravel.HotelRoomDailyPrice item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelRoomDailyPrice> UpdateHotelRoomDailyPrice(int id, ZarenTravelBO.Models.ZarenTravel.HotelRoomDailyPrice hotelroomdailyprice)
        {
            OnHotelRoomDailyPriceUpdated(hotelroomdailyprice);

            var itemToUpdate = Context.HotelRoomDailyPrices
                              .Where(i => i.Id == hotelroomdailyprice.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(hotelroomdailyprice);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterHotelRoomDailyPriceUpdated(hotelroomdailyprice);

            return hotelroomdailyprice;
        }

        partial void OnHotelRoomDailyPriceDeleted(ZarenTravelBO.Models.ZarenTravel.HotelRoomDailyPrice item);
        partial void OnAfterHotelRoomDailyPriceDeleted(ZarenTravelBO.Models.ZarenTravel.HotelRoomDailyPrice item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelRoomDailyPrice> DeleteHotelRoomDailyPrice(int id)
        {
            var itemToDelete = Context.HotelRoomDailyPrices
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnHotelRoomDailyPriceDeleted(itemToDelete);


            Context.HotelRoomDailyPrices.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterHotelRoomDailyPriceDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportHotelRoomLanguagesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/hotelroomlanguages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/hotelroomlanguages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportHotelRoomLanguagesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/hotelroomlanguages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/hotelroomlanguages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnHotelRoomLanguagesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.HotelRoomLanguage> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.HotelRoomLanguage>> GetHotelRoomLanguages(Query query = null)
        {
            var items = Context.HotelRoomLanguages.AsQueryable();

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

            OnHotelRoomLanguagesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnHotelRoomLanguageGet(ZarenTravelBO.Models.ZarenTravel.HotelRoomLanguage item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelRoomLanguage> GetHotelRoomLanguageById(int id)
        {
            var items = Context.HotelRoomLanguages
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.HotelRoom);
                items = items.Include(i => i.Language);
  
            var itemToReturn = items.FirstOrDefault();

            OnHotelRoomLanguageGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnHotelRoomLanguageCreated(ZarenTravelBO.Models.ZarenTravel.HotelRoomLanguage item);
        partial void OnAfterHotelRoomLanguageCreated(ZarenTravelBO.Models.ZarenTravel.HotelRoomLanguage item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelRoomLanguage> CreateHotelRoomLanguage(ZarenTravelBO.Models.ZarenTravel.HotelRoomLanguage hotelroomlanguage)
        {
            OnHotelRoomLanguageCreated(hotelroomlanguage);

            var existingItem = Context.HotelRoomLanguages
                              .Where(i => i.Id == hotelroomlanguage.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.HotelRoomLanguages.Add(hotelroomlanguage);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(hotelroomlanguage).State = EntityState.Detached;
                throw;
            }

            OnAfterHotelRoomLanguageCreated(hotelroomlanguage);

            return hotelroomlanguage;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelRoomLanguage> CancelHotelRoomLanguageChanges(ZarenTravelBO.Models.ZarenTravel.HotelRoomLanguage item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnHotelRoomLanguageUpdated(ZarenTravelBO.Models.ZarenTravel.HotelRoomLanguage item);
        partial void OnAfterHotelRoomLanguageUpdated(ZarenTravelBO.Models.ZarenTravel.HotelRoomLanguage item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelRoomLanguage> UpdateHotelRoomLanguage(int id, ZarenTravelBO.Models.ZarenTravel.HotelRoomLanguage hotelroomlanguage)
        {
            OnHotelRoomLanguageUpdated(hotelroomlanguage);

            var itemToUpdate = Context.HotelRoomLanguages
                              .Where(i => i.Id == hotelroomlanguage.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(hotelroomlanguage);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterHotelRoomLanguageUpdated(hotelroomlanguage);

            return hotelroomlanguage;
        }

        partial void OnHotelRoomLanguageDeleted(ZarenTravelBO.Models.ZarenTravel.HotelRoomLanguage item);
        partial void OnAfterHotelRoomLanguageDeleted(ZarenTravelBO.Models.ZarenTravel.HotelRoomLanguage item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelRoomLanguage> DeleteHotelRoomLanguage(int id)
        {
            var itemToDelete = Context.HotelRoomLanguages
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnHotelRoomLanguageDeleted(itemToDelete);


            Context.HotelRoomLanguages.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterHotelRoomLanguageDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportHotelRoomsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/hotelrooms/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/hotelrooms/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportHotelRoomsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/hotelrooms/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/hotelrooms/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnHotelRoomsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.HotelRoom> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.HotelRoom>> GetHotelRooms(Query query = null)
        {
            var items = Context.HotelRooms.AsQueryable();

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

            OnHotelRoomsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnHotelRoomGet(ZarenTravelBO.Models.ZarenTravel.HotelRoom item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelRoom> GetHotelRoomById(int id)
        {
            var items = Context.HotelRooms
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Room);
  
            var itemToReturn = items.FirstOrDefault();

            OnHotelRoomGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnHotelRoomCreated(ZarenTravelBO.Models.ZarenTravel.HotelRoom item);
        partial void OnAfterHotelRoomCreated(ZarenTravelBO.Models.ZarenTravel.HotelRoom item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelRoom> CreateHotelRoom(ZarenTravelBO.Models.ZarenTravel.HotelRoom hotelroom)
        {
            OnHotelRoomCreated(hotelroom);

            var existingItem = Context.HotelRooms
                              .Where(i => i.Id == hotelroom.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.HotelRooms.Add(hotelroom);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(hotelroom).State = EntityState.Detached;
                throw;
            }

            OnAfterHotelRoomCreated(hotelroom);

            return hotelroom;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelRoom> CancelHotelRoomChanges(ZarenTravelBO.Models.ZarenTravel.HotelRoom item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnHotelRoomUpdated(ZarenTravelBO.Models.ZarenTravel.HotelRoom item);
        partial void OnAfterHotelRoomUpdated(ZarenTravelBO.Models.ZarenTravel.HotelRoom item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelRoom> UpdateHotelRoom(int id, ZarenTravelBO.Models.ZarenTravel.HotelRoom hotelroom)
        {
            OnHotelRoomUpdated(hotelroom);

            var itemToUpdate = Context.HotelRooms
                              .Where(i => i.Id == hotelroom.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(hotelroom);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterHotelRoomUpdated(hotelroom);

            return hotelroom;
        }

        partial void OnHotelRoomDeleted(ZarenTravelBO.Models.ZarenTravel.HotelRoom item);
        partial void OnAfterHotelRoomDeleted(ZarenTravelBO.Models.ZarenTravel.HotelRoom item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelRoom> DeleteHotelRoom(int id)
        {
            var itemToDelete = Context.HotelRooms
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnHotelRoomDeleted(itemToDelete);


            Context.HotelRooms.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterHotelRoomDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportHotelsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/hotels/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/hotels/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportHotelsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/hotels/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/hotels/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnHotelsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.Hotel> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.Hotel>> GetHotels(Query query = null)
        {
            var items = Context.Hotels.AsQueryable();

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

            OnHotelsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnHotelGet(ZarenTravelBO.Models.ZarenTravel.Hotel item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Hotel> GetHotelById(int id)
        {
            var items = Context.Hotels
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.City);
                items = items.Include(i => i.Contact);
                items = items.Include(i => i.Country);
                items = items.Include(i => i.Contact1);
                items = items.Include(i => i.HotelChain);
                items = items.Include(i => i.HotelType);
                items = items.Include(i => i.Region);
                items = items.Include(i => i.Contact2);
                items = items.Include(i => i.Zone);
  
            var itemToReturn = items.FirstOrDefault();

            OnHotelGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnHotelCreated(ZarenTravelBO.Models.ZarenTravel.Hotel item);
        partial void OnAfterHotelCreated(ZarenTravelBO.Models.ZarenTravel.Hotel item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Hotel> CreateHotel(ZarenTravelBO.Models.ZarenTravel.Hotel hotel)
        {
            OnHotelCreated(hotel);

            var existingItem = Context.Hotels
                              .Where(i => i.Id == hotel.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Hotels.Add(hotel);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(hotel).State = EntityState.Detached;
                throw;
            }

            OnAfterHotelCreated(hotel);

            return hotel;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.Hotel> CancelHotelChanges(ZarenTravelBO.Models.ZarenTravel.Hotel item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnHotelUpdated(ZarenTravelBO.Models.ZarenTravel.Hotel item);
        partial void OnAfterHotelUpdated(ZarenTravelBO.Models.ZarenTravel.Hotel item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Hotel> UpdateHotel(int id, ZarenTravelBO.Models.ZarenTravel.Hotel hotel)
        {
            OnHotelUpdated(hotel);

            var itemToUpdate = Context.Hotels
                              .Where(i => i.Id == hotel.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(hotel);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterHotelUpdated(hotel);

            return hotel;
        }

        partial void OnHotelDeleted(ZarenTravelBO.Models.ZarenTravel.Hotel item);
        partial void OnAfterHotelDeleted(ZarenTravelBO.Models.ZarenTravel.Hotel item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Hotel> DeleteHotel(int id)
        {
            var itemToDelete = Context.Hotels
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnHotelDeleted(itemToDelete);


            Context.Hotels.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterHotelDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportHotelTypeLanguagesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/hoteltypelanguages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/hoteltypelanguages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportHotelTypeLanguagesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/hoteltypelanguages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/hoteltypelanguages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnHotelTypeLanguagesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.HotelTypeLanguage> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.HotelTypeLanguage>> GetHotelTypeLanguages(Query query = null)
        {
            var items = Context.HotelTypeLanguages.AsQueryable();

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

            OnHotelTypeLanguagesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnHotelTypeLanguageGet(ZarenTravelBO.Models.ZarenTravel.HotelTypeLanguage item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelTypeLanguage> GetHotelTypeLanguageById(int id)
        {
            var items = Context.HotelTypeLanguages
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.HotelType);
                items = items.Include(i => i.Language);
  
            var itemToReturn = items.FirstOrDefault();

            OnHotelTypeLanguageGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnHotelTypeLanguageCreated(ZarenTravelBO.Models.ZarenTravel.HotelTypeLanguage item);
        partial void OnAfterHotelTypeLanguageCreated(ZarenTravelBO.Models.ZarenTravel.HotelTypeLanguage item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelTypeLanguage> CreateHotelTypeLanguage(ZarenTravelBO.Models.ZarenTravel.HotelTypeLanguage hoteltypelanguage)
        {
            OnHotelTypeLanguageCreated(hoteltypelanguage);

            var existingItem = Context.HotelTypeLanguages
                              .Where(i => i.Id == hoteltypelanguage.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.HotelTypeLanguages.Add(hoteltypelanguage);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(hoteltypelanguage).State = EntityState.Detached;
                throw;
            }

            OnAfterHotelTypeLanguageCreated(hoteltypelanguage);

            return hoteltypelanguage;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelTypeLanguage> CancelHotelTypeLanguageChanges(ZarenTravelBO.Models.ZarenTravel.HotelTypeLanguage item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnHotelTypeLanguageUpdated(ZarenTravelBO.Models.ZarenTravel.HotelTypeLanguage item);
        partial void OnAfterHotelTypeLanguageUpdated(ZarenTravelBO.Models.ZarenTravel.HotelTypeLanguage item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelTypeLanguage> UpdateHotelTypeLanguage(int id, ZarenTravelBO.Models.ZarenTravel.HotelTypeLanguage hoteltypelanguage)
        {
            OnHotelTypeLanguageUpdated(hoteltypelanguage);

            var itemToUpdate = Context.HotelTypeLanguages
                              .Where(i => i.Id == hoteltypelanguage.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(hoteltypelanguage);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterHotelTypeLanguageUpdated(hoteltypelanguage);

            return hoteltypelanguage;
        }

        partial void OnHotelTypeLanguageDeleted(ZarenTravelBO.Models.ZarenTravel.HotelTypeLanguage item);
        partial void OnAfterHotelTypeLanguageDeleted(ZarenTravelBO.Models.ZarenTravel.HotelTypeLanguage item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelTypeLanguage> DeleteHotelTypeLanguage(int id)
        {
            var itemToDelete = Context.HotelTypeLanguages
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnHotelTypeLanguageDeleted(itemToDelete);


            Context.HotelTypeLanguages.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterHotelTypeLanguageDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportHotelTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/hoteltypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/hoteltypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportHotelTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/hoteltypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/hoteltypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnHotelTypesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.HotelType> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.HotelType>> GetHotelTypes(Query query = null)
        {
            var items = Context.HotelTypes.AsQueryable();

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

            OnHotelTypesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnHotelTypeGet(ZarenTravelBO.Models.ZarenTravel.HotelType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelType> GetHotelTypeById(int id)
        {
            var items = Context.HotelTypes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnHotelTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnHotelTypeCreated(ZarenTravelBO.Models.ZarenTravel.HotelType item);
        partial void OnAfterHotelTypeCreated(ZarenTravelBO.Models.ZarenTravel.HotelType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelType> CreateHotelType(ZarenTravelBO.Models.ZarenTravel.HotelType hoteltype)
        {
            OnHotelTypeCreated(hoteltype);

            var existingItem = Context.HotelTypes
                              .Where(i => i.Id == hoteltype.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.HotelTypes.Add(hoteltype);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(hoteltype).State = EntityState.Detached;
                throw;
            }

            OnAfterHotelTypeCreated(hoteltype);

            return hoteltype;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelType> CancelHotelTypeChanges(ZarenTravelBO.Models.ZarenTravel.HotelType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnHotelTypeUpdated(ZarenTravelBO.Models.ZarenTravel.HotelType item);
        partial void OnAfterHotelTypeUpdated(ZarenTravelBO.Models.ZarenTravel.HotelType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelType> UpdateHotelType(int id, ZarenTravelBO.Models.ZarenTravel.HotelType hoteltype)
        {
            OnHotelTypeUpdated(hoteltype);

            var itemToUpdate = Context.HotelTypes
                              .Where(i => i.Id == hoteltype.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(hoteltype);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterHotelTypeUpdated(hoteltype);

            return hoteltype;
        }

        partial void OnHotelTypeDeleted(ZarenTravelBO.Models.ZarenTravel.HotelType item);
        partial void OnAfterHotelTypeDeleted(ZarenTravelBO.Models.ZarenTravel.HotelType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.HotelType> DeleteHotelType(int id)
        {
            var itemToDelete = Context.HotelTypes
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnHotelTypeDeleted(itemToDelete);


            Context.HotelTypes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterHotelTypeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportLanguagesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/languages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/languages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportLanguagesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/languages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/languages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnLanguagesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.Language> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.Language>> GetLanguages(Query query = null)
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

        partial void OnLanguageGet(ZarenTravelBO.Models.ZarenTravel.Language item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Language> GetLanguageById(int id)
        {
            var items = Context.Languages
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnLanguageGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnLanguageCreated(ZarenTravelBO.Models.ZarenTravel.Language item);
        partial void OnAfterLanguageCreated(ZarenTravelBO.Models.ZarenTravel.Language item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Language> CreateLanguage(ZarenTravelBO.Models.ZarenTravel.Language language)
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

        public async Task<ZarenTravelBO.Models.ZarenTravel.Language> CancelLanguageChanges(ZarenTravelBO.Models.ZarenTravel.Language item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnLanguageUpdated(ZarenTravelBO.Models.ZarenTravel.Language item);
        partial void OnAfterLanguageUpdated(ZarenTravelBO.Models.ZarenTravel.Language item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Language> UpdateLanguage(int id, ZarenTravelBO.Models.ZarenTravel.Language language)
        {
            OnLanguageUpdated(language);

            var itemToUpdate = Context.Languages
                              .Where(i => i.Id == language.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(language);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterLanguageUpdated(language);

            return language;
        }

        partial void OnLanguageDeleted(ZarenTravelBO.Models.ZarenTravel.Language item);
        partial void OnAfterLanguageDeleted(ZarenTravelBO.Models.ZarenTravel.Language item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Language> DeleteLanguage(int id)
        {
            var itemToDelete = Context.Languages
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnLanguageDeleted(itemToDelete);


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
    
        public async Task ExportLogPermissionsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/logpermissions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/logpermissions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportLogPermissionsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/logpermissions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/logpermissions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnLogPermissionsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.LogPermission> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.LogPermission>> GetLogPermissions(Query query = null)
        {
            var items = Context.LogPermissions.AsQueryable();

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

            OnLogPermissionsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnLogPermissionGet(ZarenTravelBO.Models.ZarenTravel.LogPermission item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.LogPermission> GetLogPermissionById(int id)
        {
            var items = Context.LogPermissions
                              .AsNoTracking()
                              .Where(i => i.ID == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnLogPermissionGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnLogPermissionCreated(ZarenTravelBO.Models.ZarenTravel.LogPermission item);
        partial void OnAfterLogPermissionCreated(ZarenTravelBO.Models.ZarenTravel.LogPermission item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.LogPermission> CreateLogPermission(ZarenTravelBO.Models.ZarenTravel.LogPermission logpermission)
        {
            OnLogPermissionCreated(logpermission);

            var existingItem = Context.LogPermissions
                              .Where(i => i.ID == logpermission.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.LogPermissions.Add(logpermission);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(logpermission).State = EntityState.Detached;
                throw;
            }

            OnAfterLogPermissionCreated(logpermission);

            return logpermission;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.LogPermission> CancelLogPermissionChanges(ZarenTravelBO.Models.ZarenTravel.LogPermission item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnLogPermissionUpdated(ZarenTravelBO.Models.ZarenTravel.LogPermission item);
        partial void OnAfterLogPermissionUpdated(ZarenTravelBO.Models.ZarenTravel.LogPermission item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.LogPermission> UpdateLogPermission(int id, ZarenTravelBO.Models.ZarenTravel.LogPermission logpermission)
        {
            OnLogPermissionUpdated(logpermission);

            var itemToUpdate = Context.LogPermissions
                              .Where(i => i.ID == logpermission.ID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(logpermission);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterLogPermissionUpdated(logpermission);

            return logpermission;
        }

        partial void OnLogPermissionDeleted(ZarenTravelBO.Models.ZarenTravel.LogPermission item);
        partial void OnAfterLogPermissionDeleted(ZarenTravelBO.Models.ZarenTravel.LogPermission item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.LogPermission> DeleteLogPermission(int id)
        {
            var itemToDelete = Context.LogPermissions
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnLogPermissionDeleted(itemToDelete);


            Context.LogPermissions.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterLogPermissionDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportLogsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/logs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/logs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportLogsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/logs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/logs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnLogsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.Log> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.Log>> GetLogs(Query query = null)
        {
            var items = Context.Logs.AsQueryable();

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

            OnLogsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnLogGet(ZarenTravelBO.Models.ZarenTravel.Log item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Log> GetLogById(int id)
        {
            var items = Context.Logs
                              .AsNoTracking()
                              .Where(i => i.ID == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnLogGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnLogCreated(ZarenTravelBO.Models.ZarenTravel.Log item);
        partial void OnAfterLogCreated(ZarenTravelBO.Models.ZarenTravel.Log item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Log> CreateLog(ZarenTravelBO.Models.ZarenTravel.Log log)
        {
            OnLogCreated(log);

            var existingItem = Context.Logs
                              .Where(i => i.ID == log.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Logs.Add(log);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(log).State = EntityState.Detached;
                throw;
            }

            OnAfterLogCreated(log);

            return log;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.Log> CancelLogChanges(ZarenTravelBO.Models.ZarenTravel.Log item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnLogUpdated(ZarenTravelBO.Models.ZarenTravel.Log item);
        partial void OnAfterLogUpdated(ZarenTravelBO.Models.ZarenTravel.Log item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Log> UpdateLog(int id, ZarenTravelBO.Models.ZarenTravel.Log log)
        {
            OnLogUpdated(log);

            var itemToUpdate = Context.Logs
                              .Where(i => i.ID == log.ID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(log);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterLogUpdated(log);

            return log;
        }

        partial void OnLogDeleted(ZarenTravelBO.Models.ZarenTravel.Log item);
        partial void OnAfterLogDeleted(ZarenTravelBO.Models.ZarenTravel.Log item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Log> DeleteLog(int id)
        {
            var itemToDelete = Context.Logs
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnLogDeleted(itemToDelete);


            Context.Logs.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterLogDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportMenusToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/menus/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/menus/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportMenusToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/menus/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/menus/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnMenusRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.Menu> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.Menu>> GetMenus(Query query = null)
        {
            var items = Context.Menus.AsQueryable();

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

            OnMenusRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnMenuGet(ZarenTravelBO.Models.ZarenTravel.Menu item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Menu> GetMenuById(int id)
        {
            var items = Context.Menus
                              .AsNoTracking()
                              .Where(i => i.ID == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnMenuGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnMenuCreated(ZarenTravelBO.Models.ZarenTravel.Menu item);
        partial void OnAfterMenuCreated(ZarenTravelBO.Models.ZarenTravel.Menu item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Menu> CreateMenu(ZarenTravelBO.Models.ZarenTravel.Menu menu)
        {
            OnMenuCreated(menu);

            var existingItem = Context.Menus
                              .Where(i => i.ID == menu.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Menus.Add(menu);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(menu).State = EntityState.Detached;
                throw;
            }

            OnAfterMenuCreated(menu);

            return menu;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.Menu> CancelMenuChanges(ZarenTravelBO.Models.ZarenTravel.Menu item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnMenuUpdated(ZarenTravelBO.Models.ZarenTravel.Menu item);
        partial void OnAfterMenuUpdated(ZarenTravelBO.Models.ZarenTravel.Menu item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Menu> UpdateMenu(int id, ZarenTravelBO.Models.ZarenTravel.Menu menu)
        {
            OnMenuUpdated(menu);

            var itemToUpdate = Context.Menus
                              .Where(i => i.ID == menu.ID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(menu);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterMenuUpdated(menu);

            return menu;
        }

        partial void OnMenuDeleted(ZarenTravelBO.Models.ZarenTravel.Menu item);
        partial void OnAfterMenuDeleted(ZarenTravelBO.Models.ZarenTravel.Menu item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Menu> DeleteMenu(int id)
        {
            var itemToDelete = Context.Menus
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnMenuDeleted(itemToDelete);


            Context.Menus.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterMenuDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportOgSeosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/ogseos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/ogseos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportOgSeosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/ogseos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/ogseos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnOgSeosRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.OgSeo> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.OgSeo>> GetOgSeos(Query query = null)
        {
            var items = Context.OgSeos.AsQueryable();

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

            OnOgSeosRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnOgSeoGet(ZarenTravelBO.Models.ZarenTravel.OgSeo item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.OgSeo> GetOgSeoById(int id)
        {
            var items = Context.OgSeos
                              .AsNoTracking()
                              .Where(i => i.ID == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnOgSeoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnOgSeoCreated(ZarenTravelBO.Models.ZarenTravel.OgSeo item);
        partial void OnAfterOgSeoCreated(ZarenTravelBO.Models.ZarenTravel.OgSeo item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.OgSeo> CreateOgSeo(ZarenTravelBO.Models.ZarenTravel.OgSeo ogseo)
        {
            OnOgSeoCreated(ogseo);

            var existingItem = Context.OgSeos
                              .Where(i => i.ID == ogseo.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.OgSeos.Add(ogseo);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(ogseo).State = EntityState.Detached;
                throw;
            }

            OnAfterOgSeoCreated(ogseo);

            return ogseo;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.OgSeo> CancelOgSeoChanges(ZarenTravelBO.Models.ZarenTravel.OgSeo item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnOgSeoUpdated(ZarenTravelBO.Models.ZarenTravel.OgSeo item);
        partial void OnAfterOgSeoUpdated(ZarenTravelBO.Models.ZarenTravel.OgSeo item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.OgSeo> UpdateOgSeo(int id, ZarenTravelBO.Models.ZarenTravel.OgSeo ogseo)
        {
            OnOgSeoUpdated(ogseo);

            var itemToUpdate = Context.OgSeos
                              .Where(i => i.ID == ogseo.ID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(ogseo);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterOgSeoUpdated(ogseo);

            return ogseo;
        }

        partial void OnOgSeoDeleted(ZarenTravelBO.Models.ZarenTravel.OgSeo item);
        partial void OnAfterOgSeoDeleted(ZarenTravelBO.Models.ZarenTravel.OgSeo item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.OgSeo> DeleteOgSeo(int id)
        {
            var itemToDelete = Context.OgSeos
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnOgSeoDeleted(itemToDelete);


            Context.OgSeos.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterOgSeoDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportPageContentsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/pagecontents/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/pagecontents/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPageContentsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/pagecontents/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/pagecontents/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPageContentsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.PageContent> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.PageContent>> GetPageContents(Query query = null)
        {
            var items = Context.PageContents.AsQueryable();

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

            OnPageContentsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnPageContentGet(ZarenTravelBO.Models.ZarenTravel.PageContent item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.PageContent> GetPageContentById(int id)
        {
            var items = Context.PageContents
                              .AsNoTracking()
                              .Where(i => i.ID == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnPageContentGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnPageContentCreated(ZarenTravelBO.Models.ZarenTravel.PageContent item);
        partial void OnAfterPageContentCreated(ZarenTravelBO.Models.ZarenTravel.PageContent item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.PageContent> CreatePageContent(ZarenTravelBO.Models.ZarenTravel.PageContent pagecontent)
        {
            OnPageContentCreated(pagecontent);

            var existingItem = Context.PageContents
                              .Where(i => i.ID == pagecontent.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.PageContents.Add(pagecontent);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(pagecontent).State = EntityState.Detached;
                throw;
            }

            OnAfterPageContentCreated(pagecontent);

            return pagecontent;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.PageContent> CancelPageContentChanges(ZarenTravelBO.Models.ZarenTravel.PageContent item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnPageContentUpdated(ZarenTravelBO.Models.ZarenTravel.PageContent item);
        partial void OnAfterPageContentUpdated(ZarenTravelBO.Models.ZarenTravel.PageContent item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.PageContent> UpdatePageContent(int id, ZarenTravelBO.Models.ZarenTravel.PageContent pagecontent)
        {
            OnPageContentUpdated(pagecontent);

            var itemToUpdate = Context.PageContents
                              .Where(i => i.ID == pagecontent.ID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(pagecontent);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterPageContentUpdated(pagecontent);

            return pagecontent;
        }

        partial void OnPageContentDeleted(ZarenTravelBO.Models.ZarenTravel.PageContent item);
        partial void OnAfterPageContentDeleted(ZarenTravelBO.Models.ZarenTravel.PageContent item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.PageContent> DeletePageContent(int id)
        {
            var itemToDelete = Context.PageContents
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnPageContentDeleted(itemToDelete);


            Context.PageContents.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterPageContentDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportPageTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/pagetypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/pagetypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPageTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/pagetypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/pagetypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPageTypesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.PageType> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.PageType>> GetPageTypes(Query query = null)
        {
            var items = Context.PageTypes.AsQueryable();

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

            OnPageTypesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnPageTypeGet(ZarenTravelBO.Models.ZarenTravel.PageType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.PageType> GetPageTypeById(int id)
        {
            var items = Context.PageTypes
                              .AsNoTracking()
                              .Where(i => i.ID == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnPageTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnPageTypeCreated(ZarenTravelBO.Models.ZarenTravel.PageType item);
        partial void OnAfterPageTypeCreated(ZarenTravelBO.Models.ZarenTravel.PageType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.PageType> CreatePageType(ZarenTravelBO.Models.ZarenTravel.PageType pagetype)
        {
            OnPageTypeCreated(pagetype);

            var existingItem = Context.PageTypes
                              .Where(i => i.ID == pagetype.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.PageTypes.Add(pagetype);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(pagetype).State = EntityState.Detached;
                throw;
            }

            OnAfterPageTypeCreated(pagetype);

            return pagetype;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.PageType> CancelPageTypeChanges(ZarenTravelBO.Models.ZarenTravel.PageType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnPageTypeUpdated(ZarenTravelBO.Models.ZarenTravel.PageType item);
        partial void OnAfterPageTypeUpdated(ZarenTravelBO.Models.ZarenTravel.PageType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.PageType> UpdatePageType(int id, ZarenTravelBO.Models.ZarenTravel.PageType pagetype)
        {
            OnPageTypeUpdated(pagetype);

            var itemToUpdate = Context.PageTypes
                              .Where(i => i.ID == pagetype.ID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(pagetype);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterPageTypeUpdated(pagetype);

            return pagetype;
        }

        partial void OnPageTypeDeleted(ZarenTravelBO.Models.ZarenTravel.PageType item);
        partial void OnAfterPageTypeDeleted(ZarenTravelBO.Models.ZarenTravel.PageType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.PageType> DeletePageType(int id)
        {
            var itemToDelete = Context.PageTypes
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnPageTypeDeleted(itemToDelete);


            Context.PageTypes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterPageTypeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportPassengerInformationsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/passengerinformations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/passengerinformations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPassengerInformationsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/passengerinformations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/passengerinformations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPassengerInformationsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.PassengerInformation> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.PassengerInformation>> GetPassengerInformations(Query query = null)
        {
            var items = Context.PassengerInformations.AsQueryable();

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

            OnPassengerInformationsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnPassengerInformationGet(ZarenTravelBO.Models.ZarenTravel.PassengerInformation item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.PassengerInformation> GetPassengerInformationByIdAndPnr(int id, string pnr)
        {
            var items = Context.PassengerInformations
                              .AsNoTracking()
                              .Where(i => i.Id == id && i.Pnr == pnr);

  
            var itemToReturn = items.FirstOrDefault();

            OnPassengerInformationGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnPassengerInformationCreated(ZarenTravelBO.Models.ZarenTravel.PassengerInformation item);
        partial void OnAfterPassengerInformationCreated(ZarenTravelBO.Models.ZarenTravel.PassengerInformation item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.PassengerInformation> CreatePassengerInformation(ZarenTravelBO.Models.ZarenTravel.PassengerInformation passengerinformation)
        {
            OnPassengerInformationCreated(passengerinformation);

            var existingItem = Context.PassengerInformations
                              .Where(i => i.Id == passengerinformation.Id && i.Pnr == passengerinformation.Pnr)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.PassengerInformations.Add(passengerinformation);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(passengerinformation).State = EntityState.Detached;
                throw;
            }

            OnAfterPassengerInformationCreated(passengerinformation);

            return passengerinformation;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.PassengerInformation> CancelPassengerInformationChanges(ZarenTravelBO.Models.ZarenTravel.PassengerInformation item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnPassengerInformationUpdated(ZarenTravelBO.Models.ZarenTravel.PassengerInformation item);
        partial void OnAfterPassengerInformationUpdated(ZarenTravelBO.Models.ZarenTravel.PassengerInformation item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.PassengerInformation> UpdatePassengerInformation(int id, string pnr, ZarenTravelBO.Models.ZarenTravel.PassengerInformation passengerinformation)
        {
            OnPassengerInformationUpdated(passengerinformation);

            var itemToUpdate = Context.PassengerInformations
                              .Where(i => i.Id == passengerinformation.Id && i.Pnr == passengerinformation.Pnr)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(passengerinformation);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterPassengerInformationUpdated(passengerinformation);

            return passengerinformation;
        }

        partial void OnPassengerInformationDeleted(ZarenTravelBO.Models.ZarenTravel.PassengerInformation item);
        partial void OnAfterPassengerInformationDeleted(ZarenTravelBO.Models.ZarenTravel.PassengerInformation item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.PassengerInformation> DeletePassengerInformation(int id, string pnr)
        {
            var itemToDelete = Context.PassengerInformations
                              .Where(i => i.Id == id && i.Pnr == pnr)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnPassengerInformationDeleted(itemToDelete);


            Context.PassengerInformations.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterPassengerInformationDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportPassengersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/passengers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/passengers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPassengersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/passengers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/passengers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPassengersRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.Passenger> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.Passenger>> GetPassengers(Query query = null)
        {
            var items = Context.Passengers.AsQueryable();

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

            OnPassengersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnPassengerGet(ZarenTravelBO.Models.ZarenTravel.Passenger item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Passenger> GetPassengerById(int id)
        {
            var items = Context.Passengers
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnPassengerGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnPassengerCreated(ZarenTravelBO.Models.ZarenTravel.Passenger item);
        partial void OnAfterPassengerCreated(ZarenTravelBO.Models.ZarenTravel.Passenger item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Passenger> CreatePassenger(ZarenTravelBO.Models.ZarenTravel.Passenger passenger)
        {
            OnPassengerCreated(passenger);

            var existingItem = Context.Passengers
                              .Where(i => i.Id == passenger.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Passengers.Add(passenger);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(passenger).State = EntityState.Detached;
                throw;
            }

            OnAfterPassengerCreated(passenger);

            return passenger;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.Passenger> CancelPassengerChanges(ZarenTravelBO.Models.ZarenTravel.Passenger item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnPassengerUpdated(ZarenTravelBO.Models.ZarenTravel.Passenger item);
        partial void OnAfterPassengerUpdated(ZarenTravelBO.Models.ZarenTravel.Passenger item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Passenger> UpdatePassenger(int id, ZarenTravelBO.Models.ZarenTravel.Passenger passenger)
        {
            OnPassengerUpdated(passenger);

            var itemToUpdate = Context.Passengers
                              .Where(i => i.Id == passenger.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(passenger);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterPassengerUpdated(passenger);

            return passenger;
        }

        partial void OnPassengerDeleted(ZarenTravelBO.Models.ZarenTravel.Passenger item);
        partial void OnAfterPassengerDeleted(ZarenTravelBO.Models.ZarenTravel.Passenger item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Passenger> DeletePassenger(int id)
        {
            var itemToDelete = Context.Passengers
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnPassengerDeleted(itemToDelete);


            Context.Passengers.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterPassengerDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportPnrCustomFieldsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/pnrcustomfields/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/pnrcustomfields/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPnrCustomFieldsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/pnrcustomfields/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/pnrcustomfields/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPnrCustomFieldsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.PnrCustomField> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.PnrCustomField>> GetPnrCustomFields(Query query = null)
        {
            var items = Context.PnrCustomFields.AsQueryable();

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

            OnPnrCustomFieldsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnPnrCustomFieldGet(ZarenTravelBO.Models.ZarenTravel.PnrCustomField item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.PnrCustomField> GetPnrCustomFieldById(int id)
        {
            var items = Context.PnrCustomFields
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.FieldsType);
  
            var itemToReturn = items.FirstOrDefault();

            OnPnrCustomFieldGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnPnrCustomFieldCreated(ZarenTravelBO.Models.ZarenTravel.PnrCustomField item);
        partial void OnAfterPnrCustomFieldCreated(ZarenTravelBO.Models.ZarenTravel.PnrCustomField item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.PnrCustomField> CreatePnrCustomField(ZarenTravelBO.Models.ZarenTravel.PnrCustomField pnrcustomfield)
        {
            OnPnrCustomFieldCreated(pnrcustomfield);

            var existingItem = Context.PnrCustomFields
                              .Where(i => i.Id == pnrcustomfield.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.PnrCustomFields.Add(pnrcustomfield);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(pnrcustomfield).State = EntityState.Detached;
                throw;
            }

            OnAfterPnrCustomFieldCreated(pnrcustomfield);

            return pnrcustomfield;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.PnrCustomField> CancelPnrCustomFieldChanges(ZarenTravelBO.Models.ZarenTravel.PnrCustomField item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnPnrCustomFieldUpdated(ZarenTravelBO.Models.ZarenTravel.PnrCustomField item);
        partial void OnAfterPnrCustomFieldUpdated(ZarenTravelBO.Models.ZarenTravel.PnrCustomField item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.PnrCustomField> UpdatePnrCustomField(int id, ZarenTravelBO.Models.ZarenTravel.PnrCustomField pnrcustomfield)
        {
            OnPnrCustomFieldUpdated(pnrcustomfield);

            var itemToUpdate = Context.PnrCustomFields
                              .Where(i => i.Id == pnrcustomfield.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(pnrcustomfield);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterPnrCustomFieldUpdated(pnrcustomfield);

            return pnrcustomfield;
        }

        partial void OnPnrCustomFieldDeleted(ZarenTravelBO.Models.ZarenTravel.PnrCustomField item);
        partial void OnAfterPnrCustomFieldDeleted(ZarenTravelBO.Models.ZarenTravel.PnrCustomField item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.PnrCustomField> DeletePnrCustomField(int id)
        {
            var itemToDelete = Context.PnrCustomFields
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnPnrCustomFieldDeleted(itemToDelete);


            Context.PnrCustomFields.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterPnrCustomFieldDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportPnRsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/pnrs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/pnrs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPnRsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/pnrs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/pnrs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPnRsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.PnR> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.PnR>> GetPnRs(Query query = null)
        {
            var items = Context.PnRs.AsQueryable();

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

            OnPnRsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnPnRGet(ZarenTravelBO.Models.ZarenTravel.PnR item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.PnR> GetPnRById(int id)
        {
            var items = Context.PnRs
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Agency);
                items = items.Include(i => i.Company);
                items = items.Include(i => i.Passenger);
  
            var itemToReturn = items.FirstOrDefault();

            OnPnRGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnPnRCreated(ZarenTravelBO.Models.ZarenTravel.PnR item);
        partial void OnAfterPnRCreated(ZarenTravelBO.Models.ZarenTravel.PnR item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.PnR> CreatePnR(ZarenTravelBO.Models.ZarenTravel.PnR pnr)
        {
            OnPnRCreated(pnr);

            var existingItem = Context.PnRs
                              .Where(i => i.Id == pnr.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.PnRs.Add(pnr);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(pnr).State = EntityState.Detached;
                throw;
            }

            OnAfterPnRCreated(pnr);

            return pnr;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.PnR> CancelPnRChanges(ZarenTravelBO.Models.ZarenTravel.PnR item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnPnRUpdated(ZarenTravelBO.Models.ZarenTravel.PnR item);
        partial void OnAfterPnRUpdated(ZarenTravelBO.Models.ZarenTravel.PnR item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.PnR> UpdatePnR(int id, ZarenTravelBO.Models.ZarenTravel.PnR pnr)
        {
            OnPnRUpdated(pnr);

            var itemToUpdate = Context.PnRs
                              .Where(i => i.Id == pnr.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(pnr);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterPnRUpdated(pnr);

            return pnr;
        }

        partial void OnPnRDeleted(ZarenTravelBO.Models.ZarenTravel.PnR item);
        partial void OnAfterPnRDeleted(ZarenTravelBO.Models.ZarenTravel.PnR item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.PnR> DeletePnR(int id)
        {
            var itemToDelete = Context.PnRs
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnPnRDeleted(itemToDelete);


            Context.PnRs.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterPnRDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportPossibleQueriesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/possiblequeries/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/possiblequeries/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPossibleQueriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/possiblequeries/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/possiblequeries/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPossibleQueriesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.PossibleQuery> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.PossibleQuery>> GetPossibleQueries(Query query = null)
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

        partial void OnPossibleQueryGet(ZarenTravelBO.Models.ZarenTravel.PossibleQuery item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.PossibleQuery> GetPossibleQueryById(int id)
        {
            var items = Context.PossibleQueries
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnPossibleQueryGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnPossibleQueryCreated(ZarenTravelBO.Models.ZarenTravel.PossibleQuery item);
        partial void OnAfterPossibleQueryCreated(ZarenTravelBO.Models.ZarenTravel.PossibleQuery item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.PossibleQuery> CreatePossibleQuery(ZarenTravelBO.Models.ZarenTravel.PossibleQuery possiblequery)
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

        public async Task<ZarenTravelBO.Models.ZarenTravel.PossibleQuery> CancelPossibleQueryChanges(ZarenTravelBO.Models.ZarenTravel.PossibleQuery item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnPossibleQueryUpdated(ZarenTravelBO.Models.ZarenTravel.PossibleQuery item);
        partial void OnAfterPossibleQueryUpdated(ZarenTravelBO.Models.ZarenTravel.PossibleQuery item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.PossibleQuery> UpdatePossibleQuery(int id, ZarenTravelBO.Models.ZarenTravel.PossibleQuery possiblequery)
        {
            OnPossibleQueryUpdated(possiblequery);

            var itemToUpdate = Context.PossibleQueries
                              .Where(i => i.Id == possiblequery.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(possiblequery);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterPossibleQueryUpdated(possiblequery);

            return possiblequery;
        }

        partial void OnPossibleQueryDeleted(ZarenTravelBO.Models.ZarenTravel.PossibleQuery item);
        partial void OnAfterPossibleQueryDeleted(ZarenTravelBO.Models.ZarenTravel.PossibleQuery item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.PossibleQuery> DeletePossibleQuery(int id)
        {
            var itemToDelete = Context.PossibleQueries
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnPossibleQueryDeleted(itemToDelete);


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
    
        public async Task ExportProvidersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/providers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/providers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportProvidersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/providers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/providers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnProvidersRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.Provider> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.Provider>> GetProviders(Query query = null)
        {
            var items = Context.Providers.AsQueryable();

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

            OnProvidersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnProviderGet(ZarenTravelBO.Models.ZarenTravel.Provider item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Provider> GetProviderById(int id)
        {
            var items = Context.Providers
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Contact);
                items = items.Include(i => i.Contact1);
                items = items.Include(i => i.Contact2);
  
            var itemToReturn = items.FirstOrDefault();

            OnProviderGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnProviderCreated(ZarenTravelBO.Models.ZarenTravel.Provider item);
        partial void OnAfterProviderCreated(ZarenTravelBO.Models.ZarenTravel.Provider item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Provider> CreateProvider(ZarenTravelBO.Models.ZarenTravel.Provider provider)
        {
            OnProviderCreated(provider);

            var existingItem = Context.Providers
                              .Where(i => i.Id == provider.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Providers.Add(provider);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(provider).State = EntityState.Detached;
                throw;
            }

            OnAfterProviderCreated(provider);

            return provider;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.Provider> CancelProviderChanges(ZarenTravelBO.Models.ZarenTravel.Provider item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnProviderUpdated(ZarenTravelBO.Models.ZarenTravel.Provider item);
        partial void OnAfterProviderUpdated(ZarenTravelBO.Models.ZarenTravel.Provider item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Provider> UpdateProvider(int id, ZarenTravelBO.Models.ZarenTravel.Provider provider)
        {
            OnProviderUpdated(provider);

            var itemToUpdate = Context.Providers
                              .Where(i => i.Id == provider.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(provider);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterProviderUpdated(provider);

            return provider;
        }

        partial void OnProviderDeleted(ZarenTravelBO.Models.ZarenTravel.Provider item);
        partial void OnAfterProviderDeleted(ZarenTravelBO.Models.ZarenTravel.Provider item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Provider> DeleteProvider(int id)
        {
            var itemToDelete = Context.Providers
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnProviderDeleted(itemToDelete);


            Context.Providers.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterProviderDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportProviencesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/proviences/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/proviences/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportProviencesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/proviences/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/proviences/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnProviencesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.Provience> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.Provience>> GetProviences(Query query = null)
        {
            var items = Context.Proviences.AsQueryable();

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

            OnProviencesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnProvienceGet(ZarenTravelBO.Models.ZarenTravel.Provience item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Provience> GetProvienceById(int id)
        {
            var items = Context.Proviences
                              .AsNoTracking()
                              .Where(i => i.ID == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnProvienceGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnProvienceCreated(ZarenTravelBO.Models.ZarenTravel.Provience item);
        partial void OnAfterProvienceCreated(ZarenTravelBO.Models.ZarenTravel.Provience item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Provience> CreateProvience(ZarenTravelBO.Models.ZarenTravel.Provience provience)
        {
            OnProvienceCreated(provience);

            var existingItem = Context.Proviences
                              .Where(i => i.ID == provience.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Proviences.Add(provience);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(provience).State = EntityState.Detached;
                throw;
            }

            OnAfterProvienceCreated(provience);

            return provience;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.Provience> CancelProvienceChanges(ZarenTravelBO.Models.ZarenTravel.Provience item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnProvienceUpdated(ZarenTravelBO.Models.ZarenTravel.Provience item);
        partial void OnAfterProvienceUpdated(ZarenTravelBO.Models.ZarenTravel.Provience item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Provience> UpdateProvience(int id, ZarenTravelBO.Models.ZarenTravel.Provience provience)
        {
            OnProvienceUpdated(provience);

            var itemToUpdate = Context.Proviences
                              .Where(i => i.ID == provience.ID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(provience);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterProvienceUpdated(provience);

            return provience;
        }

        partial void OnProvienceDeleted(ZarenTravelBO.Models.ZarenTravel.Provience item);
        partial void OnAfterProvienceDeleted(ZarenTravelBO.Models.ZarenTravel.Provience item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Provience> DeleteProvience(int id)
        {
            var itemToDelete = Context.Proviences
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnProvienceDeleted(itemToDelete);


            Context.Proviences.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterProvienceDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportRegionsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/regions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/regions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportRegionsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/regions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/regions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnRegionsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.Region> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.Region>> GetRegions(Query query = null)
        {
            var items = Context.Regions.AsQueryable();

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

            OnRegionsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnRegionGet(ZarenTravelBO.Models.ZarenTravel.Region item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Region> GetRegionById(int id)
        {
            var items = Context.Regions
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnRegionGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnRegionCreated(ZarenTravelBO.Models.ZarenTravel.Region item);
        partial void OnAfterRegionCreated(ZarenTravelBO.Models.ZarenTravel.Region item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Region> CreateRegion(ZarenTravelBO.Models.ZarenTravel.Region region)
        {
            OnRegionCreated(region);

            var existingItem = Context.Regions
                              .Where(i => i.Id == region.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Regions.Add(region);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(region).State = EntityState.Detached;
                throw;
            }

            OnAfterRegionCreated(region);

            return region;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.Region> CancelRegionChanges(ZarenTravelBO.Models.ZarenTravel.Region item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnRegionUpdated(ZarenTravelBO.Models.ZarenTravel.Region item);
        partial void OnAfterRegionUpdated(ZarenTravelBO.Models.ZarenTravel.Region item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Region> UpdateRegion(int id, ZarenTravelBO.Models.ZarenTravel.Region region)
        {
            OnRegionUpdated(region);

            var itemToUpdate = Context.Regions
                              .Where(i => i.Id == region.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(region);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterRegionUpdated(region);

            return region;
        }

        partial void OnRegionDeleted(ZarenTravelBO.Models.ZarenTravel.Region item);
        partial void OnAfterRegionDeleted(ZarenTravelBO.Models.ZarenTravel.Region item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Region> DeleteRegion(int id)
        {
            var itemToDelete = Context.Regions
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnRegionDeleted(itemToDelete);


            Context.Regions.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterRegionDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportReservationDetailsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/reservationdetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/reservationdetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportReservationDetailsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/reservationdetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/reservationdetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnReservationDetailsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.ReservationDetail> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.ReservationDetail>> GetReservationDetails(Query query = null)
        {
            var items = Context.ReservationDetails.AsQueryable();

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

            OnReservationDetailsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnReservationDetailGet(ZarenTravelBO.Models.ZarenTravel.ReservationDetail item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.ReservationDetail> GetReservationDetailById(int id)
        {
            var items = Context.ReservationDetails
                              .AsNoTracking()
                              .Where(i => i.ID == id);

                items = items.Include(i => i.Reservation);
  
            var itemToReturn = items.FirstOrDefault();

            OnReservationDetailGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnReservationDetailCreated(ZarenTravelBO.Models.ZarenTravel.ReservationDetail item);
        partial void OnAfterReservationDetailCreated(ZarenTravelBO.Models.ZarenTravel.ReservationDetail item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.ReservationDetail> CreateReservationDetail(ZarenTravelBO.Models.ZarenTravel.ReservationDetail reservationdetail)
        {
            OnReservationDetailCreated(reservationdetail);

            var existingItem = Context.ReservationDetails
                              .Where(i => i.ID == reservationdetail.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ReservationDetails.Add(reservationdetail);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(reservationdetail).State = EntityState.Detached;
                throw;
            }

            OnAfterReservationDetailCreated(reservationdetail);

            return reservationdetail;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.ReservationDetail> CancelReservationDetailChanges(ZarenTravelBO.Models.ZarenTravel.ReservationDetail item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnReservationDetailUpdated(ZarenTravelBO.Models.ZarenTravel.ReservationDetail item);
        partial void OnAfterReservationDetailUpdated(ZarenTravelBO.Models.ZarenTravel.ReservationDetail item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.ReservationDetail> UpdateReservationDetail(int id, ZarenTravelBO.Models.ZarenTravel.ReservationDetail reservationdetail)
        {
            OnReservationDetailUpdated(reservationdetail);

            var itemToUpdate = Context.ReservationDetails
                              .Where(i => i.ID == reservationdetail.ID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(reservationdetail);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterReservationDetailUpdated(reservationdetail);

            return reservationdetail;
        }

        partial void OnReservationDetailDeleted(ZarenTravelBO.Models.ZarenTravel.ReservationDetail item);
        partial void OnAfterReservationDetailDeleted(ZarenTravelBO.Models.ZarenTravel.ReservationDetail item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.ReservationDetail> DeleteReservationDetail(int id)
        {
            var itemToDelete = Context.ReservationDetails
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnReservationDetailDeleted(itemToDelete);


            Context.ReservationDetails.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterReservationDetailDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportReservationsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/reservations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/reservations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportReservationsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/reservations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/reservations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnReservationsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.Reservation> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.Reservation>> GetReservations(Query query = null)
        {
            var items = Context.Reservations.AsQueryable();

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

            OnReservationsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnReservationGet(ZarenTravelBO.Models.ZarenTravel.Reservation item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Reservation> GetReservationById(int id)
        {
            var items = Context.Reservations
                              .AsNoTracking()
                              .Where(i => i.ID == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnReservationGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnReservationCreated(ZarenTravelBO.Models.ZarenTravel.Reservation item);
        partial void OnAfterReservationCreated(ZarenTravelBO.Models.ZarenTravel.Reservation item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Reservation> CreateReservation(ZarenTravelBO.Models.ZarenTravel.Reservation reservation)
        {
            OnReservationCreated(reservation);

            var existingItem = Context.Reservations
                              .Where(i => i.ID == reservation.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Reservations.Add(reservation);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(reservation).State = EntityState.Detached;
                throw;
            }

            OnAfterReservationCreated(reservation);

            return reservation;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.Reservation> CancelReservationChanges(ZarenTravelBO.Models.ZarenTravel.Reservation item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnReservationUpdated(ZarenTravelBO.Models.ZarenTravel.Reservation item);
        partial void OnAfterReservationUpdated(ZarenTravelBO.Models.ZarenTravel.Reservation item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Reservation> UpdateReservation(int id, ZarenTravelBO.Models.ZarenTravel.Reservation reservation)
        {
            OnReservationUpdated(reservation);

            var itemToUpdate = Context.Reservations
                              .Where(i => i.ID == reservation.ID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(reservation);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterReservationUpdated(reservation);

            return reservation;
        }

        partial void OnReservationDeleted(ZarenTravelBO.Models.ZarenTravel.Reservation item);
        partial void OnAfterReservationDeleted(ZarenTravelBO.Models.ZarenTravel.Reservation item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Reservation> DeleteReservation(int id)
        {
            var itemToDelete = Context.Reservations
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnReservationDeleted(itemToDelete);


            Context.Reservations.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterReservationDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportRoomsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/rooms/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/rooms/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportRoomsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/rooms/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/rooms/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnRoomsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.Room> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.Room>> GetRooms(Query query = null)
        {
            var items = Context.Rooms.AsQueryable();

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

            OnRoomsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnRoomGet(ZarenTravelBO.Models.ZarenTravel.Room item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Room> GetRoomById(int id)
        {
            var items = Context.Rooms
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnRoomGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnRoomCreated(ZarenTravelBO.Models.ZarenTravel.Room item);
        partial void OnAfterRoomCreated(ZarenTravelBO.Models.ZarenTravel.Room item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Room> CreateRoom(ZarenTravelBO.Models.ZarenTravel.Room room)
        {
            OnRoomCreated(room);

            var existingItem = Context.Rooms
                              .Where(i => i.Id == room.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Rooms.Add(room);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(room).State = EntityState.Detached;
                throw;
            }

            OnAfterRoomCreated(room);

            return room;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.Room> CancelRoomChanges(ZarenTravelBO.Models.ZarenTravel.Room item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnRoomUpdated(ZarenTravelBO.Models.ZarenTravel.Room item);
        partial void OnAfterRoomUpdated(ZarenTravelBO.Models.ZarenTravel.Room item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Room> UpdateRoom(int id, ZarenTravelBO.Models.ZarenTravel.Room room)
        {
            OnRoomUpdated(room);

            var itemToUpdate = Context.Rooms
                              .Where(i => i.Id == room.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(room);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterRoomUpdated(room);

            return room;
        }

        partial void OnRoomDeleted(ZarenTravelBO.Models.ZarenTravel.Room item);
        partial void OnAfterRoomDeleted(ZarenTravelBO.Models.ZarenTravel.Room item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Room> DeleteRoom(int id)
        {
            var itemToDelete = Context.Rooms
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnRoomDeleted(itemToDelete);


            Context.Rooms.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterRoomDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportStatusesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/statuses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/statuses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportStatusesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/statuses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/statuses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnStatusesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.Status> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.Status>> GetStatuses(Query query = null)
        {
            var items = Context.Statuses.AsQueryable();

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

            OnStatusesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnStatusGet(ZarenTravelBO.Models.ZarenTravel.Status item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Status> GetStatusById(int id)
        {
            var items = Context.Statuses
                              .AsNoTracking()
                              .Where(i => i.ID == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnStatusGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnStatusCreated(ZarenTravelBO.Models.ZarenTravel.Status item);
        partial void OnAfterStatusCreated(ZarenTravelBO.Models.ZarenTravel.Status item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Status> CreateStatus(ZarenTravelBO.Models.ZarenTravel.Status status)
        {
            OnStatusCreated(status);

            var existingItem = Context.Statuses
                              .Where(i => i.ID == status.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Statuses.Add(status);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(status).State = EntityState.Detached;
                throw;
            }

            OnAfterStatusCreated(status);

            return status;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.Status> CancelStatusChanges(ZarenTravelBO.Models.ZarenTravel.Status item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnStatusUpdated(ZarenTravelBO.Models.ZarenTravel.Status item);
        partial void OnAfterStatusUpdated(ZarenTravelBO.Models.ZarenTravel.Status item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Status> UpdateStatus(int id, ZarenTravelBO.Models.ZarenTravel.Status status)
        {
            OnStatusUpdated(status);

            var itemToUpdate = Context.Statuses
                              .Where(i => i.ID == status.ID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(status);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterStatusUpdated(status);

            return status;
        }

        partial void OnStatusDeleted(ZarenTravelBO.Models.ZarenTravel.Status item);
        partial void OnAfterStatusDeleted(ZarenTravelBO.Models.ZarenTravel.Status item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Status> DeleteStatus(int id)
        {
            var itemToDelete = Context.Statuses
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnStatusDeleted(itemToDelete);


            Context.Statuses.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterStatusDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportSupplierBuyingDestinationsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/supplierbuyingdestinations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/supplierbuyingdestinations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportSupplierBuyingDestinationsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/supplierbuyingdestinations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/supplierbuyingdestinations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnSupplierBuyingDestinationsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.SupplierBuyingDestination> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.SupplierBuyingDestination>> GetSupplierBuyingDestinations(Query query = null)
        {
            var items = Context.SupplierBuyingDestinations.AsQueryable();

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

            OnSupplierBuyingDestinationsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnSupplierBuyingDestinationGet(ZarenTravelBO.Models.ZarenTravel.SupplierBuyingDestination item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.SupplierBuyingDestination> GetSupplierBuyingDestinationById(int id)
        {
            var items = Context.SupplierBuyingDestinations
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Supplier);
  
            var itemToReturn = items.FirstOrDefault();

            OnSupplierBuyingDestinationGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnSupplierBuyingDestinationCreated(ZarenTravelBO.Models.ZarenTravel.SupplierBuyingDestination item);
        partial void OnAfterSupplierBuyingDestinationCreated(ZarenTravelBO.Models.ZarenTravel.SupplierBuyingDestination item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.SupplierBuyingDestination> CreateSupplierBuyingDestination(ZarenTravelBO.Models.ZarenTravel.SupplierBuyingDestination supplierbuyingdestination)
        {
            OnSupplierBuyingDestinationCreated(supplierbuyingdestination);

            var existingItem = Context.SupplierBuyingDestinations
                              .Where(i => i.Id == supplierbuyingdestination.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.SupplierBuyingDestinations.Add(supplierbuyingdestination);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(supplierbuyingdestination).State = EntityState.Detached;
                throw;
            }

            OnAfterSupplierBuyingDestinationCreated(supplierbuyingdestination);

            return supplierbuyingdestination;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.SupplierBuyingDestination> CancelSupplierBuyingDestinationChanges(ZarenTravelBO.Models.ZarenTravel.SupplierBuyingDestination item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnSupplierBuyingDestinationUpdated(ZarenTravelBO.Models.ZarenTravel.SupplierBuyingDestination item);
        partial void OnAfterSupplierBuyingDestinationUpdated(ZarenTravelBO.Models.ZarenTravel.SupplierBuyingDestination item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.SupplierBuyingDestination> UpdateSupplierBuyingDestination(int id, ZarenTravelBO.Models.ZarenTravel.SupplierBuyingDestination supplierbuyingdestination)
        {
            OnSupplierBuyingDestinationUpdated(supplierbuyingdestination);

            var itemToUpdate = Context.SupplierBuyingDestinations
                              .Where(i => i.Id == supplierbuyingdestination.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(supplierbuyingdestination);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterSupplierBuyingDestinationUpdated(supplierbuyingdestination);

            return supplierbuyingdestination;
        }

        partial void OnSupplierBuyingDestinationDeleted(ZarenTravelBO.Models.ZarenTravel.SupplierBuyingDestination item);
        partial void OnAfterSupplierBuyingDestinationDeleted(ZarenTravelBO.Models.ZarenTravel.SupplierBuyingDestination item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.SupplierBuyingDestination> DeleteSupplierBuyingDestination(int id)
        {
            var itemToDelete = Context.SupplierBuyingDestinations
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnSupplierBuyingDestinationDeleted(itemToDelete);


            Context.SupplierBuyingDestinations.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterSupplierBuyingDestinationDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportSupplierFeesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/supplierfees/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/supplierfees/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportSupplierFeesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/supplierfees/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/supplierfees/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnSupplierFeesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.SupplierFee> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.SupplierFee>> GetSupplierFees(Query query = null)
        {
            var items = Context.SupplierFees.AsQueryable();

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

            OnSupplierFeesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnSupplierFeeGet(ZarenTravelBO.Models.ZarenTravel.SupplierFee item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.SupplierFee> GetSupplierFeeById(int id)
        {
            var items = Context.SupplierFees
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Supplier);
  
            var itemToReturn = items.FirstOrDefault();

            OnSupplierFeeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnSupplierFeeCreated(ZarenTravelBO.Models.ZarenTravel.SupplierFee item);
        partial void OnAfterSupplierFeeCreated(ZarenTravelBO.Models.ZarenTravel.SupplierFee item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.SupplierFee> CreateSupplierFee(ZarenTravelBO.Models.ZarenTravel.SupplierFee supplierfee)
        {
            OnSupplierFeeCreated(supplierfee);

            var existingItem = Context.SupplierFees
                              .Where(i => i.Id == supplierfee.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.SupplierFees.Add(supplierfee);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(supplierfee).State = EntityState.Detached;
                throw;
            }

            OnAfterSupplierFeeCreated(supplierfee);

            return supplierfee;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.SupplierFee> CancelSupplierFeeChanges(ZarenTravelBO.Models.ZarenTravel.SupplierFee item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnSupplierFeeUpdated(ZarenTravelBO.Models.ZarenTravel.SupplierFee item);
        partial void OnAfterSupplierFeeUpdated(ZarenTravelBO.Models.ZarenTravel.SupplierFee item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.SupplierFee> UpdateSupplierFee(int id, ZarenTravelBO.Models.ZarenTravel.SupplierFee supplierfee)
        {
            OnSupplierFeeUpdated(supplierfee);

            var itemToUpdate = Context.SupplierFees
                              .Where(i => i.Id == supplierfee.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(supplierfee);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterSupplierFeeUpdated(supplierfee);

            return supplierfee;
        }

        partial void OnSupplierFeeDeleted(ZarenTravelBO.Models.ZarenTravel.SupplierFee item);
        partial void OnAfterSupplierFeeDeleted(ZarenTravelBO.Models.ZarenTravel.SupplierFee item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.SupplierFee> DeleteSupplierFee(int id)
        {
            var itemToDelete = Context.SupplierFees
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnSupplierFeeDeleted(itemToDelete);


            Context.SupplierFees.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterSupplierFeeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportSupplierProductTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/supplierproducttypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/supplierproducttypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportSupplierProductTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/supplierproducttypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/supplierproducttypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnSupplierProductTypesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.SupplierProductType> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.SupplierProductType>> GetSupplierProductTypes(Query query = null)
        {
            var items = Context.SupplierProductTypes.AsQueryable();

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

            OnSupplierProductTypesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnSupplierProductTypeGet(ZarenTravelBO.Models.ZarenTravel.SupplierProductType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.SupplierProductType> GetSupplierProductTypeById(int id)
        {
            var items = Context.SupplierProductTypes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnSupplierProductTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnSupplierProductTypeCreated(ZarenTravelBO.Models.ZarenTravel.SupplierProductType item);
        partial void OnAfterSupplierProductTypeCreated(ZarenTravelBO.Models.ZarenTravel.SupplierProductType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.SupplierProductType> CreateSupplierProductType(ZarenTravelBO.Models.ZarenTravel.SupplierProductType supplierproducttype)
        {
            OnSupplierProductTypeCreated(supplierproducttype);

            var existingItem = Context.SupplierProductTypes
                              .Where(i => i.Id == supplierproducttype.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.SupplierProductTypes.Add(supplierproducttype);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(supplierproducttype).State = EntityState.Detached;
                throw;
            }

            OnAfterSupplierProductTypeCreated(supplierproducttype);

            return supplierproducttype;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.SupplierProductType> CancelSupplierProductTypeChanges(ZarenTravelBO.Models.ZarenTravel.SupplierProductType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnSupplierProductTypeUpdated(ZarenTravelBO.Models.ZarenTravel.SupplierProductType item);
        partial void OnAfterSupplierProductTypeUpdated(ZarenTravelBO.Models.ZarenTravel.SupplierProductType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.SupplierProductType> UpdateSupplierProductType(int id, ZarenTravelBO.Models.ZarenTravel.SupplierProductType supplierproducttype)
        {
            OnSupplierProductTypeUpdated(supplierproducttype);

            var itemToUpdate = Context.SupplierProductTypes
                              .Where(i => i.Id == supplierproducttype.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(supplierproducttype);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterSupplierProductTypeUpdated(supplierproducttype);

            return supplierproducttype;
        }

        partial void OnSupplierProductTypeDeleted(ZarenTravelBO.Models.ZarenTravel.SupplierProductType item);
        partial void OnAfterSupplierProductTypeDeleted(ZarenTravelBO.Models.ZarenTravel.SupplierProductType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.SupplierProductType> DeleteSupplierProductType(int id)
        {
            var itemToDelete = Context.SupplierProductTypes
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnSupplierProductTypeDeleted(itemToDelete);


            Context.SupplierProductTypes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterSupplierProductTypeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportSupplierRegisteredProductsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/supplierregisteredproducts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/supplierregisteredproducts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportSupplierRegisteredProductsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/supplierregisteredproducts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/supplierregisteredproducts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnSupplierRegisteredProductsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.SupplierRegisteredProduct> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.SupplierRegisteredProduct>> GetSupplierRegisteredProducts(Query query = null)
        {
            var items = Context.SupplierRegisteredProducts.AsQueryable();

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

            OnSupplierRegisteredProductsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnSupplierRegisteredProductGet(ZarenTravelBO.Models.ZarenTravel.SupplierRegisteredProduct item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.SupplierRegisteredProduct> GetSupplierRegisteredProductById(int id)
        {
            var items = Context.SupplierRegisteredProducts
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Supplier);
  
            var itemToReturn = items.FirstOrDefault();

            OnSupplierRegisteredProductGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnSupplierRegisteredProductCreated(ZarenTravelBO.Models.ZarenTravel.SupplierRegisteredProduct item);
        partial void OnAfterSupplierRegisteredProductCreated(ZarenTravelBO.Models.ZarenTravel.SupplierRegisteredProduct item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.SupplierRegisteredProduct> CreateSupplierRegisteredProduct(ZarenTravelBO.Models.ZarenTravel.SupplierRegisteredProduct supplierregisteredproduct)
        {
            OnSupplierRegisteredProductCreated(supplierregisteredproduct);

            var existingItem = Context.SupplierRegisteredProducts
                              .Where(i => i.Id == supplierregisteredproduct.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.SupplierRegisteredProducts.Add(supplierregisteredproduct);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(supplierregisteredproduct).State = EntityState.Detached;
                throw;
            }

            OnAfterSupplierRegisteredProductCreated(supplierregisteredproduct);

            return supplierregisteredproduct;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.SupplierRegisteredProduct> CancelSupplierRegisteredProductChanges(ZarenTravelBO.Models.ZarenTravel.SupplierRegisteredProduct item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnSupplierRegisteredProductUpdated(ZarenTravelBO.Models.ZarenTravel.SupplierRegisteredProduct item);
        partial void OnAfterSupplierRegisteredProductUpdated(ZarenTravelBO.Models.ZarenTravel.SupplierRegisteredProduct item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.SupplierRegisteredProduct> UpdateSupplierRegisteredProduct(int id, ZarenTravelBO.Models.ZarenTravel.SupplierRegisteredProduct supplierregisteredproduct)
        {
            OnSupplierRegisteredProductUpdated(supplierregisteredproduct);

            var itemToUpdate = Context.SupplierRegisteredProducts
                              .Where(i => i.Id == supplierregisteredproduct.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(supplierregisteredproduct);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterSupplierRegisteredProductUpdated(supplierregisteredproduct);

            return supplierregisteredproduct;
        }

        partial void OnSupplierRegisteredProductDeleted(ZarenTravelBO.Models.ZarenTravel.SupplierRegisteredProduct item);
        partial void OnAfterSupplierRegisteredProductDeleted(ZarenTravelBO.Models.ZarenTravel.SupplierRegisteredProduct item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.SupplierRegisteredProduct> DeleteSupplierRegisteredProduct(int id)
        {
            var itemToDelete = Context.SupplierRegisteredProducts
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnSupplierRegisteredProductDeleted(itemToDelete);


            Context.SupplierRegisteredProducts.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterSupplierRegisteredProductDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportSuppliersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/suppliers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/suppliers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportSuppliersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/suppliers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/suppliers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnSuppliersRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.Supplier> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.Supplier>> GetSuppliers(Query query = null)
        {
            var items = Context.Suppliers.AsQueryable();

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

            OnSuppliersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnSupplierGet(ZarenTravelBO.Models.ZarenTravel.Supplier item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Supplier> GetSupplierById(int id)
        {
            var items = Context.Suppliers
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Supplier1);
                items = items.Include(i => i.SupplierType);
  
            var itemToReturn = items.FirstOrDefault();

            OnSupplierGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnSupplierCreated(ZarenTravelBO.Models.ZarenTravel.Supplier item);
        partial void OnAfterSupplierCreated(ZarenTravelBO.Models.ZarenTravel.Supplier item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Supplier> CreateSupplier(ZarenTravelBO.Models.ZarenTravel.Supplier supplier)
        {
            OnSupplierCreated(supplier);

            var existingItem = Context.Suppliers
                              .Where(i => i.Id == supplier.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Suppliers.Add(supplier);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(supplier).State = EntityState.Detached;
                throw;
            }

            OnAfterSupplierCreated(supplier);

            return supplier;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.Supplier> CancelSupplierChanges(ZarenTravelBO.Models.ZarenTravel.Supplier item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnSupplierUpdated(ZarenTravelBO.Models.ZarenTravel.Supplier item);
        partial void OnAfterSupplierUpdated(ZarenTravelBO.Models.ZarenTravel.Supplier item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Supplier> UpdateSupplier(int id, ZarenTravelBO.Models.ZarenTravel.Supplier supplier)
        {
            OnSupplierUpdated(supplier);

            var itemToUpdate = Context.Suppliers
                              .Where(i => i.Id == supplier.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(supplier);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterSupplierUpdated(supplier);

            return supplier;
        }

        partial void OnSupplierDeleted(ZarenTravelBO.Models.ZarenTravel.Supplier item);
        partial void OnAfterSupplierDeleted(ZarenTravelBO.Models.ZarenTravel.Supplier item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Supplier> DeleteSupplier(int id)
        {
            var itemToDelete = Context.Suppliers
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnSupplierDeleted(itemToDelete);


            Context.Suppliers.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterSupplierDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportSupplierSellingDestinationsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/suppliersellingdestinations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/suppliersellingdestinations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportSupplierSellingDestinationsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/suppliersellingdestinations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/suppliersellingdestinations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnSupplierSellingDestinationsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.SupplierSellingDestination> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.SupplierSellingDestination>> GetSupplierSellingDestinations(Query query = null)
        {
            var items = Context.SupplierSellingDestinations.AsQueryable();

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

            OnSupplierSellingDestinationsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnSupplierSellingDestinationGet(ZarenTravelBO.Models.ZarenTravel.SupplierSellingDestination item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.SupplierSellingDestination> GetSupplierSellingDestinationById(int id)
        {
            var items = Context.SupplierSellingDestinations
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Supplier);
  
            var itemToReturn = items.FirstOrDefault();

            OnSupplierSellingDestinationGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnSupplierSellingDestinationCreated(ZarenTravelBO.Models.ZarenTravel.SupplierSellingDestination item);
        partial void OnAfterSupplierSellingDestinationCreated(ZarenTravelBO.Models.ZarenTravel.SupplierSellingDestination item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.SupplierSellingDestination> CreateSupplierSellingDestination(ZarenTravelBO.Models.ZarenTravel.SupplierSellingDestination suppliersellingdestination)
        {
            OnSupplierSellingDestinationCreated(suppliersellingdestination);

            var existingItem = Context.SupplierSellingDestinations
                              .Where(i => i.Id == suppliersellingdestination.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.SupplierSellingDestinations.Add(suppliersellingdestination);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(suppliersellingdestination).State = EntityState.Detached;
                throw;
            }

            OnAfterSupplierSellingDestinationCreated(suppliersellingdestination);

            return suppliersellingdestination;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.SupplierSellingDestination> CancelSupplierSellingDestinationChanges(ZarenTravelBO.Models.ZarenTravel.SupplierSellingDestination item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnSupplierSellingDestinationUpdated(ZarenTravelBO.Models.ZarenTravel.SupplierSellingDestination item);
        partial void OnAfterSupplierSellingDestinationUpdated(ZarenTravelBO.Models.ZarenTravel.SupplierSellingDestination item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.SupplierSellingDestination> UpdateSupplierSellingDestination(int id, ZarenTravelBO.Models.ZarenTravel.SupplierSellingDestination suppliersellingdestination)
        {
            OnSupplierSellingDestinationUpdated(suppliersellingdestination);

            var itemToUpdate = Context.SupplierSellingDestinations
                              .Where(i => i.Id == suppliersellingdestination.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(suppliersellingdestination);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterSupplierSellingDestinationUpdated(suppliersellingdestination);

            return suppliersellingdestination;
        }

        partial void OnSupplierSellingDestinationDeleted(ZarenTravelBO.Models.ZarenTravel.SupplierSellingDestination item);
        partial void OnAfterSupplierSellingDestinationDeleted(ZarenTravelBO.Models.ZarenTravel.SupplierSellingDestination item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.SupplierSellingDestination> DeleteSupplierSellingDestination(int id)
        {
            var itemToDelete = Context.SupplierSellingDestinations
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnSupplierSellingDestinationDeleted(itemToDelete);


            Context.SupplierSellingDestinations.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterSupplierSellingDestinationDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportSupplierTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/suppliertypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/suppliertypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportSupplierTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/suppliertypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/suppliertypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnSupplierTypesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.SupplierType> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.SupplierType>> GetSupplierTypes(Query query = null)
        {
            var items = Context.SupplierTypes.AsQueryable();

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

            OnSupplierTypesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnSupplierTypeGet(ZarenTravelBO.Models.ZarenTravel.SupplierType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.SupplierType> GetSupplierTypeById(int id)
        {
            var items = Context.SupplierTypes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnSupplierTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnSupplierTypeCreated(ZarenTravelBO.Models.ZarenTravel.SupplierType item);
        partial void OnAfterSupplierTypeCreated(ZarenTravelBO.Models.ZarenTravel.SupplierType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.SupplierType> CreateSupplierType(ZarenTravelBO.Models.ZarenTravel.SupplierType suppliertype)
        {
            OnSupplierTypeCreated(suppliertype);

            var existingItem = Context.SupplierTypes
                              .Where(i => i.Id == suppliertype.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.SupplierTypes.Add(suppliertype);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(suppliertype).State = EntityState.Detached;
                throw;
            }

            OnAfterSupplierTypeCreated(suppliertype);

            return suppliertype;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.SupplierType> CancelSupplierTypeChanges(ZarenTravelBO.Models.ZarenTravel.SupplierType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnSupplierTypeUpdated(ZarenTravelBO.Models.ZarenTravel.SupplierType item);
        partial void OnAfterSupplierTypeUpdated(ZarenTravelBO.Models.ZarenTravel.SupplierType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.SupplierType> UpdateSupplierType(int id, ZarenTravelBO.Models.ZarenTravel.SupplierType suppliertype)
        {
            OnSupplierTypeUpdated(suppliertype);

            var itemToUpdate = Context.SupplierTypes
                              .Where(i => i.Id == suppliertype.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(suppliertype);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterSupplierTypeUpdated(suppliertype);

            return suppliertype;
        }

        partial void OnSupplierTypeDeleted(ZarenTravelBO.Models.ZarenTravel.SupplierType item);
        partial void OnAfterSupplierTypeDeleted(ZarenTravelBO.Models.ZarenTravel.SupplierType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.SupplierType> DeleteSupplierType(int id)
        {
            var itemToDelete = Context.SupplierTypes
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnSupplierTypeDeleted(itemToDelete);


            Context.SupplierTypes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterSupplierTypeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTerminalsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/terminals/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/terminals/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTerminalsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/terminals/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/terminals/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTerminalsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.Terminal> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.Terminal>> GetTerminals(Query query = null)
        {
            var items = Context.Terminals.AsQueryable();

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

            OnTerminalsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTerminalGet(ZarenTravelBO.Models.ZarenTravel.Terminal item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Terminal> GetTerminalById(int id)
        {
            var items = Context.Terminals
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Airport);
  
            var itemToReturn = items.FirstOrDefault();

            OnTerminalGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTerminalCreated(ZarenTravelBO.Models.ZarenTravel.Terminal item);
        partial void OnAfterTerminalCreated(ZarenTravelBO.Models.ZarenTravel.Terminal item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Terminal> CreateTerminal(ZarenTravelBO.Models.ZarenTravel.Terminal terminal)
        {
            OnTerminalCreated(terminal);

            var existingItem = Context.Terminals
                              .Where(i => i.Id == terminal.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Terminals.Add(terminal);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(terminal).State = EntityState.Detached;
                throw;
            }

            OnAfterTerminalCreated(terminal);

            return terminal;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.Terminal> CancelTerminalChanges(ZarenTravelBO.Models.ZarenTravel.Terminal item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTerminalUpdated(ZarenTravelBO.Models.ZarenTravel.Terminal item);
        partial void OnAfterTerminalUpdated(ZarenTravelBO.Models.ZarenTravel.Terminal item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Terminal> UpdateTerminal(int id, ZarenTravelBO.Models.ZarenTravel.Terminal terminal)
        {
            OnTerminalUpdated(terminal);

            var itemToUpdate = Context.Terminals
                              .Where(i => i.Id == terminal.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(terminal);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTerminalUpdated(terminal);

            return terminal;
        }

        partial void OnTerminalDeleted(ZarenTravelBO.Models.ZarenTravel.Terminal item);
        partial void OnAfterTerminalDeleted(ZarenTravelBO.Models.ZarenTravel.Terminal item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Terminal> DeleteTerminal(int id)
        {
            var itemToDelete = Context.Terminals
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTerminalDeleted(itemToDelete);


            Context.Terminals.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTerminalDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportThemeStylesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/themestyles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/themestyles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportThemeStylesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/themestyles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/themestyles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnThemeStylesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.ThemeStyle> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.ThemeStyle>> GetThemeStyles(Query query = null)
        {
            var items = Context.ThemeStyles.AsQueryable();

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

            OnThemeStylesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnThemeStyleGet(ZarenTravelBO.Models.ZarenTravel.ThemeStyle item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.ThemeStyle> GetThemeStyleById(int id)
        {
            var items = Context.ThemeStyles
                              .AsNoTracking()
                              .Where(i => i.ID == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnThemeStyleGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnThemeStyleCreated(ZarenTravelBO.Models.ZarenTravel.ThemeStyle item);
        partial void OnAfterThemeStyleCreated(ZarenTravelBO.Models.ZarenTravel.ThemeStyle item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.ThemeStyle> CreateThemeStyle(ZarenTravelBO.Models.ZarenTravel.ThemeStyle themestyle)
        {
            OnThemeStyleCreated(themestyle);

            var existingItem = Context.ThemeStyles
                              .Where(i => i.ID == themestyle.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ThemeStyles.Add(themestyle);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(themestyle).State = EntityState.Detached;
                throw;
            }

            OnAfterThemeStyleCreated(themestyle);

            return themestyle;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.ThemeStyle> CancelThemeStyleChanges(ZarenTravelBO.Models.ZarenTravel.ThemeStyle item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnThemeStyleUpdated(ZarenTravelBO.Models.ZarenTravel.ThemeStyle item);
        partial void OnAfterThemeStyleUpdated(ZarenTravelBO.Models.ZarenTravel.ThemeStyle item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.ThemeStyle> UpdateThemeStyle(int id, ZarenTravelBO.Models.ZarenTravel.ThemeStyle themestyle)
        {
            OnThemeStyleUpdated(themestyle);

            var itemToUpdate = Context.ThemeStyles
                              .Where(i => i.ID == themestyle.ID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(themestyle);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterThemeStyleUpdated(themestyle);

            return themestyle;
        }

        partial void OnThemeStyleDeleted(ZarenTravelBO.Models.ZarenTravel.ThemeStyle item);
        partial void OnAfterThemeStyleDeleted(ZarenTravelBO.Models.ZarenTravel.ThemeStyle item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.ThemeStyle> DeleteThemeStyle(int id)
        {
            var itemToDelete = Context.ThemeStyles
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnThemeStyleDeleted(itemToDelete);


            Context.ThemeStyles.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterThemeStyleDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportUrlsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/urls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/urls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportUrlsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/urls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/urls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnUrlsRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.Url> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.Url>> GetUrls(Query query = null)
        {
            var items = Context.Urls.AsQueryable();

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

            OnUrlsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnUrlGet(ZarenTravelBO.Models.ZarenTravel.Url item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Url> GetUrlById(int id)
        {
            var items = Context.Urls
                              .AsNoTracking()
                              .Where(i => i.ID == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnUrlGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnUrlCreated(ZarenTravelBO.Models.ZarenTravel.Url item);
        partial void OnAfterUrlCreated(ZarenTravelBO.Models.ZarenTravel.Url item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Url> CreateUrl(ZarenTravelBO.Models.ZarenTravel.Url url)
        {
            OnUrlCreated(url);

            var existingItem = Context.Urls
                              .Where(i => i.ID == url.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Urls.Add(url);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(url).State = EntityState.Detached;
                throw;
            }

            OnAfterUrlCreated(url);

            return url;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.Url> CancelUrlChanges(ZarenTravelBO.Models.ZarenTravel.Url item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnUrlUpdated(ZarenTravelBO.Models.ZarenTravel.Url item);
        partial void OnAfterUrlUpdated(ZarenTravelBO.Models.ZarenTravel.Url item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Url> UpdateUrl(int id, ZarenTravelBO.Models.ZarenTravel.Url url)
        {
            OnUrlUpdated(url);

            var itemToUpdate = Context.Urls
                              .Where(i => i.ID == url.ID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(url);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterUrlUpdated(url);

            return url;
        }

        partial void OnUrlDeleted(ZarenTravelBO.Models.ZarenTravel.Url item);
        partial void OnAfterUrlDeleted(ZarenTravelBO.Models.ZarenTravel.Url item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Url> DeleteUrl(int id)
        {
            var itemToDelete = Context.Urls
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnUrlDeleted(itemToDelete);


            Context.Urls.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterUrlDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportUserPreferencesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/userpreferences/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/userpreferences/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportUserPreferencesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/userpreferences/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/userpreferences/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnUserPreferencesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.UserPreference> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.UserPreference>> GetUserPreferences(Query query = null)
        {
            var items = Context.UserPreferences.AsQueryable();

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

            OnUserPreferencesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnUserPreferenceGet(ZarenTravelBO.Models.ZarenTravel.UserPreference item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.UserPreference> GetUserPreferenceById(int id)
        {
            var items = Context.UserPreferences
                              .AsNoTracking()
                              .Where(i => i.ID == id);

                items = items.Include(i => i.User);
  
            var itemToReturn = items.FirstOrDefault();

            OnUserPreferenceGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnUserPreferenceCreated(ZarenTravelBO.Models.ZarenTravel.UserPreference item);
        partial void OnAfterUserPreferenceCreated(ZarenTravelBO.Models.ZarenTravel.UserPreference item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.UserPreference> CreateUserPreference(ZarenTravelBO.Models.ZarenTravel.UserPreference userpreference)
        {
            OnUserPreferenceCreated(userpreference);

            var existingItem = Context.UserPreferences
                              .Where(i => i.ID == userpreference.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.UserPreferences.Add(userpreference);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(userpreference).State = EntityState.Detached;
                throw;
            }

            OnAfterUserPreferenceCreated(userpreference);

            return userpreference;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.UserPreference> CancelUserPreferenceChanges(ZarenTravelBO.Models.ZarenTravel.UserPreference item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnUserPreferenceUpdated(ZarenTravelBO.Models.ZarenTravel.UserPreference item);
        partial void OnAfterUserPreferenceUpdated(ZarenTravelBO.Models.ZarenTravel.UserPreference item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.UserPreference> UpdateUserPreference(int id, ZarenTravelBO.Models.ZarenTravel.UserPreference userpreference)
        {
            OnUserPreferenceUpdated(userpreference);

            var itemToUpdate = Context.UserPreferences
                              .Where(i => i.ID == userpreference.ID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(userpreference);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterUserPreferenceUpdated(userpreference);

            return userpreference;
        }

        partial void OnUserPreferenceDeleted(ZarenTravelBO.Models.ZarenTravel.UserPreference item);
        partial void OnAfterUserPreferenceDeleted(ZarenTravelBO.Models.ZarenTravel.UserPreference item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.UserPreference> DeleteUserPreference(int id)
        {
            var itemToDelete = Context.UserPreferences
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnUserPreferenceDeleted(itemToDelete);


            Context.UserPreferences.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterUserPreferenceDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportUsersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/users/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/users/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportUsersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/users/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/users/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnUsersRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.User> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.User>> GetUsers(Query query = null)
        {
            var items = Context.Users.AsQueryable();

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

            OnUsersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnUserGet(ZarenTravelBO.Models.ZarenTravel.User item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.User> GetUserById(int id)
        {
            var items = Context.Users
                              .AsNoTracking()
                              .Where(i => i.ID == id);

                items = items.Include(i => i.UserType1);
  
            var itemToReturn = items.FirstOrDefault();

            OnUserGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnUserCreated(ZarenTravelBO.Models.ZarenTravel.User item);
        partial void OnAfterUserCreated(ZarenTravelBO.Models.ZarenTravel.User item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.User> CreateUser(ZarenTravelBO.Models.ZarenTravel.User user)
        {
            OnUserCreated(user);

            var existingItem = Context.Users
                              .Where(i => i.ID == user.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Users.Add(user);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(user).State = EntityState.Detached;
                throw;
            }

            OnAfterUserCreated(user);

            return user;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.User> CancelUserChanges(ZarenTravelBO.Models.ZarenTravel.User item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnUserUpdated(ZarenTravelBO.Models.ZarenTravel.User item);
        partial void OnAfterUserUpdated(ZarenTravelBO.Models.ZarenTravel.User item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.User> UpdateUser(int id, ZarenTravelBO.Models.ZarenTravel.User user)
        {
            OnUserUpdated(user);

            var itemToUpdate = Context.Users
                              .Where(i => i.ID == user.ID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(user);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterUserUpdated(user);

            return user;
        }

        partial void OnUserDeleted(ZarenTravelBO.Models.ZarenTravel.User item);
        partial void OnAfterUserDeleted(ZarenTravelBO.Models.ZarenTravel.User item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.User> DeleteUser(int id)
        {
            var itemToDelete = Context.Users
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnUserDeleted(itemToDelete);


            Context.Users.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterUserDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportUserTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/usertypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/usertypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportUserTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/usertypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/usertypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnUserTypesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.UserType> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.UserType>> GetUserTypes(Query query = null)
        {
            var items = Context.UserTypes.AsQueryable();

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

            OnUserTypesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnUserTypeGet(ZarenTravelBO.Models.ZarenTravel.UserType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.UserType> GetUserTypeById(int id)
        {
            var items = Context.UserTypes
                              .AsNoTracking()
                              .Where(i => i.ID == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnUserTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnUserTypeCreated(ZarenTravelBO.Models.ZarenTravel.UserType item);
        partial void OnAfterUserTypeCreated(ZarenTravelBO.Models.ZarenTravel.UserType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.UserType> CreateUserType(ZarenTravelBO.Models.ZarenTravel.UserType usertype)
        {
            OnUserTypeCreated(usertype);

            var existingItem = Context.UserTypes
                              .Where(i => i.ID == usertype.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.UserTypes.Add(usertype);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(usertype).State = EntityState.Detached;
                throw;
            }

            OnAfterUserTypeCreated(usertype);

            return usertype;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.UserType> CancelUserTypeChanges(ZarenTravelBO.Models.ZarenTravel.UserType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnUserTypeUpdated(ZarenTravelBO.Models.ZarenTravel.UserType item);
        partial void OnAfterUserTypeUpdated(ZarenTravelBO.Models.ZarenTravel.UserType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.UserType> UpdateUserType(int id, ZarenTravelBO.Models.ZarenTravel.UserType usertype)
        {
            OnUserTypeUpdated(usertype);

            var itemToUpdate = Context.UserTypes
                              .Where(i => i.ID == usertype.ID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(usertype);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterUserTypeUpdated(usertype);

            return usertype;
        }

        partial void OnUserTypeDeleted(ZarenTravelBO.Models.ZarenTravel.UserType item);
        partial void OnAfterUserTypeDeleted(ZarenTravelBO.Models.ZarenTravel.UserType item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.UserType> DeleteUserType(int id)
        {
            var itemToDelete = Context.UserTypes
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnUserTypeDeleted(itemToDelete);


            Context.UserTypes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterUserTypeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportYesNosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/yesnos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/yesnos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportYesNosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/yesnos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/yesnos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnYesNosRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.YesNo> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.YesNo>> GetYesNos(Query query = null)
        {
            var items = Context.YesNos.AsQueryable();

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

            OnYesNosRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnYesNoGet(ZarenTravelBO.Models.ZarenTravel.YesNo item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.YesNo> GetYesNoById(int id)
        {
            var items = Context.YesNos
                              .AsNoTracking()
                              .Where(i => i.ID == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnYesNoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnYesNoCreated(ZarenTravelBO.Models.ZarenTravel.YesNo item);
        partial void OnAfterYesNoCreated(ZarenTravelBO.Models.ZarenTravel.YesNo item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.YesNo> CreateYesNo(ZarenTravelBO.Models.ZarenTravel.YesNo yesno)
        {
            OnYesNoCreated(yesno);

            var existingItem = Context.YesNos
                              .Where(i => i.ID == yesno.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.YesNos.Add(yesno);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(yesno).State = EntityState.Detached;
                throw;
            }

            OnAfterYesNoCreated(yesno);

            return yesno;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.YesNo> CancelYesNoChanges(ZarenTravelBO.Models.ZarenTravel.YesNo item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnYesNoUpdated(ZarenTravelBO.Models.ZarenTravel.YesNo item);
        partial void OnAfterYesNoUpdated(ZarenTravelBO.Models.ZarenTravel.YesNo item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.YesNo> UpdateYesNo(int id, ZarenTravelBO.Models.ZarenTravel.YesNo yesno)
        {
            OnYesNoUpdated(yesno);

            var itemToUpdate = Context.YesNos
                              .Where(i => i.ID == yesno.ID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(yesno);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterYesNoUpdated(yesno);

            return yesno;
        }

        partial void OnYesNoDeleted(ZarenTravelBO.Models.ZarenTravel.YesNo item);
        partial void OnAfterYesNoDeleted(ZarenTravelBO.Models.ZarenTravel.YesNo item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.YesNo> DeleteYesNo(int id)
        {
            var itemToDelete = Context.YesNos
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnYesNoDeleted(itemToDelete);


            Context.YesNos.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterYesNoDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportZonesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/zones/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/zones/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportZonesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/zones/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/zones/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnZonesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.Zone> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.Zone>> GetZones(Query query = null)
        {
            var items = Context.Zones.AsQueryable();

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

            OnZonesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnZoneGet(ZarenTravelBO.Models.ZarenTravel.Zone item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Zone> GetZoneById(int id)
        {
            var items = Context.Zones
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Region);
  
            var itemToReturn = items.FirstOrDefault();

            OnZoneGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnZoneCreated(ZarenTravelBO.Models.ZarenTravel.Zone item);
        partial void OnAfterZoneCreated(ZarenTravelBO.Models.ZarenTravel.Zone item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Zone> CreateZone(ZarenTravelBO.Models.ZarenTravel.Zone zone)
        {
            OnZoneCreated(zone);

            var existingItem = Context.Zones
                              .Where(i => i.Id == zone.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Zones.Add(zone);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(zone).State = EntityState.Detached;
                throw;
            }

            OnAfterZoneCreated(zone);

            return zone;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.Zone> CancelZoneChanges(ZarenTravelBO.Models.ZarenTravel.Zone item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnZoneUpdated(ZarenTravelBO.Models.ZarenTravel.Zone item);
        partial void OnAfterZoneUpdated(ZarenTravelBO.Models.ZarenTravel.Zone item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Zone> UpdateZone(int id, ZarenTravelBO.Models.ZarenTravel.Zone zone)
        {
            OnZoneUpdated(zone);

            var itemToUpdate = Context.Zones
                              .Where(i => i.Id == zone.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(zone);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterZoneUpdated(zone);

            return zone;
        }

        partial void OnZoneDeleted(ZarenTravelBO.Models.ZarenTravel.Zone item);
        partial void OnAfterZoneDeleted(ZarenTravelBO.Models.ZarenTravel.Zone item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.Zone> DeleteZone(int id)
        {
            var itemToDelete = Context.Zones
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnZoneDeleted(itemToDelete);


            Context.Zones.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterZoneDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportZonesCitiesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/zonescities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/zonescities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportZonesCitiesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zarentravel/zonescities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zarentravel/zonescities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnZonesCitiesRead(ref IQueryable<ZarenTravelBO.Models.ZarenTravel.ZonesCity> items);

        public async Task<IQueryable<ZarenTravelBO.Models.ZarenTravel.ZonesCity>> GetZonesCities(Query query = null)
        {
            var items = Context.ZonesCities.AsQueryable();

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

            OnZonesCitiesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnZonesCityGet(ZarenTravelBO.Models.ZarenTravel.ZonesCity item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.ZonesCity> GetZonesCityById(int id)
        {
            var items = Context.ZonesCities
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.City);
                items = items.Include(i => i.Zone);
  
            var itemToReturn = items.FirstOrDefault();

            OnZonesCityGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnZonesCityCreated(ZarenTravelBO.Models.ZarenTravel.ZonesCity item);
        partial void OnAfterZonesCityCreated(ZarenTravelBO.Models.ZarenTravel.ZonesCity item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.ZonesCity> CreateZonesCity(ZarenTravelBO.Models.ZarenTravel.ZonesCity zonescity)
        {
            OnZonesCityCreated(zonescity);

            var existingItem = Context.ZonesCities
                              .Where(i => i.Id == zonescity.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ZonesCities.Add(zonescity);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(zonescity).State = EntityState.Detached;
                throw;
            }

            OnAfterZonesCityCreated(zonescity);

            return zonescity;
        }

        public async Task<ZarenTravelBO.Models.ZarenTravel.ZonesCity> CancelZonesCityChanges(ZarenTravelBO.Models.ZarenTravel.ZonesCity item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnZonesCityUpdated(ZarenTravelBO.Models.ZarenTravel.ZonesCity item);
        partial void OnAfterZonesCityUpdated(ZarenTravelBO.Models.ZarenTravel.ZonesCity item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.ZonesCity> UpdateZonesCity(int id, ZarenTravelBO.Models.ZarenTravel.ZonesCity zonescity)
        {
            OnZonesCityUpdated(zonescity);

            var itemToUpdate = Context.ZonesCities
                              .Where(i => i.Id == zonescity.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(zonescity);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterZonesCityUpdated(zonescity);

            return zonescity;
        }

        partial void OnZonesCityDeleted(ZarenTravelBO.Models.ZarenTravel.ZonesCity item);
        partial void OnAfterZonesCityDeleted(ZarenTravelBO.Models.ZarenTravel.ZonesCity item);

        public async Task<ZarenTravelBO.Models.ZarenTravel.ZonesCity> DeleteZonesCity(int id)
        {
            var itemToDelete = Context.ZonesCities
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnZonesCityDeleted(itemToDelete);


            Context.ZonesCities.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterZonesCityDeleted(itemToDelete);

            return itemToDelete;
        }
        }
}