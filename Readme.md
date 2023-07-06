<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128551222/14.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3252)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# Grid View for ASP.NET Web Forms - How to bind grid to Entity Framework in regular and database server modes

This example demonstrates two approaches how to bind a grid to Entity Framework. The first approach is recommended for small data sources because it downloads the data to the grid. The second approach operates on the database side and is recommended for large amount of data.

## Grid mode

In grid mode, all data shaping operations are performed on the WebServer/Grid side. This mode is effective when it is necessary to maintain a small amount of data. You should explicitly evaluate data from the Entity Framework context used as the grid Model. In this example we use the the [ToList](https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.tolist) method to get data:

```cs
@Html.DevExpress().GridView(settings => {
    // ...
    settings.CallbackRouteValues = new { Controller = "EFGridMode", Action = "GridViewPartial" };
}).Bind(Model).GetHtml()
```

```cs
NorthwindContext db = new NorthwindContext();

public ActionResult GridViewPartial() {
    return PartialView(db.Orders.ToList());
}
```

## Database server mode

In database server mode, all data shaping operations are performed on the database server side. This mode is effective when it is necessary to maintain a large amount of data, for instance 100k records. The GridView loads records on demand and performs data-aware operations (sorting, filtering, grouping, etc.) on the data server. This approach significantly improves the GridView’s speed and responsiveness.



Call a [BindToEF](https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.GridViewExtension.BindToEF.overloads) method to bind the grid to the Entity Framework data content. This method uses database server mode to optimize the execution of all queries to the data context initiated by the GridView. 
```cs
@Html.DevExpress().GridView(settings => {
    // ...
    settings.CallbackRouteValues = new { Controller = "EFDatabaseServerMode", Action = "GridViewPartial" };
}).BindToEF(string.Empty, string.Empty, (s, e) => {
    e.KeyExpression = "OrderID";
    e.QueryableSource = Model;
}).GetHtml()
```

```cs
NorthwindContext db = new NorthwindContext();

public ActionResult GridViewPartial() {
    return PartialView(db.Orders);
}
```

This example operates the `Northwind SQL Compact` demo database data Model. Since table column names contain spaces, it is necessary to define the corresponding mappings at the `DBContext` level (see the [OnModelCreating](https://github.com/LanaDX/how-to-bind-the-gridview-with-the-entity-framework-in-a-regular-and-database-server-modes-e3252/blob/0fc02fe03420146b1d0138c8038cb7167b5521a3/CS/Models/Model.cs#L18-L23) method implementation). In most cases, this step is not required.


## Files to Review

* [EFGridMode/GridViewPartial.cshtml](./CS/Views/EFGridMode/GridViewPartial.cshtml) (VB: [EFGridMode/GridViewPartial.vbhtml](./VB/Views/EFGridMode/GridViewPartial.vbhtml))
* [EFDatabaseServerMode/GridViewPartial.cshtml](./CS/Views/EFDatabaseServerMode/GridViewPartial.cshtml) (VB: [EFDatabaseServerMode/GridViewPartial.vbhtml](./VB/Views/EFDatabaseServerMode/GridViewPartial.vbhtml))
* [EFGridModeController.cs](./CS/Controllers/EFGridModeController.cs) (VB: [EFGridModeController.vb](./VB/Controllers/EFGridModeController.vb))
* [EFDatabaseServerModeController.cs](./CS/Controllers/EFDatabaseServerModeController.cs) (VB: [EFDatabaseServerModeController.vb](./VB/Controllers/EFDatabaseServerModeController.vb))
* [Model.cs](./CS/Models/Model.cs) (VB: [Model.vb](./VB/Models/Model.vb))

## Documentation

* [Bind Grid View to Large Data (Database Server Mode)](https://docs.devexpress.com/AspNetMvc/14760/components/grid-view/binding-to-data/binding-to-large-data-database-server-mode)
* [KB Article: How to bind MVC GridView Extension with Entity Framework in a server mode](https://supportcenter.devexpress.com/ticket/details/ka18615/how-to-bind-mvc-gridview-extension-with-entity-framework-in-a-server-mode)
