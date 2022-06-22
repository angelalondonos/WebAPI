Create database DBAXMStore

go 

use DBAXMStore
go 

CREATE TABLE STORE(
  store_id int primary key identity,
  name varchar(100)
  )

go 

CREATE TABLE PRODUCT(
product_id int primary key identity,
code varchar(200),
name varchar(200)
)
go 

CREATE TABLE INVENTORY(
inventory_id int primary key identity,
product_id int references PRODUCT(product_id),
store_id int references STORE(store_id),
quantity int,
date_create datetime default getdate()
)

go 

