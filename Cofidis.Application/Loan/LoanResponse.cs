namespace Cofidis.Application.Loan;

public class LoanResponse
{
    public bool Approved { get; set; }
    public decimal ApprovedLoanAmount { get; set; }
    public string? Message { get; set; }
}