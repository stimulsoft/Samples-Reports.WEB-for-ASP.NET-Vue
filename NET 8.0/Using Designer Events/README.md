# Using Designer Events

This example illustrates how to use Vue Designer component.
When click Design button in Viewer, Viewer close & shows Designer:

### Step by step

#### App.vue
Import the viewer and designer components:

    import { StimulsoftViewer } from 'stimulsoft-viewer-vue';
    import { StimulsoftDesigner, type StimulsoftDesignerHandle } from 'stimulsoft-designer-vue';

Show viewer or designer at once.
When user click Design button `design` event occurs:

    <StimulsoftViewer
        v-if="showViewer"
        request-url="/Viewer/{action}"
        action="InitViewer"
        height="100vh"
        @design="showViewer = false"
    />

Define URL to designer controller, content inside the component is shown while designer loading:

    <StimulsoftDesigner
        v-else
        request-url="/api/designer"
        width="100%"
        height="100%"
    >
        Loading designer...
    </StimulsoftDesigner>

### DesignerController.cs

    namespace Using_Designer_Events.Controllers
    {
      [Produces("application/json")]
      [Route("api/designer")]
      public class DesignerController : Controller
      {
        [HttpGet]
        public IActionResult Get()
        {

Setting the required options on the server side:

          var requestParams = StiVueDesigner.GetRequestParams(this);
          if (requestParams.Action == StiAction.Undefined)
          {
            var options = new StiVueDesignerOptions();
            return StiVueDesigner.DesignerDataResult(requestParams, options);
          }
          return StiVueDesigner.ProcessRequestResult(this);
        }

        [HttpPost]
        public IActionResult Post()
        {
          var requestParams = StiVueDesigner.GetRequestParams(this);
          if (requestParams.ComponentType == StiComponentType.Designer)
          {
            switch (requestParams.Action)
            {
              case StiAction.GetReport:
                return GetReport();

              case StiAction.SaveReport:
                return SaveReport();
            }
          }
          return StiVueDesigner.ProcessRequestResult(this);
        }

Action on load report:

        public IActionResult GetReport()
        {
          var report = StiReport.CreateNewReport();
          var path = StiVueHelper.MapPath(this, "Reports/MasterDetail.mrt");
          report.Load(path);
          return StiVueDesigner.GetReportResult(this, report);
        }

Action on save report:

        public IActionResult SaveReport()
        {
          var report = StiVueDesigner.GetReportObject(this);
          var path = StiVueHelper.MapPath(this, "Reports/MasterDetail.mrt");
          report.Save(path);
          return StiVueDesigner.SaveReportResult(this);
        }
      }
    }

### ViewerController.cs

    public IActionResult InitViewer()
    {
      var requestParams = StiVueViewer.GetRequestParams(this);
      var options = new StiVueViewerOptions();

Enable Design button in viewer options:

      options.Toolbar.ShowDesignButton = true;
      options.Actions.ViewerEvent = "ViewerEvent";
      return StiVueViewer.ViewerDataResult(requestParams, options);
    }
