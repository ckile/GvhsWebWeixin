import angular = require("angular");

angular.module("gvApp.modules")
    .controller("roomServiceController", roomServiceController);

roomServiceController.$inject = ["$rootScope", "$scope"];

function roomServiceController($roomScope, $scope) {
    var vm = this;
}