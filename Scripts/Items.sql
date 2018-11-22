use [Order_V2]
go

create schema Sales
go

create table Sales.Items
(
	Item_ID uniqueidentifier not null default newid(),
	Name nvarchar(100) not null,
	Description nvarchar(100) not null,
	Price Decimal(6,2) not null,
	AmountInStock int not null,
	DateAdded date not null,
	DateEdited date not null
	constraint Item_PK primary key (Item_ID)
)

