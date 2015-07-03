USE Bank
GO

CREATE PROC usp_WithdrawMoney(@accounId INT, @moneyWithdrawAmmount MONEY)
AS
	DECLARE @accountAvailabilityBefore MONEY
	SET @accountAvailabilityBefore = 
	(SELECT a.Balance FROM Accounts a WHERE a.PersonId = @accounId)

	DECLARE @accountAvailabilityAfter MONEY
	SET @accountAvailabilityAfter = @accountAvailabilityBefore - @moneyWithdrawAmmount
	
	BEGIN TRAN 
		IF NOT (EXISTS (SELECT * FROM Accounts WHERE PersonId = @accounId))
		BEGIN
			PRINT 'No such account ! Please try another account.'
			ROLLBACK TRAN
		END
		ELSE IF (@accountAvailabilityAfter < 0)
			BEGIN
				PRINT 'No enought money in the account !' +
				' Current Availability - ' + convert(varchar(50), @accountAvailabilityBefore, 1) +
				' You tryed to withdraw - ' + convert(varchar(50), @moneyWithdrawAmmount, 1);
				ROLLBACK TRAN 			
			END
		ELSE IF (@moneyWithdrawAmmount < 1)
			BEGIN
				PRINT 'Amount '+ convert(varchar(50), @moneyWithdrawAmmount, 1) +' Try another amount !';
				ROLLBACK TRAN 				
			END
		ELSE
			BEGIN
				UPDATE [Accounts]
				SET [Balance] = @accountAvailabilityBefore - @moneyWithdrawAmmount
				WHERE PersonId = @accounId;
				COMMIT TRAN 
			END
GO

-- asure the account have enought cash to experiment with
UPDATE Accounts
SET Balance = 23413423
WHERE PersonId = 1
GO

-- withdraw available sum
SELECT a.Balance FROM Accounts a WHERE a.PersonId = 1;
EXEC usp_WithdrawMoney @accounId = 1, @moneyWithdrawAmmount = 13413423;
SELECT a.Balance FROM Accounts a WHERE a.PersonId = 1;
GO

-- withdraw unavailable sum
SELECT a.Balance FROM Accounts a WHERE a.PersonId = 1;
EXEC usp_WithdrawMoney @accounId = 1, @moneyWithdrawAmmount = 33413423;
SELECT a.Balance FROM Accounts a WHERE a.PersonId = 1;
GO

CREATE PROC usp_DepositMoney
(@accountId INT, @moneyToDeposit MONEY)
AS
	DECLARE @accountAvailabilityBefore MONEY
	SET @accountAvailabilityBefore = 
	(SELECT a.Balance FROM Accounts a WHERE a.PersonId = @accountId)
	BEGIN TRAN
	IF NOT (EXISTS (SELECT * FROM Accounts WHERE PersonId = @accountId))
		BEGIN
			PRINT 'No such account ! Please try another account.'
			ROLLBACK TRAN
		END
	ELSE IF (@moneyToDeposit <= 0)
		BEGIN
			PRINT 'Non supported amount for deposit. Please select oter amount.'
			ROLLBACK TRAN
		END
	ELSE
		BEGIN
			UPDATE [Accounts]
			SET [Balance] = @accountAvailabilityBefore + @moneyToDeposit
			WHERE PersonId = @accountId;
			COMMIT TRAN
		END 
GO

-- deposit available sum
SELECT a.Balance FROM Accounts a WHERE a.PersonId = 1;
EXEC usp_DepositMoney @accountId = 1, @moneyToDeposit = 10000000;
SELECT a.Balance FROM Accounts a WHERE a.PersonId = 1;
GO

-- deposit unavailable sum
SELECT a.Balance FROM Accounts a WHERE a.PersonId = 1;
EXEC usp_DepositMoney @accountId = 1, @moneyToDeposit = -30;
SELECT a.Balance FROM Accounts a WHERE a.PersonId = 1;
GO