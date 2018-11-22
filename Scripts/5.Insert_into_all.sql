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

insert into Users.Users 
	(		
		Discriminator,
		RegistrationDate ,
		DateEdited,
		FirstName,
		LastName,
		Login_Email,
		Login_HashPass,
		Login_Salt,
		Admin_Workplace_ID,
		Customer_City_ZIP,
		Customer_StreetName,
		Customer_StreetNumber
	)
	values
	(
		'Administrator',
		CONVERT(date,'1-11-2018', 103),
		CONVERT(date,'1-11-2018', 103),
		'Albert',
		'Fransen', 
		'admin@order.com',
		'InbBsK3LhfjJi9nmZG2jd1IYaNKuvwLMxIjPeOg3yUg=',
		'3gXWznyrL1HCdobzyrdzSQ==',
		(select Workplace_ID from Users.Workplaces where OfficeName like 'SpaceTime'),
		null,
		null,
		null	
	),
	(
		'Customer',
		CONVERT(date,'2-11-2018', 103),
		CONVERT(date,'2-11-2018', 103),
		'Filip',
		'Derese', 
		'costumer@order.com',
		'Gf8AKTqvuNnIZm1gJum55+VhJbinrCajSULPmIaLvVU=',
		'EiSVNZrgq25D9CuVLq8Qvw==',
		null,
		3340,
		'NieuwStraat',
		'15B'		
	),
	(
		'Customer',
		CONVERT(date,'1-11-2018', 103),
		CONVERT(date,'1-11-2018', 103),
		'Steffi',
		'Struyfs', 
		'jfs84CROd9SFpP9qhJQcBg==',
		'pRX+/tiuJAsj4WYj4kj6V2ZuJDZ8u2BmFbfAtGeX/yA=',
		'jfs84CROd9SFpP9qhJQcBg==',
		null,
		3340,			
		'OudeBolWeg',
		'356'
	)
	/*
insert into Users.Administrators 
	(				
		User_ID,
		Workplace_ID
	)
	values		
	(
		(select User_ID from Users.Users where LastName like 'Fransen'),
		(select Workplace_ID from Users.Workplaces where OfficeName like 'SpaceTime')
	)

insert into Users.Customers
	(
		User_ID,
		City_ZIP,
		StreetName,
		StreetNumber
	)
	values
	(
		(select User_ID from Users.Users where LastName like 'Derese'),
		3340,
		'NieuwStraat',
		'15B'
	),
	(
		(select User_ID from Users.Users where LastName like 'Struyfs'),
		3340,			
		'OudeBolWeg',
		'356'
	)*/
		
insert into Users.PhoneNumbers
	(
		User_ID,
		PhoneNumber
	)
	values
	(
		(select User_ID from Users.Users where LastName like 'Fransen'),
		 '018333333'
	),
	(
		(select User_ID from Users.Users where LastName like 'Fransen'),
		 '04649658523'
	),
	(
		(select User_ID from Users.Users where LastName like 'Fransen'),
		 '012356563'
	),
	(
		(select User_ID from Users.Users where LastName like 'Struyfs'),
		 '018532624'
	),
	(
		(select User_ID from Users.Users where LastName like 'Derese'),
		 '015326598'
	)
	
	