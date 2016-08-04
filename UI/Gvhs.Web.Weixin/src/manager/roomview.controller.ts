import angular = require("angular");
import toastr = require("toastr");
import $ = require("jquery");

angular.module("gvApp.modules")
    .controller("roomviewController", roomviewController);

roomviewController.$inject = ["$rootScope", "$scope", "roomviewService", "$modal", "$state","appConfig"];

function roomviewController($rootScope, $scope, roomviewService, $modal, $state, appConfig) {
    var vm = this;
    vm.roomviews = [];
    vm.roomviewchild = roomviewchild;

    active();

    function active() {
        roomviewService.getRoomViews()
            .then(d => {
                //alert(JSON.stringify(d.data))
                if (d.data.length > 0) {
                    vm.roomviews = d.data;
                }
                else {
                    toastr.error("获取失败");
                }
            });
    }

    function roomviewchild(rmNum) {
        appConfig.config.current = rmNum;
        $state.go("app.roomviewchild");
    }
}