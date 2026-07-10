using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Report;
using Stimulsoft.Report.Vue;

namespace Localization.Controllers
{
    [Controller]
    public class ViewerController : Controller
    {
        static ViewerController()
        {
            // How to Activate
            //Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnO...";
            //Stimulsoft.Base.StiLicense.LoadFromFile("stimulsoft.key");
            //Stimulsoft.Base.StiLicense.LoadFromStream(stream);
        }

        [HttpPost]
        public IActionResult InitViewer()
        {
            var requestParams = StiVueViewer.GetRequestParams(this);

            var options = new StiVueViewerOptions();
            options.Actions.GetReport = "GetReport";
            options.Actions.ViewerEvent = "ViewerEvent";
            options.Toolbar.ShowPinToolbarButton = false;
            options.Appearance.ScrollbarsMode = true;
            options.Localization = StiVueHelper.MapPath(this, "Localization/de.xml");

            return StiVueViewer.ViewerDataResult(requestParams, options);
        }

        [HttpPost]
        public IActionResult GetReport()
        {
            var report = StiReport.CreateNewReport();
            var path = StiVueHelper.MapPath(this, $"Reports/MasterDetail.mrt");
            report.Load(path);

            return StiVueViewer.GetReportResult(this, report);
        }

        [HttpPost]
        public IActionResult ViewerEvent()
        {
            return StiVueViewer.ViewerEventResult(this);
        }
    }
}
