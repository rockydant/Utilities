DROP TABLE [dbo].[AdminQRCodeGenerator]
CREATE TABLE [dbo].[AdminQRCodeGenerator](
	[QRCodeGeneratorId] [int] IDENTITY(1,1) NOT NULL,
	[ModuleId] [int] NOT NULL,
	[Name] [nvarchar](256) NOT NULL,    
    [Type] [nvarchar](256) DEFAULT '',
    [LinkUrl] [nvarchar](MAX) DEFAULT '',
    [QrCode] [nvarchar](MAX) DEFAULT '',
	[CreatedBy] [nvarchar](256) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](256) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
  CONSTRAINT [PK_AdminQRCodeGenerator] PRIMARY KEY CLUSTERED 
  (
	[QRCodeGeneratorId] ASC
  )
)
GO

/*  
Create foreign key relationships
*/
ALTER TABLE [dbo].[AdminQRCodeGenerator]  WITH CHECK ADD  CONSTRAINT [FK_AdminQRCodeGenerator_Module] FOREIGN KEY([ModuleId])
REFERENCES [dbo].Module ([ModuleId])
ON DELETE CASCADE
GO