USE Bank
GO

CREATE TRIGGER tr_AccountLogs
ON [Accounts]
FOR UPDATE, INSERT
AS
BEGIN
	DECLARE @accountID INT;
	SET @accountID = (SELECT i.PersonId FROM INSERTED i);

	DECLARE @newBalance MONEY;
	SET @newBalance = (SELECT i.Balance FROM INSERTED i)

    IF EXISTS(SELECT * FROM DELETED)
    BEGIN
		DECLARE @oldBalance MONEY;
		SET @oldBalance = (SELECT d.Balance FROM DELETED d);
    END

	INSERT INTO dbo.Logs
	(
	    dbo.Logs.AccountId,
	    dbo.Logs.OldSum,
	    dbo.Logs.NewSum
	)
	VALUES
	(
	    @accountId,
	    @oldBalance,
	    @newBalance
	)
END
GO

-- withdraw money
SELECT * FROM Logs l
EXEC usp_WithdrawMoney @accounId = 1, @moneyWithdrawAmmount = 13413423;
SELECT * FROM Logs l
GO

-- deposit money
SELECT * FROM Logs l
EXEC usp_DepositMoney @accountId = 1, @moneyToDeposit = 10000000;
SELECT * FROM Logs l
GO