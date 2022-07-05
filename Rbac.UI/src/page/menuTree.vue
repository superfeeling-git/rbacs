<template>
    <div>
        <el-tree ref="menuTree" :default-checked-keys="chkId" :data="data" show-checkbox node-key="value"
            :default-expand-all="true" :props="defaultProps">
        </el-tree>
    </div>
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
                },
                chkId: []
            };
        },
        props: {
            roleId: {
                type: Number,
            },
        },
        created() {
            axios.get("/api/Menu/GetCascaderAll").then(m => {
                var reg = new RegExp('\\,"children":\\[]', 'g')
                this.data = JSON.parse(JSON.stringify(m.data).replace(reg, ''));
            });
    
            axios.get(`/api/Role/GetPermissionByRoleId?RoleId=${this.roleId}`).then(m => {
                this.chkId = m.data.map(m => m.menuId);
            });
        },
        methods: {
            getdata() {
                var list = this.$refs.menuTree.getCheckedNodes(true, true).map(m => m.value);
                console.log(list);
            }
        },
    };
    </script>
