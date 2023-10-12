﻿using Microsoft.AspNetCore.Mvc;
using Nop.Core.Security;
using Nop.Services.Security;
using Nop.Web.Areas.Admin.Factories;
using Nop.Web.Areas.Admin.Models.Reports;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Web.Areas.Admin.Controllers
{
    public partial class ReportController : BaseAdminController
    {
        #region Fields

        protected readonly IPermissionService _permissionService;
        protected readonly IReportModelFactory _reportModelFactory;

        #endregion

        #region Ctor

        public ReportController(
            IPermissionService permissionService,
            IReportModelFactory reportModelFactory)
        {
            _permissionService = permissionService;
            _reportModelFactory = reportModelFactory;
        }

        #endregion

        #region Methods

        #region Sales summary

        [CheckPermission(StandardPermission.Reports.SALES_SUMMARY_REPORT_SYSTEM_NAME)]
        public virtual async Task<IActionResult> SalesSummary()
        {
            //prepare model
            var model = await _reportModelFactory.PrepareSalesSummarySearchModelAsync(new SalesSummarySearchModel());

            return View(model);
        }

        [HttpPost]
        [CheckPermission(StandardPermission.Reports.SALES_SUMMARY_REPORT_SYSTEM_NAME)]
        public virtual async Task<IActionResult> SalesSummaryList(SalesSummarySearchModel searchModel)
        {
            //prepare model
            var model = await _reportModelFactory.PrepareSalesSummaryListModelAsync(searchModel);

            return Json(model);
        }


        #endregion

        #region Low stock

        [CheckPermission(StandardPermission.Reports.LOW_STOCK_REPORT_SYSTEM_NAME)]
        public virtual async Task<IActionResult> LowStock()
        {
            //prepare model
            var model = await _reportModelFactory.PrepareLowStockProductSearchModelAsync(new LowStockProductSearchModel());

            return View(model);
        }

        [HttpPost]
        [CheckPermission(StandardPermission.Reports.LOW_STOCK_REPORT_SYSTEM_NAME)]
        public virtual async Task<IActionResult> LowStockList(LowStockProductSearchModel searchModel)
        {
            //prepare model
            var model = await _reportModelFactory.PrepareLowStockProductListModelAsync(searchModel);

            return Json(model);
        }

        #endregion

        #region Bestsellers

        [CheckPermission(StandardPermission.Reports.BESTSELLERS_REPORT_SYSTEM_NAME)]
        public virtual async Task<IActionResult> Bestsellers()
        {
            //prepare model
            var model = await _reportModelFactory.PrepareBestsellerSearchModelAsync(new BestsellerSearchModel());

            return View(model);
        }

        [HttpPost]
        [CheckPermission(StandardPermission.Reports.BESTSELLERS_REPORT_SYSTEM_NAME)]
        public virtual async Task<IActionResult> BestsellersList(BestsellerSearchModel searchModel)
        {
            //prepare model
            var model = await _reportModelFactory.PrepareBestsellerListModelAsync(searchModel);

            return Json(model);
        }

        [HttpPost]
        [CheckPermission(StandardPermission.Reports.BESTSELLERS_REPORT_SYSTEM_NAME)]
        public virtual async Task<IActionResult> BestsellersReportAggregates(BestsellerSearchModel searchModel)
        {
            //prepare model
            var totalAmount = await _reportModelFactory.GetBestsellerTotalAmountAsync(searchModel);

            return Json(new { aggregatortotal = totalAmount });
        }

        #endregion

        #region Never Sold

        [CheckPermission(StandardPermission.Reports.PRODUCTS_NEVER_PURCHASED_REPORT_SYSTEM_NAME)]
        public virtual async Task<IActionResult> NeverSold()
        {
            //prepare model
            var model = await _reportModelFactory.PrepareNeverSoldSearchModelAsync(new NeverSoldReportSearchModel());

            return View(model);
        }

        [HttpPost]
        [CheckPermission(StandardPermission.Reports.PRODUCTS_NEVER_PURCHASED_REPORT_SYSTEM_NAME)]
        public virtual async Task<IActionResult> NeverSoldList(NeverSoldReportSearchModel searchModel)
        {
            //prepare model
            var model = await _reportModelFactory.PrepareNeverSoldListModelAsync(searchModel);

            return Json(model);
        }

        #endregion

        #region Country sales

        [CheckPermission(StandardPermission.Reports.ORDER_COUNTRY_REPORT_SYSTEM_NAME)]
        public virtual async Task<IActionResult> CountrySales()
        {
            //prepare model
            var model = await _reportModelFactory.PrepareCountrySalesSearchModelAsync(new CountryReportSearchModel());

            return View(model);
        }

        [HttpPost]
        [CheckPermission(StandardPermission.Reports.ORDER_COUNTRY_REPORT_SYSTEM_NAME)]
        public virtual async Task<IActionResult> CountrySalesList(CountryReportSearchModel searchModel)
        {
            //prepare model
            var model = await _reportModelFactory.PrepareCountrySalesListModelAsync(searchModel);

            return Json(model);
        }

        #endregion

        #region Customer reports

        [CheckPermission(StandardPermission.Reports.REGISTERED_CUSTOMERS_REPORT_SYSTEM_NAME)]
        public virtual async Task<IActionResult> RegisteredCustomers()
        {
            //prepare model
            var model = await _reportModelFactory.PrepareCustomerReportsSearchModelAsync(new CustomerReportsSearchModel());

            return View(model);
        }

        [CheckPermission(StandardPermission.Reports.CUSTOMERS_BY_ORDER_TOTAL_REPORT_SYSTEM_NAME)]
        public virtual async Task<IActionResult> BestCustomersByOrderTotal()
        {
            //prepare model
            var model = await _reportModelFactory.PrepareCustomerReportsSearchModelAsync(new CustomerReportsSearchModel());

            return View(model);
        }

        [CheckPermission(StandardPermission.Reports.CUSTOMERS_BY_NUMBER_OF_ORDERS_REPORT_SYSTEM_NAME)]
        public virtual async Task<IActionResult> BestCustomersByNumberOfOrders()
        {
            //prepare model
            var model = await _reportModelFactory.PrepareCustomerReportsSearchModelAsync(new CustomerReportsSearchModel());

            return View(model);
        }

        [HttpPost]
        [CheckPermission(StandardPermission.Reports.CUSTOMERS_BY_ORDER_TOTAL_REPORT_SYSTEM_NAME)]
        public virtual async Task<IActionResult> ReportBestCustomersByOrderTotalList(BestCustomersReportSearchModel searchModel)
        {
            //prepare model
            var model = await _reportModelFactory.PrepareBestCustomersReportListModelAsync(searchModel);

            return Json(model);
        }

        [HttpPost]
        [CheckPermission(StandardPermission.Reports.CUSTOMERS_BY_NUMBER_OF_ORDERS_REPORT_SYSTEM_NAME)]
        public virtual async Task<IActionResult> ReportBestCustomersByNumberOfOrdersList(BestCustomersReportSearchModel searchModel)
        {
            //prepare model
            var model = await _reportModelFactory.PrepareBestCustomersReportListModelAsync(searchModel);

            return Json(model);
        }

        [HttpPost]
        [CheckPermission(StandardPermission.Reports.REGISTERED_CUSTOMERS_REPORT_SYSTEM_NAME)]
        public virtual async Task<IActionResult> ReportRegisteredCustomersList(RegisteredCustomersReportSearchModel searchModel)
        {
            //prepare model
            var model = await _reportModelFactory.PrepareRegisteredCustomersReportListModelAsync(searchModel);

            return Json(model);
        }

        #endregion

        #endregion
    }
}
