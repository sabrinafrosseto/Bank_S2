create schema Bank_S2;
use Bank_S2;
create table BankAccount (id int auto_increment primary key, Titular varchar(50), Numero int, Saldo decimal);
select * from BankAccount;
insert into BankAccount values (null, 'Luiz', 1234, 500);
insert into BankAccount values (null, 'Sabrina', 2345, 300);
insert into BankAccount values (null, 'Fernanda', 3456, 100);
insert into BankAccount values (null, 'Evie', 4567, 50);