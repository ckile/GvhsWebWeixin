import angular = require("angular");
import $ = require("jquery");
import App = require("./apps");
import pace = require("pace");
import ser = require("./layout.service");

angular
    .module("gvApp.layout")
    .controller("appController", shellController);

shellController.$inject = ["$rootScope", "$scope", "appConfig", "layoutService"];

function shellController($rootScope, $scope: angular.IScope, appConfig, layoutService: ser.ILayoutService) {
    var vm = this;
    $scope.$on('$includeContentLoaded', function (d, data) {
        App.App.initComponent();

    });
    $scope.$on('$viewContentLoaded', function (d, data) {
        App.App.initComponent();
        App.App.initLocalStorage();
    });
    $scope.$on('$stateChangeStart', function () {
        // reset layout setting 导航状态修改前触发
        alert("stateChange");
        $rootScope.setting.layout.pageSidebarMinified = true;
        $rootScope.setting.layout.pageFixedFooter = false;
        $rootScope.setting.layout.pageRightSidebar = false;
        $rootScope.setting.layout.pageTwoSidebar = false;
        $rootScope.setting.layout.pageTopMenu = false;
        $rootScope.setting.layout.pageBoxedLayout = false;
        $rootScope.setting.layout.pageWithoutSidebar = true;
        $rootScope.setting.layout.pageContentFullHeight = false;
        $rootScope.setting.layout.pageContentFullWidth = false;
        $rootScope.setting.layout.paceTop = false;
        $rootScope.setting.layout.pageLanguageBar = false;
        $rootScope.setting.layout.pageSidebarTransparent = false;
        $rootScope.setting.layout.pageWideSidebar = false;
        $rootScope.setting.layout.pageLightSidebar = false;
        $rootScope.setting.layout.pageFooter = false;
        $rootScope.setting.layout.pageMegaMenu = false;
        $rootScope.setting.layout.pageWithoutHeader = false;
        $rootScope.setting.layout.pageBgWhite = false;

        App.App.scrollTop();
        $('.pace .pace-progress').addClass('hide');
        $('.pace').removeClass('pace-inactive');
    });
    $scope.$on('$stateChangeSuccess', function () {
        // 导航状态更改
        pace.restart();
        App.App.initPageLoad();
        App.App.initSidebarSelection();
        App.App.initLocalStorage();
        App.App.initSidebarMobileSelection();
    });
    $scope.$on('$stateNotFound', function () {
        pace.stop();
    });
    $scope.$on('$stateChangeError', function () {
        pace.stop();
    });
    active();

    function active() {




    }




}

