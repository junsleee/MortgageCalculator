namespace MortgageCalculator
{
    public class MortgageCalculation
    {
        //fields
        private int Term; //months
        private double InterestRate; //interest rate in % or not
        private double Loan; //same as total principal for our purposes
        
        //properties
        public double RemainingBalance { get; set; } // Previous remaining balance - principal payment
        public double InterestPayment { get; set; } // previous remaining balance * interstRate/1200
        public double PrincipalPayment { get; set; } // total monthly payment - interest payment | loan amount

        //constructor
        

        //methods
    }
}
