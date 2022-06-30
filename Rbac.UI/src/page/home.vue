<template>
    <el-container>
        <el-header>权限管理系统</el-header>
        <el-container>
            <el-aside width="200px">
                <el-menu default-active="/menu" class="el-menu-vertical-demo" @open="handleOpen" @close="handleClose"
                    background-color="#545c64" text-color="#fff" active-text-color="#ffd04b"
                    :unique-opened="false" :router="true">
                    <el-submenu :index="String(item.menuId)" v-for="(item, index) in rootMenu" :key="item.menuId">
                        <template slot="title">
                            <i class="el-icon-location"></i>
                            <span>
                                {{ item.menuName }}
                            </span>
                        </template>
                        <template v-for="(submenu, i) in menu.filter(m => m.parentId == item.menuId)">
                            <el-menu-item :index="menuItem.linkUrl"
                                v-for="(menuItem, subIndex) in menu.filter(m => m.parentId == submenu.menuId && m.isShow)"
                                :key="menuItem.menuId">
                                {{ menuItem.menuName }}
                            </el-menu-item>
                        </template>
                    </el-submenu>
                </el-menu>
            </el-aside>
            <el-main>
                <router-view />
            </el-main>
        </el-container>
    </el-container>
</template>

    <script>
import axios from '../util/axios';
export default {
    name: 'RbacUIHome',

    data() {
        return {
            menu: []
        };
    },
    mounted() {
        axios.get("/api/menu/GetMenuList").then(m => {
            this.menu = m.data;
            //console.table(this.menu);
        });
    },
    computed: {
        rootMenu() {
            return this.menu.filter((v, i, arr) => {
                // console.log(v);
                // console.log(i);
                // console.log(arr);
                return v.parentId == 0;
            });
        }
    },
    methods: {
        handleOpen(key, keyPath) {
            console.log(key, keyPath);
        },
        handleClose(key, keyPath) {
            console.log(key, keyPath);
        }
    },
};
</script>
    <style>
    .el-menu-vertical-demo {
        text-align: left;
        border-right: 0;
    }
    
    .MainForm {
        width: 80%;
    }
    
    .el-header,
    .el-footer {
        background-color: #B3C0D1;
        color: #333;
        text-align: left;
        line-height: 60px;
        font-weight: bold;
    }
    
    .el-aside {
        background-color: #545c64;
        color: #333;
        text-align: center;
        line-height: 200px;
    }
    
    .el-main {
        background-color: #ffffff;
        color: rgb(23, 23, 23);
        text-align: left;
        height: calc(100vh - 60px);
    }
    
    body>.el-container {
        margin-bottom: 40px;
    }
    
    .el-container:nth-child(5) .el-aside,
    .el-container:nth-child(6) .el-aside {
        line-height: 260px;
    }
    
    .el-container:nth-child(7) .el-aside {
        line-height: 320px;
    }
    </style>
