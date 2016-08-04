import angular = require("angular");
import toastr = require("toastr");

angular.module("gvApp.modules")
    .controller("managerController", managerController);

managerController.$inject = ["$rootScope", "$scope", "managerService", "$modal", "$state"];

function managerController($rootScope, $scope, managerService, $modal, $state) {
    var vm = this;
    vm.occupancyRate = 0;
    vm.averageRoomRate = 0;
    vm.expectedRevenue = 0;
    vm.roomView = roomView;
    vm.realtimeStatistic = realtimeStatistic;
    vm.operationAnalysis = operationAnalysis;

    active();

    function active() {
        managerService.getData()
            .then(d => {
                //alert(JSON.stringify(d.data))
                if (d.data.occRate != null || d.data.avgRate != null || d.data.reve != null) {
                    vm.occupancyRate = change(d.data.occRate);
                    vm.averageRoomRate = change2(d.data.avgRate);
                    vm.expectedRevenue = change2(d.data.reve);
                }
                else {
                    toastr.error("获取失败");
                }
            });
    }
    //转换百分数并保留两位小数
    function change(str) {
        var str2 = str.toFixed(4);
        var str3 = str2.slice(2, 4) + "." + str2.slice(4, 6);
        return str3;
    }
    //保留两位小数
    function change2(str) {
        var str2 = str.toFixed(2);
        return str2;
    }


    function roomView() {
        $state.go("app.roomview");
    }

    function realtimeStatistic() {
        $state.go("app.realtimestatistic");
    }

    function operationAnalysis() {
        $state.go("app.operationanalysis");
    }
}