import angular = require("angular");
import toastr = require("toastr");

angular.module("gvApp.modules")
    .controller("myreservationController", myreservationController);

myreservationController.$inject = ["$rootScope", "$scope", "$modal", "$state", "myreservationService", "appConfig"];

function myreservationController($rootScope, $scope, $modal, $state, myreservationService, appConfig) {
    var vm = this;
    vm.reservations = [];
    vm.guestCode = 2;
    vm.cancel = cancel;

    active();

    function active() {
        myreservationService.GetReservationByGuest(vm.guestCode)
            .then(d => {
                //alert(JSON.stringify(d.data))
                if (d.data.length > 0) {
                    vm.reservations = d.data;
                }
                else {
                    toastr.error("获取失败");
                }
            });
    }

    function cancel(ResvNum) {
        appConfig.config.current = ResvNum;
        $state.go("app.cancel");
    }
}