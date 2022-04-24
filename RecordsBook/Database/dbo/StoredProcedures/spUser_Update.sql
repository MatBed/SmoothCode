CREATE PROCEDURE [dbo].[spUser_Update]
	@id int,
	@firstName nvarchar(50),
	@lastName nvarchar(50),
	@email nvarchar(max),
	@phoneNumber nvarchar(50)
AS
	update dbo.[User]
	set FirstName = @firstName, LastName = @lastName, Email = @email, PhoneNumber = @phoneNumber
	where Id = @id
RETURN 0
