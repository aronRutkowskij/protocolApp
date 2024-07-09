<template>
  <div
    id="page"
    class="flex flex-col absolute w-full h-full animate-Smooth_Appear_Fast bg-background overflow-y-scroll no-scrollbar"
  >
  <div class="w-full flex justify-between items-center">
    <div
      id="backBtn"
      class="flex cursor-pointer justify-center items-center text-center m-4 w-12 h-12 min-w-[3rem] min-h-[3rem] bg-container shadow-md border border-neutral-600 rounded-lg"
      @click="$emit('closeWindow')"
    >
      <font-awesome-icon icon="fa-solid fa-arrow-left" />
    </div>
    <div
      id="deleteBtn"
      class="flex cursor-pointer justify-center items-center text-center m-4 w-12 h-12 min-w-[3rem] min-h-[3rem] bg-container shadow-md border border-neutral-600 rounded-lg hover:text-red-400 transition-all"
      @click="$emit('deleteBag')"
    >
      <font-awesome-icon icon="fa-solid fa-trash-can" />
    </div>
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
          <span v-if="true" class="w-[10rem] px-2 min-w-[10rem] text-right"
            >Ist vorhanden?</span
          >
        </div>
        <!-- put there the value of INCHECK and rows from BagList-->
        <oneInputRow
          v-for="item in props.bagData.get.tools"
          :key="item"
          :inputList="item"
          :inCheck="true"
        />
      </div>
    </div>
    <div id="checkContainer" class="flex flex-wrap justify-center gap-4 w-full">
      <div id="Empfanger" class="flex flex-col gap-4 p-4">
        <div class="flex w-full gap-4">
          <div>
            <span class="text-xs">Empfänger</span>
            <select
              id="techniker1"
              @change="technikerChanged"
              class="flex placeholder:text-text/40 outline-none indent-2 px-2 p-1 w-[28rem] rounded-md bg-sec cursor-text"
            >
              <option
                v-for="item in props.techniker"
                :key="item.name"
                :value="item.name"
              >
                {{ item.name }}
              </option>
            </select>
          </div>
          <div class="w-[12rem]">
            <CustomInput v-model="date1" :input-value="date1" inputTitle="Datum" type="date" />
          </div>
        </div>
        <signature @saveSig="saveSig1" />
      </div>
      <div id="Kontrolleur" class="flex flex-col gap-4 p-4">
        <div class="flex w-full gap-4">
          <div>
            <span class="text-xs">Kontrolleur</span>
            <select
              id="techniker2"
              @change="technikerChanged"
              class="flex placeholder:text-text/40 outline-none indent-2 px-2 p-1 w-[28rem] rounded-md bg-sec cursor-text"
            >
              <option
                v-for="item in props.techniker"
                :key="item.name"
                :value="item.name"
              >
                {{ item.name }}
              </option>
            </select>
          </div>
          <div class="w-[12rem]">
            <CustomInput v-model="date2" :input-value="date2" inputTitle="Datum" type="date" />
          </div>
        </div>
        <signature @saveSig="saveSig2" />
      </div>
    </div>
    <div id="actionButtons" class="flex justify-end p-4 w-full gap-2">
      <div
        v-if="showValuesMissing"
        class="px-4 rounded-lg flex justify-center items-center bg-red-500"
      >
        <span>Datum und Unterschriften überprüfen!</span>
      </div>
      <button
        @click="save"
        class="flex cursor-pointer text-emerald-400 justify-center items-center text-center w-16 h-12 bg-container shadow-md border border-neutral-600 rounded-lg"
      >
        Save
      </button>
      <button
        @click="$emit('closeWindow')"
        class="flex cursor-pointer text-red-400 justify-center items-center text-center w-16 h-12 bg-container shadow-md border border-neutral-600 rounded-lg"
      >
        Cancel
      </button>
    </div>
  </div>
</template>

<script setup>
import { ref } from "vue";
import oneInputRow from "./oneInputRow.vue";
import signature from "./signature.vue";
import CustomInput from "./CustomInput.vue";
import { data } from "autoprefixer";

const props = defineProps({
  selectedBag: Number,
  bagData: Object,
  techniker: Object,
});
const emits = defineEmits(["closeWindow", "saveAll", "deleteBag"]);

const techniker1 = ref("");
const techniker2 = ref("");

const signature1 = ref(null);
const signature2 = ref(null);

const date1 = ref("");
const date2 = ref("");

const showValuesMissing = ref(false);

function technikerChanged() {
  techniker1.value = document.getElementById("techniker1").value;
  techniker2.value = document.getElementById("techniker2").value;
  console.log("t1", techniker1.value);
  console.log("t2", techniker2.value);
}

const saveSig1 = (sig) => {
  signature1.value = sig;
};

const saveSig2 = (sig) => {
  signature2.value = sig;
};

const save = () => {
  console.log("dates", date1.value, date2.value);
  if (
    signature1.value === null ||
    signature2.value === null ||
    date1.value === "" ||
    date2.value === "" 
  ) {
    showValuesMissing.value = true;
  } else {
    showValuesMissing.value = false;

    // set the bags new values
    if(props.bagData.inCompany){
      props.bagData.get.date1 = date1.value;
      props.bagData.get.date2 = date2.value;

      props.bagData.get.techniker1 = techniker1.value;
      props.bagData.get.techniker2 = techniker2.value;
      
      props.bagData.get.techniker1_signature = signature1.value;
      props.bagData.get.techniker2_signature = signature2.value;

      
    }else{
      props.bagData.give_back.date1 = date1.value;
      props.bagData.give_back.date2 = date2.value;

      props.bagData.give_back.techniker1 = techniker1.value;
      props.bagData.give_back.techniker2 = techniker2.value;
      
      props.bagData.give_back.techniker1_signature = signature1.value;
      props.bagData.give_back.techniker2_signature = signature2.value;
    }

    props.bagData.inCompany = !props.bagData.inCompany;

    emits('saveAll');
  }
};
</script>
<style scoped>
select {
  border-right: 12px solid transparent;
}
</style>
