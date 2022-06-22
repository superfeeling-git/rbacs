<template>
    <div>
        <el-form :model="ruleForm" :rules="rules" ref="ruleForm" label-width="100px" class="demo-ruleForm">
            <el-form-item label="父级菜单" prop="parentId">
                <el-cascader v-model="value" :options="options" @change="handleChange"></el-cascader>
            </el-form-item>
            <el-form-item label="菜单名称" prop="menuName">
                <el-input v-model="ruleForm.menuName"></el-input>
            </el-form-item>
            <el-form-item label="菜单链接" prop="linkurl">
                <el-input v-model="ruleForm.linkurl"></el-input>
            </el-form-item>
            <el-form-item>
                <el-button type="primary" @click="submitForm('ruleForm')">立即创建</el-button>
                <el-button @click="resetForm('ruleForm')">重置</el-button>
            </el-form-item>
        </el-form>
    </div>
</template>

    <script>
    import axios from '../util/axios';
    export default {
        data() {
            return {
                value: [],
                options: [],
                ruleForm: {
                    parentId: 0,
                    menuName: '',
                    linkurl: ''
                },
                rules: {
                    name: [
                        { required: true, message: '请输入活动名称', trigger: 'blur' },
                        { min: 3, max: 5, message: '长度在 3 到 5 个字符', trigger: 'blur' }
                    ]
                }
            };
        },
        mounted() {
            axios.get("/api/Menu/GetCascaderAll").then(m => {
                var reg = new RegExp('\\,"children":\\[]', 'g')
                this.options = JSON.parse(JSON.stringify(m.data).replace(reg, ''));
            });
        },
        methods: {
            submitForm(formName) {
                this.$refs[formName].validate((valid) => {
                    if (valid) {
                        this.ruleForm.parentId = this.value.slice(-1)[0];
                        axios.post('/api/Menu/Create', this.ruleForm).then(m => {
                            this.$message({
                                showClose: true,
                                message: '添加成功',
                                type: 'success',
                                onClose: m => {
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
            },
            handleChange(val) {
    
            }
        }
    }
    </script>
