/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('stupigshop', ['stupigshop.common',
                                  'stupigshop.products',
                                  'stupigshop.product_categories']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('home', {
            url: "/admin",
            templateUrl: "/app/components/home/homeView.html",
            controler: "homeController"
        });
        $urlRouterProvider.otherwise('/admin');
    }
})();