<template>
    <div>
        <com-b ref="comb" v-model="ShowData" :stuList="stu"></com-b>
        {{ShowData}}
        <button @click="UpdateCom">Update</button>
        <button @click="invoke">调用子组件方法</button>        
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




            token:{
                header:{
                    "alg":"hs256",
                    "typ":"JWT"
                },
                payload:{
                    "iss":"token颁发者",
                    "aud":"token接收者",
                    "exp":"1小时",
                    "username":"",
                    "role":""
                },
                Signature:{
                    
                }
            }
















            stu:[
                {
                    id:1,
                    name:"张三"
                },
                {
                    id:2,
                    name:"李四"
                }
            ],
            ShowData:''
        };
    },

    mounted() {
        
    },

    methods: {
        UpdateCom(){
            this.stu.push({
                    id:3,
                    name:"王五"
                });
        },
        invoke(){
            this.$refs.comb.test();
        },
        save(p){
            console.log(`save......${p}`);
        }
    },
};
</script>