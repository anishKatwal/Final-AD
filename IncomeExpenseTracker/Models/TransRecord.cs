using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeExpenseTracker.Models
{
    public class TransRecord
    {
        [PrimaryKey, AutoIncrement]
        public int TransId { get; set; }
        public string TransType { get; set; } = null!; // inflow, outflow, Debt
        public string TransTitle { get; set; } = null!;//Credit,gain,budget/ Debit,spending,expense/ debt
        public string TransTags { get; set; } = null!;//rent, monthly, grocessories etc.
        public double TransAmount { get; set; }//+means inflow, -ve means outflow
        public string? Notes { get; set; }//optional notes
        public DateTime TransDate { get; set; }//transDate        
        public bool? IsDebtCleared { get; set; }
        public string? DebtSource { get; set; }
        public DateTime? DueDate { get; set; }  
        public int? DebtClearId { get; set; }
    }
    public class TransSummary
    {
        public string TransDescription { get; set; } = null!;
        public string TransAmount { get; set; } = null!;
    }
}
