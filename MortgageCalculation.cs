namespace MortgageCalculator
{
    public class MortgageCalculation
    {
        //fields
        private int term; //months
        private double interestRate; //interest rate in % or not
        private double loan; //same as total principal for our purposes
        private double totalMonthlyPayment;
        private double totalInterest;
        private double totalCost;

        //properties
        public int Term { get; set; }
        public double InterestRate { get; set; }
        public double Loan { get; set; }
        public double TotalMonthlyPayment { get { return CalculateMonthlyPayments(loan, interestRate, term); } }
        public double TotalInterest { get { return CalculateTotalInterest(); } }
        public double TotalCost => CalculateTotalCost();

        //public double RemainingBalance { get { return } }
        //public double PreviousRemainingBalance = remaining balance - (total monthly payment - interest payment)
        //public double RemainingBalance { get; set; } // Previous remaining balance - principal payment
        //public double InterestPayment { get; set; } // previous remaining balance * interstRate/1200
        //public double PrincipalPayment { get; set; } // total monthly payment - interest payment | loan amount

        //constructor
        public MortgageCalculation(int term, double interestRate, double loan)
        {
            this.Term = term;
            this.InterestRate = interestRate;
            this.Loan = loan;
            
        }
        //methods
        public double CalculateMonthlyPayments(double loan, double interestRate, int term)
        {
            if (term <= 0 || interestRate < 0) return 0;

            double monthlyInterestRate = interestRate / 1200;

            return loan * (monthlyInterestRate / (1 - Math.Pow(1 + monthlyInterestRate, -term)));
        }

        public double CalculateTotalInterest()
        {
            double totalCost = TotalMonthlyPayment * Term;
            return totalCost - Loan;
        }
        public double CalculateTotalCost()
        {
            return Term * TotalMonthlyPayment;
        }
        public double CalculatePreviousRemainingBalance(int monthsPaid)
        {
            double balance = Loan;
            double monthlyInterestRate = InterestRate / 1200;
           
            for (int i = 0; i < monthsPaid; i++)
            {
                double interestPayment = balance * monthlyInterestRate;
                double principalPayment = TotalMonthlyPayment - interestPayment;
                balance -= principalPayment;
            }
            return balance;
        }
    }
}
