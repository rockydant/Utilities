/*  
Create AdminPageSubscriberDashboard table
*/

CREATE TABLE [dbo].[AdminPageSubscriberDashboard](
	[PageSubscriberDashboardId] [int] IDENTITY(1,1) NOT NULL,
	[ModuleId] [int] NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[CreatedBy] [nvarchar](256) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](256) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
  CONSTRAINT [PK_AdminPageSubscriberDashboard] PRIMARY KEY CLUSTERED 
  (
	[PageSubscriberDashboardId] ASC
  )
)
GO

/*  
Create foreign key relationships
*/
ALTER TABLE [dbo].[AdminPageSubscriberDashboard]  WITH CHECK ADD  CONSTRAINT [FK_AdminPageSubscriberDashboard_Module] FOREIGN KEY([ModuleId])
REFERENCES [dbo].Module ([ModuleId])
ON DELETE CASCADE
GO