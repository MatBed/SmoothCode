CREATE PROCEDURE [dbo].[spUser_Insert]
	@firstName nvarchar(50),
	@lastName nvarchar(50),
	@email nvarchar(max),
	@phone nvarchar(50)
AS
	insert into dbo.[User] (FirstName, LastName, Email, PhoneNumber)
	values (@firstName, @lastName, @email, @phone)
RETURN 0
