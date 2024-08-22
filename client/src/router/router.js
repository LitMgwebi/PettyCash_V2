import { createRouter, createWebHistory } from 'vue-router'
import { authGuard } from './axios'

const guard = (to, from, next) => {
    const auth = store.getters.isAuthenticated
    if (auth) {
        next()
    } else {
        router.push({ name: 'home' })
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
        // beforeEnter: guard
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
        path: '/transactions',
        name: 'transactions',
        component: () => import('@/views/Transaction/Index.vue')
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
        component: () => import('@/views/Requisition/Index.vue'),
        children: [
            {
                path: '/requisitions/applied',
                name: 'applied_list',
                component: () => import('@/components/Requisition/Lists/ApplicantList.vue')
            },
            {
                path: '/requisitions/recommendation',
                name: 'recommended_list',
                component: () => import('@/components/Requisition/Lists/RecommendationList.vue')
            },
            {
                path: '/requisitions/approval',
                name: 'approval_list',
                component: () => import('@/components/Requisition/Lists/ApprovalList.vue')
            },
            {
                path: '/requisitions/issuing',
                name: 'issuing_list',
                component: () => import('@/components/Requisition/Lists/IssuingList.vue')
            },
            {
                path: '/requisitions/close',
                name: 'close_list',
                component: () => import('@/components/Requisition/Lists/CloseList.vue')
            }
        ]
    },
    {
        path: '/requisitions/statuses',
        name: 'requisitions_statuses',
        component: () => import('@/components/Requisition/Lists/StatusesList.vue')
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
