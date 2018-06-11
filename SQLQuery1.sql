select * from games g 
left join tags t on g.title = t.title and t.tag = N'Игры для взрослых';

select distinct tag from tags;