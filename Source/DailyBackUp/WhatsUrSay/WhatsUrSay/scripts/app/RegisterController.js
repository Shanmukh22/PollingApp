(function () {
    'use strict';

    angular
        .module('app')
        .controller('RegisterController', RegisterController);
    RegisterController.$inject = ['$scope', '$http', '$location', '$mdDialog'];

    function RegisterController($scope, $http, $location, $mdDialog) {
        $scope.title = 'Register';
        $scope.user = {
            emailId: "", password: "", confirmPassword: "", name: ""
        };
        activate();

        function activate() {

        }
        $scope.Register = function ($event) {
            $event.preventDefault();
            if ($scope.user.password != $scope.user.confirmPassword) {
                $mdDialog.show(
                    $mdDialog.alert()
                      .parent(angular.element(document.querySelector('#popupContainer')))
                      .clickOutsideToClose(true)
                      .title('Error')
                      .textContent('Passwords should match.')
                      .ariaLabel('alert')
                      .ok('Ok')

                  );
                return;
            }
            var user = { emailId: $scope.user.emailId, password: $scope.user.password, name: $scope.user.name };
            $scope.LoginStatus = $http.post('WhatsUrSay/api/Login/AddUser', user).then(function success(response) {
                var alert_text = "";
                if (response.data) {
                    alert_text = "Registration Successfull, Please login.";
                    $mdDialog.show(
                    $mdDialog.alert()
                      .parent(angular.element(document.querySelector('#popupContainer')))
                      .clickOutsideToClose(true)
                      .title('Registration')
                      .textContent(alert_text)
                      .ariaLabel('alert')
                      .ok('Ok')

                  );
                    $location.path('/login');
                } else {
                    alert_text = "An error occurred while registration please try again later.";
                    $mdDialog.show(
                    $mdDialog.alert()
                      .parent(angular.element(document.querySelector('#popupContainer')))
                      .clickOutsideToClose(true)
                      .title('Registration')
                      .textContent(alert_text)
                      .ariaLabel('alert')
                      .ok('Ok')

                  );
                }


            }, function error(response) {
                $location.path('/Error');
            });

        }

    }
})();
