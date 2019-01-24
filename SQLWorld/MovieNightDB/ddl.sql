create table [User].[Membership]
(
	[MembershipId] int not null identity(1,1)
	,[Level] int not null
	,[Price] numeric(5,2) not null
	,constraint PK_Membership_MembershipId primary key (MembershipId)
	,constraint UQ_Membership_Level unique ([Level])
);

create table [User].[Address]
(
[AddressId] int not null identity(1,1)
,[Street] nvarchar(100) not null
,[City]  nvarchar (100) not null
,[StateProvince] nvarchar (100) null
,[Country] nvarchar(100) not null
,[PostalCode] nvarchar(10) null
,constraint PK_Address_AddressId primary key (AddressId)
);

create table [User].[User]
(
[UserId] int not null identity (1,1)
,[Prefix] nvarchar(5) null
,[First] nvarchar (50) not null
,[Last] nvarchar (50) not null
,[MembershipId] int null
,[AddressId] int not null
,constraint PK_User_UserId primary key (UserId)
,constraint FK_User_MembershipId foreign key (MembershipId) references [User].[Membership](MembershipId)
,constraint FK_User_AddressId foreign key (AddressId) references [User].[Address](AddressId)
);

create table [User].[Payment]
(
PaymentId int not null identity(1,1)
,[UserId] int not null
,[CardHolder] nvarchar(110)
,[CardNumber] numeric(16,0)
,[Month] int not null
,[Year] int not null
,[VerificationCode] int not null
,constraint PK_Payment_PaymentId primary key ([PaymentId])
,constraint FK_Payment_UserId foreign key (UserId) references [User].[User](UserId)
);




create table [Library].[Address]
(
[AddressId] int not null identity(1,1)
,[Street] nvarchar(100) not null
,[City]  nvarchar (100) not null
,[StateProvince] nvarchar (100) null
,[Country] nvarchar(100) not null
,[PostalCode] nvarchar(10) null
,constraint PK_LibAddress_AddressId primary key (AddressId)
);

create table [Movie].[Genre]
(
[GenreId] int not null identity(1,1)
,[Name] nvarchar(500) not null
,[Description] nvarchar(250) null
,constraint PK_Genre_GenreId primary key (GenreId)
);

create table [Movie].[Rating]
(
[RatingId] int not null identity(1,1)
,[Name] nvarchar(500) not null
,[Description] nvarchar(250) null
,constraint PK_Rating_RatingId primary key (RatingId)
);

create table [Movie].[Movie]
(
[MovieId] int not null identity (1,1)
,[Title] nvarchar (50) not null
,[GenreId] int not null
,[RatingId] int not null
,[Summary] nvarchar(1000) null
,[Duration] time not null
,[Imdb] nvarchar(500)
,constraint PK_Movie_MovieId primary key (MovieId)
,constraint FK_Movie_GenreId foreign key (GenreId) references [Movie].[Genre](GenreId)
,constraint FK_Movie_RatingId foreign key (RatingId) references [Movie].[Rating](RatingId)
);

create table [Library].[Library]
(
[LibraryId] int not null identity (1,1)
,[AddressId] int not null
,constraint PK_Library_LibraryId primary key (LibraryId)
,constraint FK_Library_AddressId foreign key (AddressId) references [Library].[Address](AddressId)
);

create table [Library].[Content]
(
[ContentId] int not null identity(1,1)
,[LibraryId] int not null
,[MovieId] int not null
,[Quantity] int not null default(0)
,constraint PK_Content_ContentId primary key (ContentId)
,constraint FK_Content_LibraryId foreign key (LibraryId) references [Library].[Library](LibraryId)
,constraint FK_Content_MovieId foreign key (MovieId) references [Movie].[Movie](MovieId) 
);

create table [Movie].[Queue]
(
[QueueId] int not null identity(1,1)
,[UserId] int not null
,[MovieId] int not null
,constraint PK_Queue_Queue primary key (QueueId)
,constraint FK_Queue_UserId foreign key (UserId) references [User].[User](UserId)
,constraint FK_Queue_MovieId foreign key (MovieId) references [Movie].Movie(MovieId)
);

create table [Movie].[Collection]
(
[CollectionId] int not null identity(1,1)
,[UserId] int not null
,[MovieId] int not null
,constraint PK_Collection_Collection primary key (CollectionId)
,constraint FK_Collection_UserId foreign key (UserId) references [User].[User](UserId)
,constraint FK_Collection_MovieId foreign key (MovieId) references [Movie].Movie(MovieId)
);