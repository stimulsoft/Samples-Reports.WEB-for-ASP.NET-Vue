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
import { ref, computed } from 'vue';
import { StimulsoftViewer } from 'stimulsoft-viewer-vue';

const reports = ['MasterDetail.mrt', 'EditableReport.mrt'];
const reportName = ref(reports[0]);

const properties = computed(() => ({ reportName: reportName.value }));
</script>

<template>
    <div>
        <select v-model="reportName">
            <option v-for="item in reports" :key="item" :value="item">{{ item }}</option>
        </select>

        <StimulsoftViewer
            request-url="/Viewer/{action}"
            action="InitViewer"
            height="100vh"
            :properties="properties"
        />
    </div>
</template>
