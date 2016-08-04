import angular = require("angular");
import toastr = require("toastr");

angular.module("gvApp.modules")
    .factory("myreservationService", myreservationService);

myreservationService.$inject = ["$http"];

function myreservationService($http: angular.IHttpService) {
    var service = {
        GetReservationByGuest: GetReservationByGuest,
    };

    return service;

    function GetReservationByGuest(guestCode) {
        return $http.post("/Weixin/MyHotel/GetReservationByGuest",guestCode)
            .success(d => {
                return d;
            })
            .error(e => {
                toastr.error("GetReservationByGuest Error!");
            });
    }
}