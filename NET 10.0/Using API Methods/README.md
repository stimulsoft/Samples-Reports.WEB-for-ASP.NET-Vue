# Using API Methods

This example illustrates how to execute methods of the StimulsoftViewer component.
The StimulsoftViewer component exposes a template ref that allows you to manipulate the viewer.

### Step by step

#### App.vue

    import { ref } from 'vue';
    import { StimulsoftViewer, type StimulsoftViewerHandle } from 'stimulsoft-viewer-vue';

Define reference to StimulsoftViewer:

    const viewerRef = ref<StimulsoftViewerHandle | null>(null);

Use the ref to call API methods:

    viewerRef.value?.export('Pdf', { ImageResolution: 200 });

#### App.vue template
Add reference to component, add button that exports report to PDF format with ImageResolution set to 200:

    <input type="button" value="Export to PDF" @click="viewerRef?.export('Pdf', { ImageResolution: 200 })" />
    <StimulsoftViewer
      ref="viewerRef"
      request-url="http://localhost:60801/Viewer/{action}"
      action="InitViewer"
      height="100vh"
    />
