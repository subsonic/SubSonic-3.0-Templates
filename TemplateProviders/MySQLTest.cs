


        //***********************************************
        //Table=alphabetical list of products
        //Columns=11
        //PK =ProductID
        
        //ProductID (int): Nullable: False
        //ProductName (string): Nullable: False
        //SupplierID (int): Nullable: True
        //CategoryID (int): Nullable: True
        //QuantityPerUnit (string): Nullable: True
        //UnitPrice (decimal): Nullable: True
        //UnitsInStock (short): Nullable: True
        //UnitsOnOrder (short): Nullable: True
        //ReorderLevel (short): Nullable: True
        //Discontinued (bool): Nullable: False
        //CategoryName (string): Nullable: False

        //***********************************************
        //Table=categories
        //Columns=4
        //PK =CategoryID
        
        //CategoryID (int): Nullable: False
        //CategoryName (string): Nullable: False
        //Description (string): Nullable: True
        //Picture (string): Nullable: True

        //***********************************************
        //Table=category sales for 1997
        //Columns=2
        //PK =CategoryName
        
        //CategoryName (string): Nullable: False
        //CategorySales (decimal): Nullable: True

        //***********************************************
        //Table=current product list
        //Columns=2
        //PK =ProductID
        
        //ProductID (int): Nullable: False
        //ProductName (string): Nullable: False

        //***********************************************
        //Table=customer and suppliers by city
        //Columns=4
        //PK =City
        
        //City (string): Nullable: True
        //CompanyName (string): Nullable: False
        //ContactName (string): Nullable: True
        //Relationship (string): Nullable: False

        //***********************************************
        //Table=customercustomerdemo
        //Columns=2
        //PK =CustomerID
        
        //CustomerID (string): Nullable: False
        //CustomerTypeID (string): Nullable: False

        //***********************************************
        //Table=customerdemographics
        //Columns=2
        //PK =CustomerTypeID
        
        //CustomerTypeID (string): Nullable: False
        //CustomerDesc (string): Nullable: True

        //***********************************************
        //Table=customers
        //Columns=11
        //PK =CustomerID
        
        //CustomerID (string): Nullable: False
        //CompanyName (string): Nullable: False
        //ContactName (string): Nullable: True
        //ContactTitle (string): Nullable: True
        //Address (string): Nullable: True
        //City (string): Nullable: True
        //Region (string): Nullable: True
        //PostalCode (string): Nullable: True
        //Country (string): Nullable: True
        //Phone (string): Nullable: True
        //Fax (string): Nullable: True

        //***********************************************
        //Table=employees
        //Columns=18
        //PK =EmployeeID
        
        //EmployeeID (int): Nullable: False
        //LastName (string): Nullable: False
        //FirstName (string): Nullable: False
        //Title (string): Nullable: True
        //TitleOfCourtesy (string): Nullable: True
        //BirthDate (DateTime): Nullable: True
        //HireDate (DateTime): Nullable: True
        //Address (string): Nullable: True
        //City (string): Nullable: True
        //Region (string): Nullable: True
        //PostalCode (string): Nullable: True
        //Country (string): Nullable: True
        //HomePhone (string): Nullable: True
        //Extension (string): Nullable: True
        //Photo (string): Nullable: True
        //Notes (string): Nullable: True
        //ReportsTo (int): Nullable: True
        //PhotoPath (string): Nullable: True

        //***********************************************
        //Table=employeeterritories
        //Columns=2
        //PK =EmployeeID
        
        //EmployeeID (int): Nullable: False
        //TerritoryID (string): Nullable: False

        //***********************************************
        //Table=invoices
        //Columns=26
        //PK =ShipName
        
        //ShipName (string): Nullable: True
        //ShipAddress (string): Nullable: True
        //ShipCity (string): Nullable: True
        //ShipRegion (string): Nullable: True
        //ShipPostalCode (string): Nullable: True
        //ShipCountry (string): Nullable: True
        //CustomerID (string): Nullable: True
        //CustomerName (string): Nullable: False
        //Address (string): Nullable: True
        //City (string): Nullable: True
        //Region (string): Nullable: True
        //PostalCode (string): Nullable: True
        //Country (string): Nullable: True
        //Salesperson (string): Nullable: False
        //OrderID (int): Nullable: False
        //OrderDate (DateTime): Nullable: True
        //RequiredDate (DateTime): Nullable: True
        //ShippedDate (DateTime): Nullable: True
        //ShipperName (string): Nullable: False
        //ProductID (int): Nullable: False
        //ProductName (string): Nullable: False
        //UnitPrice (decimal): Nullable: False
        //Quantity (short): Nullable: False
        //Discount (double): Nullable: False
        //ExtendedPrice (decimal): Nullable: True
        //Freight (decimal): Nullable: True

        //***********************************************
        //Table=order details extended
        //Columns=7
        //PK =OrderID
        
        //OrderID (int): Nullable: False
        //ProductID (int): Nullable: False
        //ProductName (string): Nullable: False
        //UnitPrice (decimal): Nullable: False
        //Quantity (short): Nullable: False
        //Discount (double): Nullable: False
        //ExtendedPrice (decimal): Nullable: True

        //***********************************************
        //Table=order details
        //Columns=5
        //PK =OrderID
        
        //OrderID (int): Nullable: False
        //ProductID (int): Nullable: False
        //UnitPrice (decimal): Nullable: False
        //Quantity (short): Nullable: False
        //Discount (double): Nullable: False

        //***********************************************
        //Table=order subtotals
        //Columns=2
        //PK =OrderID
        
        //OrderID (int): Nullable: False
        //Subtotal (decimal): Nullable: True

        //***********************************************
        //Table=orders qry
        //Columns=20
        //PK =OrderID
        
        //OrderID (int): Nullable: False
        //CustomerID (string): Nullable: True
        //EmployeeID (int): Nullable: True
        //OrderDate (DateTime): Nullable: True
        //RequiredDate (DateTime): Nullable: True
        //ShippedDate (DateTime): Nullable: True
        //ShipVia (int): Nullable: True
        //Freight (decimal): Nullable: True
        //ShipName (string): Nullable: True
        //ShipAddress (string): Nullable: True
        //ShipCity (string): Nullable: True
        //ShipRegion (string): Nullable: True
        //ShipPostalCode (string): Nullable: True
        //ShipCountry (string): Nullable: True
        //CompanyName (string): Nullable: False
        //Address (string): Nullable: True
        //City (string): Nullable: True
        //Region (string): Nullable: True
        //PostalCode (string): Nullable: True
        //Country (string): Nullable: True

        //***********************************************
        //Table=orders
        //Columns=14
        //PK =OrderID
        
        //OrderID (int): Nullable: False
        //CustomerID (string): Nullable: True
        //EmployeeID (int): Nullable: True
        //OrderDate (DateTime): Nullable: True
        //RequiredDate (DateTime): Nullable: True
        //ShippedDate (DateTime): Nullable: True
        //ShipVia (int): Nullable: True
        //Freight (decimal): Nullable: True
        //ShipName (string): Nullable: True
        //ShipAddress (string): Nullable: True
        //ShipCity (string): Nullable: True
        //ShipRegion (string): Nullable: True
        //ShipPostalCode (string): Nullable: True
        //ShipCountry (string): Nullable: True

        //***********************************************
        //Table=product sales for 1997
        //Columns=3
        //PK =CategoryName
        
        //CategoryName (string): Nullable: False
        //ProductName (string): Nullable: False
        //ProductSales (decimal): Nullable: True

        //***********************************************
        //Table=products above average price
        //Columns=2
        //PK =ProductName
        
        //ProductName (string): Nullable: False
        //UnitPrice (decimal): Nullable: True

        //***********************************************
        //Table=products by category
        //Columns=5
        //PK =CategoryName
        
        //CategoryName (string): Nullable: False
        //ProductName (string): Nullable: False
        //QuantityPerUnit (string): Nullable: True
        //UnitsInStock (short): Nullable: True
        //Discontinued (bool): Nullable: False

        //***********************************************
        //Table=products
        //Columns=12
        //PK =ProductID
        
        //ProductID (int): Nullable: False
        //ProductName (string): Nullable: False
        //SupplierID (int): Nullable: True
        //CategoryID (int): Nullable: True
        //QuantityPerUnit (string): Nullable: True
        //UnitPrice (decimal): Nullable: True
        //UnitsInStock (short): Nullable: True
        //UnitsOnOrder (short): Nullable: True
        //ReorderLevel (short): Nullable: True
        //Discontinued (bool): Nullable: False
        //IsDeleted (bool): Nullable: True
        //Thoughtful (long): Nullable: False

        //***********************************************
        //Table=quarterly orders
        //Columns=4
        //PK =CustomerID
        
        //CustomerID (string): Nullable: True
        //CompanyName (string): Nullable: True
        //City (string): Nullable: True
        //Country (string): Nullable: True

        //***********************************************
        //Table=region
        //Columns=2
        //PK =RegionID
        
        //RegionID (int): Nullable: False
        //RegionDescription (string): Nullable: False

        //***********************************************
        //Table=sales by category
        //Columns=4
        //PK =CategoryID
        
        //CategoryID (int): Nullable: False
        //CategoryName (string): Nullable: False
        //ProductName (string): Nullable: False
        //ProductSales (decimal): Nullable: True

        //***********************************************
        //Table=sales totals by amount
        //Columns=4
        //PK =SaleAmount
        
        //SaleAmount (decimal): Nullable: True
        //OrderID (int): Nullable: False
        //CompanyName (string): Nullable: False
        //ShippedDate (DateTime): Nullable: True

        //***********************************************
        //Table=shippers
        //Columns=3
        //PK =ShipperID
        
        //ShipperID (int): Nullable: False
        //CompanyName (string): Nullable: False
        //Phone (string): Nullable: True

        //***********************************************
        //Table=subsonictests
        //Columns=12
        //PK =Thinger
        
        //Thinger (int): Nullable: False
        //Name (string): Nullable: False
        //UserName (string): Nullable: False
        //CreatedOn (DateTime): Nullable: False
        //Price (decimal): Nullable: False
        //Discount (double): Nullable: False
        //Lat (decimal): Nullable: True
        //Long (decimal): Nullable: True
        //SomeFlag (bool): Nullable: False
        //SomeNullableFlag (bool): Nullable: True
        //LongText (string): Nullable: False
        //MediumText (string): Nullable: False

        //***********************************************
        //Table=summary of sales by quarter
        //Columns=3
        //PK =ShippedDate
        
        //ShippedDate (DateTime): Nullable: True
        //OrderID (int): Nullable: False
        //Subtotal (decimal): Nullable: True

        //***********************************************
        //Table=summary of sales by year
        //Columns=3
        //PK =ShippedDate
        
        //ShippedDate (DateTime): Nullable: True
        //OrderID (int): Nullable: False
        //Subtotal (decimal): Nullable: True

        //***********************************************
        //Table=suppliers
        //Columns=12
        //PK =SupplierID
        
        //SupplierID (int): Nullable: False
        //CompanyName (string): Nullable: False
        //ContactName (string): Nullable: True
        //ContactTitle (string): Nullable: True
        //Address (string): Nullable: True
        //City (string): Nullable: True
        //Region (string): Nullable: True
        //PostalCode (string): Nullable: True
        //Country (string): Nullable: True
        //Phone (string): Nullable: True
        //Fax (string): Nullable: True
        //HomePage (string): Nullable: True

        //***********************************************
        //Table=territories
        //Columns=3
        //PK =TerritoryID
        
        //TerritoryID (string): Nullable: False
        //TerritoryDescription (string): Nullable: False
        //RegionID (int): Nullable: False

