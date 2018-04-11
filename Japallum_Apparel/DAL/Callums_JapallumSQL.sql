



--Address Table
CREATE TABLE tbladdress(
	addressID int IDENTITY(500,1) PRIMARY KEY,
	streetNum varchar(10),
	streetName varchar(255),
	suburb varchar(255),
	addressState varchar(30),
	postCode smallint,
CHECK (postCode>=999 AND postCode<=9999)
)
--Customer Table
CREATE TABLE tblCustomer(
	customerID int IDENTITY(1000,1) PRIMARY KEY,
	fName varchar(60),
	lName varchar(60),
	rAddress int,
	bAddress int,
	customerEmail varchar(100),
	customerPhoneNum int,
	customerActive bit DEFAULT "True",
	FOREIGN KEY(rAddress) REFERENCES tbladdress(addressID),
	FOREIGN KEY(bAddress) REFERENCES tbladdress(addressID)
)
--Admin information table
CREATE TABLE tblAdmin(
	adminID int IDENTITY(600,1) PRIMARY KEY,
	fName varchar(60),
	lName varchar(60),
	adminEmail varchar(60)
)
--Customer login Table
CREATE TABLE tblCustomer_Login(
	customerPassword varchar(60),
	customerEmail varchar(100),
	customerID int,
	FOREIGN KEY(customerID) REFERENCES tblCustomer(customerID),
)
-- Admin Login Table
CREATE TABLE tblAdmin_Login(
	admninPassword varchar(60),
	adminEmail varchar(100),
	adminID int,
	FOREIGN KEY (adminID) REFERENCES tblAdmin(adminID)
)
-- Product table
CREATE TABLE tblProduct(
	productID int IDENTITY(1500,1) PRIMARY KEY,
	prodSize char(3),
	prodPrice Money,
	shortDesc varchar(255),
	longDesc varchar(3000),
	prodGender char(3),
	imageFile varchar(300),
	prodStock int,
	lastEdited int,
	active bit DEFAULT 1,
	FOREIGN KEY (lastEdited) REFERENCES tblAdmin(adminID)
)
--Order table
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
