/*  
Create AdminBusinessCardDashboard table
*/

CREATE TABLE [dbo].[AdminBusinessCardDashboard](
	[BusinessCardDashboardId] [int] IDENTITY(1,1) NOT NULL,
	[ModuleId] [int] NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[CreatedBy] [nvarchar](256) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](256) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
  CONSTRAINT [PK_AdminBusinessCardDashboard] PRIMARY KEY CLUSTERED 
  (
	[BusinessCardDashboardId] ASC
  )
)
GO

/*  
Create foreign key relationships
*/
ALTER TABLE [dbo].[AdminBusinessCardDashboard]  WITH CHECK ADD  CONSTRAINT [FK_AdminBusinessCardDashboard_Module] FOREIGN KEY([ModuleId])
REFERENCES [dbo].Module ([ModuleId])
ON DELETE CASCADE
GO