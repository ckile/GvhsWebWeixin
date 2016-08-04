import angular = require("angular");
import "./core/core.module";
import "./core/modules.module";
import "./core/app.config";

import "./layout/layout.module";
import "./layout/setting";
import "./layout/layout.service";
import "./layout/page-loader.controller";
import "./layout/app.controller";
import "./layout/header.controller";
import "./layout/sidebar.controller";
import "./home/home.controller";

import "./widgets/widgets.module";
import "./widgets/a.directive";


import "./booking/booking.controller";
import "./booking/booking.service";
import "./control/control.controller";
import "./myhotel/myhotel.controller";
import "./myhotel/myhotel.service";
import "./myhotel/myreservation.controller";
import "./myhotel/myreservation.service";
import "./myhotel/cancel.controller";
import "./myhotel/cancel.service";
import "./roomservice/roomservice.controller";
import "./proprietor/proprietor.controller";
import "./manager/manager.controller";
import "./manager/manager.service";
import "./manager/roomview.controller";
import "./manager/roomview.service";
import "./manager/roomviewchild.controller";
import "./manager/roomviewchild.service";
import "./manager/realtimestatistic.controller";
import "./manager/realtimestatistic.service";
import "./manager/operationanalysis.controller";
import "./manager/operationanalysis.service";
import "./layout/apps";

//import "!style!css!less!bootstrap/dist/css/bootstrap.css";

angular.module("gvApp", [
    "gvApp.core",
    "gvApp.layout",
    "gvApp.widgets",
    "gvApp.modules"
])
    .config(['$stateProvider', '$urlRouterProvider', 'appConfigProvider', function ($stateProvider: angular.ui.IStateProvider, $urlRouterProvider, appConfigProvider) {
        $urlRouterProvider.otherwise("/app/home");

        $stateProvider
            .state("app", {
                url: "/app",
                templateUrl: "/Weixin/Home/App",
                abstract: true
            })
            .state("app.home", {
                url: "/home",
                templateUrl: "/Weixin/Home/Home",
                data: { title: "主页" }
            })
            .state("app.booking", {
                url: "/booking",
                templateUrl: "/Weixin/Booking/Index",
                data: { title: "预订" },
                resolve: {
                    service: ['$ocLazyLoad', function ($ocLazyLoad) {
                        return $ocLazyLoad.load({
                            serie: true,
                            files: [
                                '/weixinsrc/assets/plugins/bootstrap-datepicker/css/datepicker3.css',
                                '/weixinsrc/assets/plugins/bootstrap-daterangepicker/daterangepicker-bs3.css',
                                '/weixinsrc/js/booking.js'

                            ]
                        });
                    }]
                }

            })
            .state("app.control", {
                url: "/control",
                templateUrl: "/Weixin/Control/Index",
                data: { title: "Control" }
            })
            .state("app.myhotel", {
                url: "/myhotel",
                templateUrl: "/Weixin/MyHotel/Index",
                data: { title: "我的酒店" }
            })
            .state("app.myreservation", {
                url: "/myreservation",
                templateUrl: "/Weixin/MyHotel/MyReservation",
                data: { title: "我的订单" }
            })
            .state("app.cancel", {
                url: "/cancel",
                templateUrl: "/Weixin/MyHotel/Cancel",
                data: { title: "取消" }
            })
            .state("app.roomservice", {
                url: "/roomservice",
                templateUrl: "/Weixin/RoomService/Index",
                data: { title: "客房服务" }
            })
            .state("app.proprietor", {
                url: "/proprietor",
                templateUrl: "/Weixin/Proprietor/Index",
                data: { title: "我是业主" }
            })
            .state("app.manager", {
                url: "/manager",
                templateUrl: "/Weixin/Manager/Index",
                data: { title: "掌控" }
            })
            .state("app.roomview", {
                url: "/roomview",
                templateUrl: "Weixin/Manager/RoomView",
                data: { title: "房态图" }
            })
            .state("app.roomviewchild", {
                url: "/roomviewchild",
                templateUrl: "Weixin/Manager/RoomViewChild",
                data: { title: "房态图子项" }
            })
            .state("app.realtimestatistic", {
                url: "/realtimestatistic",
                templateUrl: "Weixin/Manager/RealtimeStatistic",
                data: { title: "实时统计" }
            })
            .state("app.operationanalysis", {
                url: "/operationanalysis",
                templateUrl: "Weixin/Manager/OperationAnalysis",
                data: { title: "经营分析" }
            });
    }])

    .run(['$rootScope', '$state', 'setting', function ($rootScope, $state, setting) {
        $rootScope.$state = $state;
        $rootScope.setting = setting;
    }]);