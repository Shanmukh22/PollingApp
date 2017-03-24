/*
Component :                             An AngularJS controller that invokes the methods defined in 'HomeController.cs' to serve the client requests and the Home Page.
Author:                                 Abhinav Bhandaram
Use of the component in system design:  Serves the Login requests of the clients 
Written and revised:                    11/5/2016
Reason for component existence:         To serve Home page and client side functions related to Home.html view.
*/
(function () {
    'use strict';
    //Reigstering the Controller with the Angular JS module defined for our application.
    angular
            .module('app')
            .controller('HomeController', HomeController);
    //Injecting the Angular JS Scope to be used for model binding between the view and the controller.
    HomeController.$inject = ['$scope','$localStorage','$sessionStorage','$window','$location'];

    function HomeController($scope, $localStorage, $sessionStorage, $window,$location) {
        $scope.title = 'Home';
        activate();
        function activate() {
            if ($sessionStorage.userLoginInfo) {
                $scope.userInfo = $sessionStorage.userLoginInfo;
            }
        }
        $scope.$watch(function () { return $sessionStorage.userLoginInfo }, function (newVal,oldVal) {
            if (oldVal !== newVal) {
                $scope.userInfo = $sessionStorage.userLoginInfo;
            }
        })
        $scope.LogOut = function () {
            $sessionStorage.userLoginInfo = $scope.userInfo = null;
            $location.path("/");
        }
    }
})();
