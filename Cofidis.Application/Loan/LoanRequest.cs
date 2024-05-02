namespace Cofidis.Application.Loan;

public class LoanRequest(string nif)
{
    public string NIF { get; set; } = nif ?? throw new ArgumentNullException(nameof(nif), "NIF cannot be null");
}