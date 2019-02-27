@Html.DevExpress().GridView( _
    Sub(settings)
            settings.Name = "grid"
            
            settings.CallbackRouteValues = New With {.Controller = "EFDatabaseServerMode", .Action = "GridViewPartial"}

            settings.KeyFieldName = "OrderID"

            settings.Columns.Add("OrderID")
            settings.Columns.Add("CustomerID")
            settings.Columns.Add("ShipName")
            settings.Columns.Add("ShipAddress")

            settings.Settings.ShowGroupPanel = True

    End Sub).BindToEF(String.Empty, String.Empty, _
                      Sub(s, e)
                              e.KeyExpression = "OrderID"
                              e.QueryableSource = Model
                      End Sub).GetHtml()