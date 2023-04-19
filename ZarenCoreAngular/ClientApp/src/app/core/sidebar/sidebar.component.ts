import { Component, OnInit } from '@angular/core';

declare const $: any;
declare interface RouteInfo {
  path: string;
  title: string;
  icon: string;
  class: string;
}
export const ROUTES: RouteInfo[] = [
	{ path: '/accommodation', title: 'Accommodation', icon: 'people_alt', class: '' },
{ path: '/accommodationextras', title: 'AccommodationExtras', icon: 'people_alt', class: '' },
{ path: '/agency', title: 'Agency', icon: 'people_alt', class: '' },
{ path: '/agencygroup', title: 'AgencyGroup', icon: 'people_alt', class: '' },
{ path: '/agentınformation', title: 'AgentInformation', icon: 'people_alt', class: '' },
{ path: '/air', title: 'Air', icon: 'people_alt', class: '' },
{ path: '/airextras', title: 'AirExtras', icon: 'people_alt', class: '' },
{ path: '/airline', title: 'Airline', icon: 'people_alt', class: '' },
{ path: '/airport', title: 'Airport', icon: 'people_alt', class: '' },
{ path: '/airsegments', title: 'AirSegments', icon: 'people_alt', class: '' },
{ path: '/broker', title: 'Broker', icon: 'people_alt', class: '' },
{ path: '/carrent', title: 'carrent', icon: 'people_alt', class: '' },
{ path: '/carrental', title: 'CarRental', icon: 'people_alt', class: '' },
{ path: '/cartype', title: 'CarType', icon: 'people_alt', class: '' },
{ path: '/chain', title: 'Chain', icon: 'people_alt', class: '' },
{ path: '/city', title: 'City', icon: 'people_alt', class: '' },
{ path: '/company', title: 'Company', icon: 'people_alt', class: '' },
{ path: '/companycustomfields', title: 'CompanyCustomFields', icon: 'people_alt', class: '' },
{ path: '/companydivisions', title: 'CompanyDivisions', icon: 'people_alt', class: '' },
{ path: '/companygroup', title: 'CompanyGroup', icon: 'people_alt', class: '' },
{ path: '/country', title: 'Country', icon: 'people_alt', class: '' },
{ path: '/currency', title: 'Currency', icon: 'people_alt', class: '' },
{ path: '/customerınformation', title: 'CustomerInformation', icon: 'people_alt', class: '' },
{ path: '/exchangerates', title: 'ExchangeRates', icon: 'people_alt', class: '' },
{ path: '/extrastype', title: 'ExtrasType', icon: 'people_alt', class: '' },
{ path: '/fieldstype', title: 'FieldsType', icon: 'people_alt', class: '' },
{ path: '/gds', title: 'GDS', icon: 'people_alt', class: '' },
{ path: '/hotel', title: 'Hotel', icon: 'people_alt', class: '' },
{ path: '/hotelcodes', title: 'HotelCodes', icon: 'people_alt', class: '' },
{ path: '/ındustrysegment', title: 'IndustrySegment', icon: 'people_alt', class: '' },
{ path: '/languages', title: 'Languages', icon: 'people_alt', class: '' },
{ path: '/passenger', title: 'Passenger', icon: 'people_alt', class: '' },
{ path: '/passengerınformation', title: 'PassengerInformation', icon: 'people_alt', class: '' },
{ path: '/pcc', title: 'PCC', icon: 'people_alt', class: '' },
{ path: '/pnr', title: 'PNR', icon: 'people_alt', class: '' },
{ path: '/pnrcustomfields', title: 'PNRCustomFields', icon: 'people_alt', class: '' },
{ path: '/reservationınformation', title: 'ReservationInformation', icon: 'people_alt', class: '' },
{ path: '/roomtype', title: 'RoomType', icon: 'people_alt', class: '' },
{ path: '/segmentınformation', title: 'SegmentInformation', icon: 'people_alt', class: '' },
{ path: '/terminal', title: 'Terminal', icon: 'people_alt', class: '' },


 
];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html'
})
export class SidebarComponent implements OnInit {
  menuItems: any[];

  constructor() { }

  ngOnInit() {
    this.menuItems = ROUTES.filter(menuItem => menuItem);
  }
  isMobileMenu() {
    if ($(window).width() > 991) {
      return false;
    }
    return true;
  };
}
