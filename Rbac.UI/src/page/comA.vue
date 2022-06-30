<template>
    <div>
        <ul v-if="state">
            <li v-for="(item, index) in stu" :key="item.id">
                {{ item.name }}
            </li>
        </ul>

        <button @click="toggle">显示/隐藏</button>
    </div>
</template>

    <script>
    export default {
        name: 'RbacUIComA',
    
        data() {
            return {
                stu: [
                    {
                        id: 1,
                        name: '张三'
                    },
                    {
                        id: 2,
                        name: '李四'
                    }
                ],
                state: true
            };
        },
    
        mounted() {
    
        },
    
        methods: {
            toggle() {
                //数据双向绑定
                //jQuery   Dom    append()  html()  text()  Remove()  
                this.state = !this.state;
            }
        },
    };
    </script>
