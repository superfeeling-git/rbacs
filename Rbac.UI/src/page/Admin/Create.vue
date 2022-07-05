<template>
    <div>
        <el-form :model="ruleForm" :rules="rules" ref="ruleForm" label-width="100px" class="demo-ruleForm">
            <el-form-item label="用户名" prop="userName">
                <el-input v-model="ruleForm.userName"></el-input>
            </el-form-item>
            <el-form-item label="密码" prop="password">
                <el-input type="password" v-model="ruleForm.password"></el-input>
            </el-form-item>
            <el-form-item label="邮箱" prop="email">
                <el-input v-model="ruleForm.email"></el-input>
            </el-form-item>
            <el-form-item label="角色" prop="parentId">
                <el-select v-model="ruleForm.roleId" multiple placeholder="请选择" :style="{width:'360px'}">
                    <el-option v-for="item in options" :key="item.roleId" :label="item.roleName" :value="item.roleId">
                    </el-option>
                </el-select>
            </el-form-item>
            <el-form-item>
                <el-button type="primary" @click="submitForm('ruleForm')">立即创建</el-button>
                <el-button @click="resetForm('ruleForm')">重置</el-button>
            </el-form-item>
        </el-form>
    </div>
</template>

    <script>
    import axios from '../../util/axios';
    export default {
        data() {
            return {
                value: [],
                options: [],                
                ruleForm: {
                    userName: '',
                    password: '',
                    email: '',
                    roleId:[],
                },
                rules: {
                    userName: [
                        { required: true, message: '请输入活动名称', trigger: 'blur' },
                    ],
                    email: [
                        { required: true, message: '请输入Email', trigger: 'blur' },
                        { type: 'email', message: '请输入正确格式的邮箱', trigger: 'blur' }
                    ]
                }
            };
        },
        mounted() {
            axios.get("/api/Role/GetList").then(m => {
                this.options = m.data;
            });
        },
        methods: {
            submitForm(formName) {
                this.$refs[formName].validate((valid) => {
                    if (valid) {
                        //console.log(this.value);
                        //this.ruleForm.parentId = this.value.slice(-1)[0];
                        axios.post('/api/ADmin/Register', this.ruleForm).then(m => {
                            this.$message({
                                showClose: true,
                                message: '添加成功',
                                type: 'success',
                                onClose: m => {
                                    //手动resetFrom
                                    this.$parent.$parent.dialogTableVisible = false;
                                    this.$parent.$parent.loadData();
                                }
                            });
                        });
                    } else {
                        console.log('error submit!!');
                        return false;
                    }
                });
            },
            resetForm(formName) {
                this.$refs[formName].resetFields();
            }
        }
    }
    </script>
