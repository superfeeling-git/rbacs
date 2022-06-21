<template>
    <div>
        <ul>
            <li v-for="item in stuList">
                {{item.id}}
                {{item.name}}
            </li>
        </ul>
        <button>btn</button>
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
    
        mounted() {
    
        },
    
        methods: {
    
        },
    };
    </script>
