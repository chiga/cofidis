using Cofidis.Application.Loan;

namespace Cofidis.Application.Interfaces;

public interface ILoanService
{
    Task<LoanResponse> ProcessLoanRequestAsync(LoanRequest loanRequest);
}