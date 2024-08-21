using CSharpOOP;

BankAccount account = new BankAccount("Sahasra Kesara", 50000);



/*Console.WriteLine(account.Balance);*/

account.MakeDeposit(35000, DateTime.Now, "Income from salary");
/*Console.WriteLine(account.Balance);*/

account.MakeWithdrawal(5000, DateTime.Now, "Rental for room");
/*Console.WriteLine(account.Balance);*/

account.MakeWithdrawal(8000, DateTime.Now, "Car service");
/*Console.WriteLine(account.Balance);*/

Console.WriteLine("Your bank account summery is: ");
Console.WriteLine("----------------------------------");
Console.WriteLine(account.GetAccountHistory());
Console.WriteLine($"Current balance is {account.Balance}");

/*
BankAccount invalidAccount;


try
{
    invalidAccount = new BankAccount("invalid", -500);
}
catch (ArgumentOutOfRangeException exception)
{
    Console.WriteLine(exception.Message);
}
*/

/*
try
{
    account.MakeWithdrawal(90000, DateTime.Now, "Computer payment");
}
catch (InvalidOperationException ex)
{
    Console.WriteLine(ex.Message);
}
*/