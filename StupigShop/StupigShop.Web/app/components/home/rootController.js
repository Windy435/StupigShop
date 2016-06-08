/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function (app) {
    app.controller('rootController', rootController);
    app.$inject['$scope', '$state'];
    function rootController($scope, $state) {
        $scope.logout = function () {
            $state.go('login');
        }
    }
})(angular.module("stupigshop"));

//anonymous function