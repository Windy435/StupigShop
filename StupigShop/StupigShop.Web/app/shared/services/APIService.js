/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function (app) {
    app.service('APIService', APIService);

    APIService.$inject = ['$http'];
    function APIService($http) {
        return {
            get:get
        }

        function get(url, params, success, failure) {
            $http.get(url, params).then(function (result) {
                success(result);
            }, function (error) {
                failure(error);
            });
        }
    }
})(angular.module('stupigshop.common'));