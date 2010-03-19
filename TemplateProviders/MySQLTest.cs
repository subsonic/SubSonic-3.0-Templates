


        //***********************************************
        //Table=alphabetical list of products
        //Columns=11
        //PK =ProductID
        //FKs = 0;
        
             
        //ProductID (int): Nullable: False
        //ProductName (string): Nullable: False
        //SupplierID (int): Nullable: True
        //CategoryID (int): Nullable: True
        //QuantityPerUnit (string): Nullable: True
        //UnitPrice (decimal): Nullable: True
        //UnitsInStock (short): Nullable: True
        //UnitsOnOrder (short): Nullable: True
        //ReorderLevel (short): Nullable: True
        //Discontinued (sbyte): Nullable: False
        //CategoryName (string): Nullable: False

        //FKs



        //***********************************************
        //Table=categories
        //Columns=4
        //PK =CategoryID
        //FKs = 1;
        
             
        //CategoryID (int): Nullable: False
        //CategoryName (string): Nullable: False
        //Description (string): Nullable: True
        //Picture (byte[]): Nullable: True

        //FKs
        //categories --> products



        //***********************************************
        //Table=category sales for 1997
        //Columns=2
        //PK =CategoryName
        //FKs = 0;
        
             
        //CategoryName (string): Nullable: False
        //CategorySales (decimal): Nullable: True

        //FKs



        //***********************************************
        //Table=current product list
        //Columns=2
        //PK =ProductID
        //FKs = 0;
        
             
        //ProductID (int): Nullable: False
        //ProductName (string): Nullable: False

        //FKs



        //***********************************************
        //Table=customer and suppliers by city
        //Columns=4
        //PK =City
        //FKs = 0;
        
             
        //City (string): Nullable: True
        //CompanyName (string): Nullable: False
        //ContactName (string): Nullable: True
        //Relationship (string): Nullable: False

        //FKs



        //***********************************************
        //Table=customercustomerdemo
        //Columns=2
        //PK =CustomerID
        //FKs = 2;
        
             
        //CustomerID (string): Nullable: False
        //CustomerTypeID (string): Nullable: False

        //FKs
        //customercustomerdemo --> customers
        //customercustomerdemo --> customerdemographics



        //***********************************************
        //Table=customerdemographics
        //Columns=2
        //PK =CustomerTypeID
        //FKs = 1;
        
             
        //CustomerTypeID (string): Nullable: False
        //CustomerDesc (string): Nullable: True

        //FKs
        //customerdemographics --> customercustomerdemo



        //***********************************************
        //Table=customers
        //Columns=11
        //PK =CustomerID
        //FKs = 2;
        
             
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

        //FKs
        //customers --> customercustomerdemo
        //customers --> orders



        //***********************************************
        //Table=employees
        //Columns=18
        //PK =EmployeeID
        //FKs = 3;
        
             
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
        //Photo (byte[]): Nullable: True
        //Notes (string): Nullable: True
        //ReportsTo (int): Nullable: True
        //PhotoPath (string): Nullable: True

        //FKs
        //employees --> employees
        //employees --> employeeterritories
        //employees --> orders



        //***********************************************
        //Table=employeeterritories
        //Columns=2
        //PK =EmployeeID
        //FKs = 2;
        
             
        //EmployeeID (int): Nullable: False
        //TerritoryID (string): Nullable: False

        //FKs
        //employeeterritories --> employees
        //employeeterritories --> territories



        //***********************************************
        //Table=invoices
        //Columns=26
        //PK =ShipName
        //FKs = 0;
        
             
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
        //OrderDate (DateTime): Nullable: False
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

        //FKs



        //***********************************************
        //Table=order details
        //Columns=5
        //PK =OrderID
        //FKs = 2;
        
             
        //OrderID (int): Nullable: False
        //ProductID (int): Nullable: False
        //UnitPrice (decimal): Nullable: False
        //Quantity (short): Nullable: False
        //Discount (double): Nullable: False

        //FKs
        //order details --> orders
        //order details --> products



        //***********************************************
        //Table=order details extended
        //Columns=7
        //PK =OrderID
        //FKs = 0;
        
             
        //OrderID (int): Nullable: False
        //ProductID (int): Nullable: False
        //ProductName (string): Nullable: False
        //UnitPrice (decimal): Nullable: False
        //Quantity (short): Nullable: False
        //Discount (double): Nullable: False
        //ExtendedPrice (decimal): Nullable: True

        //FKs



        //***********************************************
        //Table=order subtotals
        //Columns=2
        //PK =OrderID
        //FKs = 0;
        
             
        //OrderID (int): Nullable: False
        //Subtotal (decimal): Nullable: True

        //FKs



        //***********************************************
        //Table=orders
        //Columns=14
        //PK =OrderID
        //FKs = 4;
        
             
        //OrderID (int): Nullable: False
        //CustomerID (string): Nullable: True
        //EmployeeID (int): Nullable: True
        //OrderDate (DateTime): Nullable: False
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

        //FKs
        //orders --> order details
        //orders --> customers
        //orders --> employees
        //orders --> shippers



        //***********************************************
        //Table=orders qry
        //Columns=20
        //PK =OrderID
        //FKs = 0;
        
             
        //OrderID (int): Nullable: False
        //CustomerID (string): Nullable: True
        //EmployeeID (int): Nullable: True
        //OrderDate (DateTime): Nullable: False
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

        //FKs



        //***********************************************
        //Table=product sales for 1997
        //Columns=3
        //PK =CategoryName
        //FKs = 0;
        
             
        //CategoryName (string): Nullable: False
        //ProductName (string): Nullable: False
        //ProductSales (decimal): Nullable: True

        //FKs



        //***********************************************
        //Table=products
        //Columns=10
        //PK =ProductID
        //FKs = 3;
        
             
        //ProductID (int): Nullable: False
        //ProductName (string): Nullable: False
        //SupplierID (int): Nullable: True
        //CategoryID (int): Nullable: True
        //QuantityPerUnit (string): Nullable: True
        //UnitPrice (decimal): Nullable: True
        //UnitsInStock (short): Nullable: True
        //UnitsOnOrder (short): Nullable: True
        //ReorderLevel (short): Nullable: True
        //Discontinued (sbyte): Nullable: False

        //FKs
        //products --> order details
        //products --> categories
        //products --> suppliers



        //***********************************************
        //Table=products above average price
        //Columns=2
        //PK =ProductName
        //FKs = 0;
        
             
        //ProductName (string): Nullable: False
        //UnitPrice (decimal): Nullable: True

        //FKs



        //***********************************************
        //Table=products by category
        //Columns=5
        //PK =CategoryName
        //FKs = 0;
        
             
        //CategoryName (string): Nullable: False
        //ProductName (string): Nullable: False
        //QuantityPerUnit (string): Nullable: True
        //UnitsInStock (short): Nullable: True
        //Discontinued (sbyte): Nullable: False

        //FKs



        //***********************************************
        //Table=quarterly orders
        //Columns=4
        //PK =CustomerID
        //FKs = 0;
        
             
        //CustomerID (string): Nullable: True
        //CompanyName (string): Nullable: True
        //City (string): Nullable: True
        //Country (string): Nullable: True

        //FKs



        //***********************************************
        //Table=region
        //Columns=2
        //PK =RegionID
        //FKs = 1;
        
             
        //RegionID (int): Nullable: False
        //RegionDescription (string): Nullable: False

        //FKs
        //region --> territories



        //***********************************************
        //Table=sales by category
        //Columns=4
        //PK =CategoryID
        //FKs = 0;
        
             
        //CategoryID (int): Nullable: False
        //CategoryName (string): Nullable: False
        //ProductName (string): Nullable: False
        //ProductSales (decimal): Nullable: True

        //FKs



        //***********************************************
        //Table=sales totals by amount
        //Columns=4
        //PK =SaleAmount
        //FKs = 0;
        
             
        //SaleAmount (decimal): Nullable: True
        //OrderID (int): Nullable: False
        //CompanyName (string): Nullable: False
        //ShippedDate (DateTime): Nullable: True

        //FKs



        //***********************************************
        //Table=shippers
        //Columns=3
        //PK =ShipperID
        //FKs = 1;
        
             
        //ShipperID (int): Nullable: False
        //CompanyName (string): Nullable: False
        //Phone (string): Nullable: True

        //FKs
        //shippers --> orders



        //***********************************************
        //Table=summary of sales by quarter
        //Columns=3
        //PK =ShippedDate
        //FKs = 0;
        
             
        //ShippedDate (DateTime): Nullable: True
        //OrderID (int): Nullable: False
        //Subtotal (decimal): Nullable: True

        //FKs



        //***********************************************
        //Table=summary of sales by year
        //Columns=3
        //PK =ShippedDate
        //FKs = 0;
        
             
        //ShippedDate (DateTime): Nullable: True
        //OrderID (int): Nullable: False
        //Subtotal (decimal): Nullable: True

        //FKs



        //***********************************************
        //Table=suppliers
        //Columns=12
        //PK =SupplierID
        //FKs = 1;
        
             
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

        //FKs
        //suppliers --> products



        //***********************************************
        //Table=territories
        //Columns=3
        //PK =TerritoryID
        //FKs = 2;
        
             
        //TerritoryID (string): Nullable: False
        //TerritoryDescription (string): Nullable: False
        //RegionID (int): Nullable: False

        //FKs
        //territories --> employeeterritories
        //territories --> region



