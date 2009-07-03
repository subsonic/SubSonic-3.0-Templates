using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using WestWind;

namespace SubSonic.Templates.LinqTemplates.Tests {
    
    
    public class SelectTests {
        private readonly NorthwindDB _db;

        public SelectTests()
        {
            _db = new NorthwindDB();
        }
        


        [Fact]
        public void All_With_StartsWith() {
            var result =
                _db.Customers.All(c => c.ContactName.StartsWith("x"));

            Assert.False(result);
        }

        [Fact]
        public void All_With_SubQuery() {
            var result =
                _db.Customers.Where(
                    c => _db.Orders.Where(o => o.CustomerID == c.CustomerID).All(o => o.OrderDate > DateTime.Parse("5/1/2008")));

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void Any_Should_Not_Fail() {
            Assert.True(_db.Products.Any(x => x.ProductID == 1));
        }

        [Fact]
        public void Any_With_Collection() {
            string[] ids = new[] { "ALFKI", "DRACD" };
            var result = _db.Customers.Where(c => ids.Any(id => c.CustomerID == id));
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void Any_With_Collection_One_False() {
            string[] ids = new[] { "ALFKI", "DRACD" };
            var result = _db.Customers.Where(c => ids.Any(id => c.CustomerID == id));
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void Contains_Resolves_Literal() {
            var result =
                _db.Customers.Where(x => x.ContactName.Contains("ar"));

            Assert.Equal(24, result.Count());
        }

        [Fact]
        public void Contains_With_LocalCollection_2_True() {
            string[] ids = new[] { "ALFKI", "DRACD" };
            var result =
                _db.Customers.Where(c => ids.Contains(c.CustomerID));

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void Contains_With_LocalCollection_OneFalse() {
            string[] ids = new[] { "ABCDE", "DRACD" };
            var result =
                _db.Customers.Where(c => ids.Contains(c.CustomerID));

            Assert.Equal(1, result.Count());
        }

        [Fact]
        public void Contains_With_Subquery() {
            var result =
                _db.Customers.Where(c => _db.Orders.Select(o => o.CustomerID).Contains(c.CustomerID));

            Assert.Equal(89, result.Count());
        }

        [Fact]
        public void Count_Distinct() {
            var result = _db.Customers.Select(c => c.City).Distinct().Count();

            Assert.Equal(69, result);
        }

        [Fact]
        public void Count_Distinct_With_Arg() {
            var result = _db.Customers.Distinct().Count(x => x.CustomerID == "ALFKI");

            Assert.Equal(1, result);
        }

        [Fact]
        public void Count_No_Args() {
            var result = _db.Orders.Select(o => o.OrderID).Count();
            Assert.Equal(830, result);
        }

        [Fact]
        public void Count_With_SingleArg() {
            var result = _db.Orders.Count(x => x.OrderID > 0);
            Assert.Equal(830, result);
        }

        [Fact]
        public void Distinct_GroupBy() {
            var result = _db.Orders.Distinct().GroupBy(o => o.CustomerID);

            Assert.Equal("ALFKI", result.First().Key);
            Assert.Equal(89, result.Count());
        }

        [Fact]
        public void Distinct_Should_Not_Fail() {
            var result = _db.Customers.Distinct().Count();
            Assert.Equal(91, result);
        }

        [Fact]
        public void Distinct_Should_Return_11_For_Scalar_CustomerCity() {
            var result = _db.Customers.Select(x => x.City).Distinct().Count();
            Assert.Equal(69, result);
        }

        [Fact]
        public void Distinct_Should_Return_69_For_Scalar_CustomerCity_Ordered() {
            var result = _db.Customers.Select(x => x.City).Distinct().OrderBy(x => x).ToList();

            Assert.Equal("Aachen", result.First());
            Assert.Equal("Warszawa", result.Last());
        }

        [Fact]
        public void First_Product_Should_Have_ProductID_1() {
            Assert.True(_db.Products.First().ProductID == 1);
        }

        [Fact]
        public void GroupBy_Basic() {
            var result = _db.Customers.GroupBy(c => c.City).ToList();
            Assert.NotNull(result);
            Assert.Equal(69, result.Count);
        }

        [Fact]
        public void GroupBy_Distinct() {
            var result = _db.Orders.GroupBy(o => o.CustomerID).Distinct();

            Assert.Equal("ALFKI", result.First().Key);
            Assert.Equal(89, result.Count());
        }

        [Fact]
        public void GroupBy_SelectMany() {
            var result = _db.Customers.GroupBy(c => c.City).SelectMany(x => x).ToList();
            Assert.NotNull(result);
            Assert.Equal(91, result.Count);
        }

        [Fact]
        public void GroupBy_Sum() {
            var result = _db.Orders.GroupBy(o => o.CustomerID).Select(g =>
                                                                      new
                                                                      {
                                                                          Sum = g.Sum(o => o.OrderID),
                                                                          Min = g.Min(o => o.OrderID),
                                                                          Max = g.Max(o => o.OrderID),
                                                                          Avg = g.Average(o => o.OrderID)
                                                                      });

            Assert.Equal(64835, result.First().Sum);
            Assert.Equal(10643, result.First().Min);
            Assert.Equal(11011, result.First().Max);
            Assert.Equal(10805, Math.Round(result.First().Avg, 0));
        }

        [Fact]
        public void GroupBy_Sum_With_Element_Selector_Sum_Max() {
            var result =
                _db.Orders.GroupBy(o => o.CustomerID, o => o.OrderID).Select(g => new
                {
                    Sum = g.Sum(),
                    Max = g.Max()
                });

            Assert.Equal(89, result.Count());
            Assert.Equal(64835, result.First().Sum);
            Assert.Equal(11011, result.First().Max);
        }

        [Fact]
        public void GroupBy_Sum_With_Result_Selector() {
            var result = _db.Orders.GroupBy(o => o.CustomerID, (k, g) =>
                                                               new
                                                               {
                                                                   Sum = g.Sum(o => o.OrderID),
                                                                   Min = g.Min(o => o.OrderID),
                                                                   Max = g.Max(o => o.OrderID),
                                                                   Avg = g.Average(o => o.OrderID)
                                                               });

            Assert.Equal(64835, result.First().Sum);
            Assert.Equal(10643, result.First().Min);
            Assert.Equal(11011, result.First().Max);
            Assert.Equal(10805, Math.Round(result.First().Avg, 0));
        }

        [Fact]
        public void GroupBy_With_Anon_Element() {
            var result =
                _db.Orders.GroupBy(o => o.CustomerID, o => new
                {
                    o.OrderID
                }).Select(g => g.Sum(x => x.OrderID));

            Assert.Equal(89, result.Count());
            Assert.Equal(64835, result.First());
        }

        [Fact]
        public void GroupBy_With_Element_Selector() {
            // note: groups are retrieved through a separately execute subquery per row
            var result = _db.Orders.GroupBy(o => o.CustomerID, o => o.OrderID);

            Assert.Equal(89, result.Count());
            Assert.Equal("ALFKI", result.First().Key);
        }

        [Fact]
        public void GroupBy_With_Element_Selector_Sum() {
            var result = _db.Orders.GroupBy(o => o.CustomerID, o => o.OrderID).Select(g => g.Sum());

            Assert.Equal(64835, result.First());
        }

        [Fact]
        public void GroupBy_With_OrderBy() {
            var result =
                _db.Orders.OrderBy(o => o.OrderID).GroupBy(o => o.CustomerID).Select(g => g.Sum(o => o.OrderID)).ToList();

            Assert.Equal(89, result.Count());
            Assert.Equal(64835, result.First());
            Assert.Equal(75595, result.Last());
        }

        [Fact]
        public void Join_To_Categories() {
            var result = from c in _db.Categories
                         join p in _db.Products on c.CategoryID equals p.CategoryID
                         select p;

            Assert.Equal(77, result.Count());
        }

        [Fact]
        public void OrderBy_CustomerID() {
            var result = (from c in _db.Customers
                          orderby c.CustomerID
                          select c).ToList();

            Assert.Equal("ALFKI", result.First().CustomerID);
            Assert.Equal("WOLZA", result.Last().CustomerID);
        }

        [Fact]
        public void OrderBy_CustomerID_Descending() {
            var result = (from c in _db.Customers
                          orderby c.CustomerID descending
                          select c).ToList();

            Assert.Equal("WOLZA", result.First().CustomerID);
            Assert.Equal("ALFKI", result.Last().CustomerID);
        }

        [Fact]
        public void OrderBy_CustomerID_Descending_ThenBy_City() {
            var result = _db.Customers.OrderByDescending(x => x.CustomerID).ThenBy(x => x.City).Select(x => x.City).ToList();

            Assert.Equal("Warszawa", result.First());
            Assert.Equal("Berlin", result.Last());
        }

        [Fact]
        public void OrderBy_CustomerID_Descending_ThenByDescending_City() {
            var result = _db.Customers.OrderByDescending(x => x.CustomerID).ThenByDescending(x => x.City).Select(x => x.City).ToList();

            Assert.Equal("Warszawa", result.First());
            Assert.Equal("Berlin", result.Last());
        }

        [Fact]
        public void OrderBy_CustomerID_OrderBy_Company_City() {
            var result = _db.Customers.OrderBy(x => x.CompanyName).OrderBy(x => x.City).Select(x => x.City).ToList();

            Assert.Equal("Aachen", result.First());
            Assert.Equal("Warszawa", result.Last());
        }

        [Fact]
        public void OrderBy_CustomerID_ThenBy_City() {
            var result = _db.Customers.OrderBy(x => x.CustomerID).ThenBy(x => x.City).Select(x => x.City).ToList();

            Assert.Equal("Berlin", result.First());
            Assert.Equal("Warszawa", result.Last());
        }

        [Fact]
        public void OrderBy_CustomerID_With_Select() {
            var result = (from c in _db.Customers
                          orderby c.CustomerID
                          select c).Select(c => c.Address).ToList();

            Assert.Equal("Obere Str. 57", result.First());
            Assert.Equal("ul. Filtrowa 68", result.Last());
        }

        [Fact]
        public void OrderBy_Join() {
            var result = (from c in _db.Customers.OrderBy(c => c.CustomerID)
                          join o in _db.Orders.OrderBy(o => o.OrderID) on c.CustomerID equals o.CustomerID
                          select new
                          {
                              c.CustomerID,
                              o.OrderID
                          }).ToList();

            Assert.Equal(830, result.Count);

            Assert.Equal("ALFKI", result.First().CustomerID);
            Assert.Equal(10643, result.First().OrderID);

            Assert.Equal("WOLZA", result.Last().CustomerID);
            Assert.Equal(11044, result.Last().OrderID);
        }

        [Fact]
        public void OrderBy_SelectMany() {
            var result = (from c in _db.Customers.OrderBy(c => c.CustomerID)
                          from o in _db.Orders.OrderBy(o => o.OrderID)
                          where c.CustomerID == o.CustomerID
                          select new
                          {
                              c.CustomerID,
                              o.OrderID
                          }).ToList();

            Assert.Equal(830, result.Count);
            Assert.Equal("ALFKI", result.First().CustomerID);
            Assert.Equal(10643, result.First().OrderID);

            Assert.Equal("WOLZA", result.Last().CustomerID);
            Assert.Equal(11044, result.Last().OrderID);
        }

        [Fact]
        public void Paging_With_Skip_Take() {
            var result = _db.Products.Skip(10).Take(20).OrderBy(x => x.ProductID).ToList();
            Assert.Equal(20, result.Count);
            Assert.True(result.First().ProductID >= 10);
        }

        [Fact]
        public void Paging_With_Take() {
            var result = _db.Products.Take(20).ToList();
            Assert.Equal(20, result.Count);
        }

        [Fact]
        public void Select_0_When_Set_False() {
            var result = _db.Products.Where(x => false);

            Assert.NotNull(result);
            Assert.Equal(0, result.Count());
        }

        [Fact]
        public void Select_100_When_Set_True() {
            var result = _db.Products.Where(x => true);

            Assert.NotNull(result);
            Assert.Equal(77, result.Count());
        }

        [Fact]
        public void Select_Anon_Constant_Int() {
            var result = _db.Products.Select(x => 1);

            Assert.NotNull(result);
            Assert.Equal(77, result.Count());
        }

        [Fact]
        public void Select_Anon_Constant_NullString() {
            var result = _db.Products.Select(x => (string)null);

            Assert.NotNull(result);
            Assert.Equal(77, result.Count());
        }

        [Fact]
        public void Select_Anon_Empty() {
            var result = _db.Products.Select(x => new { });

            Assert.NotNull(result);
            Assert.Equal(77, result.Count());
        }

        [Fact]
        public void Select_Anon_Literal() {
            var result = _db.Products.Select(x => new
            {
                Thing = 1
            });

            Assert.NotNull(result);
            Assert.Equal(77, result.Count());
        }

        [Fact]
        public void Select_Anon_Nested() {
            var result = _db.Products.Select(x => new
            {
                x.ProductName,
                Price = new
                {
                    x.UnitPrice
                }
            });

            Assert.NotNull(result);
            Assert.Equal(77, result.Count());
        }

        [Fact]
        public void Select_Anon_One() {
            var result = _db.Products.Select(x => new
            {
                x.ProductName
            });

            Assert.NotNull(result);
            Assert.Equal(77, result.Count());
        }

        [Fact]
        public void Select_Anon_One_And_Object() {
            var result = _db.Products.Select(x => new
            {
                x.ProductName,
                x
            });

            Assert.NotNull(result);
            Assert.Equal(77, result.Count());
        }

        [Fact]
        public void Select_Anon_Three() {
            var result = _db.Products.Select(x => new
            {
                x.ProductName,
                x.UnitPrice,
                x.Discontinued
            });

            Assert.NotNull(result);
            Assert.Equal(77, result.Count());
        }

        [Fact]
        public void Select_Anon_Two() {
            var result = _db.Products.Select(x => new
            {
                x.ProductName,
                x.UnitPrice
            });

            Assert.NotNull(result);
            Assert.Equal(77, result.Count());
        }

        [Fact]
        public void Select_Anon_With_Local() {
            int thing = 10;
            var result = _db.Products.Select(x => thing);

            Assert.NotNull(result);
            Assert.Equal(77, result.Count());
        }

        [Fact]
        public void Select_Nested_Collection() {
            var result = from p in _db.Products
                         where p.ProductID == 1
                         select _db.OrderDetails.Where(x => x.ProductID == p.ProductID).Count();
            var count = result.First();

            Assert.NotNull(result);
            Assert.Equal(38, count);
        }

        [Fact]
        public void Select_Nested_Collection_With_AnonType() {
            var result = from p in _db.Products
                         where p.ProductID == 1
                         select new
                         {
                             Thing = _db.OrderDetails.Where(x => x.ProductID == p.ProductID)
                         };
            Assert.NotNull(result);
        }

        [Fact]
        public void Select_On_Self() {
            var result = _db.Products.Select(x => x);

            Assert.NotNull(result);
            Assert.Equal(77, result.Count());
        }

        [Fact]
        public void Select_Scalar() {
            var result = _db.Products.Select(x => x.ProductName);

            Assert.NotNull(result);
            Assert.Equal(77, result.Count());
        }

        [Fact]
        public void Select_Single_Product_With_ID_1() {
            var result = (from p in _db.Products
                          where p.ProductID == 1
                          select p).SingleOrDefault();

            Assert.NotNull(result);
            Assert.Equal(1, result.ProductID);
        }

        [Fact]
        public void SelectMany_Customer_Orders() {
            var result = from c in _db.Customers
                         from o in _db.Orders
                         where c.CustomerID == o.CustomerID
                         select new
                         {
                             c.ContactName,
                             o.OrderID
                         };

            Assert.Equal(830, result.Count());
        }

        [Fact]
        public void Single_Product_Should_Have_ProductID_1() {
            Assert.True(_db.Products.Single(x => x.ProductID == 1).ProductID == 1);
        }

        [Fact]
        public void Sum_No_Args() {
            var result = _db.Orders.Select(o => o.OrderID).Sum();
            Assert.Equal(8849875, result);
        }

        [Fact]
        public void Sum_With_SingleArg() {
            var result = _db.Orders.Sum(x => x.OrderID);
            Assert.Equal(8849875, result);
        }

        [Fact]
        public void Where_Resolves_String_EndsWith_Literal() {
            var result =
                _db.Customers.Where(c => c.City.EndsWith("en"));

            Assert.Equal(3, result.Count());
        }

        [Fact]
        public void Where_Resolves_String_EndsWith_OtherColumn() {
            var result =
                _db.Customers.Where(c => c.ContactName.EndsWith(c.ContactName));

            Assert.Equal(91, result.Count());
        }

        [Fact]
        public void Where_Resolves_String_IsNullOrEmpty() {
            var result =
                _db.Customers.Where(c => string.IsNullOrEmpty(c.City));
            Assert.Equal(0, result.Count());
        }

        [Fact]
        public void Where_Resolves_String_Length() {
            var result =
                _db.Customers.Where(c => c.City.Length == 7);

            Assert.Equal(9, result.Count());
        }

        [Fact]
        public void Where_Resolves_String_StartsWith_Literal() {
            var result =
                _db.Customers.Where(c => c.ContactName.StartsWith("C"));

            Assert.Equal(5, result.Count());
        }

        [Fact]
        public void Where_Resolves_String_StartsWith_OtherColumn() {
            var result =
                _db.Customers.Where(c => c.ContactName.StartsWith(c.ContactName));

            Assert.Equal(91, result.Count());
        }


    }
}
