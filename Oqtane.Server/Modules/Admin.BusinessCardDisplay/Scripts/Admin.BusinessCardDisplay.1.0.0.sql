/*  
Create AdminBusinessCardDisplay table
*/

CREATE TABLE [dbo].[AdminBusinessCardDisplay](
	[BusinessCardDisplayId] [int] IDENTITY(1,1) NOT NULL,
	[ModuleId] [int] NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[CreatedBy] [nvarchar](256) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](256) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
  CONSTRAINT [PK_AdminBusinessCardDisplay] PRIMARY KEY CLUSTERED 
  (
	[BusinessCardDisplayId] ASC
  )
)
GO

/*  
Create foreign key relationships
*/
ALTER TABLE [dbo].[AdminBusinessCardDisplay]  WITH CHECK ADD  CONSTRAINT [FK_AdminBusinessCardDisplay_Module] FOREIGN KEY([ModuleId])
REFERENCES [dbo].Module ([ModuleId])
ON DELETE CASCADE
GO