﻿/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('stupigshop.products', ['stupigshop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('products', {
            url: "/products",
            templateUrl: "/app/components/products/productListView.html",
            controler: "productListController"
        }).state('product_add', {
            url: "/product_add",
            templateUrl: "/app/components/products/productAddView.html",
            controler: "productAddController"
        }).state('product_edit', {
            url: "/product_edit",
            templateUrl: "/app/components/products/productEditView.html",
            controler: "productEditController"
        });
    }
})();