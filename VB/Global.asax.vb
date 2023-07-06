Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Routing

Namespace EF

    ' Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    ' visit http://go.microsoft.com/?LinkId=9394801
    Public Class MvcApplication
        Inherits HttpApplication

        Public Shared Sub RegisterGlobalFilters(ByVal filters As GlobalFilterCollection)
            filters.Add(New HandleErrorAttribute())
        End Sub

        Public Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}")
            routes.IgnoreRoute("{resource}.ashx/{*pathInfo}")
            routes.MapRoute("Default", "{controller}/{action}/{id}", New With {.controller = "Home", .action = "Index", .id = UrlParameter.Optional}) ' Route name
        ' URL with parameters
        ' Parameter defaults
        End Sub

        Protected Sub Application_Start()
            Call AreaRegistration.RegisterAllAreas()
            RegisterGlobalFilters(GlobalFilters.Filters)
            RegisterRoutes(RouteTable.Routes)
            ModelBinders.Binders.DefaultBinder = New DevExpress.Web.Mvc.DevExpressEditorsBinder()
        End Sub
    End Class
End Namespace
