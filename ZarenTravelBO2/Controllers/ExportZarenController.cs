using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using ZarenBO2.Data;

namespace ZarenBO2.Controllers
{
    public partial class ExportZarenController : ExportController
    {
        private readonly ZarenContext context;
        private readonly ZarenService service;

        public ExportZarenController(ZarenContext context, ZarenService service)
        {
            this.service = service;
            this.context = context;
        }

        [HttpGet("/export/Zaren/accountlikes/csv")]
        [HttpGet("/export/Zaren/accountlikes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAccountLikesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAccountLikes(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/accountlikes/excel")]
        [HttpGet("/export/Zaren/accountlikes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAccountLikesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAccountLikes(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/autocompletes/csv")]
        [HttpGet("/export/Zaren/autocompletes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAutoCompletesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAutoCompletes(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/autocompletes/excel")]
        [HttpGet("/export/Zaren/autocompletes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAutoCompletesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAutoCompletes(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/autocompletetypes/csv")]
        [HttpGet("/export/Zaren/autocompletetypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAutoCompleteTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAutoCompleteTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/autocompletetypes/excel")]
        [HttpGet("/export/Zaren/autocompletetypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAutoCompleteTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAutoCompleteTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/bookingreservations/csv")]
        [HttpGet("/export/Zaren/bookingreservations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBookingReservationsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetBookingReservations(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/bookingreservations/excel")]
        [HttpGet("/export/Zaren/bookingreservations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBookingReservationsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetBookingReservations(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/bookingtravellers/csv")]
        [HttpGet("/export/Zaren/bookingtravellers/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBookingTravellersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetBookingTravellers(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/bookingtravellers/excel")]
        [HttpGet("/export/Zaren/bookingtravellers/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBookingTravellersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetBookingTravellers(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/commissionsfordomains/csv")]
        [HttpGet("/export/Zaren/commissionsfordomains/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCommissionsForDomainsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCommissionsForDomains(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/commissionsfordomains/excel")]
        [HttpGet("/export/Zaren/commissionsfordomains/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCommissionsForDomainsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCommissionsForDomains(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/countries/csv")]
        [HttpGet("/export/Zaren/countries/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountries(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/countries/excel")]
        [HttpGet("/export/Zaren/countries/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountries(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/currencies/csv")]
        [HttpGet("/export/Zaren/currencies/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCurrenciesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCurrencies(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/currencies/excel")]
        [HttpGet("/export/Zaren/currencies/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCurrenciesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCurrencies(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/languages/csv")]
        [HttpGet("/export/Zaren/languages/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportLanguagesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetLanguages(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/languages/excel")]
        [HttpGet("/export/Zaren/languages/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportLanguagesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetLanguages(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/paymentconfigurations/csv")]
        [HttpGet("/export/Zaren/paymentconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPaymentConfigurationsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPaymentConfigurations(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/paymentconfigurations/excel")]
        [HttpGet("/export/Zaren/paymentconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPaymentConfigurationsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPaymentConfigurations(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/paymentlogs/csv")]
        [HttpGet("/export/Zaren/paymentlogs/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPaymentLogsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPaymentLogs(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/paymentlogs/excel")]
        [HttpGet("/export/Zaren/paymentlogs/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPaymentLogsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPaymentLogs(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/possiblequeries/csv")]
        [HttpGet("/export/Zaren/possiblequeries/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPossibleQueriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPossibleQueries(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/possiblequeries/excel")]
        [HttpGet("/export/Zaren/possiblequeries/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPossibleQueriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPossibleQueries(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/resources/csv")]
        [HttpGet("/export/Zaren/resources/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportResourcesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetResources(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/resources/excel")]
        [HttpGet("/export/Zaren/resources/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportResourcesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetResources(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/testcards/csv")]
        [HttpGet("/export/Zaren/testcards/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTestCardsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTestCards(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/testcards/excel")]
        [HttpGet("/export/Zaren/testcards/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTestCardsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTestCards(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/transactiondetails/csv")]
        [HttpGet("/export/Zaren/transactiondetails/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTransactionDetailsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTransactionDetails(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/transactiondetails/excel")]
        [HttpGet("/export/Zaren/transactiondetails/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTransactionDetailsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTransactionDetails(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/transactions/csv")]
        [HttpGet("/export/Zaren/transactions/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTransactionsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTransactions(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/transactions/excel")]
        [HttpGet("/export/Zaren/transactions/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTransactionsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTransactions(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/paymentoptions/csv")]
        [HttpGet("/export/Zaren/paymentoptions/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPaymentOptionsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPaymentOptions(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/paymentoptions/excel")]
        [HttpGet("/export/Zaren/paymentoptions/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPaymentOptionsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPaymentOptions(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/paymentproviders/csv")]
        [HttpGet("/export/Zaren/paymentproviders/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPaymentProvidersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPaymentProviders(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/paymentproviders/excel")]
        [HttpGet("/export/Zaren/paymentproviders/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPaymentProvidersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPaymentProviders(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/paymentreservationstatuses/csv")]
        [HttpGet("/export/Zaren/paymentreservationstatuses/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPaymentReservationStatusesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPaymentReservationStatuses(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/paymentreservationstatuses/excel")]
        [HttpGet("/export/Zaren/paymentreservationstatuses/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPaymentReservationStatusesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPaymentReservationStatuses(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/paymentstatuses/csv")]
        [HttpGet("/export/Zaren/paymentstatuses/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPaymentStatusesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPaymentStatuses(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/paymentstatuses/excel")]
        [HttpGet("/export/Zaren/paymentstatuses/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPaymentStatusesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPaymentStatuses(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/paymenttransactionresponsetypes/csv")]
        [HttpGet("/export/Zaren/paymenttransactionresponsetypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPaymentTransactionResponseTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPaymentTransactionResponseTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/paymenttransactionresponsetypes/excel")]
        [HttpGet("/export/Zaren/paymenttransactionresponsetypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPaymentTransactionResponseTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPaymentTransactionResponseTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/paymenttransactionstatuses/csv")]
        [HttpGet("/export/Zaren/paymenttransactionstatuses/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPaymentTransactionStatusesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPaymentTransactionStatuses(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/paymenttransactionstatuses/excel")]
        [HttpGet("/export/Zaren/paymenttransactionstatuses/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPaymentTransactionStatusesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPaymentTransactionStatuses(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/paymenttransactiontypes/csv")]
        [HttpGet("/export/Zaren/paymenttransactiontypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPaymentTransactionTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPaymentTransactionTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/paymenttransactiontypes/excel")]
        [HttpGet("/export/Zaren/paymenttransactiontypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPaymentTransactionTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPaymentTransactionTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/aspnetroleclaims/csv")]
        [HttpGet("/export/Zaren/aspnetroleclaims/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAspNetRoleClaimsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAspNetRoleClaims(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/aspnetroleclaims/excel")]
        [HttpGet("/export/Zaren/aspnetroleclaims/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAspNetRoleClaimsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAspNetRoleClaims(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/aspnetroles/csv")]
        [HttpGet("/export/Zaren/aspnetroles/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAspNetRolesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAspNetRoles(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/aspnetroles/excel")]
        [HttpGet("/export/Zaren/aspnetroles/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAspNetRolesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAspNetRoles(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/aspnetuserclaims/csv")]
        [HttpGet("/export/Zaren/aspnetuserclaims/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAspNetUserClaimsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAspNetUserClaims(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/aspnetuserclaims/excel")]
        [HttpGet("/export/Zaren/aspnetuserclaims/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAspNetUserClaimsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAspNetUserClaims(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/aspnetuserlogins/csv")]
        [HttpGet("/export/Zaren/aspnetuserlogins/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAspNetUserLoginsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAspNetUserLogins(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/aspnetuserlogins/excel")]
        [HttpGet("/export/Zaren/aspnetuserlogins/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAspNetUserLoginsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAspNetUserLogins(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/aspnetuserroles/csv")]
        [HttpGet("/export/Zaren/aspnetuserroles/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAspNetUserRolesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAspNetUserRoles(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/aspnetuserroles/excel")]
        [HttpGet("/export/Zaren/aspnetuserroles/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAspNetUserRolesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAspNetUserRoles(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/aspnetusers/csv")]
        [HttpGet("/export/Zaren/aspnetusers/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAspNetUsersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAspNetUsers(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/aspnetusers/excel")]
        [HttpGet("/export/Zaren/aspnetusers/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAspNetUsersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAspNetUsers(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/aspnetusertokens/csv")]
        [HttpGet("/export/Zaren/aspnetusertokens/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAspNetUserTokensToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAspNetUserTokens(), Request.Query), fileName);
        }

        [HttpGet("/export/Zaren/aspnetusertokens/excel")]
        [HttpGet("/export/Zaren/aspnetusertokens/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAspNetUserTokensToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAspNetUserTokens(), Request.Query), fileName);
        }
    }
}
