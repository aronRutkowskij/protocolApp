<template>
  <Vue3Signature
    ref="signature1"
    :sigOption="state.option"
    :w="'640px'"
    :h="'400px'"
    :disabled="state.disabled"
  ></Vue3Signature>
  <div class="flex w-full gap-10">
      <button
        @click="save('image/jpeg')"
        class="flex cursor-pointer text-emerald-400 justify-center items-center text-center w-16 h-12 bg-container shadow-md border border-neutral-600 rounded-lg"
      >
        Save
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

const state = reactive({
  count: 0,
  option: {
    penColor: "rgb(0, 0, 0)",
    backgroundColor: "rgb(255,255,255)",
  },
  disabled: false,
});

const signature1 = ref(null);

const save = (t) => {
  console.log(signature1.value.save(t));
};

const clear = () => {
  signature1.value.clear();
};
</script>
