


Imports System
Imports SubSonic.Schema
Imports System.Collections.Generic
Imports SubSonic.DataProviders
Imports System.Data

NameSpace Southwind

		''' <summary>
		''' Table: Categories
		''' Primary Key: CategoryID
		''' </summary>

	Public Class CategoriesTable
		Inherits DatabaseTable

		Public Sub New(provider As IDataProvider)
			MyBase.New("Categories",provider)
			ClassName = "Category"
			SchemaName = "dbo"
                
				Columns.Add(New DatabaseColumn("CategoryID", Me) With { _
					.IsPrimaryKey = true, _
					.DataType = DbType.Int32, _
					.IsNullable = false, _
					.AutoIncrement = true, _
					.IsForeignKey = true _
				})

				Columns.Add(New DatabaseColumn("CategoryName", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = false, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("Description", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("Picture", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.Binary, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

                    
       End Sub
            
		Public ReadOnly Property [CategoryID] As IColumn
			Get
				Return Me.GetColumn("CategoryID")
			End Get
		End Property
            
		Public ReadOnly Property [CategoryName] As IColumn
			Get
				Return Me.GetColumn("CategoryName")
			End Get
		End Property
            
		Public ReadOnly Property [Description] As IColumn
			Get
				Return Me.GetColumn("Description")
			End Get
		End Property
            
		Public ReadOnly Property [Picture] As IColumn
			Get
				Return Me.GetColumn("Picture")
			End Get
		End Property
            
                    
	End Class        
		''' <summary>
		''' Table: Customers
		''' Primary Key: CustomerID
		''' </summary>

	Public Class CustomersTable
		Inherits DatabaseTable

		Public Sub New(provider As IDataProvider)
			MyBase.New("Customers",provider)
			ClassName = "Customer"
			SchemaName = "dbo"
                
				Columns.Add(New DatabaseColumn("CustomerID", Me) With { _
					.IsPrimaryKey = true, _
					.DataType = DbType.String, _
					.IsNullable = false, _
					.AutoIncrement = false, _
					.IsForeignKey = true _
				})

				Columns.Add(New DatabaseColumn("CompanyName", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = false, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("ContactName", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("ContactTitle", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("Address", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("City", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("Region", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("PostalCode", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("Country", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("Phone", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("Fax", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

                    
       End Sub
            
		Public ReadOnly Property [CustomerID] As IColumn
			Get
				Return Me.GetColumn("CustomerID")
			End Get
		End Property
            
		Public ReadOnly Property [CompanyName] As IColumn
			Get
				Return Me.GetColumn("CompanyName")
			End Get
		End Property
            
		Public ReadOnly Property [ContactName] As IColumn
			Get
				Return Me.GetColumn("ContactName")
			End Get
		End Property
            
		Public ReadOnly Property [ContactTitle] As IColumn
			Get
				Return Me.GetColumn("ContactTitle")
			End Get
		End Property
            
		Public ReadOnly Property [Address] As IColumn
			Get
				Return Me.GetColumn("Address")
			End Get
		End Property
            
		Public ReadOnly Property [City] As IColumn
			Get
				Return Me.GetColumn("City")
			End Get
		End Property
            
		Public ReadOnly Property [Region] As IColumn
			Get
				Return Me.GetColumn("Region")
			End Get
		End Property
            
		Public ReadOnly Property [PostalCode] As IColumn
			Get
				Return Me.GetColumn("PostalCode")
			End Get
		End Property
            
		Public ReadOnly Property [Country] As IColumn
			Get
				Return Me.GetColumn("Country")
			End Get
		End Property
            
		Public ReadOnly Property [Phone] As IColumn
			Get
				Return Me.GetColumn("Phone")
			End Get
		End Property
            
		Public ReadOnly Property [Fax] As IColumn
			Get
				Return Me.GetColumn("Fax")
			End Get
		End Property
            
                    
	End Class        
		''' <summary>
		''' Table: Shippers
		''' Primary Key: ShipperID
		''' </summary>

	Public Class ShippersTable
		Inherits DatabaseTable

		Public Sub New(provider As IDataProvider)
			MyBase.New("Shippers",provider)
			ClassName = "Shipper"
			SchemaName = "dbo"
                
				Columns.Add(New DatabaseColumn("ShipperID", Me) With { _
					.IsPrimaryKey = true, _
					.DataType = DbType.Int32, _
					.IsNullable = false, _
					.AutoIncrement = true, _
					.IsForeignKey = true _
				})

				Columns.Add(New DatabaseColumn("CompanyName", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = false, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("Phone", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

                    
       End Sub
            
		Public ReadOnly Property [ShipperID] As IColumn
			Get
				Return Me.GetColumn("ShipperID")
			End Get
		End Property
            
		Public ReadOnly Property [CompanyName] As IColumn
			Get
				Return Me.GetColumn("CompanyName")
			End Get
		End Property
            
		Public ReadOnly Property [Phone] As IColumn
			Get
				Return Me.GetColumn("Phone")
			End Get
		End Property
            
                    
	End Class        
		''' <summary>
		''' Table: Suppliers
		''' Primary Key: SupplierID
		''' </summary>

	Public Class SuppliersTable
		Inherits DatabaseTable

		Public Sub New(provider As IDataProvider)
			MyBase.New("Suppliers",provider)
			ClassName = "Supplier"
			SchemaName = "dbo"
                
				Columns.Add(New DatabaseColumn("SupplierID", Me) With { _
					.IsPrimaryKey = true, _
					.DataType = DbType.Int32, _
					.IsNullable = false, _
					.AutoIncrement = true, _
					.IsForeignKey = true _
				})

				Columns.Add(New DatabaseColumn("CompanyName", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = false, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("ContactName", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("ContactTitle", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("Address", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("City", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("Region", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("PostalCode", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("Country", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("Phone", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("Fax", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("HomePage", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

                    
       End Sub
            
		Public ReadOnly Property [SupplierID] As IColumn
			Get
				Return Me.GetColumn("SupplierID")
			End Get
		End Property
            
		Public ReadOnly Property [CompanyName] As IColumn
			Get
				Return Me.GetColumn("CompanyName")
			End Get
		End Property
            
		Public ReadOnly Property [ContactName] As IColumn
			Get
				Return Me.GetColumn("ContactName")
			End Get
		End Property
            
		Public ReadOnly Property [ContactTitle] As IColumn
			Get
				Return Me.GetColumn("ContactTitle")
			End Get
		End Property
            
		Public ReadOnly Property [Address] As IColumn
			Get
				Return Me.GetColumn("Address")
			End Get
		End Property
            
		Public ReadOnly Property [City] As IColumn
			Get
				Return Me.GetColumn("City")
			End Get
		End Property
            
		Public ReadOnly Property [Region] As IColumn
			Get
				Return Me.GetColumn("Region")
			End Get
		End Property
            
		Public ReadOnly Property [PostalCode] As IColumn
			Get
				Return Me.GetColumn("PostalCode")
			End Get
		End Property
            
		Public ReadOnly Property [Country] As IColumn
			Get
				Return Me.GetColumn("Country")
			End Get
		End Property
            
		Public ReadOnly Property [Phone] As IColumn
			Get
				Return Me.GetColumn("Phone")
			End Get
		End Property
            
		Public ReadOnly Property [Fax] As IColumn
			Get
				Return Me.GetColumn("Fax")
			End Get
		End Property
            
		Public ReadOnly Property [HomePage] As IColumn
			Get
				Return Me.GetColumn("HomePage")
			End Get
		End Property
            
                    
	End Class        
		''' <summary>
		''' Table: Orders
		''' Primary Key: OrderID
		''' </summary>

	Public Class OrdersTable
		Inherits DatabaseTable

		Public Sub New(provider As IDataProvider)
			MyBase.New("Orders",provider)
			ClassName = "Order"
			SchemaName = "dbo"
                
				Columns.Add(New DatabaseColumn("OrderID", Me) With { _
					.IsPrimaryKey = true, _
					.DataType = DbType.Int32, _
					.IsNullable = false, _
					.AutoIncrement = true, _
					.IsForeignKey = true _
				})

				Columns.Add(New DatabaseColumn("CustomerID", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = true _
				})

				Columns.Add(New DatabaseColumn("EmployeeID", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.Int32, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = true _
				})

				Columns.Add(New DatabaseColumn("OrderDate", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.DateTime, _
					.IsNullable = false, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("RequiredDate", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.DateTime, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("ShippedDate", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.DateTime, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("ShipVia", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.Int32, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = true _
				})

				Columns.Add(New DatabaseColumn("Freight", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.Currency, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("ShipName", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("ShipAddress", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("ShipCity", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("ShipRegion", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("ShipPostalCode", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("ShipCountry", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

                    
       End Sub
            
		Public ReadOnly Property [OrderID] As IColumn
			Get
				Return Me.GetColumn("OrderID")
			End Get
		End Property
            
		Public ReadOnly Property [CustomerID] As IColumn
			Get
				Return Me.GetColumn("CustomerID")
			End Get
		End Property
            
		Public ReadOnly Property [EmployeeID] As IColumn
			Get
				Return Me.GetColumn("EmployeeID")
			End Get
		End Property
            
		Public ReadOnly Property [OrderDate] As IColumn
			Get
				Return Me.GetColumn("OrderDate")
			End Get
		End Property
            
		Public ReadOnly Property [RequiredDate] As IColumn
			Get
				Return Me.GetColumn("RequiredDate")
			End Get
		End Property
            
		Public ReadOnly Property [ShippedDate] As IColumn
			Get
				Return Me.GetColumn("ShippedDate")
			End Get
		End Property
            
		Public ReadOnly Property [ShipVia] As IColumn
			Get
				Return Me.GetColumn("ShipVia")
			End Get
		End Property
            
		Public ReadOnly Property [Freight] As IColumn
			Get
				Return Me.GetColumn("Freight")
			End Get
		End Property
            
		Public ReadOnly Property [ShipName] As IColumn
			Get
				Return Me.GetColumn("ShipName")
			End Get
		End Property
            
		Public ReadOnly Property [ShipAddress] As IColumn
			Get
				Return Me.GetColumn("ShipAddress")
			End Get
		End Property
            
		Public ReadOnly Property [ShipCity] As IColumn
			Get
				Return Me.GetColumn("ShipCity")
			End Get
		End Property
            
		Public ReadOnly Property [ShipRegion] As IColumn
			Get
				Return Me.GetColumn("ShipRegion")
			End Get
		End Property
            
		Public ReadOnly Property [ShipPostalCode] As IColumn
			Get
				Return Me.GetColumn("ShipPostalCode")
			End Get
		End Property
            
		Public ReadOnly Property [ShipCountry] As IColumn
			Get
				Return Me.GetColumn("ShipCountry")
			End Get
		End Property
            
                    
	End Class        
		''' <summary>
		''' Table: Products
		''' Primary Key: ProductID
		''' </summary>

	Public Class ProductsTable
		Inherits DatabaseTable

		Public Sub New(provider As IDataProvider)
			MyBase.New("Products",provider)
			ClassName = "Product"
			SchemaName = "dbo"
                
				Columns.Add(New DatabaseColumn("ProductID", Me) With { _
					.IsPrimaryKey = true, _
					.DataType = DbType.Int32, _
					.IsNullable = false, _
					.AutoIncrement = true, _
					.IsForeignKey = true _
				})

				Columns.Add(New DatabaseColumn("ProductName", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = false, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("SupplierID", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.Int32, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = true _
				})

				Columns.Add(New DatabaseColumn("CategoryID", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.Int32, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = true _
				})

				Columns.Add(New DatabaseColumn("QuantityPerUnit", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("UnitPrice", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.Currency, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("UnitsInStock", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.Int16, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("UnitsOnOrder", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.Int16, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("ReorderLevel", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.Int16, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("Discontinued", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.Boolean, _
					.IsNullable = false, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

                    
       End Sub
            
		Public ReadOnly Property [ProductID] As IColumn
			Get
				Return Me.GetColumn("ProductID")
			End Get
		End Property
            
		Public ReadOnly Property [ProductName] As IColumn
			Get
				Return Me.GetColumn("ProductName")
			End Get
		End Property
            
		Public ReadOnly Property [SupplierID] As IColumn
			Get
				Return Me.GetColumn("SupplierID")
			End Get
		End Property
            
		Public ReadOnly Property [CategoryID] As IColumn
			Get
				Return Me.GetColumn("CategoryID")
			End Get
		End Property
            
		Public ReadOnly Property [QuantityPerUnit] As IColumn
			Get
				Return Me.GetColumn("QuantityPerUnit")
			End Get
		End Property
            
		Public ReadOnly Property [UnitPrice] As IColumn
			Get
				Return Me.GetColumn("UnitPrice")
			End Get
		End Property
            
		Public ReadOnly Property [UnitsInStock] As IColumn
			Get
				Return Me.GetColumn("UnitsInStock")
			End Get
		End Property
            
		Public ReadOnly Property [UnitsOnOrder] As IColumn
			Get
				Return Me.GetColumn("UnitsOnOrder")
			End Get
		End Property
            
		Public ReadOnly Property [ReorderLevel] As IColumn
			Get
				Return Me.GetColumn("ReorderLevel")
			End Get
		End Property
            
		Public ReadOnly Property [Discontinued] As IColumn
			Get
				Return Me.GetColumn("Discontinued")
			End Get
		End Property
            
                    
	End Class        
		''' <summary>
		''' Table: Order Details
		''' Primary Key: OrderID
		''' </summary>

	Public Class OrderDetailsTable
		Inherits DatabaseTable

		Public Sub New(provider As IDataProvider)
			MyBase.New("Order Details",provider)
			ClassName = "OrderDetail"
			SchemaName = "dbo"
                
				Columns.Add(New DatabaseColumn("OrderID", Me) With { _
					.IsPrimaryKey = true, _
					.DataType = DbType.Int32, _
					.IsNullable = false, _
					.AutoIncrement = false, _
					.IsForeignKey = true _
				})

				Columns.Add(New DatabaseColumn("ProductID", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.Int32, _
					.IsNullable = false, _
					.AutoIncrement = false, _
					.IsForeignKey = true _
				})

				Columns.Add(New DatabaseColumn("UnitPrice", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.Currency, _
					.IsNullable = false, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("Quantity", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.Int16, _
					.IsNullable = false, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("Discount", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.Single, _
					.IsNullable = false, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

                    
       End Sub
            
		Public ReadOnly Property [OrderID] As IColumn
			Get
				Return Me.GetColumn("OrderID")
			End Get
		End Property
            
		Public ReadOnly Property [ProductID] As IColumn
			Get
				Return Me.GetColumn("ProductID")
			End Get
		End Property
            
		Public ReadOnly Property [UnitPrice] As IColumn
			Get
				Return Me.GetColumn("UnitPrice")
			End Get
		End Property
            
		Public ReadOnly Property [Quantity] As IColumn
			Get
				Return Me.GetColumn("Quantity")
			End Get
		End Property
            
		Public ReadOnly Property [Discount] As IColumn
			Get
				Return Me.GetColumn("Discount")
			End Get
		End Property
            
                    
	End Class        
		''' <summary>
		''' Table: CustomerCustomerDemo
		''' Primary Key: CustomerID
		''' </summary>

	Public Class CustomerCustomerDemoTable
		Inherits DatabaseTable

		Public Sub New(provider As IDataProvider)
			MyBase.New("CustomerCustomerDemo",provider)
			ClassName = "CustomerCustomerDemo"
			SchemaName = "dbo"
                
				Columns.Add(New DatabaseColumn("CustomerID", Me) With { _
					.IsPrimaryKey = true, _
					.DataType = DbType.String, _
					.IsNullable = false, _
					.AutoIncrement = false, _
					.IsForeignKey = true _
				})

				Columns.Add(New DatabaseColumn("CustomerTypeID", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = false, _
					.AutoIncrement = false, _
					.IsForeignKey = true _
				})

                    
       End Sub
            
		Public ReadOnly Property [CustomerID] As IColumn
			Get
				Return Me.GetColumn("CustomerID")
			End Get
		End Property
            
		Public ReadOnly Property [CustomerTypeID] As IColumn
			Get
				Return Me.GetColumn("CustomerTypeID")
			End Get
		End Property
            
                    
	End Class        
		''' <summary>
		''' Table: CustomerDemographics
		''' Primary Key: CustomerTypeID
		''' </summary>

	Public Class CustomerDemographicsTable
		Inherits DatabaseTable

		Public Sub New(provider As IDataProvider)
			MyBase.New("CustomerDemographics",provider)
			ClassName = "CustomerDemographic"
			SchemaName = "dbo"
                
				Columns.Add(New DatabaseColumn("CustomerTypeID", Me) With { _
					.IsPrimaryKey = true, _
					.DataType = DbType.String, _
					.IsNullable = false, _
					.AutoIncrement = false, _
					.IsForeignKey = true _
				})

				Columns.Add(New DatabaseColumn("CustomerDesc", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

                    
       End Sub
            
		Public ReadOnly Property [CustomerTypeID] As IColumn
			Get
				Return Me.GetColumn("CustomerTypeID")
			End Get
		End Property
            
		Public ReadOnly Property [CustomerDesc] As IColumn
			Get
				Return Me.GetColumn("CustomerDesc")
			End Get
		End Property
            
                    
	End Class        
		''' <summary>
		''' Table: Region
		''' Primary Key: RegionID
		''' </summary>

	Public Class RegionTable
		Inherits DatabaseTable

		Public Sub New(provider As IDataProvider)
			MyBase.New("Region",provider)
			ClassName = "Region"
			SchemaName = "dbo"
                
				Columns.Add(New DatabaseColumn("RegionID", Me) With { _
					.IsPrimaryKey = true, _
					.DataType = DbType.Int32, _
					.IsNullable = false, _
					.AutoIncrement = false, _
					.IsForeignKey = true _
				})

				Columns.Add(New DatabaseColumn("RegionDescription", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = false, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

                    
       End Sub
            
		Public ReadOnly Property [RegionID] As IColumn
			Get
				Return Me.GetColumn("RegionID")
			End Get
		End Property
            
		Public ReadOnly Property [RegionDescription] As IColumn
			Get
				Return Me.GetColumn("RegionDescription")
			End Get
		End Property
            
                    
	End Class        
		''' <summary>
		''' Table: Territories
		''' Primary Key: TerritoryID
		''' </summary>

	Public Class TerritoriesTable
		Inherits DatabaseTable

		Public Sub New(provider As IDataProvider)
			MyBase.New("Territories",provider)
			ClassName = "Territory"
			SchemaName = "dbo"
                
				Columns.Add(New DatabaseColumn("TerritoryID", Me) With { _
					.IsPrimaryKey = true, _
					.DataType = DbType.String, _
					.IsNullable = false, _
					.AutoIncrement = false, _
					.IsForeignKey = true _
				})

				Columns.Add(New DatabaseColumn("TerritoryDescription", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = false, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("RegionID", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.Int32, _
					.IsNullable = false, _
					.AutoIncrement = false, _
					.IsForeignKey = true _
				})

                    
       End Sub
            
		Public ReadOnly Property [TerritoryID] As IColumn
			Get
				Return Me.GetColumn("TerritoryID")
			End Get
		End Property
            
		Public ReadOnly Property [TerritoryDescription] As IColumn
			Get
				Return Me.GetColumn("TerritoryDescription")
			End Get
		End Property
            
		Public ReadOnly Property [RegionID] As IColumn
			Get
				Return Me.GetColumn("RegionID")
			End Get
		End Property
            
                    
	End Class        
		''' <summary>
		''' Table: EmployeeTerritories
		''' Primary Key: EmployeeID
		''' </summary>

	Public Class EmployeeTerritoriesTable
		Inherits DatabaseTable

		Public Sub New(provider As IDataProvider)
			MyBase.New("EmployeeTerritories",provider)
			ClassName = "EmployeeTerritory"
			SchemaName = "dbo"
                
				Columns.Add(New DatabaseColumn("EmployeeID", Me) With { _
					.IsPrimaryKey = true, _
					.DataType = DbType.Int32, _
					.IsNullable = false, _
					.AutoIncrement = false, _
					.IsForeignKey = true _
				})

				Columns.Add(New DatabaseColumn("TerritoryID", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = false, _
					.AutoIncrement = false, _
					.IsForeignKey = true _
				})

                    
       End Sub
            
		Public ReadOnly Property [EmployeeID] As IColumn
			Get
				Return Me.GetColumn("EmployeeID")
			End Get
		End Property
            
		Public ReadOnly Property [TerritoryID] As IColumn
			Get
				Return Me.GetColumn("TerritoryID")
			End Get
		End Property
            
                    
	End Class        
		''' <summary>
		''' Table: Employees
		''' Primary Key: EmployeeID
		''' </summary>

	Public Class EmployeesTable
		Inherits DatabaseTable

		Public Sub New(provider As IDataProvider)
			MyBase.New("Employees",provider)
			ClassName = "Employee"
			SchemaName = "dbo"
                
				Columns.Add(New DatabaseColumn("EmployeeID", Me) With { _
					.IsPrimaryKey = true, _
					.DataType = DbType.Int32, _
					.IsNullable = false, _
					.AutoIncrement = true, _
					.IsForeignKey = true _
				})

				Columns.Add(New DatabaseColumn("LastName", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = false, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("FirstName", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = false, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("Title", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("TitleOfCourtesy", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("BirthDate", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.DateTime, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("HireDate", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.DateTime, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("Address", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("City", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("Region", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("PostalCode", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("Country", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("HomePhone", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("Extension", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("Photo", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.Binary, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("Notes", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

				Columns.Add(New DatabaseColumn("ReportsTo", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.Int32, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = true _
				})

				Columns.Add(New DatabaseColumn("PhotoPath", Me) With { _
					.IsPrimaryKey = false, _
					.DataType = DbType.String, _
					.IsNullable = true, _
					.AutoIncrement = false, _
					.IsForeignKey = false _
				})

                    
       End Sub
            
		Public ReadOnly Property [EmployeeID] As IColumn
			Get
				Return Me.GetColumn("EmployeeID")
			End Get
		End Property
            
		Public ReadOnly Property [LastName] As IColumn
			Get
				Return Me.GetColumn("LastName")
			End Get
		End Property
            
		Public ReadOnly Property [FirstName] As IColumn
			Get
				Return Me.GetColumn("FirstName")
			End Get
		End Property
            
		Public ReadOnly Property [Title] As IColumn
			Get
				Return Me.GetColumn("Title")
			End Get
		End Property
            
		Public ReadOnly Property [TitleOfCourtesy] As IColumn
			Get
				Return Me.GetColumn("TitleOfCourtesy")
			End Get
		End Property
            
		Public ReadOnly Property [BirthDate] As IColumn
			Get
				Return Me.GetColumn("BirthDate")
			End Get
		End Property
            
		Public ReadOnly Property [HireDate] As IColumn
			Get
				Return Me.GetColumn("HireDate")
			End Get
		End Property
            
		Public ReadOnly Property [Address] As IColumn
			Get
				Return Me.GetColumn("Address")
			End Get
		End Property
            
		Public ReadOnly Property [City] As IColumn
			Get
				Return Me.GetColumn("City")
			End Get
		End Property
            
		Public ReadOnly Property [Region] As IColumn
			Get
				Return Me.GetColumn("Region")
			End Get
		End Property
            
		Public ReadOnly Property [PostalCode] As IColumn
			Get
				Return Me.GetColumn("PostalCode")
			End Get
		End Property
            
		Public ReadOnly Property [Country] As IColumn
			Get
				Return Me.GetColumn("Country")
			End Get
		End Property
            
		Public ReadOnly Property [HomePhone] As IColumn
			Get
				Return Me.GetColumn("HomePhone")
			End Get
		End Property
            
		Public ReadOnly Property [Extension] As IColumn
			Get
				Return Me.GetColumn("Extension")
			End Get
		End Property
            
		Public ReadOnly Property [Photo] As IColumn
			Get
				Return Me.GetColumn("Photo")
			End Get
		End Property
            
		Public ReadOnly Property [Notes] As IColumn
			Get
				Return Me.GetColumn("Notes")
			End Get
		End Property
            
		Public ReadOnly Property [ReportsTo] As IColumn
			Get
				Return Me.GetColumn("ReportsTo")
			End Get
		End Property
            
		Public ReadOnly Property [PhotoPath] As IColumn
			Get
				Return Me.GetColumn("PhotoPath")
			End Get
		End Property
            
                    
	End Class        
End NameSpace
