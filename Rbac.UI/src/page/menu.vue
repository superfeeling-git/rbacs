<template>
    <div>
        <el-table :data="tableData" style="width: 100%;margin-bottom: 20px;" row-key="menuId" border default-expand-all
            :tree-props="{ children: 'children', hasChildren: 'hasChildren' }">
            <el-table-column prop="menuId" label="菜单ID" sortable width="180">
            </el-table-column>
            <el-table-column prop="menuName" label="菜单名称" sortable width="180">
            </el-table-column>            
            <el-table-column prop="linkUrl" label="菜单链接" sortable width="180">
            </el-table-column>
        </el-table>
    </div>
</template>

<script>
    import axios  from "axios";

    export default {
        name: 'RbacUIMenu',
    
        data() {
            return {
                tableData: []
            };
        },
    
        mounted() {
            axios.get("https://localhost:5001/api/Menu/GetAll").then(m=>{
                this.tableData = m.data;
            });
        },
    
        methods: {
    
        },
    };
</script>
