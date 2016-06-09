/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function (app) {
    app.controller('productListController', productListController);

    productListController.$inject = ['$scope', 'APIService', 'notificationService', '$ngBootbox', '$filter']

    function productListController($scope, APIService, notificationService, $ngBootbox, $filter) {
        $scope.products = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.totalCount = 0;
        $scope.keyword = '';
        $scope.getProducts = getProducts;

        $scope.search = search;

        $scope.deleteProductMultiple = deleteProductMultiple;

        function deleteProductMultiple() {
            var listId = [];
            $.each($scope.selected, function (i, item) {
                listId.push(item.ID);
            });
            var config = {
                params: {
                    checkedProducts: JSON.stringify(listId)
                }
            }
            APIService.del('api/product/deletemulti', config, function (result) {
                notificationService.displaySuccess("Delete success " + result.data + " records");
                search();
            }, function (error) {
                notificationService.displayError("Delete failure");
            });
        }

        $scope.selectAll = selectAll;

        $scope.isAll = false;
        function selectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.products, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.products, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        $scope.$watch("products", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);

        $scope.deleteProduct = deleteProduct;

        function deleteProduct(id) {
            $ngBootbox.confirm('Are you sure want to delete?').then(function () {
                var config = {
                    params: {
                        id: id,
                    }
                };
                APIService.del('api/product/delete', config, function () {
                    notificationService.displaySuccess('Delete success');
                    search();
                }, function () {
                    notificationService.displayError('Delete failure');
                })
            });
        }

        function search() {
            getProducts();
        }

        function getProducts(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 20
                }
            }
            APIService.get('/api/product/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning("No records were found");
                }
                else {
                    notificationService.displaySuccess(result.data.TotalCount + " records were found");
                }
                $scope.products = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                notificationService.displayError("Cannot load product");
            });
        }

       $scope.getProducts();
    }
})(angular.module("stupigshop.products"));