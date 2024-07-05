<template>
  <div id="page" class="flex flex-wrap overflow-scroll no-scrollbar justify-center items-center gap-4 w-full h-screen bg-background text-text">
    <oneBag v-if="!isBagSelected" :isFree="true" :caseNumber="1" @click="openBag"/>
    <addNewBag v-if="!isBagSelected" />
    <oppenedBagWindow v-if="isBagSelected" :selectedBag="selectedBagNumber" @closeWindow="isBagSelected=false" />
  </div>
</template>

<script setup>
import { onMounted, ref } from "vue";
import addNewBag from "../components/addNewBag.vue";
import oneBag from "../components/oneBag.vue";
import oppenedBagWindow from '../components/oppenedBagWindow.vue'

import * as fetchus from "../fetchusMaximus";
import pathconfig from "../pathconfig.json";

import protocolTemplate from "../protocolTamplate.json";

const isBagSelected = ref(false)
const selectedBagNumber =ref(0)
const bags = ref([]);

const openBag=(number)=>{
  isBagSelected.value=true
selectedBagNumber.value=number
}

const getBags = async () => {
  bags.value = await fetchus.postfetch(pathconfig.server + pathconfig.getbag);
  console.log("bags", bags.value);
}

onMounted(async () => {
  await getBags();
})
</script>
