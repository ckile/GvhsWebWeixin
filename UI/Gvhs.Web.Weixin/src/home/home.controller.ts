import angular = require("angular");

angular
    .module("gvApp.layout")
    .controller("homeController", homeController);

homeController.$inject = ["$state", "setting"];

function homeController($state: angular.ui.IStateService, setting) {
    var vm = this;
    vm.booking = booking;
    vm.control = control;
    vm.roomService = roomService;
    vm.myhotel = myhotel;
    vm.manager = manager;
    vm.proprietor = proprietor;
    active();

    function active() { }

    function booking() {
        $state.go("app.booking");
    }

    function control() {
        $state.go("app.control");
    }

    function roomService() {
        $state.go("app.roomservice");
    }

    function myhotel() {
        $state.go("app.myhotel");
    }

    function manager() {
        $state.go("app.manager");
    }

    function proprietor() {
        $state.go("app.proprietor");
    }

}