'' 
''   SubSonic - http://subsonicproject.com
'' 
''   The contents of this file are subject to the New BSD
''   License (the "License"); you may not use this file
''   except in compliance with the License. You may obtain a copy of
''   the License at http://www.opensource.org/licenses/bsd-license.php
''  
''   Software distributed under the License is distributed on an 
''   "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, either express or
''   implied. See the License for the specific language governing
''   rights and limitations under the License.
'' 
Imports System.Linq
Imports Southwind
Imports Xunit

Namespace SubSonic.Tests.ActiveRecord

  Public Class FetchTests
    <Fact()> _
    Public Sub ActiveRecord_Should_Load_Single_Product1_Through_Factory()
      Dim productItem = Product.SingleOrDefault(Function(x) x.ProductID = 1)
      Assert.Equal(1, productItem.ProductID)
    End Sub

    <Fact()> _
      Public Sub ActiveRecord_Should_Return_10_Products_LessOrEqual_To_10()
      Dim products = Product.Find(Function(x) x.ProductID <= 10)
      Assert.Equal(10, products.Count)
    End Sub

    <Fact()> _
      Public Sub ActiveRecord_Should_Return_10_Products_Paged()
      Dim products = Product.GetPaged(1, 10)
      Assert.Equal(10, products.Count)
      Assert.Equal(77, products.TotalCount)
    End Sub

    <Fact()> _
        Public Sub ActiveRecord_Should_Return_20_Products_Using_SkipTake()

      Dim products = From p In Product.All() _
                           Join od In OrderDetail.All() On p.ProductID Equals od.ProductID _
                           Select p

      Assert.Equal(2155, products.Count())
    End Sub

  End Class

End Namespace
