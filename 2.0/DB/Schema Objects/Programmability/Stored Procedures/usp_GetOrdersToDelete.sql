IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetOrdersToDelete]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[usp_GetOrdersToDelete]
GO

-- IncludeDeleted can be used for debug
create proc [dbo].[usp_GetOrdersToDelete] (@IncludeDeleted char(1) = 'N' )
as
set nocount on

select ORDER_ID
      ,ExternalLink
      ,DATE
      ,ModifiedOn
  from ORDERS
 where (
           @IncludeDeleted = 'Y'
        or ( Active = 'Y' and ModifiedOn < dateadd( dd, -7, getdate() ) )
       )
   and ExternalLink is not null
 order by ORDER_ID

GO
