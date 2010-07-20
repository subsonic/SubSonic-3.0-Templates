


using System;
using System.ComponentModel;
using System.Linq;

namespace WestWind
{
    
    
    
    
    /// <summary>
    /// A class which represents the Categories table in the Northwind Database.
    /// This class is queryable through NorthwindDB.Category 
    /// </summary>

	public partial class Category: INotifyPropertyChanging, INotifyPropertyChanged
	{
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
	    
	    public Category(){
	        OnCreated();
	    }
	    
	    #region Properties
	    
        partial void OnCategoryIDChanging(int value);
        partial void OnCategoryIDChanged();
		
		private int _CategoryID;
		public int CategoryID { 
		    get{
		        return _CategoryID;
		    } 
		    set{
		        this.OnCategoryIDChanging(value);
                this.SendPropertyChanging();
                this._CategoryID = value;
                this.SendPropertyChanged("CategoryID");
                this.OnCategoryIDChanged();
		    }
		}
		
        partial void OnCategoryNameChanging(string value);
        partial void OnCategoryNameChanged();
		
		private string _CategoryName;
		public string CategoryName { 
		    get{
		        return _CategoryName;
		    } 
		    set{
		        this.OnCategoryNameChanging(value);
                this.SendPropertyChanging();
                this._CategoryName = value;
                this.SendPropertyChanged("CategoryName");
                this.OnCategoryNameChanged();
		    }
		}
		
        partial void OnDescriptionChanging(string value);
        partial void OnDescriptionChanged();
		
		private string _Description;
		public string Description { 
		    get{
		        return _Description;
		    } 
		    set{
		        this.OnDescriptionChanging(value);
                this.SendPropertyChanging();
                this._Description = value;
                this.SendPropertyChanged("Description");
                this.OnDescriptionChanged();
		    }
		}
		
        partial void OnPictureChanging(byte[] value);
        partial void OnPictureChanged();
		
		private byte[] _Picture;
		public byte[] Picture { 
		    get{
		        return _Picture;
		    } 
		    set{
		        this.OnPictureChanging(value);
                this.SendPropertyChanging();
                this._Picture = value;
                this.SendPropertyChanged("Picture");
                this.OnPictureChanged();
		    }
		}
		

        #endregion

        #region Foreign Keys
        public IQueryable<Product> Products
        {
            get
            {
                  var db=new WestWind.NorthwindDB();
                  return from items in db.Products
                       where items.CategoryID == _CategoryID
                       select items;
            }
        }

        #endregion


        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging()
        {
            var handler = PropertyChanging;
            if (handler != null)
               handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

	}
	
    
    
    /// <summary>
    /// A class which represents the Customers table in the Northwind Database.
    /// This class is queryable through NorthwindDB.Customer 
    /// </summary>

	public partial class Customer: INotifyPropertyChanging, INotifyPropertyChanged
	{
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
	    
	    public Customer(){
	        OnCreated();
	    }
	    
	    #region Properties
	    
        partial void OnCustomerIDChanging(string value);
        partial void OnCustomerIDChanged();
		
		private string _CustomerID;
		public string CustomerID { 
		    get{
		        return _CustomerID;
		    } 
		    set{
		        this.OnCustomerIDChanging(value);
                this.SendPropertyChanging();
                this._CustomerID = value;
                this.SendPropertyChanged("CustomerID");
                this.OnCustomerIDChanged();
		    }
		}
		
        partial void OnCompanyNameChanging(string value);
        partial void OnCompanyNameChanged();
		
		private string _CompanyName;
		public string CompanyName { 
		    get{
		        return _CompanyName;
		    } 
		    set{
		        this.OnCompanyNameChanging(value);
                this.SendPropertyChanging();
                this._CompanyName = value;
                this.SendPropertyChanged("CompanyName");
                this.OnCompanyNameChanged();
		    }
		}
		
        partial void OnContactNameChanging(string value);
        partial void OnContactNameChanged();
		
		private string _ContactName;
		public string ContactName { 
		    get{
		        return _ContactName;
		    } 
		    set{
		        this.OnContactNameChanging(value);
                this.SendPropertyChanging();
                this._ContactName = value;
                this.SendPropertyChanged("ContactName");
                this.OnContactNameChanged();
		    }
		}
		
        partial void OnContactTitleChanging(string value);
        partial void OnContactTitleChanged();
		
		private string _ContactTitle;
		public string ContactTitle { 
		    get{
		        return _ContactTitle;
		    } 
		    set{
		        this.OnContactTitleChanging(value);
                this.SendPropertyChanging();
                this._ContactTitle = value;
                this.SendPropertyChanged("ContactTitle");
                this.OnContactTitleChanged();
		    }
		}
		
        partial void OnAddressChanging(string value);
        partial void OnAddressChanged();
		
		private string _Address;
		public string Address { 
		    get{
		        return _Address;
		    } 
		    set{
		        this.OnAddressChanging(value);
                this.SendPropertyChanging();
                this._Address = value;
                this.SendPropertyChanged("Address");
                this.OnAddressChanged();
		    }
		}
		
        partial void OnCityChanging(string value);
        partial void OnCityChanged();
		
		private string _City;
		public string City { 
		    get{
		        return _City;
		    } 
		    set{
		        this.OnCityChanging(value);
                this.SendPropertyChanging();
                this._City = value;
                this.SendPropertyChanged("City");
                this.OnCityChanged();
		    }
		}
		
        partial void OnRegionChanging(string value);
        partial void OnRegionChanged();
		
		private string _Region;
		public string Region { 
		    get{
		        return _Region;
		    } 
		    set{
		        this.OnRegionChanging(value);
                this.SendPropertyChanging();
                this._Region = value;
                this.SendPropertyChanged("Region");
                this.OnRegionChanged();
		    }
		}
		
        partial void OnPostalCodeChanging(string value);
        partial void OnPostalCodeChanged();
		
		private string _PostalCode;
		public string PostalCode { 
		    get{
		        return _PostalCode;
		    } 
		    set{
		        this.OnPostalCodeChanging(value);
                this.SendPropertyChanging();
                this._PostalCode = value;
                this.SendPropertyChanged("PostalCode");
                this.OnPostalCodeChanged();
		    }
		}
		
        partial void OnCountryChanging(string value);
        partial void OnCountryChanged();
		
		private string _Country;
		public string Country { 
		    get{
		        return _Country;
		    } 
		    set{
		        this.OnCountryChanging(value);
                this.SendPropertyChanging();
                this._Country = value;
                this.SendPropertyChanged("Country");
                this.OnCountryChanged();
		    }
		}
		
        partial void OnPhoneChanging(string value);
        partial void OnPhoneChanged();
		
		private string _Phone;
		public string Phone { 
		    get{
		        return _Phone;
		    } 
		    set{
		        this.OnPhoneChanging(value);
                this.SendPropertyChanging();
                this._Phone = value;
                this.SendPropertyChanged("Phone");
                this.OnPhoneChanged();
		    }
		}
		
        partial void OnFaxChanging(string value);
        partial void OnFaxChanged();
		
		private string _Fax;
		public string Fax { 
		    get{
		        return _Fax;
		    } 
		    set{
		        this.OnFaxChanging(value);
                this.SendPropertyChanging();
                this._Fax = value;
                this.SendPropertyChanged("Fax");
                this.OnFaxChanged();
		    }
		}
		

        #endregion

        #region Foreign Keys
        public IQueryable<CustomerCustomerDemo> CustomerCustomerDemos
        {
            get
            {
                  var db=new WestWind.NorthwindDB();
                  return from items in db.CustomerCustomerDemos
                       where items.CustomerID == _CustomerID
                       select items;
            }
        }

        public IQueryable<Order> Orders
        {
            get
            {
                  var db=new WestWind.NorthwindDB();
                  return from items in db.Orders
                       where items.CustomerID == _CustomerID
                       select items;
            }
        }

        #endregion


        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging()
        {
            var handler = PropertyChanging;
            if (handler != null)
               handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

	}
	
    
    
    /// <summary>
    /// A class which represents the Shippers table in the Northwind Database.
    /// This class is queryable through NorthwindDB.Shipper 
    /// </summary>

	public partial class Shipper: INotifyPropertyChanging, INotifyPropertyChanged
	{
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
	    
	    public Shipper(){
	        OnCreated();
	    }
	    
	    #region Properties
	    
        partial void OnShipperIDChanging(int value);
        partial void OnShipperIDChanged();
		
		private int _ShipperID;
		public int ShipperID { 
		    get{
		        return _ShipperID;
		    } 
		    set{
		        this.OnShipperIDChanging(value);
                this.SendPropertyChanging();
                this._ShipperID = value;
                this.SendPropertyChanged("ShipperID");
                this.OnShipperIDChanged();
		    }
		}
		
        partial void OnCompanyNameChanging(string value);
        partial void OnCompanyNameChanged();
		
		private string _CompanyName;
		public string CompanyName { 
		    get{
		        return _CompanyName;
		    } 
		    set{
		        this.OnCompanyNameChanging(value);
                this.SendPropertyChanging();
                this._CompanyName = value;
                this.SendPropertyChanged("CompanyName");
                this.OnCompanyNameChanged();
		    }
		}
		
        partial void OnPhoneChanging(string value);
        partial void OnPhoneChanged();
		
		private string _Phone;
		public string Phone { 
		    get{
		        return _Phone;
		    } 
		    set{
		        this.OnPhoneChanging(value);
                this.SendPropertyChanging();
                this._Phone = value;
                this.SendPropertyChanged("Phone");
                this.OnPhoneChanged();
		    }
		}
		

        #endregion

        #region Foreign Keys
        public IQueryable<Order> Orders
        {
            get
            {
                  var db=new WestWind.NorthwindDB();
                  return from items in db.Orders
                       where items.ShipVia == _ShipperID
                       select items;
            }
        }

        #endregion


        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging()
        {
            var handler = PropertyChanging;
            if (handler != null)
               handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

	}
	
    
    
    /// <summary>
    /// A class which represents the Suppliers table in the Northwind Database.
    /// This class is queryable through NorthwindDB.Supplier 
    /// </summary>

	public partial class Supplier: INotifyPropertyChanging, INotifyPropertyChanged
	{
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
	    
	    public Supplier(){
	        OnCreated();
	    }
	    
	    #region Properties
	    
        partial void OnSupplierIDChanging(int value);
        partial void OnSupplierIDChanged();
		
		private int _SupplierID;
		public int SupplierID { 
		    get{
		        return _SupplierID;
		    } 
		    set{
		        this.OnSupplierIDChanging(value);
                this.SendPropertyChanging();
                this._SupplierID = value;
                this.SendPropertyChanged("SupplierID");
                this.OnSupplierIDChanged();
		    }
		}
		
        partial void OnCompanyNameChanging(string value);
        partial void OnCompanyNameChanged();
		
		private string _CompanyName;
		public string CompanyName { 
		    get{
		        return _CompanyName;
		    } 
		    set{
		        this.OnCompanyNameChanging(value);
                this.SendPropertyChanging();
                this._CompanyName = value;
                this.SendPropertyChanged("CompanyName");
                this.OnCompanyNameChanged();
		    }
		}
		
        partial void OnContactNameChanging(string value);
        partial void OnContactNameChanged();
		
		private string _ContactName;
		public string ContactName { 
		    get{
		        return _ContactName;
		    } 
		    set{
		        this.OnContactNameChanging(value);
                this.SendPropertyChanging();
                this._ContactName = value;
                this.SendPropertyChanged("ContactName");
                this.OnContactNameChanged();
		    }
		}
		
        partial void OnContactTitleChanging(string value);
        partial void OnContactTitleChanged();
		
		private string _ContactTitle;
		public string ContactTitle { 
		    get{
		        return _ContactTitle;
		    } 
		    set{
		        this.OnContactTitleChanging(value);
                this.SendPropertyChanging();
                this._ContactTitle = value;
                this.SendPropertyChanged("ContactTitle");
                this.OnContactTitleChanged();
		    }
		}
		
        partial void OnAddressChanging(string value);
        partial void OnAddressChanged();
		
		private string _Address;
		public string Address { 
		    get{
		        return _Address;
		    } 
		    set{
		        this.OnAddressChanging(value);
                this.SendPropertyChanging();
                this._Address = value;
                this.SendPropertyChanged("Address");
                this.OnAddressChanged();
		    }
		}
		
        partial void OnCityChanging(string value);
        partial void OnCityChanged();
		
		private string _City;
		public string City { 
		    get{
		        return _City;
		    } 
		    set{
		        this.OnCityChanging(value);
                this.SendPropertyChanging();
                this._City = value;
                this.SendPropertyChanged("City");
                this.OnCityChanged();
		    }
		}
		
        partial void OnRegionChanging(string value);
        partial void OnRegionChanged();
		
		private string _Region;
		public string Region { 
		    get{
		        return _Region;
		    } 
		    set{
		        this.OnRegionChanging(value);
                this.SendPropertyChanging();
                this._Region = value;
                this.SendPropertyChanged("Region");
                this.OnRegionChanged();
		    }
		}
		
        partial void OnPostalCodeChanging(string value);
        partial void OnPostalCodeChanged();
		
		private string _PostalCode;
		public string PostalCode { 
		    get{
		        return _PostalCode;
		    } 
		    set{
		        this.OnPostalCodeChanging(value);
                this.SendPropertyChanging();
                this._PostalCode = value;
                this.SendPropertyChanged("PostalCode");
                this.OnPostalCodeChanged();
		    }
		}
		
        partial void OnCountryChanging(string value);
        partial void OnCountryChanged();
		
		private string _Country;
		public string Country { 
		    get{
		        return _Country;
		    } 
		    set{
		        this.OnCountryChanging(value);
                this.SendPropertyChanging();
                this._Country = value;
                this.SendPropertyChanged("Country");
                this.OnCountryChanged();
		    }
		}
		
        partial void OnPhoneChanging(string value);
        partial void OnPhoneChanged();
		
		private string _Phone;
		public string Phone { 
		    get{
		        return _Phone;
		    } 
		    set{
		        this.OnPhoneChanging(value);
                this.SendPropertyChanging();
                this._Phone = value;
                this.SendPropertyChanged("Phone");
                this.OnPhoneChanged();
		    }
		}
		
        partial void OnFaxChanging(string value);
        partial void OnFaxChanged();
		
		private string _Fax;
		public string Fax { 
		    get{
		        return _Fax;
		    } 
		    set{
		        this.OnFaxChanging(value);
                this.SendPropertyChanging();
                this._Fax = value;
                this.SendPropertyChanged("Fax");
                this.OnFaxChanged();
		    }
		}
		
        partial void OnHomePageChanging(string value);
        partial void OnHomePageChanged();
		
		private string _HomePage;
		public string HomePage { 
		    get{
		        return _HomePage;
		    } 
		    set{
		        this.OnHomePageChanging(value);
                this.SendPropertyChanging();
                this._HomePage = value;
                this.SendPropertyChanged("HomePage");
                this.OnHomePageChanged();
		    }
		}
		

        #endregion

        #region Foreign Keys
        public IQueryable<Product> Products
        {
            get
            {
                  var db=new WestWind.NorthwindDB();
                  return from items in db.Products
                       where items.SupplierID == _SupplierID
                       select items;
            }
        }

        #endregion


        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging()
        {
            var handler = PropertyChanging;
            if (handler != null)
               handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

	}
	
    
    
    /// <summary>
    /// A class which represents the Orders table in the Northwind Database.
    /// This class is queryable through NorthwindDB.Order 
    /// </summary>

	public partial class Order: INotifyPropertyChanging, INotifyPropertyChanged
	{
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
	    
	    public Order(){
	        OnCreated();
	    }
	    
	    #region Properties
	    
        partial void OnOrderIDChanging(int value);
        partial void OnOrderIDChanged();
		
		private int _OrderID;
		public int OrderID { 
		    get{
		        return _OrderID;
		    } 
		    set{
		        this.OnOrderIDChanging(value);
                this.SendPropertyChanging();
                this._OrderID = value;
                this.SendPropertyChanged("OrderID");
                this.OnOrderIDChanged();
		    }
		}
		
        partial void OnCustomerIDChanging(string value);
        partial void OnCustomerIDChanged();
		
		private string _CustomerID;
		public string CustomerID { 
		    get{
		        return _CustomerID;
		    } 
		    set{
		        this.OnCustomerIDChanging(value);
                this.SendPropertyChanging();
                this._CustomerID = value;
                this.SendPropertyChanged("CustomerID");
                this.OnCustomerIDChanged();
		    }
		}
		
        partial void OnEmployeeIDChanging(int? value);
        partial void OnEmployeeIDChanged();
		
		private int? _EmployeeID;
		public int? EmployeeID { 
		    get{
		        return _EmployeeID;
		    } 
		    set{
		        this.OnEmployeeIDChanging(value);
                this.SendPropertyChanging();
                this._EmployeeID = value;
                this.SendPropertyChanged("EmployeeID");
                this.OnEmployeeIDChanged();
		    }
		}
		
        partial void OnOrderDateChanging(DateTime value);
        partial void OnOrderDateChanged();
		
		private DateTime _OrderDate;
		public DateTime OrderDate { 
		    get{
		        return _OrderDate;
		    } 
		    set{
		        this.OnOrderDateChanging(value);
                this.SendPropertyChanging();
                this._OrderDate = value;
                this.SendPropertyChanged("OrderDate");
                this.OnOrderDateChanged();
		    }
		}
		
        partial void OnRequiredDateChanging(DateTime? value);
        partial void OnRequiredDateChanged();
		
		private DateTime? _RequiredDate;
		public DateTime? RequiredDate { 
		    get{
		        return _RequiredDate;
		    } 
		    set{
		        this.OnRequiredDateChanging(value);
                this.SendPropertyChanging();
                this._RequiredDate = value;
                this.SendPropertyChanged("RequiredDate");
                this.OnRequiredDateChanged();
		    }
		}
		
        partial void OnShippedDateChanging(DateTime? value);
        partial void OnShippedDateChanged();
		
		private DateTime? _ShippedDate;
		public DateTime? ShippedDate { 
		    get{
		        return _ShippedDate;
		    } 
		    set{
		        this.OnShippedDateChanging(value);
                this.SendPropertyChanging();
                this._ShippedDate = value;
                this.SendPropertyChanged("ShippedDate");
                this.OnShippedDateChanged();
		    }
		}
		
        partial void OnShipViaChanging(int? value);
        partial void OnShipViaChanged();
		
		private int? _ShipVia;
		public int? ShipVia { 
		    get{
		        return _ShipVia;
		    } 
		    set{
		        this.OnShipViaChanging(value);
                this.SendPropertyChanging();
                this._ShipVia = value;
                this.SendPropertyChanged("ShipVia");
                this.OnShipViaChanged();
		    }
		}
		
        partial void OnFreightChanging(decimal? value);
        partial void OnFreightChanged();
		
		private decimal? _Freight;
		public decimal? Freight { 
		    get{
		        return _Freight;
		    } 
		    set{
		        this.OnFreightChanging(value);
                this.SendPropertyChanging();
                this._Freight = value;
                this.SendPropertyChanged("Freight");
                this.OnFreightChanged();
		    }
		}
		
        partial void OnShipNameChanging(string value);
        partial void OnShipNameChanged();
		
		private string _ShipName;
		public string ShipName { 
		    get{
		        return _ShipName;
		    } 
		    set{
		        this.OnShipNameChanging(value);
                this.SendPropertyChanging();
                this._ShipName = value;
                this.SendPropertyChanged("ShipName");
                this.OnShipNameChanged();
		    }
		}
		
        partial void OnShipAddressChanging(string value);
        partial void OnShipAddressChanged();
		
		private string _ShipAddress;
		public string ShipAddress { 
		    get{
		        return _ShipAddress;
		    } 
		    set{
		        this.OnShipAddressChanging(value);
                this.SendPropertyChanging();
                this._ShipAddress = value;
                this.SendPropertyChanged("ShipAddress");
                this.OnShipAddressChanged();
		    }
		}
		
        partial void OnShipCityChanging(string value);
        partial void OnShipCityChanged();
		
		private string _ShipCity;
		public string ShipCity { 
		    get{
		        return _ShipCity;
		    } 
		    set{
		        this.OnShipCityChanging(value);
                this.SendPropertyChanging();
                this._ShipCity = value;
                this.SendPropertyChanged("ShipCity");
                this.OnShipCityChanged();
		    }
		}
		
        partial void OnShipRegionChanging(string value);
        partial void OnShipRegionChanged();
		
		private string _ShipRegion;
		public string ShipRegion { 
		    get{
		        return _ShipRegion;
		    } 
		    set{
		        this.OnShipRegionChanging(value);
                this.SendPropertyChanging();
                this._ShipRegion = value;
                this.SendPropertyChanged("ShipRegion");
                this.OnShipRegionChanged();
		    }
		}
		
        partial void OnShipPostalCodeChanging(string value);
        partial void OnShipPostalCodeChanged();
		
		private string _ShipPostalCode;
		public string ShipPostalCode { 
		    get{
		        return _ShipPostalCode;
		    } 
		    set{
		        this.OnShipPostalCodeChanging(value);
                this.SendPropertyChanging();
                this._ShipPostalCode = value;
                this.SendPropertyChanged("ShipPostalCode");
                this.OnShipPostalCodeChanged();
		    }
		}
		
        partial void OnShipCountryChanging(string value);
        partial void OnShipCountryChanged();
		
		private string _ShipCountry;
		public string ShipCountry { 
		    get{
		        return _ShipCountry;
		    } 
		    set{
		        this.OnShipCountryChanging(value);
                this.SendPropertyChanging();
                this._ShipCountry = value;
                this.SendPropertyChanged("ShipCountry");
                this.OnShipCountryChanged();
		    }
		}
		

        #endregion

        #region Foreign Keys
        public IQueryable<Customer> Customers
        {
            get
            {
                  var db=new WestWind.NorthwindDB();
                  return from items in db.Customers
                       where items.CustomerID == _CustomerID
                       select items;
            }
        }

        public IQueryable<Employee> Employees
        {
            get
            {
                  var db=new WestWind.NorthwindDB();
                  return from items in db.Employees
                       where items.EmployeeID == _EmployeeID
                       select items;
            }
        }

        public IQueryable<OrderDetail> OrderDetails
        {
            get
            {
                  var db=new WestWind.NorthwindDB();
                  return from items in db.OrderDetails
                       where items.OrderID == _OrderID
                       select items;
            }
        }

        public IQueryable<Shipper> Shippers
        {
            get
            {
                  var db=new WestWind.NorthwindDB();
                  return from items in db.Shippers
                       where items.ShipperID == _ShipVia
                       select items;
            }
        }

        #endregion


        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging()
        {
            var handler = PropertyChanging;
            if (handler != null)
               handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

	}
	
    
    
    /// <summary>
    /// A class which represents the Products table in the Northwind Database.
    /// This class is queryable through NorthwindDB.Product 
    /// </summary>

	public partial class Product: INotifyPropertyChanging, INotifyPropertyChanged
	{
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
	    
	    public Product(){
	        OnCreated();
	    }
	    
	    #region Properties
	    
        partial void OnProductIDChanging(int value);
        partial void OnProductIDChanged();
		
		private int _ProductID;
		public int ProductID { 
		    get{
		        return _ProductID;
		    } 
		    set{
		        this.OnProductIDChanging(value);
                this.SendPropertyChanging();
                this._ProductID = value;
                this.SendPropertyChanged("ProductID");
                this.OnProductIDChanged();
		    }
		}
		
        partial void OnProductNameChanging(string value);
        partial void OnProductNameChanged();
		
		private string _ProductName;
		public string ProductName { 
		    get{
		        return _ProductName;
		    } 
		    set{
		        this.OnProductNameChanging(value);
                this.SendPropertyChanging();
                this._ProductName = value;
                this.SendPropertyChanged("ProductName");
                this.OnProductNameChanged();
		    }
		}
		
        partial void OnSupplierIDChanging(int? value);
        partial void OnSupplierIDChanged();
		
		private int? _SupplierID;
		public int? SupplierID { 
		    get{
		        return _SupplierID;
		    } 
		    set{
		        this.OnSupplierIDChanging(value);
                this.SendPropertyChanging();
                this._SupplierID = value;
                this.SendPropertyChanged("SupplierID");
                this.OnSupplierIDChanged();
		    }
		}
		
        partial void OnCategoryIDChanging(int? value);
        partial void OnCategoryIDChanged();
		
		private int? _CategoryID;
		public int? CategoryID { 
		    get{
		        return _CategoryID;
		    } 
		    set{
		        this.OnCategoryIDChanging(value);
                this.SendPropertyChanging();
                this._CategoryID = value;
                this.SendPropertyChanged("CategoryID");
                this.OnCategoryIDChanged();
		    }
		}
		
        partial void OnQuantityPerUnitChanging(string value);
        partial void OnQuantityPerUnitChanged();
		
		private string _QuantityPerUnit;
		public string QuantityPerUnit { 
		    get{
		        return _QuantityPerUnit;
		    } 
		    set{
		        this.OnQuantityPerUnitChanging(value);
                this.SendPropertyChanging();
                this._QuantityPerUnit = value;
                this.SendPropertyChanged("QuantityPerUnit");
                this.OnQuantityPerUnitChanged();
		    }
		}
		
        partial void OnUnitPriceChanging(decimal? value);
        partial void OnUnitPriceChanged();
		
		private decimal? _UnitPrice;
		public decimal? UnitPrice { 
		    get{
		        return _UnitPrice;
		    } 
		    set{
		        this.OnUnitPriceChanging(value);
                this.SendPropertyChanging();
                this._UnitPrice = value;
                this.SendPropertyChanged("UnitPrice");
                this.OnUnitPriceChanged();
		    }
		}
		
        partial void OnUnitsInStockChanging(short? value);
        partial void OnUnitsInStockChanged();
		
		private short? _UnitsInStock;
		public short? UnitsInStock { 
		    get{
		        return _UnitsInStock;
		    } 
		    set{
		        this.OnUnitsInStockChanging(value);
                this.SendPropertyChanging();
                this._UnitsInStock = value;
                this.SendPropertyChanged("UnitsInStock");
                this.OnUnitsInStockChanged();
		    }
		}
		
        partial void OnUnitsOnOrderChanging(short? value);
        partial void OnUnitsOnOrderChanged();
		
		private short? _UnitsOnOrder;
		public short? UnitsOnOrder { 
		    get{
		        return _UnitsOnOrder;
		    } 
		    set{
		        this.OnUnitsOnOrderChanging(value);
                this.SendPropertyChanging();
                this._UnitsOnOrder = value;
                this.SendPropertyChanged("UnitsOnOrder");
                this.OnUnitsOnOrderChanged();
		    }
		}
		
        partial void OnReorderLevelChanging(short? value);
        partial void OnReorderLevelChanged();
		
		private short? _ReorderLevel;
		public short? ReorderLevel { 
		    get{
		        return _ReorderLevel;
		    } 
		    set{
		        this.OnReorderLevelChanging(value);
                this.SendPropertyChanging();
                this._ReorderLevel = value;
                this.SendPropertyChanged("ReorderLevel");
                this.OnReorderLevelChanged();
		    }
		}
		
        partial void OnDiscontinuedChanging(bool value);
        partial void OnDiscontinuedChanged();
		
		private bool _Discontinued;
		public bool Discontinued { 
		    get{
		        return _Discontinued;
		    } 
		    set{
		        this.OnDiscontinuedChanging(value);
                this.SendPropertyChanging();
                this._Discontinued = value;
                this.SendPropertyChanged("Discontinued");
                this.OnDiscontinuedChanged();
		    }
		}
		

        #endregion

        #region Foreign Keys
        public IQueryable<Category> Categories
        {
            get
            {
                  var db=new WestWind.NorthwindDB();
                  return from items in db.Categories
                       where items.CategoryID == _CategoryID
                       select items;
            }
        }

        public IQueryable<OrderDetail> OrderDetails
        {
            get
            {
                  var db=new WestWind.NorthwindDB();
                  return from items in db.OrderDetails
                       where items.ProductID == _ProductID
                       select items;
            }
        }

        public IQueryable<Supplier> Suppliers
        {
            get
            {
                  var db=new WestWind.NorthwindDB();
                  return from items in db.Suppliers
                       where items.SupplierID == _SupplierID
                       select items;
            }
        }

        #endregion


        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging()
        {
            var handler = PropertyChanging;
            if (handler != null)
               handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

	}
	
    
    
    /// <summary>
    /// A class which represents the Order Details table in the Northwind Database.
    /// This class is queryable through NorthwindDB.OrderDetail 
    /// </summary>

	public partial class OrderDetail: INotifyPropertyChanging, INotifyPropertyChanged
	{
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
	    
	    public OrderDetail(){
	        OnCreated();
	    }
	    
	    #region Properties
	    
        partial void OnOrderIDChanging(int value);
        partial void OnOrderIDChanged();
		
		private int _OrderID;
		public int OrderID { 
		    get{
		        return _OrderID;
		    } 
		    set{
		        this.OnOrderIDChanging(value);
                this.SendPropertyChanging();
                this._OrderID = value;
                this.SendPropertyChanged("OrderID");
                this.OnOrderIDChanged();
		    }
		}
		
        partial void OnProductIDChanging(int value);
        partial void OnProductIDChanged();
		
		private int _ProductID;
		public int ProductID { 
		    get{
		        return _ProductID;
		    } 
		    set{
		        this.OnProductIDChanging(value);
                this.SendPropertyChanging();
                this._ProductID = value;
                this.SendPropertyChanged("ProductID");
                this.OnProductIDChanged();
		    }
		}
		
        partial void OnUnitPriceChanging(decimal value);
        partial void OnUnitPriceChanged();
		
		private decimal _UnitPrice;
		public decimal UnitPrice { 
		    get{
		        return _UnitPrice;
		    } 
		    set{
		        this.OnUnitPriceChanging(value);
                this.SendPropertyChanging();
                this._UnitPrice = value;
                this.SendPropertyChanged("UnitPrice");
                this.OnUnitPriceChanged();
		    }
		}
		
        partial void OnQuantityChanging(short value);
        partial void OnQuantityChanged();
		
		private short _Quantity;
		public short Quantity { 
		    get{
		        return _Quantity;
		    } 
		    set{
		        this.OnQuantityChanging(value);
                this.SendPropertyChanging();
                this._Quantity = value;
                this.SendPropertyChanged("Quantity");
                this.OnQuantityChanged();
		    }
		}
		
        partial void OnDiscountChanging(decimal value);
        partial void OnDiscountChanged();
		
		private decimal _Discount;
		public decimal Discount { 
		    get{
		        return _Discount;
		    } 
		    set{
		        this.OnDiscountChanging(value);
                this.SendPropertyChanging();
                this._Discount = value;
                this.SendPropertyChanged("Discount");
                this.OnDiscountChanged();
		    }
		}
		

        #endregion

        #region Foreign Keys
        public IQueryable<Order> Orders
        {
            get
            {
                  var db=new WestWind.NorthwindDB();
                  return from items in db.Orders
                       where items.OrderID == _OrderID
                       select items;
            }
        }

        public IQueryable<Product> Products
        {
            get
            {
                  var db=new WestWind.NorthwindDB();
                  return from items in db.Products
                       where items.ProductID == _ProductID
                       select items;
            }
        }

        #endregion


        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging()
        {
            var handler = PropertyChanging;
            if (handler != null)
               handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

	}
	
    
    
    /// <summary>
    /// A class which represents the CustomerCustomerDemo table in the Northwind Database.
    /// This class is queryable through NorthwindDB.CustomerCustomerDemo 
    /// </summary>

	public partial class CustomerCustomerDemo: INotifyPropertyChanging, INotifyPropertyChanged
	{
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
	    
	    public CustomerCustomerDemo(){
	        OnCreated();
	    }
	    
	    #region Properties
	    
        partial void OnCustomerIDChanging(string value);
        partial void OnCustomerIDChanged();
		
		private string _CustomerID;
		public string CustomerID { 
		    get{
		        return _CustomerID;
		    } 
		    set{
		        this.OnCustomerIDChanging(value);
                this.SendPropertyChanging();
                this._CustomerID = value;
                this.SendPropertyChanged("CustomerID");
                this.OnCustomerIDChanged();
		    }
		}
		
        partial void OnCustomerTypeIDChanging(string value);
        partial void OnCustomerTypeIDChanged();
		
		private string _CustomerTypeID;
		public string CustomerTypeID { 
		    get{
		        return _CustomerTypeID;
		    } 
		    set{
		        this.OnCustomerTypeIDChanging(value);
                this.SendPropertyChanging();
                this._CustomerTypeID = value;
                this.SendPropertyChanged("CustomerTypeID");
                this.OnCustomerTypeIDChanged();
		    }
		}
		

        #endregion

        #region Foreign Keys
        public IQueryable<CustomerDemographic> CustomerDemographics
        {
            get
            {
                  var db=new WestWind.NorthwindDB();
                  return from items in db.CustomerDemographics
                       where items.CustomerTypeID == _CustomerTypeID
                       select items;
            }
        }

        public IQueryable<Customer> Customers
        {
            get
            {
                  var db=new WestWind.NorthwindDB();
                  return from items in db.Customers
                       where items.CustomerID == _CustomerID
                       select items;
            }
        }

        #endregion


        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging()
        {
            var handler = PropertyChanging;
            if (handler != null)
               handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

	}
	
    
    
    /// <summary>
    /// A class which represents the CustomerDemographics table in the Northwind Database.
    /// This class is queryable through NorthwindDB.CustomerDemographic 
    /// </summary>

	public partial class CustomerDemographic: INotifyPropertyChanging, INotifyPropertyChanged
	{
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
	    
	    public CustomerDemographic(){
	        OnCreated();
	    }
	    
	    #region Properties
	    
        partial void OnCustomerTypeIDChanging(string value);
        partial void OnCustomerTypeIDChanged();
		
		private string _CustomerTypeID;
		public string CustomerTypeID { 
		    get{
		        return _CustomerTypeID;
		    } 
		    set{
		        this.OnCustomerTypeIDChanging(value);
                this.SendPropertyChanging();
                this._CustomerTypeID = value;
                this.SendPropertyChanged("CustomerTypeID");
                this.OnCustomerTypeIDChanged();
		    }
		}
		
        partial void OnCustomerDescChanging(string value);
        partial void OnCustomerDescChanged();
		
		private string _CustomerDesc;
		public string CustomerDesc { 
		    get{
		        return _CustomerDesc;
		    } 
		    set{
		        this.OnCustomerDescChanging(value);
                this.SendPropertyChanging();
                this._CustomerDesc = value;
                this.SendPropertyChanged("CustomerDesc");
                this.OnCustomerDescChanged();
		    }
		}
		

        #endregion

        #region Foreign Keys
        public IQueryable<CustomerCustomerDemo> CustomerCustomerDemos
        {
            get
            {
                  var db=new WestWind.NorthwindDB();
                  return from items in db.CustomerCustomerDemos
                       where items.CustomerTypeID == _CustomerTypeID
                       select items;
            }
        }

        #endregion


        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging()
        {
            var handler = PropertyChanging;
            if (handler != null)
               handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

	}
	
    
    
    /// <summary>
    /// A class which represents the Region table in the Northwind Database.
    /// This class is queryable through NorthwindDB.Region 
    /// </summary>

	public partial class Region: INotifyPropertyChanging, INotifyPropertyChanged
	{
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
	    
	    public Region(){
	        OnCreated();
	    }
	    
	    #region Properties
	    
        partial void OnRegionIDChanging(int value);
        partial void OnRegionIDChanged();
		
		private int _RegionID;
		public int RegionID { 
		    get{
		        return _RegionID;
		    } 
		    set{
		        this.OnRegionIDChanging(value);
                this.SendPropertyChanging();
                this._RegionID = value;
                this.SendPropertyChanged("RegionID");
                this.OnRegionIDChanged();
		    }
		}
		
        partial void OnRegionDescriptionChanging(string value);
        partial void OnRegionDescriptionChanged();
		
		private string _RegionDescription;
		public string RegionDescription { 
		    get{
		        return _RegionDescription;
		    } 
		    set{
		        this.OnRegionDescriptionChanging(value);
                this.SendPropertyChanging();
                this._RegionDescription = value;
                this.SendPropertyChanged("RegionDescription");
                this.OnRegionDescriptionChanged();
		    }
		}
		

        #endregion

        #region Foreign Keys
        public IQueryable<Territory> Territories
        {
            get
            {
                  var db=new WestWind.NorthwindDB();
                  return from items in db.Territories
                       where items.RegionID == _RegionID
                       select items;
            }
        }

        #endregion


        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging()
        {
            var handler = PropertyChanging;
            if (handler != null)
               handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

	}
	
    
    
    /// <summary>
    /// A class which represents the Territories table in the Northwind Database.
    /// This class is queryable through NorthwindDB.Territory 
    /// </summary>

	public partial class Territory: INotifyPropertyChanging, INotifyPropertyChanged
	{
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
	    
	    public Territory(){
	        OnCreated();
	    }
	    
	    #region Properties
	    
        partial void OnTerritoryIDChanging(string value);
        partial void OnTerritoryIDChanged();
		
		private string _TerritoryID;
		public string TerritoryID { 
		    get{
		        return _TerritoryID;
		    } 
		    set{
		        this.OnTerritoryIDChanging(value);
                this.SendPropertyChanging();
                this._TerritoryID = value;
                this.SendPropertyChanged("TerritoryID");
                this.OnTerritoryIDChanged();
		    }
		}
		
        partial void OnTerritoryDescriptionChanging(string value);
        partial void OnTerritoryDescriptionChanged();
		
		private string _TerritoryDescription;
		public string TerritoryDescription { 
		    get{
		        return _TerritoryDescription;
		    } 
		    set{
		        this.OnTerritoryDescriptionChanging(value);
                this.SendPropertyChanging();
                this._TerritoryDescription = value;
                this.SendPropertyChanged("TerritoryDescription");
                this.OnTerritoryDescriptionChanged();
		    }
		}
		
        partial void OnRegionIDChanging(int value);
        partial void OnRegionIDChanged();
		
		private int _RegionID;
		public int RegionID { 
		    get{
		        return _RegionID;
		    } 
		    set{
		        this.OnRegionIDChanging(value);
                this.SendPropertyChanging();
                this._RegionID = value;
                this.SendPropertyChanged("RegionID");
                this.OnRegionIDChanged();
		    }
		}
		

        #endregion

        #region Foreign Keys
        public IQueryable<Region> Regions
        {
            get
            {
                  var db=new WestWind.NorthwindDB();
                  return from items in db.Regions
                       where items.RegionID == _RegionID
                       select items;
            }
        }

        public IQueryable<EmployeeTerritory> EmployeeTerritories
        {
            get
            {
                  var db=new WestWind.NorthwindDB();
                  return from items in db.EmployeeTerritories
                       where items.TerritoryID == _TerritoryID
                       select items;
            }
        }

        #endregion


        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging()
        {
            var handler = PropertyChanging;
            if (handler != null)
               handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

	}
	
    
    
    /// <summary>
    /// A class which represents the EmployeeTerritories table in the Northwind Database.
    /// This class is queryable through NorthwindDB.EmployeeTerritory 
    /// </summary>

	public partial class EmployeeTerritory: INotifyPropertyChanging, INotifyPropertyChanged
	{
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
	    
	    public EmployeeTerritory(){
	        OnCreated();
	    }
	    
	    #region Properties
	    
        partial void OnEmployeeIDChanging(int value);
        partial void OnEmployeeIDChanged();
		
		private int _EmployeeID;
		public int EmployeeID { 
		    get{
		        return _EmployeeID;
		    } 
		    set{
		        this.OnEmployeeIDChanging(value);
                this.SendPropertyChanging();
                this._EmployeeID = value;
                this.SendPropertyChanged("EmployeeID");
                this.OnEmployeeIDChanged();
		    }
		}
		
        partial void OnTerritoryIDChanging(string value);
        partial void OnTerritoryIDChanged();
		
		private string _TerritoryID;
		public string TerritoryID { 
		    get{
		        return _TerritoryID;
		    } 
		    set{
		        this.OnTerritoryIDChanging(value);
                this.SendPropertyChanging();
                this._TerritoryID = value;
                this.SendPropertyChanged("TerritoryID");
                this.OnTerritoryIDChanged();
		    }
		}
		

        #endregion

        #region Foreign Keys
        public IQueryable<Employee> Employees
        {
            get
            {
                  var db=new WestWind.NorthwindDB();
                  return from items in db.Employees
                       where items.EmployeeID == _EmployeeID
                       select items;
            }
        }

        public IQueryable<Territory> Territories
        {
            get
            {
                  var db=new WestWind.NorthwindDB();
                  return from items in db.Territories
                       where items.TerritoryID == _TerritoryID
                       select items;
            }
        }

        #endregion


        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging()
        {
            var handler = PropertyChanging;
            if (handler != null)
               handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

	}
	
    
    
    /// <summary>
    /// A class which represents the sysdiagrams table in the Northwind Database.
    /// This class is queryable through NorthwindDB.sysdiagram 
    /// </summary>

	public partial class sysdiagram: INotifyPropertyChanging, INotifyPropertyChanged
	{
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
	    
	    public sysdiagram(){
	        OnCreated();
	    }
	    
	    #region Properties
	    
        partial void OnnameChanging(string value);
        partial void OnnameChanged();
		
		private string _name;
		public string name { 
		    get{
		        return _name;
		    } 
		    set{
		        this.OnnameChanging(value);
                this.SendPropertyChanging();
                this._name = value;
                this.SendPropertyChanged("name");
                this.OnnameChanged();
		    }
		}
		
        partial void Onprincipal_idChanging(int value);
        partial void Onprincipal_idChanged();
		
		private int _principal_id;
		public int principal_id { 
		    get{
		        return _principal_id;
		    } 
		    set{
		        this.Onprincipal_idChanging(value);
                this.SendPropertyChanging();
                this._principal_id = value;
                this.SendPropertyChanged("principal_id");
                this.Onprincipal_idChanged();
		    }
		}
		
        partial void Ondiagram_idChanging(int value);
        partial void Ondiagram_idChanged();
		
		private int _diagram_id;
		public int diagram_id { 
		    get{
		        return _diagram_id;
		    } 
		    set{
		        this.Ondiagram_idChanging(value);
                this.SendPropertyChanging();
                this._diagram_id = value;
                this.SendPropertyChanged("diagram_id");
                this.Ondiagram_idChanged();
		    }
		}
		
        partial void OnversionChanging(int? value);
        partial void OnversionChanged();
		
		private int? _version;
		public int? version { 
		    get{
		        return _version;
		    } 
		    set{
		        this.OnversionChanging(value);
                this.SendPropertyChanging();
                this._version = value;
                this.SendPropertyChanged("version");
                this.OnversionChanged();
		    }
		}
		
        partial void OndefinitionChanging(byte[] value);
        partial void OndefinitionChanged();
		
		private byte[] _definition;
		public byte[] definition { 
		    get{
		        return _definition;
		    } 
		    set{
		        this.OndefinitionChanging(value);
                this.SendPropertyChanging();
                this._definition = value;
                this.SendPropertyChanged("definition");
                this.OndefinitionChanged();
		    }
		}
		

        #endregion

        #region Foreign Keys
        #endregion


        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging()
        {
            var handler = PropertyChanging;
            if (handler != null)
               handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

	}
	
    
    
    /// <summary>
    /// A class which represents the Employees table in the Northwind Database.
    /// This class is queryable through NorthwindDB.Employee 
    /// </summary>

	public partial class Employee: INotifyPropertyChanging, INotifyPropertyChanged
	{
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
	    
	    public Employee(){
	        OnCreated();
	    }
	    
	    #region Properties
	    
        partial void OnEmployeeIDChanging(int value);
        partial void OnEmployeeIDChanged();
		
		private int _EmployeeID;
		public int EmployeeID { 
		    get{
		        return _EmployeeID;
		    } 
		    set{
		        this.OnEmployeeIDChanging(value);
                this.SendPropertyChanging();
                this._EmployeeID = value;
                this.SendPropertyChanged("EmployeeID");
                this.OnEmployeeIDChanged();
		    }
		}
		
        partial void OnLastNameChanging(string value);
        partial void OnLastNameChanged();
		
		private string _LastName;
		public string LastName { 
		    get{
		        return _LastName;
		    } 
		    set{
		        this.OnLastNameChanging(value);
                this.SendPropertyChanging();
                this._LastName = value;
                this.SendPropertyChanged("LastName");
                this.OnLastNameChanged();
		    }
		}
		
        partial void OnFirstNameChanging(string value);
        partial void OnFirstNameChanged();
		
		private string _FirstName;
		public string FirstName { 
		    get{
		        return _FirstName;
		    } 
		    set{
		        this.OnFirstNameChanging(value);
                this.SendPropertyChanging();
                this._FirstName = value;
                this.SendPropertyChanged("FirstName");
                this.OnFirstNameChanged();
		    }
		}
		
        partial void OnTitleChanging(string value);
        partial void OnTitleChanged();
		
		private string _Title;
		public string Title { 
		    get{
		        return _Title;
		    } 
		    set{
		        this.OnTitleChanging(value);
                this.SendPropertyChanging();
                this._Title = value;
                this.SendPropertyChanged("Title");
                this.OnTitleChanged();
		    }
		}
		
        partial void OnTitleOfCourtesyChanging(string value);
        partial void OnTitleOfCourtesyChanged();
		
		private string _TitleOfCourtesy;
		public string TitleOfCourtesy { 
		    get{
		        return _TitleOfCourtesy;
		    } 
		    set{
		        this.OnTitleOfCourtesyChanging(value);
                this.SendPropertyChanging();
                this._TitleOfCourtesy = value;
                this.SendPropertyChanged("TitleOfCourtesy");
                this.OnTitleOfCourtesyChanged();
		    }
		}
		
        partial void OnBirthDateChanging(DateTime? value);
        partial void OnBirthDateChanged();
		
		private DateTime? _BirthDate;
		public DateTime? BirthDate { 
		    get{
		        return _BirthDate;
		    } 
		    set{
		        this.OnBirthDateChanging(value);
                this.SendPropertyChanging();
                this._BirthDate = value;
                this.SendPropertyChanged("BirthDate");
                this.OnBirthDateChanged();
		    }
		}
		
        partial void OnHireDateChanging(DateTime? value);
        partial void OnHireDateChanged();
		
		private DateTime? _HireDate;
		public DateTime? HireDate { 
		    get{
		        return _HireDate;
		    } 
		    set{
		        this.OnHireDateChanging(value);
                this.SendPropertyChanging();
                this._HireDate = value;
                this.SendPropertyChanged("HireDate");
                this.OnHireDateChanged();
		    }
		}
		
        partial void OnAddressChanging(string value);
        partial void OnAddressChanged();
		
		private string _Address;
		public string Address { 
		    get{
		        return _Address;
		    } 
		    set{
		        this.OnAddressChanging(value);
                this.SendPropertyChanging();
                this._Address = value;
                this.SendPropertyChanged("Address");
                this.OnAddressChanged();
		    }
		}
		
        partial void OnCityChanging(string value);
        partial void OnCityChanged();
		
		private string _City;
		public string City { 
		    get{
		        return _City;
		    } 
		    set{
		        this.OnCityChanging(value);
                this.SendPropertyChanging();
                this._City = value;
                this.SendPropertyChanged("City");
                this.OnCityChanged();
		    }
		}
		
        partial void OnRegionChanging(string value);
        partial void OnRegionChanged();
		
		private string _Region;
		public string Region { 
		    get{
		        return _Region;
		    } 
		    set{
		        this.OnRegionChanging(value);
                this.SendPropertyChanging();
                this._Region = value;
                this.SendPropertyChanged("Region");
                this.OnRegionChanged();
		    }
		}
		
        partial void OnPostalCodeChanging(string value);
        partial void OnPostalCodeChanged();
		
		private string _PostalCode;
		public string PostalCode { 
		    get{
		        return _PostalCode;
		    } 
		    set{
		        this.OnPostalCodeChanging(value);
                this.SendPropertyChanging();
                this._PostalCode = value;
                this.SendPropertyChanged("PostalCode");
                this.OnPostalCodeChanged();
		    }
		}
		
        partial void OnCountryChanging(string value);
        partial void OnCountryChanged();
		
		private string _Country;
		public string Country { 
		    get{
		        return _Country;
		    } 
		    set{
		        this.OnCountryChanging(value);
                this.SendPropertyChanging();
                this._Country = value;
                this.SendPropertyChanged("Country");
                this.OnCountryChanged();
		    }
		}
		
        partial void OnHomePhoneChanging(string value);
        partial void OnHomePhoneChanged();
		
		private string _HomePhone;
		public string HomePhone { 
		    get{
		        return _HomePhone;
		    } 
		    set{
		        this.OnHomePhoneChanging(value);
                this.SendPropertyChanging();
                this._HomePhone = value;
                this.SendPropertyChanged("HomePhone");
                this.OnHomePhoneChanged();
		    }
		}
		
        partial void OnExtensionChanging(string value);
        partial void OnExtensionChanged();
		
		private string _Extension;
		public string Extension { 
		    get{
		        return _Extension;
		    } 
		    set{
		        this.OnExtensionChanging(value);
                this.SendPropertyChanging();
                this._Extension = value;
                this.SendPropertyChanged("Extension");
                this.OnExtensionChanged();
		    }
		}
		
        partial void OnPhotoChanging(byte[] value);
        partial void OnPhotoChanged();
		
		private byte[] _Photo;
		public byte[] Photo { 
		    get{
		        return _Photo;
		    } 
		    set{
		        this.OnPhotoChanging(value);
                this.SendPropertyChanging();
                this._Photo = value;
                this.SendPropertyChanged("Photo");
                this.OnPhotoChanged();
		    }
		}
		
        partial void OnNotesChanging(string value);
        partial void OnNotesChanged();
		
		private string _Notes;
		public string Notes { 
		    get{
		        return _Notes;
		    } 
		    set{
		        this.OnNotesChanging(value);
                this.SendPropertyChanging();
                this._Notes = value;
                this.SendPropertyChanged("Notes");
                this.OnNotesChanged();
		    }
		}
		
        partial void OnReportsToChanging(int? value);
        partial void OnReportsToChanged();
		
		private int? _ReportsTo;
		public int? ReportsTo { 
		    get{
		        return _ReportsTo;
		    } 
		    set{
		        this.OnReportsToChanging(value);
                this.SendPropertyChanging();
                this._ReportsTo = value;
                this.SendPropertyChanged("ReportsTo");
                this.OnReportsToChanged();
		    }
		}
		
        partial void OnPhotoPathChanging(string value);
        partial void OnPhotoPathChanged();
		
		private string _PhotoPath;
		public string PhotoPath { 
		    get{
		        return _PhotoPath;
		    } 
		    set{
		        this.OnPhotoPathChanging(value);
                this.SendPropertyChanging();
                this._PhotoPath = value;
                this.SendPropertyChanged("PhotoPath");
                this.OnPhotoPathChanged();
		    }
		}
		

        #endregion

        #region Foreign Keys
        public IQueryable<Employee> Employees
        {
            get
            {
                  var db=new WestWind.NorthwindDB();
                  return from items in db.Employees
                       where items.EmployeeID == _ReportsTo
                       select items;
            }
        }

        public IQueryable<EmployeeTerritory> EmployeeTerritories
        {
            get
            {
                  var db=new WestWind.NorthwindDB();
                  return from items in db.EmployeeTerritories
                       where items.EmployeeID == _EmployeeID
                       select items;
            }
        }

        public IQueryable<Order> Orders
        {
            get
            {
                  var db=new WestWind.NorthwindDB();
                  return from items in db.Orders
                       where items.EmployeeID == _EmployeeID
                       select items;
            }
        }

        #endregion


        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging()
        {
            var handler = PropertyChanging;
            if (handler != null)
               handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

	}
	
}