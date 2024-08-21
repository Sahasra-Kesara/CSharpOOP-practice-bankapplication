using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpOOP;

public class BankAccount
{
    private static int accountNumberSeed = 1234567890;
    private List<Transaction> allTransactions = new List<Transaction>();


    public string Number {  get; }
    public string Owner { get; set; }
    public decimal Balance
    {
        get
        {
            decimal balance = 0;

            foreach (var item in allTransactions)
            {
                balance += item.Amount;
            }

            return balance;
        }
    }


    // Constructor
    public BankAccount(string name, decimal initialBalance)
    {
        this.Owner = name;
        MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");

        this.Number = accountNumberSeed.ToString();
        accountNumberSeed++;
        
    }


    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if(amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount),
                "Amount of Deposit must be positive");
        }
        var deposit = new Transaction(amount, date, note);
        allTransactions.Add(deposit);
    }
    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        if(amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount),
                "Amount of Withdrawal must be positive");
        }

        if(this.Balance - amount < 0)
        {
            throw new InvalidOperationException("Not Sufficient funds for this withdrawals");
        }

        var withdrawal = new Transaction(-amount, date, note);
        allTransactions.Add(withdrawal);
    }
    public string GetAccountHistory()
    {
        var report = new StringBuilder();
        decimal balance = 0;

        report.AppendLine("Date\tAmount\tNote");
        foreach(var item in allTransactions)
        {
            balance += item.Amount;
            report.AppendLine($"{item.Date.ToShortDateString()}\t" +
                              $"{item.Amount}\t" +
                              $"{item.Notes}");
        }
        return report.ToString();
    }
}
