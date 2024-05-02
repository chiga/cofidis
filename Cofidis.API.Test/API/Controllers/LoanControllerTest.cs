using Cofidis.API.Controllers;
using Cofidis.Application.Interfaces;
using Cofidis.Application.Loan;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace CofidisTests.API.Controllers;

public class LoanControllerTest
{
    private readonly ILoanService _loanService = Substitute.For<ILoanService>();

    [Fact]
    public async Task RequestLoan_ValidRequest_ReturnsOkResult()
    {
        // Arrange
        _loanService.ProcessLoanRequestAsync(Arg.Any<LoanRequest>()).Returns(Task.FromResult(new LoanResponse()));
        var controller = new LoanController(_loanService);

        // Act
        var result = await controller.RequestLoan(Arg.Any<LoanRequest>()) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
    }
}