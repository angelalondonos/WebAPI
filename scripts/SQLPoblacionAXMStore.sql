use DBAXMStore

go

insert into STORE(name) 
values 
('Bodega Armenia'),
('Bodega Calarca'),
('Bodega Circasia')

go

insert into PRODUCT(code, name) 
values 
('R41','Televisor 22'),
('R42','Nevera'),
('R43','Lavadora')

go 

insert into INVENTORY(product_id, store_id, quantity) 
values 
(1, 1, 35),
(3, 1,12),
(2, 1,10)