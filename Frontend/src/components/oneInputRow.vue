<template>
  <div id="container" class="flex gap-4 h-max w-full">
    <div class="w-[20rem] min-w-[10rem]">
      <CustomInput type="number" v-model="inputList.menge" :inputValue="inputList.menge" />
    </div>
    <div class="w-full min-w-[10rem]">
      <CustomInput type="text" v-model="inputList.name" :inputValue="inputList.name"/>
    </div>
    <div class="w-full min-w-[10rem]">
      <CustomInput type="text " v-model="inputList.modell" :inputValue="inputList.modell"/>
    </div>
    <div v-if="inCheck" class="flex justify-start w-[10rem] min-w-[10rem] mr-10">
      <CustomInput type="checkbox" v-model="inputList.isThere" :inputValue="inputList.isThere"/>
    </div>
  </div>
</template>

<script setup>
import { ref } from "vue";
import CustomInput from "./CustomInput.vue";
const props = defineProps({inCheck:Boolean,inputList:Object})
</script>
