CREATE TABLE Category (
    ID int primary key IDENTITY(1,1),
    name varchar(255),
    alias varchar(255),
    parentId int,
    createdDate datetime default getdate(),
	status bit default 1
);
go

CREATE TABLE Product (
    ID int primary key IDENTITY(1,1),
    name varchar(255),
    alias varchar(255),
    categoryId int,
    images nvarchar(500),
	price decimal(18,0),
	detail ntext,
	status bit
);
go

