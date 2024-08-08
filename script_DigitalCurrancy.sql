USE [master]
GO 

CREATE DATABASE DigitalCurrency
Go

USE DigitalCurrency
Go

CREATE TABLE [dbo].[Wallets](
	Id int IDENTITY(1, 1) primary key,
	Holder varchar(50) NOT NULL,
	Balance decimal(18, 0) NOT NULL
);
GO

INSERT Wallets ( Holder, Balance) VALUES 
         ( 'Ahmad', 10000 ),
		 ( 'Reem', 5000 ); 
Go

CREATE PROCEDURE AddWallet
@Holder varchar(50), 
@Balance decimal(18,0)
AS
BEGIN
  INSERT INTO WALLETS ( Holder, Balance) VALUES (@Holder, @Balance)
END
GO

CREATE PROCEDURE [dbo].[GetAllWallets]
AS
BEGIN
    SELECT * FROM Wallets
END
GO
CREATE TABLE [dbo].[Transactions](
    Id INT IDENTITY(1, 1) PRIMARY KEY,
    WalletId INT NOT NULL,
    TransactionDate DATETIME NOT NULL DEFAULT GETDATE(),
    Amount DECIMAL(18, 2) NOT NULL,
    TransactionType VARCHAR(50) NOT NULL, 
    FOREIGN KEY (WalletId) REFERENCES [dbo].[Wallets](Id)
);
GO
INSERT INTO [dbo].[Transactions] (WalletId, Amount, TransactionType) VALUES 
    (1, 500, 'Deposit'), 
    (1, -200, 'Withdrawal'), 
    (2, 1000, 'Deposit');
go



