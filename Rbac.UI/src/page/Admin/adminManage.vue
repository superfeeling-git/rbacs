<template>
    <div>
        <el-form :inline="true" class="demo-form-inline">
            <el-form-item>
                <el-button type="primary" @click="Create">添加</el-button>
            </el-form-item>
        </el-form>
        <el-table :data="tableData" style="width: 100%">
            <el-table-column label="用户Id" width="180">
                <template slot-scope="scope">
                    <span style="margin-left: 10px">{{ scope.row.adminId }}</span>
                </template>
            </el-table-column>
            <el-table-column label="用户名" width="180">
                <template slot-scope="scope">
                    {{ scope.row.userName.toLowerCase() }}
                </template>
            </el-table-column>
            <el-table-column label="是否锁定" width="180" :formatter="formatter" />
            <el-table-column label="创建时间" width="180">
                <template slot-scope="scope">
                    {{ moment(scope.row.createTime).format('YYYY-MM-DD') }}
                </template>
            </el-table-column>
            <el-table-column label="操作">
                <template slot-scope="scope">
                    <el-button size="mini" @click="handleEdit(scope.$index, scope.row)">编辑</el-button>
                    <el-button size="mini" type="danger" @click="handleDelete(scope.$index, scope.row)">删除
                    </el-button>
                </template>
            </el-table-column>
        </el-table>
        <el-dialog title="添加管理员" :visible.sync="dialogTableVisible">
            <admin-create :key="new Date().getTime()"></admin-create>
        </el-dialog>
    </div>
</template>

    <script>
    import axios from '../../util/axios';
    import AdminCreate from './Create';
    import moment from 'moment';
    export default {
        components: {
            AdminCreate
        },
        data() {
            return {
                tableData: [],
                moment,
                dialogTableVisible: false
            }
        },
        created() {
            axios.get('api/Admin/Page').then(m => {
                //console.log(m.data.item1);
                this.tableData = m.data.item1;
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
            Create() {
                this.dialogTableVisible = true;
            }
        }
    }
    </script>
