<template>
    <div class="login">
        <el-card class="box-card loginForm">
            <div slot="header" class="clearfix">
                <span>系统登录</span>
                <el-button style="float: right; padding: 3px 0" type="text">注册</el-button>
            </div>
            <el-form :model="ruleForm" :rules="rules" ref="ruleForm" label-width="100px" class="demo-ruleForm">
                <el-form-item label="用户名" prop="userName">
                    <el-input v-model="ruleForm.userName"></el-input>
                </el-form-item>
                <el-form-item label="密码" prop="password">
                    <el-input type="password" v-model="ruleForm.password"></el-input>
                </el-form-item>
                <el-form-item>
                    <el-button type="primary" @click="submitForm('ruleForm')">登录</el-button>
                    <el-button @click="resetForm('ruleForm')">重置</el-button>
                </el-form-item>
            </el-form>
        </el-card>
    </div>
</template>

    <script>
import axios from '../util/axios';
export default {
    data() {
        return {
            ruleForm: {
                userName: "",
                password: ""
            },
            rules: {
                userName: [
                    { required: true, message: '请输入用户名', trigger: 'blur' },
                    { min: 3, max: 5, message: '长度在 3 到 5 个字符', trigger: 'blur' }
                ],
                password: [
                    { required: true, message: '请输入密码', trigger: 'blur' },
                    { min: 3, max: 5, message: '长度在 3 到 5 个字符', trigger: 'blur' }
                ]
            }
        };
    },
    methods: {
        submitForm(formName) {
            this.$refs[formName].validate((valid) => {
                if (valid) {
                    axios.post("/api/admin/login", this.ruleForm).then(m => {
                        let loginInfo = m.data;
                        if(loginInfo.code > 0){
                            this.$message.error(loginInfo.msg);
                        }
                        else{
                            //保存token
                            localStorage.setItem("token",loginInfo.token);                            
                            this.$router.push("/home");
                        }
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
    <style>
    .login {
        background: rgb(39, 119, 56);
        width: 100%;
        height: 100%;
        padding-top: 15em;
    }
    
    .loginForm {
        margin: 0 auto;
    
        overflow: hidden；
    }
    
    .text {
        font-size: 14px;
    }
    
    .item {
        margin-bottom: 18px;
    }
    
    .clearfix:before,
    .clearfix:after {
        display: table;
        content: "";
    }
    
    .clearfix:after {
        clear: both
    }
    
    .box-card {
        width: 480px;
    }
    </style>
