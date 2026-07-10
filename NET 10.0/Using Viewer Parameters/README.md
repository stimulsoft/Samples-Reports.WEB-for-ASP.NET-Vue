# Using Viewer Parameters

This example illustrates how to pass necessary properties from Vue to server.

### Step by step

#### App.vue

Transfer parameter *reportName*:

    const reports = ['MasterDetail.mrt', 'EditableReport.mrt'];
    const reportName = ref(reports[0]);

Define properties:

    const properties = computed(() => ({ reportName: reportName.value }));

Pass properties to the viewer:

    <StimulsoftViewer
      request-url="http://localhost:60801/Viewer/{action}"
      action="InitViewer"
      height="100vh"
      :properties="properties"
    />

#### ViewerController.cs

Check request parameter with name *properties*:

    var reportName = "MasterDetail.mrt";
    var properties = httpContext.Request.Params["properties"]?.ToString();
    if (properties != null)
    {
        var data = Convert.FromBase64String(properties);
        var json = Encoding.UTF8.GetString(data);
        var jsonObject = JsonConvert.DeserializeObject(json) as JToken;
        reportName = jsonObject["reportName"]?.ToString() ?? reportName;
    }
