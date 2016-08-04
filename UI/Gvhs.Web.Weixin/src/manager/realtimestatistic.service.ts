import angular = require("angular");
import toastr = require("toastr");

angular.module("gvApp.modules")
    .factory("realtimestatisticService", realtimestatisticService);

realtimestatisticService.$inject = ["$http"];

function realtimestatisticService($http: angular.IHttpService) {
    var services = {
        getData : getData
    };

    return services;

    function getData() {
        return $http.get("/Weixin/Manager/GetRealtimeStatistic")
            .success(d => {
                return d;
            })
            .error(e => {
                toastr.error("GetData Error!");
            });
    }
}