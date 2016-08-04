import angular = require("angular");
import toastr = require("toastr");

angular.module("gvApp.modules")
    .factory("managerService", managerService);

managerService.$inject = ["$http"];

function managerService($http: angular.IHttpService) {
    var services = {
        getData : getData
    };

    return services;

    function getData() {
        return $http.get("/Weixin/Manager/GetData")
            .success(d => {
                return d;
            })
            .error(e => {
                toastr.error("GetData Error!");
            });
    }
}