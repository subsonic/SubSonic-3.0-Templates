


Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data
Imports SubSonic.DataProviders
Imports SubSonic.Extensions
Imports System.Linq.Expressions
Imports SubSonic.Schema
Imports System.Collections
Imports SubSonic
Imports SubSonic.Repository
Imports System.ComponentModel
Imports System.Data.Common

NameSpace Southwind
    
    
    ''' <summary>
    ''' A class which represents the Categories table in the Northwind Database.
    ''' </summary>
    Public Partial Class Category
		Implements IActiveRecord

		' Built-in testing
        Shared TestItems As IList(Of Category)
        Shared _testRepo As TestRepository(Of Category)
        Public Sub SetIsLoaded(isLoaded As Boolean) Implements IActiveRecord.SetIsLoaded
            _isLoaded = isLoaded
        End Sub
        Private Shared Sub SetTestRepo()
			iF _testRepo Is Nothing Then _testRepo = New TestRepository(Of Category)(New Southwind.NorthwindDB())
        End Sub
        Public Shared Sub ResetTestRepo()
            _testRepo = Nothing
            SetTestRepo()
        End Sub
        Public Shared Sub Setup(testlist As List(Of Category))
            SetTestRepo()
            _testRepo._items = testlist
        End Sub
        Public Shared Sub Setup(item As Category)
            SetTestRepo()
            _testRepo._items.Add(item)
        End Sub
        Public Shared Sub Setup(testItems As Integer)
            SetTestRepo()
            For i As Integer = 0 To testItems - 1
                Dim item As New Category()
                _testRepo._items.Add(item)
            Next i
        End Sub
        
        Public TestMode As Boolean = False



        Private _repo As IRepository(Of Category)
        Private tbl As ITable
        Private _isNew As Boolean
        Public Function IsNew() As Boolean Implements IActiveRecord.IsNew
            Return _isNew
        End Function
        Public Sub SetIsNew(isNew As Boolean) Implements IActiveRecord.SetIsNew
            _isNew=isNew
        End Sub
        Private _isLoaded As Boolean
        Public Function IsLoaded() As Boolean Implements IActiveRecord.IsLoaded
            Return _isLoaded
        End Function
                
        Private _dirtyColumns As List(Of IColumn)
        Public Function IsDirty() As Boolean Implements IActiveRecord.IsDirty
            Return _dirtyColumns.Count > 0
        End Function
        
        Public Function GetDirtyColumns() As List(Of IColumn) Implements IActiveRecord.GetDirtyColumns
            Return _dirtyColumns
        End Function

        Private _db As Southwind.NorthwindDB
        Public Sub New(connectionString As String, providerName As String)
            _db = New Southwind.NorthwindDB(connectionString, providerName)
            Init()            
         End Sub
        Private Sub Init()
            TestMode = Me._db.Provider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase)
            _dirtyColumns = New List(Of IColumn)()
            If TestMode Then
                Category.SetTestRepo()
                _repo=_testRepo
            Else
                _repo = New SubSonicRepository(Of Category)(_db)
            End If
            tbl=_repo.GetTable()
            _isNew = True
            OnCreated()       
      
        End Sub
        
        Public Sub New()
             _db = New Southwind.NorthwindDB()
            Init()            
        End Sub
        
       
        Private Partial Sub OnCreated()
		End Sub
            
        Private Partial Sub OnLoaded()
		End Sub
        
		Private Partial Sub OnSaved()
		End Sub
        
		Private Partial Sub OnChanged()
		End Sub

		Public ReadOnly Property Columns As IList(Of IColumn)
            Get
                Return tbl.Columns
            End Get
        End Property

        Public Sub New(expression As Expression(Of Func(Of Category, Boolean)))
			MyBase.New()
            _isLoaded=_repo.Load(Me,expression)
            If _isLoaded Then OnLoaded()
        End Sub
        
       
        
        Friend Shared Function GetRepo(connectionString As String, providerName As String) As IRepository(Of Category)
            Dim db As Southwind.NorthwindDB
            If String.IsNullOrEmpty(connectionString)
                db = New Southwind.NorthwindDB()
            Else
                db = New Southwind.NorthwindDB(connectionString, providerName)
            End If
            Dim _repo As IRepository(Of Category)
            
            If db.TestMode Then
                Category.SetTestRepo()
                _repo = _testRepo
            Else
                _repo = New SubSonicRepository(Of Category)(db)
            End If
            Return _repo
        End Function
        
        Friend Shared Function GetRepo() As IRepository(Of Category)
            Return GetRepo(String.Empty,String.Empty)
        End Function
        
        Public Shared Function SingleOrDefault(expression As Expression(Of Func(Of Category, Boolean))) As Category

            Dim repo = GetRepo()
            Dim results = repo.Find(expression)
            Dim singleItem As Category = Nothing
            If results.Count() > 0 Then
                singleItem = results.ToList()(0)
                singleItem.OnLoaded()
                singleItem.SetIsLoaded(true)
            End If

            Return singleItem
        End Function  
        
        Public Shared Function SingleOrDefault(expression As Expression(Of Func(Of Category, Boolean)), _
											   connectionString As String, _
											   providerName As String) As Category
			Dim repo = GetRepo(connectionString,providerName)
            Dim results = repo.Find(expression)
            Dim singleItem As Category = Nothing
            If results.Count() > 0 Then
                singleItem = results.ToList()(0)
                singleItem.OnLoaded()
                singleItem.SetIsLoaded(true)
            End If

            Return singleItem
		End Function
        
        
        Public Shared Function Exists(expression As Expression(Of Func(Of Category, Boolean)), connectionString As String, providerName As String) As Boolean
        	Return All(connectionString,providerName).Any(expression)
        End Function
		
        Public Shared Function Exists(expression As Expression(Of Func(Of Category, Boolean))) As Boolean
            Return All().Any(expression)
        End Function        

        Public Shared Function Find(expression As Expression(Of Func(Of Category, Boolean))) As IList(Of Category)
            Dim repo = GetRepo()
            Return repo.Find(expression).ToList()
        End Function
        
        Public Shared Function Find(expression As Expression(Of Func(Of Category, Boolean)), connectionString As String, providerName As String) As IList(Of Category)
            Dim repo = GetRepo(connectionString,providerName)
            Return repo.Find(expression).ToList()
        End Function
        Public Shared Function All(connectionString As String, providerName As String) As IQueryable(Of Category)
            Return GetRepo(connectionString,providerName).GetAll()
        End Function
        Public Shared Function All() As IQueryable(Of Category)
            Return GetRepo().GetAll()
        End Function
        
        Public Shared Function GetPaged(sortBy As String, pageIndex As Integer, pageSize As Integer, connectionString As String, providerName As String) As PagedList(Of Category)
            Return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize)
        End Function
      
        Public Shared Function GetPaged(sortBy As String, pageIndex As Integer, pageSize As Integer) As PagedList(Of Category)
            Return GetRepo().GetPaged(sortBy, pageIndex, pageSize)
        End Function

        Public Shared Function GetPaged(pageIndex As Integer, pageSize As Integer, connectionString As String, providerName As String) As PagedList(Of Category)
            Return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize)
        End Function

        Public Shared Function GetPaged(pageIndex As Integer, pageSize As Integer) As PagedList(Of Category)
            Return GetRepo().GetPaged(pageIndex, pageSize)
        End Function

        Public Function KeyName() As String Implements IActiveRecord.KeyName
            Return "CategoryID"
        End Function

        Public Function KeyValue() As Object Implements IActiveRecord.KeyValue
            Return Me.CategoryID
        End Function
        
        Public Sub SetKeyValue(value As Object) Implements IActiveRecord.SetKeyValue
            If value IsNot Nothing AndAlso value IsNot DBNull.Value Then
                Dim settable = value.ChangeTypeTo(Of Integer)()
                Me.GetType.GetProperty(Me.KeyName()).SetValue(Me, settable, Nothing)
            End If
        End Sub
        
        Public Overrides Function ToString() As String
            Return Me.CategoryName.ToString()
        End Function

        Public Overrides Function Equals(obj As Object) As Boolean
            If obj.GetType() Is GetType(Category) Then
                Dim compareItem As Category = obj
                Return compareItem.KeyValue() = Me.KeyValue()
            Else
                Return MyBase.Equals(obj)
            End If
        End Function

        Public Function DescriptorValue() As String Implements IActiveRecord.DescriptorValue
            Return Me.CategoryName.ToString()
        End Function

        Public Function DescriptorColumn() As String Implements IActiveRecord.DescriptorColumn
            Return "CategoryName"
        End Function
        Public Shared Function GetKeyColumn() As String 
            Return "CategoryID"
        End Function
        Public Shared Function GetDescriptorColumn() As String
            Return "CategoryName"
        End Function
        
       #Region " Foreign Keys "
        Public ReadOnly Property [Products] As IQueryable(Of Product)
            Get
                  Dim repo = Southwind.Product.GetRepo()
                  Return From items In repo.GetAll() _
                       	Where items.CategoryID = _CategoryID _
                       Select items
            End Get
        End Property

        #End Region

        Private _CategoryID As Integer
        Public Property [CategoryID] As Integer
            Get
				Return _CategoryID
			End Get
            Set(value As Integer)
                _CategoryID = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "CategoryID")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _CategoryName As String
        Public Property [CategoryName] As String
            Get
				Return _CategoryName
			End Get
            Set(value As String)
                _CategoryName = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "CategoryName")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _Description As String
        Public Property [Description] As String
            Get
				Return _Description
			End Get
            Set(value As String)
                _Description = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "Description")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _Picture As Byte()
        Public Property [Picture] As Byte()
            Get
				Return _Picture
			End Get
            Set(value As Byte())
                _Picture = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "Picture")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property



        Public Function GetUpdateCommand() As DbCommand Implements IActiveRecord.GetUpdateCommand
            If TestMode Then
                Return _db.Provider.CreateCommand()
            Else
                Return Me.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand()
            End If
        End Function
        Public Function GetInsertCommand() As DbCommand Implements IActiveRecord.GetInsertCommand
            If TestMode Then
                Return _db.Provider.CreateCommand()
            Else
                Return Me.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand()
			End If
        End Function
        
        Public Function GetDeleteCommand() As DbCommand Implements IActiveRecord.GetDeleteCommand
            If TestMode Then
                Return _db.Provider.CreateCommand()
            Else
                Return Me.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand()
			End If
        End Function
       
        
        Public Sub Update() Implements IActiveRecord.Update
            Update(_db.Provider)
        End Sub
        
        Public Sub Update(provider As IDataProvider) Implements IActiveRecord.Update
        
            If Me._dirtyColumns.Count > 0 Then _repo.Update(Me,provider)
			
            OnSaved()
        End Sub
 
        Public Sub Add() Implements IActiveRecord.Add
            Add(_db.Provider)
        End Sub
        
        
       
        Public Sub Add(provider As IDataProvider) Implements IActiveRecord.Add

            Me.SetKeyValue(_repo.Add(Me,provider))
            OnSaved()
        End Sub
        
                
        
        Public Sub Save() Implements IActiveRecord.Save
            Save(_db.Provider)
        End Sub
        Public Sub Save(provider As IDataProvider) Implements IActiveRecord.Save
            If _isNew Then
                Add(provider)
            Else
                Update(provider)
			End If
        End Sub

        

        Public Sub Delete(provider As IDataProvider)
                   
                 
            _repo.Delete(KeyValue())
            
                    End Sub


        Public Sub Delete() Implements IActiveRecord.Delete
            Delete(_db.Provider)
        End Sub


        Public Shared Sub Delete(expression As Expression(Of Func(Of Category, Boolean)))
            Dim repo = GetRepo()
            
       
            
            repo.DeleteMany(expression)
            
        End Sub

        

        Public Sub Load(rdr As IDataReader) Implements IActiveRecord.Load
            Load(rdr, true)
        End Sub
        Public Sub Load(rdr As IDataReader, closeReader As Boolean) Implements IActiveRecord.Load
            If rdr.Read() Then
                Try
                    rdr.Load(Me)
                    _isNew = False
                    _isLoaded = True
                Catch
                    _isLoaded = False
                    Throw
                End Try
            Else
                _isLoaded = False
            End If

            If closeReader Then rdr.Dispose()

        End Sub
	End Class
    
    
    ''' <summary>
    ''' A class which represents the Customers table in the Northwind Database.
    ''' </summary>
    Public Partial Class Customer
		Implements IActiveRecord

		' Built-in testing
        Shared TestItems As IList(Of Customer)
        Shared _testRepo As TestRepository(Of Customer)
        Public Sub SetIsLoaded(isLoaded As Boolean) Implements IActiveRecord.SetIsLoaded
            _isLoaded = isLoaded
        End Sub
        Private Shared Sub SetTestRepo()
			iF _testRepo Is Nothing Then _testRepo = New TestRepository(Of Customer)(New Southwind.NorthwindDB())
        End Sub
        Public Shared Sub ResetTestRepo()
            _testRepo = Nothing
            SetTestRepo()
        End Sub
        Public Shared Sub Setup(testlist As List(Of Customer))
            SetTestRepo()
            _testRepo._items = testlist
        End Sub
        Public Shared Sub Setup(item As Customer)
            SetTestRepo()
            _testRepo._items.Add(item)
        End Sub
        Public Shared Sub Setup(testItems As Integer)
            SetTestRepo()
            For i As Integer = 0 To testItems - 1
                Dim item As New Customer()
                _testRepo._items.Add(item)
            Next i
        End Sub
        
        Public TestMode As Boolean = False



        Private _repo As IRepository(Of Customer)
        Private tbl As ITable
        Private _isNew As Boolean
        Public Function IsNew() As Boolean Implements IActiveRecord.IsNew
            Return _isNew
        End Function
        Public Sub SetIsNew(isNew As Boolean) Implements IActiveRecord.SetIsNew
            _isNew=isNew
        End Sub
        Private _isLoaded As Boolean
        Public Function IsLoaded() As Boolean Implements IActiveRecord.IsLoaded
            Return _isLoaded
        End Function
                
        Private _dirtyColumns As List(Of IColumn)
        Public Function IsDirty() As Boolean Implements IActiveRecord.IsDirty
            Return _dirtyColumns.Count > 0
        End Function
        
        Public Function GetDirtyColumns() As List(Of IColumn) Implements IActiveRecord.GetDirtyColumns
            Return _dirtyColumns
        End Function

        Private _db As Southwind.NorthwindDB
        Public Sub New(connectionString As String, providerName As String)
            _db = New Southwind.NorthwindDB(connectionString, providerName)
            Init()            
         End Sub
        Private Sub Init()
            TestMode = Me._db.Provider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase)
            _dirtyColumns = New List(Of IColumn)()
            If TestMode Then
                Customer.SetTestRepo()
                _repo=_testRepo
            Else
                _repo = New SubSonicRepository(Of Customer)(_db)
            End If
            tbl=_repo.GetTable()
            _isNew = True
            OnCreated()       
      
        End Sub
        
        Public Sub New()
             _db = New Southwind.NorthwindDB()
            Init()            
        End Sub
        
       
        Private Partial Sub OnCreated()
		End Sub
            
        Private Partial Sub OnLoaded()
		End Sub
        
		Private Partial Sub OnSaved()
		End Sub
        
		Private Partial Sub OnChanged()
		End Sub

		Public ReadOnly Property Columns As IList(Of IColumn)
            Get
                Return tbl.Columns
            End Get
        End Property

        Public Sub New(expression As Expression(Of Func(Of Customer, Boolean)))
			MyBase.New()
            _isLoaded=_repo.Load(Me,expression)
            If _isLoaded Then OnLoaded()
        End Sub
        
       
        
        Friend Shared Function GetRepo(connectionString As String, providerName As String) As IRepository(Of Customer)
            Dim db As Southwind.NorthwindDB
            If String.IsNullOrEmpty(connectionString)
                db = New Southwind.NorthwindDB()
            Else
                db = New Southwind.NorthwindDB(connectionString, providerName)
            End If
            Dim _repo As IRepository(Of Customer)
            
            If db.TestMode Then
                Customer.SetTestRepo()
                _repo = _testRepo
            Else
                _repo = New SubSonicRepository(Of Customer)(db)
            End If
            Return _repo
        End Function
        
        Friend Shared Function GetRepo() As IRepository(Of Customer)
            Return GetRepo(String.Empty,String.Empty)
        End Function
        
        Public Shared Function SingleOrDefault(expression As Expression(Of Func(Of Customer, Boolean))) As Customer

            Dim repo = GetRepo()
            Dim results = repo.Find(expression)
            Dim singleItem As Customer = Nothing
            If results.Count() > 0 Then
                singleItem = results.ToList()(0)
                singleItem.OnLoaded()
                singleItem.SetIsLoaded(true)
            End If

            Return singleItem
        End Function  
        
        Public Shared Function SingleOrDefault(expression As Expression(Of Func(Of Customer, Boolean)), _
											   connectionString As String, _
											   providerName As String) As Customer
			Dim repo = GetRepo(connectionString,providerName)
            Dim results = repo.Find(expression)
            Dim singleItem As Customer = Nothing
            If results.Count() > 0 Then
                singleItem = results.ToList()(0)
                singleItem.OnLoaded()
                singleItem.SetIsLoaded(true)
            End If

            Return singleItem
		End Function
        
        
        Public Shared Function Exists(expression As Expression(Of Func(Of Customer, Boolean)), connectionString As String, providerName As String) As Boolean
        	Return All(connectionString,providerName).Any(expression)
        End Function
		
        Public Shared Function Exists(expression As Expression(Of Func(Of Customer, Boolean))) As Boolean
            Return All().Any(expression)
        End Function        

        Public Shared Function Find(expression As Expression(Of Func(Of Customer, Boolean))) As IList(Of Customer)
            Dim repo = GetRepo()
            Return repo.Find(expression).ToList()
        End Function
        
        Public Shared Function Find(expression As Expression(Of Func(Of Customer, Boolean)), connectionString As String, providerName As String) As IList(Of Customer)
            Dim repo = GetRepo(connectionString,providerName)
            Return repo.Find(expression).ToList()
        End Function
        Public Shared Function All(connectionString As String, providerName As String) As IQueryable(Of Customer)
            Return GetRepo(connectionString,providerName).GetAll()
        End Function
        Public Shared Function All() As IQueryable(Of Customer)
            Return GetRepo().GetAll()
        End Function
        
        Public Shared Function GetPaged(sortBy As String, pageIndex As Integer, pageSize As Integer, connectionString As String, providerName As String) As PagedList(Of Customer)
            Return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize)
        End Function
      
        Public Shared Function GetPaged(sortBy As String, pageIndex As Integer, pageSize As Integer) As PagedList(Of Customer)
            Return GetRepo().GetPaged(sortBy, pageIndex, pageSize)
        End Function

        Public Shared Function GetPaged(pageIndex As Integer, pageSize As Integer, connectionString As String, providerName As String) As PagedList(Of Customer)
            Return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize)
        End Function

        Public Shared Function GetPaged(pageIndex As Integer, pageSize As Integer) As PagedList(Of Customer)
            Return GetRepo().GetPaged(pageIndex, pageSize)
        End Function

        Public Function KeyName() As String Implements IActiveRecord.KeyName
            Return "CustomerID"
        End Function

        Public Function KeyValue() As Object Implements IActiveRecord.KeyValue
            Return Me.CustomerID
        End Function
        
        Public Sub SetKeyValue(value As Object) Implements IActiveRecord.SetKeyValue
            If value IsNot Nothing AndAlso value IsNot DBNull.Value Then
                Dim settable = value.ChangeTypeTo(Of String)()
                Me.GetType.GetProperty(Me.KeyName()).SetValue(Me, settable, Nothing)
            End If
        End Sub
        
        Public Overrides Function ToString() As String
            Return Me.CustomerID.ToString()
        End Function

        Public Overrides Function Equals(obj As Object) As Boolean
            If obj.GetType() Is GetType(Customer) Then
                Dim compareItem As Customer = obj
                Return compareItem.KeyValue() = Me.KeyValue()
            Else
                Return MyBase.Equals(obj)
            End If
        End Function

        Public Function DescriptorValue() As String Implements IActiveRecord.DescriptorValue
            Return Me.CustomerID.ToString()
        End Function

        Public Function DescriptorColumn() As String Implements IActiveRecord.DescriptorColumn
            Return "CustomerID"
        End Function
        Public Shared Function GetKeyColumn() As String 
            Return "CustomerID"
        End Function
        Public Shared Function GetDescriptorColumn() As String
            Return "CustomerID"
        End Function
        
       #Region " Foreign Keys "
        Public ReadOnly Property [CustomerCustomerDemos] As IQueryable(Of CustomerCustomerDemo)
            Get
                  Dim repo = Southwind.CustomerCustomerDemo.GetRepo()
                  Return From items In repo.GetAll() _
                       	Where items.CustomerID = _CustomerID _
                       Select items
            End Get
        End Property

        Public ReadOnly Property [Orders] As IQueryable(Of Order)
            Get
                  Dim repo = Southwind.Order.GetRepo()
                  Return From items In repo.GetAll() _
                       	Where items.CustomerID = _CustomerID _
                       Select items
            End Get
        End Property

        #End Region

        Private _CustomerID As String
        Public Property [CustomerID] As String
            Get
				Return _CustomerID
			End Get
            Set(value As String)
                _CustomerID = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "CustomerID")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _CompanyName As String
        Public Property [CompanyName] As String
            Get
				Return _CompanyName
			End Get
            Set(value As String)
                _CompanyName = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "CompanyName")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _ContactName As String
        Public Property [ContactName] As String
            Get
				Return _ContactName
			End Get
            Set(value As String)
                _ContactName = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "ContactName")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _ContactTitle As String
        Public Property [ContactTitle] As String
            Get
				Return _ContactTitle
			End Get
            Set(value As String)
                _ContactTitle = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "ContactTitle")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _Address As String
        Public Property [Address] As String
            Get
				Return _Address
			End Get
            Set(value As String)
                _Address = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "Address")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _City As String
        Public Property [City] As String
            Get
				Return _City
			End Get
            Set(value As String)
                _City = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "City")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _Region As String
        Public Property [Region] As String
            Get
				Return _Region
			End Get
            Set(value As String)
                _Region = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "Region")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _PostalCode As String
        Public Property [PostalCode] As String
            Get
				Return _PostalCode
			End Get
            Set(value As String)
                _PostalCode = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "PostalCode")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _Country As String
        Public Property [Country] As String
            Get
				Return _Country
			End Get
            Set(value As String)
                _Country = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "Country")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _Phone As String
        Public Property [Phone] As String
            Get
				Return _Phone
			End Get
            Set(value As String)
                _Phone = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "Phone")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _Fax As String
        Public Property [Fax] As String
            Get
				Return _Fax
			End Get
            Set(value As String)
                _Fax = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "Fax")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property



        Public Function GetUpdateCommand() As DbCommand Implements IActiveRecord.GetUpdateCommand
            If TestMode Then
                Return _db.Provider.CreateCommand()
            Else
                Return Me.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand()
            End If
        End Function
        Public Function GetInsertCommand() As DbCommand Implements IActiveRecord.GetInsertCommand
            If TestMode Then
                Return _db.Provider.CreateCommand()
            Else
                Return Me.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand()
			End If
        End Function
        
        Public Function GetDeleteCommand() As DbCommand Implements IActiveRecord.GetDeleteCommand
            If TestMode Then
                Return _db.Provider.CreateCommand()
            Else
                Return Me.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand()
			End If
        End Function
       
        
        Public Sub Update() Implements IActiveRecord.Update
            Update(_db.Provider)
        End Sub
        
        Public Sub Update(provider As IDataProvider) Implements IActiveRecord.Update
        
            If Me._dirtyColumns.Count > 0 Then _repo.Update(Me,provider)
			
            OnSaved()
        End Sub
 
        Public Sub Add() Implements IActiveRecord.Add
            Add(_db.Provider)
        End Sub
        
        
       
        Public Sub Add(provider As IDataProvider) Implements IActiveRecord.Add

            Me.SetKeyValue(_repo.Add(Me,provider))
            OnSaved()
        End Sub
        
                
        
        Public Sub Save() Implements IActiveRecord.Save
            Save(_db.Provider)
        End Sub
        Public Sub Save(provider As IDataProvider) Implements IActiveRecord.Save
            If _isNew Then
                Add(provider)
            Else
                Update(provider)
			End If
        End Sub

        

        Public Sub Delete(provider As IDataProvider)
                   
                 
            _repo.Delete(KeyValue())
            
                    End Sub


        Public Sub Delete() Implements IActiveRecord.Delete
            Delete(_db.Provider)
        End Sub


        Public Shared Sub Delete(expression As Expression(Of Func(Of Customer, Boolean)))
            Dim repo = GetRepo()
            
       
            
            repo.DeleteMany(expression)
            
        End Sub

        

        Public Sub Load(rdr As IDataReader) Implements IActiveRecord.Load
            Load(rdr, true)
        End Sub
        Public Sub Load(rdr As IDataReader, closeReader As Boolean) Implements IActiveRecord.Load
            If rdr.Read() Then
                Try
                    rdr.Load(Me)
                    _isNew = False
                    _isLoaded = True
                Catch
                    _isLoaded = False
                    Throw
                End Try
            Else
                _isLoaded = False
            End If

            If closeReader Then rdr.Dispose()

        End Sub
	End Class
    
    
    ''' <summary>
    ''' A class which represents the Shippers table in the Northwind Database.
    ''' </summary>
    Public Partial Class Shipper
		Implements IActiveRecord

		' Built-in testing
        Shared TestItems As IList(Of Shipper)
        Shared _testRepo As TestRepository(Of Shipper)
        Public Sub SetIsLoaded(isLoaded As Boolean) Implements IActiveRecord.SetIsLoaded
            _isLoaded = isLoaded
        End Sub
        Private Shared Sub SetTestRepo()
			iF _testRepo Is Nothing Then _testRepo = New TestRepository(Of Shipper)(New Southwind.NorthwindDB())
        End Sub
        Public Shared Sub ResetTestRepo()
            _testRepo = Nothing
            SetTestRepo()
        End Sub
        Public Shared Sub Setup(testlist As List(Of Shipper))
            SetTestRepo()
            _testRepo._items = testlist
        End Sub
        Public Shared Sub Setup(item As Shipper)
            SetTestRepo()
            _testRepo._items.Add(item)
        End Sub
        Public Shared Sub Setup(testItems As Integer)
            SetTestRepo()
            For i As Integer = 0 To testItems - 1
                Dim item As New Shipper()
                _testRepo._items.Add(item)
            Next i
        End Sub
        
        Public TestMode As Boolean = False



        Private _repo As IRepository(Of Shipper)
        Private tbl As ITable
        Private _isNew As Boolean
        Public Function IsNew() As Boolean Implements IActiveRecord.IsNew
            Return _isNew
        End Function
        Public Sub SetIsNew(isNew As Boolean) Implements IActiveRecord.SetIsNew
            _isNew=isNew
        End Sub
        Private _isLoaded As Boolean
        Public Function IsLoaded() As Boolean Implements IActiveRecord.IsLoaded
            Return _isLoaded
        End Function
                
        Private _dirtyColumns As List(Of IColumn)
        Public Function IsDirty() As Boolean Implements IActiveRecord.IsDirty
            Return _dirtyColumns.Count > 0
        End Function
        
        Public Function GetDirtyColumns() As List(Of IColumn) Implements IActiveRecord.GetDirtyColumns
            Return _dirtyColumns
        End Function

        Private _db As Southwind.NorthwindDB
        Public Sub New(connectionString As String, providerName As String)
            _db = New Southwind.NorthwindDB(connectionString, providerName)
            Init()            
         End Sub
        Private Sub Init()
            TestMode = Me._db.Provider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase)
            _dirtyColumns = New List(Of IColumn)()
            If TestMode Then
                Shipper.SetTestRepo()
                _repo=_testRepo
            Else
                _repo = New SubSonicRepository(Of Shipper)(_db)
            End If
            tbl=_repo.GetTable()
            _isNew = True
            OnCreated()       
      
        End Sub
        
        Public Sub New()
             _db = New Southwind.NorthwindDB()
            Init()            
        End Sub
        
       
        Private Partial Sub OnCreated()
		End Sub
            
        Private Partial Sub OnLoaded()
		End Sub
        
		Private Partial Sub OnSaved()
		End Sub
        
		Private Partial Sub OnChanged()
		End Sub

		Public ReadOnly Property Columns As IList(Of IColumn)
            Get
                Return tbl.Columns
            End Get
        End Property

        Public Sub New(expression As Expression(Of Func(Of Shipper, Boolean)))
			MyBase.New()
            _isLoaded=_repo.Load(Me,expression)
            If _isLoaded Then OnLoaded()
        End Sub
        
       
        
        Friend Shared Function GetRepo(connectionString As String, providerName As String) As IRepository(Of Shipper)
            Dim db As Southwind.NorthwindDB
            If String.IsNullOrEmpty(connectionString)
                db = New Southwind.NorthwindDB()
            Else
                db = New Southwind.NorthwindDB(connectionString, providerName)
            End If
            Dim _repo As IRepository(Of Shipper)
            
            If db.TestMode Then
                Shipper.SetTestRepo()
                _repo = _testRepo
            Else
                _repo = New SubSonicRepository(Of Shipper)(db)
            End If
            Return _repo
        End Function
        
        Friend Shared Function GetRepo() As IRepository(Of Shipper)
            Return GetRepo(String.Empty,String.Empty)
        End Function
        
        Public Shared Function SingleOrDefault(expression As Expression(Of Func(Of Shipper, Boolean))) As Shipper

            Dim repo = GetRepo()
            Dim results = repo.Find(expression)
            Dim singleItem As Shipper = Nothing
            If results.Count() > 0 Then
                singleItem = results.ToList()(0)
                singleItem.OnLoaded()
                singleItem.SetIsLoaded(true)
            End If

            Return singleItem
        End Function  
        
        Public Shared Function SingleOrDefault(expression As Expression(Of Func(Of Shipper, Boolean)), _
											   connectionString As String, _
											   providerName As String) As Shipper
			Dim repo = GetRepo(connectionString,providerName)
            Dim results = repo.Find(expression)
            Dim singleItem As Shipper = Nothing
            If results.Count() > 0 Then
                singleItem = results.ToList()(0)
                singleItem.OnLoaded()
                singleItem.SetIsLoaded(true)
            End If

            Return singleItem
		End Function
        
        
        Public Shared Function Exists(expression As Expression(Of Func(Of Shipper, Boolean)), connectionString As String, providerName As String) As Boolean
        	Return All(connectionString,providerName).Any(expression)
        End Function
		
        Public Shared Function Exists(expression As Expression(Of Func(Of Shipper, Boolean))) As Boolean
            Return All().Any(expression)
        End Function        

        Public Shared Function Find(expression As Expression(Of Func(Of Shipper, Boolean))) As IList(Of Shipper)
            Dim repo = GetRepo()
            Return repo.Find(expression).ToList()
        End Function
        
        Public Shared Function Find(expression As Expression(Of Func(Of Shipper, Boolean)), connectionString As String, providerName As String) As IList(Of Shipper)
            Dim repo = GetRepo(connectionString,providerName)
            Return repo.Find(expression).ToList()
        End Function
        Public Shared Function All(connectionString As String, providerName As String) As IQueryable(Of Shipper)
            Return GetRepo(connectionString,providerName).GetAll()
        End Function
        Public Shared Function All() As IQueryable(Of Shipper)
            Return GetRepo().GetAll()
        End Function
        
        Public Shared Function GetPaged(sortBy As String, pageIndex As Integer, pageSize As Integer, connectionString As String, providerName As String) As PagedList(Of Shipper)
            Return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize)
        End Function
      
        Public Shared Function GetPaged(sortBy As String, pageIndex As Integer, pageSize As Integer) As PagedList(Of Shipper)
            Return GetRepo().GetPaged(sortBy, pageIndex, pageSize)
        End Function

        Public Shared Function GetPaged(pageIndex As Integer, pageSize As Integer, connectionString As String, providerName As String) As PagedList(Of Shipper)
            Return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize)
        End Function

        Public Shared Function GetPaged(pageIndex As Integer, pageSize As Integer) As PagedList(Of Shipper)
            Return GetRepo().GetPaged(pageIndex, pageSize)
        End Function

        Public Function KeyName() As String Implements IActiveRecord.KeyName
            Return "ShipperID"
        End Function

        Public Function KeyValue() As Object Implements IActiveRecord.KeyValue
            Return Me.ShipperID
        End Function
        
        Public Sub SetKeyValue(value As Object) Implements IActiveRecord.SetKeyValue
            If value IsNot Nothing AndAlso value IsNot DBNull.Value Then
                Dim settable = value.ChangeTypeTo(Of Integer)()
                Me.GetType.GetProperty(Me.KeyName()).SetValue(Me, settable, Nothing)
            End If
        End Sub
        
        Public Overrides Function ToString() As String
            Return Me.CompanyName.ToString()
        End Function

        Public Overrides Function Equals(obj As Object) As Boolean
            If obj.GetType() Is GetType(Shipper) Then
                Dim compareItem As Shipper = obj
                Return compareItem.KeyValue() = Me.KeyValue()
            Else
                Return MyBase.Equals(obj)
            End If
        End Function

        Public Function DescriptorValue() As String Implements IActiveRecord.DescriptorValue
            Return Me.CompanyName.ToString()
        End Function

        Public Function DescriptorColumn() As String Implements IActiveRecord.DescriptorColumn
            Return "CompanyName"
        End Function
        Public Shared Function GetKeyColumn() As String 
            Return "ShipperID"
        End Function
        Public Shared Function GetDescriptorColumn() As String
            Return "CompanyName"
        End Function
        
       #Region " Foreign Keys "
        Public ReadOnly Property [Orders] As IQueryable(Of Order)
            Get
                  Dim repo = Southwind.Order.GetRepo()
                  Return From items In repo.GetAll() _
                       	Where items.ShipVia = _ShipperID _
                       Select items
            End Get
        End Property

        #End Region

        Private _ShipperID As Integer
        Public Property [ShipperID] As Integer
            Get
				Return _ShipperID
			End Get
            Set(value As Integer)
                _ShipperID = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "ShipperID")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _CompanyName As String
        Public Property [CompanyName] As String
            Get
				Return _CompanyName
			End Get
            Set(value As String)
                _CompanyName = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "CompanyName")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _Phone As String
        Public Property [Phone] As String
            Get
				Return _Phone
			End Get
            Set(value As String)
                _Phone = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "Phone")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property



        Public Function GetUpdateCommand() As DbCommand Implements IActiveRecord.GetUpdateCommand
            If TestMode Then
                Return _db.Provider.CreateCommand()
            Else
                Return Me.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand()
            End If
        End Function
        Public Function GetInsertCommand() As DbCommand Implements IActiveRecord.GetInsertCommand
            If TestMode Then
                Return _db.Provider.CreateCommand()
            Else
                Return Me.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand()
			End If
        End Function
        
        Public Function GetDeleteCommand() As DbCommand Implements IActiveRecord.GetDeleteCommand
            If TestMode Then
                Return _db.Provider.CreateCommand()
            Else
                Return Me.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand()
			End If
        End Function
       
        
        Public Sub Update() Implements IActiveRecord.Update
            Update(_db.Provider)
        End Sub
        
        Public Sub Update(provider As IDataProvider) Implements IActiveRecord.Update
        
            If Me._dirtyColumns.Count > 0 Then _repo.Update(Me,provider)
			
            OnSaved()
        End Sub
 
        Public Sub Add() Implements IActiveRecord.Add
            Add(_db.Provider)
        End Sub
        
        
       
        Public Sub Add(provider As IDataProvider) Implements IActiveRecord.Add

            Me.SetKeyValue(_repo.Add(Me,provider))
            OnSaved()
        End Sub
        
                
        
        Public Sub Save() Implements IActiveRecord.Save
            Save(_db.Provider)
        End Sub
        Public Sub Save(provider As IDataProvider) Implements IActiveRecord.Save
            If _isNew Then
                Add(provider)
            Else
                Update(provider)
			End If
        End Sub

        

        Public Sub Delete(provider As IDataProvider)
                   
                 
            _repo.Delete(KeyValue())
            
                    End Sub


        Public Sub Delete() Implements IActiveRecord.Delete
            Delete(_db.Provider)
        End Sub


        Public Shared Sub Delete(expression As Expression(Of Func(Of Shipper, Boolean)))
            Dim repo = GetRepo()
            
       
            
            repo.DeleteMany(expression)
            
        End Sub

        

        Public Sub Load(rdr As IDataReader) Implements IActiveRecord.Load
            Load(rdr, true)
        End Sub
        Public Sub Load(rdr As IDataReader, closeReader As Boolean) Implements IActiveRecord.Load
            If rdr.Read() Then
                Try
                    rdr.Load(Me)
                    _isNew = False
                    _isLoaded = True
                Catch
                    _isLoaded = False
                    Throw
                End Try
            Else
                _isLoaded = False
            End If

            If closeReader Then rdr.Dispose()

        End Sub
	End Class
    
    
    ''' <summary>
    ''' A class which represents the Suppliers table in the Northwind Database.
    ''' </summary>
    Public Partial Class Supplier
		Implements IActiveRecord

		' Built-in testing
        Shared TestItems As IList(Of Supplier)
        Shared _testRepo As TestRepository(Of Supplier)
        Public Sub SetIsLoaded(isLoaded As Boolean) Implements IActiveRecord.SetIsLoaded
            _isLoaded = isLoaded
        End Sub
        Private Shared Sub SetTestRepo()
			iF _testRepo Is Nothing Then _testRepo = New TestRepository(Of Supplier)(New Southwind.NorthwindDB())
        End Sub
        Public Shared Sub ResetTestRepo()
            _testRepo = Nothing
            SetTestRepo()
        End Sub
        Public Shared Sub Setup(testlist As List(Of Supplier))
            SetTestRepo()
            _testRepo._items = testlist
        End Sub
        Public Shared Sub Setup(item As Supplier)
            SetTestRepo()
            _testRepo._items.Add(item)
        End Sub
        Public Shared Sub Setup(testItems As Integer)
            SetTestRepo()
            For i As Integer = 0 To testItems - 1
                Dim item As New Supplier()
                _testRepo._items.Add(item)
            Next i
        End Sub
        
        Public TestMode As Boolean = False



        Private _repo As IRepository(Of Supplier)
        Private tbl As ITable
        Private _isNew As Boolean
        Public Function IsNew() As Boolean Implements IActiveRecord.IsNew
            Return _isNew
        End Function
        Public Sub SetIsNew(isNew As Boolean) Implements IActiveRecord.SetIsNew
            _isNew=isNew
        End Sub
        Private _isLoaded As Boolean
        Public Function IsLoaded() As Boolean Implements IActiveRecord.IsLoaded
            Return _isLoaded
        End Function
                
        Private _dirtyColumns As List(Of IColumn)
        Public Function IsDirty() As Boolean Implements IActiveRecord.IsDirty
            Return _dirtyColumns.Count > 0
        End Function
        
        Public Function GetDirtyColumns() As List(Of IColumn) Implements IActiveRecord.GetDirtyColumns
            Return _dirtyColumns
        End Function

        Private _db As Southwind.NorthwindDB
        Public Sub New(connectionString As String, providerName As String)
            _db = New Southwind.NorthwindDB(connectionString, providerName)
            Init()            
         End Sub
        Private Sub Init()
            TestMode = Me._db.Provider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase)
            _dirtyColumns = New List(Of IColumn)()
            If TestMode Then
                Supplier.SetTestRepo()
                _repo=_testRepo
            Else
                _repo = New SubSonicRepository(Of Supplier)(_db)
            End If
            tbl=_repo.GetTable()
            _isNew = True
            OnCreated()       
      
        End Sub
        
        Public Sub New()
             _db = New Southwind.NorthwindDB()
            Init()            
        End Sub
        
       
        Private Partial Sub OnCreated()
		End Sub
            
        Private Partial Sub OnLoaded()
		End Sub
        
		Private Partial Sub OnSaved()
		End Sub
        
		Private Partial Sub OnChanged()
		End Sub

		Public ReadOnly Property Columns As IList(Of IColumn)
            Get
                Return tbl.Columns
            End Get
        End Property

        Public Sub New(expression As Expression(Of Func(Of Supplier, Boolean)))
			MyBase.New()
            _isLoaded=_repo.Load(Me,expression)
            If _isLoaded Then OnLoaded()
        End Sub
        
       
        
        Friend Shared Function GetRepo(connectionString As String, providerName As String) As IRepository(Of Supplier)
            Dim db As Southwind.NorthwindDB
            If String.IsNullOrEmpty(connectionString)
                db = New Southwind.NorthwindDB()
            Else
                db = New Southwind.NorthwindDB(connectionString, providerName)
            End If
            Dim _repo As IRepository(Of Supplier)
            
            If db.TestMode Then
                Supplier.SetTestRepo()
                _repo = _testRepo
            Else
                _repo = New SubSonicRepository(Of Supplier)(db)
            End If
            Return _repo
        End Function
        
        Friend Shared Function GetRepo() As IRepository(Of Supplier)
            Return GetRepo(String.Empty,String.Empty)
        End Function
        
        Public Shared Function SingleOrDefault(expression As Expression(Of Func(Of Supplier, Boolean))) As Supplier

            Dim repo = GetRepo()
            Dim results = repo.Find(expression)
            Dim singleItem As Supplier = Nothing
            If results.Count() > 0 Then
                singleItem = results.ToList()(0)
                singleItem.OnLoaded()
                singleItem.SetIsLoaded(true)
            End If

            Return singleItem
        End Function  
        
        Public Shared Function SingleOrDefault(expression As Expression(Of Func(Of Supplier, Boolean)), _
											   connectionString As String, _
											   providerName As String) As Supplier
			Dim repo = GetRepo(connectionString,providerName)
            Dim results = repo.Find(expression)
            Dim singleItem As Supplier = Nothing
            If results.Count() > 0 Then
                singleItem = results.ToList()(0)
                singleItem.OnLoaded()
                singleItem.SetIsLoaded(true)
            End If

            Return singleItem
		End Function
        
        
        Public Shared Function Exists(expression As Expression(Of Func(Of Supplier, Boolean)), connectionString As String, providerName As String) As Boolean
        	Return All(connectionString,providerName).Any(expression)
        End Function
		
        Public Shared Function Exists(expression As Expression(Of Func(Of Supplier, Boolean))) As Boolean
            Return All().Any(expression)
        End Function        

        Public Shared Function Find(expression As Expression(Of Func(Of Supplier, Boolean))) As IList(Of Supplier)
            Dim repo = GetRepo()
            Return repo.Find(expression).ToList()
        End Function
        
        Public Shared Function Find(expression As Expression(Of Func(Of Supplier, Boolean)), connectionString As String, providerName As String) As IList(Of Supplier)
            Dim repo = GetRepo(connectionString,providerName)
            Return repo.Find(expression).ToList()
        End Function
        Public Shared Function All(connectionString As String, providerName As String) As IQueryable(Of Supplier)
            Return GetRepo(connectionString,providerName).GetAll()
        End Function
        Public Shared Function All() As IQueryable(Of Supplier)
            Return GetRepo().GetAll()
        End Function
        
        Public Shared Function GetPaged(sortBy As String, pageIndex As Integer, pageSize As Integer, connectionString As String, providerName As String) As PagedList(Of Supplier)
            Return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize)
        End Function
      
        Public Shared Function GetPaged(sortBy As String, pageIndex As Integer, pageSize As Integer) As PagedList(Of Supplier)
            Return GetRepo().GetPaged(sortBy, pageIndex, pageSize)
        End Function

        Public Shared Function GetPaged(pageIndex As Integer, pageSize As Integer, connectionString As String, providerName As String) As PagedList(Of Supplier)
            Return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize)
        End Function

        Public Shared Function GetPaged(pageIndex As Integer, pageSize As Integer) As PagedList(Of Supplier)
            Return GetRepo().GetPaged(pageIndex, pageSize)
        End Function

        Public Function KeyName() As String Implements IActiveRecord.KeyName
            Return "SupplierID"
        End Function

        Public Function KeyValue() As Object Implements IActiveRecord.KeyValue
            Return Me.SupplierID
        End Function
        
        Public Sub SetKeyValue(value As Object) Implements IActiveRecord.SetKeyValue
            If value IsNot Nothing AndAlso value IsNot DBNull.Value Then
                Dim settable = value.ChangeTypeTo(Of Integer)()
                Me.GetType.GetProperty(Me.KeyName()).SetValue(Me, settable, Nothing)
            End If
        End Sub
        
        Public Overrides Function ToString() As String
            Return Me.CompanyName.ToString()
        End Function

        Public Overrides Function Equals(obj As Object) As Boolean
            If obj.GetType() Is GetType(Supplier) Then
                Dim compareItem As Supplier = obj
                Return compareItem.KeyValue() = Me.KeyValue()
            Else
                Return MyBase.Equals(obj)
            End If
        End Function

        Public Function DescriptorValue() As String Implements IActiveRecord.DescriptorValue
            Return Me.CompanyName.ToString()
        End Function

        Public Function DescriptorColumn() As String Implements IActiveRecord.DescriptorColumn
            Return "CompanyName"
        End Function
        Public Shared Function GetKeyColumn() As String 
            Return "SupplierID"
        End Function
        Public Shared Function GetDescriptorColumn() As String
            Return "CompanyName"
        End Function
        
       #Region " Foreign Keys "
        Public ReadOnly Property [Products] As IQueryable(Of Product)
            Get
                  Dim repo = Southwind.Product.GetRepo()
                  Return From items In repo.GetAll() _
                       	Where items.SupplierID = _SupplierID _
                       Select items
            End Get
        End Property

        #End Region

        Private _SupplierID As Integer
        Public Property [SupplierID] As Integer
            Get
				Return _SupplierID
			End Get
            Set(value As Integer)
                _SupplierID = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "SupplierID")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _CompanyName As String
        Public Property [CompanyName] As String
            Get
				Return _CompanyName
			End Get
            Set(value As String)
                _CompanyName = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "CompanyName")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _ContactName As String
        Public Property [ContactName] As String
            Get
				Return _ContactName
			End Get
            Set(value As String)
                _ContactName = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "ContactName")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _ContactTitle As String
        Public Property [ContactTitle] As String
            Get
				Return _ContactTitle
			End Get
            Set(value As String)
                _ContactTitle = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "ContactTitle")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _Address As String
        Public Property [Address] As String
            Get
				Return _Address
			End Get
            Set(value As String)
                _Address = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "Address")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _City As String
        Public Property [City] As String
            Get
				Return _City
			End Get
            Set(value As String)
                _City = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "City")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _Region As String
        Public Property [Region] As String
            Get
				Return _Region
			End Get
            Set(value As String)
                _Region = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "Region")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _PostalCode As String
        Public Property [PostalCode] As String
            Get
				Return _PostalCode
			End Get
            Set(value As String)
                _PostalCode = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "PostalCode")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _Country As String
        Public Property [Country] As String
            Get
				Return _Country
			End Get
            Set(value As String)
                _Country = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "Country")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _Phone As String
        Public Property [Phone] As String
            Get
				Return _Phone
			End Get
            Set(value As String)
                _Phone = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "Phone")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _Fax As String
        Public Property [Fax] As String
            Get
				Return _Fax
			End Get
            Set(value As String)
                _Fax = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "Fax")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _HomePage As String
        Public Property [HomePage] As String
            Get
				Return _HomePage
			End Get
            Set(value As String)
                _HomePage = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "HomePage")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property



        Public Function GetUpdateCommand() As DbCommand Implements IActiveRecord.GetUpdateCommand
            If TestMode Then
                Return _db.Provider.CreateCommand()
            Else
                Return Me.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand()
            End If
        End Function
        Public Function GetInsertCommand() As DbCommand Implements IActiveRecord.GetInsertCommand
            If TestMode Then
                Return _db.Provider.CreateCommand()
            Else
                Return Me.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand()
			End If
        End Function
        
        Public Function GetDeleteCommand() As DbCommand Implements IActiveRecord.GetDeleteCommand
            If TestMode Then
                Return _db.Provider.CreateCommand()
            Else
                Return Me.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand()
			End If
        End Function
       
        
        Public Sub Update() Implements IActiveRecord.Update
            Update(_db.Provider)
        End Sub
        
        Public Sub Update(provider As IDataProvider) Implements IActiveRecord.Update
        
            If Me._dirtyColumns.Count > 0 Then _repo.Update(Me,provider)
			
            OnSaved()
        End Sub
 
        Public Sub Add() Implements IActiveRecord.Add
            Add(_db.Provider)
        End Sub
        
        
       
        Public Sub Add(provider As IDataProvider) Implements IActiveRecord.Add

            Me.SetKeyValue(_repo.Add(Me,provider))
            OnSaved()
        End Sub
        
                
        
        Public Sub Save() Implements IActiveRecord.Save
            Save(_db.Provider)
        End Sub
        Public Sub Save(provider As IDataProvider) Implements IActiveRecord.Save
            If _isNew Then
                Add(provider)
            Else
                Update(provider)
			End If
        End Sub

        

        Public Sub Delete(provider As IDataProvider)
                   
                 
            _repo.Delete(KeyValue())
            
                    End Sub


        Public Sub Delete() Implements IActiveRecord.Delete
            Delete(_db.Provider)
        End Sub


        Public Shared Sub Delete(expression As Expression(Of Func(Of Supplier, Boolean)))
            Dim repo = GetRepo()
            
       
            
            repo.DeleteMany(expression)
            
        End Sub

        

        Public Sub Load(rdr As IDataReader) Implements IActiveRecord.Load
            Load(rdr, true)
        End Sub
        Public Sub Load(rdr As IDataReader, closeReader As Boolean) Implements IActiveRecord.Load
            If rdr.Read() Then
                Try
                    rdr.Load(Me)
                    _isNew = False
                    _isLoaded = True
                Catch
                    _isLoaded = False
                    Throw
                End Try
            Else
                _isLoaded = False
            End If

            If closeReader Then rdr.Dispose()

        End Sub
	End Class
    
    
    ''' <summary>
    ''' A class which represents the Orders table in the Northwind Database.
    ''' </summary>
    Public Partial Class Order
		Implements IActiveRecord

		' Built-in testing
        Shared TestItems As IList(Of Order)
        Shared _testRepo As TestRepository(Of Order)
        Public Sub SetIsLoaded(isLoaded As Boolean) Implements IActiveRecord.SetIsLoaded
            _isLoaded = isLoaded
        End Sub
        Private Shared Sub SetTestRepo()
			iF _testRepo Is Nothing Then _testRepo = New TestRepository(Of Order)(New Southwind.NorthwindDB())
        End Sub
        Public Shared Sub ResetTestRepo()
            _testRepo = Nothing
            SetTestRepo()
        End Sub
        Public Shared Sub Setup(testlist As List(Of Order))
            SetTestRepo()
            _testRepo._items = testlist
        End Sub
        Public Shared Sub Setup(item As Order)
            SetTestRepo()
            _testRepo._items.Add(item)
        End Sub
        Public Shared Sub Setup(testItems As Integer)
            SetTestRepo()
            For i As Integer = 0 To testItems - 1
                Dim item As New Order()
                _testRepo._items.Add(item)
            Next i
        End Sub
        
        Public TestMode As Boolean = False



        Private _repo As IRepository(Of Order)
        Private tbl As ITable
        Private _isNew As Boolean
        Public Function IsNew() As Boolean Implements IActiveRecord.IsNew
            Return _isNew
        End Function
        Public Sub SetIsNew(isNew As Boolean) Implements IActiveRecord.SetIsNew
            _isNew=isNew
        End Sub
        Private _isLoaded As Boolean
        Public Function IsLoaded() As Boolean Implements IActiveRecord.IsLoaded
            Return _isLoaded
        End Function
                
        Private _dirtyColumns As List(Of IColumn)
        Public Function IsDirty() As Boolean Implements IActiveRecord.IsDirty
            Return _dirtyColumns.Count > 0
        End Function
        
        Public Function GetDirtyColumns() As List(Of IColumn) Implements IActiveRecord.GetDirtyColumns
            Return _dirtyColumns
        End Function

        Private _db As Southwind.NorthwindDB
        Public Sub New(connectionString As String, providerName As String)
            _db = New Southwind.NorthwindDB(connectionString, providerName)
            Init()            
         End Sub
        Private Sub Init()
            TestMode = Me._db.Provider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase)
            _dirtyColumns = New List(Of IColumn)()
            If TestMode Then
                Order.SetTestRepo()
                _repo=_testRepo
            Else
                _repo = New SubSonicRepository(Of Order)(_db)
            End If
            tbl=_repo.GetTable()
            _isNew = True
            OnCreated()       
      
        End Sub
        
        Public Sub New()
             _db = New Southwind.NorthwindDB()
            Init()            
        End Sub
        
       
        Private Partial Sub OnCreated()
		End Sub
            
        Private Partial Sub OnLoaded()
		End Sub
        
		Private Partial Sub OnSaved()
		End Sub
        
		Private Partial Sub OnChanged()
		End Sub

		Public ReadOnly Property Columns As IList(Of IColumn)
            Get
                Return tbl.Columns
            End Get
        End Property

        Public Sub New(expression As Expression(Of Func(Of Order, Boolean)))
			MyBase.New()
            _isLoaded=_repo.Load(Me,expression)
            If _isLoaded Then OnLoaded()
        End Sub
        
       
        
        Friend Shared Function GetRepo(connectionString As String, providerName As String) As IRepository(Of Order)
            Dim db As Southwind.NorthwindDB
            If String.IsNullOrEmpty(connectionString)
                db = New Southwind.NorthwindDB()
            Else
                db = New Southwind.NorthwindDB(connectionString, providerName)
            End If
            Dim _repo As IRepository(Of Order)
            
            If db.TestMode Then
                Order.SetTestRepo()
                _repo = _testRepo
            Else
                _repo = New SubSonicRepository(Of Order)(db)
            End If
            Return _repo
        End Function
        
        Friend Shared Function GetRepo() As IRepository(Of Order)
            Return GetRepo(String.Empty,String.Empty)
        End Function
        
        Public Shared Function SingleOrDefault(expression As Expression(Of Func(Of Order, Boolean))) As Order

            Dim repo = GetRepo()
            Dim results = repo.Find(expression)
            Dim singleItem As Order = Nothing
            If results.Count() > 0 Then
                singleItem = results.ToList()(0)
                singleItem.OnLoaded()
                singleItem.SetIsLoaded(true)
            End If

            Return singleItem
        End Function  
        
        Public Shared Function SingleOrDefault(expression As Expression(Of Func(Of Order, Boolean)), _
											   connectionString As String, _
											   providerName As String) As Order
			Dim repo = GetRepo(connectionString,providerName)
            Dim results = repo.Find(expression)
            Dim singleItem As Order = Nothing
            If results.Count() > 0 Then
                singleItem = results.ToList()(0)
                singleItem.OnLoaded()
                singleItem.SetIsLoaded(true)
            End If

            Return singleItem
		End Function
        
        
        Public Shared Function Exists(expression As Expression(Of Func(Of Order, Boolean)), connectionString As String, providerName As String) As Boolean
        	Return All(connectionString,providerName).Any(expression)
        End Function
		
        Public Shared Function Exists(expression As Expression(Of Func(Of Order, Boolean))) As Boolean
            Return All().Any(expression)
        End Function        

        Public Shared Function Find(expression As Expression(Of Func(Of Order, Boolean))) As IList(Of Order)
            Dim repo = GetRepo()
            Return repo.Find(expression).ToList()
        End Function
        
        Public Shared Function Find(expression As Expression(Of Func(Of Order, Boolean)), connectionString As String, providerName As String) As IList(Of Order)
            Dim repo = GetRepo(connectionString,providerName)
            Return repo.Find(expression).ToList()
        End Function
        Public Shared Function All(connectionString As String, providerName As String) As IQueryable(Of Order)
            Return GetRepo(connectionString,providerName).GetAll()
        End Function
        Public Shared Function All() As IQueryable(Of Order)
            Return GetRepo().GetAll()
        End Function
        
        Public Shared Function GetPaged(sortBy As String, pageIndex As Integer, pageSize As Integer, connectionString As String, providerName As String) As PagedList(Of Order)
            Return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize)
        End Function
      
        Public Shared Function GetPaged(sortBy As String, pageIndex As Integer, pageSize As Integer) As PagedList(Of Order)
            Return GetRepo().GetPaged(sortBy, pageIndex, pageSize)
        End Function

        Public Shared Function GetPaged(pageIndex As Integer, pageSize As Integer, connectionString As String, providerName As String) As PagedList(Of Order)
            Return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize)
        End Function

        Public Shared Function GetPaged(pageIndex As Integer, pageSize As Integer) As PagedList(Of Order)
            Return GetRepo().GetPaged(pageIndex, pageSize)
        End Function

        Public Function KeyName() As String Implements IActiveRecord.KeyName
            Return "OrderID"
        End Function

        Public Function KeyValue() As Object Implements IActiveRecord.KeyValue
            Return Me.OrderID
        End Function
        
        Public Sub SetKeyValue(value As Object) Implements IActiveRecord.SetKeyValue
            If value IsNot Nothing AndAlso value IsNot DBNull.Value Then
                Dim settable = value.ChangeTypeTo(Of Integer)()
                Me.GetType.GetProperty(Me.KeyName()).SetValue(Me, settable, Nothing)
            End If
        End Sub
        
        Public Overrides Function ToString() As String
            Return Me.CustomerID.ToString()
        End Function

        Public Overrides Function Equals(obj As Object) As Boolean
            If obj.GetType() Is GetType(Order) Then
                Dim compareItem As Order = obj
                Return compareItem.KeyValue() = Me.KeyValue()
            Else
                Return MyBase.Equals(obj)
            End If
        End Function

        Public Function DescriptorValue() As String Implements IActiveRecord.DescriptorValue
            Return Me.CustomerID.ToString()
        End Function

        Public Function DescriptorColumn() As String Implements IActiveRecord.DescriptorColumn
            Return "CustomerID"
        End Function
        Public Shared Function GetKeyColumn() As String 
            Return "OrderID"
        End Function
        Public Shared Function GetDescriptorColumn() As String
            Return "CustomerID"
        End Function
        
       #Region " Foreign Keys "
        Public ReadOnly Property [Customers] As IQueryable(Of Customer)
            Get
                  Dim repo = Southwind.Customer.GetRepo()
                  Return From items In repo.GetAll() _
                       	Where items.CustomerID = _CustomerID _
                       Select items
            End Get
        End Property

        Public ReadOnly Property [Employees] As IQueryable(Of Employee)
            Get
                  Dim repo = Southwind.Employee.GetRepo()
                  Return From items In repo.GetAll() _
                       	Where items.EmployeeID = _EmployeeID _
                       Select items
            End Get
        End Property

        Public ReadOnly Property [OrderDetails] As IQueryable(Of OrderDetail)
            Get
                  Dim repo = Southwind.OrderDetail.GetRepo()
                  Return From items In repo.GetAll() _
                       	Where items.OrderID = _OrderID _
                       Select items
            End Get
        End Property

        Public ReadOnly Property [Shippers] As IQueryable(Of Shipper)
            Get
                  Dim repo = Southwind.Shipper.GetRepo()
                  Return From items In repo.GetAll() _
                       	Where items.ShipperID = _ShipVia _
                       Select items
            End Get
        End Property

        #End Region

        Private _OrderID As Integer
        Public Property [OrderID] As Integer
            Get
				Return _OrderID
			End Get
            Set(value As Integer)
                _OrderID = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "OrderID")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _CustomerID As String
        Public Property [CustomerID] As String
            Get
				Return _CustomerID
			End Get
            Set(value As String)
                _CustomerID = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "CustomerID")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _EmployeeID As Integer?
        Public Property [EmployeeID] As Integer?
            Get
				Return _EmployeeID
			End Get
            Set(value As Integer?)
                _EmployeeID = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "EmployeeID")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _OrderDate As Date
        Public Property [OrderDate] As Date
            Get
				Return _OrderDate
			End Get
            Set(value As Date)
                _OrderDate = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "OrderDate")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _RequiredDate As Date?
        Public Property [RequiredDate] As Date?
            Get
				Return _RequiredDate
			End Get
            Set(value As Date?)
                _RequiredDate = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "RequiredDate")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _ShippedDate As Date?
        Public Property [ShippedDate] As Date?
            Get
				Return _ShippedDate
			End Get
            Set(value As Date?)
                _ShippedDate = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "ShippedDate")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _ShipVia As Integer?
        Public Property [ShipVia] As Integer?
            Get
				Return _ShipVia
			End Get
            Set(value As Integer?)
                _ShipVia = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "ShipVia")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _Freight As Decimal?
        Public Property [Freight] As Decimal?
            Get
				Return _Freight
			End Get
            Set(value As Decimal?)
                _Freight = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "Freight")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _ShipName As String
        Public Property [ShipName] As String
            Get
				Return _ShipName
			End Get
            Set(value As String)
                _ShipName = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "ShipName")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _ShipAddress As String
        Public Property [ShipAddress] As String
            Get
				Return _ShipAddress
			End Get
            Set(value As String)
                _ShipAddress = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "ShipAddress")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _ShipCity As String
        Public Property [ShipCity] As String
            Get
				Return _ShipCity
			End Get
            Set(value As String)
                _ShipCity = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "ShipCity")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _ShipRegion As String
        Public Property [ShipRegion] As String
            Get
				Return _ShipRegion
			End Get
            Set(value As String)
                _ShipRegion = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "ShipRegion")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _ShipPostalCode As String
        Public Property [ShipPostalCode] As String
            Get
				Return _ShipPostalCode
			End Get
            Set(value As String)
                _ShipPostalCode = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "ShipPostalCode")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _ShipCountry As String
        Public Property [ShipCountry] As String
            Get
				Return _ShipCountry
			End Get
            Set(value As String)
                _ShipCountry = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "ShipCountry")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property



        Public Function GetUpdateCommand() As DbCommand Implements IActiveRecord.GetUpdateCommand
            If TestMode Then
                Return _db.Provider.CreateCommand()
            Else
                Return Me.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand()
            End If
        End Function
        Public Function GetInsertCommand() As DbCommand Implements IActiveRecord.GetInsertCommand
            If TestMode Then
                Return _db.Provider.CreateCommand()
            Else
                Return Me.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand()
			End If
        End Function
        
        Public Function GetDeleteCommand() As DbCommand Implements IActiveRecord.GetDeleteCommand
            If TestMode Then
                Return _db.Provider.CreateCommand()
            Else
                Return Me.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand()
			End If
        End Function
       
        
        Public Sub Update() Implements IActiveRecord.Update
            Update(_db.Provider)
        End Sub
        
        Public Sub Update(provider As IDataProvider) Implements IActiveRecord.Update
        
            If Me._dirtyColumns.Count > 0 Then _repo.Update(Me,provider)
			
            OnSaved()
        End Sub
 
        Public Sub Add() Implements IActiveRecord.Add
            Add(_db.Provider)
        End Sub
        
        
       
        Public Sub Add(provider As IDataProvider) Implements IActiveRecord.Add

            Me.SetKeyValue(_repo.Add(Me,provider))
            OnSaved()
        End Sub
        
                
        
        Public Sub Save() Implements IActiveRecord.Save
            Save(_db.Provider)
        End Sub
        Public Sub Save(provider As IDataProvider) Implements IActiveRecord.Save
            If _isNew Then
                Add(provider)
            Else
                Update(provider)
			End If
        End Sub

        

        Public Sub Delete(provider As IDataProvider)
                   
                 
            _repo.Delete(KeyValue())
            
                    End Sub


        Public Sub Delete() Implements IActiveRecord.Delete
            Delete(_db.Provider)
        End Sub


        Public Shared Sub Delete(expression As Expression(Of Func(Of Order, Boolean)))
            Dim repo = GetRepo()
            
       
            
            repo.DeleteMany(expression)
            
        End Sub

        

        Public Sub Load(rdr As IDataReader) Implements IActiveRecord.Load
            Load(rdr, true)
        End Sub
        Public Sub Load(rdr As IDataReader, closeReader As Boolean) Implements IActiveRecord.Load
            If rdr.Read() Then
                Try
                    rdr.Load(Me)
                    _isNew = False
                    _isLoaded = True
                Catch
                    _isLoaded = False
                    Throw
                End Try
            Else
                _isLoaded = False
            End If

            If closeReader Then rdr.Dispose()

        End Sub
	End Class
    
    
    ''' <summary>
    ''' A class which represents the Products table in the Northwind Database.
    ''' </summary>
    Public Partial Class Product
		Implements IActiveRecord

		' Built-in testing
        Shared TestItems As IList(Of Product)
        Shared _testRepo As TestRepository(Of Product)
        Public Sub SetIsLoaded(isLoaded As Boolean) Implements IActiveRecord.SetIsLoaded
            _isLoaded = isLoaded
        End Sub
        Private Shared Sub SetTestRepo()
			iF _testRepo Is Nothing Then _testRepo = New TestRepository(Of Product)(New Southwind.NorthwindDB())
        End Sub
        Public Shared Sub ResetTestRepo()
            _testRepo = Nothing
            SetTestRepo()
        End Sub
        Public Shared Sub Setup(testlist As List(Of Product))
            SetTestRepo()
            _testRepo._items = testlist
        End Sub
        Public Shared Sub Setup(item As Product)
            SetTestRepo()
            _testRepo._items.Add(item)
        End Sub
        Public Shared Sub Setup(testItems As Integer)
            SetTestRepo()
            For i As Integer = 0 To testItems - 1
                Dim item As New Product()
                _testRepo._items.Add(item)
            Next i
        End Sub
        
        Public TestMode As Boolean = False



        Private _repo As IRepository(Of Product)
        Private tbl As ITable
        Private _isNew As Boolean
        Public Function IsNew() As Boolean Implements IActiveRecord.IsNew
            Return _isNew
        End Function
        Public Sub SetIsNew(isNew As Boolean) Implements IActiveRecord.SetIsNew
            _isNew=isNew
        End Sub
        Private _isLoaded As Boolean
        Public Function IsLoaded() As Boolean Implements IActiveRecord.IsLoaded
            Return _isLoaded
        End Function
                
        Private _dirtyColumns As List(Of IColumn)
        Public Function IsDirty() As Boolean Implements IActiveRecord.IsDirty
            Return _dirtyColumns.Count > 0
        End Function
        
        Public Function GetDirtyColumns() As List(Of IColumn) Implements IActiveRecord.GetDirtyColumns
            Return _dirtyColumns
        End Function

        Private _db As Southwind.NorthwindDB
        Public Sub New(connectionString As String, providerName As String)
            _db = New Southwind.NorthwindDB(connectionString, providerName)
            Init()            
         End Sub
        Private Sub Init()
            TestMode = Me._db.Provider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase)
            _dirtyColumns = New List(Of IColumn)()
            If TestMode Then
                Product.SetTestRepo()
                _repo=_testRepo
            Else
                _repo = New SubSonicRepository(Of Product)(_db)
            End If
            tbl=_repo.GetTable()
            _isNew = True
            OnCreated()       
      
        End Sub
        
        Public Sub New()
             _db = New Southwind.NorthwindDB()
            Init()            
        End Sub
        
       
        Private Partial Sub OnCreated()
		End Sub
            
        Private Partial Sub OnLoaded()
		End Sub
        
		Private Partial Sub OnSaved()
		End Sub
        
		Private Partial Sub OnChanged()
		End Sub

		Public ReadOnly Property Columns As IList(Of IColumn)
            Get
                Return tbl.Columns
            End Get
        End Property

        Public Sub New(expression As Expression(Of Func(Of Product, Boolean)))
			MyBase.New()
            _isLoaded=_repo.Load(Me,expression)
            If _isLoaded Then OnLoaded()
        End Sub
        
       
        
        Friend Shared Function GetRepo(connectionString As String, providerName As String) As IRepository(Of Product)
            Dim db As Southwind.NorthwindDB
            If String.IsNullOrEmpty(connectionString)
                db = New Southwind.NorthwindDB()
            Else
                db = New Southwind.NorthwindDB(connectionString, providerName)
            End If
            Dim _repo As IRepository(Of Product)
            
            If db.TestMode Then
                Product.SetTestRepo()
                _repo = _testRepo
            Else
                _repo = New SubSonicRepository(Of Product)(db)
            End If
            Return _repo
        End Function
        
        Friend Shared Function GetRepo() As IRepository(Of Product)
            Return GetRepo(String.Empty,String.Empty)
        End Function
        
        Public Shared Function SingleOrDefault(expression As Expression(Of Func(Of Product, Boolean))) As Product

            Dim repo = GetRepo()
            Dim results = repo.Find(expression)
            Dim singleItem As Product = Nothing
            If results.Count() > 0 Then
                singleItem = results.ToList()(0)
                singleItem.OnLoaded()
                singleItem.SetIsLoaded(true)
            End If

            Return singleItem
        End Function  
        
        Public Shared Function SingleOrDefault(expression As Expression(Of Func(Of Product, Boolean)), _
											   connectionString As String, _
											   providerName As String) As Product
			Dim repo = GetRepo(connectionString,providerName)
            Dim results = repo.Find(expression)
            Dim singleItem As Product = Nothing
            If results.Count() > 0 Then
                singleItem = results.ToList()(0)
                singleItem.OnLoaded()
                singleItem.SetIsLoaded(true)
            End If

            Return singleItem
		End Function
        
        
        Public Shared Function Exists(expression As Expression(Of Func(Of Product, Boolean)), connectionString As String, providerName As String) As Boolean
        	Return All(connectionString,providerName).Any(expression)
        End Function
		
        Public Shared Function Exists(expression As Expression(Of Func(Of Product, Boolean))) As Boolean
            Return All().Any(expression)
        End Function        

        Public Shared Function Find(expression As Expression(Of Func(Of Product, Boolean))) As IList(Of Product)
            Dim repo = GetRepo()
            Return repo.Find(expression).ToList()
        End Function
        
        Public Shared Function Find(expression As Expression(Of Func(Of Product, Boolean)), connectionString As String, providerName As String) As IList(Of Product)
            Dim repo = GetRepo(connectionString,providerName)
            Return repo.Find(expression).ToList()
        End Function
        Public Shared Function All(connectionString As String, providerName As String) As IQueryable(Of Product)
            Return GetRepo(connectionString,providerName).GetAll()
        End Function
        Public Shared Function All() As IQueryable(Of Product)
            Return GetRepo().GetAll()
        End Function
        
        Public Shared Function GetPaged(sortBy As String, pageIndex As Integer, pageSize As Integer, connectionString As String, providerName As String) As PagedList(Of Product)
            Return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize)
        End Function
      
        Public Shared Function GetPaged(sortBy As String, pageIndex As Integer, pageSize As Integer) As PagedList(Of Product)
            Return GetRepo().GetPaged(sortBy, pageIndex, pageSize)
        End Function

        Public Shared Function GetPaged(pageIndex As Integer, pageSize As Integer, connectionString As String, providerName As String) As PagedList(Of Product)
            Return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize)
        End Function

        Public Shared Function GetPaged(pageIndex As Integer, pageSize As Integer) As PagedList(Of Product)
            Return GetRepo().GetPaged(pageIndex, pageSize)
        End Function

        Public Function KeyName() As String Implements IActiveRecord.KeyName
            Return "ProductID"
        End Function

        Public Function KeyValue() As Object Implements IActiveRecord.KeyValue
            Return Me.ProductID
        End Function
        
        Public Sub SetKeyValue(value As Object) Implements IActiveRecord.SetKeyValue
            If value IsNot Nothing AndAlso value IsNot DBNull.Value Then
                Dim settable = value.ChangeTypeTo(Of Integer)()
                Me.GetType.GetProperty(Me.KeyName()).SetValue(Me, settable, Nothing)
            End If
        End Sub
        
        Public Overrides Function ToString() As String
            Return Me.ProductName.ToString()
        End Function

        Public Overrides Function Equals(obj As Object) As Boolean
            If obj.GetType() Is GetType(Product) Then
                Dim compareItem As Product = obj
                Return compareItem.KeyValue() = Me.KeyValue()
            Else
                Return MyBase.Equals(obj)
            End If
        End Function

        Public Function DescriptorValue() As String Implements IActiveRecord.DescriptorValue
            Return Me.ProductName.ToString()
        End Function

        Public Function DescriptorColumn() As String Implements IActiveRecord.DescriptorColumn
            Return "ProductName"
        End Function
        Public Shared Function GetKeyColumn() As String 
            Return "ProductID"
        End Function
        Public Shared Function GetDescriptorColumn() As String
            Return "ProductName"
        End Function
        
       #Region " Foreign Keys "
        Public ReadOnly Property [Categories] As IQueryable(Of Category)
            Get
                  Dim repo = Southwind.Category.GetRepo()
                  Return From items In repo.GetAll() _
                       	Where items.CategoryID = _CategoryID _
                       Select items
            End Get
        End Property

        Public ReadOnly Property [OrderDetails] As IQueryable(Of OrderDetail)
            Get
                  Dim repo = Southwind.OrderDetail.GetRepo()
                  Return From items In repo.GetAll() _
                       	Where items.ProductID = _ProductID _
                       Select items
            End Get
        End Property

        Public ReadOnly Property [Suppliers] As IQueryable(Of Supplier)
            Get
                  Dim repo = Southwind.Supplier.GetRepo()
                  Return From items In repo.GetAll() _
                       	Where items.SupplierID = _SupplierID _
                       Select items
            End Get
        End Property

        #End Region

        Private _ProductID As Integer
        Public Property [ProductID] As Integer
            Get
				Return _ProductID
			End Get
            Set(value As Integer)
                _ProductID = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "ProductID")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _ProductName As String
        Public Property [ProductName] As String
            Get
				Return _ProductName
			End Get
            Set(value As String)
                _ProductName = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "ProductName")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _SupplierID As Integer?
        Public Property [SupplierID] As Integer?
            Get
				Return _SupplierID
			End Get
            Set(value As Integer?)
                _SupplierID = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "SupplierID")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _CategoryID As Integer?
        Public Property [CategoryID] As Integer?
            Get
				Return _CategoryID
			End Get
            Set(value As Integer?)
                _CategoryID = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "CategoryID")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _QuantityPerUnit As String
        Public Property [QuantityPerUnit] As String
            Get
				Return _QuantityPerUnit
			End Get
            Set(value As String)
                _QuantityPerUnit = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "QuantityPerUnit")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _UnitPrice As Decimal?
        Public Property [UnitPrice] As Decimal?
            Get
				Return _UnitPrice
			End Get
            Set(value As Decimal?)
                _UnitPrice = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "UnitPrice")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _UnitsInStock As Short?
        Public Property [UnitsInStock] As Short?
            Get
				Return _UnitsInStock
			End Get
            Set(value As Short?)
                _UnitsInStock = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "UnitsInStock")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _UnitsOnOrder As Short?
        Public Property [UnitsOnOrder] As Short?
            Get
				Return _UnitsOnOrder
			End Get
            Set(value As Short?)
                _UnitsOnOrder = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "UnitsOnOrder")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _ReorderLevel As Short?
        Public Property [ReorderLevel] As Short?
            Get
				Return _ReorderLevel
			End Get
            Set(value As Short?)
                _ReorderLevel = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "ReorderLevel")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _Discontinued As Boolean
        Public Property [Discontinued] As Boolean
            Get
				Return _Discontinued
			End Get
            Set(value As Boolean)
                _Discontinued = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "Discontinued")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property



        Public Function GetUpdateCommand() As DbCommand Implements IActiveRecord.GetUpdateCommand
            If TestMode Then
                Return _db.Provider.CreateCommand()
            Else
                Return Me.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand()
            End If
        End Function
        Public Function GetInsertCommand() As DbCommand Implements IActiveRecord.GetInsertCommand
            If TestMode Then
                Return _db.Provider.CreateCommand()
            Else
                Return Me.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand()
			End If
        End Function
        
        Public Function GetDeleteCommand() As DbCommand Implements IActiveRecord.GetDeleteCommand
            If TestMode Then
                Return _db.Provider.CreateCommand()
            Else
                Return Me.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand()
			End If
        End Function
       
        
        Public Sub Update() Implements IActiveRecord.Update
            Update(_db.Provider)
        End Sub
        
        Public Sub Update(provider As IDataProvider) Implements IActiveRecord.Update
        
            If Me._dirtyColumns.Count > 0 Then _repo.Update(Me,provider)
			
            OnSaved()
        End Sub
 
        Public Sub Add() Implements IActiveRecord.Add
            Add(_db.Provider)
        End Sub
        
        
       
        Public Sub Add(provider As IDataProvider) Implements IActiveRecord.Add

            Me.SetKeyValue(_repo.Add(Me,provider))
            OnSaved()
        End Sub
        
                
        
        Public Sub Save() Implements IActiveRecord.Save
            Save(_db.Provider)
        End Sub
        Public Sub Save(provider As IDataProvider) Implements IActiveRecord.Save
            If _isNew Then
                Add(provider)
            Else
                Update(provider)
			End If
        End Sub

        

        Public Sub Delete(provider As IDataProvider)
                   
                 
            _repo.Delete(KeyValue())
            
                    End Sub


        Public Sub Delete() Implements IActiveRecord.Delete
            Delete(_db.Provider)
        End Sub


        Public Shared Sub Delete(expression As Expression(Of Func(Of Product, Boolean)))
            Dim repo = GetRepo()
            
       
            
            repo.DeleteMany(expression)
            
        End Sub

        

        Public Sub Load(rdr As IDataReader) Implements IActiveRecord.Load
            Load(rdr, true)
        End Sub
        Public Sub Load(rdr As IDataReader, closeReader As Boolean) Implements IActiveRecord.Load
            If rdr.Read() Then
                Try
                    rdr.Load(Me)
                    _isNew = False
                    _isLoaded = True
                Catch
                    _isLoaded = False
                    Throw
                End Try
            Else
                _isLoaded = False
            End If

            If closeReader Then rdr.Dispose()

        End Sub
	End Class
    
    
    ''' <summary>
    ''' A class which represents the Order Details table in the Northwind Database.
    ''' </summary>
    Public Partial Class OrderDetail
		Implements IActiveRecord

		' Built-in testing
        Shared TestItems As IList(Of OrderDetail)
        Shared _testRepo As TestRepository(Of OrderDetail)
        Public Sub SetIsLoaded(isLoaded As Boolean) Implements IActiveRecord.SetIsLoaded
            _isLoaded = isLoaded
        End Sub
        Private Shared Sub SetTestRepo()
			iF _testRepo Is Nothing Then _testRepo = New TestRepository(Of OrderDetail)(New Southwind.NorthwindDB())
        End Sub
        Public Shared Sub ResetTestRepo()
            _testRepo = Nothing
            SetTestRepo()
        End Sub
        Public Shared Sub Setup(testlist As List(Of OrderDetail))
            SetTestRepo()
            _testRepo._items = testlist
        End Sub
        Public Shared Sub Setup(item As OrderDetail)
            SetTestRepo()
            _testRepo._items.Add(item)
        End Sub
        Public Shared Sub Setup(testItems As Integer)
            SetTestRepo()
            For i As Integer = 0 To testItems - 1
                Dim item As New OrderDetail()
                _testRepo._items.Add(item)
            Next i
        End Sub
        
        Public TestMode As Boolean = False



        Private _repo As IRepository(Of OrderDetail)
        Private tbl As ITable
        Private _isNew As Boolean
        Public Function IsNew() As Boolean Implements IActiveRecord.IsNew
            Return _isNew
        End Function
        Public Sub SetIsNew(isNew As Boolean) Implements IActiveRecord.SetIsNew
            _isNew=isNew
        End Sub
        Private _isLoaded As Boolean
        Public Function IsLoaded() As Boolean Implements IActiveRecord.IsLoaded
            Return _isLoaded
        End Function
                
        Private _dirtyColumns As List(Of IColumn)
        Public Function IsDirty() As Boolean Implements IActiveRecord.IsDirty
            Return _dirtyColumns.Count > 0
        End Function
        
        Public Function GetDirtyColumns() As List(Of IColumn) Implements IActiveRecord.GetDirtyColumns
            Return _dirtyColumns
        End Function

        Private _db As Southwind.NorthwindDB
        Public Sub New(connectionString As String, providerName As String)
            _db = New Southwind.NorthwindDB(connectionString, providerName)
            Init()            
         End Sub
        Private Sub Init()
            TestMode = Me._db.Provider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase)
            _dirtyColumns = New List(Of IColumn)()
            If TestMode Then
                OrderDetail.SetTestRepo()
                _repo=_testRepo
            Else
                _repo = New SubSonicRepository(Of OrderDetail)(_db)
            End If
            tbl=_repo.GetTable()
            _isNew = True
            OnCreated()       
      
        End Sub
        
        Public Sub New()
             _db = New Southwind.NorthwindDB()
            Init()            
        End Sub
        
       
        Private Partial Sub OnCreated()
		End Sub
            
        Private Partial Sub OnLoaded()
		End Sub
        
		Private Partial Sub OnSaved()
		End Sub
        
		Private Partial Sub OnChanged()
		End Sub

		Public ReadOnly Property Columns As IList(Of IColumn)
            Get
                Return tbl.Columns
            End Get
        End Property

        Public Sub New(expression As Expression(Of Func(Of OrderDetail, Boolean)))
			MyBase.New()
            _isLoaded=_repo.Load(Me,expression)
            If _isLoaded Then OnLoaded()
        End Sub
        
       
        
        Friend Shared Function GetRepo(connectionString As String, providerName As String) As IRepository(Of OrderDetail)
            Dim db As Southwind.NorthwindDB
            If String.IsNullOrEmpty(connectionString)
                db = New Southwind.NorthwindDB()
            Else
                db = New Southwind.NorthwindDB(connectionString, providerName)
            End If
            Dim _repo As IRepository(Of OrderDetail)
            
            If db.TestMode Then
                OrderDetail.SetTestRepo()
                _repo = _testRepo
            Else
                _repo = New SubSonicRepository(Of OrderDetail)(db)
            End If
            Return _repo
        End Function
        
        Friend Shared Function GetRepo() As IRepository(Of OrderDetail)
            Return GetRepo(String.Empty,String.Empty)
        End Function
        
        Public Shared Function SingleOrDefault(expression As Expression(Of Func(Of OrderDetail, Boolean))) As OrderDetail

            Dim repo = GetRepo()
            Dim results = repo.Find(expression)
            Dim singleItem As OrderDetail = Nothing
            If results.Count() > 0 Then
                singleItem = results.ToList()(0)
                singleItem.OnLoaded()
                singleItem.SetIsLoaded(true)
            End If

            Return singleItem
        End Function  
        
        Public Shared Function SingleOrDefault(expression As Expression(Of Func(Of OrderDetail, Boolean)), _
											   connectionString As String, _
											   providerName As String) As OrderDetail
			Dim repo = GetRepo(connectionString,providerName)
            Dim results = repo.Find(expression)
            Dim singleItem As OrderDetail = Nothing
            If results.Count() > 0 Then
                singleItem = results.ToList()(0)
                singleItem.OnLoaded()
                singleItem.SetIsLoaded(true)
            End If

            Return singleItem
		End Function
        
        
        Public Shared Function Exists(expression As Expression(Of Func(Of OrderDetail, Boolean)), connectionString As String, providerName As String) As Boolean
        	Return All(connectionString,providerName).Any(expression)
        End Function
		
        Public Shared Function Exists(expression As Expression(Of Func(Of OrderDetail, Boolean))) As Boolean
            Return All().Any(expression)
        End Function        

        Public Shared Function Find(expression As Expression(Of Func(Of OrderDetail, Boolean))) As IList(Of OrderDetail)
            Dim repo = GetRepo()
            Return repo.Find(expression).ToList()
        End Function
        
        Public Shared Function Find(expression As Expression(Of Func(Of OrderDetail, Boolean)), connectionString As String, providerName As String) As IList(Of OrderDetail)
            Dim repo = GetRepo(connectionString,providerName)
            Return repo.Find(expression).ToList()
        End Function
        Public Shared Function All(connectionString As String, providerName As String) As IQueryable(Of OrderDetail)
            Return GetRepo(connectionString,providerName).GetAll()
        End Function
        Public Shared Function All() As IQueryable(Of OrderDetail)
            Return GetRepo().GetAll()
        End Function
        
        Public Shared Function GetPaged(sortBy As String, pageIndex As Integer, pageSize As Integer, connectionString As String, providerName As String) As PagedList(Of OrderDetail)
            Return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize)
        End Function
      
        Public Shared Function GetPaged(sortBy As String, pageIndex As Integer, pageSize As Integer) As PagedList(Of OrderDetail)
            Return GetRepo().GetPaged(sortBy, pageIndex, pageSize)
        End Function

        Public Shared Function GetPaged(pageIndex As Integer, pageSize As Integer, connectionString As String, providerName As String) As PagedList(Of OrderDetail)
            Return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize)
        End Function

        Public Shared Function GetPaged(pageIndex As Integer, pageSize As Integer) As PagedList(Of OrderDetail)
            Return GetRepo().GetPaged(pageIndex, pageSize)
        End Function

        Public Function KeyName() As String Implements IActiveRecord.KeyName
            Return "OrderID"
        End Function

        Public Function KeyValue() As Object Implements IActiveRecord.KeyValue
            Return Me.OrderID
        End Function
        
        Public Sub SetKeyValue(value As Object) Implements IActiveRecord.SetKeyValue
            If value IsNot Nothing AndAlso value IsNot DBNull.Value Then
                Dim settable = value.ChangeTypeTo(Of Integer)()
                Me.GetType.GetProperty(Me.KeyName()).SetValue(Me, settable, Nothing)
            End If
        End Sub
        
        Public Overrides Function ToString() As String
            Return Me.ProductID.ToString()
        End Function

        Public Overrides Function Equals(obj As Object) As Boolean
            If obj.GetType() Is GetType(OrderDetail) Then
                Dim compareItem As OrderDetail = obj
                Return compareItem.KeyValue() = Me.KeyValue()
            Else
                Return MyBase.Equals(obj)
            End If
        End Function

        Public Function DescriptorValue() As String Implements IActiveRecord.DescriptorValue
            Return Me.ProductID.ToString()
        End Function

        Public Function DescriptorColumn() As String Implements IActiveRecord.DescriptorColumn
            Return "ProductID"
        End Function
        Public Shared Function GetKeyColumn() As String 
            Return "OrderID"
        End Function
        Public Shared Function GetDescriptorColumn() As String
            Return "ProductID"
        End Function
        
       #Region " Foreign Keys "
        Public ReadOnly Property [Orders] As IQueryable(Of Order)
            Get
                  Dim repo = Southwind.Order.GetRepo()
                  Return From items In repo.GetAll() _
                       	Where items.OrderID = _OrderID _
                       Select items
            End Get
        End Property

        Public ReadOnly Property [Products] As IQueryable(Of Product)
            Get
                  Dim repo = Southwind.Product.GetRepo()
                  Return From items In repo.GetAll() _
                       	Where items.ProductID = _ProductID _
                       Select items
            End Get
        End Property

        #End Region

        Private _OrderID As Integer
        Public Property [OrderID] As Integer
            Get
				Return _OrderID
			End Get
            Set(value As Integer)
                _OrderID = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "OrderID")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _ProductID As Integer
        Public Property [ProductID] As Integer
            Get
				Return _ProductID
			End Get
            Set(value As Integer)
                _ProductID = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "ProductID")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _UnitPrice As Decimal
        Public Property [UnitPrice] As Decimal
            Get
				Return _UnitPrice
			End Get
            Set(value As Decimal)
                _UnitPrice = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "UnitPrice")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _Quantity As Short
        Public Property [Quantity] As Short
            Get
				Return _Quantity
			End Get
            Set(value As Short)
                _Quantity = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "Quantity")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _Discount As Decimal
        Public Property [Discount] As Decimal
            Get
				Return _Discount
			End Get
            Set(value As Decimal)
                _Discount = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "Discount")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property



        Public Function GetUpdateCommand() As DbCommand Implements IActiveRecord.GetUpdateCommand
            If TestMode Then
                Return _db.Provider.CreateCommand()
            Else
                Return Me.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand()
            End If
        End Function
        Public Function GetInsertCommand() As DbCommand Implements IActiveRecord.GetInsertCommand
            If TestMode Then
                Return _db.Provider.CreateCommand()
            Else
                Return Me.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand()
			End If
        End Function
        
        Public Function GetDeleteCommand() As DbCommand Implements IActiveRecord.GetDeleteCommand
            If TestMode Then
                Return _db.Provider.CreateCommand()
            Else
                Return Me.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand()
			End If
        End Function
       
        
        Public Sub Update() Implements IActiveRecord.Update
            Update(_db.Provider)
        End Sub
        
        Public Sub Update(provider As IDataProvider) Implements IActiveRecord.Update
        
            If Me._dirtyColumns.Count > 0 Then _repo.Update(Me,provider)
			
            OnSaved()
        End Sub
 
        Public Sub Add() Implements IActiveRecord.Add
            Add(_db.Provider)
        End Sub
        
        
       
        Public Sub Add(provider As IDataProvider) Implements IActiveRecord.Add

            Me.SetKeyValue(_repo.Add(Me,provider))
            OnSaved()
        End Sub
        
                
        
        Public Sub Save() Implements IActiveRecord.Save
            Save(_db.Provider)
        End Sub
        Public Sub Save(provider As IDataProvider) Implements IActiveRecord.Save
            If _isNew Then
                Add(provider)
            Else
                Update(provider)
			End If
        End Sub

        

        Public Sub Delete(provider As IDataProvider)
                   
                 
            _repo.Delete(KeyValue())
            
                    End Sub


        Public Sub Delete() Implements IActiveRecord.Delete
            Delete(_db.Provider)
        End Sub


        Public Shared Sub Delete(expression As Expression(Of Func(Of OrderDetail, Boolean)))
            Dim repo = GetRepo()
            
       
            
            repo.DeleteMany(expression)
            
        End Sub

        

        Public Sub Load(rdr As IDataReader) Implements IActiveRecord.Load
            Load(rdr, true)
        End Sub
        Public Sub Load(rdr As IDataReader, closeReader As Boolean) Implements IActiveRecord.Load
            If rdr.Read() Then
                Try
                    rdr.Load(Me)
                    _isNew = False
                    _isLoaded = True
                Catch
                    _isLoaded = False
                    Throw
                End Try
            Else
                _isLoaded = False
            End If

            If closeReader Then rdr.Dispose()

        End Sub
	End Class
    
    
    ''' <summary>
    ''' A class which represents the CustomerCustomerDemo table in the Northwind Database.
    ''' </summary>
    Public Partial Class CustomerCustomerDemo
		Implements IActiveRecord

		' Built-in testing
        Shared TestItems As IList(Of CustomerCustomerDemo)
        Shared _testRepo As TestRepository(Of CustomerCustomerDemo)
        Public Sub SetIsLoaded(isLoaded As Boolean) Implements IActiveRecord.SetIsLoaded
            _isLoaded = isLoaded
        End Sub
        Private Shared Sub SetTestRepo()
			iF _testRepo Is Nothing Then _testRepo = New TestRepository(Of CustomerCustomerDemo)(New Southwind.NorthwindDB())
        End Sub
        Public Shared Sub ResetTestRepo()
            _testRepo = Nothing
            SetTestRepo()
        End Sub
        Public Shared Sub Setup(testlist As List(Of CustomerCustomerDemo))
            SetTestRepo()
            _testRepo._items = testlist
        End Sub
        Public Shared Sub Setup(item As CustomerCustomerDemo)
            SetTestRepo()
            _testRepo._items.Add(item)
        End Sub
        Public Shared Sub Setup(testItems As Integer)
            SetTestRepo()
            For i As Integer = 0 To testItems - 1
                Dim item As New CustomerCustomerDemo()
                _testRepo._items.Add(item)
            Next i
        End Sub
        
        Public TestMode As Boolean = False



        Private _repo As IRepository(Of CustomerCustomerDemo)
        Private tbl As ITable
        Private _isNew As Boolean
        Public Function IsNew() As Boolean Implements IActiveRecord.IsNew
            Return _isNew
        End Function
        Public Sub SetIsNew(isNew As Boolean) Implements IActiveRecord.SetIsNew
            _isNew=isNew
        End Sub
        Private _isLoaded As Boolean
        Public Function IsLoaded() As Boolean Implements IActiveRecord.IsLoaded
            Return _isLoaded
        End Function
                
        Private _dirtyColumns As List(Of IColumn)
        Public Function IsDirty() As Boolean Implements IActiveRecord.IsDirty
            Return _dirtyColumns.Count > 0
        End Function
        
        Public Function GetDirtyColumns() As List(Of IColumn) Implements IActiveRecord.GetDirtyColumns
            Return _dirtyColumns
        End Function

        Private _db As Southwind.NorthwindDB
        Public Sub New(connectionString As String, providerName As String)
            _db = New Southwind.NorthwindDB(connectionString, providerName)
            Init()            
         End Sub
        Private Sub Init()
            TestMode = Me._db.Provider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase)
            _dirtyColumns = New List(Of IColumn)()
            If TestMode Then
                CustomerCustomerDemo.SetTestRepo()
                _repo=_testRepo
            Else
                _repo = New SubSonicRepository(Of CustomerCustomerDemo)(_db)
            End If
            tbl=_repo.GetTable()
            _isNew = True
            OnCreated()       
      
        End Sub
        
        Public Sub New()
             _db = New Southwind.NorthwindDB()
            Init()            
        End Sub
        
       
        Private Partial Sub OnCreated()
		End Sub
            
        Private Partial Sub OnLoaded()
		End Sub
        
		Private Partial Sub OnSaved()
		End Sub
        
		Private Partial Sub OnChanged()
		End Sub

		Public ReadOnly Property Columns As IList(Of IColumn)
            Get
                Return tbl.Columns
            End Get
        End Property

        Public Sub New(expression As Expression(Of Func(Of CustomerCustomerDemo, Boolean)))
			MyBase.New()
            _isLoaded=_repo.Load(Me,expression)
            If _isLoaded Then OnLoaded()
        End Sub
        
       
        
        Friend Shared Function GetRepo(connectionString As String, providerName As String) As IRepository(Of CustomerCustomerDemo)
            Dim db As Southwind.NorthwindDB
            If String.IsNullOrEmpty(connectionString)
                db = New Southwind.NorthwindDB()
            Else
                db = New Southwind.NorthwindDB(connectionString, providerName)
            End If
            Dim _repo As IRepository(Of CustomerCustomerDemo)
            
            If db.TestMode Then
                CustomerCustomerDemo.SetTestRepo()
                _repo = _testRepo
            Else
                _repo = New SubSonicRepository(Of CustomerCustomerDemo)(db)
            End If
            Return _repo
        End Function
        
        Friend Shared Function GetRepo() As IRepository(Of CustomerCustomerDemo)
            Return GetRepo(String.Empty,String.Empty)
        End Function
        
        Public Shared Function SingleOrDefault(expression As Expression(Of Func(Of CustomerCustomerDemo, Boolean))) As CustomerCustomerDemo

            Dim repo = GetRepo()
            Dim results = repo.Find(expression)
            Dim singleItem As CustomerCustomerDemo = Nothing
            If results.Count() > 0 Then
                singleItem = results.ToList()(0)
                singleItem.OnLoaded()
                singleItem.SetIsLoaded(true)
            End If

            Return singleItem
        End Function  
        
        Public Shared Function SingleOrDefault(expression As Expression(Of Func(Of CustomerCustomerDemo, Boolean)), _
											   connectionString As String, _
											   providerName As String) As CustomerCustomerDemo
			Dim repo = GetRepo(connectionString,providerName)
            Dim results = repo.Find(expression)
            Dim singleItem As CustomerCustomerDemo = Nothing
            If results.Count() > 0 Then
                singleItem = results.ToList()(0)
                singleItem.OnLoaded()
                singleItem.SetIsLoaded(true)
            End If

            Return singleItem
		End Function
        
        
        Public Shared Function Exists(expression As Expression(Of Func(Of CustomerCustomerDemo, Boolean)), connectionString As String, providerName As String) As Boolean
        	Return All(connectionString,providerName).Any(expression)
        End Function
		
        Public Shared Function Exists(expression As Expression(Of Func(Of CustomerCustomerDemo, Boolean))) As Boolean
            Return All().Any(expression)
        End Function        

        Public Shared Function Find(expression As Expression(Of Func(Of CustomerCustomerDemo, Boolean))) As IList(Of CustomerCustomerDemo)
            Dim repo = GetRepo()
            Return repo.Find(expression).ToList()
        End Function
        
        Public Shared Function Find(expression As Expression(Of Func(Of CustomerCustomerDemo, Boolean)), connectionString As String, providerName As String) As IList(Of CustomerCustomerDemo)
            Dim repo = GetRepo(connectionString,providerName)
            Return repo.Find(expression).ToList()
        End Function
        Public Shared Function All(connectionString As String, providerName As String) As IQueryable(Of CustomerCustomerDemo)
            Return GetRepo(connectionString,providerName).GetAll()
        End Function
        Public Shared Function All() As IQueryable(Of CustomerCustomerDemo)
            Return GetRepo().GetAll()
        End Function
        
        Public Shared Function GetPaged(sortBy As String, pageIndex As Integer, pageSize As Integer, connectionString As String, providerName As String) As PagedList(Of CustomerCustomerDemo)
            Return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize)
        End Function
      
        Public Shared Function GetPaged(sortBy As String, pageIndex As Integer, pageSize As Integer) As PagedList(Of CustomerCustomerDemo)
            Return GetRepo().GetPaged(sortBy, pageIndex, pageSize)
        End Function

        Public Shared Function GetPaged(pageIndex As Integer, pageSize As Integer, connectionString As String, providerName As String) As PagedList(Of CustomerCustomerDemo)
            Return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize)
        End Function

        Public Shared Function GetPaged(pageIndex As Integer, pageSize As Integer) As PagedList(Of CustomerCustomerDemo)
            Return GetRepo().GetPaged(pageIndex, pageSize)
        End Function

        Public Function KeyName() As String Implements IActiveRecord.KeyName
            Return "CustomerID"
        End Function

        Public Function KeyValue() As Object Implements IActiveRecord.KeyValue
            Return Me.CustomerID
        End Function
        
        Public Sub SetKeyValue(value As Object) Implements IActiveRecord.SetKeyValue
            If value IsNot Nothing AndAlso value IsNot DBNull.Value Then
                Dim settable = value.ChangeTypeTo(Of String)()
                Me.GetType.GetProperty(Me.KeyName()).SetValue(Me, settable, Nothing)
            End If
        End Sub
        
        Public Overrides Function ToString() As String
            Return Me.CustomerID.ToString()
        End Function

        Public Overrides Function Equals(obj As Object) As Boolean
            If obj.GetType() Is GetType(CustomerCustomerDemo) Then
                Dim compareItem As CustomerCustomerDemo = obj
                Return compareItem.KeyValue() = Me.KeyValue()
            Else
                Return MyBase.Equals(obj)
            End If
        End Function

        Public Function DescriptorValue() As String Implements IActiveRecord.DescriptorValue
            Return Me.CustomerID.ToString()
        End Function

        Public Function DescriptorColumn() As String Implements IActiveRecord.DescriptorColumn
            Return "CustomerID"
        End Function
        Public Shared Function GetKeyColumn() As String 
            Return "CustomerID"
        End Function
        Public Shared Function GetDescriptorColumn() As String
            Return "CustomerID"
        End Function
        
       #Region " Foreign Keys "
        Public ReadOnly Property [CustomerDemographics] As IQueryable(Of CustomerDemographic)
            Get
                  Dim repo = Southwind.CustomerDemographic.GetRepo()
                  Return From items In repo.GetAll() _
                       	Where items.CustomerTypeID = _CustomerTypeID _
                       Select items
            End Get
        End Property

        Public ReadOnly Property [Customers] As IQueryable(Of Customer)
            Get
                  Dim repo = Southwind.Customer.GetRepo()
                  Return From items In repo.GetAll() _
                       	Where items.CustomerID = _CustomerID _
                       Select items
            End Get
        End Property

        #End Region

        Private _CustomerID As String
        Public Property [CustomerID] As String
            Get
				Return _CustomerID
			End Get
            Set(value As String)
                _CustomerID = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "CustomerID")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _CustomerTypeID As String
        Public Property [CustomerTypeID] As String
            Get
				Return _CustomerTypeID
			End Get
            Set(value As String)
                _CustomerTypeID = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "CustomerTypeID")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property



        Public Function GetUpdateCommand() As DbCommand Implements IActiveRecord.GetUpdateCommand
            If TestMode Then
                Return _db.Provider.CreateCommand()
            Else
                Return Me.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand()
            End If
        End Function
        Public Function GetInsertCommand() As DbCommand Implements IActiveRecord.GetInsertCommand
            If TestMode Then
                Return _db.Provider.CreateCommand()
            Else
                Return Me.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand()
			End If
        End Function
        
        Public Function GetDeleteCommand() As DbCommand Implements IActiveRecord.GetDeleteCommand
            If TestMode Then
                Return _db.Provider.CreateCommand()
            Else
                Return Me.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand()
			End If
        End Function
       
        
        Public Sub Update() Implements IActiveRecord.Update
            Update(_db.Provider)
        End Sub
        
        Public Sub Update(provider As IDataProvider) Implements IActiveRecord.Update
        
            If Me._dirtyColumns.Count > 0 Then _repo.Update(Me,provider)
			
            OnSaved()
        End Sub
 
        Public Sub Add() Implements IActiveRecord.Add
            Add(_db.Provider)
        End Sub
        
        
       
        Public Sub Add(provider As IDataProvider) Implements IActiveRecord.Add

            Me.SetKeyValue(_repo.Add(Me,provider))
            OnSaved()
        End Sub
        
                
        
        Public Sub Save() Implements IActiveRecord.Save
            Save(_db.Provider)
        End Sub
        Public Sub Save(provider As IDataProvider) Implements IActiveRecord.Save
            If _isNew Then
                Add(provider)
            Else
                Update(provider)
			End If
        End Sub

        

        Public Sub Delete(provider As IDataProvider)
                   
                 
            _repo.Delete(KeyValue())
            
                    End Sub


        Public Sub Delete() Implements IActiveRecord.Delete
            Delete(_db.Provider)
        End Sub


        Public Shared Sub Delete(expression As Expression(Of Func(Of CustomerCustomerDemo, Boolean)))
            Dim repo = GetRepo()
            
       
            
            repo.DeleteMany(expression)
            
        End Sub

        

        Public Sub Load(rdr As IDataReader) Implements IActiveRecord.Load
            Load(rdr, true)
        End Sub
        Public Sub Load(rdr As IDataReader, closeReader As Boolean) Implements IActiveRecord.Load
            If rdr.Read() Then
                Try
                    rdr.Load(Me)
                    _isNew = False
                    _isLoaded = True
                Catch
                    _isLoaded = False
                    Throw
                End Try
            Else
                _isLoaded = False
            End If

            If closeReader Then rdr.Dispose()

        End Sub
	End Class
    
    
    ''' <summary>
    ''' A class which represents the CustomerDemographics table in the Northwind Database.
    ''' </summary>
    Public Partial Class CustomerDemographic
		Implements IActiveRecord

		' Built-in testing
        Shared TestItems As IList(Of CustomerDemographic)
        Shared _testRepo As TestRepository(Of CustomerDemographic)
        Public Sub SetIsLoaded(isLoaded As Boolean) Implements IActiveRecord.SetIsLoaded
            _isLoaded = isLoaded
        End Sub
        Private Shared Sub SetTestRepo()
			iF _testRepo Is Nothing Then _testRepo = New TestRepository(Of CustomerDemographic)(New Southwind.NorthwindDB())
        End Sub
        Public Shared Sub ResetTestRepo()
            _testRepo = Nothing
            SetTestRepo()
        End Sub
        Public Shared Sub Setup(testlist As List(Of CustomerDemographic))
            SetTestRepo()
            _testRepo._items = testlist
        End Sub
        Public Shared Sub Setup(item As CustomerDemographic)
            SetTestRepo()
            _testRepo._items.Add(item)
        End Sub
        Public Shared Sub Setup(testItems As Integer)
            SetTestRepo()
            For i As Integer = 0 To testItems - 1
                Dim item As New CustomerDemographic()
                _testRepo._items.Add(item)
            Next i
        End Sub
        
        Public TestMode As Boolean = False



        Private _repo As IRepository(Of CustomerDemographic)
        Private tbl As ITable
        Private _isNew As Boolean
        Public Function IsNew() As Boolean Implements IActiveRecord.IsNew
            Return _isNew
        End Function
        Public Sub SetIsNew(isNew As Boolean) Implements IActiveRecord.SetIsNew
            _isNew=isNew
        End Sub
        Private _isLoaded As Boolean
        Public Function IsLoaded() As Boolean Implements IActiveRecord.IsLoaded
            Return _isLoaded
        End Function
                
        Private _dirtyColumns As List(Of IColumn)
        Public Function IsDirty() As Boolean Implements IActiveRecord.IsDirty
            Return _dirtyColumns.Count > 0
        End Function
        
        Public Function GetDirtyColumns() As List(Of IColumn) Implements IActiveRecord.GetDirtyColumns
            Return _dirtyColumns
        End Function

        Private _db As Southwind.NorthwindDB
        Public Sub New(connectionString As String, providerName As String)
            _db = New Southwind.NorthwindDB(connectionString, providerName)
            Init()            
         End Sub
        Private Sub Init()
            TestMode = Me._db.Provider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase)
            _dirtyColumns = New List(Of IColumn)()
            If TestMode Then
                CustomerDemographic.SetTestRepo()
                _repo=_testRepo
            Else
                _repo = New SubSonicRepository(Of CustomerDemographic)(_db)
            End If
            tbl=_repo.GetTable()
            _isNew = True
            OnCreated()       
      
        End Sub
        
        Public Sub New()
             _db = New Southwind.NorthwindDB()
            Init()            
        End Sub
        
       
        Private Partial Sub OnCreated()
		End Sub
            
        Private Partial Sub OnLoaded()
		End Sub
        
		Private Partial Sub OnSaved()
		End Sub
        
		Private Partial Sub OnChanged()
		End Sub

		Public ReadOnly Property Columns As IList(Of IColumn)
            Get
                Return tbl.Columns
            End Get
        End Property

        Public Sub New(expression As Expression(Of Func(Of CustomerDemographic, Boolean)))
			MyBase.New()
            _isLoaded=_repo.Load(Me,expression)
            If _isLoaded Then OnLoaded()
        End Sub
        
       
        
        Friend Shared Function GetRepo(connectionString As String, providerName As String) As IRepository(Of CustomerDemographic)
            Dim db As Southwind.NorthwindDB
            If String.IsNullOrEmpty(connectionString)
                db = New Southwind.NorthwindDB()
            Else
                db = New Southwind.NorthwindDB(connectionString, providerName)
            End If
            Dim _repo As IRepository(Of CustomerDemographic)
            
            If db.TestMode Then
                CustomerDemographic.SetTestRepo()
                _repo = _testRepo
            Else
                _repo = New SubSonicRepository(Of CustomerDemographic)(db)
            End If
            Return _repo
        End Function
        
        Friend Shared Function GetRepo() As IRepository(Of CustomerDemographic)
            Return GetRepo(String.Empty,String.Empty)
        End Function
        
        Public Shared Function SingleOrDefault(expression As Expression(Of Func(Of CustomerDemographic, Boolean))) As CustomerDemographic

            Dim repo = GetRepo()
            Dim results = repo.Find(expression)
            Dim singleItem As CustomerDemographic = Nothing
            If results.Count() > 0 Then
                singleItem = results.ToList()(0)
                singleItem.OnLoaded()
                singleItem.SetIsLoaded(true)
            End If

            Return singleItem
        End Function  
        
        Public Shared Function SingleOrDefault(expression As Expression(Of Func(Of CustomerDemographic, Boolean)), _
											   connectionString As String, _
											   providerName As String) As CustomerDemographic
			Dim repo = GetRepo(connectionString,providerName)
            Dim results = repo.Find(expression)
            Dim singleItem As CustomerDemographic = Nothing
            If results.Count() > 0 Then
                singleItem = results.ToList()(0)
                singleItem.OnLoaded()
                singleItem.SetIsLoaded(true)
            End If

            Return singleItem
		End Function
        
        
        Public Shared Function Exists(expression As Expression(Of Func(Of CustomerDemographic, Boolean)), connectionString As String, providerName As String) As Boolean
        	Return All(connectionString,providerName).Any(expression)
        End Function
		
        Public Shared Function Exists(expression As Expression(Of Func(Of CustomerDemographic, Boolean))) As Boolean
            Return All().Any(expression)
        End Function        

        Public Shared Function Find(expression As Expression(Of Func(Of CustomerDemographic, Boolean))) As IList(Of CustomerDemographic)
            Dim repo = GetRepo()
            Return repo.Find(expression).ToList()
        End Function
        
        Public Shared Function Find(expression As Expression(Of Func(Of CustomerDemographic, Boolean)), connectionString As String, providerName As String) As IList(Of CustomerDemographic)
            Dim repo = GetRepo(connectionString,providerName)
            Return repo.Find(expression).ToList()
        End Function
        Public Shared Function All(connectionString As String, providerName As String) As IQueryable(Of CustomerDemographic)
            Return GetRepo(connectionString,providerName).GetAll()
        End Function
        Public Shared Function All() As IQueryable(Of CustomerDemographic)
            Return GetRepo().GetAll()
        End Function
        
        Public Shared Function GetPaged(sortBy As String, pageIndex As Integer, pageSize As Integer, connectionString As String, providerName As String) As PagedList(Of CustomerDemographic)
            Return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize)
        End Function
      
        Public Shared Function GetPaged(sortBy As String, pageIndex As Integer, pageSize As Integer) As PagedList(Of CustomerDemographic)
            Return GetRepo().GetPaged(sortBy, pageIndex, pageSize)
        End Function

        Public Shared Function GetPaged(pageIndex As Integer, pageSize As Integer, connectionString As String, providerName As String) As PagedList(Of CustomerDemographic)
            Return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize)
        End Function

        Public Shared Function GetPaged(pageIndex As Integer, pageSize As Integer) As PagedList(Of CustomerDemographic)
            Return GetRepo().GetPaged(pageIndex, pageSize)
        End Function

        Public Function KeyName() As String Implements IActiveRecord.KeyName
            Return "CustomerTypeID"
        End Function

        Public Function KeyValue() As Object Implements IActiveRecord.KeyValue
            Return Me.CustomerTypeID
        End Function
        
        Public Sub SetKeyValue(value As Object) Implements IActiveRecord.SetKeyValue
            If value IsNot Nothing AndAlso value IsNot DBNull.Value Then
                Dim settable = value.ChangeTypeTo(Of String)()
                Me.GetType.GetProperty(Me.KeyName()).SetValue(Me, settable, Nothing)
            End If
        End Sub
        
        Public Overrides Function ToString() As String
            Return Me.CustomerTypeID.ToString()
        End Function

        Public Overrides Function Equals(obj As Object) As Boolean
            If obj.GetType() Is GetType(CustomerDemographic) Then
                Dim compareItem As CustomerDemographic = obj
                Return compareItem.KeyValue() = Me.KeyValue()
            Else
                Return MyBase.Equals(obj)
            End If
        End Function

        Public Function DescriptorValue() As String Implements IActiveRecord.DescriptorValue
            Return Me.CustomerTypeID.ToString()
        End Function

        Public Function DescriptorColumn() As String Implements IActiveRecord.DescriptorColumn
            Return "CustomerTypeID"
        End Function
        Public Shared Function GetKeyColumn() As String 
            Return "CustomerTypeID"
        End Function
        Public Shared Function GetDescriptorColumn() As String
            Return "CustomerTypeID"
        End Function
        
       #Region " Foreign Keys "
        Public ReadOnly Property [CustomerCustomerDemos] As IQueryable(Of CustomerCustomerDemo)
            Get
                  Dim repo = Southwind.CustomerCustomerDemo.GetRepo()
                  Return From items In repo.GetAll() _
                       	Where items.CustomerTypeID = _CustomerTypeID _
                       Select items
            End Get
        End Property

        #End Region

        Private _CustomerTypeID As String
        Public Property [CustomerTypeID] As String
            Get
				Return _CustomerTypeID
			End Get
            Set(value As String)
                _CustomerTypeID = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "CustomerTypeID")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _CustomerDesc As String
        Public Property [CustomerDesc] As String
            Get
				Return _CustomerDesc
			End Get
            Set(value As String)
                _CustomerDesc = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "CustomerDesc")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property



        Public Function GetUpdateCommand() As DbCommand Implements IActiveRecord.GetUpdateCommand
            If TestMode Then
                Return _db.Provider.CreateCommand()
            Else
                Return Me.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand()
            End If
        End Function
        Public Function GetInsertCommand() As DbCommand Implements IActiveRecord.GetInsertCommand
            If TestMode Then
                Return _db.Provider.CreateCommand()
            Else
                Return Me.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand()
			End If
        End Function
        
        Public Function GetDeleteCommand() As DbCommand Implements IActiveRecord.GetDeleteCommand
            If TestMode Then
                Return _db.Provider.CreateCommand()
            Else
                Return Me.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand()
			End If
        End Function
       
        
        Public Sub Update() Implements IActiveRecord.Update
            Update(_db.Provider)
        End Sub
        
        Public Sub Update(provider As IDataProvider) Implements IActiveRecord.Update
        
            If Me._dirtyColumns.Count > 0 Then _repo.Update(Me,provider)
			
            OnSaved()
        End Sub
 
        Public Sub Add() Implements IActiveRecord.Add
            Add(_db.Provider)
        End Sub
        
        
       
        Public Sub Add(provider As IDataProvider) Implements IActiveRecord.Add

            Me.SetKeyValue(_repo.Add(Me,provider))
            OnSaved()
        End Sub
        
                
        
        Public Sub Save() Implements IActiveRecord.Save
            Save(_db.Provider)
        End Sub
        Public Sub Save(provider As IDataProvider) Implements IActiveRecord.Save
            If _isNew Then
                Add(provider)
            Else
                Update(provider)
			End If
        End Sub

        

        Public Sub Delete(provider As IDataProvider)
                   
                 
            _repo.Delete(KeyValue())
            
                    End Sub


        Public Sub Delete() Implements IActiveRecord.Delete
            Delete(_db.Provider)
        End Sub


        Public Shared Sub Delete(expression As Expression(Of Func(Of CustomerDemographic, Boolean)))
            Dim repo = GetRepo()
            
       
            
            repo.DeleteMany(expression)
            
        End Sub

        

        Public Sub Load(rdr As IDataReader) Implements IActiveRecord.Load
            Load(rdr, true)
        End Sub
        Public Sub Load(rdr As IDataReader, closeReader As Boolean) Implements IActiveRecord.Load
            If rdr.Read() Then
                Try
                    rdr.Load(Me)
                    _isNew = False
                    _isLoaded = True
                Catch
                    _isLoaded = False
                    Throw
                End Try
            Else
                _isLoaded = False
            End If

            If closeReader Then rdr.Dispose()

        End Sub
	End Class
    
    
    ''' <summary>
    ''' A class which represents the Region table in the Northwind Database.
    ''' </summary>
    Public Partial Class Region
		Implements IActiveRecord

		' Built-in testing
        Shared TestItems As IList(Of Region)
        Shared _testRepo As TestRepository(Of Region)
        Public Sub SetIsLoaded(isLoaded As Boolean) Implements IActiveRecord.SetIsLoaded
            _isLoaded = isLoaded
        End Sub
        Private Shared Sub SetTestRepo()
			iF _testRepo Is Nothing Then _testRepo = New TestRepository(Of Region)(New Southwind.NorthwindDB())
        End Sub
        Public Shared Sub ResetTestRepo()
            _testRepo = Nothing
            SetTestRepo()
        End Sub
        Public Shared Sub Setup(testlist As List(Of Region))
            SetTestRepo()
            _testRepo._items = testlist
        End Sub
        Public Shared Sub Setup(item As Region)
            SetTestRepo()
            _testRepo._items.Add(item)
        End Sub
        Public Shared Sub Setup(testItems As Integer)
            SetTestRepo()
            For i As Integer = 0 To testItems - 1
                Dim item As New Region()
                _testRepo._items.Add(item)
            Next i
        End Sub
        
        Public TestMode As Boolean = False



        Private _repo As IRepository(Of Region)
        Private tbl As ITable
        Private _isNew As Boolean
        Public Function IsNew() As Boolean Implements IActiveRecord.IsNew
            Return _isNew
        End Function
        Public Sub SetIsNew(isNew As Boolean) Implements IActiveRecord.SetIsNew
            _isNew=isNew
        End Sub
        Private _isLoaded As Boolean
        Public Function IsLoaded() As Boolean Implements IActiveRecord.IsLoaded
            Return _isLoaded
        End Function
                
        Private _dirtyColumns As List(Of IColumn)
        Public Function IsDirty() As Boolean Implements IActiveRecord.IsDirty
            Return _dirtyColumns.Count > 0
        End Function
        
        Public Function GetDirtyColumns() As List(Of IColumn) Implements IActiveRecord.GetDirtyColumns
            Return _dirtyColumns
        End Function

        Private _db As Southwind.NorthwindDB
        Public Sub New(connectionString As String, providerName As String)
            _db = New Southwind.NorthwindDB(connectionString, providerName)
            Init()            
         End Sub
        Private Sub Init()
            TestMode = Me._db.Provider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase)
            _dirtyColumns = New List(Of IColumn)()
            If TestMode Then
                Region.SetTestRepo()
                _repo=_testRepo
            Else
                _repo = New SubSonicRepository(Of Region)(_db)
            End If
            tbl=_repo.GetTable()
            _isNew = True
            OnCreated()       
      
        End Sub
        
        Public Sub New()
             _db = New Southwind.NorthwindDB()
            Init()            
        End Sub
        
       
        Private Partial Sub OnCreated()
		End Sub
            
        Private Partial Sub OnLoaded()
		End Sub
        
		Private Partial Sub OnSaved()
		End Sub
        
		Private Partial Sub OnChanged()
		End Sub

		Public ReadOnly Property Columns As IList(Of IColumn)
            Get
                Return tbl.Columns
            End Get
        End Property

        Public Sub New(expression As Expression(Of Func(Of Region, Boolean)))
			MyBase.New()
            _isLoaded=_repo.Load(Me,expression)
            If _isLoaded Then OnLoaded()
        End Sub
        
       
        
        Friend Shared Function GetRepo(connectionString As String, providerName As String) As IRepository(Of Region)
            Dim db As Southwind.NorthwindDB
            If String.IsNullOrEmpty(connectionString)
                db = New Southwind.NorthwindDB()
            Else
                db = New Southwind.NorthwindDB(connectionString, providerName)
            End If
            Dim _repo As IRepository(Of Region)
            
            If db.TestMode Then
                Region.SetTestRepo()
                _repo = _testRepo
            Else
                _repo = New SubSonicRepository(Of Region)(db)
            End If
            Return _repo
        End Function
        
        Friend Shared Function GetRepo() As IRepository(Of Region)
            Return GetRepo(String.Empty,String.Empty)
        End Function
        
        Public Shared Function SingleOrDefault(expression As Expression(Of Func(Of Region, Boolean))) As Region

            Dim repo = GetRepo()
            Dim results = repo.Find(expression)
            Dim singleItem As Region = Nothing
            If results.Count() > 0 Then
                singleItem = results.ToList()(0)
                singleItem.OnLoaded()
                singleItem.SetIsLoaded(true)
            End If

            Return singleItem
        End Function  
        
        Public Shared Function SingleOrDefault(expression As Expression(Of Func(Of Region, Boolean)), _
											   connectionString As String, _
											   providerName As String) As Region
			Dim repo = GetRepo(connectionString,providerName)
            Dim results = repo.Find(expression)
            Dim singleItem As Region = Nothing
            If results.Count() > 0 Then
                singleItem = results.ToList()(0)
                singleItem.OnLoaded()
                singleItem.SetIsLoaded(true)
            End If

            Return singleItem
		End Function
        
        
        Public Shared Function Exists(expression As Expression(Of Func(Of Region, Boolean)), connectionString As String, providerName As String) As Boolean
        	Return All(connectionString,providerName).Any(expression)
        End Function
		
        Public Shared Function Exists(expression As Expression(Of Func(Of Region, Boolean))) As Boolean
            Return All().Any(expression)
        End Function        

        Public Shared Function Find(expression As Expression(Of Func(Of Region, Boolean))) As IList(Of Region)
            Dim repo = GetRepo()
            Return repo.Find(expression).ToList()
        End Function
        
        Public Shared Function Find(expression As Expression(Of Func(Of Region, Boolean)), connectionString As String, providerName As String) As IList(Of Region)
            Dim repo = GetRepo(connectionString,providerName)
            Return repo.Find(expression).ToList()
        End Function
        Public Shared Function All(connectionString As String, providerName As String) As IQueryable(Of Region)
            Return GetRepo(connectionString,providerName).GetAll()
        End Function
        Public Shared Function All() As IQueryable(Of Region)
            Return GetRepo().GetAll()
        End Function
        
        Public Shared Function GetPaged(sortBy As String, pageIndex As Integer, pageSize As Integer, connectionString As String, providerName As String) As PagedList(Of Region)
            Return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize)
        End Function
      
        Public Shared Function GetPaged(sortBy As String, pageIndex As Integer, pageSize As Integer) As PagedList(Of Region)
            Return GetRepo().GetPaged(sortBy, pageIndex, pageSize)
        End Function

        Public Shared Function GetPaged(pageIndex As Integer, pageSize As Integer, connectionString As String, providerName As String) As PagedList(Of Region)
            Return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize)
        End Function

        Public Shared Function GetPaged(pageIndex As Integer, pageSize As Integer) As PagedList(Of Region)
            Return GetRepo().GetPaged(pageIndex, pageSize)
        End Function

        Public Function KeyName() As String Implements IActiveRecord.KeyName
            Return "RegionID"
        End Function

        Public Function KeyValue() As Object Implements IActiveRecord.KeyValue
            Return Me.RegionID
        End Function
        
        Public Sub SetKeyValue(value As Object) Implements IActiveRecord.SetKeyValue
            If value IsNot Nothing AndAlso value IsNot DBNull.Value Then
                Dim settable = value.ChangeTypeTo(Of Integer)()
                Me.GetType.GetProperty(Me.KeyName()).SetValue(Me, settable, Nothing)
            End If
        End Sub
        
        Public Overrides Function ToString() As String
            Return Me.RegionDescription.ToString()
        End Function

        Public Overrides Function Equals(obj As Object) As Boolean
            If obj.GetType() Is GetType(Region) Then
                Dim compareItem As Region = obj
                Return compareItem.KeyValue() = Me.KeyValue()
            Else
                Return MyBase.Equals(obj)
            End If
        End Function

        Public Function DescriptorValue() As String Implements IActiveRecord.DescriptorValue
            Return Me.RegionDescription.ToString()
        End Function

        Public Function DescriptorColumn() As String Implements IActiveRecord.DescriptorColumn
            Return "RegionDescription"
        End Function
        Public Shared Function GetKeyColumn() As String 
            Return "RegionID"
        End Function
        Public Shared Function GetDescriptorColumn() As String
            Return "RegionDescription"
        End Function
        
       #Region " Foreign Keys "
        Public ReadOnly Property [Territories] As IQueryable(Of Territory)
            Get
                  Dim repo = Southwind.Territory.GetRepo()
                  Return From items In repo.GetAll() _
                       	Where items.RegionID = _RegionID _
                       Select items
            End Get
        End Property

        #End Region

        Private _RegionID As Integer
        Public Property [RegionID] As Integer
            Get
				Return _RegionID
			End Get
            Set(value As Integer)
                _RegionID = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "RegionID")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _RegionDescription As String
        Public Property [RegionDescription] As String
            Get
				Return _RegionDescription
			End Get
            Set(value As String)
                _RegionDescription = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "RegionDescription")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property



        Public Function GetUpdateCommand() As DbCommand Implements IActiveRecord.GetUpdateCommand
            If TestMode Then
                Return _db.Provider.CreateCommand()
            Else
                Return Me.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand()
            End If
        End Function
        Public Function GetInsertCommand() As DbCommand Implements IActiveRecord.GetInsertCommand
            If TestMode Then
                Return _db.Provider.CreateCommand()
            Else
                Return Me.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand()
			End If
        End Function
        
        Public Function GetDeleteCommand() As DbCommand Implements IActiveRecord.GetDeleteCommand
            If TestMode Then
                Return _db.Provider.CreateCommand()
            Else
                Return Me.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand()
			End If
        End Function
       
        
        Public Sub Update() Implements IActiveRecord.Update
            Update(_db.Provider)
        End Sub
        
        Public Sub Update(provider As IDataProvider) Implements IActiveRecord.Update
        
            If Me._dirtyColumns.Count > 0 Then _repo.Update(Me,provider)
			
            OnSaved()
        End Sub
 
        Public Sub Add() Implements IActiveRecord.Add
            Add(_db.Provider)
        End Sub
        
        
       
        Public Sub Add(provider As IDataProvider) Implements IActiveRecord.Add

            Me.SetKeyValue(_repo.Add(Me,provider))
            OnSaved()
        End Sub
        
                
        
        Public Sub Save() Implements IActiveRecord.Save
            Save(_db.Provider)
        End Sub
        Public Sub Save(provider As IDataProvider) Implements IActiveRecord.Save
            If _isNew Then
                Add(provider)
            Else
                Update(provider)
			End If
        End Sub

        

        Public Sub Delete(provider As IDataProvider)
                   
                 
            _repo.Delete(KeyValue())
            
                    End Sub


        Public Sub Delete() Implements IActiveRecord.Delete
            Delete(_db.Provider)
        End Sub


        Public Shared Sub Delete(expression As Expression(Of Func(Of Region, Boolean)))
            Dim repo = GetRepo()
            
       
            
            repo.DeleteMany(expression)
            
        End Sub

        

        Public Sub Load(rdr As IDataReader) Implements IActiveRecord.Load
            Load(rdr, true)
        End Sub
        Public Sub Load(rdr As IDataReader, closeReader As Boolean) Implements IActiveRecord.Load
            If rdr.Read() Then
                Try
                    rdr.Load(Me)
                    _isNew = False
                    _isLoaded = True
                Catch
                    _isLoaded = False
                    Throw
                End Try
            Else
                _isLoaded = False
            End If

            If closeReader Then rdr.Dispose()

        End Sub
	End Class
    
    
    ''' <summary>
    ''' A class which represents the Territories table in the Northwind Database.
    ''' </summary>
    Public Partial Class Territory
		Implements IActiveRecord

		' Built-in testing
        Shared TestItems As IList(Of Territory)
        Shared _testRepo As TestRepository(Of Territory)
        Public Sub SetIsLoaded(isLoaded As Boolean) Implements IActiveRecord.SetIsLoaded
            _isLoaded = isLoaded
        End Sub
        Private Shared Sub SetTestRepo()
			iF _testRepo Is Nothing Then _testRepo = New TestRepository(Of Territory)(New Southwind.NorthwindDB())
        End Sub
        Public Shared Sub ResetTestRepo()
            _testRepo = Nothing
            SetTestRepo()
        End Sub
        Public Shared Sub Setup(testlist As List(Of Territory))
            SetTestRepo()
            _testRepo._items = testlist
        End Sub
        Public Shared Sub Setup(item As Territory)
            SetTestRepo()
            _testRepo._items.Add(item)
        End Sub
        Public Shared Sub Setup(testItems As Integer)
            SetTestRepo()
            For i As Integer = 0 To testItems - 1
                Dim item As New Territory()
                _testRepo._items.Add(item)
            Next i
        End Sub
        
        Public TestMode As Boolean = False



        Private _repo As IRepository(Of Territory)
        Private tbl As ITable
        Private _isNew As Boolean
        Public Function IsNew() As Boolean Implements IActiveRecord.IsNew
            Return _isNew
        End Function
        Public Sub SetIsNew(isNew As Boolean) Implements IActiveRecord.SetIsNew
            _isNew=isNew
        End Sub
        Private _isLoaded As Boolean
        Public Function IsLoaded() As Boolean Implements IActiveRecord.IsLoaded
            Return _isLoaded
        End Function
                
        Private _dirtyColumns As List(Of IColumn)
        Public Function IsDirty() As Boolean Implements IActiveRecord.IsDirty
            Return _dirtyColumns.Count > 0
        End Function
        
        Public Function GetDirtyColumns() As List(Of IColumn) Implements IActiveRecord.GetDirtyColumns
            Return _dirtyColumns
        End Function

        Private _db As Southwind.NorthwindDB
        Public Sub New(connectionString As String, providerName As String)
            _db = New Southwind.NorthwindDB(connectionString, providerName)
            Init()            
         End Sub
        Private Sub Init()
            TestMode = Me._db.Provider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase)
            _dirtyColumns = New List(Of IColumn)()
            If TestMode Then
                Territory.SetTestRepo()
                _repo=_testRepo
            Else
                _repo = New SubSonicRepository(Of Territory)(_db)
            End If
            tbl=_repo.GetTable()
            _isNew = True
            OnCreated()       
      
        End Sub
        
        Public Sub New()
             _db = New Southwind.NorthwindDB()
            Init()            
        End Sub
        
       
        Private Partial Sub OnCreated()
		End Sub
            
        Private Partial Sub OnLoaded()
		End Sub
        
		Private Partial Sub OnSaved()
		End Sub
        
		Private Partial Sub OnChanged()
		End Sub

		Public ReadOnly Property Columns As IList(Of IColumn)
            Get
                Return tbl.Columns
            End Get
        End Property

        Public Sub New(expression As Expression(Of Func(Of Territory, Boolean)))
			MyBase.New()
            _isLoaded=_repo.Load(Me,expression)
            If _isLoaded Then OnLoaded()
        End Sub
        
       
        
        Friend Shared Function GetRepo(connectionString As String, providerName As String) As IRepository(Of Territory)
            Dim db As Southwind.NorthwindDB
            If String.IsNullOrEmpty(connectionString)
                db = New Southwind.NorthwindDB()
            Else
                db = New Southwind.NorthwindDB(connectionString, providerName)
            End If
            Dim _repo As IRepository(Of Territory)
            
            If db.TestMode Then
                Territory.SetTestRepo()
                _repo = _testRepo
            Else
                _repo = New SubSonicRepository(Of Territory)(db)
            End If
            Return _repo
        End Function
        
        Friend Shared Function GetRepo() As IRepository(Of Territory)
            Return GetRepo(String.Empty,String.Empty)
        End Function
        
        Public Shared Function SingleOrDefault(expression As Expression(Of Func(Of Territory, Boolean))) As Territory

            Dim repo = GetRepo()
            Dim results = repo.Find(expression)
            Dim singleItem As Territory = Nothing
            If results.Count() > 0 Then
                singleItem = results.ToList()(0)
                singleItem.OnLoaded()
                singleItem.SetIsLoaded(true)
            End If

            Return singleItem
        End Function  
        
        Public Shared Function SingleOrDefault(expression As Expression(Of Func(Of Territory, Boolean)), _
											   connectionString As String, _
											   providerName As String) As Territory
			Dim repo = GetRepo(connectionString,providerName)
            Dim results = repo.Find(expression)
            Dim singleItem As Territory = Nothing
            If results.Count() > 0 Then
                singleItem = results.ToList()(0)
                singleItem.OnLoaded()
                singleItem.SetIsLoaded(true)
            End If

            Return singleItem
		End Function
        
        
        Public Shared Function Exists(expression As Expression(Of Func(Of Territory, Boolean)), connectionString As String, providerName As String) As Boolean
        	Return All(connectionString,providerName).Any(expression)
        End Function
		
        Public Shared Function Exists(expression As Expression(Of Func(Of Territory, Boolean))) As Boolean
            Return All().Any(expression)
        End Function        

        Public Shared Function Find(expression As Expression(Of Func(Of Territory, Boolean))) As IList(Of Territory)
            Dim repo = GetRepo()
            Return repo.Find(expression).ToList()
        End Function
        
        Public Shared Function Find(expression As Expression(Of Func(Of Territory, Boolean)), connectionString As String, providerName As String) As IList(Of Territory)
            Dim repo = GetRepo(connectionString,providerName)
            Return repo.Find(expression).ToList()
        End Function
        Public Shared Function All(connectionString As String, providerName As String) As IQueryable(Of Territory)
            Return GetRepo(connectionString,providerName).GetAll()
        End Function
        Public Shared Function All() As IQueryable(Of Territory)
            Return GetRepo().GetAll()
        End Function
        
        Public Shared Function GetPaged(sortBy As String, pageIndex As Integer, pageSize As Integer, connectionString As String, providerName As String) As PagedList(Of Territory)
            Return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize)
        End Function
      
        Public Shared Function GetPaged(sortBy As String, pageIndex As Integer, pageSize As Integer) As PagedList(Of Territory)
            Return GetRepo().GetPaged(sortBy, pageIndex, pageSize)
        End Function

        Public Shared Function GetPaged(pageIndex As Integer, pageSize As Integer, connectionString As String, providerName As String) As PagedList(Of Territory)
            Return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize)
        End Function

        Public Shared Function GetPaged(pageIndex As Integer, pageSize As Integer) As PagedList(Of Territory)
            Return GetRepo().GetPaged(pageIndex, pageSize)
        End Function

        Public Function KeyName() As String Implements IActiveRecord.KeyName
            Return "TerritoryID"
        End Function

        Public Function KeyValue() As Object Implements IActiveRecord.KeyValue
            Return Me.TerritoryID
        End Function
        
        Public Sub SetKeyValue(value As Object) Implements IActiveRecord.SetKeyValue
            If value IsNot Nothing AndAlso value IsNot DBNull.Value Then
                Dim settable = value.ChangeTypeTo(Of String)()
                Me.GetType.GetProperty(Me.KeyName()).SetValue(Me, settable, Nothing)
            End If
        End Sub
        
        Public Overrides Function ToString() As String
            Return Me.TerritoryID.ToString()
        End Function

        Public Overrides Function Equals(obj As Object) As Boolean
            If obj.GetType() Is GetType(Territory) Then
                Dim compareItem As Territory = obj
                Return compareItem.KeyValue() = Me.KeyValue()
            Else
                Return MyBase.Equals(obj)
            End If
        End Function

        Public Function DescriptorValue() As String Implements IActiveRecord.DescriptorValue
            Return Me.TerritoryID.ToString()
        End Function

        Public Function DescriptorColumn() As String Implements IActiveRecord.DescriptorColumn
            Return "TerritoryID"
        End Function
        Public Shared Function GetKeyColumn() As String 
            Return "TerritoryID"
        End Function
        Public Shared Function GetDescriptorColumn() As String
            Return "TerritoryID"
        End Function
        
       #Region " Foreign Keys "
        Public ReadOnly Property [Regions] As IQueryable(Of Region)
            Get
                  Dim repo = Southwind.Region.GetRepo()
                  Return From items In repo.GetAll() _
                       	Where items.RegionID = _RegionID _
                       Select items
            End Get
        End Property

        Public ReadOnly Property [EmployeeTerritories] As IQueryable(Of EmployeeTerritory)
            Get
                  Dim repo = Southwind.EmployeeTerritory.GetRepo()
                  Return From items In repo.GetAll() _
                       	Where items.TerritoryID = _TerritoryID _
                       Select items
            End Get
        End Property

        #End Region

        Private _TerritoryID As String
        Public Property [TerritoryID] As String
            Get
				Return _TerritoryID
			End Get
            Set(value As String)
                _TerritoryID = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "TerritoryID")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _TerritoryDescription As String
        Public Property [TerritoryDescription] As String
            Get
				Return _TerritoryDescription
			End Get
            Set(value As String)
                _TerritoryDescription = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "TerritoryDescription")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _RegionID As Integer
        Public Property [RegionID] As Integer
            Get
				Return _RegionID
			End Get
            Set(value As Integer)
                _RegionID = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "RegionID")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property



        Public Function GetUpdateCommand() As DbCommand Implements IActiveRecord.GetUpdateCommand
            If TestMode Then
                Return _db.Provider.CreateCommand()
            Else
                Return Me.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand()
            End If
        End Function
        Public Function GetInsertCommand() As DbCommand Implements IActiveRecord.GetInsertCommand
            If TestMode Then
                Return _db.Provider.CreateCommand()
            Else
                Return Me.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand()
			End If
        End Function
        
        Public Function GetDeleteCommand() As DbCommand Implements IActiveRecord.GetDeleteCommand
            If TestMode Then
                Return _db.Provider.CreateCommand()
            Else
                Return Me.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand()
			End If
        End Function
       
        
        Public Sub Update() Implements IActiveRecord.Update
            Update(_db.Provider)
        End Sub
        
        Public Sub Update(provider As IDataProvider) Implements IActiveRecord.Update
        
            If Me._dirtyColumns.Count > 0 Then _repo.Update(Me,provider)
			
            OnSaved()
        End Sub
 
        Public Sub Add() Implements IActiveRecord.Add
            Add(_db.Provider)
        End Sub
        
        
       
        Public Sub Add(provider As IDataProvider) Implements IActiveRecord.Add

            Me.SetKeyValue(_repo.Add(Me,provider))
            OnSaved()
        End Sub
        
                
        
        Public Sub Save() Implements IActiveRecord.Save
            Save(_db.Provider)
        End Sub
        Public Sub Save(provider As IDataProvider) Implements IActiveRecord.Save
            If _isNew Then
                Add(provider)
            Else
                Update(provider)
			End If
        End Sub

        

        Public Sub Delete(provider As IDataProvider)
                   
                 
            _repo.Delete(KeyValue())
            
                    End Sub


        Public Sub Delete() Implements IActiveRecord.Delete
            Delete(_db.Provider)
        End Sub


        Public Shared Sub Delete(expression As Expression(Of Func(Of Territory, Boolean)))
            Dim repo = GetRepo()
            
       
            
            repo.DeleteMany(expression)
            
        End Sub

        

        Public Sub Load(rdr As IDataReader) Implements IActiveRecord.Load
            Load(rdr, true)
        End Sub
        Public Sub Load(rdr As IDataReader, closeReader As Boolean) Implements IActiveRecord.Load
            If rdr.Read() Then
                Try
                    rdr.Load(Me)
                    _isNew = False
                    _isLoaded = True
                Catch
                    _isLoaded = False
                    Throw
                End Try
            Else
                _isLoaded = False
            End If

            If closeReader Then rdr.Dispose()

        End Sub
	End Class
    
    
    ''' <summary>
    ''' A class which represents the EmployeeTerritories table in the Northwind Database.
    ''' </summary>
    Public Partial Class EmployeeTerritory
		Implements IActiveRecord

		' Built-in testing
        Shared TestItems As IList(Of EmployeeTerritory)
        Shared _testRepo As TestRepository(Of EmployeeTerritory)
        Public Sub SetIsLoaded(isLoaded As Boolean) Implements IActiveRecord.SetIsLoaded
            _isLoaded = isLoaded
        End Sub
        Private Shared Sub SetTestRepo()
			iF _testRepo Is Nothing Then _testRepo = New TestRepository(Of EmployeeTerritory)(New Southwind.NorthwindDB())
        End Sub
        Public Shared Sub ResetTestRepo()
            _testRepo = Nothing
            SetTestRepo()
        End Sub
        Public Shared Sub Setup(testlist As List(Of EmployeeTerritory))
            SetTestRepo()
            _testRepo._items = testlist
        End Sub
        Public Shared Sub Setup(item As EmployeeTerritory)
            SetTestRepo()
            _testRepo._items.Add(item)
        End Sub
        Public Shared Sub Setup(testItems As Integer)
            SetTestRepo()
            For i As Integer = 0 To testItems - 1
                Dim item As New EmployeeTerritory()
                _testRepo._items.Add(item)
            Next i
        End Sub
        
        Public TestMode As Boolean = False



        Private _repo As IRepository(Of EmployeeTerritory)
        Private tbl As ITable
        Private _isNew As Boolean
        Public Function IsNew() As Boolean Implements IActiveRecord.IsNew
            Return _isNew
        End Function
        Public Sub SetIsNew(isNew As Boolean) Implements IActiveRecord.SetIsNew
            _isNew=isNew
        End Sub
        Private _isLoaded As Boolean
        Public Function IsLoaded() As Boolean Implements IActiveRecord.IsLoaded
            Return _isLoaded
        End Function
                
        Private _dirtyColumns As List(Of IColumn)
        Public Function IsDirty() As Boolean Implements IActiveRecord.IsDirty
            Return _dirtyColumns.Count > 0
        End Function
        
        Public Function GetDirtyColumns() As List(Of IColumn) Implements IActiveRecord.GetDirtyColumns
            Return _dirtyColumns
        End Function

        Private _db As Southwind.NorthwindDB
        Public Sub New(connectionString As String, providerName As String)
            _db = New Southwind.NorthwindDB(connectionString, providerName)
            Init()            
         End Sub
        Private Sub Init()
            TestMode = Me._db.Provider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase)
            _dirtyColumns = New List(Of IColumn)()
            If TestMode Then
                EmployeeTerritory.SetTestRepo()
                _repo=_testRepo
            Else
                _repo = New SubSonicRepository(Of EmployeeTerritory)(_db)
            End If
            tbl=_repo.GetTable()
            _isNew = True
            OnCreated()       
      
        End Sub
        
        Public Sub New()
             _db = New Southwind.NorthwindDB()
            Init()            
        End Sub
        
       
        Private Partial Sub OnCreated()
		End Sub
            
        Private Partial Sub OnLoaded()
		End Sub
        
		Private Partial Sub OnSaved()
		End Sub
        
		Private Partial Sub OnChanged()
		End Sub

		Public ReadOnly Property Columns As IList(Of IColumn)
            Get
                Return tbl.Columns
            End Get
        End Property

        Public Sub New(expression As Expression(Of Func(Of EmployeeTerritory, Boolean)))
			MyBase.New()
            _isLoaded=_repo.Load(Me,expression)
            If _isLoaded Then OnLoaded()
        End Sub
        
       
        
        Friend Shared Function GetRepo(connectionString As String, providerName As String) As IRepository(Of EmployeeTerritory)
            Dim db As Southwind.NorthwindDB
            If String.IsNullOrEmpty(connectionString)
                db = New Southwind.NorthwindDB()
            Else
                db = New Southwind.NorthwindDB(connectionString, providerName)
            End If
            Dim _repo As IRepository(Of EmployeeTerritory)
            
            If db.TestMode Then
                EmployeeTerritory.SetTestRepo()
                _repo = _testRepo
            Else
                _repo = New SubSonicRepository(Of EmployeeTerritory)(db)
            End If
            Return _repo
        End Function
        
        Friend Shared Function GetRepo() As IRepository(Of EmployeeTerritory)
            Return GetRepo(String.Empty,String.Empty)
        End Function
        
        Public Shared Function SingleOrDefault(expression As Expression(Of Func(Of EmployeeTerritory, Boolean))) As EmployeeTerritory

            Dim repo = GetRepo()
            Dim results = repo.Find(expression)
            Dim singleItem As EmployeeTerritory = Nothing
            If results.Count() > 0 Then
                singleItem = results.ToList()(0)
                singleItem.OnLoaded()
                singleItem.SetIsLoaded(true)
            End If

            Return singleItem
        End Function  
        
        Public Shared Function SingleOrDefault(expression As Expression(Of Func(Of EmployeeTerritory, Boolean)), _
											   connectionString As String, _
											   providerName As String) As EmployeeTerritory
			Dim repo = GetRepo(connectionString,providerName)
            Dim results = repo.Find(expression)
            Dim singleItem As EmployeeTerritory = Nothing
            If results.Count() > 0 Then
                singleItem = results.ToList()(0)
                singleItem.OnLoaded()
                singleItem.SetIsLoaded(true)
            End If

            Return singleItem
		End Function
        
        
        Public Shared Function Exists(expression As Expression(Of Func(Of EmployeeTerritory, Boolean)), connectionString As String, providerName As String) As Boolean
        	Return All(connectionString,providerName).Any(expression)
        End Function
		
        Public Shared Function Exists(expression As Expression(Of Func(Of EmployeeTerritory, Boolean))) As Boolean
            Return All().Any(expression)
        End Function        

        Public Shared Function Find(expression As Expression(Of Func(Of EmployeeTerritory, Boolean))) As IList(Of EmployeeTerritory)
            Dim repo = GetRepo()
            Return repo.Find(expression).ToList()
        End Function
        
        Public Shared Function Find(expression As Expression(Of Func(Of EmployeeTerritory, Boolean)), connectionString As String, providerName As String) As IList(Of EmployeeTerritory)
            Dim repo = GetRepo(connectionString,providerName)
            Return repo.Find(expression).ToList()
        End Function
        Public Shared Function All(connectionString As String, providerName As String) As IQueryable(Of EmployeeTerritory)
            Return GetRepo(connectionString,providerName).GetAll()
        End Function
        Public Shared Function All() As IQueryable(Of EmployeeTerritory)
            Return GetRepo().GetAll()
        End Function
        
        Public Shared Function GetPaged(sortBy As String, pageIndex As Integer, pageSize As Integer, connectionString As String, providerName As String) As PagedList(Of EmployeeTerritory)
            Return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize)
        End Function
      
        Public Shared Function GetPaged(sortBy As String, pageIndex As Integer, pageSize As Integer) As PagedList(Of EmployeeTerritory)
            Return GetRepo().GetPaged(sortBy, pageIndex, pageSize)
        End Function

        Public Shared Function GetPaged(pageIndex As Integer, pageSize As Integer, connectionString As String, providerName As String) As PagedList(Of EmployeeTerritory)
            Return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize)
        End Function

        Public Shared Function GetPaged(pageIndex As Integer, pageSize As Integer) As PagedList(Of EmployeeTerritory)
            Return GetRepo().GetPaged(pageIndex, pageSize)
        End Function

        Public Function KeyName() As String Implements IActiveRecord.KeyName
            Return "EmployeeID"
        End Function

        Public Function KeyValue() As Object Implements IActiveRecord.KeyValue
            Return Me.EmployeeID
        End Function
        
        Public Sub SetKeyValue(value As Object) Implements IActiveRecord.SetKeyValue
            If value IsNot Nothing AndAlso value IsNot DBNull.Value Then
                Dim settable = value.ChangeTypeTo(Of Integer)()
                Me.GetType.GetProperty(Me.KeyName()).SetValue(Me, settable, Nothing)
            End If
        End Sub
        
        Public Overrides Function ToString() As String
            Return Me.TerritoryID.ToString()
        End Function

        Public Overrides Function Equals(obj As Object) As Boolean
            If obj.GetType() Is GetType(EmployeeTerritory) Then
                Dim compareItem As EmployeeTerritory = obj
                Return compareItem.KeyValue() = Me.KeyValue()
            Else
                Return MyBase.Equals(obj)
            End If
        End Function

        Public Function DescriptorValue() As String Implements IActiveRecord.DescriptorValue
            Return Me.TerritoryID.ToString()
        End Function

        Public Function DescriptorColumn() As String Implements IActiveRecord.DescriptorColumn
            Return "TerritoryID"
        End Function
        Public Shared Function GetKeyColumn() As String 
            Return "EmployeeID"
        End Function
        Public Shared Function GetDescriptorColumn() As String
            Return "TerritoryID"
        End Function
        
       #Region " Foreign Keys "
        Public ReadOnly Property [Employees] As IQueryable(Of Employee)
            Get
                  Dim repo = Southwind.Employee.GetRepo()
                  Return From items In repo.GetAll() _
                       	Where items.EmployeeID = _EmployeeID _
                       Select items
            End Get
        End Property

        Public ReadOnly Property [Territories] As IQueryable(Of Territory)
            Get
                  Dim repo = Southwind.Territory.GetRepo()
                  Return From items In repo.GetAll() _
                       	Where items.TerritoryID = _TerritoryID _
                       Select items
            End Get
        End Property

        #End Region

        Private _EmployeeID As Integer
        Public Property [EmployeeID] As Integer
            Get
				Return _EmployeeID
			End Get
            Set(value As Integer)
                _EmployeeID = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "EmployeeID")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _TerritoryID As String
        Public Property [TerritoryID] As String
            Get
				Return _TerritoryID
			End Get
            Set(value As String)
                _TerritoryID = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "TerritoryID")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property



        Public Function GetUpdateCommand() As DbCommand Implements IActiveRecord.GetUpdateCommand
            If TestMode Then
                Return _db.Provider.CreateCommand()
            Else
                Return Me.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand()
            End If
        End Function
        Public Function GetInsertCommand() As DbCommand Implements IActiveRecord.GetInsertCommand
            If TestMode Then
                Return _db.Provider.CreateCommand()
            Else
                Return Me.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand()
			End If
        End Function
        
        Public Function GetDeleteCommand() As DbCommand Implements IActiveRecord.GetDeleteCommand
            If TestMode Then
                Return _db.Provider.CreateCommand()
            Else
                Return Me.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand()
			End If
        End Function
       
        
        Public Sub Update() Implements IActiveRecord.Update
            Update(_db.Provider)
        End Sub
        
        Public Sub Update(provider As IDataProvider) Implements IActiveRecord.Update
        
            If Me._dirtyColumns.Count > 0 Then _repo.Update(Me,provider)
			
            OnSaved()
        End Sub
 
        Public Sub Add() Implements IActiveRecord.Add
            Add(_db.Provider)
        End Sub
        
        
       
        Public Sub Add(provider As IDataProvider) Implements IActiveRecord.Add

            Me.SetKeyValue(_repo.Add(Me,provider))
            OnSaved()
        End Sub
        
                
        
        Public Sub Save() Implements IActiveRecord.Save
            Save(_db.Provider)
        End Sub
        Public Sub Save(provider As IDataProvider) Implements IActiveRecord.Save
            If _isNew Then
                Add(provider)
            Else
                Update(provider)
			End If
        End Sub

        

        Public Sub Delete(provider As IDataProvider)
                   
                 
            _repo.Delete(KeyValue())
            
                    End Sub


        Public Sub Delete() Implements IActiveRecord.Delete
            Delete(_db.Provider)
        End Sub


        Public Shared Sub Delete(expression As Expression(Of Func(Of EmployeeTerritory, Boolean)))
            Dim repo = GetRepo()
            
       
            
            repo.DeleteMany(expression)
            
        End Sub

        

        Public Sub Load(rdr As IDataReader) Implements IActiveRecord.Load
            Load(rdr, true)
        End Sub
        Public Sub Load(rdr As IDataReader, closeReader As Boolean) Implements IActiveRecord.Load
            If rdr.Read() Then
                Try
                    rdr.Load(Me)
                    _isNew = False
                    _isLoaded = True
                Catch
                    _isLoaded = False
                    Throw
                End Try
            Else
                _isLoaded = False
            End If

            If closeReader Then rdr.Dispose()

        End Sub
	End Class
    
    
    ''' <summary>
    ''' A class which represents the Employees table in the Northwind Database.
    ''' </summary>
    Public Partial Class Employee
		Implements IActiveRecord

		' Built-in testing
        Shared TestItems As IList(Of Employee)
        Shared _testRepo As TestRepository(Of Employee)
        Public Sub SetIsLoaded(isLoaded As Boolean) Implements IActiveRecord.SetIsLoaded
            _isLoaded = isLoaded
        End Sub
        Private Shared Sub SetTestRepo()
			iF _testRepo Is Nothing Then _testRepo = New TestRepository(Of Employee)(New Southwind.NorthwindDB())
        End Sub
        Public Shared Sub ResetTestRepo()
            _testRepo = Nothing
            SetTestRepo()
        End Sub
        Public Shared Sub Setup(testlist As List(Of Employee))
            SetTestRepo()
            _testRepo._items = testlist
        End Sub
        Public Shared Sub Setup(item As Employee)
            SetTestRepo()
            _testRepo._items.Add(item)
        End Sub
        Public Shared Sub Setup(testItems As Integer)
            SetTestRepo()
            For i As Integer = 0 To testItems - 1
                Dim item As New Employee()
                _testRepo._items.Add(item)
            Next i
        End Sub
        
        Public TestMode As Boolean = False



        Private _repo As IRepository(Of Employee)
        Private tbl As ITable
        Private _isNew As Boolean
        Public Function IsNew() As Boolean Implements IActiveRecord.IsNew
            Return _isNew
        End Function
        Public Sub SetIsNew(isNew As Boolean) Implements IActiveRecord.SetIsNew
            _isNew=isNew
        End Sub
        Private _isLoaded As Boolean
        Public Function IsLoaded() As Boolean Implements IActiveRecord.IsLoaded
            Return _isLoaded
        End Function
                
        Private _dirtyColumns As List(Of IColumn)
        Public Function IsDirty() As Boolean Implements IActiveRecord.IsDirty
            Return _dirtyColumns.Count > 0
        End Function
        
        Public Function GetDirtyColumns() As List(Of IColumn) Implements IActiveRecord.GetDirtyColumns
            Return _dirtyColumns
        End Function

        Private _db As Southwind.NorthwindDB
        Public Sub New(connectionString As String, providerName As String)
            _db = New Southwind.NorthwindDB(connectionString, providerName)
            Init()            
         End Sub
        Private Sub Init()
            TestMode = Me._db.Provider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase)
            _dirtyColumns = New List(Of IColumn)()
            If TestMode Then
                Employee.SetTestRepo()
                _repo=_testRepo
            Else
                _repo = New SubSonicRepository(Of Employee)(_db)
            End If
            tbl=_repo.GetTable()
            _isNew = True
            OnCreated()       
      
        End Sub
        
        Public Sub New()
             _db = New Southwind.NorthwindDB()
            Init()            
        End Sub
        
       
        Private Partial Sub OnCreated()
		End Sub
            
        Private Partial Sub OnLoaded()
		End Sub
        
		Private Partial Sub OnSaved()
		End Sub
        
		Private Partial Sub OnChanged()
		End Sub

		Public ReadOnly Property Columns As IList(Of IColumn)
            Get
                Return tbl.Columns
            End Get
        End Property

        Public Sub New(expression As Expression(Of Func(Of Employee, Boolean)))
			MyBase.New()
            _isLoaded=_repo.Load(Me,expression)
            If _isLoaded Then OnLoaded()
        End Sub
        
       
        
        Friend Shared Function GetRepo(connectionString As String, providerName As String) As IRepository(Of Employee)
            Dim db As Southwind.NorthwindDB
            If String.IsNullOrEmpty(connectionString)
                db = New Southwind.NorthwindDB()
            Else
                db = New Southwind.NorthwindDB(connectionString, providerName)
            End If
            Dim _repo As IRepository(Of Employee)
            
            If db.TestMode Then
                Employee.SetTestRepo()
                _repo = _testRepo
            Else
                _repo = New SubSonicRepository(Of Employee)(db)
            End If
            Return _repo
        End Function
        
        Friend Shared Function GetRepo() As IRepository(Of Employee)
            Return GetRepo(String.Empty,String.Empty)
        End Function
        
        Public Shared Function SingleOrDefault(expression As Expression(Of Func(Of Employee, Boolean))) As Employee

            Dim repo = GetRepo()
            Dim results = repo.Find(expression)
            Dim singleItem As Employee = Nothing
            If results.Count() > 0 Then
                singleItem = results.ToList()(0)
                singleItem.OnLoaded()
                singleItem.SetIsLoaded(true)
            End If

            Return singleItem
        End Function  
        
        Public Shared Function SingleOrDefault(expression As Expression(Of Func(Of Employee, Boolean)), _
											   connectionString As String, _
											   providerName As String) As Employee
			Dim repo = GetRepo(connectionString,providerName)
            Dim results = repo.Find(expression)
            Dim singleItem As Employee = Nothing
            If results.Count() > 0 Then
                singleItem = results.ToList()(0)
                singleItem.OnLoaded()
                singleItem.SetIsLoaded(true)
            End If

            Return singleItem
		End Function
        
        
        Public Shared Function Exists(expression As Expression(Of Func(Of Employee, Boolean)), connectionString As String, providerName As String) As Boolean
        	Return All(connectionString,providerName).Any(expression)
        End Function
		
        Public Shared Function Exists(expression As Expression(Of Func(Of Employee, Boolean))) As Boolean
            Return All().Any(expression)
        End Function        

        Public Shared Function Find(expression As Expression(Of Func(Of Employee, Boolean))) As IList(Of Employee)
            Dim repo = GetRepo()
            Return repo.Find(expression).ToList()
        End Function
        
        Public Shared Function Find(expression As Expression(Of Func(Of Employee, Boolean)), connectionString As String, providerName As String) As IList(Of Employee)
            Dim repo = GetRepo(connectionString,providerName)
            Return repo.Find(expression).ToList()
        End Function
        Public Shared Function All(connectionString As String, providerName As String) As IQueryable(Of Employee)
            Return GetRepo(connectionString,providerName).GetAll()
        End Function
        Public Shared Function All() As IQueryable(Of Employee)
            Return GetRepo().GetAll()
        End Function
        
        Public Shared Function GetPaged(sortBy As String, pageIndex As Integer, pageSize As Integer, connectionString As String, providerName As String) As PagedList(Of Employee)
            Return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize)
        End Function
      
        Public Shared Function GetPaged(sortBy As String, pageIndex As Integer, pageSize As Integer) As PagedList(Of Employee)
            Return GetRepo().GetPaged(sortBy, pageIndex, pageSize)
        End Function

        Public Shared Function GetPaged(pageIndex As Integer, pageSize As Integer, connectionString As String, providerName As String) As PagedList(Of Employee)
            Return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize)
        End Function

        Public Shared Function GetPaged(pageIndex As Integer, pageSize As Integer) As PagedList(Of Employee)
            Return GetRepo().GetPaged(pageIndex, pageSize)
        End Function

        Public Function KeyName() As String Implements IActiveRecord.KeyName
            Return "EmployeeID"
        End Function

        Public Function KeyValue() As Object Implements IActiveRecord.KeyValue
            Return Me.EmployeeID
        End Function
        
        Public Sub SetKeyValue(value As Object) Implements IActiveRecord.SetKeyValue
            If value IsNot Nothing AndAlso value IsNot DBNull.Value Then
                Dim settable = value.ChangeTypeTo(Of Integer)()
                Me.GetType.GetProperty(Me.KeyName()).SetValue(Me, settable, Nothing)
            End If
        End Sub
        
        Public Overrides Function ToString() As String
            Return Me.LastName.ToString()
        End Function

        Public Overrides Function Equals(obj As Object) As Boolean
            If obj.GetType() Is GetType(Employee) Then
                Dim compareItem As Employee = obj
                Return compareItem.KeyValue() = Me.KeyValue()
            Else
                Return MyBase.Equals(obj)
            End If
        End Function

        Public Function DescriptorValue() As String Implements IActiveRecord.DescriptorValue
            Return Me.LastName.ToString()
        End Function

        Public Function DescriptorColumn() As String Implements IActiveRecord.DescriptorColumn
            Return "LastName"
        End Function
        Public Shared Function GetKeyColumn() As String 
            Return "EmployeeID"
        End Function
        Public Shared Function GetDescriptorColumn() As String
            Return "LastName"
        End Function
        
       #Region " Foreign Keys "
        Public ReadOnly Property [Employees] As IQueryable(Of Employee)
            Get
                  Dim repo = Southwind.Employee.GetRepo()
                  Return From items In repo.GetAll() _
                       	Where items.EmployeeID = _ReportsTo _
                       Select items
            End Get
        End Property

        Public ReadOnly Property [EmployeeTerritories] As IQueryable(Of EmployeeTerritory)
            Get
                  Dim repo = Southwind.EmployeeTerritory.GetRepo()
                  Return From items In repo.GetAll() _
                       	Where items.EmployeeID = _EmployeeID _
                       Select items
            End Get
        End Property

        Public ReadOnly Property [Orders] As IQueryable(Of Order)
            Get
                  Dim repo = Southwind.Order.GetRepo()
                  Return From items In repo.GetAll() _
                       	Where items.EmployeeID = _EmployeeID _
                       Select items
            End Get
        End Property

        #End Region

        Private _EmployeeID As Integer
        Public Property [EmployeeID] As Integer
            Get
				Return _EmployeeID
			End Get
            Set(value As Integer)
                _EmployeeID = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "EmployeeID")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _LastName As String
        Public Property [LastName] As String
            Get
				Return _LastName
			End Get
            Set(value As String)
                _LastName = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "LastName")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _FirstName As String
        Public Property [FirstName] As String
            Get
				Return _FirstName
			End Get
            Set(value As String)
                _FirstName = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "FirstName")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _Title As String
        Public Property [Title] As String
            Get
				Return _Title
			End Get
            Set(value As String)
                _Title = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "Title")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _TitleOfCourtesy As String
        Public Property [TitleOfCourtesy] As String
            Get
				Return _TitleOfCourtesy
			End Get
            Set(value As String)
                _TitleOfCourtesy = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "TitleOfCourtesy")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _BirthDate As Date?
        Public Property [BirthDate] As Date?
            Get
				Return _BirthDate
			End Get
            Set(value As Date?)
                _BirthDate = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "BirthDate")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _HireDate As Date?
        Public Property [HireDate] As Date?
            Get
				Return _HireDate
			End Get
            Set(value As Date?)
                _HireDate = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "HireDate")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _Address As String
        Public Property [Address] As String
            Get
				Return _Address
			End Get
            Set(value As String)
                _Address = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "Address")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _City As String
        Public Property [City] As String
            Get
				Return _City
			End Get
            Set(value As String)
                _City = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "City")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _Region As String
        Public Property [Region] As String
            Get
				Return _Region
			End Get
            Set(value As String)
                _Region = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "Region")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _PostalCode As String
        Public Property [PostalCode] As String
            Get
				Return _PostalCode
			End Get
            Set(value As String)
                _PostalCode = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "PostalCode")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _Country As String
        Public Property [Country] As String
            Get
				Return _Country
			End Get
            Set(value As String)
                _Country = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "Country")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _HomePhone As String
        Public Property [HomePhone] As String
            Get
				Return _HomePhone
			End Get
            Set(value As String)
                _HomePhone = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "HomePhone")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _Extension As String
        Public Property [Extension] As String
            Get
				Return _Extension
			End Get
            Set(value As String)
                _Extension = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "Extension")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _Photo As Byte()
        Public Property [Photo] As Byte()
            Get
				Return _Photo
			End Get
            Set(value As Byte())
                _Photo = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "Photo")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _Notes As String
        Public Property [Notes] As String
            Get
				Return _Notes
			End Get
            Set(value As String)
                _Notes = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "Notes")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _ReportsTo As Integer?
        Public Property [ReportsTo] As Integer?
            Get
				Return _ReportsTo
			End Get
            Set(value As Integer?)
                _ReportsTo = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "ReportsTo")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property

        Private _PhotoPath As String
        Public Property [PhotoPath] As String
            Get
				Return _PhotoPath
			End Get
            Set(value As String)
                _PhotoPath = value
                Dim col = tbl.Columns.SingleOrDefault(Function(x) x.Name = "PhotoPath")
                If col IsNot Nothing Then
                    If Not _dirtyColumns.Any(Function(x) x.Name = col.Name) AndAlso _isLoaded Then
                        _dirtyColumns.Add(col)
                    End If
                End If
                OnChanged()
            End Set
        End Property



        Public Function GetUpdateCommand() As DbCommand Implements IActiveRecord.GetUpdateCommand
            If TestMode Then
                Return _db.Provider.CreateCommand()
            Else
                Return Me.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand()
            End If
        End Function
        Public Function GetInsertCommand() As DbCommand Implements IActiveRecord.GetInsertCommand
            If TestMode Then
                Return _db.Provider.CreateCommand()
            Else
                Return Me.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand()
			End If
        End Function
        
        Public Function GetDeleteCommand() As DbCommand Implements IActiveRecord.GetDeleteCommand
            If TestMode Then
                Return _db.Provider.CreateCommand()
            Else
                Return Me.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand()
			End If
        End Function
       
        
        Public Sub Update() Implements IActiveRecord.Update
            Update(_db.Provider)
        End Sub
        
        Public Sub Update(provider As IDataProvider) Implements IActiveRecord.Update
        
            If Me._dirtyColumns.Count > 0 Then _repo.Update(Me,provider)
			
            OnSaved()
        End Sub
 
        Public Sub Add() Implements IActiveRecord.Add
            Add(_db.Provider)
        End Sub
        
        
       
        Public Sub Add(provider As IDataProvider) Implements IActiveRecord.Add

            Me.SetKeyValue(_repo.Add(Me,provider))
            OnSaved()
        End Sub
        
                
        
        Public Sub Save() Implements IActiveRecord.Save
            Save(_db.Provider)
        End Sub
        Public Sub Save(provider As IDataProvider) Implements IActiveRecord.Save
            If _isNew Then
                Add(provider)
            Else
                Update(provider)
			End If
        End Sub

        

        Public Sub Delete(provider As IDataProvider)
                   
                 
            _repo.Delete(KeyValue())
            
                    End Sub


        Public Sub Delete() Implements IActiveRecord.Delete
            Delete(_db.Provider)
        End Sub


        Public Shared Sub Delete(expression As Expression(Of Func(Of Employee, Boolean)))
            Dim repo = GetRepo()
            
       
            
            repo.DeleteMany(expression)
            
        End Sub

        

        Public Sub Load(rdr As IDataReader) Implements IActiveRecord.Load
            Load(rdr, true)
        End Sub
        Public Sub Load(rdr As IDataReader, closeReader As Boolean) Implements IActiveRecord.Load
            If rdr.Read() Then
                Try
                    rdr.Load(Me)
                    _isNew = False
                    _isLoaded = True
                Catch
                    _isLoaded = False
                    Throw
                End Try
            Else
                _isLoaded = False
            End If

            If closeReader Then rdr.Dispose()

        End Sub
	End Class
End NameSpace
