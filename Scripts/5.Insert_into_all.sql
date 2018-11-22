USE [Order_V2]
go

insert into Users.Cities
	(
		City_ZIP,
		CityName,
		CountryName
	)
	values
	(
		5540,
		'Lier',
		'Belgie'
	),
	(
		3340,
		'Hasselt',
		'Belgie'
	),
	(
		3000,
		'Leuven',
		'Belgie'
	)	


insert into Users.Customers 
	(		
		FirstName,
		LastName,
		Login_Email,
		Login_HashPass,
		StreetName,
		StreetNumber,
		City_ZIP,
		RegistrationDate,
		DateEdited
	)
	values
	(
		'Filip',
		'Derese', 
		'costumer@order.com',
		'e4MzbfoVWToQPl8hhJfV0wa47j82H5C8mBOr4QTxdpk=',
		'Nieuwstraat', 
		'15C',
		5540,
		CONVERT(date,'1-11-2018', 103),
		CONVERT(date,'1-11-2018', 103)
		
	),
	(
		'Gwen',
		'Verbruggen', 
		'Costumer1@order.com',
		'2ivcKvaD/5fFm9skyQYAAlBNhTqLBR4BLFFokixUNV0=',
		'Oudenbolweg', 
		'142',
		3000,
		CONVERT(date,'2-11-2018', 103),		
		CONVERT(date,'2-11-2018', 103)
	)

insert into Users.Workplaces 
	(				
		OfficeName,
		City_ZIP,
		Streetname,
		StreetNumber
	)
	values		
	(
		'SpaceTime',
		3000,
		'Drinkwaterstraat',
		'125C'
	)

insert into Users.Administrators 
	(				
		Name, 
		Login_Email ,
		Login_HashPass, 
		Workplace_ID, 
		PhoneNumber,
		RegistrationDate ,
		DateEdited
	)
	values		
	(
		'Gwen',
		'admin@order.com',
		'hYtKav97hWW5Ex8y0tvSCFmiGAsBMYF3KENyKdDZ5bc=',
		(select Workplace_ID from Users.Workplaces), 
		'00321563256',		
		CONVERT(date,'1-11-2018', 103),
		CONVERT(date,'1-11-2018', 103)
	)

insert into Users.PhoneNumbers
	(
		Customer_ID,
		PhoneNumber
	)
	values
	(
		(select Customer_ID
		from Users.Customers
		where LastName like 'Verbruggen' ),
		 '018532624'
	),
	(
		(select Customer_ID
		from Users.Customers
		where LastName like 'Derese' ),
		 '018333333'
	),
	(
		(select Customer_ID
		from Users.Customers
		where LastName like 'Derese' ),
		 '015326598'
	)


insert into Sales.Items
	(
		Name,
		Description,
		Price,
		AmountInStock,
		DateAdded,
		DateEdited
	)
	values
	(
		'FunThing',
		'Just some Funny Object',
		12.30,
		56,
		CONVERT(date,'5-11-2018', 103),
		CONVERT(date,'5-11-2018', 103)
	),
	(
		'LameThing',
		'Just some lame stupid Object',
		222.30,
		6,
		CONVERT(date,'5-11-2018', 103),
		CONVERT(date,'5-11-2018', 103)
	),	
	(
		'BLaBLa',
		'BlaBlaBlaBlaBlaBlaBlaBlaBlaBlaBlaBlaBlaBlaBla',
		0.01,
		102425,
		CONVERT(date,'4-11-2018', 103),
		CONVERT(date,'4-11-2018', 103)
	)

insert into OrderLine.PlacedOrders
	(
      Customer_ID,
		DateOrdered,
		DateShipped
	)
	values
	(
		(select Customer_ID
		from Users.Customers
		where LastName like 'Verbruggen' ),
		CONVERT(date,'6-11-2018', 103),
		CONVERT(date,'6-11-2018', 103)		 
	)

insert into OrderLine.ItemGroups
	(
		PlacedOrder_ID,
		Item_ID,
		PricePerItem,
		Item_Amount,
		EstimatedShippingDate,
		Description
	)	
	values
	(
		(
		select PlacedOrder_ID 
		from OrdeRLine.PlacedOrders
		),
		(select Item_ID from Sales.Items where Name like 'FunThing'),
		(select Price from Sales.Items where Name like 'FunThing'),
		5,
		CONVERT(date,'11-11-2018', 103),	 
		'phu'
	)

	