﻿/// <reference path="../plugins/angular/angular.js" />

var myApp = angular.module('myModule', []);

myApp.controller("myController", myController);

myApp.$inject = ['$scope'];

//declare
function myController($scope){
    $scope.message = "This is my message from Controller";
}