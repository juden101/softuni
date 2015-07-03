USE Bank
GO

CREATE FUNCTION usf_CalculateInterest(@sum money, @rate money, @numberOfMonths money) 
RETURNS money
AS
BEGIN
	DECLARE @result money;
	DECLARE @r money SET @r = @rate / 100;
	DECLARE @t money SET @t = @numberOfMonths / 12;

	SET @result = @sum * (1 + (@r * @t));
	RETURN @result;
END
GO

DECLARE @interestCalc MONEY;
EXEC @interestCalc = usf_CalculateInterest @sum=100, @rate = 4, @numberOfMonths=6
SELECT @interestCalc AS [Interest]
GO