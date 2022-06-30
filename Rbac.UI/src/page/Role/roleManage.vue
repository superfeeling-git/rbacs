<template>
    <div>
        <el-table :data="tableData" style="width: 100%">
            <el-table-column label="角色Id" width="180">
                <template slot-scope="scope">
                    <span style="margin-left: 10px">{{ scope.row.roleId }}</span>
                </template>
            </el-table-column>
            <el-table-column label="角色名称" width="180">
                <template slot-scope="scope">
                    {{ scope.row.roleName }}
                </template>
            </el-table-column>
            <el-table-column label="操作">
                <template slot-scope="scope">
                    <el-button size="mini" @click="handleEdit(scope.$index, scope.row)">编辑</el-button>
                    <el-button size="mini" @click="assignPerm(scope.row.roleId)">分配权限</el-button>
                    <el-button size="mini" type="danger" @click="handleDelete(scope.$index, scope.row)">删除
                    </el-button>
                </template>
            </el-table-column>
        </el-table>
        <el-dialog title="分配权限" :visible.sync="dialogVisible">
            <menu-tree :mid="xxx"></menu-tree>
            <span slot="footer" class="dialog-footer">
                <el-button @click="dialogVisible = false">取 消</el-button>
                <el-button type="primary" @click="SavePermission()">确 定</el-button>
            </span>
        </el-dialog>
    </div>
</template>

    <script>
    import menuTree from '../menuTree';
    import axios from '../../util/axios';
    import moment from 'moment';
    export default {
        components: {
            menuTree
        },
        data() {
            return {
                tableData: [],
                moment,
                dialogVisible: false
            }
        },
        created() {
            axios.get('api/Role/GetList').then(m => {
                this.tableData = m.data;
            });
    
            //console.log(moment().format('YYYY-MM-DD Q DDD d'));
        },
        methods: {
            handleEdit(index, row) {
                console.log(index, row);
            },
            handleDelete(index, row) {
                console.log(index, row);
            },
            formatter(row, column, cellValue, index) {
                return row.isLock ? "是" : "否";
            },
            assignPerm(roleId) {
                this.dialogVisible = true;
            },
            SavePermission() {
                //获取数据
            }
        }
    }
    </script>
