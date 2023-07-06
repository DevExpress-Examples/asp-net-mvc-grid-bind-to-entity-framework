Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations

Namespace EF.Models

    Public Class Order

        <Key>
        Public Property OrderID As Integer

        Public Property CustomerID As String

        Public Property ShipName As String

        Public Property ShipAddress As String
    End Class

    Public Class NorthwindContext
        Inherits DbContext

        Public Sub New()
            MyBase.New("SQLCompact_Northwind_Connection")
        End Sub

        Public Property Orders As DbSet(Of Order)

        Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
            modelBuilder.Entity(Of Order)().Property(Function(p) p.OrderID).HasColumnName("Order ID")
            modelBuilder.Entity(Of Order)().Property(Function(p) p.CustomerID).HasColumnName("Customer ID")
            modelBuilder.Entity(Of Order)().Property(Function(p) p.ShipName).HasColumnName("Ship Name")
            modelBuilder.Entity(Of Order)().Property(Function(p) p.ShipAddress).HasColumnName("Ship Address")
        End Sub
    End Class
End Namespace
