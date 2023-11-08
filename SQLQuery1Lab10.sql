Use NorthWind
Go
Select ProductName, UnitPrice, Categories.CategoryName FROM Products 
INNER JOIN Categories ON Products.CategoryID = Categories.CategoryID
ORDER BY Categories.CategoryName, ProductName;

Select CompanyName, COUNT(Orders.CustomerID) AS OrderCount FROM Customers
LEFT JOIN Orders ON Customers.CustomerId = Orders.CustomerId
GROUP BY Customers.CustomerId, Customers.CompanyName
ORDER BY OrderCount DESC

Select E.EmployeeID, FirstName, T.TerritoryDescription FROM Employees AS E
JOIN EmployeeTerritories AS ET ON E.EmployeeID = ET.EmployeeID
JOIN Territories AS T ON ET.TerritoryID = T.TerritoryID;

