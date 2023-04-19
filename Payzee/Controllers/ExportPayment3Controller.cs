using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using Payzee.Data;

namespace Payzee.Controllers
{
    public partial class ExportPayment3Controller : ExportController
    {
        private readonly Payment3Context context;
        private readonly Payment3Service service;

        public ExportPayment3Controller(Payment3Context context, Payment3Service service)
        {
            this.service = service;
            this.context = context;
        }

        [HttpGet("/export/Payment3/currencies/csv")]
        [HttpGet("/export/Payment3/currencies/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCurrenciesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCurrencies(), Request.Query), fileName);
        }

        [HttpGet("/export/Payment3/currencies/excel")]
        [HttpGet("/export/Payment3/currencies/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCurrenciesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCurrencies(), Request.Query), fileName);
        }

        [HttpGet("/export/Payment3/languages/csv")]
        [HttpGet("/export/Payment3/languages/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportLanguagesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetLanguages(), Request.Query), fileName);
        }

        [HttpGet("/export/Payment3/languages/excel")]
        [HttpGet("/export/Payment3/languages/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportLanguagesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetLanguages(), Request.Query), fileName);
        }

        [HttpGet("/export/Payment3/paymentconfigurations/csv")]
        [HttpGet("/export/Payment3/paymentconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPaymentConfigurationsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPaymentConfigurations(), Request.Query), fileName);
        }

        [HttpGet("/export/Payment3/paymentconfigurations/excel")]
        [HttpGet("/export/Payment3/paymentconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPaymentConfigurationsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPaymentConfigurations(), Request.Query), fileName);
        }

        [HttpGet("/export/Payment3/paymentlogs/csv")]
        [HttpGet("/export/Payment3/paymentlogs/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPaymentLogsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPaymentLogs(), Request.Query), fileName);
        }

        [HttpGet("/export/Payment3/paymentlogs/excel")]
        [HttpGet("/export/Payment3/paymentlogs/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPaymentLogsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPaymentLogs(), Request.Query), fileName);
        }

        [HttpGet("/export/Payment3/resources/csv")]
        [HttpGet("/export/Payment3/resources/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportResourcesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetResources(), Request.Query), fileName);
        }

        [HttpGet("/export/Payment3/resources/excel")]
        [HttpGet("/export/Payment3/resources/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportResourcesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetResources(), Request.Query), fileName);
        }

        [HttpGet("/export/Payment3/testcards/csv")]
        [HttpGet("/export/Payment3/testcards/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTestCardsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTestCards(), Request.Query), fileName);
        }

        [HttpGet("/export/Payment3/testcards/excel")]
        [HttpGet("/export/Payment3/testcards/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTestCardsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTestCards(), Request.Query), fileName);
        }

        [HttpGet("/export/Payment3/transactiondetails/csv")]
        [HttpGet("/export/Payment3/transactiondetails/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTransactionDetailsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTransactionDetails(), Request.Query), fileName);
        }

        [HttpGet("/export/Payment3/transactiondetails/excel")]
        [HttpGet("/export/Payment3/transactiondetails/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTransactionDetailsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTransactionDetails(), Request.Query), fileName);
        }

        [HttpGet("/export/Payment3/transactions/csv")]
        [HttpGet("/export/Payment3/transactions/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTransactionsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTransactions(), Request.Query), fileName);
        }

        [HttpGet("/export/Payment3/transactions/excel")]
        [HttpGet("/export/Payment3/transactions/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTransactionsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTransactions(), Request.Query), fileName);
        }
    }
}
