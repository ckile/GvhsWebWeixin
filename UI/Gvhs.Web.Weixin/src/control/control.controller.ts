import angular = require("angular");

angular.module("gvApp.modules")
    .controller("controlController", controlController);

controlController.$inject = [];

function controlController() {
    var vm = this;

    active();

    function active() { }



}