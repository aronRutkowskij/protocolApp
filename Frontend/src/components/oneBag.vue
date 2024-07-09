<template>
  <div
    id="container"
    class="flex animate-Smooth_Appear_Fast flex-col cursor-pointer gap-4 justify-center items-center text-center w-[12rem] h-[12rem] rounded-lg bg-container shadow-md border border-neutral-600"
  >
    <font-awesome-icon icon="fa-solid fa-briefcase" class="text-6xl" :class="{[' text-emerald-400']:inCompany,['text-red-400']:!inCompany}" />
    <span class="text-2xl">{{ caseNumber }}</span>
  </div>
</template>

<script setup>
const props = defineProps({ caseNumber: Number, inCompany: Boolean });
</script>
