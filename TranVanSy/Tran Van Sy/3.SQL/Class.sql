use StudentManagement
go
 
create table Class(
    ClassId int not null primary key,
	ClassName varchar(100) not null,
	TeacherId int not null foreign key references Teacher(Id),
	StartTime time not null,
	EndTime time not null
);

insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (1, 'Luminex Corporation', 18, '7:16 AM', '11:23 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (2, 'Mitel Networks Corporation', 40, '7:47 AM', '11:58 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (3, 'Algonquin Power & Utilities Corp.', 40, '7:56 AM', '11:15 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (4, 'Sanderson Farms, Inc.', 4, '7:39 AM', '11:48 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (5, 'Capitol Acquisition Corp. III', 70, '7:08 AM', '11:22 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (6, 'Sun Communities, Inc.', 67, '7:52 AM', '11:05 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (7, 'Time Warner Inc.', 70, '7:37 AM', '11:09 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (8, 'Middlesex Water Company', 82, '7:03 AM', '11:03 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (9, 'Mid-America Apartment Communities, Inc.', 19, '7:16 AM', '11:42 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (10, 'Ivy High Income Opportunities Fund', 92, '7:16 AM', '11:06 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (11, 'The Community Financial Corporation', 33, '7:06 AM', '11:52 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (12, 'Vanguard Global ex-U.S. Real Estate ETF', 4, '7:08 AM', '11:35 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (13, 'OGE Energy Corporation', 65, '7:28 AM', '11:09 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (14, 'Xenia Hotels & Resorts, Inc.', 54, '7:47 AM', '11:02 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (15, 'Neff Corporation', 25, '7:51 AM', '11:49 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (16, 'Sempra Energy', 74, '7:00 AM', '11:01 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (17, 'Enphase Energy, Inc.', 96, '7:08 AM', '11:45 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (18, 'Orion Engineered Carbons S.A', 23, '7:22 AM', '11:49 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (19, 'Insys Therapeutics, Inc.', 32, '7:48 AM', '11:01 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (20, 'Insignia Systems, Inc.', 5, '7:58 AM', '11:44 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (21, 'Kennedy-Wilson Holdings Inc.', 100, '7:26 AM', '11:29 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (22, 'The Bancorp, Inc.', 61, '7:22 AM', '11:13 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (23, 'Origo Acquisition Corporation', 26, '7:52 AM', '11:00 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (24, 'BancFirst Corporation', 13, '7:11 AM', '11:56 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (25, 'Synthetic Fixed-Income Securities, Inc.', 53, '7:08 AM', '11:41 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (26, 'AstroNova, Inc.', 28, '7:16 AM', '11:55 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (27, 'BroadSoft, Inc.', 7, '7:40 AM', '11:07 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (28, 'Burlington Stores, Inc.', 56, '7:14 AM', '11:47 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (29, 'Greif Bros. Corporation', 24, '7:49 AM', '11:23 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (30, 'State Street Corporation', 19, '7:44 AM', '11:39 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (31, 'Zafgen, Inc.', 66, '7:46 AM', '11:47 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (32, 'SORL Auto Parts, Inc.', 84, '7:47 AM', '11:02 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (33, 'Nam Tai Property Inc.', 62, '7:38 AM', '11:36 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (34, 'Epizyme, Inc.', 63, '7:07 AM', '11:51 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (35, 'Banc of California, Inc.', 24, '7:51 AM', '11:46 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (36, 'Pulmatrix, Inc.', 66, '7:35 AM', '11:56 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (37, 'Liberty Media Corporation', 79, '7:20 AM', '11:31 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (38, 'VelocityShares Daily Inverse VIX Medium-Term ETN', 51, '7:28 AM', '11:10 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (39, 'Alphabet Inc.', 18, '7:08 AM', '11:17 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (40, 'First Trust NASDAQ Technology Dividend Index Fund', 39, '7:11 AM', '11:30 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (41, 'QUALCOMM Incorporated', 67, '7:05 AM', '11:28 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (42, 'Steven Madden, Ltd.', 2, '7:21 AM', '11:23 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (43, 'Athene Holding Ltd.', 93, '7:05 AM', '11:05 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (44, 'Lexington Realty Trust', 10, '7:26 AM', '11:34 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (45, 'Community Bankers Trust Corporation.', 68, '7:58 AM', '11:04 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (46, 'Royal Gold, Inc.', 94, '7:52 AM', '11:26 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (47, 'GAIN Capital Holdings, Inc.', 91, '7:27 AM', '11:49 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (48, 'Hornbeck Offshore Services', 75, '7:23 AM', '11:10 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (49, 'Zions Bancorporation', 81, '7:03 AM', '11:45 AM');
insert into Class (ClassId, ClassName, TeacherId, StartTime, EndTime) values (50, 'Solar Capital Ltd.', 39, '7:08 AM', '11:52 AM');

--them du lieu vao bang class
insert into Class values(51,'Hoa', 40, '7:00 AM', '11:00 AM')
select *from Class
where ClassId=51;

--sua thong tin class
update Class
set ClassName='Sinh', TeacherId=12
where classId=5;
select *from Class
where ClassId=5;

-- xoa thong tin class
delete from Class where ClassId=2;

--tim kiem class
select *from Class
where ClassId=5;