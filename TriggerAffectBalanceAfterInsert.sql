USE [DigitalCurrency]
GO

CREATE TRIGGER trg_UpdateWalletBalance
ON [dbo].[Transactions]
AFTER INSERT
AS
BEGIN
    -- Update Wallet balance for each new transaction
    -- Use the INSERTED table to access new rows in Transactions

    -- Update for deposits
    UPDATE w
    SET w.Balance = w.Balance + i.Amount
    FROM [dbo].[Wallets] w
    INNER JOIN INSERTED i ON w.Id = i.WalletId
    WHERE i.TransactionType = 'Deposit';

    -- Update for withdrawals
    UPDATE w
    SET w.Balance = w.Balance - i.Amount
    FROM [dbo].[Wallets] w
    INNER JOIN INSERTED i ON w.Id = i.WalletId
    WHERE i.TransactionType = 'Withdraw';

    -- Optionally, you can add error handling or logging here
END
GO
SELECT * FROM [dbo].[Wallets];

-- Insert a deposit transaction
INSERT INTO [dbo].[Transactions] (WalletId, TransactionDate, Amount, TransactionType)
VALUES (1, GETDATE(), 100.00, 'Deposit');

-- Insert a withdrawal transaction
INSERT INTO [dbo].[Transactions] (WalletId, TransactionDate, Amount, TransactionType)
VALUES (1, GETDATE(), 50.00, 'Withdraw');

-- Verify the updates
SELECT * FROM [dbo].[Wallets];
select *