/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function (app) {
    app.controller('productCategoryListController', productCategoryListController);

    productCategoryListController.$inject['$scope', 'APIService', 'notificationService', '$ngBootbox', '$filter']

    function productCategoryListController($scope, APIService, notificationService, $ngBootbox, $filter) {
        $scope.productCatergories = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.totalCount = 0;
        $scope.keyword = '';
        $scope.getProductCategories = getProductCategories;

        $scope.search = search;

        $scope.deleteProductCategoryMultiple = deleteProductCategoryMultiple;

        function deleteProductCategoryMultiple() {
            var listId = [];
            $.each($scope.selected, function (i, item) {
                listId.push(item.ID);
            });
            var config = {
                params: {
                    checkedProductCategories: JSON.stringify(listId)
                }
            }
            APIService.del('api/productcategory/deletemulti', config, function (result) {
                notificationService.displaySuccess("Delete success " + result.data + " records");
                search();
            }, function (error) {
                notificationService.displayError("Delete failure");
            });
        }

        $scope.selectAll = selectAll

        $scope.isAll = false;
        function selectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.productCatergories, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.productCatergories, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        $scope.$watch("productCatergories", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);

        $scope.deleteProductCategory = deleteProductCategory;

        function deleteProductCategory(id) {
            $ngBootbox.confirm('Are you sure want to delete?').then(function () {
                var config = {
                    params: {
                        id: id,
                    }
                };
                APIService.del('api/productcategory/delete', config, function () {
                    notificationService.displaySuccess('Delete success');
                    search();
                }, function () {
                    notificationService.displayError('Delete failure');
                })
            });
        }

        function search() {
            getProductCategories();
        }

        function getProductCategories(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 20
                }
            }
            APIService.get('/api/productcategory/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning("No records were found");
                }
                else {
                    notificationService.displaySuccess(result.data.TotalCount + " records were found");
                }
                $scope.productCatergories = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load productcategory failed');
            });
        }

        $scope.getProductCategories();
    }
})(angular.module("stupigshop.product_categories"));