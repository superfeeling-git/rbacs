import Vue from 'vue'
import Router from 'vue-router'
Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/login',
      name: 'login',
      component: () => import('../page/login')
    },
    {
      path: '/home',
      name: 'home',
      component: () => import('../page/home'),
      children: [{
        path: '/menu',
        name: 'Menu',
        component: () => import('../page/menu')
      },
      {
        path: '/coma',
        name: 'coma',
        component: () => import('../page/comA')
      }]
    }
  ]
})
