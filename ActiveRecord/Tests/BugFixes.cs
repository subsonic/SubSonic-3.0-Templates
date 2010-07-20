using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using SouthWind;

namespace SubSonic.Templates.ActiveRecord.Tests {
    public class BugFixes {


        /// <summary>
        /// Issue 22 from NathanB http://github.com/subsonic/SubSonic-3.0/issues#issue/22
        /// </summary>
				//[Fact]
				//public void Insertion_Of_NewRecord_With_StringPK_ShouldNot_Overwrite_KeyValue() {
				//  // TODO: This test should fail until the issue is fixed
				//  // It causes too many knock on test failures right now though
				//    var customer = new Customer();
				//    customer.CustomerID = "ROBCO";
				//    customer.Address = "";
				//    customer.City = "";
				//    customer.CompanyName = "";
				//    customer.ContactName = "";
				//    customer.ContactTitle = "";
				//    customer.Country = "";
				//    customer.Phone = "";
				//    customer.PostalCode = "";
				//    customer.Region = "";
				//    customer.Save();


				//    Assert.NotNull(customer.CustomerID);
				//    Assert.Equal("ROBCO", customer.CustomerID);

				//    Customer.Delete(x => x.CustomerID == "ROBCO");
				//}

    }
}
