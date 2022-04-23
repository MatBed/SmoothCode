CREATE PROCEDURE [dbo].[spUser_GetAll]
AS
begin
	select Id, FirstName, LastName, Email, PhoneNumber
	from dbo.[User]
end