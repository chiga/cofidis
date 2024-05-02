using Cofidis.Application.Interfaces;
using Cofidis.Application.Loan;
using Microsoft.AspNetCore.Mvc;

namespace Cofidis.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoanController : ControllerBase
{
    private readonly ILoanService _loanService;

    public LoanController(ILoanService loanService)
    {
        _loanService = loanService;
    }

    [HttpPost("request")]
    public async Task<IActionResult> RequestLoan([FromBody] LoanRequest loanRequest)
    {
        try
        {
            var response = await _loanService.ProcessLoanRequestAsync(loanRequest);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}