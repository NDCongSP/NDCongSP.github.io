USE [OnlineShop]
GO
/****** Object:  StoredProcedure [dbo].[spAccountLogin]    Script Date: 5/28/2020 2:33:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER proc [dbo].[spAccountLogin]
@userName varchar(500),
@password varchar(500)
as
begin
	select COUNT(*) from Account where userName= @userName and password=@password
end
go

exec spAccountLogin @userName=admin,@password=admin
