import Vue from 'vue'
import Router from 'vue-router'
Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Menu',
      component: ()=>import('../page/menu')
    },
    {
      path: '/coma',
      name: 'coma',
      component: ()=>import('../page/comA')
    }
  ]
})
