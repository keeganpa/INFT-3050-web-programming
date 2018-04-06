




CREATE TABLE tbladdress(
	addressID int IDENTITY(500,1) PRIMARY KEY,
	streetNum varchar(10),
	streetName varchar(255),
	suburb varchar(255),
	addressState varchar(30),
	postCode smallint,
CHECK (postCode>=999 AND postCode<=9999)
)

CREATE TABLE tblCustomer(
	customerID int IDENTITY(1000,1) PRIMARY KEY,
	fName varchar(60),
	lName varchar(60),
	rAddress int,
	bAddress int,
	customerEmail varchar(100),
	customerPhoneNum int,
	FOREIGN KEY(rAddress) REFERENCES tbladdress(addressID),
	FOREIGN KEY(bAddress) REFERENCES tbladdress(addressID)
)

CREATE TABLE tblAdmin(
	adminID int IDENTITY(600,1) PRIMARY KEY,
	fName varchar(60),
	lName varchar(60),
	email varchar(60)
)

CREATE TABLE tblCustomer_Login(
	customerLoginID int IDENTITY(200,1) PRIMARY KEY,
	customerPassword varchar(60),
	customerEmail varchar(100),
	customerID int,
	FOREIGN KEY(customerID) REFERENCES tblCustomer(customerID),
)

CREATE TABLE tblAdmin_Login(
	adminLoginID int IDENTITY(300,1) PRIMARY KEY,
	admninPassword varchar(60),
	adminEmail varchar(100),
	adminID int,
	FOREIGN KEY (adminID) REFERENCES tblAdmin(adminID)
)

CREATE TABLE tblProduct(
	productID int IDENTITY(1500,1) PRIMARY KEY,
	prodSize char(3),
	prodPrice Money,
	shortDesc varchar(255),
	longDesc varchar(3000),
	prodGender char(3),
	imageFile varchar(300),
	prodStock int,
	active bit
)

CREATE TABLE tblOrder(
	orderID int IDENTITY(2378,1) PRIMARY KEY,
	orderDate DateTime,
	subTotal Money,
	customerID int,
	customerAddress int,
	shipMethod varchar(40),
	tax float,
	orderTotal Money,
	cardType varchar(40),
	cardNo varchar(16),
	expirationMonth int,
	expirationYear int,
	FOREIGN KEY (customerID) REFERENCES tblCustomer(customerID)
)

CREATE TABLE junctionProd_Order(
	orderID int,
	productID int,
	prodPrice Money,
	Quantity smallint,
	FOREIGN KEY(orderID) REFERENCES tblOrder(orderID),
	FOREIGN KEY(productID) REFERENCES tblProduct(productID)
)