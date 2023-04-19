import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FlexLayoutModule, CoreModule } from '@angular/flex-layout';

import {MatButtonModule} from '@angular/material/button';
import {MatInputModule} from '@angular/material/input';
import {MatCheckboxModule} from '@angular/material/checkbox'
import {MatRippleModule} from '@angular/material/core';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatTooltipModule} from '@angular/material/tooltip';
import {MatSelectModule} from '@angular/material/select';
import {MatDialogModule} from '@angular/material/dialog';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatNativeDateModule} from '@angular/material/core';
import {MatRadioModule} from '@angular/material/radio';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import {MatTabsModule} from '@angular/material/tabs';

import { DataTablesModule } from 'angular-datatables';

import { AdminRoutes } from './admin.routing';
import { AccommodationComponent } from './components/accommodation/accommodation.component';
import { AccommodationDialogComponent } from './components/accommodation/accommodation-dialog/accommodation-dialog.component';
import { AccommodationExtrasComponent } from './components/accommodationextras/accommodationextras.component';
import { AccommodationExtrasDialogComponent } from './components/accommodationextras/accommodationextras-dialog/accommodationextras-dialog.component';
import { AgencyComponent } from './components/agency/agency.component';
import { AgencyDialogComponent } from './components/agency/agency-dialog/agency-dialog.component';
import { AgencyGroupComponent } from './components/agencygroup/agencygroup.component';
import { AgencyGroupDialogComponent } from './components/agencygroup/agencygroup-dialog/agencygroup-dialog.component';
import { AgentInformationComponent } from './components/agentınformation/agentınformation.component';
import { AgentInformationDialogComponent } from './components/agentınformation/agentınformation-dialog/agentınformation-dialog.component';
import { AirComponent } from './components/air/air.component';
import { AirDialogComponent } from './components/air/air-dialog/air-dialog.component';
import { AirExtrasComponent } from './components/airextras/airextras.component';
import { AirExtrasDialogComponent } from './components/airextras/airextras-dialog/airextras-dialog.component';
import { AirlineComponent } from './components/airline/airline.component';
import { AirlineDialogComponent } from './components/airline/airline-dialog/airline-dialog.component';
import { AirportComponent } from './components/airport/airport.component';
import { AirportDialogComponent } from './components/airport/airport-dialog/airport-dialog.component';
import { AirSegmentsComponent } from './components/airsegments/airsegments.component';
import { AirSegmentsDialogComponent } from './components/airsegments/airsegments-dialog/airsegments-dialog.component';
import { BrokerComponent } from './components/broker/broker.component';
import { BrokerDialogComponent } from './components/broker/broker-dialog/broker-dialog.component';
import { carrentComponent } from './components/carrent/carrent.component';
import { carrentDialogComponent } from './components/carrent/carrent-dialog/carrent-dialog.component';
import { CarRentalComponent } from './components/carrental/carrental.component';
import { CarRentalDialogComponent } from './components/carrental/carrental-dialog/carrental-dialog.component';
import { CarTypeComponent } from './components/cartype/cartype.component';
import { CarTypeDialogComponent } from './components/cartype/cartype-dialog/cartype-dialog.component';
import { ChainComponent } from './components/chain/chain.component';
import { ChainDialogComponent } from './components/chain/chain-dialog/chain-dialog.component';
import { CityComponent } from './components/city/city.component';
import { CityDialogComponent } from './components/city/city-dialog/city-dialog.component';
import { CompanyComponent } from './components/company/company.component';
import { CompanyDialogComponent } from './components/company/company-dialog/company-dialog.component';
import { CompanyCustomFieldsComponent } from './components/companycustomfields/companycustomfields.component';
import { CompanyCustomFieldsDialogComponent } from './components/companycustomfields/companycustomfields-dialog/companycustomfields-dialog.component';
import { CompanyDivisionsComponent } from './components/companydivisions/companydivisions.component';
import { CompanyDivisionsDialogComponent } from './components/companydivisions/companydivisions-dialog/companydivisions-dialog.component';
import { CompanyGroupComponent } from './components/companygroup/companygroup.component';
import { CompanyGroupDialogComponent } from './components/companygroup/companygroup-dialog/companygroup-dialog.component';
import { CountryComponent } from './components/country/country.component';
import { CountryDialogComponent } from './components/country/country-dialog/country-dialog.component';
import { CurrencyComponent } from './components/currency/currency.component';
import { CurrencyDialogComponent } from './components/currency/currency-dialog/currency-dialog.component';
import { CustomerInformationComponent } from './components/customerınformation/customerınformation.component';
import { CustomerInformationDialogComponent } from './components/customerınformation/customerınformation-dialog/customerınformation-dialog.component';
import { ExchangeRatesComponent } from './components/exchangerates/exchangerates.component';
import { ExchangeRatesDialogComponent } from './components/exchangerates/exchangerates-dialog/exchangerates-dialog.component';
import { ExtrasTypeComponent } from './components/extrastype/extrastype.component';
import { ExtrasTypeDialogComponent } from './components/extrastype/extrastype-dialog/extrastype-dialog.component';
import { FieldsTypeComponent } from './components/fieldstype/fieldstype.component';
import { FieldsTypeDialogComponent } from './components/fieldstype/fieldstype-dialog/fieldstype-dialog.component';
import { GDSComponent } from './components/gds/gds.component';
import { GDSDialogComponent } from './components/gds/gds-dialog/gds-dialog.component';
import { HotelComponent } from './components/hotel/hotel.component';
import { HotelDialogComponent } from './components/hotel/hotel-dialog/hotel-dialog.component';
import { HotelCodesComponent } from './components/hotelcodes/hotelcodes.component';
import { HotelCodesDialogComponent } from './components/hotelcodes/hotelcodes-dialog/hotelcodes-dialog.component';
import { IndustrySegmentComponent } from './components/ındustrysegment/ındustrysegment.component';
import { IndustrySegmentDialogComponent } from './components/ındustrysegment/ındustrysegment-dialog/ındustrysegment-dialog.component';
import { LanguagesComponent } from './components/languages/languages.component';
import { LanguagesDialogComponent } from './components/languages/languages-dialog/languages-dialog.component';
import { PassengerComponent } from './components/passenger/passenger.component';
import { PassengerDialogComponent } from './components/passenger/passenger-dialog/passenger-dialog.component';
import { PassengerInformationComponent } from './components/passengerınformation/passengerınformation.component';
import { PassengerInformationDialogComponent } from './components/passengerınformation/passengerınformation-dialog/passengerınformation-dialog.component';
import { PCCComponent } from './components/pcc/pcc.component';
import { PCCDialogComponent } from './components/pcc/pcc-dialog/pcc-dialog.component';
import { PNRComponent } from './components/pnr/pnr.component';
import { PNRDialogComponent } from './components/pnr/pnr-dialog/pnr-dialog.component';
import { PNRCustomFieldsComponent } from './components/pnrcustomfields/pnrcustomfields.component';
import { PNRCustomFieldsDialogComponent } from './components/pnrcustomfields/pnrcustomfields-dialog/pnrcustomfields-dialog.component';
import { ReservationInformationComponent } from './components/reservationınformation/reservationınformation.component';
import { ReservationInformationDialogComponent } from './components/reservationınformation/reservationınformation-dialog/reservationınformation-dialog.component';
import { RoomTypeComponent } from './components/roomtype/roomtype.component';
import { RoomTypeDialogComponent } from './components/roomtype/roomtype-dialog/roomtype-dialog.component';
import { SegmentInformationComponent } from './components/segmentınformation/segmentınformation.component';
import { SegmentInformationDialogComponent } from './components/segmentınformation/segmentınformation-dialog/segmentınformation-dialog.component';
import { TerminalComponent } from './components/terminal/terminal.component';
import { TerminalDialogComponent } from './components/terminal/terminal-dialog/terminal-dialog.component';


import { DashboardComponent } from 'app/modules/admin/components/dashboard/dashboard.component';

import { ConfirmDialogComponent } from 'app/shared/components/confirm-dialog/confirm-dialog.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(AdminRoutes),
    FormsModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatRippleModule,
    MatFormFieldModule,
    MatInputModule,
	MatCheckboxModule,
    MatSelectModule,
    MatTooltipModule,
    MatDialogModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatRadioModule,
    FlexLayoutModule,
    MatProgressBarModule,
	MatTabsModule,
    DataTablesModule,
    CoreModule
  ],
  declarations: [
    DashboardComponent,
AccommodationComponent,
AccommodationDialogComponent,
AccommodationExtrasComponent,
AccommodationExtrasDialogComponent,
AgencyComponent,
AgencyDialogComponent,
AgencyGroupComponent,
AgencyGroupDialogComponent,
AgentInformationComponent,
AgentInformationDialogComponent,
AirComponent,
AirDialogComponent,
AirExtrasComponent,
AirExtrasDialogComponent,
AirlineComponent,
AirlineDialogComponent,
AirportComponent,
AirportDialogComponent,
AirSegmentsComponent,
AirSegmentsDialogComponent,
BrokerComponent,
BrokerDialogComponent,
carrentComponent,
carrentDialogComponent,
CarRentalComponent,
CarRentalDialogComponent,
CarTypeComponent,
CarTypeDialogComponent,
ChainComponent,
ChainDialogComponent,
CityComponent,
CityDialogComponent,
CompanyComponent,
CompanyDialogComponent,
CompanyCustomFieldsComponent,
CompanyCustomFieldsDialogComponent,
CompanyDivisionsComponent,
CompanyDivisionsDialogComponent,
CompanyGroupComponent,
CompanyGroupDialogComponent,
CountryComponent,
CountryDialogComponent,
CurrencyComponent,
CurrencyDialogComponent,
CustomerInformationComponent,
CustomerInformationDialogComponent,
ExchangeRatesComponent,
ExchangeRatesDialogComponent,
ExtrasTypeComponent,
ExtrasTypeDialogComponent,
FieldsTypeComponent,
FieldsTypeDialogComponent,
GDSComponent,
GDSDialogComponent,
HotelComponent,
HotelDialogComponent,
HotelCodesComponent,
HotelCodesDialogComponent,
IndustrySegmentComponent,
IndustrySegmentDialogComponent,
LanguagesComponent,
LanguagesDialogComponent,
PassengerComponent,
PassengerDialogComponent,
PassengerInformationComponent,
PassengerInformationDialogComponent,
PCCComponent,
PCCDialogComponent,
PNRComponent,
PNRDialogComponent,
PNRCustomFieldsComponent,
PNRCustomFieldsDialogComponent,
ReservationInformationComponent,
ReservationInformationDialogComponent,
RoomTypeComponent,
RoomTypeDialogComponent,
SegmentInformationComponent,
SegmentInformationDialogComponent,
TerminalComponent,
TerminalDialogComponent,


    ConfirmDialogComponent
  ],
  entryComponents: [ConfirmDialogComponent, AccommodationComponent,AccommodationDialogComponent,AccommodationExtrasComponent,AccommodationExtrasDialogComponent,AgencyComponent,AgencyDialogComponent,AgencyGroupComponent,AgencyGroupDialogComponent,AgentInformationComponent,AgentInformationDialogComponent,AirComponent,AirDialogComponent,AirExtrasComponent,AirExtrasDialogComponent,AirlineComponent,AirlineDialogComponent,AirportComponent,AirportDialogComponent,AirSegmentsComponent,AirSegmentsDialogComponent,BrokerComponent,BrokerDialogComponent,carrentComponent,carrentDialogComponent,CarRentalComponent,CarRentalDialogComponent,CarTypeComponent,CarTypeDialogComponent,ChainComponent,ChainDialogComponent,CityComponent,CityDialogComponent,CompanyComponent,CompanyDialogComponent,CompanyCustomFieldsComponent,CompanyCustomFieldsDialogComponent,CompanyDivisionsComponent,CompanyDivisionsDialogComponent,CompanyGroupComponent,CompanyGroupDialogComponent,CountryComponent,CountryDialogComponent,CurrencyComponent,CurrencyDialogComponent,CustomerInformationComponent,CustomerInformationDialogComponent,ExchangeRatesComponent,ExchangeRatesDialogComponent,ExtrasTypeComponent,ExtrasTypeDialogComponent,FieldsTypeComponent,FieldsTypeDialogComponent,GDSComponent,GDSDialogComponent,HotelComponent,HotelDialogComponent,HotelCodesComponent,HotelCodesDialogComponent,IndustrySegmentComponent,IndustrySegmentDialogComponent,LanguagesComponent,LanguagesDialogComponent,PassengerComponent,PassengerDialogComponent,PassengerInformationComponent,PassengerInformationDialogComponent,PCCComponent,PCCDialogComponent,PNRComponent,PNRDialogComponent,PNRCustomFieldsComponent,PNRCustomFieldsDialogComponent,ReservationInformationComponent,ReservationInformationDialogComponent,RoomTypeComponent,RoomTypeDialogComponent,SegmentInformationComponent,SegmentInformationDialogComponent,TerminalComponent,TerminalDialogComponent,]
})

export class AdminModule { }
