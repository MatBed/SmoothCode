CREATE PROCEDURE [dbo].[spUser_GetById]
	@userId int
AS
begin
	select Id, FirstName, LastName, Email, PhoneNumber
	from dbo.[User]
	where Id = @userId
end