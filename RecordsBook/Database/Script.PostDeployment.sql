if not exists (select 1 from dbo.[User])
begin
	insert into dbo.[User] (FirstName, LastName, Email, PhoneNumber)
	values ('Tomasz', 'Kowalski', 'tomaszkowalski@gmail.com', '+48123123123')
	, ('Marek', 'Nowak', 'mareknowak@wp.pl', '+48987987987')
end 