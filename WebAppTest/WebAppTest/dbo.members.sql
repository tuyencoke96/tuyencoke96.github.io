CREATE TABLE [dbo].[members] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [first_name] NVARCHAR (50)  NOT NULL,
    [surname]    NVARCHAR (50)  NOT NULL,
    [email]      NVARCHAR (200) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

