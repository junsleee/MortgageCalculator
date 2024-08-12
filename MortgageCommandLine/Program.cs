using MortgageCalculator;
namespace MortgageCommandLine
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my Mortgage Calculator!");
            //word
            Console.Write("Enter the term of the mortgage (in months): ");
            int term = int.Parse(Console.ReadLine());

            Console.Write("Enter the annual interest rate (in %): ");
            double interestRate = double.Parse(Console.ReadLine());

            Console.Write("Enter the loan amount: ");
            double loan = double.Parse(Console.ReadLine());

            MortgageCalculation mortgage = new MortgageCalculation(term, interestRate, loan);

            Console.WriteLine($"\nMonthly Payment: {mortgage.totalMonthlyPayment:C}");
            Console.WriteLine($"Total Interest: {mortgage.totalInterest:C}");
            Console.WriteLine($"Total Cost: {mortgage.totalCost:C}");

           
            Console.Write("\nDo you want to calculate the remaining balance after a certain number of months? (y/n): ");
            string response = Console.ReadLine();

            if (response.ToLower() == "y")
            {
                Console.Write("Enter the number of months: ");
                int monthsPaid = int.Parse(Console.ReadLine());

                double remainingBalance = mortgage.CalculatePreviousRemainingBalance(monthsPaid);
                Console.WriteLine($"Remaining Balance after {monthsPaid} months: {remainingBalance:C}");
            }

            Console.WriteLine("\nThank you for using the Mortgage Calculator!");
        }
    }
}
