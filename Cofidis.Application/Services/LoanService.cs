using Cofidis.Application.Interfaces;
using Cofidis.Application.Loan;
using Cofidis.Domain.Interfaces;
using Cofidis.Domain.Validation;
using System.Text.RegularExpressions;

namespace Cofidis.Application.Services;

public class LoanService : ILoanService
{
    private readonly ICreditLimitRepository _creditLimitRepository;
    private readonly IRiskService _riskService;

    public LoanService(ICreditLimitRepository creditLimitRepository, IRiskService riskService)
    {
        _creditLimitRepository = creditLimitRepository;
        _riskService = riskService;
    }

    public async Task<LoanResponse> ProcessLoanRequestAsync(LoanRequest loanRequest)
    {
        ValidationLoanRequest(loanRequest);

        var databyNIF = _riskService.GetDataByNIF(loanRequest.NIF);

        if (databyNIF.IsCreditworthy)
        {
            var credit = _creditLimitRepository.GetCreditLimit(databyNIF.Salary);
            return new LoanResponse { Approved = true, ApprovedLoanAmount = credit, Message = "Loan approved successfully" };
        }

        return new LoanResponse { Approved = false, ApprovedLoanAmount = 0, Message = "Loan reproved" };
    }

    private void ValidationLoanRequest(LoanRequest loanRequest)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(loanRequest.NIF),
            "Invalid NIF. NIF is required");
        DomainExceptionValidation.When(IsValidNIF(loanRequest.NIF), "Invalid NIF");
    }

    private static bool IsValidNIF(string nif)
    {
        return !Regex.IsMatch(nif, @"^\d{9}$");
    }
}