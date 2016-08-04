import angular = require("angular");
import toastr = require("toastr");
import $ = require("jquery");

angular.module("gvApp.modules")
    .controller("roomviewchildController", roomviewchildController);

roomviewchildController.$inject = ["$rootScope", "$scope", "roomviewchildService", "$modal", "$state","appConfig"];

function roomviewchildController($rootScope, $scope, roomviewchildService, $modal, $state, appConfig) {
    var vm = this;
    vm.name = "";
    vm.rmNum = appConfig.config.current;
    vm.rmType = "";
    vm.rate = 0.00;
    vm.changeRoomView = changeRoomView;
    vm.back = back;

    active();

    function active() {
        $("#changeRoomView").css("background", "red");

        roomviewchildService.getRoomViewByRmNum(vm.rmNum)
            .then(d => {
                //alert(JSON.stringify(vm.rmNum))
                if (vm.rmNum != null) {
                    vm.name = d.data.Name;
                    vm.rmType = d.data.RmType;
                    vm.rate = d.data.Rate;
                }
                else {
                    toastr.error("获取失败");
                }
            });
    }

    function changeRoomView() {
        $("#changeRoomView").css("background", "green");
    }

    function back() {
        $state.go("app.roomview");
    }
}