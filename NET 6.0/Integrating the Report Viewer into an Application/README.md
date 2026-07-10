# Integrating the Report Viewer into an Application

This example illustrates loading of the report with Vue Viewer.

### Step by step

#### App.vue

Import and add *StimulsoftViewer* component:

    import { StimulsoftViewer } from 'stimulsoft-viewer-vue';

Define URL template to server controller:

    request-url="http://localhost:60801/Viewer/{action}"

Define controller action that handle viewer initial request:

    action="InitViewer"

Define viewer height:

    height="100vh"

#### ViewerController.cs

Define action that handle viewer initial request:

    public IActionResult InitViewer()
    {
        var requestParams = StiVueViewer.GetRequestParams(this);
Define Vue viewer options:

        var options = new StiVueViewerOptions();

Define ViewerEvent that will handle viewer request:

        options.Actions.ViewerEvent = "ViewerEvent";

Get the initial data for Vue Viewer:

        return StiVueViewer.ViewerDataResult(requestParams, options);
    }

Define action that handle viewer requests:

    public IActionResult ViewerEvent()
    {
        return StiVueViewer.ViewerEventResult(this);
    }
