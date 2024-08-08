using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public  class Transaction : EntityBase
    {
        public int TransId { get; set; }
        public int WalletId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string? TransactionType { get; set; }

        public override string ToString()
        {
            return $"Transaction Detials: {TransId} : {WalletId} : {TransactionDate} : {Amount} : {TransactionType}";
        }
    }
}
