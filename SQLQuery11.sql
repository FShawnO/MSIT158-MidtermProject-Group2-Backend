/****** SSMS 中 SelectTopNRows 命令的指令碼  ******/
SELECT SUM(core.[PackQty]) FROM (

SELECT DISTINCT
--[PackageWayDetailID]
      --,
	  PAD.[PackageID]
      ,[OrderID]
      ,[PackQty] 
	  --, A.PackageStyleID
  FROM [SelectShop].[dbo].[tPackageWayDetail] PAD
  JOIN [dbo].[tAllPackage] A
  ON PAD.PackageID = A.PackageID
  JOIN [dbo].[GiftPackageStyle] G
  ON A.PackageStyleID = G.PStlyeID
 --JOIN [dbo].[Boxes] Bo
 -- ON G.PStlyeID = Bo.PStlyeID
 --  JOIN [dbo].[Bags] Ba
 -- ON G.PStlyeID = Ba.PStlyeID
  JOIN [dbo].[Cards] C
  ON G.PStlyeID = C.PStlyeID) core
  --ORDER BY PAD.PackageID, OrderID
  