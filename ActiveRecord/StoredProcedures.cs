


  
using System;
using SubSonic;
using SubSonic.Schema;
using SubSonic.DataProviders;

namespace Southwind{
	public class SPs{

        public static StoredProcedure CustOrderHist(string CustomerID){
            StoredProcedure sp=new StoredProcedure("CustOrderHist",ProviderFactory.GetProvider("Northwind"));
            sp.Command.AddParameter("CustomerID",CustomerID);
            return sp;
        }
        public static StoredProcedure CustOrdersDetail(int OrderID){
            StoredProcedure sp=new StoredProcedure("CustOrdersDetail",ProviderFactory.GetProvider("Northwind"));
            sp.Command.AddParameter("OrderID",OrderID);
            return sp;
        }
        public static StoredProcedure CustOrdersOrders(string CustomerID){
            StoredProcedure sp=new StoredProcedure("CustOrdersOrders",ProviderFactory.GetProvider("Northwind"));
            sp.Command.AddParameter("CustomerID",CustomerID);
            return sp;
        }
        public static StoredProcedure EmployeeSalesbyCountry(DateTime Beginning_Date,DateTime Ending_Date){
            StoredProcedure sp=new StoredProcedure("Employee Sales by Country",ProviderFactory.GetProvider("Northwind"));
            sp.Command.AddParameter("Beginning_Date",Beginning_Date);
            sp.Command.AddParameter("Ending_Date",Ending_Date);
            return sp;
        }
        public static StoredProcedure SalesbyYear(DateTime Beginning_Date,DateTime Ending_Date){
            StoredProcedure sp=new StoredProcedure("Sales by Year",ProviderFactory.GetProvider("Northwind"));
            sp.Command.AddParameter("Beginning_Date",Beginning_Date);
            sp.Command.AddParameter("Ending_Date",Ending_Date);
            return sp;
        }
        public static StoredProcedure SalesByCategory(string CategoryName,string OrdYear){
            StoredProcedure sp=new StoredProcedure("SalesByCategory",ProviderFactory.GetProvider("Northwind"));
            sp.Command.AddParameter("CategoryName",CategoryName);
            sp.Command.AddParameter("OrdYear",OrdYear);
            return sp;
        }
        public static StoredProcedure TenMostExpensiveProducts(){
            StoredProcedure sp=new StoredProcedure("Ten Most Expensive Products",ProviderFactory.GetProvider("Northwind"));
            return sp;
        }
	
	}
	
}
 