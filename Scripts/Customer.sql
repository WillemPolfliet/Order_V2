use [Order_V2]
go

create schema Users
go

create table Users.Customers
(
	Customer_ID uniqueidentifier not null default newid(),
	FirstName nvarchar(100) not null,
	StreetName nvarchar(100) not null,
	StreetNumber nvarchar(10) not null,
	City_ZIP int not null,
	RegistrationDate Date not null,
	DateEdited Date not null,
	LastName nvarchar(100) not null,
	Login_Email nvarchar(100) not null,
	Login_HashPass nvarchar(100)  null

	constraint Customer_PK primary key (Customer_ID)
)

create table Users.Administrators
(
	Administrators_ID uniqueidentifier not null default newid(),
	Workplace_ID  uniqueidentifier not null,
	PhoneNumber nvarchar(30) not null,
	RegistrationDate Datetime not null,
	DateEdited Datetime not null,
	Name nvarchar(100) not null,
	Login_Email nvarchar(100) not null,
	Login_HashPass nvarchar(100) null
	constraint Administrators_PK primary key (Administrators_ID)
)

create table Users.Cities
(
	City_ZIP int not null,
	CityName nvarchar(100) not null,
	CountryName nvarchar(100) not null
	constraint Cities_pk primary key(City_ZIP)
)

create table Users.Workplaces
(
	Workplace_ID uniqueidentifier not null default newid(),
	OfficeName nvarchar(100) not null,
	City_ZIP int not null,
	StreetName nvarchar(100) not null,
	StreetNumber nvarchar(10) not null,
	constraint Workplaces_pk primary key(Workplace_ID)
)

create table Users.PhoneNumbers
(
	Customer_ID uniqueidentifier not null,
	PhoneNumber varchar(100) not null
)

alter table Users.Customers	
	add constraint Customers_Cities_FK
	foreign key (City_ZIP) references Users.Cities(City_ZIP)

alter table Users.Administrators	
	add constraint Administrators_Workplaces_FK
	foreign key (Workplace_ID) references Users.Workplaces(Workplace_ID)
alter table Users.Workplaces	
	add constraint Workplaces_Cities_FK
	foreign key (City_ZIP) references Users.Cities(City_ZIP)

alter table Users.PhoneNumbers
	add constraint PhoneNumbers_Customers_FK
	foreign key (Customer_ID) references Users.Customers(Customer_ID)

