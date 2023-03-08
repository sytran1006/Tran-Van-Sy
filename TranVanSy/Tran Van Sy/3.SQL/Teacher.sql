use StudentManagement
go

create table Teacher(
    Id int not null primary key,
	FullName varchar(255) not null,
	DateOfBirth date not null,
	StartYear int not null,
	PhoneNumber varchar(50) not null,
	Email varchar(100) not null
);

insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (1, 'Gaspard How', '2001-05-31', 2015, '7082176824', 'ghow0@walmart.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (2, 'Jelene Ivell', '2001-02-04', 2017, '9262426605', 'jivell1@sbwire.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (3, 'Obadias Boden', '2002-11-07', 2018, '4459472821', 'oboden2@cdc.gov');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (4, 'Frasco Soutter', '2002-02-11', 2019, '2293767954', 'fsoutter3@cdc.gov');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (5, 'Bartholomeo Simister', '1998-05-01', 2018, '3058488179', 'bsimister4@webnode.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (6, 'Nickie Leivers', '1998-12-28', 2020, '4252708694', 'nleivers5@mit.edu');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (7, 'Kial Klimko', '1998-09-19', 2019, '7072786129', 'kklimko6@cyberchimps.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (8, 'Broddie Cammacke', '2000-04-24', 2017, '3264175702', 'bcammacke7@tumblr.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (9, 'Leodora Meredyth', '1998-04-23', 2017, '3517925405', 'lmeredyth8@goo.ne.jp');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (10, 'Yevette Mariotte', '1998-07-21', 2020, '8809711939', 'ymariotte9@moonfruit.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (11, 'Dew Marini', '1998-03-01', 2020, '3969548382', 'dmarinia@prweb.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (12, 'Alysa Clackers', '2005-09-11', 2016, '7408545829', 'aclackersb@irs.gov');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (13, 'Westbrooke Bocke', '2004-01-25', 2017, '1703478061', 'wbockec@mozilla.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (14, 'Aurlie Shorie', '1995-10-12', 2017, '9418766028', 'ashoried@huffingtonpost.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (15, 'Crysta Tabram', '2001-12-03', 2019, '6408272187', 'ctabrame@who.int');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (16, 'Salomo Vannar', '1998-11-06', 2018, '5758332428', 'svannarf@newsvine.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (17, 'Leeanne Greaterex', '1997-03-18', 2020, '1138116714', 'lgreaterexg@opera.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (18, 'Robinett De Ruel', '2004-05-26', 2020, '9345725566', 'rdeh@un.org');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (19, 'Adelaide Willshire', '1997-06-01', 2018, '9068134540', 'awillshirei@newsvine.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (20, 'Ronnie Boldra', '1996-07-21', 2015, '3635675645', 'rboldraj@bigcartel.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (21, 'Tally Allett', '2003-09-05', 2015, '4695472234', 'tallettk@i2i.jp');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (22, 'Davy Albutt', '2000-08-23', 2015, '8395230873', 'dalbuttl@pen.io');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (23, 'Silvana Sprowell', '2005-08-17', 2019, '9827653497', 'ssprowellm@mlb.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (24, 'Mag Empson', '2004-04-22', 2018, '4229355116', 'mempsonn@salon.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (25, 'Enrique Congram', '1998-09-16', 2018, '6039783770', 'econgramo@va.gov');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (26, 'Andie Oldnall', '2001-07-08', 2019, '5161090216', 'aoldnallp@amazonaws.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (27, 'Vikky Dulake', '2005-03-17', 2018, '6921365666', 'vdulakeq@facebook.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (28, 'Athena Drover', '2005-06-28', 2015, '8066233929', 'adroverr@washingtonpost.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (29, 'Danella Abbis', '2004-05-19', 2017, '3924224711', 'dabbiss@gov.uk');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (30, 'Honey Eytel', '1996-02-11', 2017, '6449236749', 'heytelt@reverbnation.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (31, 'Xaviera Hammerberg', '2004-07-15', 2016, '3671951366', 'xhammerbergu@forbes.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (32, 'Martin Bineham', '2005-08-10', 2019, '4206423421', 'mbinehamv@bravesites.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (33, 'Bessy Haxbie', '1998-10-05', 2016, '1114075287', 'bhaxbiew@issuu.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (34, 'Rudy Flaws', '2000-11-13', 2018, '3561260881', 'rflawsx@smugmug.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (35, 'Uriel Fennick', '2005-09-27', 2015, '7012562206', 'ufennicky@vistaprint.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (36, 'Charin Pergens', '2004-06-17', 2020, '3434983097', 'cpergensz@google.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (37, 'Sawyere Spadari', '2005-06-27', 2015, '7584390019', 'sspadari10@telegraph.co.uk');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (38, 'Cassi Klausen', '1999-04-21', 2015, '5863665952', 'cklausen11@ebay.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (39, 'Kliment Zorzutti', '1999-01-19', 2016, '4953234532', 'kzorzutti12@bloomberg.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (40, 'Em Lusgdin', '2002-02-01', 2016, '5735422303', 'elusgdin13@irs.gov');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (41, 'Marcille Kubacki', '1999-08-15', 2019, '9706912418', 'mkubacki14@nytimes.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (42, 'Jessi Dawtry', '1998-12-04', 2019, '6651301847', 'jdawtry15@webeden.co.uk');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (43, 'Koressa Cheater', '1997-12-10', 2020, '2947537608', 'kcheater16@reuters.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (44, 'Anderson Naire', '2003-03-18', 2015, '9467046643', 'anaire17@bravesites.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (45, 'Nonie Greyes', '2004-10-26', 2019, '4689517549', 'ngreyes18@salon.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (46, 'Annnora Brettle', '1997-01-01', 2018, '4216018593', 'abrettle19@dyndns.org');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (47, 'Jackson Winley', '2001-08-22', 2020, '3604622620', 'jwinley1a@google.pl');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (48, 'Denyse Covert', '2002-07-14', 2018, '3182647376', 'dcovert1b@cnbc.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (49, 'Doris Kundert', '2001-06-09', 2015, '9402886229', 'dkundert1c@e-recht24.de');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (50, 'Yalonda Holley', '1998-08-09', 2016, '2615849458', 'yholley1d@mit.edu');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (51, 'Inglebert Antonescu', '2001-10-09', 2017, '4371029654', 'iantonescu1e@sphinn.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (52, 'Moria Durbin', '1996-04-13', 2018, '2314799579', 'mdurbin1f@wikimedia.org');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (53, 'Bella Dobell', '1996-06-03', 2018, '6633820637', 'bdobell1g@sbwire.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (54, 'Shaine Gabe', '1995-10-01', 2020, '8159831011', 'sgabe1h@ucla.edu');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (55, 'Zita Coopper', '1999-12-05', 2018, '8063589116', 'zcoopper1i@cnn.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (56, 'Skippie Issit', '1998-07-17', 2015, '1669139287', 'sissit1j@printfriendly.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (57, 'Nataline Garrould', '1998-06-28', 2019, '6416702894', 'ngarrould1k@quantcast.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (58, 'Vidovik Moysey', '2005-03-31', 2017, '8992374998', 'vmoysey1l@trellian.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (59, 'Cleo Matteoli', '2005-08-30', 2016, '3333708515', 'cmatteoli1m@goo.ne.jp');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (60, 'Maryanna Bennison', '2000-07-06', 2018, '6886726773', 'mbennison1n@mayoclinic.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (61, 'Peter Baily', '1996-12-14', 2017, '9188347455', 'pbaily1o@cnet.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (62, 'Ceciley Davidescu', '1996-06-30', 2016, '9239517067', 'cdavidescu1p@ihg.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (63, 'Diann Steers', '2002-08-04', 2016, '2713263697', 'dsteers1q@ameblo.jp');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (64, 'Lisha Plesing', '2002-10-13', 2019, '6417982637', 'lplesing1r@google.es');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (65, 'Kendall Mountford', '2002-12-30', 2017, '4156060347', 'kmountford1s@hhs.gov');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (66, 'Krysta Bucke', '2002-12-18', 2016, '6302322392', 'kbucke1t@flavors.me');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (67, 'Laraine Tod', '1999-12-07', 2020, '8985581676', 'ltod1u@newyorker.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (68, 'Sindee Steljes', '2005-03-04', 2017, '9022260561', 'ssteljes1v@vk.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (69, 'Shepherd Bernocchi', '2003-01-11', 2015, '2549267395', 'sbernocchi1w@spotify.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (70, 'Letti Wehnerr', '1996-07-11', 2018, '8393032625', 'lwehnerr1x@xrea.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (71, 'Candida Purdon', '2002-05-28', 2020, '7957647622', 'cpurdon1y@delicious.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (72, 'Candace Crayke', '2001-06-08', 2018, '4767661242', 'ccrayke1z@ebay.co.uk');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (73, 'Irvine Rosenwald', '1999-10-08', 2020, '8622043571', 'irosenwald20@jiathis.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (74, 'Judye Leeburn', '2001-12-16', 2019, '6885275547', 'jleeburn21@globo.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (75, 'Angeli Belderson', '2003-06-25', 2020, '4869174069', 'abelderson22@hubpages.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (76, 'Babb Tabbernor', '1997-07-07', 2017, '5829311352', 'btabbernor23@yandex.ru');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (77, 'Cindra Fullicks', '2005-04-20', 2017, '9787464271', 'cfullicks24@technorati.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (78, 'Duffy Snooks', '2001-05-23', 2017, '7409340891', 'dsnooks25@goo.gl');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (79, 'Darnall Esh', '1997-06-06', 2015, '8671095718', 'desh26@vk.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (80, 'Lishe Edward', '2002-01-10', 2018, '3811973980', 'ledward27@washingtonpost.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (81, 'Clemmy Asser', '2005-08-23', 2017, '7114497297', 'casser28@histats.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (82, 'Bevan Carnow', '2000-10-18', 2018, '7509285425', 'bcarnow29@thetimes.co.uk');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (83, 'Matthus Stibbs', '2001-10-20', 2019, '5112587883', 'mstibbs2a@cnbc.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (84, 'Alfons Lovick', '2002-05-27', 2018, '6288783195', 'alovick2b@cafepress.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (85, 'Modestia Yearron', '1998-08-21', 2020, '7267864016', 'myearron2c@exblog.jp');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (86, 'Pavel Pervoe', '2001-04-04', 2020, '2216472480', 'ppervoe2d@flickr.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (87, 'Martina Holston', '2002-02-04', 2017, '8752120348', 'mholston2e@bandcamp.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (88, 'Lindsy Paike', '2005-01-12', 2020, '1934712508', 'lpaike2f@eventbrite.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (89, 'Lynsey Joskovitch', '2005-05-23', 2020, '9126994881', 'ljoskovitch2g@hhs.gov');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (90, 'Ethelda Ferber', '1999-06-20', 2019, '8628727147', 'eferber2h@wiley.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (91, 'Niki Peddowe', '2003-02-17', 2018, '2603013226', 'npeddowe2i@jiathis.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (92, 'Kirstin Kubat', '1999-06-19', 2019, '6967382753', 'kkubat2j@ca.gov');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (93, 'Blinny Nunan', '2000-03-10', 2020, '2874717785', 'bnunan2k@mapquest.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (94, 'Annalee Anstey', '2003-04-16', 2015, '9506505470', 'aanstey2l@vkontakte.ru');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (95, 'Rawley Harradine', '2001-09-15', 2017, '9386945494', 'rharradine2m@yahoo.co.jp');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (96, 'Prudi Croucher', '2002-10-06', 2017, '5451724619', 'pcroucher2n@domainmarket.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (97, 'Ceciley Neil', '2002-12-23', 2019, '4071096673', 'cneil2o@a8.net');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (98, 'Sarita Lucian', '2004-12-16', 2018, '7208823383', 'slucian2p@artisteer.com');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (99, 'Lyman Ardley', '2005-08-29', 2017, '1807021592', 'lardley2q@discuz.net');
insert into Teacher (Id, FullName, DateOfBirth, StartYear, PhoneNumber, Email) values (100, 'Noemi Beggs', '1998-10-07', 2018, '8605316943', 'nbeggs2r@mayoclinic.com');

--them du lieu vao bang teacher
insert into Teacher values (101,'Tran Van Sy','2000-06-10',2015,'0365738184','sytranhd@gamil.com')
select * from Teacher
where Id=101;

--sua thong tin sinh vien
update Teacher
set FullName = 'Le Thi Thu Huyen', DateOfBirth = '2002-07-27', Email='huyen@mail.com', StartYear=2017
where Id=5;
select * from Teacher
where Id=5;

--xoa thong tin sinh vien
delete from Teacher where Id=10;
select top 20 * from Student;

--tim kiem thong tin sinh vien theo id
select * from Teacher 
where Id=50;

--lay danh sach giao vien cung nam vao truong
select * from Teacher 
where StartYear=2015;