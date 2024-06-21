import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import Purpose from '@/views/Pupose/Index.vue'
import Department from '@/views/Department/Index.vue'
import Office from '@/views/Office/Index.vue'
import SubAccount from '@/views/SubAccount/Index.vue'
import MainAccount from '@/views/MainAccount/Index.vue'
import NotFound from '@/views/NotFound.vue'

const routes = [
    {
        path: '/',
        name: 'home',
        component: HomeView
    },
    {
        path: '/purposes',
        name: 'purposes',
        component: Purpose
    },
    {
        path: '/departments',
        name: 'departments',
        component: Department
    },
    {
        path: '/offices',
        name: 'offices',
        component: Office
    },
    {
        path: '/sub_accounts',
        name: 'sub_accounts',
        component: SubAccount
    },
    {
        path: '/main_accounts',
        name: 'main_accounts',
        component: MainAccount
    },
    {
        path: '/about',
        name: 'about',
        // route level code-splitting
        // this generates a separate chunk (about.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () => import(/* webpackChunkName: "about" */ '../views/AboutView.vue')
    },
    {
        path: '/:catchAll(.*)',
        name: 'notFound',
        component: NotFound
    }
]

const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes
})

export default router
