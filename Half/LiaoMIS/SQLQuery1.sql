select a.Description from Board a
inner join Account c on a.Name = c.Account
where c.Id = 2;

update Board
Set Name = 'scottmico'
Where Id = 2;

insert into Board
Values('scottmico','NONONO');

delete from board
where Id = 3;