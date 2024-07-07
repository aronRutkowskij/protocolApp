<template>
  <div
    id="page"
    class="flex flex-wrap overflow-scroll no-scrollbar justify-center items-center gap-4 w-full h-screen bg-background text-text"
  >
    <oneBag
      v-for="(item, index, count) in bags"
      :isFree="true"
      :caseNumber="item.name"
      @click="openBag(count)"
    />
    <addNewBag v-if="!isBagSelected" />
    <oppenedBagWindow
      v-if="isBagSelected"
      :selectedBag="selectedBagNumber"
      :bagData="selectedBagData"
      @closeWindow="isBagSelected = false"
    />
  </div>
</template>

<script setup>
import { onMounted, ref } from "vue";
import addNewBag from "../components/addNewBag.vue";
import oneBag from "../components/oneBag.vue";
import oppenedBagWindow from "../components/oppenedBagWindow.vue";

import * as fetchus from "../fetchusMaximus";
import pathconfig from "../pathconfig.json";

import protocolTemplate from "../protocolTamplate.json";

const isBagSelected = ref(false);
const selectedBagNumber = ref(0);
const bags = ref([]);
const selectedBagData = ref({});

const newbag = {
  bag5: {
    name: "5",
    type: "Werkzeugtasche",
    modell: "Parkside",
    get: {
      date1: "01.01.2024",
      date2: "01.01.2024",
      techniker1: "some name",
      techniker1_signature: "",
      techniker2: "other name",
      techniker2_signature: "",
      tools: [
        {
          name: "Bitkasten-Set",
          modell: "Parkside",
          menge: 1,
          isThere: true,
        },
        {
          name: "Kleine Wasserwaage",
          modell: "Parkside",
          menge: 1,
          isThere: true,
        },
        {
          name: "10er Bit-Set",
          modell: "Parkside",
          menge: 1,
          isThere: true,
        },
        {
          name: "Teppichmesser",
          modell: "Parkside",
          menge: 1,
          isThere: true,
        },
        {
          name: "Messband",
          modell: "Brüder Mannesmann",
          menge: 1,
          isThere: true,
        },
        {
          name: "Bitschraubendreher",
          modell: "Parkside",
          menge: 1,
          isThere: true,
        },
        {
          name: "Rollgabelschlüssel",
          modell: "OWIM",
          menge: 1,
          isThere: true,
        },
        {
          name: "Spitzzange",
          modell: "Parkside",
          menge: 1,
          isThere: true,
        },
        {
          name: "Seitenschneider",
          modell: "Parkside",
          menge: 1,
          isThere: true,
        },
        {
          name: "Präzisionsschraubendreher",
          modell: "Parkside",
          menge: 5,
          isThere: true,
        },
      ],
    },
    give_back: {
      date1: "01.01.2024",
      date2: "01.01.2024",
      techniker1: "some name",
      techniker1_signature: "",
      techniker2: "other name",
      techniker2_signature: "",
      tools: [
        {
          name: "Bitkasten-Set",
          modell: "Parkside",
          menge: 1,
          isThere: true,
        },
        {
          name: "Kleine Wasserwaage",
          modell: "Parkside",
          menge: 1,
          isThere: true,
        },
        {
          name: "10er Bit-Set",
          modell: "Parkside",
          menge: 1,
          isThere: true,
        },
        {
          name: "Teppichmesser",
          modell: "Parkside",
          menge: 1,
          isThere: true,
        },
        {
          name: "Messband",
          modell: "Brüder Mannesmann",
          menge: 1,
          isThere: true,
        },
        {
          name: "Bitschraubendreher",
          modell: "Parkside",
          menge: 1,
          isThere: true,
        },
        {
          name: "Rollgabelschlüssel",
          modell: "OWIM",
          menge: 1,
          isThere: true,
        },
        {
          name: "Spitzzange",
          modell: "Parkside",
          menge: 1,
          isThere: true,
        },
        {
          name: "Seitenschneider",
          modell: "Parkside",
          menge: 1,
          isThere: true,
        },
        {
          name: "Präzisionsschraubendreher",
          modell: "Parkside",
          menge: 5,
          isThere: true,
        },
      ],
    },
  },
};

const openBag = (number) => {
  isBagSelected.value = true;
  selectedBagNumber.value = number + 1;
  console.log("bags", bags.value);
  
  let counter = 0;
  console.log("number", number);
  for (const key in bags.value) {
    if (bags.value.hasOwnProperty(key)) {
      if(counter == number){
        selectedBagData.value = bags.value[key];
      }
      counter++;
      // console.log(key); // bag1, bag2, bag3, bag4
      console.log(bags.value[key]); // bag1 data, bag2 data, etc.
    }
  }
  console.log("selected bag", selectedBagData.value);
};

const getBags = async () => {
  bags.value = await fetchus.postfetch(pathconfig.server + pathconfig.getbag);
  bags.value = JSON.parse(bags.value.bagData);
};

onMounted(async () => {
  await getBags();
  // addbag();
});

const addbag = () => {
  console.log("bags", JSON.parse(bags.value.bagData));
  bags.value.bagData = { ...JSON.parse(bags.value.bagData), ...newbag };
  console.log("bags", bags.value.bagData);
};
</script>
