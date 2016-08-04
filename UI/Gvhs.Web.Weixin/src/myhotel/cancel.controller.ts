import angular = require("angular");
import toastr = require("toastr");

angular.module("gvApp.modules")
    .controller("cancelController", cancelController);

cancelController.$inject = ["$rootScope", "$scope", "$modal", "$state","appConfig","cancelService"];

function cancelController($rootScope, $scope, $modal, $state, appConfig, cancelService) {
    var vm = this;
    vm.resvNum = appConfig.config.current;
    vm.arrDt = "";
    vm.dptDt = "";
    vm.rmType = "";
    vm.rate = "";
    vm.remark = "";
    vm.cancel = cancel;
    vm.back = back;
    
    active();

    function active() {
        cancelService.getResvByResvNum(vm.resvNum)
            .then(d => {
                //alert(JSON.stringify(vm.resvNum))
                //alert(JSON.stringify(d.data))
                if (vm.resvNum != null) {
                    vm.arrDt = d.data.ArrDt;
                    vm.dptDt = d.data.DptDt;
                    vm.rmType = d.data.RmType;
                    vm.rate = d.data.Rate;
                }
                else {
                    toastr.error("获取失败");
                }
            });
    }

    function cancel(resvNum) {
        cancelService.cancelReservation(vm.resvNum)
            .then(d => {
                //alert(JSON.stringify(d.data))
                if (d.data.data == "1") {
                    toastr.success("取消订单成功");
                    $state.go("app.myreservation");
                }
                else {
                    toastr.error("取消订单失败");
                }
            });
    }

    function back() {
        $state.go("app.myreservation");
    }
}