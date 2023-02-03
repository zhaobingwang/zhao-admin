<script setup lang="ts">
import { getSample, createSample } from '@/api/sample';
getSample('F89CA7E8-07EA-4D92-1A7F-08DB05C60018').then((res) => {
  console.log('res', res);
});
</script>

<template>
  <main>
    <t-date-picker />
  </main>
</template>
