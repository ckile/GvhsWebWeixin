import angular = require("angular");
import toastr = require("toastr");

angular.module("gvApp.layout")
    .factory("layoutService", layoutService);

layoutService.$inject = ["$http"];

export interface ILayoutService {
    getUser(): angular.IPromise<any>;
    getHotelInfo(): angular.IPromise<any>;
}


function layoutService($http: angular.IHttpService): ILayoutService {
    var services = {
        getUser: getUser,
        getHotelInfo: getHotelInfo
    };
    return services;
    /**
     * 获取用户Profile信息
     */
    function getUser(): angular.IPromise<any> {
        return $http.get("/Weixin/api/Guests")
            .success(d => { return d })
            .error(e => {
                toastr.error("User Error!");
            });
    }
    /**
     * 获取酒店基本信息
     */
    function getHotelInfo(): angular.IPromise<any> {
        return $http.get("/Weixin/api/HotelInfo")
            .success(d => { return d })
            .error(e => { toastr.error("Hotel Info Error!"); });
    }

}