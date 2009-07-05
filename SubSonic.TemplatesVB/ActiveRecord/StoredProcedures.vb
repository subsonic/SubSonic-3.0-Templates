


  
Imports System
Imports SubSonic
Imports SubSonic.Schema
Imports SubSonic.DataProviders

NameSpace Southwind

	Public Class SPs

        Public Shared Function CustOrderHist(CustomerID As String) As StoredProcedure
            Dim sp As New StoredProcedure("CustOrderHist",ProviderFactory.GetProvider("Northwind"))
            sp.Command.AddParameter("CustomerID",CustomerID)
            Return sp
        End Function
        Public Shared Function CustOrdersDetail(OrderID As Integer) As StoredProcedure
            Dim sp As New StoredProcedure("CustOrdersDetail",ProviderFactory.GetProvider("Northwind"))
            sp.Command.AddParameter("OrderID",OrderID)
            Return sp
        End Function
        Public Shared Function CustOrdersOrders(CustomerID As String) As StoredProcedure
            Dim sp As New StoredProcedure("CustOrdersOrders",ProviderFactory.GetProvider("Northwind"))
            sp.Command.AddParameter("CustomerID",CustomerID)
            Return sp
        End Function
        Public Shared Function EmployeeSalesbyCountry(Beginning_Date As Date,Ending_Date As Date) As StoredProcedure
            Dim sp As New StoredProcedure("Employee Sales by Country",ProviderFactory.GetProvider("Northwind"))
            sp.Command.AddParameter("Beginning_Date",Beginning_Date)
            sp.Command.AddParameter("Ending_Date",Ending_Date)
            Return sp
        End Function
        Public Shared Function SalesbyYear(Beginning_Date As Date,Ending_Date As Date) As StoredProcedure
            Dim sp As New StoredProcedure("Sales by Year",ProviderFactory.GetProvider("Northwind"))
            sp.Command.AddParameter("Beginning_Date",Beginning_Date)
            sp.Command.AddParameter("Ending_Date",Ending_Date)
            Return sp
        End Function
        Public Shared Function SalesByCategory(CategoryName As String,OrdYear As String) As StoredProcedure
            Dim sp As New StoredProcedure("SalesByCategory",ProviderFactory.GetProvider("Northwind"))
            sp.Command.AddParameter("CategoryName",CategoryName)
            sp.Command.AddParameter("OrdYear",OrdYear)
            Return sp
        End Function
        Public Shared Function TenMostExpensiveProducts() As StoredProcedure
            Dim sp As New StoredProcedure("Ten Most Expensive Products",ProviderFactory.GetProvider("Northwind"))
            Return sp
        End Function
	
	End Class
	
End NameSpace
 