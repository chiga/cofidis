namespace Cofidis.Domain.Interfaces;

public interface ICreditLimitRepository
{
    decimal GetCreditLimit(decimal salary);
}