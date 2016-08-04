import angular = require("angular");
import toastr = require("toastr");

angular.module("gvApp.modules")
    .factory("bookingService", bookingService);

bookingService.$inject = ["$http"];

function bookingService($http: angular.IHttpService) {
    var services = {
        getRoomTypes: getRoomTypes,
        postReservation: postReservation,
        getVerifyCode: getVerifyCode
    };

    return services;

    function getRoomTypes(params) {
        return $http.post("/Weixin/Booking/RoomTypes", params)
            .success(d => { return d; })
            .error(e => { toastr.error("Get Room Type Error!"); });
    }

    function postReservation(resv) {
        return $http.post("/Weixin/api/Reservations", resv)
            .success(d => { return d; })
            .error(e => { toastr.error("Post Reservation Error!"); });
    }

    function getVerifyCode() {
        return $http.get("/Weixin/Booking/GetVerifyCode")
            .success(d => {
                return d;
            })
            .error(e => {
                toastr.error("GetData Error!");
            });
    }
}