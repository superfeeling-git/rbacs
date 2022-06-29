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
            <el-table-column label="操作">
                <template slot-scope="scope">
                    <el-button size="mini" @click="handleEdit(scope.$index, scope.row)">编辑</el-button>
                    <el-button size="mini" type="danger" @click="handleDelete(scope.$index, scope.row)">删除
                    </el-button>
                </template>
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
            loadData() {
                axios.get("/api/Menu/GetAll").then(m => {
                    this.tableData = m.data;
                });
            },
            handleEdit(index, row) {
                console.log(index, row);
            },
            handleDelete(index, row) {
                if (row.children.length > 0) {
                    this.$message.error('还有子节点，不能删除');
                }
                else {
                    this.$confirm('此操作将永久删除该文件, 是否继续?', '提示', {
                        confirmButtonText: '确定',
                        cancelButtonText: '取消',
                        type: 'warning'
                    }).then(() => {
                        axios.get(`/api/Menu/Delete?id=${row.menuId}`).then(m => {
                            this.$message({
                                message: '删除成功',
                                type: 'success',
                                duration: 1000,
                                onClose: (m) => {
                                    this.loadData();
                                }
                            });
                        });
                    }).catch(() => {
                        this.$message({
                            type: 'info',
                            message: '已取消删除'
                        });
                    });    
                }
            }
        },
    };
    </script>
