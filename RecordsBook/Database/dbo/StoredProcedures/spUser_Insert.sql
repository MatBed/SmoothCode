CREATE PROCEDURE [dbo].[spUser_Insert]
	@firstName nvarchar(50),
	@lastName nvarchar(50),
	@email nvarchar(max),
	@phoneNumber nvarchar(50)
AS
	insert into dbo.[User] (FirstName, LastName, Email, PhoneNumber)
	values (@firstName, @lastName, @email, @phoneNumber)
RETURN 0
