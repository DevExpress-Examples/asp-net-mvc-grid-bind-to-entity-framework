@Html.DevExpress().GridView( _
    Sub(settings)
            settings.Name = "grid"
    
            settings.CallbackRouteValues = New With {.Controller = "EFGridMode", .Action = "GridViewPartial"}
    
            settings.KeyFieldName = "OrderID"
    
            settings.Columns.Add("OrderID")
            settings.Columns.Add("CustomerID")
            settings.Columns.Add("ShipName")
            settings.Columns.Add("ShipAddress")

            settings.Settings.ShowGroupPanel = True
    
    End Sub).Bind(Model).GetHtml()