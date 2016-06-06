(function (app) {
    app.controller('productCategoryAddController', productCategoryAddController);
    productCategoryAddController.$inject['$scope', 'APIService', 'notificationService', '$state']
    function productCategoryAddController($scope, APIService, notificationService, $state) {
        $scope.productCategory = {
            CreatedDate: new Date(),
            Status: true
        }
        $scope.AddProductCategory = AddProductCategory;

        function AddProductCategory() {
            APIService.post('api/productcategory/create', $scope.productCategory, function (result) {
                notificationService.displaySuccess(result.data.Name + " added");
                $state.go('product_categories');
            }, function (error) {
                notificationService.displayError('Add new product category failed');
            });
        }

        $scope.parentCategories = [];

        function loadparentCategories() {
            APIService.get('api/productcategory/getallparents', null, function (result) {
                $scope.parentCategories = result.data;
            }, function () {
                console.log('Cannot get list parent');
            });
        }

        loadparentCategories();
    }
})(angular.module('stupigshop.product_categories'));