import angular = require("angular");
import toastr = require("toastr");

angular.module("gvApp.modules")
    .controller("realtimestatisticController", realtimestatisticController);

realtimestatisticController.$inject = ["$rootScope", "$scope", "realtimestatisticService", "$modal", "$state"];

function realtimestatisticController($rootScope, $scope, realtimestatisticService, $modal, $state) {
    var vm = this;
    vm.totalRoom = 0;
    vm.closeRoom = 0;
    vm.repairRoom = 0;
    vm.rentRoom = 0;
    vm.expectArrive = 0;
    vm.actualArrive = 0;
    vm.expectDeparture = 0;
    vm.actualDeparture = 0;
    vm.walkin = 0;
    vm.team = 0;
    vm.personal = 0;
    vm.free = 0;
    vm.meeting = 0;
    vm.longTerm = 0;
    active();

    function active() {
        realtimestatisticService.getData()
            .then(d => {
                //alert(JSON.stringify(d.data))
                if (d.data.length > 0) {
                    vm.totalRoom = d.data.totalRoom;
                    vm.closeRoom = d.data.closeRoom;
                    vm.repairRoom = d.data.repairRoom;
                    vm.rentRoom = d.data.rentRoom;
                    vm.expectArrive = d.data.expectArrive;
                    vm.actualArrive = d.data.actualArrive;
                    vm.expectDeparture = d.data.expectDeparture;
                    vm.actualDeparture = d.data.actualDeparture;
                    vm.walkin = d.data.walkin;
                    vm.team = d.data.team;
                    vm.personal = d.data.personal;
                    vm.free = d.data.free;
                    vm.meeting = d.data.meeting;
                    vm.longTerm = d.data.longTerm;
                }
                else {
                    toastr.error("获取失败");
                }
            });
    }
}