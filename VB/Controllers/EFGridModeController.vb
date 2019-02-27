Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports System.Web.Mvc
Imports EF.Models

Namespace EF.Controllers
	Public Class EFGridModeController
		Inherits Controller
		Private db As New NorthwindContext()

		Public Function Index() As ActionResult
			Return View()
		End Function

		Public Function GridViewPartial() As ActionResult
			Return PartialView(db.Orders.ToList())
		End Function
	End Class
End Namespace