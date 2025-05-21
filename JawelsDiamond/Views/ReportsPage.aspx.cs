using JawelsDiamond.Datasets;
using JawelsDiamond.Handler;
using JawelsDiamond.Models;
using JawelsDiamond.Reports;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Util;

namespace JawelsDiamond.Views
{
    public partial class ReportsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SessionHandler.RedirectIfNotLoggedIn(Session, Response);
                SessionHandler.CheckAdmin(UserHandler.GetUserIdFromSession(), Response);
            }

            TransactionReport report = new TransactionReport();
            CrystalReportView.ReportSource = report;
            DatasetReporting data = GetData(TransactionHandlers.GetFinishedTransactions());
            report.SetDataSource(data);
        }

        private DatasetReporting GetData(List<TransactionHeader> transactions)
        {
            DatasetReporting data = new DatasetReporting();
            var HeaderTable = data.TransactionHeader;
            var DetailTable = data.TransactionDetail;

            foreach (TransactionHeader t in transactions)
            {
                var headerRow = HeaderTable.NewTransactionHeaderRow();
                headerRow["Transaction ID"] = t.TransactionID;
                headerRow["User ID"] = t.UserID;
                headerRow["Payment Method"] = t.PaymentMethod;
                headerRow["Transaction Date"] = t.TransactionDate;
                headerRow["Transaction Status"] = t.TransactionStatus;

                HeaderTable.AddTransactionHeaderRow(headerRow);

                if (t.TransactionDetails != null)
                {
                    foreach (var detail in t.TransactionDetails)
                    {
                        var detailRow = DetailTable.NewTransactionDetailRow();
                        detailRow["Transaction ID"] = t.TransactionID;
                        detailRow["Jewel ID"] = detail.JewelID;
                        detailRow["Quantity"] = detail.Quantity;
                        detailRow["Jewel Name"] = detail.MsJewel.JewelName;
                        detailRow["Jewel Price"] = detail.MsJewel.JewelPrice;
                        DetailTable.AddTransactionDetailRow(detailRow);
                    }
                }
            }
            return data;
        }
    }
}