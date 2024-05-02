using Cofidis.Application.Interfaces;
using Cofidis.Application.Loan;
using Cofidis.Application.Services;
using Cofidis.Domain.Entities;
using Cofidis.Domain.Interfaces;
using NSubstitute;

namespace CofidisTests.Application.Services;

public class LoanServicesTests
{
    private readonly IRiskService _riskService = Substitute.For<IRiskService>();
    private readonly ICreditLimitRepository _creditLimitRepository = Substitute.For<ICreditLimitRepository>();

    [Fact]
    public async Task ProcessLoanRequestAsync_ValidRequest_Creditworthy_ReturnsApprovedLoanResponse()
    {
        // Arrange
        var loanRequest = new LoanRequest("123456789");

        _riskService.GetDataByNIF(Arg.Any<string>()).Returns(new DataByNIF("123456789") { Salary = 1000, IsCreditworthy = true });
        _creditLimitRepository.GetCreditLimit(Arg.Any<decimal>()).Returns(1000);

        var loanService = new LoanService(_creditLimitRepository, _riskService);

        // Act
        var result = await loanService.ProcessLoanRequestAsync(loanRequest);

        // Assert
        Assert.True(result.Approved);
        Assert.Equal(1000, result.ApprovedLoanAmount);
    }
}