import angular = require("angular");
import ser = require("./layout.service");
import $ = require("jquery");
import "angular-strap";

angular
    .module("gvApp.layout")
    .controller("headerController", headerController);

headerController.$inject = ["$scope", "$rootScope", "$state","appConfig", "layoutService", "$modal"];

function headerController($scope: angular.IScope, $rootscope: angular.IRootScopeService, $state: angular.ui.IState, appConfig ,layoutService: ser.ILayoutService, $modal: mgcrea.ngStrap.modal.IModalService) {
    var vm = this;
    vm.hotelName = "Hotel Name";
    vm.userName = "User Name";
    vm.headImgUrl = "";
    vm.roomCode = null;
    vm.hotelNameClick = hotelNameClick;
    vm.userNameClick = userNameClick;
    vm.roomCodeClick = roomCodeClick;
    vm.tipClick = tipClick;

    active();

    function active() {
        layoutService.getUser()
            .then(d => {
                vm.userName = d.data.Name;
                vm.headImgUrl = d.data.WeixinHeadimgurl;
                appConfig.config.user = d.data;   // 保存user到appConfig
            });

        layoutService.getHotelInfo()
            .then(function (d) {
                vm.hotelName = d.data.hotelName;
                appConfig.config.hotelInfo = d.data;
            });
    }

    function hotelNameClick() {
        $modal({
            title: vm.hotelName,
            content: "This Tips",
            show: true
        });
    }

    function userNameClick() {

    }

    function roomCodeClick() {
        $modal({
            title: "提示",
            content: "您已入住酒店，房间号为:" + vm.roomCode,
            show: true
        });
    }

    function tipClick() { }


}