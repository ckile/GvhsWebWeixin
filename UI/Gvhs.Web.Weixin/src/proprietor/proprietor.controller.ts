import angular = require("angular");

angular.module("gvApp.modules")
    .controller("proprietorController", proprietorController);

proprietorController.$inject = ["$rootScope", "$scope"];

function proprietorController($rootScope, $scope) {
    var vm = this;
}