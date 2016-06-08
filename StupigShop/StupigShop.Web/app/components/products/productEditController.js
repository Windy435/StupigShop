(function (app) {
    app.controller('productEditController', productEditController);
    productEditController.$inject['$scope', 'APIService', 'notificationService', '$state', '$stateParams', 'commonService']
    function productEditController($scope, APIService, notificationService, $state, $stateParams, commonService) {
        $scope.product = {
            CreatedDate: new Date(),
            Status: true
        }

        $scope.ckeditorOptions = {
            language: 'eng',
            height: '200px'
        }

        $scope.UpdateProduct = UpdateProduct;

        function UpdateProduct() {
            APIService.put('api/product/update', $scope.product, function (result) {
                notificationService.displaySuccess(result.data.Name + " updated");
                $state.go('products');
            }, function (error) {
                notificationService.displayError('Update product failed');
            });
        }

        function loadProductDetail() {
            APIService.get('/api/product/getbyid/' + $stateParams.id, null, function (result) {
                $scope.product = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
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


        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }

        loadProductDetail();
    }
})(angular.module('stupigshop.products'));