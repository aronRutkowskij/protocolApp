<template>
  <div
    id="page"
    class="flex flex-wrap overflow-scroll no-scrollbar justify-center items-center gap-4 w-full h-screen bg-background text-text"
  >
    <oneBag
      v-for="(item, index, count) in bags"
      :inCompany="item.inCompany"
      :caseNumber="item.name"
      @click="openBag(count)"
    />
    <addNewBag v-if="!isBagSelected" @click="addbag" />
    <oppenedBagWindow
      v-if="isBagSelected"
      :selectedBag="selectedBagNumber"
      :bagData="selectedBagData"
      :techniker="techniker"
      @closeWindow="isBagSelected = false"
      @saveAll="saveAll"
      @deleteBag="deleteBag"
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
const selectedBagKey = ref();
const bags = ref([]);
const selectedBagData = ref({});
const techniker = ref([]);

const newbag = {
  bag5: {
    name: 5,
    type: "Werkzeugtasche",
    modell: "Parkside",
    inCompany: true,
    get: {
      date1: "",
      date2: "",
      techniker1: "",
      techniker1_signature: "",
      techniker2: "",
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
      date2: "",
      date1: "",
      techniker1: "",
      techniker1_signature: "",
      techniker2: "",
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
  selectedBagNumber.value = number + 1;
  console.log("bags", bags.value);

  let counter = 0;
  console.log("number", number);
  for (const key in bags.value) {
    if (bags.value.hasOwnProperty(key)) {
      if (counter == number) {
        selectedBagData.value = bags.value[key];
        selectedBagKey.value = key;
      }
      counter++;
      // console.log(key); // bag1, bag2, bag3, bag4
      // console.log(bags.value[key]); // bag1 data, bag2 data, etc.
    }
  }
  console.log("selected bag", selectedBagData.value);
  isBagSelected.value = true;
};

const getBags = async () => {
  bags.value = await fetchus.postfetch(pathconfig.server + pathconfig.getbag);
  console.log("bags", bags.value);
  bags.value = JSON.parse(bags.value.bagData);
};

const getTechniker = async () => {
  techniker.value = await fetchus.postfetch(
    pathconfig.server + pathconfig.gettechniker
  );
  console.log("techinker", techniker.value);
};

const saveAll = async () => {
  const formdata = new FormData();
  formdata.append("jsondata", JSON.stringify(bags.value));
  const save = await fetchus.postfetch(
    pathconfig.server + pathconfig.updatebag,
    formdata
  );
  console.log("saved", save);

  isBagSelected.value = false;
};

onMounted(async () => {
  await getBags();
  await getTechniker();
  // await addInitialBag();
});

const addbag = async () => {
  let counter = 1;
  for (const key in bags.value) {
    if (bags.value.hasOwnProperty(key)) {
      counter++;
    }
  }
  newbag.bag5.name = counter;
  console.log("newbag", newbag);
  console.log("bags1", JSON.parse(JSON.stringify(bags.value)));

  const newKey = `bag${counter}`;
  const dynamicNewBag = { [newKey]: newbag.bag5 };
  bags.value = { ...JSON.parse(JSON.stringify(bags.value)), ...dynamicNewBag };

  console.log("bags with added", bags.value);
  await saveAll();
  await getBags();
};

const deleteBag = async () => {
  bags.value = Object.fromEntries(
    Object.entries(bags.value).filter(([key, value]) => key !== selectedBagKey.value)
  );
  isBagSelected.value = false;
  await saveAll();
  await getBags();
};

const addInitialBag = async () => {
  const b = ref([]);
  b.value = protocolTemplate;
  const formdata = new FormData();
  formdata.append("jsondata", JSON.stringify(b.value));
  const added = await fetchus.postfetch(
    "http://localhost:5070/protocolapp/bag/add",
    formdata
  );
  console.log("added", added);
};
</script>
