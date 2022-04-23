CREATE PROCEDURE [dbo].[spUser_Update]
	@id int,
	@firstName nvarchar(50),
	@lastName nvarchar(50),
	@email nvarchar(max),
	@phone nvarchar(50)
AS
	update dbo.[User]
	set FirstName = @firstName, LastName = @lastName, Email = @email, PhoneNumber = @phone
	where Id = @id
RETURN 0
