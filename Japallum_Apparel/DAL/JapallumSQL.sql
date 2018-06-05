-- Execute this line first then switch to JapallumDB to do the rest of the data

USE master

GO

IF NOT EXISTS (

	SELECT name

	FROM sys.databases

	WHERE name = N'JapallumDB'

	)

CREATE DATABASE JapallumDB

GO



--Address Table

CREATE TABLE tblAddress(

	addressID int IDENTITY(500,1) PRIMARY KEY,

	streetNum varchar(10),

	streetName varchar(255),

	suburb varchar(255),

	addressState varchar(30),

	postCode smallint,

CHECK (postCode>=999 AND postCode<=9999)

)

--Postage Table

CREATE TABLE tblPostage(

	postageID int IDENTITY(1500,1) PRIMARY KEY,

	postageDesc varchar(30),

	postageCost Money,

	postageactive bit DEFAULT 1

)

--Customer Table

CREATE TABLE tblCustomer(

	customerID int IDENTITY(1000,1) PRIMARY KEY,

	fName varchar(60),

	lName varchar(60),

	rAddress int,

	bAddress int,

	customerEmail varchar(100)UNIQUE,

	customerPassword varchar(60),

	customerActive bit DEFAULT 1,

	FOREIGN KEY(rAddress) REFERENCES tbladdress(addressID) ON UPDATE NO ACTION ON DELETE NO ACTION,

	FOREIGN KEY(bAddress) REFERENCES tbladdress(addressID) ON UPDATE NO ACTION ON DELETE NO ACTION

)

--Admin information table

CREATE TABLE tblAdmin(

	adminID int IDENTITY(600,1) PRIMARY KEY,

	fName varchar(60),

	lName varchar(60),

	adminEmail varchar(60)UNIQUE,

	adminPassword varchar(60),
	
	adminActive bit DEFAULT 1

)

-- Product table

CREATE TABLE tblProduct(

	productID int IDENTITY(1500,1) PRIMARY KEY,

	prodSize char(3),

	prodPrice Money,

	shortDesc varchar(100)UNIQUE,

	longDesc varchar(500),

	prodGender char(3),

	imageFile varchar(300),

	prodStock int,

	lastEdited int,

	active bit DEFAULT 1,

	FOREIGN KEY (lastEdited) REFERENCES tblAdmin(adminID) ON UPDATE CASCADE ON DELETE NO ACTION,

	CHECK (prodGender= 'Y' OR prodGender='M' OR prodGender='F')

)

--Order table

CREATE TABLE tblOrder(

	orderID int IDENTITY(2378,1) PRIMARY KEY,

	orderDate DateTime,

	subTotal Money,

	customerID int,

	customerAddress int,

	postage int,

	tax float,

	orderTotal Money,

	FOREIGN KEY (customerID) REFERENCES tblCustomer(customerID)ON UPDATE NO ACTION ON DELETE NO ACTION,

	FOREIGN KEY (Postage) REFERENCES tblPostage(postageID) ON UPDATE CASCADE ON DELETE NO ACTION

)

--Junction table so that the many to many relationship between Order and Product will work, uses a contraint primary key that uses the two foreign keys to function, this may change later but for now it works.

CREATE TABLE junctionProd_Order(

	orderID int,

	productID int,

	prodPrice Money,

	Quantity smallint,

	FOREIGN KEY(orderID) REFERENCES tblOrder(orderID),

	FOREIGN KEY(productID) REFERENCES tblProduct(productID),

	CONSTRAINT PK_PRod_Order PRIMARY KEY(

		orderID,

		productID

	)

)

--Test Data for the final server



--Address Data

INSERT INTO tblAddress VALUES(10,'Long st','Chiswick', 'New South Wales',2375);

INSERT INTO tblAddress VALUES(39,'Azure Lane','Otamatane', 'Victoria',3640);



--Postage Data

INSERT INTO tblPostage VALUES('Express Postage',15.00,1);

INSERT INTO tblPostage VALUES('Air Mail',25.00,1);



--Customer Data

INSERT INTO tblCustomer VALUES('Laura', 'Kinsman',501,501,'Lkins@gmail.com','Butterflies',1);

INSERT INTO tblCustomer VALUES('James', 'Duveaux',500,501,'IfightDragons@gmail.com','Avalon',1);



--Admin Data

INSERT INTO tblAdmin VALUES('Jeremy','Clarkson','TopGear@Japallum.com','howdousehammer',1);

INSERT INTO tblAdmin VALUES('Callum','Haddock','Calhad@Japallum.com','TinTinReference',1);



--Product Data



--Mens products

INSERT INTO tblProduct VALUES( 'Lrg', 25.00, 'Sweater', 'A Sweater for students','M', '~/Images/Sweater.png',134,600,1);

INSERT INTO tblProduct VALUES( 'Lrg', 10.00, 'Plain Shirt', 'A nice plain shirt that will always be in season','M', '~/Images/Mens_shirt.png', 50,601,1);

INSERT INTO tblProduct VALUES( '36', 20.00, 'Generic Pants', 'They have pockets','M', '~/Images/Mens_pants.png', 74,600,1);

INSERT INTO tblProduct VALUES( '11', 50.00, 'Generic Shoes',  'You will be running everywhere in these', 'M', '~/Images/Mens_footwear.png',20,601,1);



--Womens Products

INSERT INTO tblProduct VALUES('Sml', 10.00,'Pretty Shirt', 'It is very pretty','F', '~/Images/Womens_shirt.png',74, 601,1);

INSERT INTO tblProduct VALUES('Sml', 20.00,'Pretty Pants', 'It is just dying to be the newest additon to your collection','F', '~/Images/Womens_pants.png',44, 600,1);

INSERT INTO tblProduct VALUES('6', 50.00,'High Heel Shoes', 'For you to tower over your enemies','F', '~/Images/Womens_footwear.png',15, 601,1);



-- Childrens Products

INSERT INTO tblProduct VALUES('Lrg', 5.00,'Playful Shirt', 'Go have some fun in the sun','Y', '~/Images/Youth_Shirt.png',34, 600,1);

INSERT INTO tblProduct VALUES('36', 10.00,'Happy Pants', 'These pants will be able to resist even the roughest of playing','Y', '~/Images/Youth_pants.png',120, 600,1);

INSERT INTO tblProduct VALUES('11', 25.00,'Kids Shoes', 'Look Cool and have shoes tp help you do so','Y', '~/Images/Youth_footwear.png',10, 601,1);



--Order Data

INSERT INTO tblOrder VALUES( GETDATE(), 75.00, 1001, 501, 1500, 0.14, 85.05);

INSERT INTO tblOrder VALUES( GETDATE(), 45.00, 1000, 501, 1501, 0.14, 51.30);



--Junction Box between the two data

INSERT INTO junctionProd_Order VALUES(2378, 1500,25.00,3);

INSERT INTO junctionProd_Order VALUES(2379, 1500,25.00,1);

INSERT INTO junctionProd_Order VALUES(2379, 1501,20.00,1);





CREATE LOGIN Calhad

	WITH PASSWORD = 'TinTinReferences'

GO