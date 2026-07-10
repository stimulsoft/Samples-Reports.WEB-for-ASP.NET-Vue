# Using Viewer Events

This example illustrates how to use Stimulsoft Vue Viewer events.

### Step by step

#### App.vue

    import { StimulsoftViewer } from 'stimulsoft-viewer-vue';

Define event handlers:

    function loaded(): void {
        console.log('Report loaded');
    }

    function onExport(event: any): void {
        console.log(`Export to: ${event.format}`);
    }

Bind event handlers in the template:

    <StimulsoftViewer
      request-url="http://localhost:60801/Viewer/{action}"
      action="InitViewer"
      height="100vh"
      @loaded="loaded"
      @export="onExport"
    />
