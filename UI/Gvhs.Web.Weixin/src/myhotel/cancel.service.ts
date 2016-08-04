import angular = require("angular");
import toastr = require("toastr");

angular.module("gvApp.modules")
    .factory("cancelService", cancelService);

cancelService.$inject = ["$http"];

function cancelService($http: angular.IHttpService) {
    var service = {
        getResvByResvNum: getResvByResvNum,
        cancelReservation: cancelReservation
    };

    return service;

    function getResvByResvNum(resvNum) {
        return $http.post("/Weixin/MyHotel/GetResvByResvNum", resvNum)
            .success(d => {
                return d;
            })
            .error(e => {
                toastr.error("GetResvByResvNum Error!");
            });
    }

    function cancelReservation(resvNum) {
        return $http.post("/Weixin/MyHotel/CancelReservation", resvNum)
            .success(d => {
                return d;
            })
            .error(e => {
                toastr.error("ResvCancel Error!");
            });
    }

}