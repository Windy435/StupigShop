/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function (app) {
    app.controller('productCategoryListController', productCategoryListController);

    productCategoryListController.$inject['$scope', 'APIService']

    function productCategoryListController($scope, APIService) {
        $scope.productCatergories = [];

        $scope.getProductCategories = getProductCategories;

        function getProductCategories() {
            APIService.get('/api/productcategory/getall', null, function (result) {
                $scope.productCatergories = result.data;
            }, function () {
                console.log('Load productcategory failed');
            });
        }

        $scope.getProductCategories();
    }
})(angular.module("stupigshop.product_categories"));