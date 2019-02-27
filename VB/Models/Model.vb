Imports Microsoft.VisualBasic
Imports System
Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations

Namespace EF.Models
	Public Class Order
        Private privateOrderID As Integer
        <Key()> _
        Public Property OrderID() As Integer
            Get
                Return privateOrderID
            End Get
            Set(ByVal value As Integer)
                privateOrderID = value
            End Set
        End Property
        Private privateCustomerID As String
        Public Property CustomerID() As String
            Get
                Return privateCustomerID
            End Get
            Set(ByVal value As String)
                privateCustomerID = value
            End Set
        End Property
        Private privateShipName As String
        Public Property ShipName() As String
            Get
                Return privateShipName
            End Get
            Set(ByVal value As String)
                privateShipName = value
            End Set
        End Property
        Private privateShipAddress As String
        Public Property ShipAddress() As String
            Get
                Return privateShipAddress
            End Get
            Set(ByVal value As String)
                privateShipAddress = value
            End Set
        End Property
    End Class

    Public Class NorthwindContext
        Inherits DbContext
        Public Sub New()
            MyBase.New("SQLCompact_Northwind_Connection")
        End Sub
        Private privateOrders As DbSet(Of Order)
        Public Property Orders() As DbSet(Of Order)
            Get
                Return privateOrders
            End Get
            Set(ByVal value As DbSet(Of Order))
                privateOrders = value
            End Set
        End Property

        Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
            modelBuilder.Entity(Of Order)().Property(Function(p) p.OrderID).HasColumnName("Order ID")
            modelBuilder.Entity(Of Order)().Property(Function(p) p.CustomerID).HasColumnName("Customer ID")
            modelBuilder.Entity(Of Order)().Property(Function(p) p.ShipName).HasColumnName("Ship Name")
            modelBuilder.Entity(Of Order)().Property(Function(p) p.ShipAddress).HasColumnName("Ship Address")
        End Sub
    End Class
End Namespace