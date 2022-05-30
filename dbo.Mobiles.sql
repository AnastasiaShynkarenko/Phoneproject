CREATE TABLE [dbo].[Mobiles] (
    [First]  VARCHAR (50)   NULL,
    [Last]   VARCHAR (50)   NULL,
    [Mobile] VARCHAR (50)   NOT NULL,
    [Email]  VARCHAR(50) NULL,
    [Group]  VARCHAR(50) NULL,
    CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED ([Mobile] ASC)
);

