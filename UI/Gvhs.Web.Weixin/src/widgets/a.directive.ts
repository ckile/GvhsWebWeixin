import angular = require("angular");

angular.module("gvApp.widgets")
    .directive("a", aDirective);

aDirective.$inject = [];

function aDirective() : angular.IDirectiveFactory {
    return function (...args) {
        return {
            restrict: 'E',
            link: function (scope: angular.IScope, elem: angular.IAugmentedJQuery, attrs) {
                if (attrs.ngClick || attrs.href === '' || attrs.href === '#') {
                    elem.on('click', function (e) {
                        e.preventDefault();
                    });
                }
            }
        };
    }

}