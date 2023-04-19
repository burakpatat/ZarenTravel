using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using ZarenTravel.Models.ZarenSoft;

namespace ZarenTravel.Data
{
    public partial class ZarenSoftContext : DbContext
    {
        public ZarenSoftContext()
        {
        }

        public ZarenSoftContext(DbContextOptions<ZarenSoftContext> options) : base(options)
        {
        }

        partial void OnModelBuilding(ModelBuilder builder);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ZarenTravel.Models.ZarenSoft.AgencyContractsConfigurationByHotel>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.Efmigrationshistorydelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.Efmigrationshistorygetall>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.Efmigrationshistorygetbyid>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.Efmigrationshistorygetbyproductversion>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.Efmigrationshistoryinsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.Efmigrationshistoryupdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AgenciesDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AgenciesGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AgenciesGetByAddress>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AgenciesGetByComercialContactId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AgenciesGetByFinanceContactId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AgenciesGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AgenciesGetByMarkUp>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AgenciesGetByName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AgenciesGetByPaymentPolitic>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AgenciesGetByReservationContactId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AgenciesInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AgenciesUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AgencyGroupDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AgencyGroupGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AgencyGroupGetByActive>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AgencyGroupGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AgencyGroupGetByName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AgencyGroupGetByTimestamp>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AgencyGroupGetTimestampBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AgencyGroupInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AgencyGroupUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AgentInformationDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AgentInformationGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AgentInformationGetByAgentName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AgentInformationGetByAgentStation>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AgentinformationgetbyfileId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AgentinformationgetbyfileName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AgentInformationGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AgentInformationGetByRecordDateStamp>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AgentInformationGetRecordDateStampBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AgentInformationInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AgentInformationUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirExtrasDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirExtrasGetAiExTimestampBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirExtrasGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirExtrasGetByAiExActive>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirExtrasGetByAiExDescription>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirExtrasGetByAiExFare>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirExtrasGetByAiExTimestamp>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirExtrasGetByAirId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirExtrasGetByExTyId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirExtrasGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirExtrasInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirExtrasUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirlineDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirlineGetAirlineTimestampBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirlineGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirlineGetByAirlineActive>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirlineGetByAirlineCode>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirlineGetByAirlineName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirlineGetByAirlinePlate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirlineGetByAirlineTimestamp>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirlineGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirlineInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirlineUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirportDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirportGetAirportTimestampBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirportGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirportGetByAirportActive>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirportGetByAirportCode>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirportGetByAirportName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirportGetByAirportTimestamp>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirportGetByCityId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirportGetByCountryId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirportGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirportInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirportUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirsDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirSegmentsDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirSegmentsGetAiSeArrivalBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirSegmentsGetAiSeDepartureBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirSegmentsGetAiSeTimestampBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirSegmentsGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirSegmentsGetByAirId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirSegmentsGetByAirlineId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirSegmentsGetByAirportIdDestination>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirSegmentsGetByAirportIdOrigin>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirSegmentsGetByAiSeActive>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirSegmentsGetByAiSeArrival>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirSegmentsGetByAiSeClass>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirSegmentsGetByAiSeDeparture>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirSegmentsGetByAiSeFlightNumber>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirSegmentsGetByAiSeTimestamp>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirSegmentsGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirSegmentsGetByTerminalIdDestination>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirSegmentsGetByTerminalIdOrigin>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirSegmentsInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirSegmentsUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirsGetAirBookedDateBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirsGetAirIssueddateBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirsGetAirTimestampBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirsGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirsGetByAirActive>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirsGetByAirBookedDate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirsGetByAirFare>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirsGetByAirFareBasis>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirsGetByAirHighestFare>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirsGetByAirIncludeBag>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirsGetByAirIssueddate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirsGetByAirlineId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirsGetByAirLowestFare>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirsGetByAirOriginalTicket>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirsGetByAirRecordAirline>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirsGetByAirReIssued>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirsGetByAirTax>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirsGetByAirTicket>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirsGetByAirTimestamp>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirsGetByBrokerId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirsGetByCurrencyId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirsGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirsGetByPnrId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirsInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirsUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ApiDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ApiGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ApiGetByApiName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ApiGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ApiGetByPassword>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ApiGetByUserKey>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ApiInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ApiResultInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ApiUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AuthorizationTemplateDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AuthorizationTemplateGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AuthorizationTemplateGetByCanDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AuthorizationTemplateGetByCanDetail>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AuthorizationTemplateGetByCanInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AuthorizationTemplateGetByCanList>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AuthorizationTemplateGetByCanRemove>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AuthorizationTemplateGetByCanUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AuthorizationTemplateGetByDatabaseTable>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AuthorizationTemplateGetByDepartment>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AuthorizationTemplateGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AuthorizationTemplateGetByOnLeftMenu>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AuthorizationTemplateGetByProduct>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AuthorizationTemplateGetByUser>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AuthorizationTemplateInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AuthorizationTemplateUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AutoCompletesDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AutoCompletesGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AutoCompletesGetByApiId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AutoCompletesGetByApiSystemId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AutoCompletesGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AutoCompletesGetByName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AutoCompletesGetByType>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AutoCompletesInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AutoCompletesUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AutoCompleteTypesDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AutoCompleteTypesGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AutoCompleteTypesGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AutoCompleteTypesGetByName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AutoCompleteTypesInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AutoCompleteTypesUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BannerDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BannerGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BannerGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BannerGetByImagePath>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BannerGetByLanguageId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BannerGetByMobileImagePath>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BannerGetByTableOrder>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BannerGetByText>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BannerGetByText2>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BannerGetByText3>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BannerInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BannerUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BoardTypeLanguagesDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BoardTypeLanguagesGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BoardTypeLanguagesGetByBoardTypeId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BoardTypeLanguagesGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BoardTypeLanguagesGetByLanguageId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BoardTypeLanguagesGetByName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BoardTypeLanguagesInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BoardTypeLanguagesUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BoardTypesDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BoardTypesGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BoardTypesGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BoardTypesGetByName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BoardTypesInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BoardTypesUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingDealsDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingDealsGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingDealsGetByBookingId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingDealsGetByDealId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingDealsGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingDealsInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingDealsUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingRoomsDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingRoomsGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingRoomsGetByBoardTypeId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingRoomsGetByBookingId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingRoomsGetByCost>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingRoomsGetByHotelRoomId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingRoomsGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingRoomsGetByPrice>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingRoomsInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingRoomsUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingsDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingsGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingsGetByAdult>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingsGetByAgencyId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingsGetByChild>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingsGetByChildrenAge>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingsGetByClientAddress>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingsGetByClientContact>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingsGetByClientEmail>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingsGetByClientName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingsGetByClientNote>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingsGetByClientSurname>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingsGetByClientTitle>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingsGetByDateBooked>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingsGetByFromDate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingsGetByHotelId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingsGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingsGetByInfant>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingsGetByNight>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingsGetByNumRoom>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingsGetByPaidStatus>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingsGetByProviderId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingsGetByReference>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingsGetByStatus>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingsGetByToDate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingsGetByTotalCost>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingsGetByTotalPrice>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingsGetDateBookedBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingsGetFromDateBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingsGetToDateBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingsInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingsUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BrokerDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BrokerGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BrokerGetBrokerTimestampBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BrokerGetByBrokerActive>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BrokerGetByBrokerCode>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BrokerGetByBrokerName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BrokerGetByBrokerTimestamp>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BrokerGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BrokerInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BrokerUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BuyRoomsDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BuyRoomsGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BuyRoomsGetByDescription>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BuyRoomsGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BuyRoomsGetByMaxAdult>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BuyRoomsGetByMaxAllotment>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BuyRoomsGetByMaxChild>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BuyRoomsGetByMaxInfant>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BuyRoomsGetByName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BuyRoomsInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.BuyRoomsUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CancelationLanguagesDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CancelationLanguagesGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CancelationLanguagesGetByCancelationRulesId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CancelationLanguagesGetByDescription>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CancelationLanguagesGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CancelationLanguagesGetByLanguageId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CancelationLanguagesGetByName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CancelationLanguagesInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CancelationLanguagesUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CancellationRulesDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CancellationRulesGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CancellationRulesGetByCancellationSeasonId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CancellationRulesGetByCost>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CancellationRulesGetByCostType>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CancellationRulesGetByFromDay>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CancellationRulesGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CancellationRulesGetByToDay>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CancellationRulesInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CancellationRulesUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CancellationSeasonsDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CancellationSeasonsGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CancellationSeasonsGetByEndDate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CancellationSeasonsGetByHotelId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CancellationSeasonsGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CancellationSeasonsGetByStartDate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CancellationSeasonsGetEndDateBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CancellationSeasonsGetStartDateBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CancellationSeasonsInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CancellationSeasonsUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarRentalsDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarRentalsGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarRentalsGetByCaRtActive>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarRentalsGetByCaRtCode>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarRentalsGetByCaRtName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarRentalsGetByCaRtTimestamp>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarRentalsGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarRentalsGetCaRtTimestampBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarRentalsInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarRentalsUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarRentsDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarRentsGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarRentsGetByAirportIdPickUp>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarRentsGetByAirportIdReturn>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarRentsGetByCaReActive>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarRentsGetByCaReBookDate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarRentsGetByCaRePickUpDate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarRentsGetByCaReRate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarRentsGetByCaReReturnDate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarRentsGetByCaReTax>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarRentsGetByCaReTimestamp>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarRentsGetByCaRtId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarRentsGetByCaTyId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarRentsGetByCurrencyId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarRentsGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarRentsGetByPnrId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarRentsGetCaReBookDateBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarRentsGetCaRePickUpDateBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarRentsGetCaReReturnDateBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarRentsGetCaReTimestampBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarRentsInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarRentsUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarTypesDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarTypesGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarTypesGetByCaTyActive>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarTypesGetByCaTyCode>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarTypesGetByCaTyDescription>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarTypesGetByCaTyTimestamp>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarTypesGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarTypesGetCaTyTimestampBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarTypesInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarTypesUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CitiesDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CitiesGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CitiesGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CitiesGetByLatitude>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CitiesGetByLongitude>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CitiesGetByName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CitiesInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CitiesUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CityModelsDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CityModelsGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CityModelsGetByCityName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CityModelsGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CityModelsInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CityModelsUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CompaniesDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CompaniesGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CompaniesGetByAgencyId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CompaniesGetByCoDiId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CompaniesGetByCoGrId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CompaniesGetByCompanyActive>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CompaniesGetByCompanyCode>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CompaniesGetByCompanyRepresentative>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CompaniesGetByCompanyTimestamp>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CompaniesGetByCountryId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CompaniesGetByCurrencyId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CompaniesGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CompaniesGetByInSeId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CompaniesGetByLanguagesId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CompaniesGetCompanyTimestampBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CompaniesInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CompaniesUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ContactsDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ContactsGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ContactsGetByEmail>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ContactsGetByFaxNumber>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ContactsGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ContactsGetByName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ContactsGetByTelNumber>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ContactsInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ContactsUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CountryDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CountryGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CountryGetByAbbreviation>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CountryGetByArea>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CountryGetByBarcode>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CountryGetByCallingCode>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CountryGetByCity>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CountryGetByContinent>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CountryGetByCostLine>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CountryGetByCurrencyCode>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CountryGetByCurrencyName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CountryGetByDefaultLanguageId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CountryGetByDensity>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CountryGetByDish>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CountryGetByDomainTld>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CountryGetByEast>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CountryGetByElevation>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CountryGetByExpectancy>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CountryGetByFlagBase64>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CountryGetByGovernment>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CountryGetByHasFraudRisk>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CountryGetByHasManuelRegistration>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CountryGetByHeight>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CountryGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CountryGetByIndependence>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CountryGetByIso>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CountryGetByLandlocked>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CountryGetByLanguagesJson>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CountryGetByLocation>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CountryGetByName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CountryGetByNorth>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CountryGetByPopulation>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CountryGetByReligion>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CountryGetByShortName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CountryGetBySouth>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CountryGetBySymbol>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CountryGetByTemperature>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CountryGetByWest>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CountryInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CountryUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CurrencyDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CurrencyGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CurrencyGetByCurrencyActive>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CurrencyGetByCurrencyCode>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CurrencyGetByCurrencyCodeIatum>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CurrencyGetByCurrencyName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CurrencyGetByCurrencyTimestamp>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CurrencyGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CurrencyGetCurrencyTimestampBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CurrencyInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CurrencyUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CustomerInformationDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CustomerInformationGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByAgentCode>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByAlternativeEmailId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByBookingStatus>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByCountryCode>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CustomerinformationgetbycustomeridN>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByDateOfBirth>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByEmailId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByFax>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CustomerinformationgetbyfileId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CustomerinformationgetbyfileName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByFirstName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByGender>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CustomerInformationGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByLanguageCode>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByLastName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByMobile>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByModificationDate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByNationalityCode>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByOfficeTelephone>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByRecordDateStamp>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByTelephone>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByTitle>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByTotalFare>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByTotalInfantcount>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByTotalpaxcount>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByTotalTaxChg>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CustomerInformationGetDateOfBirthBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CustomerInformationGetModificationDateBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CustomerInformationGetRecordDateStampBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CustomerInformationInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.CustomerInformationUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseColumnsDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByCmsColumnTitle>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByCmsInputType>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByColumnName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByDbType>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByErrorDescription>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByHasDefaultValue>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByHasShowedOnList>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByIsFilter>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByIsLanguageField>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByIsNullable>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByIsPrimary>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByIsPublic>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByIsRequired>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByIsRoutingField>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByIsSecondry>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByJsonName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByMaxLength>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByParameterDescription>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByResize>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByReturnColumnNameFromCmsTitle>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetBySelectedDataSourceTable>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetBySelectedText>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetBySelectedValue>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByTableId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByTableOrder>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByTooltip>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseColumnsInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseColumnsUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseTablesDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseTablesGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseTablesGetByCanGenerate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseTablesGetByCmsGridSize>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseTablesGetByCmsIcon>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseTablesGetByCmsLinkedTable>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseTablesGetByCreateDate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseTablesGetByDisplayName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseTablesGetByForUser>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseTablesGetByFrontPageName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseTablesGetByHasMultiLanguage>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseTablesGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseTablesGetByIsRouting>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseTablesGetByParentTable>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseTablesGetByTableName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseTablesGetByTableOrder>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseTablesGetCreateDateBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseTablesInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseTablesUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseValueTypesDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseValueTypesGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseValueTypesGetByFrontEndName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseValueTypesGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseValueTypesGetBySqlName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseValueTypesInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseValueTypesUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatatableCmsInputTypeDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatatableCmsInputTypeGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatatableCmsInputTypeGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatatableCmsInputTypeGetByName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatatableCmsInputTypeInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatatableCmsInputTypeUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DealsDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DealsGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DealsGetByBoardTypeId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DealsGetByDealTypeId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DealsGetByDiscount>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DealsGetByEndDate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DealsGetByFreeNight>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DealsGetByHotelRoomId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DealsGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DealsGetByRelease>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DealsGetByStartDate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DealsGetEndDateBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DealsGetStartDateBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DealsInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DealsUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DealTypeLanguagesDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DealTypeLanguagesGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DealTypeLanguagesGetByDealTypeId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DealTypeLanguagesGetByDescription>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DealTypeLanguagesGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DealTypeLanguagesGetByLanguageId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DealTypeLanguagesGetByName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DealTypeLanguagesInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DealTypeLanguagesUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DealTypesDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DealTypesGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DealTypesGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DealTypesGetByName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DealTypesInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DealTypesUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DynamicJson>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DynamicQuery>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DynamicQueueList>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DynamicSpaceReport>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.Dynamicstatistic>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DynamicTable>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DynamicTableCount>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DynamicTableForeignKey>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DynamicTablePager>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DynamicTableReport>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DynamicTableRow>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DynamicTableSearch>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DynamicTableSearchAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DynamicTableSearchTable>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DynamicTransactionReport>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DynamicUpsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DynamicViewDto>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.DynamicViewReport>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ExchangeRatesDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ExchangeRatesGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ExchangeRatesGetByCurrencyIdFrom>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ExchangeRatesGetByCurrencyIdTo>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ExchangeRatesGetByExRaActive>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ExchangeRatesGetByExRaDate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ExchangeRatesGetByExRaTimestamp>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ExchangeRatesGetByExRaValue>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ExchangeRatesGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ExchangeRatesGetExRaDateBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ExchangeRatesInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ExchangeRatesUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ExtensionsDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ExtensionsGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ExtensionsGetByExtensionName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ExtensionsGetByFilePath>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ExtensionsGetByFileType>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ExtensionsGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ExtensionsGetByIsRealName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ExtensionsGetByKeyName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ExtensionsInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ExtensionsUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ExtrasTypeDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ExtrasTypeGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ExtrasTypeGetByExTyActive>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ExtrasTypeGetByExTyCode>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ExtrasTypeGetByExTyName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ExtrasTypeGetByExTyTimestamp>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ExtrasTypeGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ExtrasTypeGetExTyTimestampBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ExtrasTypeInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ExtrasTypeUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.FacilitiesDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.FacilitiesGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.FacilitiesGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.FacilitiesGetByName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.FacilitiesHotelsDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.FacilitiesHotelsGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.FacilitiesHotelsGetByFacilityId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.FacilitiesHotelsGetByHotelId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.FacilitiesHotelsGetByHotelRoomId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.FacilitiesHotelsGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.FacilitiesHotelsInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.FacilitiesHotelsUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.FacilitiesInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.FacilitiesUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.FacilityLanguagesDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.FacilityLanguagesGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.FacilityLanguagesGetByFacilityId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.FacilityLanguagesGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.FacilityLanguagesGetByLanguageId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.FacilityLanguagesGetByName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.FacilityLanguagesInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.FacilityLanguagesUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.FieldsTypeDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.FieldsTypeGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.FieldsTypeGetByFiTyActive>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.FieldsTypeGetByFiTyCode>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.FieldsTypeGetByFiTyName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.FieldsTypeGetByFiTyTimestamp>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.FieldsTypeGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.FieldsTypeGetFiTyTimestampBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.FieldsTypeInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.FieldsTypeUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.GetColumn>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.GetColumnsWithOutIdentity>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.GetdatawıthpagıngResult>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.GetDependency>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.GetExtended>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.GetExtendedInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.GetExtendedRemove>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.GetGroupBy>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.GetIdentityList>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.GetIndexStat>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.GetModifyDate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.GetPager>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.GetParameterName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.GetProcedureName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.GetRequestParameterName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.GetReturnParameterName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.GetSearchWithList>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.GetServerInfo>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.GetSpLog>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.GetStoredProceduresForATable>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.GetTableColumn>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.GetTableFk>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.GetTableInfo>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.GetTableName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.GetTable>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.GetTableSize>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.GetViewBackupHistory>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.GetViewList>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HeaderColorDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HeaderColorGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HeaderColorGetByColor>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HeaderColorGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HeaderColorGetByName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HeaderColorGetByPath>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HeaderColorInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HeaderColorUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelAgencyMarkupsDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelAgencyMarkupsGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelAgencyMarkupsGetByAgencyId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelAgencyMarkupsGetByEndDate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelAgencyMarkupsGetByHotelId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelAgencyMarkupsGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelAgencyMarkupsGetByMarkUp>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelAgencyMarkupsGetByStartDate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelAgencyMarkupsGetEndDateBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelAgencyMarkupsGetStartDateBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelAgencyMarkupsInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelAgencyMarkupsUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelBuyRoomAllotmentDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelBuyRoomAllotmentGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelBuyRoomAllotmentGetByAllotment>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelBuyRoomAllotmentGetByDay>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelBuyRoomAllotmentGetByHotelBuyRoomId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelBuyRoomAllotmentGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelBuyRoomAllotmentGetByRelease>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelBuyRoomAllotmentGetByStopSale>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelBuyRoomAllotmentGetDayBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelBuyRoomAllotmentInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelBuyRoomAllotmentUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelBuyRoomsDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelBuyRoomsGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelBuyRoomsGetByBuyRoomId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelBuyRoomsGetByHotelId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelBuyRoomsGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelBuyRoomsInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelBuyRoomsUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelChainsDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelChainsGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelChainsGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelChainsGetByName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelChainsInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelChainsUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelDescriptionsDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelDescriptionsGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelDescriptionsGetByDescription>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelDescriptionsGetByHotelId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelDescriptionsGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelDescriptionsGetByLanguageId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelDescriptionsInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelDescriptionsUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelPhotoLanguagesDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelPhotoLanguagesGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelPhotoLanguagesGetByDescription>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelPhotoLanguagesGetByHotelPhotoId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelPhotoLanguagesGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelPhotoLanguagesGetByLanguageId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelPhotoLanguagesInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelPhotoLanguagesUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelPhotosDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelPhotosGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelPhotosGetByHotelId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelPhotosGetByHotelRoomId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelPhotosGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelPhotosGetByOrder>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelPhotosGetByPath>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelPhotosInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelPhotosUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelRoomDailyPricesDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelRoomDailyPricesGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelRoomDailyPricesGetByBoardTypeId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelRoomDailyPricesGetByCost>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelRoomDailyPricesGetByDay>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelRoomDailyPricesGetByHotelRoomId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelRoomDailyPricesGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelRoomDailyPricesGetByStopSale>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelRoomDailyPricesGetDayBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelRoomDailyPricesInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelRoomDailyPricesUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelRoomLanguagesDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelRoomLanguagesGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelRoomLanguagesGetByDescription>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelRoomLanguagesGetByHotelRoomId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelRoomLanguagesGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelRoomLanguagesGetByLanguageId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelRoomLanguagesGetByName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelRoomLanguagesInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelRoomLanguagesUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelRoomsDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelRoomsGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelRoomsGetByAdult>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelRoomsGetByChild>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelRoomsGetByHotelBuyRoomId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelRoomsGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelRoomsGetByInfant>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelRoomsGetByName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelRoomsGetByRoomId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelRoomsInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelRoomsUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelsDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelSeasonsGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelSeasonsInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelsGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelsGetByAddress>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelsGetByCityId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelsGetByCommercialContactId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelsGetByCountryId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelsGetByFinanceContactId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelsGetByHotelChainId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelsGetByHotelTypeId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelsGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelsGetByLatitude>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelsGetByLongitude>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelsGetByName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelsGetByNumberRoom>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelsGetByRegionId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelsGetByRelease>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelsGetByReservationContactId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelsGetByZipCode>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelsGetByZoneId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelsInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelsUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelTypeLanguagesDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelTypeLanguagesGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelTypeLanguagesGetByHotelTypeId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelTypeLanguagesGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelTypeLanguagesGetByLanguageId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelTypeLanguagesGetByName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelTypeLanguagesInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelTypeLanguagesUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelTypesDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelTypesGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelTypesGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelTypesGetByName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelTypesInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelTypesUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LanguagesDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LanguagesGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LanguagesGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LanguagesGetByName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LanguagesInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LanguagesUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LogPermissionsDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LogPermissionsGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LogPermissionsGetByCanClassInit>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LogPermissionsGetByCanClassInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LogPermissionsGetByCanClassList>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LogPermissionsGetByCanClassUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LogPermissionsGetByCanDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LogPermissionsGetByCanGetList>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LogPermissionsGetByCanGetOne>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LogPermissionsGetByCanInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LogPermissionsGetByCanUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LogPermissionsGetByCanView>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LogPermissionsGetByChangeDate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LogPermissionsGetByDatabaseTable>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LogPermissionsGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LogPermissionsGetByModifyBy>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LogPermissionsGetByModifyDate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LogPermissionsGetByNote>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LogPermissionsGetByProduct>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LogPermissionsGetByUserId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LogPermissionsGetChangeDateBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LogPermissionsGetModifyDateBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LogPermissionsInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LogPermissionsUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LogsDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LogsGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LogsGetByDate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LogsGetByDescription>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LogsGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LogsGetByLogMethod>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LogsGetByLogPath>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LogsGetByType>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LogsGetByUrlOriginalString>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LogsGetByUserAgent>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LogsGetByUserHostAddress>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LogsGetByUserId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LogsGetDateBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LogsInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.LogsUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.MenuDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.MenuGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.MenuGetByColor>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.MenuGetByIcon>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.MenuGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.MenuGetByTitle>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.MenuGetByTitleArabic>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.MenuGetByTitleEng>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.MenuGetByUrl>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.MenuInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.MenuUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.OgSeoDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.OgSeoGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.OgSeoGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.OgSeoGetByogDescription>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.OgSeoGetByogImage>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.OgSeoGetByogTitle>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.OgSeoGetByPageId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.OgSeoGetByPageType>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.OgSeoGetByseoDescription>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.OgSeoGetByseoKeyword>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.OgSeoGetByseoTitle>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.OgSeoInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.OgSeoUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PageContentDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PageContentGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PageContentGetByContent>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PageContentGetByCreateDate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PageContentGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PageContentGetByImage>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PageContentGetByLanguageId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PageContentGetByPageUrl>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PageContentGetBySubTitle>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PageContentGetByTableOrder>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PageContentGetByTitle>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PageContentGetCreateDateBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PageContentInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PageContentUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PageTypesDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PageTypesGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PageTypesGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PageTypesGetByName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PageTypesInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PageTypesUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PassengerInformationDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PassengerInformationGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PassengerInformationGetByAdultId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PassengerinformationgetbyfileId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PassengerinformationgetbyfileName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PassengerInformationGetByFirstName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PassengerInformationGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PassengerInformationGetByLastName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PassengerInformationGetByNationalityCode>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PassengerInformationGetByPaxSequence>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PassengerInformationGetByPnrpaxId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PassengerInformationGetByRecordDateStamp>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PassengerInformationGetByTitle>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PassengerInformationGetByTotalFare>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PassengerInformationGetByTotalPaid>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PassengerInformationGetByTotalTaxchg>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PassengerInformationGetRecordDateStampBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PassengerInformationInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PassengerInformationUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PassengersDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PassengersGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PassengersGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PassengersGetByPassemgerTimestamp>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PassengersGetByPassengerActive>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PassengersGetByPassengerCelPhone>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PassengersGetByPassengerEmail>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PassengersGetByPassengerFullName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PassengersGetByPassengerJobPosition>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PassengersGetByPassengerPhone>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PassengersGetByPassengerVıp>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PassengersGetPassemgerTimestampBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PassengersInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PassengersUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PnrCustomFieldsDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PnrCustomFieldsGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PnrCustomFieldsGetByFiTyActive>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PnrCustomFieldsGetByFiTyId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PnrCustomFieldsGetByFiTyTimestamp>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PnrCustomFieldsGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PnrCustomFieldsGetByPnCuValue>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PnrCustomFieldsGetByPnrId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PnrCustomFieldsGetFiTyTimestampBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PnrCustomFieldsInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PnrCustomFieldsUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PnRsDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PnRsGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PnRsGetByAgencyId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PnRsGetByCompanyId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PnRsGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PnRsGetByPassengerId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PnRsGetByPccId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PnRsGetByPnrActive>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PnRsGetByPnrRecord>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PnRsGetByPnrTimestamp>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PnRsGetPnrTimestampBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PnRsInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PnRsUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PossibleQueryDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PossibleQueryGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PossibleQueryGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PossibleQueryGetByQuery>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PossibleQueryInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.PossibleQueryUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ProvidersDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ProvidersGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ProvidersGetByAddress>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ProvidersGetByComercialContactId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ProvidersGetByFinanceContactId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ProvidersGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ProvidersGetByName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ProvidersGetByReservationContactId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ProvidersGetByWebsite>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ProvidersInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ProvidersUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ProvienceDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ProvienceGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ProvienceGetByCityId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ProvienceGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ProvienceGetByInformation>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ProvienceGetByListImage>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ProvienceGetByName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ProvienceGetByStatu>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ProvienceGetByTableOrder>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ProvienceInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ProvienceUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.RegionsDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.RegionsGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.RegionsGetByCountryId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.RegionsGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.RegionsGetByLatLongBound>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.RegionsGetByName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.RegionsInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.RegionsUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ReservationDetailsDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ReservationDetailsGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ReservationDetailsGetByApartPrice>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ReservationDetailsGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ReservationDetailsGetByPropertId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ReservationDetailsGetByPropertPrice>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ReservationDetailsGetByRezervationId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ReservationDetailsInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ReservationDetailsUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ReservationsDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ReservationsGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ReservationsGetByApartId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ReservationsGetByCustomerId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ReservationsGetByFinishDate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ReservationsGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ReservationsGetByNote>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ReservationsGetByPaymentCompleted>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ReservationsGetByPaymentType>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ReservationsGetByReferenceCode>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ReservationsGetByStartDate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ReservationsGetByTotalPrice>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ReservationsGetFinishDateBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ReservationsGetStartDateBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ReservationsInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ReservationsUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.RoomsDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.RoomsGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.RoomsGetByAdult>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.RoomsGetByChild>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.RoomsGetByDescription>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.RoomsGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.RoomsGetByInfant>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.RoomsGetByName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.RoomsInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.RoomsUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.StatusDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.StatusGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.StatusGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.StatusGetByName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.StatusInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.StatusUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierBuyingDestinationsDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierBuyingDestinationsGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierBuyingDestinationsGetByAgencyId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierBuyingDestinationsGetByCity>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierBuyingDestinationsGetByCountry>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierBuyingDestinationsGetByCreatedBy>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierBuyingDestinationsGetByCreatedDate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierBuyingDestinationsGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierBuyingDestinationsGetByTableOrder>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierBuyingDestinationsGetByUpdatedBy>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierBuyingDestinationsGetByUpdatedDate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierBuyingDestinationsGetCreatedDateBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierBuyingDestinationsGetUpdatedDateBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierBuyingDestinationsInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierBuyingDestinationsUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierFeesDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierFeesGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierFeesGetByAmount>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierFeesGetByByPercentage>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierFeesGetByCreatedBy>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierFeesGetByCreatedDate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierFeesGetByCurrencyId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierFeesGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierFeesGetByProductId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierFeesGetBySupplierId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierFeesGetByUpdatedBy>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierFeesGetByUpdatedDate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierFeesGetCreatedDateBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierFeesGetUpdatedDateBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierFeesInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierFeesUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierProductTypeDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierProductTypeGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierProductTypeGetByCreatedBy>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierProductTypeGetByCreatedDate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierProductTypeGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierProductTypeGetByName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierProductTypeGetByUpdatedBy>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierProductTypeGetByUpdatedDate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierProductTypeGetCreatedDateBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierProductTypeGetUpdatedDateBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierProductTypeInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierProductTypeUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierRegisteredProductsDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierRegisteredProductsGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierRegisteredProductsGetByContractInfo>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierRegisteredProductsGetByCreatedBy>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierRegisteredProductsGetByCreatedDate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierRegisteredProductsGetByFee>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierRegisteredProductsGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierRegisteredProductsGetByProductTypeId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierRegisteredProductsGetBySupplierId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierRegisteredProductsGetByUpdatedBy>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierRegisteredProductsGetByUpdatedDate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierRegisteredProductsGetCreatedDateBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierRegisteredProductsGetUpdatedDateBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierRegisteredProductsInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierRegisteredProductsUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SuppliersDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierSellingDestinationsDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierSellingDestinationsGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierSellingDestinationsGetByCity>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierSellingDestinationsGetByCountry>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierSellingDestinationsGetByCreatedBy>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierSellingDestinationsGetByCreatedDate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierSellingDestinationsGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierSellingDestinationsGetBySupplierId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierSellingDestinationsGetByTableOrder>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierSellingDestinationsGetByUpdatedBy>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierSellingDestinationsGetByUpdatedDate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierSellingDestinationsGetCreatedDateBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierSellingDestinationsGetUpdatedDateBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierSellingDestinationsInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierSellingDestinationsUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SuppliersGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SuppliersGetByAcceptProduct>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SuppliersGetByAcceptReseller>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SuppliersGetByAcceptSupplier>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SuppliersGetByBriefDescription>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SuppliersGetByCreatedBy>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SuppliersGetByCreatedDate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SuppliersGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SuppliersGetByIsReseller>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SuppliersGetByIsSupplier>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SuppliersGetByLogo>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SuppliersGetByName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SuppliersGetBySourceMarketCountryId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SuppliersGetBySupplierId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SuppliersGetBySupplierTypeId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SuppliersGetByUpdatedBy>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SuppliersGetByUpdatedDate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SuppliersGetByWebsite>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SuppliersGetCreatedDateBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SuppliersGetUpdatedDateBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SuppliersInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SuppliersUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierTypeDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierTypeGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierTypeGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierTypeGetByName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierTypeInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.SupplierTypeUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.TerminalDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.TerminalGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.TerminalGetByAirportId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.TerminalGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.TerminalGetByTerminalActive>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.TerminalGetByTerminalCode>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.TerminalGetByTerminalName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.TerminalGetByTerminalTimestamp>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.TerminalGetTerminalTimestampBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.TerminalInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.TerminalUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ThemeStyleDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ThemeStyleGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ThemeStyleGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ThemeStyleGetByName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ThemeStyleGetByPath>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ThemeStyleGetByProperty>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ThemeStyleInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ThemeStyleUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UrlsDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UrlsGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UrlsGetByFriendlyUrl>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UrlsGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UrlsGetByIsDefault>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UrlsGetByLanguageId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UrlsGetByPageId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UrlsGetByPageName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UrlsGetByPageView>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UrlsInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UrlsUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UserPreferencesDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UserPreferencesGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UserPreferencesGetByHeaderColor>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UserPreferencesGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UserPreferencesGetByProduct>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UserPreferencesGetBySideBarColor>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UserPreferencesGetByThemeStyle>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UserPreferencesGetByUserId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UserPreferencesInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UserPreferencesUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UsersDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UsersGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UsersGetBirthDateBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UsersGetByBirthDate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UsersGetByBirthPlace>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UsersGetByCreateDate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UsersGetByEmail>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UsersGetByGender>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UsersGetByGovernmentId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UsersGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UsersGetByIsMaster>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UsersGetByIsSuperAdmin>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UsersGetByMaritalStatus>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UsersGetByMotherName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UsersGetByName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UsersGetByPassword>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UsersGetByProduct>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UsersGetByStatus>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UsersGetBySurname>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UsersGetByUserName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UsersGetByUserType>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UsersGetCreateDateBetween>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UsersInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UsersUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UserTypeDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UserTypeGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UserTypeGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UserTypeGetByName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UserTypeInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.UserTypeUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.YesNoDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.YesNoGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.YesNoGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.YesNoGetByName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.YesNoInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.YesNoUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ZonesCitiesDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ZonesCitiesGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ZonesCitiesGetByCityId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ZonesCitiesGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ZonesCitiesGetByMainZone>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ZonesCitiesGetByZoneId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ZonesCitiesInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ZonesCitiesUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ZonesDelete>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ZonesGetAll>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ZonesGetById>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ZonesGetByLatLongBound>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ZonesGetByName>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ZonesGetByRegionId>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ZonesInsert>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.ZonesUpdate>().HasNoKey();

            builder.Entity<ZarenTravel.Models.ZarenSoft.AgentInformation>().HasKey(table => new {
                table.Id, table.AgentCode
            });

            builder.Entity<ZarenTravel.Models.ZarenSoft.CustomerInformation>().HasKey(table => new {
                table.Id, table.CustomerId
            });

            builder.Entity<ZarenTravel.Models.ZarenSoft.PassengerInformation>().HasKey(table => new {
                table.Id, table.Pnr
            });

            builder.Entity<ZarenTravel.Models.ZarenSoft.Agency>()
              .HasOne(i => i.Contact)
              .WithMany(i => i.Agencies)
              .HasForeignKey(i => i.ComercialContactId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.Agency>()
              .HasOne(i => i.Contact1)
              .WithMany(i => i.Agencies1)
              .HasForeignKey(i => i.FinanceContactId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.Agency>()
              .HasOne(i => i.AgencyGroup)
              .WithMany(i => i.Agencies)
              .HasForeignKey(i => i.Id)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.Agency>()
              .HasOne(i => i.Contact2)
              .WithMany(i => i.Agencies2)
              .HasForeignKey(i => i.ReservationContactId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirExtra>()
              .HasOne(i => i.Air)
              .WithMany(i => i.AirExtras)
              .HasForeignKey(i => i.AirId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirExtra>()
              .HasOne(i => i.ExtrasType)
              .WithMany(i => i.AirExtras)
              .HasForeignKey(i => i.ExTyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.Airport>()
              .HasOne(i => i.Country)
              .WithMany(i => i.Airports)
              .HasForeignKey(i => i.CountryId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.Air>()
              .HasOne(i => i.Airline)
              .WithMany(i => i.Airs)
              .HasForeignKey(i => i.AirlineId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.Air>()
              .HasOne(i => i.Broker)
              .WithMany(i => i.Airs)
              .HasForeignKey(i => i.BrokerId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.Air>()
              .HasOne(i => i.Currency1)
              .WithMany(i => i.Airs)
              .HasForeignKey(i => i.CurrencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirSegment>()
              .HasOne(i => i.Air)
              .WithMany(i => i.AirSegments)
              .HasForeignKey(i => i.AirId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirSegment>()
              .HasOne(i => i.Airline)
              .WithMany(i => i.AirSegments)
              .HasForeignKey(i => i.AirlineId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirSegment>()
              .HasOne(i => i.Airport)
              .WithMany(i => i.AirSegments)
              .HasForeignKey(i => i.AirportIdDestination)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirSegment>()
              .HasOne(i => i.Airport1)
              .WithMany(i => i.AirSegments1)
              .HasForeignKey(i => i.AirportIdOrigin)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirSegment>()
              .HasOne(i => i.Terminal)
              .WithMany(i => i.AirSegments)
              .HasForeignKey(i => i.TerminalIdDestination)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.AirSegment>()
              .HasOne(i => i.Terminal1)
              .WithMany(i => i.AirSegments1)
              .HasForeignKey(i => i.TerminalIdOrigin)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.AutoComplete>()
              .HasOne(i => i.Api)
              .WithMany(i => i.AutoCompletes)
              .HasForeignKey(i => i.ApiId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.AutoComplete>()
              .HasOne(i => i.AutoCompleteType)
              .WithMany(i => i.AutoCompletes)
              .HasForeignKey(i => i.Type)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.BoardTypeLanguage>()
              .HasOne(i => i.BoardType)
              .WithMany(i => i.BoardTypeLanguages)
              .HasForeignKey(i => i.BoardTypeId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.BoardTypeLanguage>()
              .HasOne(i => i.Language)
              .WithMany(i => i.BoardTypeLanguages)
              .HasForeignKey(i => i.LanguageId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingDeal>()
              .HasOne(i => i.Booking)
              .WithMany(i => i.BookingDeals)
              .HasForeignKey(i => i.BookingId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingDeal>()
              .HasOne(i => i.Deal)
              .WithMany(i => i.BookingDeals)
              .HasForeignKey(i => i.DealId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingRoom>()
              .HasOne(i => i.BoardType)
              .WithMany(i => i.BookingRooms)
              .HasForeignKey(i => i.BoardTypeId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingRoom>()
              .HasOne(i => i.Booking)
              .WithMany(i => i.BookingRooms)
              .HasForeignKey(i => i.BookingId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.BookingRoom>()
              .HasOne(i => i.HotelRoom)
              .WithMany(i => i.BookingRooms)
              .HasForeignKey(i => i.HotelRoomId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.Booking>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.Bookings)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.Booking>()
              .HasOne(i => i.Hotel)
              .WithMany(i => i.Bookings)
              .HasForeignKey(i => i.HotelId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.Booking>()
              .HasOne(i => i.Provider)
              .WithMany(i => i.Bookings)
              .HasForeignKey(i => i.ProviderId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.CancelationLanguage>()
              .HasOne(i => i.CancellationRule)
              .WithMany(i => i.CancelationLanguages)
              .HasForeignKey(i => i.CancelationRulesId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.CancelationLanguage>()
              .HasOne(i => i.Language)
              .WithMany(i => i.CancelationLanguages)
              .HasForeignKey(i => i.LanguageId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.CancellationRule>()
              .HasOne(i => i.CancellationSeason)
              .WithMany(i => i.CancellationRules)
              .HasForeignKey(i => i.CancellationSeasonId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.CancellationSeason>()
              .HasOne(i => i.Hotel)
              .WithMany(i => i.CancellationSeasons)
              .HasForeignKey(i => i.HotelId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarRent>()
              .HasOne(i => i.Airport)
              .WithMany(i => i.CarRents)
              .HasForeignKey(i => i.AirportIdPickUp)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarRent>()
              .HasOne(i => i.Airport1)
              .WithMany(i => i.CarRents1)
              .HasForeignKey(i => i.AirportIdReturn)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarRent>()
              .HasOne(i => i.CarRental)
              .WithMany(i => i.CarRents)
              .HasForeignKey(i => i.CaRtId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarRent>()
              .HasOne(i => i.CarType)
              .WithMany(i => i.CarRents)
              .HasForeignKey(i => i.CaTyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.CarRent>()
              .HasOne(i => i.Currency1)
              .WithMany(i => i.CarRents)
              .HasForeignKey(i => i.CurrencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.Company>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.Companies)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.Company>()
              .HasOne(i => i.Country)
              .WithMany(i => i.Companies)
              .HasForeignKey(i => i.CountryId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.Company>()
              .HasOne(i => i.Currency1)
              .WithMany(i => i.Companies)
              .HasForeignKey(i => i.CurrencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.Company>()
              .HasOne(i => i.Language)
              .WithMany(i => i.Companies)
              .HasForeignKey(i => i.LanguagesId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseColumn>()
              .HasOne(i => i.DatabaseValueType)
              .WithMany(i => i.DatabaseColumns)
              .HasForeignKey(i => i.DbType)
              .HasPrincipalKey(i => i.ID);

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseColumn>()
              .HasOne(i => i.DatabaseTable)
              .WithMany(i => i.DatabaseColumns)
              .HasForeignKey(i => i.TableID)
              .HasPrincipalKey(i => i.ID);

            builder.Entity<ZarenTravel.Models.ZarenSoft.Deal>()
              .HasOne(i => i.BoardType)
              .WithMany(i => i.Deals)
              .HasForeignKey(i => i.BoardTypeId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.Deal>()
              .HasOne(i => i.DealType)
              .WithMany(i => i.Deals)
              .HasForeignKey(i => i.DealTypeId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.Deal>()
              .HasOne(i => i.HotelRoom)
              .WithMany(i => i.Deals)
              .HasForeignKey(i => i.HotelRoomId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.DealTypeLanguage>()
              .HasOne(i => i.DealType)
              .WithMany(i => i.DealTypeLanguages)
              .HasForeignKey(i => i.DealTypeId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.DealTypeLanguage>()
              .HasOne(i => i.Language)
              .WithMany(i => i.DealTypeLanguages)
              .HasForeignKey(i => i.LanguageId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.ExchangeRate>()
              .HasOne(i => i.Currency1)
              .WithMany(i => i.ExchangeRates)
              .HasForeignKey(i => i.CurrencyIdFrom)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.ExchangeRate>()
              .HasOne(i => i.Currency11)
              .WithMany(i => i.ExchangeRates1)
              .HasForeignKey(i => i.CurrencyIdTo)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.FacilitiesHotel>()
              .HasOne(i => i.Facility)
              .WithMany(i => i.FacilitiesHotels)
              .HasForeignKey(i => i.FacilityId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.FacilitiesHotel>()
              .HasOne(i => i.Hotel)
              .WithMany(i => i.FacilitiesHotels)
              .HasForeignKey(i => i.HotelId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.FacilitiesHotel>()
              .HasOne(i => i.HotelRoom)
              .WithMany(i => i.FacilitiesHotels)
              .HasForeignKey(i => i.HotelRoomId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.FacilityLanguage>()
              .HasOne(i => i.Facility)
              .WithMany(i => i.FacilityLanguages)
              .HasForeignKey(i => i.FacilityId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.FacilityLanguage>()
              .HasOne(i => i.Language)
              .WithMany(i => i.FacilityLanguages)
              .HasForeignKey(i => i.LanguageId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelAgencyMarkup>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.HotelAgencyMarkups)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelAgencyMarkup>()
              .HasOne(i => i.Hotel)
              .WithMany(i => i.HotelAgencyMarkups)
              .HasForeignKey(i => i.HotelId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelBuyRoomAllotment>()
              .HasOne(i => i.HotelBuyRoom)
              .WithMany(i => i.HotelBuyRoomAllotments)
              .HasForeignKey(i => i.HotelBuyRoomId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelBuyRoom>()
              .HasOne(i => i.BuyRoom)
              .WithMany(i => i.HotelBuyRooms)
              .HasForeignKey(i => i.BuyRoomId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelBuyRoom>()
              .HasOne(i => i.Hotel)
              .WithMany(i => i.HotelBuyRooms)
              .HasForeignKey(i => i.HotelId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelDescription>()
              .HasOne(i => i.Hotel)
              .WithMany(i => i.HotelDescriptions)
              .HasForeignKey(i => i.HotelId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelDescription>()
              .HasOne(i => i.Language)
              .WithMany(i => i.HotelDescriptions)
              .HasForeignKey(i => i.LanguageId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelPhotoLanguage>()
              .HasOne(i => i.HotelPhoto)
              .WithMany(i => i.HotelPhotoLanguages)
              .HasForeignKey(i => i.HotelPhotoId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelPhotoLanguage>()
              .HasOne(i => i.Language)
              .WithMany(i => i.HotelPhotoLanguages)
              .HasForeignKey(i => i.LanguageId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelPhoto>()
              .HasOne(i => i.Hotel)
              .WithMany(i => i.HotelPhotos)
              .HasForeignKey(i => i.HotelId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelPhoto>()
              .HasOne(i => i.HotelRoom)
              .WithMany(i => i.HotelPhotos)
              .HasForeignKey(i => i.HotelRoomId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelRoomDailyPrice>()
              .HasOne(i => i.BoardType)
              .WithMany(i => i.HotelRoomDailyPrices)
              .HasForeignKey(i => i.BoardTypeId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelRoomDailyPrice>()
              .HasOne(i => i.HotelRoom)
              .WithMany(i => i.HotelRoomDailyPrices)
              .HasForeignKey(i => i.HotelRoomId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelRoomLanguage>()
              .HasOne(i => i.HotelRoom)
              .WithMany(i => i.HotelRoomLanguages)
              .HasForeignKey(i => i.HotelRoomId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelRoomLanguage>()
              .HasOne(i => i.Language)
              .WithMany(i => i.HotelRoomLanguages)
              .HasForeignKey(i => i.LanguageId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelRoom>()
              .HasOne(i => i.Room)
              .WithMany(i => i.HotelRooms)
              .HasForeignKey(i => i.RoomId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.Hotel>()
              .HasOne(i => i.City)
              .WithMany(i => i.Hotels)
              .HasForeignKey(i => i.CityId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.Hotel>()
              .HasOne(i => i.Contact)
              .WithMany(i => i.Hotels)
              .HasForeignKey(i => i.CommercialContactId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.Hotel>()
              .HasOne(i => i.Country)
              .WithMany(i => i.Hotels)
              .HasForeignKey(i => i.CountryId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.Hotel>()
              .HasOne(i => i.Contact1)
              .WithMany(i => i.Hotels1)
              .HasForeignKey(i => i.FinanceContactId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.Hotel>()
              .HasOne(i => i.HotelChain)
              .WithMany(i => i.Hotels)
              .HasForeignKey(i => i.HotelChainId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.Hotel>()
              .HasOne(i => i.HotelType)
              .WithMany(i => i.Hotels)
              .HasForeignKey(i => i.HotelTypeId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.Hotel>()
              .HasOne(i => i.Region)
              .WithMany(i => i.Hotels)
              .HasForeignKey(i => i.RegionId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.Hotel>()
              .HasOne(i => i.Contact2)
              .WithMany(i => i.Hotels2)
              .HasForeignKey(i => i.ReservationContactId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.Hotel>()
              .HasOne(i => i.Zone)
              .WithMany(i => i.Hotels)
              .HasForeignKey(i => i.ZoneId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelTypeLanguage>()
              .HasOne(i => i.HotelType)
              .WithMany(i => i.HotelTypeLanguages)
              .HasForeignKey(i => i.HotelTypeId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.HotelTypeLanguage>()
              .HasOne(i => i.Language)
              .WithMany(i => i.HotelTypeLanguages)
              .HasForeignKey(i => i.LanguageId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.PnrCustomField>()
              .HasOne(i => i.FieldsType)
              .WithMany(i => i.PnrCustomFields)
              .HasForeignKey(i => i.FiTyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.PnR>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.PnRs)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.PnR>()
              .HasOne(i => i.Company)
              .WithMany(i => i.PnRs)
              .HasForeignKey(i => i.CompanyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.PnR>()
              .HasOne(i => i.Passenger)
              .WithMany(i => i.PnRs)
              .HasForeignKey(i => i.PassengerId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.Provider>()
              .HasOne(i => i.Contact)
              .WithMany(i => i.Providers)
              .HasForeignKey(i => i.ComercialContactId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.Provider>()
              .HasOne(i => i.Contact1)
              .WithMany(i => i.Providers1)
              .HasForeignKey(i => i.FinanceContactId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.Provider>()
              .HasOne(i => i.Contact2)
              .WithMany(i => i.Providers2)
              .HasForeignKey(i => i.ReservationContactId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.ReservationDetail>()
              .HasOne(i => i.Reservation)
              .WithMany(i => i.ReservationDetails)
              .HasForeignKey(i => i.RezervationID)
              .HasPrincipalKey(i => i.ID);

            builder.Entity<ZarenTravel.Models.ZarenSoft.Terminal>()
              .HasOne(i => i.Airport)
              .WithMany(i => i.Terminals)
              .HasForeignKey(i => i.AirportId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.UserPreference>()
              .HasOne(i => i.User)
              .WithMany(i => i.UserPreferences)
              .HasForeignKey(i => i.UserID)
              .HasPrincipalKey(i => i.ID);

            builder.Entity<ZarenTravel.Models.ZarenSoft.User>()
              .HasOne(i => i.UserType1)
              .WithMany(i => i.Users)
              .HasForeignKey(i => i.UserType)
              .HasPrincipalKey(i => i.ID);

            builder.Entity<ZarenTravel.Models.ZarenSoft.Zone>()
              .HasOne(i => i.Region)
              .WithMany(i => i.Zones)
              .HasForeignKey(i => i.RegionId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.ZonesCity>()
              .HasOne(i => i.City)
              .WithMany(i => i.ZonesCities)
              .HasForeignKey(i => i.CityId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.ZonesCity>()
              .HasOne(i => i.Zone)
              .WithMany(i => i.ZonesCities)
              .HasForeignKey(i => i.ZoneId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.MarketPlaceBuyingDestination>()
              .HasOne(i => i.MarketPlacesProfile)
              .WithMany(i => i.MarketPlaceBuyingDestinations)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.MarketPlaceFee>()
              .HasOne(i => i.MarketPlacesProfile)
              .WithMany(i => i.MarketPlaceFees)
              .HasForeignKey(i => i.MarketPlaceProfileId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.MarketPlacesProfile>()
              .HasOne(i => i.MarketPlaceType)
              .WithMany(i => i.MarketPlacesProfiles)
              .HasForeignKey(i => i.MarketPlaceTypeId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.MarketPlacesProfile>()
              .HasOne(i => i.MarketPlacesProfile1)
              .WithMany(i => i.MarketPlacesProfiles1)
              .HasForeignKey(i => i.ParentId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.MarketPlaceSellingDestination>()
              .HasOne(i => i.MarketPlacesProfile)
              .WithMany(i => i.MarketPlaceSellingDestinations)
              .HasForeignKey(i => i.SupplierId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravel.Models.ZarenSoft.AgentInformation>()
              .Property(p => p.RecordDateStamp)
              .HasDefaultValueSql(@"('getdate()')");

            builder.Entity<ZarenTravel.Models.ZarenSoft.DatabaseTable>()
              .Property(p => p.CreateDate)
              .HasDefaultValueSql(@"(getdate())");

            builder.Entity<ZarenTravel.Models.ZarenSoft.PassengerInformation>()
              .Property(p => p.RecordDateStamp)
              .HasDefaultValueSql(@"('getdate()')");
            this.OnModelBuilding(builder);
        }

        public DbSet<ZarenTravel.Models.ZarenSoft.Agency> Agencies { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyGroup> AgencyGroups { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgentInformation> AgentInformations { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirExtra> AirExtras { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.Airline> Airlines { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.Airport> Airports { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.Air> Airs { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirSegment> AirSegments { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.Api> Apis { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AuthorizationTemplate> AuthorizationTemplates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AutoComplete> AutoCompletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AutoCompleteType> AutoCompleteTypes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.Banner> Banners { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BoardTypeLanguage> BoardTypeLanguages { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BoardType> BoardTypes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingDeal> BookingDeals { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingRoom> BookingRooms { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.Booking> Bookings { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.Broker> Brokers { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BuyRoom> BuyRooms { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CancelationLanguage> CancelationLanguages { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CancellationRule> CancellationRules { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CancellationSeason> CancellationSeasons { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarRental> CarRentals { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarRent> CarRents { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarType> CarTypes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.City> Cities { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CityModel> CityModels { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.Company> Companies { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.Contact> Contacts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.Country> Countries { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.Currency1> Currency1S { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CustomerInformation> CustomerInformations { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseColumn> DatabaseColumns { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseTable> DatabaseTables { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseValueType> DatabaseValueTypes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatatableCmsInputType> DatatableCmsInputTypes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.Deal> Deals { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DealTypeLanguage> DealTypeLanguages { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DealType> DealTypes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ExchangeRate> ExchangeRates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.Extension> Extensions { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ExtrasType> ExtrasTypes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.Facility> Facilities { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.FacilitiesHotel> FacilitiesHotels { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.FacilityLanguage> FacilityLanguages { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.FieldsType> FieldsTypes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HeaderColor> HeaderColors { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelAgencyMarkup> HotelAgencyMarkups { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelBuyRoomAllotment> HotelBuyRoomAllotments { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelBuyRoom> HotelBuyRooms { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelChain> HotelChains { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelDescription> HotelDescriptions { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelPhotoLanguage> HotelPhotoLanguages { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelPhoto> HotelPhotos { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelRoomDailyPrice> HotelRoomDailyPrices { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelRoomLanguage> HotelRoomLanguages { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelRoom> HotelRooms { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.Hotel> Hotels { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelTypeLanguage> HotelTypeLanguages { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelType> HotelTypes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.Language> Languages { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LogPermission> LogPermissions { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.Log> Logs { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.Menu> Menus { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.OgSeo> OgSeos { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PageContent> PageContents { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PageType> PageTypes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PassengerInformation> PassengerInformations { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.Passenger> Passengers { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PnrCustomField> PnrCustomFields { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PnR> PnRs { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PossibleQuery> PossibleQueries { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.Provider> Providers { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.Provience> Proviences { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.Region> Regions { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ReservationDetail> ReservationDetails { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.Reservation> Reservations { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.Room> Rooms { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.Status> Statuses { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.Terminal> Terminals { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ThemeStyle> ThemeStyles { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.Url> Urls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UserPreference> UserPreferences { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.User> Users { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UserType> UserTypes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.YesNo> YesNos { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.Zone> Zones { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ZonesCity> ZonesCities { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.Agency1> Agency1S { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyCmsDevice> AgencyCmsDevices { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyCmsSectionType> AgencyCmsSectionTypes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyCmsSocialMediaUrl> AgencyCmsSocialMediaUrls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyCmsTheme> AgencyCmsThemes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyContractsClosedTour> AgencyContractsClosedTours { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyContractsHotelCategory> AgencyContractsHotelCategories { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyContractsHotelInformation> AgencyContractsHotelInformations { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyContractsHotelInformationImage> AgencyContractsHotelInformationImages { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyContractsHotelsConfiguration> AgencyContractsHotelsConfigurations { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyContractsHotelsConfigurationDay> AgencyContractsHotelsConfigurationDays { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyContractsHotelsMenu> AgencyContractsHotelsMenus { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyContractsInsuranceBasicDatum> AgencyContractsInsuranceBasicData { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyContractsInsuranceSelectedLanguage> AgencyContractsInsuranceSelectedLanguages { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyContractsInsuranceSelectedProductType> AgencyContractsInsuranceSelectedProductTypes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyContractsInsuranceType> AgencyContractsInsuranceTypes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyCreditDeposit> AgencyCreditDeposits { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyManager> AgencyManagers { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyMicroSiteApiProductProvider> AgencyMicroSiteApiProductProviders { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyMicroSiteDesign> AgencyMicroSiteDesigns { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyMicroSiteDomainLanguageSetting> AgencyMicroSiteDomainLanguageSettings { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyMicroSiteDomain> AgencyMicroSiteDomains { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyMicroSitePaymentProvider> AgencyMicroSitePaymentProviders { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyMicroSiteProperty> AgencyMicroSiteProperties { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyMicroSite> AgencyMicroSites { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyMicroSiteSettingPassengerDatum> AgencyMicroSiteSettingPassengerData { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyMicroSiteSettingsAccommodationSearchResult> AgencyMicroSiteSettingsAccommodationSearchResults { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyMicroSiteSettingsBookingProcess> AgencyMicroSiteSettingsBookingProcesses { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyMicroSiteSettingsBookingReplicatorMode> AgencyMicroSiteSettingsBookingReplicatorModes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyMicroSiteSettingsEmailVoucher> AgencyMicroSiteSettingsEmailVouchers { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyMicroSiteSettingsEnableMultiDay> AgencyMicroSiteSettingsEnableMultiDays { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyMicroSiteSettingsGeneral> AgencyMicroSiteSettingsGenerals { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyMicroSiteSettingsHelpSupport> AgencyMicroSiteSettingsHelpSupports { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyMicroSiteSettingsInvoice> AgencyMicroSiteSettingsInvoices { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyMicroSiteSettingsOther> AgencyMicroSiteSettingsOthers { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyMicroSiteSettingsPaymetOption> AgencyMicroSiteSettingsPaymetOptions { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyMicroSiteSettingsRequestInvoice> AgencyMicroSiteSettingsRequestInvoices { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyMicroSiteSettingsRequiredPassenger> AgencyMicroSiteSettingsRequiredPassengers { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyMicroSiteSettingsSearchEngine> AgencyMicroSiteSettingsSearchEngines { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyMicroSiteSettingsSearchSetting> AgencyMicroSiteSettingsSearchSettings { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyMicroSiteSettingsSortType> AgencyMicroSiteSettingsSortTypes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyMicroSiteSettingsTermsCondition> AgencyMicroSiteSettingsTermsConditions { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyMicroSitesSettingsEmailConfiguration> AgencyMicroSitesSettingsEmailConfigurations { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyUser> AgencyUsers { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ApiProduct> ApiProducts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ApiResult1> ApiResult1S { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.Gender> Genders { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelCategory> HotelCategories { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelFacility> HotelFacilities { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelFacilityCategory> HotelFacilityCategories { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelFacilityCategorySelectedFacility> HotelFacilityCategorySelectedFacilities { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelPresentation> HotelPresentations { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.Hotel1> Hotel1S { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelSeasonMediaFile> HotelSeasonMediaFiles { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelSeason> HotelSeasons { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelSeasonSelectedTextCategory> HotelSeasonSelectedTextCategories { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelSelectedCategory> HotelSelectedCategories { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelTextCategory> HotelTextCategories { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelTextCategoriesSelectedPresentation> HotelTextCategoriesSelectedPresentations { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.InsuranceSelectedLang> InsuranceSelectedLangs { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.InvoiceType> InvoiceTypes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LimitType> LimitTypes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PaymentType> PaymentTypes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.Statu> Status { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyContractsConfigurationByHotel> AgencyContractsConfigurationByHotels { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.Currency> Currencies { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.MarketPlaceApprovalStatus> MarketPlaceApprovalStatuses { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.MarketPlaceBuyingDestination> MarketPlaceBuyingDestinations { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.MarketPlaceFee> MarketPlaceFees { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.MarketPlaceRequestProcess> MarketPlaceRequestProcesses { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.MarketPlaceRequestProduct> MarketPlaceRequestProducts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.MarketPlacesProfile> MarketPlacesProfiles { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.MarketPlaceType> MarketPlaceTypes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.MarketPlaceSellingDestination> MarketPlaceSellingDestinations { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ProductType> ProductTypes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.Efmigrationshistorydelete> Efmigrationshistorydeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.Efmigrationshistorygetall> Efmigrationshistorygetalls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.Efmigrationshistorygetbyid> Efmigrationshistorygetbyids { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.Efmigrationshistorygetbyproductversion> Efmigrationshistorygetbyproductversions { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.Efmigrationshistoryinsert> Efmigrationshistoryinserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.Efmigrationshistoryupdate> Efmigrationshistoryupdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgenciesDelete> AgenciesDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgenciesGetAll> AgenciesGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgenciesGetByAddress> AgenciesGetByAddresses { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgenciesGetByComercialContactId> AgenciesGetByComercialContactIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgenciesGetByFinanceContactId> AgenciesGetByFinanceContactIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgenciesGetById> AgenciesGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgenciesGetByMarkUp> AgenciesGetByMarkUps { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgenciesGetByName> AgenciesGetByNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgenciesGetByPaymentPolitic> AgenciesGetByPaymentPolitics { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgenciesGetByReservationContactId> AgenciesGetByReservationContactIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgenciesInsert> AgenciesInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgenciesUpdate> AgenciesUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyGroupDelete> AgencyGroupDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyGroupGetAll> AgencyGroupGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyGroupGetByActive> AgencyGroupGetByActives { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyGroupGetById> AgencyGroupGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyGroupGetByName> AgencyGroupGetByNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyGroupGetByTimestamp> AgencyGroupGetByTimestamps { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyGroupGetTimestampBetween> AgencyGroupGetTimestampBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyGroupInsert> AgencyGroupInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgencyGroupUpdate> AgencyGroupUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgentInformationDelete> AgentInformationDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgentInformationGetAll> AgentInformationGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgentInformationGetByAgentName> AgentInformationGetByAgentNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgentInformationGetByAgentStation> AgentInformationGetByAgentStations { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgentinformationgetbyfileId> AgentinformationgetbyfileIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgentinformationgetbyfileName> AgentinformationgetbyfileNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgentInformationGetById> AgentInformationGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgentInformationGetByRecordDateStamp> AgentInformationGetByRecordDateStamps { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgentInformationGetRecordDateStampBetween> AgentInformationGetRecordDateStampBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgentInformationInsert> AgentInformationInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AgentInformationUpdate> AgentInformationUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirExtrasDelete> AirExtrasDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirExtrasGetAiExTimestampBetween> AirExtrasGetAiExTimestampBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirExtrasGetAll> AirExtrasGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirExtrasGetByAiExActive> AirExtrasGetByAiExActives { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirExtrasGetByAiExDescription> AirExtrasGetByAiExDescriptions { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirExtrasGetByAiExFare> AirExtrasGetByAiExFares { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirExtrasGetByAiExTimestamp> AirExtrasGetByAiExTimestamps { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirExtrasGetByAirId> AirExtrasGetByAirIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirExtrasGetByExTyId> AirExtrasGetByExTyIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirExtrasGetById> AirExtrasGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirExtrasInsert> AirExtrasInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirExtrasUpdate> AirExtrasUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirlineDelete> AirlineDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirlineGetAirlineTimestampBetween> AirlineGetAirlineTimestampBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirlineGetAll> AirlineGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirlineGetByAirlineActive> AirlineGetByAirlineActives { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirlineGetByAirlineCode> AirlineGetByAirlineCodes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirlineGetByAirlineName> AirlineGetByAirlineNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirlineGetByAirlinePlate> AirlineGetByAirlinePlates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirlineGetByAirlineTimestamp> AirlineGetByAirlineTimestamps { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirlineGetById> AirlineGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirlineInsert> AirlineInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirlineUpdate> AirlineUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirportDelete> AirportDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirportGetAirportTimestampBetween> AirportGetAirportTimestampBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirportGetAll> AirportGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirportGetByAirportActive> AirportGetByAirportActives { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirportGetByAirportCode> AirportGetByAirportCodes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirportGetByAirportName> AirportGetByAirportNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirportGetByAirportTimestamp> AirportGetByAirportTimestamps { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirportGetByCityId> AirportGetByCityIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirportGetByCountryId> AirportGetByCountryIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirportGetById> AirportGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirportInsert> AirportInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirportUpdate> AirportUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirsDelete> AirsDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirSegmentsDelete> AirSegmentsDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirSegmentsGetAiSeArrivalBetween> AirSegmentsGetAiSeArrivalBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirSegmentsGetAiSeDepartureBetween> AirSegmentsGetAiSeDepartureBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirSegmentsGetAiSeTimestampBetween> AirSegmentsGetAiSeTimestampBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirSegmentsGetAll> AirSegmentsGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirSegmentsGetByAirId> AirSegmentsGetByAirIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirSegmentsGetByAirlineId> AirSegmentsGetByAirlineIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirSegmentsGetByAirportIdDestination> AirSegmentsGetByAirportIdDestinations { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirSegmentsGetByAirportIdOrigin> AirSegmentsGetByAirportIdOrigins { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirSegmentsGetByAiSeActive> AirSegmentsGetByAiSeActives { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirSegmentsGetByAiSeArrival> AirSegmentsGetByAiSeArrivals { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirSegmentsGetByAiSeClass> AirSegmentsGetByAiSeClasses { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirSegmentsGetByAiSeDeparture> AirSegmentsGetByAiSeDepartures { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirSegmentsGetByAiSeFlightNumber> AirSegmentsGetByAiSeFlightNumbers { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirSegmentsGetByAiSeTimestamp> AirSegmentsGetByAiSeTimestamps { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirSegmentsGetById> AirSegmentsGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirSegmentsGetByTerminalIdDestination> AirSegmentsGetByTerminalIdDestinations { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirSegmentsGetByTerminalIdOrigin> AirSegmentsGetByTerminalIdOrigins { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirSegmentsInsert> AirSegmentsInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirSegmentsUpdate> AirSegmentsUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirsGetAirBookedDateBetween> AirsGetAirBookedDateBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirsGetAirIssueddateBetween> AirsGetAirIssueddateBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirsGetAirTimestampBetween> AirsGetAirTimestampBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirsGetAll> AirsGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirsGetByAirActive> AirsGetByAirActives { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirsGetByAirBookedDate> AirsGetByAirBookedDates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirsGetByAirFare> AirsGetByAirFares { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirsGetByAirFareBasis> AirsGetByAirFareBases { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirsGetByAirHighestFare> AirsGetByAirHighestFares { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirsGetByAirIncludeBag> AirsGetByAirIncludeBags { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirsGetByAirIssueddate> AirsGetByAirIssueddates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirsGetByAirlineId> AirsGetByAirlineIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirsGetByAirLowestFare> AirsGetByAirLowestFares { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirsGetByAirOriginalTicket> AirsGetByAirOriginalTickets { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirsGetByAirRecordAirline> AirsGetByAirRecordAirlines { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirsGetByAirReIssued> AirsGetByAirReIssueds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirsGetByAirTax> AirsGetByAirTaxes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirsGetByAirTicket> AirsGetByAirTickets { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirsGetByAirTimestamp> AirsGetByAirTimestamps { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirsGetByBrokerId> AirsGetByBrokerIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirsGetByCurrencyId> AirsGetByCurrencyIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirsGetById> AirsGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirsGetByPnrId> AirsGetByPnrIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirsInsert> AirsInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AirsUpdate> AirsUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ApiDelete> ApiDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ApiGetAll> ApiGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ApiGetByApiName> ApiGetByApiNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ApiGetById> ApiGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ApiGetByPassword> ApiGetByPasswords { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ApiGetByUserKey> ApiGetByUserKeys { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ApiInsert> ApiInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ApiResultInsert> ApiResultInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ApiUpdate> ApiUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AuthorizationTemplateDelete> AuthorizationTemplateDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AuthorizationTemplateGetAll> AuthorizationTemplateGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AuthorizationTemplateGetByCanDelete> AuthorizationTemplateGetByCanDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AuthorizationTemplateGetByCanDetail> AuthorizationTemplateGetByCanDetails { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AuthorizationTemplateGetByCanInsert> AuthorizationTemplateGetByCanInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AuthorizationTemplateGetByCanList> AuthorizationTemplateGetByCanLists { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AuthorizationTemplateGetByCanRemove> AuthorizationTemplateGetByCanRemoves { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AuthorizationTemplateGetByCanUpdate> AuthorizationTemplateGetByCanUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AuthorizationTemplateGetByDatabaseTable> AuthorizationTemplateGetByDatabaseTables { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AuthorizationTemplateGetByDepartment> AuthorizationTemplateGetByDepartments { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AuthorizationTemplateGetById> AuthorizationTemplateGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AuthorizationTemplateGetByOnLeftMenu> AuthorizationTemplateGetByOnLeftMenus { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AuthorizationTemplateGetByProduct> AuthorizationTemplateGetByProducts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AuthorizationTemplateGetByUser> AuthorizationTemplateGetByUsers { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AuthorizationTemplateInsert> AuthorizationTemplateInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AuthorizationTemplateUpdate> AuthorizationTemplateUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AutoCompletesDelete> AutoCompletesDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AutoCompletesGetAll> AutoCompletesGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AutoCompletesGetByApiId> AutoCompletesGetByApiIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AutoCompletesGetByApiSystemId> AutoCompletesGetByApiSystemIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AutoCompletesGetById> AutoCompletesGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AutoCompletesGetByName> AutoCompletesGetByNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AutoCompletesGetByType> AutoCompletesGetByTypes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AutoCompletesInsert> AutoCompletesInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AutoCompletesUpdate> AutoCompletesUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AutoCompleteTypesDelete> AutoCompleteTypesDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AutoCompleteTypesGetAll> AutoCompleteTypesGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AutoCompleteTypesGetById> AutoCompleteTypesGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AutoCompleteTypesGetByName> AutoCompleteTypesGetByNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AutoCompleteTypesInsert> AutoCompleteTypesInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.AutoCompleteTypesUpdate> AutoCompleteTypesUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BannerDelete> BannerDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BannerGetAll> BannerGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BannerGetById> BannerGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BannerGetByImagePath> BannerGetByImagePaths { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BannerGetByLanguageId> BannerGetByLanguageIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BannerGetByMobileImagePath> BannerGetByMobileImagePaths { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BannerGetByTableOrder> BannerGetByTableOrders { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BannerGetByText> BannerGetByTexts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BannerGetByText2> BannerGetByText2S { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BannerGetByText3> BannerGetByText3S { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BannerInsert> BannerInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BannerUpdate> BannerUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BoardTypeLanguagesDelete> BoardTypeLanguagesDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BoardTypeLanguagesGetAll> BoardTypeLanguagesGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BoardTypeLanguagesGetByBoardTypeId> BoardTypeLanguagesGetByBoardTypeIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BoardTypeLanguagesGetById> BoardTypeLanguagesGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BoardTypeLanguagesGetByLanguageId> BoardTypeLanguagesGetByLanguageIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BoardTypeLanguagesGetByName> BoardTypeLanguagesGetByNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BoardTypeLanguagesInsert> BoardTypeLanguagesInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BoardTypeLanguagesUpdate> BoardTypeLanguagesUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BoardTypesDelete> BoardTypesDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BoardTypesGetAll> BoardTypesGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BoardTypesGetById> BoardTypesGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BoardTypesGetByName> BoardTypesGetByNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BoardTypesInsert> BoardTypesInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BoardTypesUpdate> BoardTypesUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingDealsDelete> BookingDealsDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingDealsGetAll> BookingDealsGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingDealsGetByBookingId> BookingDealsGetByBookingIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingDealsGetByDealId> BookingDealsGetByDealIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingDealsGetById> BookingDealsGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingDealsInsert> BookingDealsInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingDealsUpdate> BookingDealsUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingRoomsDelete> BookingRoomsDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingRoomsGetAll> BookingRoomsGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingRoomsGetByBoardTypeId> BookingRoomsGetByBoardTypeIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingRoomsGetByBookingId> BookingRoomsGetByBookingIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingRoomsGetByCost> BookingRoomsGetByCosts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingRoomsGetByHotelRoomId> BookingRoomsGetByHotelRoomIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingRoomsGetById> BookingRoomsGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingRoomsGetByPrice> BookingRoomsGetByPrices { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingRoomsInsert> BookingRoomsInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingRoomsUpdate> BookingRoomsUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingsDelete> BookingsDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingsGetAll> BookingsGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingsGetByAdult> BookingsGetByAdults { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingsGetByAgencyId> BookingsGetByAgencyIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingsGetByChild> BookingsGetByChildren { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingsGetByChildrenAge> BookingsGetByChildrenAges { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingsGetByClientAddress> BookingsGetByClientAddresses { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingsGetByClientContact> BookingsGetByClientContacts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingsGetByClientEmail> BookingsGetByClientEmails { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingsGetByClientName> BookingsGetByClientNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingsGetByClientNote> BookingsGetByClientNotes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingsGetByClientSurname> BookingsGetByClientSurnames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingsGetByClientTitle> BookingsGetByClientTitles { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingsGetByDateBooked> BookingsGetByDateBookeds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingsGetByFromDate> BookingsGetByFromDates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingsGetByHotelId> BookingsGetByHotelIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingsGetById> BookingsGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingsGetByInfant> BookingsGetByInfants { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingsGetByNight> BookingsGetByNights { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingsGetByNumRoom> BookingsGetByNumRooms { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingsGetByPaidStatus> BookingsGetByPaidStatuses { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingsGetByProviderId> BookingsGetByProviderIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingsGetByReference> BookingsGetByReferences { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingsGetByStatus> BookingsGetByStatuses { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingsGetByToDate> BookingsGetByToDates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingsGetByTotalCost> BookingsGetByTotalCosts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingsGetByTotalPrice> BookingsGetByTotalPrices { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingsGetDateBookedBetween> BookingsGetDateBookedBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingsGetFromDateBetween> BookingsGetFromDateBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingsGetToDateBetween> BookingsGetToDateBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingsInsert> BookingsInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BookingsUpdate> BookingsUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BrokerDelete> BrokerDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BrokerGetAll> BrokerGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BrokerGetBrokerTimestampBetween> BrokerGetBrokerTimestampBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BrokerGetByBrokerActive> BrokerGetByBrokerActives { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BrokerGetByBrokerCode> BrokerGetByBrokerCodes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BrokerGetByBrokerName> BrokerGetByBrokerNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BrokerGetByBrokerTimestamp> BrokerGetByBrokerTimestamps { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BrokerGetById> BrokerGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BrokerInsert> BrokerInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BrokerUpdate> BrokerUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BuyRoomsDelete> BuyRoomsDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BuyRoomsGetAll> BuyRoomsGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BuyRoomsGetByDescription> BuyRoomsGetByDescriptions { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BuyRoomsGetById> BuyRoomsGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BuyRoomsGetByMaxAdult> BuyRoomsGetByMaxAdults { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BuyRoomsGetByMaxAllotment> BuyRoomsGetByMaxAllotments { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BuyRoomsGetByMaxChild> BuyRoomsGetByMaxChildren { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BuyRoomsGetByMaxInfant> BuyRoomsGetByMaxInfants { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BuyRoomsGetByName> BuyRoomsGetByNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BuyRoomsInsert> BuyRoomsInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.BuyRoomsUpdate> BuyRoomsUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CancelationLanguagesDelete> CancelationLanguagesDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CancelationLanguagesGetAll> CancelationLanguagesGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CancelationLanguagesGetByCancelationRulesId> CancelationLanguagesGetByCancelationRulesIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CancelationLanguagesGetByDescription> CancelationLanguagesGetByDescriptions { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CancelationLanguagesGetById> CancelationLanguagesGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CancelationLanguagesGetByLanguageId> CancelationLanguagesGetByLanguageIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CancelationLanguagesGetByName> CancelationLanguagesGetByNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CancelationLanguagesInsert> CancelationLanguagesInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CancelationLanguagesUpdate> CancelationLanguagesUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CancellationRulesDelete> CancellationRulesDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CancellationRulesGetAll> CancellationRulesGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CancellationRulesGetByCancellationSeasonId> CancellationRulesGetByCancellationSeasonIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CancellationRulesGetByCost> CancellationRulesGetByCosts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CancellationRulesGetByCostType> CancellationRulesGetByCostTypes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CancellationRulesGetByFromDay> CancellationRulesGetByFromDays { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CancellationRulesGetById> CancellationRulesGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CancellationRulesGetByToDay> CancellationRulesGetByToDays { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CancellationRulesInsert> CancellationRulesInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CancellationRulesUpdate> CancellationRulesUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CancellationSeasonsDelete> CancellationSeasonsDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CancellationSeasonsGetAll> CancellationSeasonsGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CancellationSeasonsGetByEndDate> CancellationSeasonsGetByEndDates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CancellationSeasonsGetByHotelId> CancellationSeasonsGetByHotelIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CancellationSeasonsGetById> CancellationSeasonsGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CancellationSeasonsGetByStartDate> CancellationSeasonsGetByStartDates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CancellationSeasonsGetEndDateBetween> CancellationSeasonsGetEndDateBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CancellationSeasonsGetStartDateBetween> CancellationSeasonsGetStartDateBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CancellationSeasonsInsert> CancellationSeasonsInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CancellationSeasonsUpdate> CancellationSeasonsUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarRentalsDelete> CarRentalsDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarRentalsGetAll> CarRentalsGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarRentalsGetByCaRtActive> CarRentalsGetByCaRtActives { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarRentalsGetByCaRtCode> CarRentalsGetByCaRtCodes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarRentalsGetByCaRtName> CarRentalsGetByCaRtNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarRentalsGetByCaRtTimestamp> CarRentalsGetByCaRtTimestamps { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarRentalsGetById> CarRentalsGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarRentalsGetCaRtTimestampBetween> CarRentalsGetCaRtTimestampBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarRentalsInsert> CarRentalsInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarRentalsUpdate> CarRentalsUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarRentsDelete> CarRentsDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarRentsGetAll> CarRentsGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarRentsGetByAirportIdPickUp> CarRentsGetByAirportIdPickUps { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarRentsGetByAirportIdReturn> CarRentsGetByAirportIdReturns { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarRentsGetByCaReActive> CarRentsGetByCaReActives { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarRentsGetByCaReBookDate> CarRentsGetByCaReBookDates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarRentsGetByCaRePickUpDate> CarRentsGetByCaRePickUpDates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarRentsGetByCaReRate> CarRentsGetByCaReRates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarRentsGetByCaReReturnDate> CarRentsGetByCaReReturnDates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarRentsGetByCaReTax> CarRentsGetByCaReTaxes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarRentsGetByCaReTimestamp> CarRentsGetByCaReTimestamps { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarRentsGetByCaRtId> CarRentsGetByCaRtIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarRentsGetByCaTyId> CarRentsGetByCaTyIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarRentsGetByCurrencyId> CarRentsGetByCurrencyIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarRentsGetById> CarRentsGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarRentsGetByPnrId> CarRentsGetByPnrIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarRentsGetCaReBookDateBetween> CarRentsGetCaReBookDateBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarRentsGetCaRePickUpDateBetween> CarRentsGetCaRePickUpDateBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarRentsGetCaReReturnDateBetween> CarRentsGetCaReReturnDateBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarRentsGetCaReTimestampBetween> CarRentsGetCaReTimestampBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarRentsInsert> CarRentsInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarRentsUpdate> CarRentsUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarTypesDelete> CarTypesDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarTypesGetAll> CarTypesGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarTypesGetByCaTyActive> CarTypesGetByCaTyActives { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarTypesGetByCaTyCode> CarTypesGetByCaTyCodes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarTypesGetByCaTyDescription> CarTypesGetByCaTyDescriptions { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarTypesGetByCaTyTimestamp> CarTypesGetByCaTyTimestamps { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarTypesGetById> CarTypesGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarTypesGetCaTyTimestampBetween> CarTypesGetCaTyTimestampBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarTypesInsert> CarTypesInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CarTypesUpdate> CarTypesUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CitiesDelete> CitiesDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CitiesGetAll> CitiesGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CitiesGetById> CitiesGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CitiesGetByLatitude> CitiesGetByLatitudes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CitiesGetByLongitude> CitiesGetByLongitudes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CitiesGetByName> CitiesGetByNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CitiesInsert> CitiesInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CitiesUpdate> CitiesUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CityModelsDelete> CityModelsDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CityModelsGetAll> CityModelsGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CityModelsGetByCityName> CityModelsGetByCityNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CityModelsGetById> CityModelsGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CityModelsInsert> CityModelsInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CityModelsUpdate> CityModelsUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CompaniesDelete> CompaniesDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CompaniesGetAll> CompaniesGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CompaniesGetByAgencyId> CompaniesGetByAgencyIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CompaniesGetByCoDiId> CompaniesGetByCoDiIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CompaniesGetByCoGrId> CompaniesGetByCoGrIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CompaniesGetByCompanyActive> CompaniesGetByCompanyActives { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CompaniesGetByCompanyCode> CompaniesGetByCompanyCodes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CompaniesGetByCompanyRepresentative> CompaniesGetByCompanyRepresentatives { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CompaniesGetByCompanyTimestamp> CompaniesGetByCompanyTimestamps { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CompaniesGetByCountryId> CompaniesGetByCountryIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CompaniesGetByCurrencyId> CompaniesGetByCurrencyIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CompaniesGetById> CompaniesGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CompaniesGetByInSeId> CompaniesGetByInSeIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CompaniesGetByLanguagesId> CompaniesGetByLanguagesIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CompaniesGetCompanyTimestampBetween> CompaniesGetCompanyTimestampBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CompaniesInsert> CompaniesInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CompaniesUpdate> CompaniesUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ContactsDelete> ContactsDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ContactsGetAll> ContactsGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ContactsGetByEmail> ContactsGetByEmails { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ContactsGetByFaxNumber> ContactsGetByFaxNumbers { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ContactsGetById> ContactsGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ContactsGetByName> ContactsGetByNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ContactsGetByTelNumber> ContactsGetByTelNumbers { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ContactsInsert> ContactsInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ContactsUpdate> ContactsUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CountryDelete> CountryDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CountryGetAll> CountryGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CountryGetByAbbreviation> CountryGetByAbbreviations { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CountryGetByArea> CountryGetByAreas { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CountryGetByBarcode> CountryGetByBarcodes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CountryGetByCallingCode> CountryGetByCallingCodes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CountryGetByCity> CountryGetByCities { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CountryGetByContinent> CountryGetByContinents { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CountryGetByCostLine> CountryGetByCostLines { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CountryGetByCurrencyCode> CountryGetByCurrencyCodes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CountryGetByCurrencyName> CountryGetByCurrencyNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CountryGetByDefaultLanguageId> CountryGetByDefaultLanguageIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CountryGetByDensity> CountryGetByDensities { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CountryGetByDish> CountryGetByDishes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CountryGetByDomainTld> CountryGetByDomainTlds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CountryGetByEast> CountryGetByEasts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CountryGetByElevation> CountryGetByElevations { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CountryGetByExpectancy> CountryGetByExpectancies { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CountryGetByFlagBase64> CountryGetByFlagBase64S { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CountryGetByGovernment> CountryGetByGovernments { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CountryGetByHasFraudRisk> CountryGetByHasFraudRisks { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CountryGetByHasManuelRegistration> CountryGetByHasManuelRegistrations { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CountryGetByHeight> CountryGetByHeights { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CountryGetById> CountryGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CountryGetByIndependence> CountryGetByIndependences { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CountryGetByIso> CountryGetByIsos { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CountryGetByLandlocked> CountryGetByLandlockeds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CountryGetByLanguagesJson> CountryGetByLanguagesJsons { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CountryGetByLocation> CountryGetByLocations { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CountryGetByName> CountryGetByNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CountryGetByNorth> CountryGetByNorths { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CountryGetByPopulation> CountryGetByPopulations { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CountryGetByReligion> CountryGetByReligions { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CountryGetByShortName> CountryGetByShortNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CountryGetBySouth> CountryGetBySouths { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CountryGetBySymbol> CountryGetBySymbols { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CountryGetByTemperature> CountryGetByTemperatures { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CountryGetByWest> CountryGetByWests { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CountryInsert> CountryInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CountryUpdate> CountryUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CurrencyDelete> CurrencyDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CurrencyGetAll> CurrencyGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CurrencyGetByCurrencyActive> CurrencyGetByCurrencyActives { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CurrencyGetByCurrencyCode> CurrencyGetByCurrencyCodes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CurrencyGetByCurrencyCodeIatum> CurrencyGetByCurrencyCodeIata { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CurrencyGetByCurrencyName> CurrencyGetByCurrencyNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CurrencyGetByCurrencyTimestamp> CurrencyGetByCurrencyTimestamps { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CurrencyGetById> CurrencyGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CurrencyGetCurrencyTimestampBetween> CurrencyGetCurrencyTimestampBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CurrencyInsert> CurrencyInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CurrencyUpdate> CurrencyUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CustomerInformationDelete> CustomerInformationDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CustomerInformationGetAll> CustomerInformationGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByAgentCode> CustomerInformationGetByAgentCodes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByAlternativeEmailId> CustomerInformationGetByAlternativeEmailIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByBookingStatus> CustomerInformationGetByBookingStatuses { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByCountryCode> CustomerInformationGetByCountryCodes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CustomerinformationgetbycustomeridN> CustomerinformationgetbycustomeridNs { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByDateOfBirth> CustomerInformationGetByDateOfBirths { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByEmailId> CustomerInformationGetByEmailIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByFax> CustomerInformationGetByFaxes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CustomerinformationgetbyfileId> CustomerinformationgetbyfileIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CustomerinformationgetbyfileName> CustomerinformationgetbyfileNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByFirstName> CustomerInformationGetByFirstNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByGender> CustomerInformationGetByGenders { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CustomerInformationGetById> CustomerInformationGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByLanguageCode> CustomerInformationGetByLanguageCodes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByLastName> CustomerInformationGetByLastNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByMobile> CustomerInformationGetByMobiles { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByModificationDate> CustomerInformationGetByModificationDates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByNationalityCode> CustomerInformationGetByNationalityCodes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByOfficeTelephone> CustomerInformationGetByOfficeTelephones { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByRecordDateStamp> CustomerInformationGetByRecordDateStamps { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByTelephone> CustomerInformationGetByTelephones { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByTitle> CustomerInformationGetByTitles { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByTotalFare> CustomerInformationGetByTotalFares { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByTotalInfantcount> CustomerInformationGetByTotalInfantcounts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByTotalpaxcount> CustomerInformationGetByTotalpaxcounts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CustomerInformationGetByTotalTaxChg> CustomerInformationGetByTotalTaxChgs { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CustomerInformationGetDateOfBirthBetween> CustomerInformationGetDateOfBirthBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CustomerInformationGetModificationDateBetween> CustomerInformationGetModificationDateBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CustomerInformationGetRecordDateStampBetween> CustomerInformationGetRecordDateStampBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CustomerInformationInsert> CustomerInformationInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.CustomerInformationUpdate> CustomerInformationUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseColumnsDelete> DatabaseColumnsDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetAll> DatabaseColumnsGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByCmsColumnTitle> DatabaseColumnsGetByCmsColumnTitles { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByCmsInputType> DatabaseColumnsGetByCmsInputTypes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByColumnName> DatabaseColumnsGetByColumnNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByDbType> DatabaseColumnsGetByDbTypes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByErrorDescription> DatabaseColumnsGetByErrorDescriptions { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByHasDefaultValue> DatabaseColumnsGetByHasDefaultValues { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByHasShowedOnList> DatabaseColumnsGetByHasShowedOnLists { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetById> DatabaseColumnsGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByIsFilter> DatabaseColumnsGetByIsFilters { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByIsLanguageField> DatabaseColumnsGetByIsLanguageFields { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByIsNullable> DatabaseColumnsGetByIsNullables { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByIsPrimary> DatabaseColumnsGetByIsPrimaries { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByIsPublic> DatabaseColumnsGetByIsPublics { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByIsRequired> DatabaseColumnsGetByIsRequireds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByIsRoutingField> DatabaseColumnsGetByIsRoutingFields { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByIsSecondry> DatabaseColumnsGetByIsSecondries { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByJsonName> DatabaseColumnsGetByJsonNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByMaxLength> DatabaseColumnsGetByMaxLengths { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByParameterDescription> DatabaseColumnsGetByParameterDescriptions { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByResize> DatabaseColumnsGetByResizes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByReturnColumnNameFromCmsTitle> DatabaseColumnsGetByReturnColumnNameFromCmsTitles { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetBySelectedDataSourceTable> DatabaseColumnsGetBySelectedDataSourceTables { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetBySelectedText> DatabaseColumnsGetBySelectedTexts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetBySelectedValue> DatabaseColumnsGetBySelectedValues { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByTableId> DatabaseColumnsGetByTableIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByTableOrder> DatabaseColumnsGetByTableOrders { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseColumnsGetByTooltip> DatabaseColumnsGetByTooltips { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseColumnsInsert> DatabaseColumnsInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseColumnsUpdate> DatabaseColumnsUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseTablesDelete> DatabaseTablesDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseTablesGetAll> DatabaseTablesGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseTablesGetByCanGenerate> DatabaseTablesGetByCanGenerates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseTablesGetByCmsGridSize> DatabaseTablesGetByCmsGridSizes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseTablesGetByCmsIcon> DatabaseTablesGetByCmsIcons { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseTablesGetByCmsLinkedTable> DatabaseTablesGetByCmsLinkedTables { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseTablesGetByCreateDate> DatabaseTablesGetByCreateDates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseTablesGetByDisplayName> DatabaseTablesGetByDisplayNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseTablesGetByForUser> DatabaseTablesGetByForUsers { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseTablesGetByFrontPageName> DatabaseTablesGetByFrontPageNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseTablesGetByHasMultiLanguage> DatabaseTablesGetByHasMultiLanguages { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseTablesGetById> DatabaseTablesGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseTablesGetByIsRouting> DatabaseTablesGetByIsRoutings { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseTablesGetByParentTable> DatabaseTablesGetByParentTables { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseTablesGetByTableName> DatabaseTablesGetByTableNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseTablesGetByTableOrder> DatabaseTablesGetByTableOrders { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseTablesGetCreateDateBetween> DatabaseTablesGetCreateDateBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseTablesInsert> DatabaseTablesInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseTablesUpdate> DatabaseTablesUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseValueTypesDelete> DatabaseValueTypesDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseValueTypesGetAll> DatabaseValueTypesGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseValueTypesGetByFrontEndName> DatabaseValueTypesGetByFrontEndNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseValueTypesGetById> DatabaseValueTypesGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseValueTypesGetBySqlName> DatabaseValueTypesGetBySqlNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseValueTypesInsert> DatabaseValueTypesInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatabaseValueTypesUpdate> DatabaseValueTypesUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatatableCmsInputTypeDelete> DatatableCmsInputTypeDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatatableCmsInputTypeGetAll> DatatableCmsInputTypeGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatatableCmsInputTypeGetById> DatatableCmsInputTypeGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatatableCmsInputTypeGetByName> DatatableCmsInputTypeGetByNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatatableCmsInputTypeInsert> DatatableCmsInputTypeInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DatatableCmsInputTypeUpdate> DatatableCmsInputTypeUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DealsDelete> DealsDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DealsGetAll> DealsGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DealsGetByBoardTypeId> DealsGetByBoardTypeIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DealsGetByDealTypeId> DealsGetByDealTypeIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DealsGetByDiscount> DealsGetByDiscounts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DealsGetByEndDate> DealsGetByEndDates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DealsGetByFreeNight> DealsGetByFreeNights { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DealsGetByHotelRoomId> DealsGetByHotelRoomIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DealsGetById> DealsGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DealsGetByRelease> DealsGetByReleases { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DealsGetByStartDate> DealsGetByStartDates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DealsGetEndDateBetween> DealsGetEndDateBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DealsGetStartDateBetween> DealsGetStartDateBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DealsInsert> DealsInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DealsUpdate> DealsUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DealTypeLanguagesDelete> DealTypeLanguagesDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DealTypeLanguagesGetAll> DealTypeLanguagesGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DealTypeLanguagesGetByDealTypeId> DealTypeLanguagesGetByDealTypeIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DealTypeLanguagesGetByDescription> DealTypeLanguagesGetByDescriptions { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DealTypeLanguagesGetById> DealTypeLanguagesGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DealTypeLanguagesGetByLanguageId> DealTypeLanguagesGetByLanguageIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DealTypeLanguagesGetByName> DealTypeLanguagesGetByNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DealTypeLanguagesInsert> DealTypeLanguagesInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DealTypeLanguagesUpdate> DealTypeLanguagesUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DealTypesDelete> DealTypesDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DealTypesGetAll> DealTypesGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DealTypesGetById> DealTypesGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DealTypesGetByName> DealTypesGetByNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DealTypesInsert> DealTypesInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DealTypesUpdate> DealTypesUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DynamicJson> DynamicJsons { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DynamicQuery> DynamicQueries { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DynamicQueueList> DynamicQueueLists { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DynamicSpaceReport> DynamicSpaceReports { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.Dynamicstatistic> Dynamicstatistics { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DynamicTable> DynamicTables { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DynamicTableCount> DynamicTableCounts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DynamicTableForeignKey> DynamicTableForeignKeys { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DynamicTablePager> DynamicTablePagers { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DynamicTableReport> DynamicTableReports { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DynamicTableRow> DynamicTableRows { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DynamicTableSearch> DynamicTableSearches { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DynamicTableSearchAll> DynamicTableSearchAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DynamicTableSearchTable> DynamicTableSearchTables { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DynamicTransactionReport> DynamicTransactionReports { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DynamicUpsert> DynamicUpserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DynamicViewDto> DynamicViewDtos { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.DynamicViewReport> DynamicViewReports { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ExchangeRatesDelete> ExchangeRatesDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ExchangeRatesGetAll> ExchangeRatesGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ExchangeRatesGetByCurrencyIdFrom> ExchangeRatesGetByCurrencyIdFroms { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ExchangeRatesGetByCurrencyIdTo> ExchangeRatesGetByCurrencyIdTos { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ExchangeRatesGetByExRaActive> ExchangeRatesGetByExRaActives { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ExchangeRatesGetByExRaDate> ExchangeRatesGetByExRaDates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ExchangeRatesGetByExRaTimestamp> ExchangeRatesGetByExRaTimestamps { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ExchangeRatesGetByExRaValue> ExchangeRatesGetByExRaValues { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ExchangeRatesGetById> ExchangeRatesGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ExchangeRatesGetExRaDateBetween> ExchangeRatesGetExRaDateBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ExchangeRatesInsert> ExchangeRatesInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ExchangeRatesUpdate> ExchangeRatesUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ExtensionsDelete> ExtensionsDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ExtensionsGetAll> ExtensionsGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ExtensionsGetByExtensionName> ExtensionsGetByExtensionNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ExtensionsGetByFilePath> ExtensionsGetByFilePaths { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ExtensionsGetByFileType> ExtensionsGetByFileTypes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ExtensionsGetById> ExtensionsGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ExtensionsGetByIsRealName> ExtensionsGetByIsRealNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ExtensionsGetByKeyName> ExtensionsGetByKeyNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ExtensionsInsert> ExtensionsInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ExtensionsUpdate> ExtensionsUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ExtrasTypeDelete> ExtrasTypeDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ExtrasTypeGetAll> ExtrasTypeGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ExtrasTypeGetByExTyActive> ExtrasTypeGetByExTyActives { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ExtrasTypeGetByExTyCode> ExtrasTypeGetByExTyCodes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ExtrasTypeGetByExTyName> ExtrasTypeGetByExTyNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ExtrasTypeGetByExTyTimestamp> ExtrasTypeGetByExTyTimestamps { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ExtrasTypeGetById> ExtrasTypeGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ExtrasTypeGetExTyTimestampBetween> ExtrasTypeGetExTyTimestampBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ExtrasTypeInsert> ExtrasTypeInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ExtrasTypeUpdate> ExtrasTypeUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.FacilitiesDelete> FacilitiesDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.FacilitiesGetAll> FacilitiesGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.FacilitiesGetById> FacilitiesGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.FacilitiesGetByName> FacilitiesGetByNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.FacilitiesHotelsDelete> FacilitiesHotelsDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.FacilitiesHotelsGetAll> FacilitiesHotelsGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.FacilitiesHotelsGetByFacilityId> FacilitiesHotelsGetByFacilityIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.FacilitiesHotelsGetByHotelId> FacilitiesHotelsGetByHotelIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.FacilitiesHotelsGetByHotelRoomId> FacilitiesHotelsGetByHotelRoomIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.FacilitiesHotelsGetById> FacilitiesHotelsGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.FacilitiesHotelsInsert> FacilitiesHotelsInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.FacilitiesHotelsUpdate> FacilitiesHotelsUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.FacilitiesInsert> FacilitiesInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.FacilitiesUpdate> FacilitiesUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.FacilityLanguagesDelete> FacilityLanguagesDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.FacilityLanguagesGetAll> FacilityLanguagesGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.FacilityLanguagesGetByFacilityId> FacilityLanguagesGetByFacilityIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.FacilityLanguagesGetById> FacilityLanguagesGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.FacilityLanguagesGetByLanguageId> FacilityLanguagesGetByLanguageIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.FacilityLanguagesGetByName> FacilityLanguagesGetByNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.FacilityLanguagesInsert> FacilityLanguagesInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.FacilityLanguagesUpdate> FacilityLanguagesUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.FieldsTypeDelete> FieldsTypeDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.FieldsTypeGetAll> FieldsTypeGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.FieldsTypeGetByFiTyActive> FieldsTypeGetByFiTyActives { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.FieldsTypeGetByFiTyCode> FieldsTypeGetByFiTyCodes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.FieldsTypeGetByFiTyName> FieldsTypeGetByFiTyNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.FieldsTypeGetByFiTyTimestamp> FieldsTypeGetByFiTyTimestamps { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.FieldsTypeGetById> FieldsTypeGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.FieldsTypeGetFiTyTimestampBetween> FieldsTypeGetFiTyTimestampBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.FieldsTypeInsert> FieldsTypeInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.FieldsTypeUpdate> FieldsTypeUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.GetColumn> GetColumns { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.GetColumnsWithOutIdentity> GetColumnsWithOutIdentities { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.GetdatawıthpagıngResult> Getdatawıthpagıngs { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.GetDependency> GetDependencies { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.GetExtended> GetExtendeds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.GetExtendedInsert> GetExtendedInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.GetExtendedRemove> GetExtendedRemoves { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.GetGroupBy> GetGroupBies { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.GetIdentityList> GetIdentityLists { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.GetIndexStat> GetIndexStats { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.GetModifyDate> GetModifyDates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.GetPager> GetPagers { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.GetParameterName> GetParameterNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.GetProcedureName> GetProcedureNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.GetRequestParameterName> GetRequestParameterNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.GetReturnParameterName> GetReturnParameterNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.GetSearchWithList> GetSearchWithLists { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.GetServerInfo> GetServerInfos { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.GetSpLog> GetSpLogs { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.GetStoredProceduresForATable> GetStoredProceduresForATables { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.GetTableColumn> GetTableColumns { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.GetTableFk> GetTableFks { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.GetTableInfo> GetTableInfos { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.GetTableName> GetTableNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.GetTable> GetTables { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.GetTableSize> GetTableSizes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.GetViewBackupHistory> GetViewBackupHistories { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.GetViewList> GetViewLists { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HeaderColorDelete> HeaderColorDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HeaderColorGetAll> HeaderColorGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HeaderColorGetByColor> HeaderColorGetByColors { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HeaderColorGetById> HeaderColorGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HeaderColorGetByName> HeaderColorGetByNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HeaderColorGetByPath> HeaderColorGetByPaths { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HeaderColorInsert> HeaderColorInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HeaderColorUpdate> HeaderColorUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelAgencyMarkupsDelete> HotelAgencyMarkupsDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelAgencyMarkupsGetAll> HotelAgencyMarkupsGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelAgencyMarkupsGetByAgencyId> HotelAgencyMarkupsGetByAgencyIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelAgencyMarkupsGetByEndDate> HotelAgencyMarkupsGetByEndDates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelAgencyMarkupsGetByHotelId> HotelAgencyMarkupsGetByHotelIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelAgencyMarkupsGetById> HotelAgencyMarkupsGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelAgencyMarkupsGetByMarkUp> HotelAgencyMarkupsGetByMarkUps { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelAgencyMarkupsGetByStartDate> HotelAgencyMarkupsGetByStartDates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelAgencyMarkupsGetEndDateBetween> HotelAgencyMarkupsGetEndDateBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelAgencyMarkupsGetStartDateBetween> HotelAgencyMarkupsGetStartDateBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelAgencyMarkupsInsert> HotelAgencyMarkupsInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelAgencyMarkupsUpdate> HotelAgencyMarkupsUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelBuyRoomAllotmentDelete> HotelBuyRoomAllotmentDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelBuyRoomAllotmentGetAll> HotelBuyRoomAllotmentGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelBuyRoomAllotmentGetByAllotment> HotelBuyRoomAllotmentGetByAllotments { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelBuyRoomAllotmentGetByDay> HotelBuyRoomAllotmentGetByDays { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelBuyRoomAllotmentGetByHotelBuyRoomId> HotelBuyRoomAllotmentGetByHotelBuyRoomIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelBuyRoomAllotmentGetById> HotelBuyRoomAllotmentGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelBuyRoomAllotmentGetByRelease> HotelBuyRoomAllotmentGetByReleases { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelBuyRoomAllotmentGetByStopSale> HotelBuyRoomAllotmentGetByStopSales { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelBuyRoomAllotmentGetDayBetween> HotelBuyRoomAllotmentGetDayBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelBuyRoomAllotmentInsert> HotelBuyRoomAllotmentInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelBuyRoomAllotmentUpdate> HotelBuyRoomAllotmentUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelBuyRoomsDelete> HotelBuyRoomsDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelBuyRoomsGetAll> HotelBuyRoomsGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelBuyRoomsGetByBuyRoomId> HotelBuyRoomsGetByBuyRoomIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelBuyRoomsGetByHotelId> HotelBuyRoomsGetByHotelIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelBuyRoomsGetById> HotelBuyRoomsGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelBuyRoomsInsert> HotelBuyRoomsInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelBuyRoomsUpdate> HotelBuyRoomsUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelChainsDelete> HotelChainsDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelChainsGetAll> HotelChainsGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelChainsGetById> HotelChainsGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelChainsGetByName> HotelChainsGetByNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelChainsInsert> HotelChainsInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelChainsUpdate> HotelChainsUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelDescriptionsDelete> HotelDescriptionsDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelDescriptionsGetAll> HotelDescriptionsGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelDescriptionsGetByDescription> HotelDescriptionsGetByDescriptions { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelDescriptionsGetByHotelId> HotelDescriptionsGetByHotelIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelDescriptionsGetById> HotelDescriptionsGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelDescriptionsGetByLanguageId> HotelDescriptionsGetByLanguageIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelDescriptionsInsert> HotelDescriptionsInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelDescriptionsUpdate> HotelDescriptionsUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelPhotoLanguagesDelete> HotelPhotoLanguagesDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelPhotoLanguagesGetAll> HotelPhotoLanguagesGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelPhotoLanguagesGetByDescription> HotelPhotoLanguagesGetByDescriptions { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelPhotoLanguagesGetByHotelPhotoId> HotelPhotoLanguagesGetByHotelPhotoIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelPhotoLanguagesGetById> HotelPhotoLanguagesGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelPhotoLanguagesGetByLanguageId> HotelPhotoLanguagesGetByLanguageIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelPhotoLanguagesInsert> HotelPhotoLanguagesInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelPhotoLanguagesUpdate> HotelPhotoLanguagesUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelPhotosDelete> HotelPhotosDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelPhotosGetAll> HotelPhotosGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelPhotosGetByHotelId> HotelPhotosGetByHotelIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelPhotosGetByHotelRoomId> HotelPhotosGetByHotelRoomIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelPhotosGetById> HotelPhotosGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelPhotosGetByOrder> HotelPhotosGetByOrders { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelPhotosGetByPath> HotelPhotosGetByPaths { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelPhotosInsert> HotelPhotosInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelPhotosUpdate> HotelPhotosUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelRoomDailyPricesDelete> HotelRoomDailyPricesDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelRoomDailyPricesGetAll> HotelRoomDailyPricesGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelRoomDailyPricesGetByBoardTypeId> HotelRoomDailyPricesGetByBoardTypeIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelRoomDailyPricesGetByCost> HotelRoomDailyPricesGetByCosts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelRoomDailyPricesGetByDay> HotelRoomDailyPricesGetByDays { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelRoomDailyPricesGetByHotelRoomId> HotelRoomDailyPricesGetByHotelRoomIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelRoomDailyPricesGetById> HotelRoomDailyPricesGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelRoomDailyPricesGetByStopSale> HotelRoomDailyPricesGetByStopSales { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelRoomDailyPricesGetDayBetween> HotelRoomDailyPricesGetDayBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelRoomDailyPricesInsert> HotelRoomDailyPricesInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelRoomDailyPricesUpdate> HotelRoomDailyPricesUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelRoomLanguagesDelete> HotelRoomLanguagesDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelRoomLanguagesGetAll> HotelRoomLanguagesGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelRoomLanguagesGetByDescription> HotelRoomLanguagesGetByDescriptions { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelRoomLanguagesGetByHotelRoomId> HotelRoomLanguagesGetByHotelRoomIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelRoomLanguagesGetById> HotelRoomLanguagesGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelRoomLanguagesGetByLanguageId> HotelRoomLanguagesGetByLanguageIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelRoomLanguagesGetByName> HotelRoomLanguagesGetByNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelRoomLanguagesInsert> HotelRoomLanguagesInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelRoomLanguagesUpdate> HotelRoomLanguagesUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelRoomsDelete> HotelRoomsDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelRoomsGetAll> HotelRoomsGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelRoomsGetByAdult> HotelRoomsGetByAdults { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelRoomsGetByChild> HotelRoomsGetByChildren { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelRoomsGetByHotelBuyRoomId> HotelRoomsGetByHotelBuyRoomIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelRoomsGetById> HotelRoomsGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelRoomsGetByInfant> HotelRoomsGetByInfants { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelRoomsGetByName> HotelRoomsGetByNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelRoomsGetByRoomId> HotelRoomsGetByRoomIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelRoomsInsert> HotelRoomsInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelRoomsUpdate> HotelRoomsUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelsDelete> HotelsDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelSeasonsGetAll> HotelSeasonsGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelSeasonsInsert> HotelSeasonsInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelsGetAll> HotelsGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelsGetByAddress> HotelsGetByAddresses { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelsGetByCityId> HotelsGetByCityIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelsGetByCommercialContactId> HotelsGetByCommercialContactIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelsGetByCountryId> HotelsGetByCountryIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelsGetByFinanceContactId> HotelsGetByFinanceContactIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelsGetByHotelChainId> HotelsGetByHotelChainIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelsGetByHotelTypeId> HotelsGetByHotelTypeIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelsGetById> HotelsGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelsGetByLatitude> HotelsGetByLatitudes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelsGetByLongitude> HotelsGetByLongitudes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelsGetByName> HotelsGetByNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelsGetByNumberRoom> HotelsGetByNumberRooms { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelsGetByRegionId> HotelsGetByRegionIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelsGetByRelease> HotelsGetByReleases { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelsGetByReservationContactId> HotelsGetByReservationContactIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelsGetByZipCode> HotelsGetByZipCodes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelsGetByZoneId> HotelsGetByZoneIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelsInsert> HotelsInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelsUpdate> HotelsUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelTypeLanguagesDelete> HotelTypeLanguagesDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelTypeLanguagesGetAll> HotelTypeLanguagesGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelTypeLanguagesGetByHotelTypeId> HotelTypeLanguagesGetByHotelTypeIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelTypeLanguagesGetById> HotelTypeLanguagesGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelTypeLanguagesGetByLanguageId> HotelTypeLanguagesGetByLanguageIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelTypeLanguagesGetByName> HotelTypeLanguagesGetByNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelTypeLanguagesInsert> HotelTypeLanguagesInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelTypeLanguagesUpdate> HotelTypeLanguagesUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelTypesDelete> HotelTypesDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelTypesGetAll> HotelTypesGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelTypesGetById> HotelTypesGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelTypesGetByName> HotelTypesGetByNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelTypesInsert> HotelTypesInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.HotelTypesUpdate> HotelTypesUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LanguagesDelete> LanguagesDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LanguagesGetAll> LanguagesGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LanguagesGetById> LanguagesGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LanguagesGetByName> LanguagesGetByNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LanguagesInsert> LanguagesInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LanguagesUpdate> LanguagesUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LogPermissionsDelete> LogPermissionsDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LogPermissionsGetAll> LogPermissionsGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LogPermissionsGetByCanClassInit> LogPermissionsGetByCanClassInits { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LogPermissionsGetByCanClassInsert> LogPermissionsGetByCanClassInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LogPermissionsGetByCanClassList> LogPermissionsGetByCanClassLists { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LogPermissionsGetByCanClassUpdate> LogPermissionsGetByCanClassUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LogPermissionsGetByCanDelete> LogPermissionsGetByCanDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LogPermissionsGetByCanGetList> LogPermissionsGetByCanGetLists { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LogPermissionsGetByCanGetOne> LogPermissionsGetByCanGetOnes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LogPermissionsGetByCanInsert> LogPermissionsGetByCanInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LogPermissionsGetByCanUpdate> LogPermissionsGetByCanUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LogPermissionsGetByCanView> LogPermissionsGetByCanViews { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LogPermissionsGetByChangeDate> LogPermissionsGetByChangeDates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LogPermissionsGetByDatabaseTable> LogPermissionsGetByDatabaseTables { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LogPermissionsGetById> LogPermissionsGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LogPermissionsGetByModifyBy> LogPermissionsGetByModifyBies { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LogPermissionsGetByModifyDate> LogPermissionsGetByModifyDates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LogPermissionsGetByNote> LogPermissionsGetByNotes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LogPermissionsGetByProduct> LogPermissionsGetByProducts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LogPermissionsGetByUserId> LogPermissionsGetByUserIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LogPermissionsGetChangeDateBetween> LogPermissionsGetChangeDateBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LogPermissionsGetModifyDateBetween> LogPermissionsGetModifyDateBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LogPermissionsInsert> LogPermissionsInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LogPermissionsUpdate> LogPermissionsUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LogsDelete> LogsDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LogsGetAll> LogsGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LogsGetByDate> LogsGetByDates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LogsGetByDescription> LogsGetByDescriptions { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LogsGetById> LogsGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LogsGetByLogMethod> LogsGetByLogMethods { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LogsGetByLogPath> LogsGetByLogPaths { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LogsGetByType> LogsGetByTypes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LogsGetByUrlOriginalString> LogsGetByUrlOriginalStrings { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LogsGetByUserAgent> LogsGetByUserAgents { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LogsGetByUserHostAddress> LogsGetByUserHostAddresses { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LogsGetByUserId> LogsGetByUserIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LogsGetDateBetween> LogsGetDateBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LogsInsert> LogsInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.LogsUpdate> LogsUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.MenuDelete> MenuDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.MenuGetAll> MenuGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.MenuGetByColor> MenuGetByColors { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.MenuGetByIcon> MenuGetByIcons { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.MenuGetById> MenuGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.MenuGetByTitle> MenuGetByTitles { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.MenuGetByTitleArabic> MenuGetByTitleArabics { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.MenuGetByTitleEng> MenuGetByTitleEngs { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.MenuGetByUrl> MenuGetByUrls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.MenuInsert> MenuInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.MenuUpdate> MenuUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.OgSeoDelete> OgSeoDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.OgSeoGetAll> OgSeoGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.OgSeoGetById> OgSeoGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.OgSeoGetByogDescription> OgSeoGetByogDescriptions { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.OgSeoGetByogImage> OgSeoGetByogImages { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.OgSeoGetByogTitle> OgSeoGetByogTitles { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.OgSeoGetByPageId> OgSeoGetByPageIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.OgSeoGetByPageType> OgSeoGetByPageTypes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.OgSeoGetByseoDescription> OgSeoGetByseoDescriptions { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.OgSeoGetByseoKeyword> OgSeoGetByseoKeywords { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.OgSeoGetByseoTitle> OgSeoGetByseoTitles { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.OgSeoInsert> OgSeoInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.OgSeoUpdate> OgSeoUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PageContentDelete> PageContentDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PageContentGetAll> PageContentGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PageContentGetByContent> PageContentGetByContents { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PageContentGetByCreateDate> PageContentGetByCreateDates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PageContentGetById> PageContentGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PageContentGetByImage> PageContentGetByImages { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PageContentGetByLanguageId> PageContentGetByLanguageIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PageContentGetByPageUrl> PageContentGetByPageUrls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PageContentGetBySubTitle> PageContentGetBySubTitles { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PageContentGetByTableOrder> PageContentGetByTableOrders { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PageContentGetByTitle> PageContentGetByTitles { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PageContentGetCreateDateBetween> PageContentGetCreateDateBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PageContentInsert> PageContentInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PageContentUpdate> PageContentUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PageTypesDelete> PageTypesDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PageTypesGetAll> PageTypesGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PageTypesGetById> PageTypesGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PageTypesGetByName> PageTypesGetByNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PageTypesInsert> PageTypesInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PageTypesUpdate> PageTypesUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PassengerInformationDelete> PassengerInformationDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PassengerInformationGetAll> PassengerInformationGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PassengerInformationGetByAdultId> PassengerInformationGetByAdultIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PassengerinformationgetbyfileId> PassengerinformationgetbyfileIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PassengerinformationgetbyfileName> PassengerinformationgetbyfileNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PassengerInformationGetByFirstName> PassengerInformationGetByFirstNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PassengerInformationGetById> PassengerInformationGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PassengerInformationGetByLastName> PassengerInformationGetByLastNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PassengerInformationGetByNationalityCode> PassengerInformationGetByNationalityCodes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PassengerInformationGetByPaxSequence> PassengerInformationGetByPaxSequences { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PassengerInformationGetByPnrpaxId> PassengerInformationGetByPnrpaxIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PassengerInformationGetByRecordDateStamp> PassengerInformationGetByRecordDateStamps { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PassengerInformationGetByTitle> PassengerInformationGetByTitles { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PassengerInformationGetByTotalFare> PassengerInformationGetByTotalFares { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PassengerInformationGetByTotalPaid> PassengerInformationGetByTotalPaids { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PassengerInformationGetByTotalTaxchg> PassengerInformationGetByTotalTaxchgs { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PassengerInformationGetRecordDateStampBetween> PassengerInformationGetRecordDateStampBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PassengerInformationInsert> PassengerInformationInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PassengerInformationUpdate> PassengerInformationUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PassengersDelete> PassengersDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PassengersGetAll> PassengersGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PassengersGetById> PassengersGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PassengersGetByPassemgerTimestamp> PassengersGetByPassemgerTimestamps { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PassengersGetByPassengerActive> PassengersGetByPassengerActives { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PassengersGetByPassengerCelPhone> PassengersGetByPassengerCelPhones { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PassengersGetByPassengerEmail> PassengersGetByPassengerEmails { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PassengersGetByPassengerFullName> PassengersGetByPassengerFullNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PassengersGetByPassengerJobPosition> PassengersGetByPassengerJobPositions { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PassengersGetByPassengerPhone> PassengersGetByPassengerPhones { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PassengersGetByPassengerVıp> PassengersGetByPassengerVıps { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PassengersGetPassemgerTimestampBetween> PassengersGetPassemgerTimestampBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PassengersInsert> PassengersInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PassengersUpdate> PassengersUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PnrCustomFieldsDelete> PnrCustomFieldsDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PnrCustomFieldsGetAll> PnrCustomFieldsGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PnrCustomFieldsGetByFiTyActive> PnrCustomFieldsGetByFiTyActives { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PnrCustomFieldsGetByFiTyId> PnrCustomFieldsGetByFiTyIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PnrCustomFieldsGetByFiTyTimestamp> PnrCustomFieldsGetByFiTyTimestamps { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PnrCustomFieldsGetById> PnrCustomFieldsGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PnrCustomFieldsGetByPnCuValue> PnrCustomFieldsGetByPnCuValues { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PnrCustomFieldsGetByPnrId> PnrCustomFieldsGetByPnrIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PnrCustomFieldsGetFiTyTimestampBetween> PnrCustomFieldsGetFiTyTimestampBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PnrCustomFieldsInsert> PnrCustomFieldsInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PnrCustomFieldsUpdate> PnrCustomFieldsUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PnRsDelete> PnRsDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PnRsGetAll> PnRsGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PnRsGetByAgencyId> PnRsGetByAgencyIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PnRsGetByCompanyId> PnRsGetByCompanyIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PnRsGetById> PnRsGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PnRsGetByPassengerId> PnRsGetByPassengerIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PnRsGetByPccId> PnRsGetByPccIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PnRsGetByPnrActive> PnRsGetByPnrActives { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PnRsGetByPnrRecord> PnRsGetByPnrRecords { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PnRsGetByPnrTimestamp> PnRsGetByPnrTimestamps { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PnRsGetPnrTimestampBetween> PnRsGetPnrTimestampBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PnRsInsert> PnRsInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PnRsUpdate> PnRsUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PossibleQueryDelete> PossibleQueryDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PossibleQueryGetAll> PossibleQueryGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PossibleQueryGetById> PossibleQueryGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PossibleQueryGetByQuery> PossibleQueryGetByQueries { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PossibleQueryInsert> PossibleQueryInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.PossibleQueryUpdate> PossibleQueryUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ProvidersDelete> ProvidersDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ProvidersGetAll> ProvidersGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ProvidersGetByAddress> ProvidersGetByAddresses { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ProvidersGetByComercialContactId> ProvidersGetByComercialContactIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ProvidersGetByFinanceContactId> ProvidersGetByFinanceContactIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ProvidersGetById> ProvidersGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ProvidersGetByName> ProvidersGetByNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ProvidersGetByReservationContactId> ProvidersGetByReservationContactIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ProvidersGetByWebsite> ProvidersGetByWebsites { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ProvidersInsert> ProvidersInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ProvidersUpdate> ProvidersUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ProvienceDelete> ProvienceDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ProvienceGetAll> ProvienceGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ProvienceGetByCityId> ProvienceGetByCityIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ProvienceGetById> ProvienceGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ProvienceGetByInformation> ProvienceGetByInformations { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ProvienceGetByListImage> ProvienceGetByListImages { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ProvienceGetByName> ProvienceGetByNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ProvienceGetByStatu> ProvienceGetByStatus { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ProvienceGetByTableOrder> ProvienceGetByTableOrders { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ProvienceInsert> ProvienceInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ProvienceUpdate> ProvienceUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.RegionsDelete> RegionsDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.RegionsGetAll> RegionsGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.RegionsGetByCountryId> RegionsGetByCountryIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.RegionsGetById> RegionsGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.RegionsGetByLatLongBound> RegionsGetByLatLongBounds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.RegionsGetByName> RegionsGetByNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.RegionsInsert> RegionsInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.RegionsUpdate> RegionsUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ReservationDetailsDelete> ReservationDetailsDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ReservationDetailsGetAll> ReservationDetailsGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ReservationDetailsGetByApartPrice> ReservationDetailsGetByApartPrices { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ReservationDetailsGetById> ReservationDetailsGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ReservationDetailsGetByPropertId> ReservationDetailsGetByPropertIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ReservationDetailsGetByPropertPrice> ReservationDetailsGetByPropertPrices { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ReservationDetailsGetByRezervationId> ReservationDetailsGetByRezervationIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ReservationDetailsInsert> ReservationDetailsInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ReservationDetailsUpdate> ReservationDetailsUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ReservationsDelete> ReservationsDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ReservationsGetAll> ReservationsGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ReservationsGetByApartId> ReservationsGetByApartIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ReservationsGetByCustomerId> ReservationsGetByCustomerIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ReservationsGetByFinishDate> ReservationsGetByFinishDates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ReservationsGetById> ReservationsGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ReservationsGetByNote> ReservationsGetByNotes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ReservationsGetByPaymentCompleted> ReservationsGetByPaymentCompleteds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ReservationsGetByPaymentType> ReservationsGetByPaymentTypes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ReservationsGetByReferenceCode> ReservationsGetByReferenceCodes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ReservationsGetByStartDate> ReservationsGetByStartDates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ReservationsGetByTotalPrice> ReservationsGetByTotalPrices { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ReservationsGetFinishDateBetween> ReservationsGetFinishDateBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ReservationsGetStartDateBetween> ReservationsGetStartDateBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ReservationsInsert> ReservationsInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ReservationsUpdate> ReservationsUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.RoomsDelete> RoomsDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.RoomsGetAll> RoomsGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.RoomsGetByAdult> RoomsGetByAdults { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.RoomsGetByChild> RoomsGetByChildren { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.RoomsGetByDescription> RoomsGetByDescriptions { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.RoomsGetById> RoomsGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.RoomsGetByInfant> RoomsGetByInfants { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.RoomsGetByName> RoomsGetByNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.RoomsInsert> RoomsInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.RoomsUpdate> RoomsUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.StatusDelete> StatusDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.StatusGetAll> StatusGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.StatusGetById> StatusGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.StatusGetByName> StatusGetByNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.StatusInsert> StatusInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.StatusUpdate> StatusUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierBuyingDestinationsDelete> SupplierBuyingDestinationsDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierBuyingDestinationsGetAll> SupplierBuyingDestinationsGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierBuyingDestinationsGetByAgencyId> SupplierBuyingDestinationsGetByAgencyIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierBuyingDestinationsGetByCity> SupplierBuyingDestinationsGetByCities { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierBuyingDestinationsGetByCountry> SupplierBuyingDestinationsGetByCountries { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierBuyingDestinationsGetByCreatedBy> SupplierBuyingDestinationsGetByCreatedBies { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierBuyingDestinationsGetByCreatedDate> SupplierBuyingDestinationsGetByCreatedDates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierBuyingDestinationsGetById> SupplierBuyingDestinationsGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierBuyingDestinationsGetByTableOrder> SupplierBuyingDestinationsGetByTableOrders { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierBuyingDestinationsGetByUpdatedBy> SupplierBuyingDestinationsGetByUpdatedBies { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierBuyingDestinationsGetByUpdatedDate> SupplierBuyingDestinationsGetByUpdatedDates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierBuyingDestinationsGetCreatedDateBetween> SupplierBuyingDestinationsGetCreatedDateBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierBuyingDestinationsGetUpdatedDateBetween> SupplierBuyingDestinationsGetUpdatedDateBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierBuyingDestinationsInsert> SupplierBuyingDestinationsInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierBuyingDestinationsUpdate> SupplierBuyingDestinationsUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierFeesDelete> SupplierFeesDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierFeesGetAll> SupplierFeesGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierFeesGetByAmount> SupplierFeesGetByAmounts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierFeesGetByByPercentage> SupplierFeesGetByByPercentages { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierFeesGetByCreatedBy> SupplierFeesGetByCreatedBies { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierFeesGetByCreatedDate> SupplierFeesGetByCreatedDates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierFeesGetByCurrencyId> SupplierFeesGetByCurrencyIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierFeesGetById> SupplierFeesGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierFeesGetByProductId> SupplierFeesGetByProductIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierFeesGetBySupplierId> SupplierFeesGetBySupplierIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierFeesGetByUpdatedBy> SupplierFeesGetByUpdatedBies { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierFeesGetByUpdatedDate> SupplierFeesGetByUpdatedDates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierFeesGetCreatedDateBetween> SupplierFeesGetCreatedDateBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierFeesGetUpdatedDateBetween> SupplierFeesGetUpdatedDateBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierFeesInsert> SupplierFeesInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierFeesUpdate> SupplierFeesUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierProductTypeDelete> SupplierProductTypeDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierProductTypeGetAll> SupplierProductTypeGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierProductTypeGetByCreatedBy> SupplierProductTypeGetByCreatedBies { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierProductTypeGetByCreatedDate> SupplierProductTypeGetByCreatedDates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierProductTypeGetById> SupplierProductTypeGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierProductTypeGetByName> SupplierProductTypeGetByNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierProductTypeGetByUpdatedBy> SupplierProductTypeGetByUpdatedBies { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierProductTypeGetByUpdatedDate> SupplierProductTypeGetByUpdatedDates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierProductTypeGetCreatedDateBetween> SupplierProductTypeGetCreatedDateBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierProductTypeGetUpdatedDateBetween> SupplierProductTypeGetUpdatedDateBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierProductTypeInsert> SupplierProductTypeInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierProductTypeUpdate> SupplierProductTypeUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierRegisteredProductsDelete> SupplierRegisteredProductsDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierRegisteredProductsGetAll> SupplierRegisteredProductsGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierRegisteredProductsGetByContractInfo> SupplierRegisteredProductsGetByContractInfos { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierRegisteredProductsGetByCreatedBy> SupplierRegisteredProductsGetByCreatedBies { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierRegisteredProductsGetByCreatedDate> SupplierRegisteredProductsGetByCreatedDates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierRegisteredProductsGetByFee> SupplierRegisteredProductsGetByFees { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierRegisteredProductsGetById> SupplierRegisteredProductsGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierRegisteredProductsGetByProductTypeId> SupplierRegisteredProductsGetByProductTypeIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierRegisteredProductsGetBySupplierId> SupplierRegisteredProductsGetBySupplierIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierRegisteredProductsGetByUpdatedBy> SupplierRegisteredProductsGetByUpdatedBies { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierRegisteredProductsGetByUpdatedDate> SupplierRegisteredProductsGetByUpdatedDates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierRegisteredProductsGetCreatedDateBetween> SupplierRegisteredProductsGetCreatedDateBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierRegisteredProductsGetUpdatedDateBetween> SupplierRegisteredProductsGetUpdatedDateBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierRegisteredProductsInsert> SupplierRegisteredProductsInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierRegisteredProductsUpdate> SupplierRegisteredProductsUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SuppliersDelete> SuppliersDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierSellingDestinationsDelete> SupplierSellingDestinationsDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierSellingDestinationsGetAll> SupplierSellingDestinationsGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierSellingDestinationsGetByCity> SupplierSellingDestinationsGetByCities { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierSellingDestinationsGetByCountry> SupplierSellingDestinationsGetByCountries { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierSellingDestinationsGetByCreatedBy> SupplierSellingDestinationsGetByCreatedBies { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierSellingDestinationsGetByCreatedDate> SupplierSellingDestinationsGetByCreatedDates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierSellingDestinationsGetById> SupplierSellingDestinationsGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierSellingDestinationsGetBySupplierId> SupplierSellingDestinationsGetBySupplierIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierSellingDestinationsGetByTableOrder> SupplierSellingDestinationsGetByTableOrders { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierSellingDestinationsGetByUpdatedBy> SupplierSellingDestinationsGetByUpdatedBies { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierSellingDestinationsGetByUpdatedDate> SupplierSellingDestinationsGetByUpdatedDates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierSellingDestinationsGetCreatedDateBetween> SupplierSellingDestinationsGetCreatedDateBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierSellingDestinationsGetUpdatedDateBetween> SupplierSellingDestinationsGetUpdatedDateBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierSellingDestinationsInsert> SupplierSellingDestinationsInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierSellingDestinationsUpdate> SupplierSellingDestinationsUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SuppliersGetAll> SuppliersGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SuppliersGetByAcceptProduct> SuppliersGetByAcceptProducts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SuppliersGetByAcceptReseller> SuppliersGetByAcceptResellers { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SuppliersGetByAcceptSupplier> SuppliersGetByAcceptSuppliers { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SuppliersGetByBriefDescription> SuppliersGetByBriefDescriptions { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SuppliersGetByCreatedBy> SuppliersGetByCreatedBies { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SuppliersGetByCreatedDate> SuppliersGetByCreatedDates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SuppliersGetById> SuppliersGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SuppliersGetByIsReseller> SuppliersGetByIsResellers { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SuppliersGetByIsSupplier> SuppliersGetByIsSuppliers { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SuppliersGetByLogo> SuppliersGetByLogos { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SuppliersGetByName> SuppliersGetByNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SuppliersGetBySourceMarketCountryId> SuppliersGetBySourceMarketCountryIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SuppliersGetBySupplierId> SuppliersGetBySupplierIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SuppliersGetBySupplierTypeId> SuppliersGetBySupplierTypeIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SuppliersGetByUpdatedBy> SuppliersGetByUpdatedBies { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SuppliersGetByUpdatedDate> SuppliersGetByUpdatedDates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SuppliersGetByWebsite> SuppliersGetByWebsites { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SuppliersGetCreatedDateBetween> SuppliersGetCreatedDateBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SuppliersGetUpdatedDateBetween> SuppliersGetUpdatedDateBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SuppliersInsert> SuppliersInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SuppliersUpdate> SuppliersUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierTypeDelete> SupplierTypeDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierTypeGetAll> SupplierTypeGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierTypeGetById> SupplierTypeGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierTypeGetByName> SupplierTypeGetByNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierTypeInsert> SupplierTypeInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.SupplierTypeUpdate> SupplierTypeUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.TerminalDelete> TerminalDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.TerminalGetAll> TerminalGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.TerminalGetByAirportId> TerminalGetByAirportIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.TerminalGetById> TerminalGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.TerminalGetByTerminalActive> TerminalGetByTerminalActives { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.TerminalGetByTerminalCode> TerminalGetByTerminalCodes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.TerminalGetByTerminalName> TerminalGetByTerminalNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.TerminalGetByTerminalTimestamp> TerminalGetByTerminalTimestamps { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.TerminalGetTerminalTimestampBetween> TerminalGetTerminalTimestampBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.TerminalInsert> TerminalInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.TerminalUpdate> TerminalUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ThemeStyleDelete> ThemeStyleDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ThemeStyleGetAll> ThemeStyleGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ThemeStyleGetById> ThemeStyleGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ThemeStyleGetByName> ThemeStyleGetByNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ThemeStyleGetByPath> ThemeStyleGetByPaths { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ThemeStyleGetByProperty> ThemeStyleGetByProperties { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ThemeStyleInsert> ThemeStyleInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ThemeStyleUpdate> ThemeStyleUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UrlsDelete> UrlsDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UrlsGetAll> UrlsGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UrlsGetByFriendlyUrl> UrlsGetByFriendlyUrls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UrlsGetById> UrlsGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UrlsGetByIsDefault> UrlsGetByIsDefaults { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UrlsGetByLanguageId> UrlsGetByLanguageIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UrlsGetByPageId> UrlsGetByPageIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UrlsGetByPageName> UrlsGetByPageNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UrlsGetByPageView> UrlsGetByPageViews { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UrlsInsert> UrlsInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UrlsUpdate> UrlsUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UserPreferencesDelete> UserPreferencesDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UserPreferencesGetAll> UserPreferencesGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UserPreferencesGetByHeaderColor> UserPreferencesGetByHeaderColors { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UserPreferencesGetById> UserPreferencesGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UserPreferencesGetByProduct> UserPreferencesGetByProducts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UserPreferencesGetBySideBarColor> UserPreferencesGetBySideBarColors { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UserPreferencesGetByThemeStyle> UserPreferencesGetByThemeStyles { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UserPreferencesGetByUserId> UserPreferencesGetByUserIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UserPreferencesInsert> UserPreferencesInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UserPreferencesUpdate> UserPreferencesUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UsersDelete> UsersDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UsersGetAll> UsersGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UsersGetBirthDateBetween> UsersGetBirthDateBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UsersGetByBirthDate> UsersGetByBirthDates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UsersGetByBirthPlace> UsersGetByBirthPlaces { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UsersGetByCreateDate> UsersGetByCreateDates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UsersGetByEmail> UsersGetByEmails { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UsersGetByGender> UsersGetByGenders { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UsersGetByGovernmentId> UsersGetByGovernmentIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UsersGetById> UsersGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UsersGetByIsMaster> UsersGetByIsMasters { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UsersGetByIsSuperAdmin> UsersGetByIsSuperAdmins { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UsersGetByMaritalStatus> UsersGetByMaritalStatuses { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UsersGetByMotherName> UsersGetByMotherNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UsersGetByName> UsersGetByNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UsersGetByPassword> UsersGetByPasswords { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UsersGetByProduct> UsersGetByProducts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UsersGetByStatus> UsersGetByStatuses { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UsersGetBySurname> UsersGetBySurnames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UsersGetByUserName> UsersGetByUserNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UsersGetByUserType> UsersGetByUserTypes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UsersGetCreateDateBetween> UsersGetCreateDateBetweens { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UsersInsert> UsersInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UsersUpdate> UsersUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UserTypeDelete> UserTypeDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UserTypeGetAll> UserTypeGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UserTypeGetById> UserTypeGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UserTypeGetByName> UserTypeGetByNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UserTypeInsert> UserTypeInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.UserTypeUpdate> UserTypeUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.YesNoDelete> YesNoDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.YesNoGetAll> YesNoGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.YesNoGetById> YesNoGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.YesNoGetByName> YesNoGetByNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.YesNoInsert> YesNoInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.YesNoUpdate> YesNoUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ZonesCitiesDelete> ZonesCitiesDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ZonesCitiesGetAll> ZonesCitiesGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ZonesCitiesGetByCityId> ZonesCitiesGetByCityIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ZonesCitiesGetById> ZonesCitiesGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ZonesCitiesGetByMainZone> ZonesCitiesGetByMainZones { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ZonesCitiesGetByZoneId> ZonesCitiesGetByZoneIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ZonesCitiesInsert> ZonesCitiesInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ZonesCitiesUpdate> ZonesCitiesUpdates { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ZonesDelete> ZonesDeletes { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ZonesGetAll> ZonesGetAlls { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ZonesGetById> ZonesGetByIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ZonesGetByLatLongBound> ZonesGetByLatLongBounds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ZonesGetByName> ZonesGetByNames { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ZonesGetByRegionId> ZonesGetByRegionIds { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ZonesInsert> ZonesInserts { get; set; }

        public DbSet<ZarenTravel.Models.ZarenSoft.ZonesUpdate> ZonesUpdates { get; set; }
    }
}