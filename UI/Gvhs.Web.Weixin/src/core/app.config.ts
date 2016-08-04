import angular = require("angular");
/* 全局配置服务
    使用Provider来申明，保证各个阶段可用
------------------------------*/
angular.module("gvApp.core")
    .provider("appConfig", appConfigProvider);

appConfigProvider.$inject = [];

function appConfigProvider(): angular.IServiceProvider {
    var ac = this;
    ac.config = {
        user: null,
        hotelInfo: null
    };

    

    return {
        $get: function() {
            return { config: ac.config }
        }
    }
}
