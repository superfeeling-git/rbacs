<template>
    <el-tree :data="data" show-checkbox node-key="value" :default-expand-all="true" :props="defaultProps">
    </el-tree>
</template>
    <script>
    import axios from '../util/axios';
    export default {
        data() {
            return {
                data: [],
                defaultProps: {
                    //id: 'value',
                    children: 'children',
                    label: 'label'
                }
            };
        },
        props:{
            xxx:{
                type:Number
            }
        },
        created() {
            axios.get("/api/Menu/GetCascaderAll").then(m => {
                var reg = new RegExp('\\,"children":\\[]', 'g')
                this.data = JSON.parse(JSON.stringify(m.data).replace(reg, ''));
            });
        },
    };
    </script>
