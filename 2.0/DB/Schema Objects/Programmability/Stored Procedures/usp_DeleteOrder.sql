IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_DeleteOrder]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_DeleteOrder]
GO

create proc [dbo].[usp_DeleteOrder]
(
 @OrderId int
,@ModifiedBy int
)
as
set nocount on

update ORDERS
   set Active = 'N'
      ,ModifiedBy = @ModifiedBy
      ,ModifiedOn = getdate()
 where ORDER_ID = @OrderId
   and Active='Y'

GO
