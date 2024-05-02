namespace Cofidis.Application.Services;

public static class RiskAnalysis
{
    public static double CalculateRiskIndex(double unemployment, double inflation, double creditHistory, double debtRatio)
    {
        const double unemploymentWeight = 0.3;
        const double inflationWeight = 0.2;
        const double creditHistoryWeight = 0.3;
        const double debtRatioWeight = 0.2;

        double riskIndex = (unemployment * unemploymentWeight) +
                           (inflation * inflationWeight) +
                           (creditHistory * creditHistoryWeight) +
                           (debtRatio * debtRatioWeight);

        return riskIndex;
    }

    public static bool IsCreditworthy(double riskIndex)
    {
        const double creditRiskThreshold = 0.6;

        return riskIndex < creditRiskThreshold;
    }
}