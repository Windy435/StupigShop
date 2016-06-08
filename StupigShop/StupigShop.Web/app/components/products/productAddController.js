/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function (app) {
    app.controller('productAddController', productAddController);

    productAddController.$inject['$scope', 'APIService', 'notificationService', '$state', 'commonService']
    function productAddController($scope, APIService, notificationService, $state, commonService) {

        $scope.product = {
            CreatedDate: new Date(),
            Status: true
        }

        $scope.ckeditorOptions = {
            language: 'eng',
            height: '200px'
        }

        $scope.AddProduct = AddProduct;

        function AddProduct() {
            APIService.post('api/product/create', $scope.product, function (result) {
                notificationService.displaySuccess(result.data.Name + " added");
                $state.go('products');
            }, function (error) {
                notificationService.displayError('Add new product failed');
            });
        }

        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }

        $scope.productCategories = [];
        $scope.getListProductCategory = getListProductCategory;

        function getListProductCategory() {
            APIService.get('api/productcategory/getallparents', null, function (result) {
                $scope.productCategories = result.data;
            }, function (error) {
                notificationService.displayError("Load product category failed");
            });
        }
        $scope.chooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.product.Image = fileUrl;
            }

            finder.popup();
//            console.log($scope.product.Image);

        }
        $scope.getListProductCategory();
        
    }
})(angular.module("stupigshop.products"));