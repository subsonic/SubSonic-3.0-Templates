


  
using System;
using SubSonic;
using SubSonic.Schema;
using SubSonic.DataProviders;

namespace WestWind{
	public partial class NorthwindDB{

        public StoredProcedure CustOrderHist(string CustomerID){
            StoredProcedure sp=new StoredProcedure("CustOrderHist",this.Provider);
            sp.Command.AddParameter("CustomerID",CustomerID);
            return sp;
        }
        public StoredProcedure CustOrdersDetail(int OrderID){
            StoredProcedure sp=new StoredProcedure("CustOrdersDetail",this.Provider);
            sp.Command.AddParameter("OrderID",OrderID);
            return sp;
        }
        public StoredProcedure CustOrdersOrders(string CustomerID){
            StoredProcedure sp=new StoredProcedure("CustOrdersOrders",this.Provider);
            sp.Command.AddParameter("CustomerID",CustomerID);
            return sp;
        }
        public StoredProcedure EmployeeSalesbyCountry(DateTime Beginning_Date,DateTime Ending_Date){
            StoredProcedure sp=new StoredProcedure("Employee Sales by Country",this.Provider);
            sp.Command.AddParameter("Beginning_Date",Beginning_Date);
            sp.Command.AddParameter("Ending_Date",Ending_Date);
            return sp;
        }
        public StoredProcedure SalesbyYear(DateTime Beginning_Date,DateTime Ending_Date){
            StoredProcedure sp=new StoredProcedure("Sales by Year",this.Provider);
            sp.Command.AddParameter("Beginning_Date",Beginning_Date);
            sp.Command.AddParameter("Ending_Date",Ending_Date);
            return sp;
        }
        public StoredProcedure SalesByCategory(string CategoryName,string OrdYear){
            StoredProcedure sp=new StoredProcedure("SalesByCategory",this.Provider);
            sp.Command.AddParameter("CategoryName",CategoryName);
            sp.Command.AddParameter("OrdYear",OrdYear);
            return sp;
        }
        public StoredProcedure TenMostExpensiveProducts(){
            StoredProcedure sp=new StoredProcedure("Ten Most Expensive Products",this.Provider);
            return sp;
        }
	
	}
	
}
 