<!--
{*******************************************************************}
{                                                                   }
{   Stimulsoft Reports.VUE                                          }
{                                                                   }
{                                                                   }
{   Copyright (C) 2003-2026 Stimulsoft                              }
{   ALL RIGHTS RESERVED                                             }
{                                                                   }
{   The entire contents of this file is protected by U.S. and       }
{   International Copyright Laws. Unauthorized reproduction,        }
{   reverse-engineering, and distribution of all or any portion of  }
{   the code contained in this file is strictly prohibited and may  }
{   result in severe civil and criminal penalties and will be       }
{   prosecuted to the maximum extent possible under the law.        }
{                                                                   }
{   RESTRICTIONS                                                    }
{                                                                   }
{   THIS SOURCE CODE AND ALL RESULTING INTERMEDIATE FILES           }
{   ARE CONFIDENTIAL AND PROPRIETARY                                }
{   TRADE SECRETS OF Stimulsoft                                     }
{                                                                   }
{   CONSULT THE END USER LICENSE AGREEMENT FOR INFORMATION ON       }
{   ADDITIONAL RESTRICTIONS.                                        }
{                                                                   }
{*******************************************************************}
-->

<script setup lang="ts">
import { ref, onMounted, onBeforeUnmount } from 'vue';
import { StimulsoftViewer, type StimulsoftViewerHandle } from 'stimulsoft-viewer-vue';

const viewerRef = ref<StimulsoftViewerHandle | null>(null);
const zoom = ref(100);
const currentPage = ref(0);
let interval: any = null;

onMounted(() => {
    interval = setInterval(() => {
        if (viewerRef.value) {
            zoom.value = viewerRef.value.zoom;
            currentPage.value = viewerRef.value.currentPage;
        }
    }, 200);
});

onBeforeUnmount(() => clearInterval(interval));

function zoomTo50(): void {
    if (viewerRef.value) viewerRef.value.zoom = 50;
}

function exportToPdf(): void {
    viewerRef.value?.export('Pdf', { ImageResolution: 200 });
}
</script>

<template>
    <div>
        Zoom is {{ zoom }}<br />
        Current page {{ currentPage + 1 }}<br />
        <input type="button" value="Zoom to 50%" @click="zoomTo50" />
        <input type="button" value="Export to PDF" @click="exportToPdf" />

        <StimulsoftViewer
            ref="viewerRef"
            request-url="/Viewer/{action}"
            action="InitViewer"
            height="100vh"
        />
    </div>
</template>
