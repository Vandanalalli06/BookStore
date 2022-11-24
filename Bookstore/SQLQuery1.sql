create database Bookstore

create table bookstore1
(
FullName varchar(100),
Email varchar(100),
Password varchar(100),
MobileNumber varchar(100),
)

alter procedure SpUser
(
@FullName varchar(150),
@Email varchar(150),
@Password varchar(150),
@MobileNumber varchar(150)
)
as
begin
insert into bookstore1 values(@FullName,@Email,@Password,@MobileNumber)
end