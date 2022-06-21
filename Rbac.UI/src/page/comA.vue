<template>
    <div>
        <com-b :stuList="stu"></com-b>
    </div>
</template>

<script>
import ComB from './ComB';
export default {
name: 'RbacUIComA',
    components:{
        ComB
    },

    data() {
        return {
            stu:[
                {
                    id:1,
                    name:"张三"
                },
                {
                    id:2,
                    name:"李四"
                }
            ]
        };
    },

    mounted() {
        
    },

    methods: {
        
    },
};
</script>