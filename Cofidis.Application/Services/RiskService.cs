using Cofidis.Application.Interfaces;
using Cofidis.Domain.Entities;

namespace Cofidis.Application.Services;

public class RiskService : IRiskService
{
    public DataByNIF GetDataByNIF(string nif)
    {
        double creditHistory = GetDataFromAPI();
        double debtRatio = GetDataFromAPI();
        double inflation = GetDataFromAPI();
        double unemployment = GetDataFromAPI();
        decimal salary = GetSalaryFromAPI();

        var index = RiskAnalysis.CalculateRiskIndex(unemployment, inflation, creditHistory, debtRatio);
        var isCreditWortht = RiskAnalysis.IsCreditworthy(index);

        return new DataByNIF(nif)
        {
            Salary = salary,
            IsCreditworthy = isCreditWortht
        };
    }

    private static double GetDataFromAPI()
    {
        Random random = new Random();
        return random.NextDouble();
    }

    private static decimal GetSalaryFromAPI()
    {
        Random random = new Random();

        double randomNumber = random.NextDouble();

        decimal salary = (decimal)(randomNumber * (3000 - 1000)) + 1000;

        return salary;
    }
}