


Imports System
Imports System.Data
Imports System.Linq
Imports System.Linq.Expressions
Imports SubSonic.DataProviders
Imports SubSonic.Extensions
Imports SubSonic.Linq.Structure
Imports SubSonic.Query
Imports SubSonic.Schema
Imports System.Data.Common
Imports System.Collections.Generic

NameSpace Southwind

    Public Partial Class NorthwindDB 
		Implements IQuerySurface

        Private _dataProvider As IDataProvider
        Private _provider As DbQueryProvider
        
        Public ReadOnly Property TestMode As Boolean
            Get
               	Return _dataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase)
			End Get
        End Property

        Public Sub New() 
            _dataProvider = ProviderFactory.GetProvider("Northwind")
            Init()
        End Sub

        Public Sub New(connectionStringName As String)
            _dataProvider = ProviderFactory.GetProvider(connectionStringName)
            Init()
        End Sub

		Public Sub New(connectionString As String, providerName As String)
            _dataProvider = ProviderFactory.GetProvider(connectionString,providerName)
            Init()
        End Sub

		Public Function FindByPrimaryKey(pkName As String) As ITable
            Return _dataProvider.Schema.Tables.SingleOrDefault(Function(x) x.PrimaryKey.Name.Equals(pkName, StringComparison.InvariantCultureIgnoreCase))
        End Function

        Public Function GetQuery(Of T)() As Query(Of T) Implements IQuerySurface.GetQuery
            Return New Query(Of T)(provider)
        End Function
        
        Public Function FindTable(tableName As String) As ITable Implements IQuerySurface.FindTable
            Return _dataProvider.FindTable(tableName)
        End Function
               
        Public ReadOnly Property Provider As IDataProvider Implements IQuerySurface.Provider
            Get 
				Return _dataProvider
			End Get
		End Property
        
        Public ReadOnly Property QueryProvider As DbQueryProvider
            Get 
				Return _provider
			End Get
		End Property
		
        Private _batch As BatchQuery = Nothing
		
        Public Sub Queue(Of T)(qry As IQueryable(Of T))
            If _batch Is Nothing Then _batch = New BatchQuery(Provider, QueryProvider)
            _batch.Queue(qry)
        End Sub

        Public Sub Queue(qry As ISqlQuery)
            If _batch Is Nothing Then _batch = new BatchQuery(Provider, QueryProvider)
            _batch.Queue(qry)
        End Sub

        Public Sub ExecuteTransaction(commands As IList(Of DbCommand))
            If Not TestMode Then
                Using connection = commands(0).Connection
                   If connection.State = ConnectionState.Closed Then connection.Open()
                   
                   Using trans = connection.BeginTransaction() 
                        For Each cmd in commands 
                            cmd.Transaction = trans
                            cmd.Connection = connection
                            cmd.ExecuteNonQuery()
                        Next cmd
                        trans.Commit()
                    End Using
                    connection.Close()
                End Using
            End If
        End Sub

        Public Function ExecuteBatch() As IDataReader
            If _batch Is Nothing Then Throw New InvalidOperationException("There's nothing in the queue")
            If Not TestMode Then Return _batch.ExecuteReader()
            Return Nothing
        End Function
			
		Private _Categories As Query(Of Category)
        Public Property Categories As Query(Of Category)
			Get
				Return _Categories
			End Get
			Set(value As Query(Of Category))
				_Categories = value
			End Set
		End Property
		Private _Customers As Query(Of Customer)
        Public Property Customers As Query(Of Customer)
			Get
				Return _Customers
			End Get
			Set(value As Query(Of Customer))
				_Customers = value
			End Set
		End Property
		Private _Shippers As Query(Of Shipper)
        Public Property Shippers As Query(Of Shipper)
			Get
				Return _Shippers
			End Get
			Set(value As Query(Of Shipper))
				_Shippers = value
			End Set
		End Property
		Private _Suppliers As Query(Of Supplier)
        Public Property Suppliers As Query(Of Supplier)
			Get
				Return _Suppliers
			End Get
			Set(value As Query(Of Supplier))
				_Suppliers = value
			End Set
		End Property
		Private _Orders As Query(Of Order)
        Public Property Orders As Query(Of Order)
			Get
				Return _Orders
			End Get
			Set(value As Query(Of Order))
				_Orders = value
			End Set
		End Property
		Private _Products As Query(Of Product)
        Public Property Products As Query(Of Product)
			Get
				Return _Products
			End Get
			Set(value As Query(Of Product))
				_Products = value
			End Set
		End Property
		Private _OrderDetails As Query(Of OrderDetail)
        Public Property OrderDetails As Query(Of OrderDetail)
			Get
				Return _OrderDetails
			End Get
			Set(value As Query(Of OrderDetail))
				_OrderDetails = value
			End Set
		End Property
		Private _CustomerCustomerDemos As Query(Of CustomerCustomerDemo)
        Public Property CustomerCustomerDemos As Query(Of CustomerCustomerDemo)
			Get
				Return _CustomerCustomerDemos
			End Get
			Set(value As Query(Of CustomerCustomerDemo))
				_CustomerCustomerDemos = value
			End Set
		End Property
		Private _CustomerDemographics As Query(Of CustomerDemographic)
        Public Property CustomerDemographics As Query(Of CustomerDemographic)
			Get
				Return _CustomerDemographics
			End Get
			Set(value As Query(Of CustomerDemographic))
				_CustomerDemographics = value
			End Set
		End Property
		Private _Regions As Query(Of Region)
        Public Property Regions As Query(Of Region)
			Get
				Return _Regions
			End Get
			Set(value As Query(Of Region))
				_Regions = value
			End Set
		End Property
		Private _Territories As Query(Of Territory)
        Public Property Territories As Query(Of Territory)
			Get
				Return _Territories
			End Get
			Set(value As Query(Of Territory))
				_Territories = value
			End Set
		End Property
		Private _EmployeeTerritories As Query(Of EmployeeTerritory)
        Public Property EmployeeTerritories As Query(Of EmployeeTerritory)
			Get
				Return _EmployeeTerritories
			End Get
			Set(value As Query(Of EmployeeTerritory))
				_EmployeeTerritories = value
			End Set
		End Property
		Private _Employees As Query(Of Employee)
        Public Property Employees As Query(Of Employee)
			Get
				Return _Employees
			End Get
			Set(value As Query(Of Employee))
				_Employees = value
			End Set
		End Property

        #Region " Aggregates and SubSonic Queries "

		Public Function SelectColumns(ParamArray columns As String()) As [Select]
            Return New [Select](Provider, columns)
        End Function

        Public ReadOnly Property [Select] As [Select] Implements IQuerySurface.Select
            Get
				Return New [Select](Me.Provider)
			End Get
        End Property

		Public ReadOnly Property Insert() As Insert Implements IQuerySurface.Insert
			Get
				Return New Insert(Me.provider)
			End Get
		End Property
		
        Public Function Update(Of T As New) As Update(Of T) Implements IQuerySurface.Update
            Return New Update(Of T)(Me.Provider)
        End Function

        Public Function Delete(Of T As New)(column As Expression(Of Func(Of T, Boolean))) As SqlQuery Implements IQuerySurface.Delete
            Dim lambda As LambdaExpression = column
            Dim result As SqlQuery = New Delete(Of T)(Me.Provider)
            result = result.From(Of T)()
            Dim c As Global.SubSonic.Query.Constraint = lambda.ParseConstraint()
            result.Constraints.Add(c)
            Return result
        End Function

        Public Function Max(Of T)(column As Expression(Of Func(Of T, Object))) As SqlQuery Implements IQuerySurface.Max
            Dim lambda As LambdaExpression = column
            Dim colName As String = lambda.ParseObjectValue()
            Dim objectName As String = GetType(T).Name
            Dim tableName As String = Me.Provider.FindTable(objectName).Name
            Return New [Select](Me.Provider, New Aggregate(colName, AggregateFunction.Max)).From(tableName)
        End Function

        Public Function Min(Of T)(column As Expression(Of Func(Of T, Object))) As SqlQuery Implements IQuerySurface.Min
            Dim lambda As LambdaExpression = column
            Dim colName As String = lambda.ParseObjectValue()
            Dim objectName As String = GetType(T).Name
            Dim tableName As String = Me.Provider.FindTable(objectName).Name
            Return New [Select](Me.Provider, New Aggregate(colName, AggregateFunction.Min)).From(tableName)
        End Function

        Public Function Sum(Of T)(column As Expression(Of Func(Of T, Object))) As SqlQuery Implements IQuerySurface.Sum
            Dim lambda As LambdaExpression = column
            Dim colName As String = lambda.ParseObjectValue()
            Dim objectName As String = GetType(T).Name
            Dim tableName As String = Me.Provider.FindTable(objectName).Name
            Return New [Select](Me.Provider, New Aggregate(colName, AggregateFunction.Sum)).From(tableName)
        End Function

        Public Function Avg(Of T)(column As Expression(Of Func(Of T, Object))) As SqlQuery Implements IQuerySurface.Avg
            Dim lambda As LambdaExpression = column
            Dim colName As String = lambda.ParseObjectValue()
            Dim objectName As String = GetType(T).Name
            Dim tableName As String = Me.Provider.FindTable(objectName).Name
            Return New [Select](Me.Provider, New Aggregate(colName, AggregateFunction.Avg)).From(tableName)
        End Function

        Public Function Count(Of T)(column As Expression(Of Func(Of T, Object))) As SqlQuery Implements IQuerySurface.Count
            Dim lambda As LambdaExpression = column
            Dim colName As String = lambda.ParseObjectValue()
            Dim objectName As String = GetType(T).Name
            Dim tableName As String = Me.Provider.FindTable(objectName).Name
            Return New [Select](Me.Provider, New Aggregate(colName, AggregateFunction.Count)).From(tableName)
        End Function

        Public Function Variance(Of T)(column As Expression(Of Func(Of T, Object))) As SqlQuery Implements IQuerySurface.Variance
            Dim lambda As LambdaExpression = column
            Dim colName As String = lambda.ParseObjectValue()
            Dim objectName As String = GetType(T).Name
            Dim tableName As String = Me.Provider.FindTable(objectName).Name
            Return New [Select](Me.Provider, New Aggregate(colName, AggregateFunction.Var)).From(tableName)
        End Function

        Public Function StandardDeviation(Of T)(column As Expression(Of Func(Of T, Object))) As SqlQuery Implements IQuerySurface.StandardDeviation
            Dim lambda As LambdaExpression = column
            Dim colName As String = lambda.ParseObjectValue()
            Dim objectName As String = GetType(T).Name
            Dim tableName As String = Me.Provider.FindTable(objectName).Name
            Return New [Select](Me.Provider, New Aggregate(colName, AggregateFunction.StDev)).From(tableName)
        End Function

        #End Region

        Private Sub Init()
            _provider = New DbQueryProvider(Me.Provider)

            ' Query Defs
            Categories = New Query(Of Category)(_provider)
            Customers = New Query(Of Customer)(_provider)
            Shippers = New Query(Of Shipper)(_provider)
            Suppliers = New Query(Of Supplier)(_provider)
            Orders = New Query(Of Order)(_provider)
            Products = New Query(Of Product)(_provider)
            OrderDetails = New Query(Of OrderDetail)(_provider)
            CustomerCustomerDemos = New Query(Of CustomerCustomerDemo)(_provider)
            CustomerDemographics = New Query(Of CustomerDemographic)(_provider)
            Regions = New Query(Of Region)(_provider)
            Territories = New Query(Of Territory)(_provider)
            EmployeeTerritories = New Query(Of EmployeeTerritory)(_provider)
            Employees = New Query(Of Employee)(_provider)


            ' Schemas
        	If _dataProvider.Schema.Tables.Count = 0 Then
            	_dataProvider.Schema.Tables.Add(New CategoriesTable(_dataProvider))
            	_dataProvider.Schema.Tables.Add(New CustomersTable(_dataProvider))
            	_dataProvider.Schema.Tables.Add(New ShippersTable(_dataProvider))
            	_dataProvider.Schema.Tables.Add(New SuppliersTable(_dataProvider))
            	_dataProvider.Schema.Tables.Add(New OrdersTable(_dataProvider))
            	_dataProvider.Schema.Tables.Add(New ProductsTable(_dataProvider))
            	_dataProvider.Schema.Tables.Add(New OrderDetailsTable(_dataProvider))
            	_dataProvider.Schema.Tables.Add(New CustomerCustomerDemoTable(_dataProvider))
            	_dataProvider.Schema.Tables.Add(New CustomerDemographicsTable(_dataProvider))
            	_dataProvider.Schema.Tables.Add(New RegionTable(_dataProvider))
            	_dataProvider.Schema.Tables.Add(New TerritoriesTable(_dataProvider))
            	_dataProvider.Schema.Tables.Add(New EmployeeTerritoriesTable(_dataProvider))
            	_dataProvider.Schema.Tables.Add(New EmployeesTable(_dataProvider))
            End If
        End Sub
    End Class
End NameSpace
