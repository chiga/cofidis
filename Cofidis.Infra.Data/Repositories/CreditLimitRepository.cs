using Cofidis.Domain.Interfaces;
using Cofidis.Infra.Data.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Cofidis.Infra.Data.Repositories;

public class CreditLimitRepository : ICreditLimitRepository
{
    private readonly ApplicationDbContext _context;

    public CreditLimitRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public decimal GetCreditLimit(decimal salary)
    {
        var result = _context.CreditLimit
             .FromSqlRaw("EXEC CalculateCreditLimit @Salary", new SqlParameter("@Salary", salary))
             .AsEnumerable()
             .FirstOrDefault();

        if (result != null)
        {
            return result.CreditLimit;
        }
        else
        {
            throw new Exception("No credit limit result found.");
        }
    }
}