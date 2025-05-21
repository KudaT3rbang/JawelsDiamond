using JawelsDiamond.Models;
using System.Data.Entity;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Web;
using System.Runtime.Remoting.Messaging;

namespace JawelsDiamond.Repository
{
    public class TransactionRepository
    {
        private static DbEntities db = DatabaseSingleton.GetInstance();

        public static void InsertTransactionHeader(TransactionHeader header)
        {
            db.TransactionHeaders.Add(header);
            db.SaveChanges();
        }

        public static void InsertTransactionDetail(TransactionDetail detail)
        {
            db.TransactionDetails.Add(detail);
            db.SaveChanges();
        }

        public static List<TransactionHeader> GetTransactionsByUserId(int userId)
        {
            return db.TransactionHeaders
                .Where(t => t.UserID == userId)
                .ToList();
        }

        public static List<TransactionDetail> GetDetailedTransactionsById(int transactionId)
        {
            return db.TransactionDetails
                .Include(td => td.MsJewel)
                .Include(td => td.TransactionHeader)
                .Where(td => td.TransactionHeader.TransactionID == transactionId)
                .ToList();
        }

        public static void UpdateTransactionStatus(int id, string status)
        {
            TransactionHeader transaction = db.TransactionHeaders.Find(id);
            if (transaction != null)
            {
                transaction.TransactionStatus = status;
                db.SaveChanges();
            }
        }

        public static List<TransactionHeader> GetFinishedTransactions()
        {
            return db.TransactionHeaders
                .Where(t => t.TransactionStatus == "Done")
                .Include(th => th.TransactionDetails)
                .Include(th => th.TransactionDetails.Select(td => td.MsJewel))
                .ToList();
        }

        public static List<TransactionHeader> GetUnfinishedTransactions()
        {
            return db.TransactionHeaders
                .Where(t => t.TransactionStatus != "Done" && t.TransactionStatus != "Rejected")
                .Include("MsUser")
                .ToList();
        }
    }
}