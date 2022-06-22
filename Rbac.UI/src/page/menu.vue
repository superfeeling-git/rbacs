<template>
    <div>
        <el-form :inline="true" class="demo-form-inline">
            <el-form-item>
                <el-button type="primary" @click="CreateMenu">添加</el-button>
            </el-form-item>
        </el-form>
        <el-table :data="tableData" style="width: 100%;margin-bottom: 20px;" row-key="menuId" border default-expand-all
            :tree-props="{ children: 'children', hasChildren: 'hasChildren' }">
            <el-table-column prop="menuId" label="菜单ID" sortable width="180">
            </el-table-column>
            <el-table-column prop="menuName" label="菜单名称" sortable width="180">
            </el-table-column>
            <el-table-column prop="linkUrl" label="菜单链接" sortable width="180">
            </el-table-column>
        </el-table>
        <el-dialog title="添加菜单" :visible.sync="dialogTableVisible">
            <menu-create></menu-create>
        </el-dialog>
        <!--MVVM模式，组件化开发-->
    </div>
</template>

    <script>
    import axios from "axios";
    import MenuCreate from './menuCreate.vue';
    
    export default {
        name: 'RbacUIMenu',
    
        components: {
            MenuCreate      //驼峰命名法
        },
    
        data() {
            return {
                tableData: [],
                dialogTableVisible: false
            };
        },
    
        mounted() {
            this.loadData();
        },
    
        methods: {
            CreateMenu() {
                this.dialogTableVisible = true;
            },
            loadData(){
                    axios.get("https://localhost:5001/api/Menu/GetAll").then(m => {
                    this.tableData = m.data;
                });
            }
        },
    };
    </script>
