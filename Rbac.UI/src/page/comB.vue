<template>
    <div>
        <ul>
            <li v-for="item in stuList">
                {{item.id}}
                {{item.name}}
            </li>
        </ul>
        <button @click="sendParent">btn</button>
        <button @click="invoke">父组件</button>
    </div>
</template>

    <script>
    export default {
        name: 'RbacUIComB',
    
        data() {
            return {
    
            };
        },
    
        props: {
            stuList: {
                type: Array,
                default:[]
            }
        },
        created() {
            
        },
        mounted() {
            console.log(this.stuList);
        },    
        methods: {
            sendParent(){
                this.$emit('input', 'param');
            },
            test(){
                console.log('子组件方法');
            },
            invoke(){
                console.log(this.$parent.save('aaa'));
            }
        },
    };
    </script>
