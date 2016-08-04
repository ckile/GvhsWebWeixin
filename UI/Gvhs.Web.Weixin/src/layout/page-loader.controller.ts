import angular = require("angular");
import App =require("./apps");

angular.module("gvApp.layout")
    .controller("pageLoaderController", pageLoaderController);

pageLoaderController.$inject = ["$rootScope", "$scope"];

function pageLoaderController($scope, $rootScope) {
   App.App.initPageLoad();
}