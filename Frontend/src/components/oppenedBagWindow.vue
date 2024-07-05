<template>
  <div
    id="page"
    class="flex flex-col absolute w-full h-full animate-Smooth_Appear_Fast bg-background overflow-y-scroll no-scrollbar"
  >
    <div
      id="backBtn"
      class="flex cursor-pointer justify-center items-center text-center m-4 w-12 h-12 min-w-[3rem] min-h-[3rem] bg-container shadow-md border border-neutral-600 rounded-lg"
      @click="$emit('closeWindow')"
    >
      <font-awesome-icon icon="fa-solid fa-arrow-left" />
    </div>
    <div id="listContainer" class="flex w-full h-[30rem] p-4 pt-0">
      <div
        id="container"
        class="flex flex-col items-start w-full min-w-max gap-4 h-auto rounded-lg p-4 pt-0 border-4 border-container overflow-y-scroll no-scrollbar"
      >
        <div
          id="titles"
          class="flex w-full gap-4 text-xs sticky top-0 bg-background p-3 z-10"
        >
          <span class="w-[21rem] px-2 min-w-[10rem]">Menge</span>
          <span class="w-full px-2 min-w-[10rem]">Werkzeug</span>
          <span class="w-full px-2 min-w-[10rem]">Marke/Modell</span>
          <!-- put there the value of INCHECK -->
          <span v-if="true" class="w-[10rem] px-2 min-w-[10rem] text-right">Ist vorhanden?</span>

        </div>
          <!-- put there the value of INCHECK and rows from BagList-->
        <oneInputRow v-for="item in 1" :key="item" :inCheck="true"/>
      </div>
    </div>
    <div id="checkContainer" class="flex flex-wrap justify-center  gap-4 w-full">
      <div id="Empfanger" class="flex flex-col gap-4 p-4">
        <div class="flex w-full gap-4">
          <div>
            <span class="text-xs">Empfänger</span>
            <select
              id="names"
              class="flex placeholder:text-text/40 outline-none indent-2 px-2 p-1 w-[28rem] rounded-md bg-sec cursor-text"
            >
              <option v-for="item in 12" :key="item">Volvo</option>
            </select>
          </div>
          <div class="w-[12rem]">
            <CustomInput inputTitle="Datum" type="date" />
          </div>
        </div>
        <signature />
      </div>
      <div id="Kontrolleur" class="flex flex-col gap-4 p-4">
        <div class="flex w-full gap-4">
          <div>
            <span class="text-xs">Kontrolleur</span>
            <select
              id="names"
              class="flex placeholder:text-text/40 outline-none indent-2 px-2 p-1 w-[28rem] rounded-md bg-sec cursor-text"
            >
              <option v-for="item in 12" :key="item">Volvo</option>
            </select>
          </div>
          <div class="w-[12rem]">
            <CustomInput inputTitle="Datum" type="date" />
          </div>
        </div>
        <signature />
      </div>
    </div>
  </div>
</template>

<script setup>
import oneInputRow from "./oneInputRow.vue";
import signature from "./signature.vue";
import CustomInput from "./CustomInput.vue";

const props = defineProps({ selectedBag: Number });
const emits = defineEmits(["closeWindow"]);

</script>
<style scoped>
select {
  border-right: 12px solid transparent;
}
</style>
