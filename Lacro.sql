create database Lacro
use Lacro
create table Post(
Id int primary key identity,
Title nvarchar(100) not null,
Content nvarchar(500) not null

)
select * from Post

