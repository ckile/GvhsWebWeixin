import angular = require("angular");
import toastr = require("toastr");

angular.module("gvApp.modules")
    .factory("roomviewchildService", roomviewchildService);

roomviewchildService.$inject = ["$http"];

function roomviewchildService($http: angular.IHttpService) {
    var service = {
        getRoomViewByRmNum: getRoomViewByRmNum
    };

    return service;

    function getRoomViewByRmNum(rmNum) {
        return $http.post("/Weixin/Manager/GetRoomViewByRmNum", rmNum)
            .success(d => {
                return d;
            })
            .error(e => {
                toastr.error("GetRoomViewByRmNum Error!");
            });
    }
}