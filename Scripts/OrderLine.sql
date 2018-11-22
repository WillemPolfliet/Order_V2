use [Order_V2]
go

create schema OrderLine
go

create table OrderLine.PlacedOrders
(
	PlacedOrder_ID uniqueidentifier not null default newid(),
	Customer_ID uniqueidentifier not null,
	DateOrdered Datetime not null,
	DateShipped Datetime null,
	constraint Item_PK primary key (PlacedOrder_ID)
)
create table OrderLine.ItemGroups
(
	/*ItemGroup_ID uniqueidentifier not null default newid(),*/
	PlacedOrder_ID uniqueidentifier not null,
	Item_ID uniqueidentifier not null,
	PricePerItem decimal(6,2) not null,
	Item_Amount int not null,	
	EstimatedShippingDate Datetime not null,
	Description nvarchar(100) null
)

alter table OrderLine.PlacedOrders
	add constraint PlacedOrders_Customers_FK
	foreign key (Customer_ID) references Users.Customers(Customer_ID)

alter table OrderLine.ItemGroups
	add constraint ItemGroups_PlacedOrders_FK
	foreign key (PlacedOrder_ID) references OrderLine.PlacedOrders(PlacedOrder_ID)

alter table OrderLine.ItemGroups
	add constraint ItemGroups_Items_FK
	foreign key (Item_ID) references Sales.Items(Item_ID)
