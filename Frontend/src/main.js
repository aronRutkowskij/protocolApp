import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import "./index.css";

/* import the fontawesome core */
import { library } from "@fortawesome/fontawesome-svg-core";

/* import font awesome icon component */
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";

/* import specific icons */
import {
  faBriefcase,
  faPlus,
  faArrowLeft,
  faTrashCan,
  faCircleInfo
} from "@fortawesome/free-solid-svg-icons";

/* add icons to the library */
library.add(faBriefcase, faPlus, faArrowLeft, faTrashCan, faCircleInfo);

import Vue3Signature from "vue3-signature";

const app = createApp(App);
app.use(router);
app.use(Vue3Signature);
app.component("font-awesome-icon", FontAwesomeIcon);
app.mount("#app");
