using Spectre.Console;
using MortgageCalculator;
using System.Security.Cryptography.X509Certificates;

namespace MortgageCalculatorConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the term in months: ");
            int term = int.Parse(Console.ReadLine());

            Console.Write("Enter the interest rate: ");
            double interestRate = double.Parse(Console.ReadLine());

            Console.Write("Enter the loan amount: ");
            double loan = double.Parse(Console.ReadLine());

            var mortgageCalculation = new MortgageCalculation(term, interestRate, loan);

            var table = new Table();
            table.AddColumn(new TableColumn("Month").Centered());
            table.AddColumn(new TableColumn("Monthly Payment").Centered());
            table.AddColumn(new TableColumn("Principal").Centered());
            table.AddColumn(new TableColumn("Interest").Centered());
            table.AddColumn(new TableColumn("Total Interest").Centered());
            table.AddColumn(new TableColumn("Balance").Centered());

            double totalInterest = 0;

            for (int i = 1; i < mortgageCalculation.Term + 1; i++)
            {
                double monthlyPayment = mortgageCalculation.CalculateMonthlyPayments();
                double previousBalance = mortgageCalculation.CalculatePreviousRemainingBalance(i - 1);
                double monthlyInterest = previousBalance * mortgageCalculation.InterestRate / 1200;
                double monthlyPrincipal = monthlyPayment - monthlyInterest;
                double remainingBalance = mortgageCalculation.CalculatePreviousRemainingBalance(i);
                totalInterest += monthlyInterest;

                table.AddRow(
                    i.ToString(),
                    $"[green]{monthlyPayment.ToString("C")}[/]",
                    $"[green]{monthlyPrincipal.ToString("C")}[/]",
                    $"[green]{monthlyInterest.ToString("C")}[/]",
                    $"[green]{totalInterest.ToString("C")}[/]",
                    $"[red]{remainingBalance.ToString("C")}[/]"
                );
            }
            AnsiConsole.Write(table);
        }
    }
}
