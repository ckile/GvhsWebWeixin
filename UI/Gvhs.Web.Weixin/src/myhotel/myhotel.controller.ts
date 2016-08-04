import angular = require("angular");

angular.module("gvApp.modules")
    .controller("myhotelController", myhotelController);


myhotelController.$inject = ["$rootScope", "$scope", "$modal", "$state"];

function myhotelController($rootScope, $scope, $modal, $state) {
    var vm = this;
    vm.myReservation = myReservation;

    active();

    function active() { }

    function myReservation() {
        $state.go("app.myreservation");
    }
}