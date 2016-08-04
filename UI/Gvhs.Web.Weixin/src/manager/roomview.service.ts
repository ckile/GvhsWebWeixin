import angular = require("angular");
import toastr = require("toastr");

angular.module("gvApp.modules")
    .factory("roomviewService", roomviewService);

roomviewService.$inject = ["$http"];

function roomviewService($http: angular.IHttpService) {
    var service = {
        getRoomViews: getRoomViews,
    };

    return service;

    function getRoomViews() {
        return $http.get("/Weixin/Manager/GetRoomViews")
            .success(d => {
                return d;
            })
            .error(e => {
                toastr.error("GetRoomViews Error!");
            });
    }
}