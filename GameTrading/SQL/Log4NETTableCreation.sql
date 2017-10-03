Create Table [dbo].[Log4Net](
[ID] [int] IDENTITY (1,1) NOT NULL,
[Date] [datetime] not null,
[Thread][varchar] (255) not null,
[Level][varchar] (10) not null,
[Logger][varchar](1000) not null,
[Message] [varchar] (4000) not null,
[Exception][varchar](4000) not null
)
ON [Primary]
