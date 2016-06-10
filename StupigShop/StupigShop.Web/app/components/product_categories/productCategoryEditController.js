(function (app) {
    app.controller('productCategoryEditController', productCategoryEditController);
    productCategoryEditController.$inject = ['$scope', 'APIService', 'notificationService', '$state', '$stateParams', 'commonService']
    function productCategoryEditController($scope, APIService, notificationService, $state, $stateParams, commonService) {
        $scope.productCategory = {
            CreatedDate: new Date(),
            Status: true
        }
        $scope.UpdateProductCategory = UpdateProductCategory;

        function UpdateProductCategory() {
            APIService.put('api/productcategory/update', $scope.productCategory, function (result) {
                notificationService.displaySuccess(result.data.Name + " updated");
                $state.go('product_categories');
            }, function (error) {
                notificationService.displayError('Update product category failed');
            });
        }

        function loadProductCategoryDetail() {
            APIService.get('/api/productcategory/getbyid/' + $stateParams.id, null, function (result) {
                $scope.productCategory = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        $scope.parentCategories = [];

        function loadparentCategories() {
            APIService.get('api/productcategory/getallparents', null, function (result) {
                $scope.parentCategories = result.data;
            }, function (error) {
                console.log('Cannot get list parent');
            });
        }

        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.productCategory.Alias = commonService.getSeoTitle($scope.productCategory.Name);
        }

        $scope.chooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.productCategory.Image = fileUrl;
                });
            }

            finder.popup();
            //            console.log($scope.product.Image);

        }


        loadProductCategoryDetail();
        loadparentCategories();
    }
})(angular.module('stupigshop.product_categories'));