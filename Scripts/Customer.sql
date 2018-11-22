use [Order_V2]
go

create schema Users
go

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
	User_ID uniqueidentifier not null,
	PhoneNumber varchar(100) not null
)


create table Users.Users
(
	User_ID uniqueidentifier not null default newid(),
	Discriminator varchar(100) not null,
	RegistrationDate Date not null,
	DateEdited Date not null,
	FirstName nvarchar(100) not null,
	LastName nvarchar(100) not null,
	Login_Email nvarchar(100) not null,
	Login_HashPass nvarchar(100)  not null,
	Login_Salt nvarchar(100)  not null,

	Customer_StreetName nvarchar(100) null,
	Customer_StreetNumber nvarchar(10) null,
	Customer_City_ZIP int null	,

	Admin_Workplace_ID  uniqueidentifier null

	constraint User_PK primary key (User_ID)
)

/*
create table Users.Customers
(	
	User_ID uniqueidentifier not null,
	StreetName nvarchar(100) not null,
	StreetNumber nvarchar(10) not null,
	City_ZIP int not null	
)

create table Users.Administrators
(
	User_ID uniqueidentifier not null,
	Workplace_ID  uniqueidentifier not null
)





alter table Users.Administrators	
	add constraint Administrators_Users_FK
	foreign key (User_ID) references Users.Users(User_ID)

alter table Users.Customers	
	add constraint Customers_Users_FK
	foreign key (User_ID) references Users.Users(User_ID)
	*/
alter table Users.Users	
	add constraint Customers_Cities_FK
	foreign key (Customer_City_ZIP) references Users.Cities(City_ZIP)

alter table Users.Users	
	add constraint Administrators_Workplaces_FK
	foreign key (Admin_Workplace_ID) references Users.Workplaces(Workplace_ID)

alter table Users.Workplaces	
	add constraint Workplaces_Cities_FK
	foreign key (City_ZIP) references Users.Cities(City_ZIP)

alter table Users.PhoneNumbers
	add constraint PhoneNumbers_Users_FK
	foreign key (User_ID) references Users.Users(User_ID)

