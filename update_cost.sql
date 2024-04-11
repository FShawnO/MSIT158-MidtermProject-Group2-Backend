UPDATE
    [SelectShop].[dbo].[tProduct]
SET
    [SelectShop].[dbo].[tProduct].[Cost] = t2.Cost
FROM
    [SelectShop].[dbo].[tProduct] t1
INNER JOIN
    [SelectShop_temp].[dbo].[tProduct] t2
ON 
    t1.ProductID = t2.ProductID