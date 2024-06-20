import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import middlewareSettings from "./router/axios";

createApp(App).use(store).use(middlewareSettings).use(router).mount("#app");
