<template>
  <Vue3Signature
    ref="signature1"
    :sigOption="state.option"
    :w="'640px'"
    :h="'400px'"
    :disabled="state.disabled"
  ></Vue3Signature>
  <div class="flex justify-between w-[640px] gap-0">
      <button
        @click="save('image/jpeg')"
        class="flex cursor-pointer text-emerald-400 justify-center items-center text-center w-16 h-12 bg-container shadow-md border border-neutral-600 rounded-lg"
        :class="{['bg-green-400 text-white']:saved}"
      >
        {{ saveText }}
      </button>
      <button
        @click="clear"
        class="flex cursor-pointer text-red-400  justify-center items-center text-center w-16 h-12 bg-container shadow-md border border-neutral-600 rounded-lg"
      >
        Clear
      </button>
  </div>
</template>

<script setup>
import { reactive, ref } from "vue";

const emits = defineEmits(["saveSig"]);

const state = reactive({
  count: 0,
  option: {
    penColor: "rgb(0, 0, 0)",
    backgroundColor: "rgb(255,255,255)",
  },
  disabled: false,
});

const signature1 = ref(null);
const saved = ref(false);
const saveText = ref("Save");

const save = (t) => {
  // console.log(signature1.value.save(t));
  saved.value = true;
  saveText.value = "Saved";
  emits('saveSig', signature1.value.save(t))
};

const clear = () => {
  saved.value = false;
  saveText.value = "Save";
  signature1.value.clear();
};
</script>
