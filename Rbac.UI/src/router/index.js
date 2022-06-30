import Vue from 'vue'
import Router from 'vue-router'
Vue.use(Router)

//MPA 多页面
//SPA 单页面

export default new Router({
  routes: [
    {
      path: '/',
      name: 'index',
      redirect: 'login'
    },
    {
      path: '/login',
      name: 'login',
      component: () => import('../page/login')
    },
    {
      path: '/home',
      name: 'home',
      component: () => import('../page/home'),
      redirect: '/menu',
      children: [{
        path: '/menu',
        name: 'Menu',
        component: () => import('../page/menu')
      },
      {
        path: '/admin',
        name: 'adminManage',
        component: () => import('../page/Admin/adminManage')
      },
      {
        path: '/role',
        name: 'roleManage',
        component: () => import('../page/Role/roleManage')
      }]
    }
  ]
})
