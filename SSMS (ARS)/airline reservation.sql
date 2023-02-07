create database ars;
--------------create Table Flight server--------------------

create table flight_Server
(
Server_Id int,
flight_no int not null,
origin varchar(255) not null,
destination varchar(255) not null,
origin_time time,
destination_time time,
total_seats_available int not null,
Pilot_user_ID varchar(255),
primary key(Server_Id)
);

-------------------Create table Flight Client-------------------
create table flight_Client(
Client_user_ID int not null,
name varchar(255) not null,
contact_information varchar(255),
seat_required int not null,
Server_Id int,
primary key (Client_user_ID),
FOREIGN KEY (Server_Id) REFERENCES flight_Server(Server_Id)
);

-------------------Create table Pilot Information---------------------
create table Pilot_information(
Pilot_user_ID varchar(255),
Pilot_name varchar(255),
Pilot_gender varchar(255)
);

--------------------insertion for flight server-----------------
insert into flight_Server values(1,111,'New York','London', '22:19:09','19:32:50' ,40, 'P1' );
insert into flight_Server values(2,222,'London', 'New York', '23:59:59','02:23:45' ,50, 'P2' );
insert into flight_Server values(3,333,'Mumbai', 'Banglore', '18:05:59','02:53:45' ,45, 'P3' );
insert into flight_Server values(4,444,'Mumbai', 'Hyderabad', '20:19:59','02:39:45' ,30, 'P4');
select * from flight_Server;

--------------------insertion for flight client-----------------
insert into flight_Client values(2, 'Naresh' , '1234567890', 5, 1);
insert into flight_Client values(3, 'Hemangi' , '7778889990', 7,2);
insert into flight_Client values(4, 'Pinal' , '2223334445', 9,3);
insert into flight_Client values(5, 'Kishan' , '11122334445', 5,4);

select * from flight_Client;

--------------------insertion for Pilot information-----------------
insert into Pilot_information values('P1', 'Hardik' , 'Male');
insert into Pilot_information values('P2', 'Vinit' , 'Male');
insert into Pilot_information values('P3', 'Nihar', 'Male');
select * from Pilot_information;



-------------------JOIN------------------------------

-- fetch the flight no. and client name they belong to (inner join)
select fs.flight_no, fc.name
from flight_Server fs inner join flight_Client fc  on fs.Server_Id = fc.Client_user_ID;

-- fetch the ALL  flight no. and client name they belong to (left join/left outer join)
select fs.flight_no, fc.name
from flight_Server fs left join flight_Client fc  on fs.Server_Id = fc.Client_user_ID;

-- fetch the flight no. and All client name they belong to (right join/ right outer join)
select fs.flight_no, fc.name
from flight_Server fs right join flight_Client fc  on fs.Server_Id = fc.Client_user_ID;

-- fetch the all flight no. , their client name and  pilot name
select fs.flight_no, fc.name, pl.Pilot_name
from flight_Server fs
left join flight_Client fc on fs.Server_Id = fc.Client_user_ID
left join  Pilot_information pl on pl.Pilot_user_ID = fs.Pilot_user_ID;

--------Full Join----------------------
select fs.flight_no, fc.name
from flight_Server fs
full join flight_Client fc on fc.Client_user_ID = fs.Server_Id;

-------Cross Join (it return cartesian product) -----------------------
select fs.flight_no, fc.name
from flight_Server fs   -- 4
cross join flight_Client fc; --4


------------------Stored procedure-------------
GO
CREATE PROCEDURE server_procedure
AS
select * from flight_Server
GO

EXEC server_procedure;
GO

----------------stored program (with parameter)--------------
go 
create procedure server_procedure2
as
select flight_no from flight_Server where  flight_no > 222;
go

exec server_procedure2;
go







------------------Indexing ---------------
select count(*) from flight_Server;

select top 1 * from flight_Server order by Server_Id desc;
--BEFORE---
select * from flight_Server where Server_Id = 2;

---After ----
--create clustered index server_idx
--on flight_Server(Server_Id asc)
--select * from flight_Server where Server_Id = 2;
---------------
--select * from INFORMATION_SCHEMA.TABLE_CONSTRAINTS;
--alter table flight_server
--drop constraint PK__flight_S__FED355D36649D422;


----- natural join (same as a inner join, but difference is that SQL has to choose the condition)-------
select fs.flight_no, fc.name
from flight_Server fs
join flight_Client fc on fc.Client_user_ID = fs.Server_Id;

--------SELF Join--------
SELECT A.Client_user_ID AS cl , B.Client_user_ID AS cl2, A.Server_Id, B.Server_Id
FROM flight_Client A, flight_Client B
--WHERE A.Client_user_ID <> B.Client_user_ID
--AND A.Server_Id = B.Server_Id
ORDER BY A.Server_Id;
--select * from flight_Client;



--------------DML trigger--------------

create table flight_trigger(
Flight_audit_Id int identity,
audit_action text 
);
go
create trigger t1 
on flight_Server 
for insert 
as
begin 
declare @tempId int
select @tempId = Server_Id from inserted
insert into flight_trigger values ('new Server with Id= ' + cast(@tempId as varchar(225)) + 'is added at' + cast(Getdate() AS VARCHAR(22)))
end
go
insert into flight_Server values(9,990,'New York','Himmatnagar', '21:19:09','21:32:50' ,40, 'P6' );
select * from flight_trigger;


-----------DDL Trigger-----------------
go
create trigger second_flight_trigger
on database
for CREAT_TABLE
as 
begin
    print 'you have created, altered or dropped a table'
end
create table test (server int)


go
-------------------Cursor-----------
begin 
declare flight_cursor cursor scroll     ------Declaring the cursor
for select Server_Id,flight_no,origin from flight_Server 
open flight_cursor                      -------open the cursor

fetch next from  flight_cursor          ------fetch the cursor
while @@FETCH_STATUS = 0
    fetch next from flight_cursor 

close flight_cursor                     ------ close the cursor
deallocate flight_cursor                ------ deallocate the cursor
end

 alter table flight_Client
 add after_reservation bit
  
 
 select * from flight_Client
---------------merge ------------------
go
MERGE flight_Server fs
USING flight_Client fc 
ON fs.Server_Id = fc.Client_user_ID
WHEN MATCHED THEN
  UPDATE
  SET fs.total_seats_available = fs.total_seats_available - fc.seat_required;
 go

 select * from flight_Client