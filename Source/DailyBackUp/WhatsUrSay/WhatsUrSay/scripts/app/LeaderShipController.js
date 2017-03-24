/*
Component :                             An AngularJS controller that invokes the methods defined in 'LoginController.cs' to serve the client login requests  and the Login Page.
Author:                                 Abhinav Bhandaram
Use of the component in system design:  Serves the Login requests of the clients 
Written and revised:                    11/5/2016
Reason for component existence:         To serve Login page and client side functions related to Login.html view.
*/
(function () {
    'use strict';
    //Reigstering the Controller with the Angular JS module defined for our application.
    angular
        .module('app')
        .controller('LeaderShipController', LeaderShipController);
    //Injecting the Angular JS Scope and required modules to be used for model binding between the view and the controller, making http requests etc.
    LeaderShipController.$inject = ['$scope', '$http', '$location', '$mdDialog', '$localStorage', '$sessionStorage', '$window'];

    function LeaderShipController($scope, $http, $location, $mdDialog, $localStorage, $sessionStorage, $window) {
        $scope.title = 'Leader Ship';
        $scope.description = "";
        activate();

        function activate() {
            if ($sessionStorage.userLoginInfo) {
                $scope.userInfo = $sessionStorage.userLoginInfo;
            }


        }
        $scope.$watch(function () { return $sessionStorage.userLoginInfo }, function (newVal, oldVal) {
            if (oldVal !== newVal) {
                $scope.userInfo = $sessionStorage.userLoginInfo;
            }
        })
        //Purpose: To proces the login requests of clients into our application.
        //Input: $event to prevent the default JS behaviour of the link button.
        //Output: An alert showing the login status of the user.
        $scope.SubmitRequest = function ($event) {
            $event.preventDefault();
            var request = { userId: $scope.userInfo.userId, description: $scope.description }
            $scope.LoginStatus = $http.post('WhatsUrSay/api/LeaderShip/RequestGroupLeaderShip', request).then(function success(response) {
                var alert_text = "";
                if (response.data==true) {
                    alert_text = "Request Submitted Successfully.";
                    $mdDialog.show(
                    $mdDialog.alert()
                      .parent(angular.element(document.querySelector('#popupContainer')))
                      .clickOutsideToClose(true)
                      .title('Request Group Leadership')
                      .textContent(alert_text)
                      .ariaLabel('alert')
                      .ok('Ok')

                  );
                    $location.path('/dashboard');
                } else if(response.data==false){
                    alert_text = "Request not submitted.";
                    $mdDialog.show(
                    $mdDialog.alert()
                      .parent(angular.element(document.querySelector('#popupContainer')))
                      .clickOutsideToClose(true)
                      .title('Request Group Leadership')
                      .textContent(alert_text)
                      .ariaLabel('alert')
                      .ok('Ok')

                  );
                } else {
                    alert_text = "You have already submitted a request for group leadership.";
                    $mdDialog.show(
                    $mdDialog.alert()
                      .parent(angular.element(document.querySelector('#popupContainer')))
                      .clickOutsideToClose(true)
                      .title('Request Group Leadership')
                      .textContent(alert_text)
                      .ariaLabel('alert')
                      .ok('Ok')
                      );
                    $location.path('/dashboard');
                }


            }, function error(response) {
                $location.path('/error');
            });

        }

    }
})();
