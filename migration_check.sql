CREATE TABLE TodoGroup (Id int IDENTITY(1,1), ForDay date)
ALTER TABLE Todo ADD GroupId int

INSERT INTO TodoGroup (ForDay) SELECT Todo.ForDay FROM Todo GROUP BY Todo.ForDay

UPDATE Todo SET Todo.GroupId = TodoGroup.Id FROM Todo INNER JOIN TodoGroup ON Todo.ForDay = TodoGroup.ForDay 

SELECT * FROM Todo

DROP TABLE TodoGroup
ALTER TABLE Todo DROP COLUMN GroupId