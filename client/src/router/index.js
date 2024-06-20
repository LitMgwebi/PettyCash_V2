import { createRouter, createWebHistory } from "vue-router";
import HomeView from "../views/HomeView.vue";
import Purpose from "@/views/Pupose/Index.vue";
import NotFound from "@/views/NotFound.vue";

const routes = [
	{
		path: "/",
		name: "home",
		component: HomeView,
	},
	{
		path: "/purposes",
		name: "purposes",
		component: Purpose,
	},
	{
		path: "/about",
		name: "about",
		// route level code-splitting
		// this generates a separate chunk (about.[hash].js) for this route
		// which is lazy-loaded when the route is visited.
		component: () =>
			import(/* webpackChunkName: "about" */ "../views/AboutView.vue"),
	},
	{
		path: "/:catchAll(.*)",
		name: "notFound",
		component: NotFound,
	},
];

const router = createRouter({
	history: createWebHistory(process.env.BASE_URL),
	routes,
});

export default router;
