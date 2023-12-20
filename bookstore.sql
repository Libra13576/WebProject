use [master]
go

create database FPTBook
go

use FPTBook
go

create table tblCategory
(
   catID int identity(1, 1) primary key,
   catName nvarchar(50) not null unique,
   catDetails nvarchar(300) null
)
go

create table tblStoreOwner
(
	ownerID varchar(5) not null primary key,
	ownerName nvarchar(30) not null,
	ownerAddress nvarchar(50) not null,
	ownerPhone varchar(12) null,
	ownerTaxCode varchar(12) null,
	ownerDetails nvarchar(300) null,
	ownerphoto nvarchar(50),
	ownerPassword nvarchar(300) null
)
go

create table tblPublisher
(
	publisherID int identity(1, 1) not null primary key,
	publisherName nvarchar(30) not null unique,
	publisherAddress nvarchar(50) null,
	publisherDetails nvarchar(300) null,
	publogo varchar(50)
)
go

create table tblAuthor
(
	authorID varchar(5) not null primary key,
	authorName nvarchar(30) not null,
	authorAdress nvarchar(50) null,
	authorEmail varchar(30) null
)
go

create table tblBook
(
	bookID varchar(10) not null primary key,
	bookTitle nvarchar(60) not null,
	bookPrice int not null default(10),
	bookDetailes nvarchar(500) null,
	bookImage1 varchar(30) null,
	bookImage2 varchar(30) null,
	bookImage3 varchar(30) null,
	catID int not null,
	ownerID varchar(5) not null,
	publisherID int not null,
	constraint fk_catID foreign key(catID) references tblCategory(catID),
	constraint fk_ownerID foreign key(ownerID) references tblStoreOwner(ownerID),
	constraint fk_publisherID foreign key(publisherID) references tblPublisher(publisherID)
)
go

create table tblBookAuthor
(
	bookID varchar(10) not null,
	authorID varchar(5) not null,
	details nvarchar(300) null,
	constraint pk_bookauthor primary key (bookID, authorID),
	constraint fk_bookID foreign key (bookID) references tblBook(bookID),
	constraint fk_authorID foreign key (authorID) references tblAuthor(authorID)
)
go

create table tblCustomer
(
	customerID varchar(10) not null primary key,
	customerEmail varchar(30) not null,
	customerPassword varchar(300) not null,
	customerFullname nvarchar(30) not null,
	customerAddress nvarchar(30) null,
	customerPhone varchar(12) null,
	customerphoto varchar(50) null
)
go

create table tblCart(
	bookID varchar(10) not null,
	customerID varchar(10) not null,
	quantity int not null,
	price int not null,
	orderID varchar(10) not null,
	constraint pk_customercart primary key (orderID, customerID),
	constraint fk_customer_cart foreign key (customerID) references tblCustomer(customerID),
	constraint fk_cart_order foreign key (orderID) references tblOrder(orderID),
	constraint fk_book foreign key (bookID) references tblBook(bookID),
)
go

create table tblOrder(
	orderID varchar(10) not null primary key,
	bookID varchar(10) not null,
	customerID varchar(10) not null,
	cartID varchar(10) not null,
	price int not null,
	constraint fk_customer_order foreign key (customerID) references tblCustomer(customerID),
)
go 

create table tbladmin(
	adminID varchar(10) not null primary key,
	ownerID varchar(5) not null,
	adminname varchar(30) not null,
	adminpassword varchar(30) not null,
	customerEmail varchar(20) null,
	catID int identity(1, 1),
	adminphoto varchar(50)
)
go

IF EXISTS (SELECT name FROM sys.databases WHERE name = N'FPTBook')
	BEGIN
		-- Database exists. Drop it
		Drop database FPTBook
	END
ELSE
	BEGIN
		-- Database does not exist. Create it
		create database FPTBook
	END
GO

--add data
insert into tblPublisher(publisherName) 
values(N'Kim Dong'), (N'Giao Duc'), (N'Phuong Nam'), (N'Ha Noi')
go

select * from tblPublisher
go

insert into tblCategory(catName)
values(N'Information Technology'), (N'Children'),(N'Science'),(N'Bussiness'),('Comic')
go

select * from tblCategory
go

insert into tblStoreOwner(ownerID, ownerName, ownerPassword, ownerAddress)
values  (N'S0123', 'BaoKhang', N'123', N'12 Hai Bà Trưng'),
		(N'S0456', 'DuyKhang', N'456', N'12 Hai Bà Trưng'),
		(N'S0789', 'DucTai', N'789', N'12 Hai Bà Trưng'),
		(N'S1011', 'VanChien', N'101112', N'12 Hai Bà Trưng')
go

select * from tblStoreOwner
go

insert into tbladmin(adminID, ownerID, adminname, adminpassword, adminphoto)
values  (N'A0123','S0123', 'BaoKhang', N'123', 'adminphoto01.png'),
		(N'A0456','S0456', 'DuyKhang', N'456', N'adminphoto02.png'),
		(N'A0789','S0789','DucTai', N'789', N'adminphoto03.png'),
		(N'A1011','S1011', 'VanChien', N'101112', N'adminphoto03.png')
go
select * from tblPublisher
go
select * from tblStoreOwner
go
select * from tbladmin
go


--minimum 20 books
	insert into tblBook(bookID, bookTitle, bookPrice, bookImage1, catID, publisherID, ownerID)
	values ('B0001', N'ASP.NET core MVC', '35500', 'book01.jpg',1,3,'S0123'),
			('B0002', N'C# Programming', '200000', 'book02.jpg',1,2,'S0456'),
			('B0003', N'Thinking in Java', '150000', 'book03.jpg',1,1,'S0789'),
			('B0004', N'Microsoft SQL server 2023', '350000', 'book04.jpg',1,1,'S0123'),
			('B0005', N'Laravel Framework in Action', '370000', 'book05.jpg',3,3,'S0456'),
			('B0006', N'THÁM TỬ LỪNG DANH CONAN', '22500', 'book06.jpg',5,4,'S0456'),
			('B0007', N'NHIỆM VỤ TỐI THƯỢNG', '27000', 'book07.jpg',5,4,'S0123'),
			('B0008', N'The Pragmatic Programmer', '288000', 'book08.jpg',1,1,'S0456'),
			('B0009', N'Mythical Man-Month', '140000', 'book09.jpg',1,1,'S0789'),
			('B0010', N'Peopleware', '320000', 'book10.jpg',1,1,'S1011'),
			('B0011', N'Advanced Linux Programming', '150000', 'book11.jpg',1,1,'S0789'),
			('B0012', N'STEM ', '45000', 'book12.jpg',1,1,'S0123'),
			('B0013', N'Programming luggage', '170000', 'book13.jpg',1,1,'S1011'),
			('B0014', N'MASHLE ', '27000', 'book14.jpg',5,4,'S0456'),
			('B0015', N'Until the July telomere ends', '120000', 'book15.jpg',5,4,'S0789'),
			('B0016', N'A Silent Voice', '129000', 'book16.jpg',5,4,'S0123'),
			('B0017', N'Eating the Alphabet', '350000', 'book17.jpg',2,2,'S0456'),
			('B0018', N'A Seed Grows', '290000', 'book18.jpg',2,2,'S1011'),
			('B0019', N'We Are the Gardeners', '230000', 'book19.jpg',2,2,'S0123'),
			('B0020', N'Winter Gardens', '150000', 'book20.jpg',2,2,'S0456')
	go

	select * from tblBook
	go