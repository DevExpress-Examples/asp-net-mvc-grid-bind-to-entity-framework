# How to bind the GridView with the Entity Framework in a regular and Database Server modes


<p>This example is an illustration of the <a href="https://www.devexpress.com/Support/Center/p/KA18615">KA18615: How to bind MVC GridView Extension with Entity Framework in a server mode</a> KB Article. Please refer to the article for an explanation.<br />
This example illustrates how to use the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebMvcGridViewExtension_BindToEFtopic"><u>GridViewExtension.BindToEF</u></a> method for binding the MVC GridView Extension with the EF data content in:</p><p>- The <a href="http://documentation.devexpress.com/#AspNet/CustomDocument14580"><u>Grid mode</u></a>. All data shaping operations are performed on the WebServer/Grid side (for a small volume of data). Note that a table from the EF context used as the grid's Model should be explicitly evaluated, for example, via the <strong>ToList</strong> method:</p>

```cs
NorthwindContext db = new NorthwindContext();
```

<p> </p>

```cs
public ActionResult GridViewPartial() {
    return PartialView(db.Orders.ToList());
}
```

<p> </p>

```cs
@Html.DevExpress().GridView(settings => {
    ...
    settings.CallbackRouteValues = new { Controller = "EFGridMode", Action = "GridViewPartial" };
}).Bind(Model).GetHtml()
```

<p> </p><p>- The <a href="http://documentation.devexpress.com/#AspNet/CustomDocument14760"><u>Database Server mode</u></a>. All data shaping operations are performed on the database server side. This mode is effective when it is necessary to maintain a large volume of data only, for example 100k records. Since this mode creates special LINQ queries, this mode may be not so effective when operating with small portion of data:</p>

```cs
NorthwindContext db = new NorthwindContext();
```

<p> </p>

```cs
public ActionResult GridViewPartial() {
    return PartialView(db.Orders);
}
```

<p> </p>

```cs
@Html.DevExpress().GridView(settings => {
    ...
    settings.CallbackRouteValues = new { Controller = "EFDatabaseServerMode", Action = "GridViewPartial" };
}).BindToEF(string.Empty, string.Empty, (s, e) => {
    e.KeyExpression = "OrderID";
    e.QueryableSource = Model;
}).GetHtml()
```

<p> </p><p>This example operates the <strong>Northwind SQL Compact demo database</strong>. The data Model is defined via the <strong>EF Code First</strong> approach. Since tables’ column names contain spaces, it is necessary to define the corresponding mappings at the <strong>DBContext</strong> level (via the <strong>OnModelCreating</strong> method). In most cases, this step is no longer required.</p>

<br/>


