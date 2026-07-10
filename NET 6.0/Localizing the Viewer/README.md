# Localizing the Viewer

This example illustrates how to localize the viewer. To select localization, it is enough to set the path to the localization XML file as the value of the Localization option.

### Step by step

#### ViewerController.cs

    public IActionResult InitViewer()
    {
       var requestParams = StiVueViewer.GetRequestParams(this);
       var options = new StiVueViewerOptions();
       options.Actions.ViewerEvent = "ViewerEvent";

Set the path to the localization XML file as the value of the Localization option:

       options.Localization = StiVueHelper.MapPath(this, "Localization/de.xml");
       return StiVueViewer.ViewerDataResult(requestParams, options);
    }
