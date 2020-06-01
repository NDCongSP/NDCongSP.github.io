CREATE TABLE Category (
    ID int primary key IDENTITY(1,1),
    name varchar(255),
    alias varchar(255),
    parentId int,
    createdDate datetime default getdate(),
	status bit default 1
);
go

INSERT INTO Category (name, alias)
VALUES ('May Tinh','may-tinh');
INSERT INTO Category (name, alias)
VALUES ('May Tinh1','may-tinh1');

INSERT INTO Category (name, alias)
VALUES ('May Tinh2','may-tinh2');

INSERT INTO Category (name, alias)
VALUES ('May Tinh3','may-tinh3');
INSERT INTO Category (name, alias)
VALUES ('May Tinh4','may-tinh4');
INSERT INTO Category (name, alias)
VALUES ('May Tinh5','may-tinh5');
INSERT INTO Category (name, alias)
VALUES ('May Tinh6','may-tinh6');
INSERT INTO Category (name, alias)
VALUES ('May Tinh7','may-tinh7');

INSERT INTO Category (name, alias,status)
VALUES ('May Bay','May Bay',0);
INSERT INTO Category (name, alias,status)
VALUES ('May Bay1','May Bay1',0);
INSERT INTO Category (name, alias,status)
VALUES ('May Bay2','May Bay2',0);


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


ALTER proc spCategoryWhere
@status int
as
begin
 select * from Category where status = @status
end
go

exec spCategoryWhere @status=0