CREATE PROCEDURE [dbo].[spUser_Delete]
	@userId int
AS
begin
	delete
	from dbo.[User]
	where Id = @userId
end