using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;

namespace Travel.Pages
{
    public partial class AddRoomsSelectedHotel
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }
        [Inject]
        public TravelCDbService TravelCDbService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            roomsSelectedHotel = new Travel.Models.TravelCDb.RoomsSelectedHotel();

            hotelsForHotelId = await TravelCDbService.GetHotels();

            roomsForRoomId = await TravelCDbService.GetRooms();
        }
        protected bool errorVisible;
        protected Travel.Models.TravelCDb.RoomsSelectedHotel roomsSelectedHotel;

        protected IEnumerable<Travel.Models.TravelCDb.Hotel> hotelsForHotelId;

        protected IEnumerable<Travel.Models.TravelCDb.Room> roomsForRoomId;

        protected async Task FormSubmit()
        {
            try
            {
                await TravelCDbService.CreateRoomsSelectedHotel(roomsSelectedHotel);
                DialogService.Close(roomsSelectedHotel);
            }
            catch (Exception ex)
            {
                hasChanges = ex is Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException;
                canEdit = !(ex is Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException);
                errorVisible = true;
            }
        }

        protected async Task CancelButtonClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }


        protected bool hasChanges = false;
        protected bool canEdit = true;
    }
}