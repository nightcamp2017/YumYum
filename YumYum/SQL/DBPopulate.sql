use [YumYum]
SET IDENTITY_INSERT dbo.StaffType ON
insert into StaffType(Id,Type) values(1,'Full-Time')
insert into StaffType(Id,Type) values(2,'Part-Time')
SET IDENTITY_INSERT dbo.StaffType OFF
SET IDENTITY_INSERT dbo.StaffPosition ON
insert into StaffPosition(Id,Position,StaffTypeId) values(1,'Manager',1)
insert into StaffPosition(Id,Position,StaffTypeId) values(2,'Server',2)
SET IDENTITY_INSERT dbo.StaffPosition Off

