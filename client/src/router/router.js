import { createRouter, createWebHistory } from 'vue-router'
import { authGuard } from './axios'

const guard = (to, from, next) => {
    const auth = store.getters.isAuthenticated
    if (auth) {
        next()
    } else {
        router.push('/')
        next()
    }
}
const routes = [
    {
        path: '/',
        name: 'home',
        component: () => import('@/views/HomeView.vue')
    },
    {
        path: '/login',
        name: 'login',
        component: () => import('@/views/Auth/Login.vue')
    },
    {
        path: '/register',
        name: 'register',
        component: () => import('@/views/Auth/Register.vue')
    },
    {
        path: '/dashboard',
        name: 'dashboard',
        component: () => import('@/views/User/Dashboard.vue')
    },
    {
        path: '/purposes',
        name: 'purposes',
        component: () => import('@/views/Purpose/Index.vue')
        // beforeEnter: authGuard
    },
    {
        path: '/divisions',
        name: 'divisions',
        component: () => import('@/views/Division/Index.vue')
        // beforeEnter: guard
    },
    {
        path: '/offices',
        name: 'offices',
        component: () => import('@/views/Office/Index.vue')
    },
    {
        path: '/sub_accounts',
        name: 'sub_accounts',
        component: () => import('@/views/SubAccount/Index.vue')
    },
    {
        path: '/main_accounts',
        name: 'main_accounts',
        component: () => import('@/views/MainAccount/Index.vue')
    },
    {
        path: '/gl_accounts',
        name: 'gl_accounts',
        component: () => import('@/views/GLAccount/Index.vue')
    },
    {
        path: '/requisitions',
        name: 'requisitions',
        component: () => import('@/views/Requisition/List.vue')
    },
    {
        path: '/requisitions/create',
        name: 'requistion_create',
        component: () => import('@/views/Requisition/Create.vue')
    },
    {
        path: '/:catchAll(.*)',
        name: 'notFound',
        component: () => import('@/views/NotFound.vue')
    }
]

const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes
})

export default router
