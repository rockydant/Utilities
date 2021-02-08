/*  
Create AdminPageSubscriber table
*/

CREATE TABLE [dbo].[AdminPageSubscriber](
	[PageSubscriberId] [int] IDENTITY(1,1) NOT NULL,
	[ModuleId] [int] NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[CreatedBy] [nvarchar](256) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](256) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
  CONSTRAINT [PK_AdminPageSubscriber] PRIMARY KEY CLUSTERED 
  (
	[PageSubscriberId] ASC
  )
)
GO

/*  
Create foreign key relationships
*/
ALTER TABLE [dbo].[AdminPageSubscriber]  WITH CHECK ADD  CONSTRAINT [FK_AdminPageSubscriber_Module] FOREIGN KEY([ModuleId])
REFERENCES [dbo].Module ([ModuleId])
ON DELETE CASCADE
GO