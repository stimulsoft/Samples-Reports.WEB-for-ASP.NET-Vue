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
import { ref } from 'vue';
import { StimulsoftViewer } from 'stimulsoft-viewer-vue';
import { StimulsoftDesigner, type StimulsoftDesignerHandle } from 'stimulsoft-designer-vue';

const showViewer = ref(true);
const designerRef = ref<StimulsoftDesignerHandle | null>(null);

function onDesignerLoaded(): void {
    const el = designerRef.value?.containerElement;
    if (el) el.style.height = '100%';
}
</script>

<template>
    <StimulsoftViewer
        v-if="showViewer"
        request-url="/Viewer/{action}"
        action="InitViewer"
        height="100vh"
        @design="showViewer = false"
    />
    <div v-else style="height: 100vh;">
        <StimulsoftDesigner
            ref="designerRef"
            request-url="/api/designer"
            width="100%"
            height="100%"
            @designer-loaded="onDesignerLoaded"
        >
            Loading designer...
        </StimulsoftDesigner>
    </div>
</template>
