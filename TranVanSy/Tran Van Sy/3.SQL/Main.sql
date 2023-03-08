use StudentManagement
go

--1.them du lieu vao bang student
insert into Student values (1026,'tranvansy','Male','2000-06-10','transy32@gmail.com','36657381855',9.6,36)

--1.sua thong tin sinh vien
update student
set FullName='Le Thi Thu Huyen', Gender='Female', DateOfBirth='2002-07-27', Email='huyen1@mail.com', Score=9, ClassId=22
where Id=5;

--1.xoa thong tin sinh vien
delete from student where Id=999

--1.tim kiem thong tin sinh vien theo id
select * from Student 
where Id=4;

--4.lay danh sach sinh vien
select *from Student

--lay danh sach sinh vien cung lop
select *from Student
where ClassId=5 ;

--lay ra tong so sinh vien trong lop co classid=5
select count(Id)
from Student
where ClassId=5;

--5.lay ra tong sinh vien trong moi lop
select ClassId, Count(Id) 'number student'
from Student
group by ClassId
order by ClassId asc

--6.lay ra 10 sinh vien diem cao nhat trong lop co id=5
select top 10* from Student 
where ClassId=5 
order by Score desc;

--thong ke so hoc sinh nam trong mot lop bat ki(vd ClassId = 12)
select count(Id)
from Student
where ClassId=5 and Gender='Male';

--7.thong ke so hoc sinh nam trong cac lop
select ClassId, count(Id) 'Male Student'
from Student
where Gender='Male'
group by ClassId
order by ClassId asc

--diem trung binh cua lop co id bang 5
select avg(Score)
from Student
where ClassId=5;

--8.diem trung binh cua moi lop va sap xep tu cao den thap
select ClassId, avg(Score) 'Avg score'
from Student
group by ClassId
order by Classid asc

--
select MAX(Id)from Student
--------------------------------------------------------------------------------------------------

--3.them du lieu vao bang class
insert into Class values(52,'Sinh', 40, '7:00 AM', '11:00 AM')

--3.sua thong tin class
update Class
set ClassName='Sinh', TeacherId=12
where classId=5;


--3.xoa thong tin class
delete from Class where ClassId=10

--3.tim kiem class
select *from Class
where ClassId=34;

--4.lay ra danh sach lop
select* from Class

--9.lay ra danh sach cac lop ma giao vien chu nhiem
select TeacherId, FullName, ClassName, StartTime, EndTime
from Class c, Teacher t
where c.TeacherId=t.Id
and TeacherId=40

--lay ra so luong cac lop ma giao vien chu nhiem
select TeacherId, 'Number of class'=count(ClassId)
from Class
group by TeacherId
order by TeacherId asc

--10.lay ra giao vien chu nhiem nhieu lop nhat
select TeacherId,  count(ClassId) 'Number of class'
from Class
group by TeacherId
having count(ClassId)>=all(select count(classId) from Class group by TeacherId)
----------------------------------------------------------------------------------

--2.them du lieu vao bang teacher
insert into Teacher values (1010,'tranvansy','2000-06-10',2015,'0365738185','sytranhd1@gamil.com')

--2.sua thong tin giao vien
update Teacher
set FullName = 'Le Thi Thu Huyen', DateOfBirth = '2002-07-27', Email='huyen@mail.com', StartYear=2017
where Id=5;


--2.xoa thong tin giao vien
delete from Teacher where Id=11;


--2.tim kiem thong tin giao vien theo id
select * from Teacher 
where Id=50;

--4.Lay ra danh sach giao vien
select *from Teacher

--lay danh sach giao vien cung nam vao truong
select * from Teacher 
where StartYear=2015;


--lay ra danh sach diem trung binh cua cac lop
select top 10  ClassId,'Average of score'= avg(Score)
from Student
group by ClassId
order by avg(Score) desc

--------------------------------------------------------------------------------------
--1.nang cao :thong ke 10 giao vien chu nhiem lop co diem trung binh cao nhat
select top 10 Teacher.Id 'TeacherId',Teacher.FullName, Teacher.DateOfBirth,Teacher.Email,Teacher.PhoneNumber,Teacher.StartYear, Class.ClassId, KQ.[Average of score]
from Teacher ,Class,
(select top 10 Class.ClassId, AVG(Score)'Average of score'
from Class, Student, Teacher
where Student.ClassId= Class.ClassId and Class.TeacherId= Teacher.Id
group by Class.ClassId
order by AVG(Score) desc)as KQ
where  Class.TeacherId= Teacher.Id and kq.ClassId= Class.ClassId

--2.nang cao: tim sinh vien theo giơi tinh
select st.Id,st.FullName, st.Gender,st.DateOfBirth,st.Email, st.PhoneNumber,st.Score,st.ClassId
from( select *
from Student
where Gender='Male')as st
where  st.Id=40;

--2.nang cao: tim giao vien theo nam vao truong
select tc.Id,tc.FullName,tc.DateOfBirth,tc.StartYear, tc.PhoneNumber,tc.Email
from( select *
from Teacher
where StartYear= 2017)as tc
where  tc.Id=13;

--2.nang cao: tim lop theo gio bat dau , gio ket thuc
select cl.ClassId,cl.ClassName,cl.StartTime,cl.EndTime, cl.TeacherId
from( select *
from Class
where StartTime= '7:00 AM')as cl
where  cl.EndTime='11:00 AM';