CREATE PROCEDURE CalculateCreditLimit
    @MonthlyIncome DECIMAL
AS
BEGIN
    IF @MonthlyIncome <= 1000
        SELECT 1000 AS CreditLimit;
    ELSE IF @MonthlyIncome > 1000 AND @MonthlyIncome <= 2000
        SELECT 2000 AS CreditLimit;
    ELSE
        SELECT 5000 AS CreditLimit;
END
