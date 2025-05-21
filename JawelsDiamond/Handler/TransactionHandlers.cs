using JawelsDiamond.Factory;
using JawelsDiamond.Models;
using JawelsDiamond.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Handler
{
    public class TransactionHandlers
    {
        public static List<TransactionHeader> GetUserTransactions(int userId)
        {
            return TransactionRepository.GetTransactionsByUserId(userId);
        }

        public static List<TransactionDetail> GetUserTransactionsDetailed(int transactionId)
        {
            return TransactionRepository.GetDetailedTransactionsById(transactionId);
        }

        public static void UpdateTransactionStatus(int id, string status)
        {
            TransactionRepository.UpdateTransactionStatus(id, status);
        }

        public static List<TransactionHeader> GetFinishedTransactions()
        {
            return TransactionRepository.GetFinishedTransactions();
        }

        public static List<TransactionHeader> GetUnfinishedTransactions()
        {
            return TransactionRepository.GetUnfinishedTransactions();
        }
    }
}