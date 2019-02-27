<!DOCTYPE html>
<html>
<head>
    <title>@ViewBag.Title</title>
    <link href="@Url.Content("~/Content/Site.css")" rel="stylesheet" type="text/css" />
    @Html.DevExpress().GetStyleSheets(
        New StyleSheet With { .ExtensionSuite = ExtensionSuite.All }
    )
    @Html.DevExpress().GetScripts(
        New Script With { .ExtensionSuite = ExtensionSuite.All }
    )
</head>
<body>
    @RenderBody()
</body>
</html>