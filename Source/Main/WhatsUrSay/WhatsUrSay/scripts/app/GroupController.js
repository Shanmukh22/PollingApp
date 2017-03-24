(function () {
    'use strict';
    //Reigstering the Controller with the Angular JS module defined for our application.
    angular
        .module('app')
        .controller('GroupController', GroupController);
    //Injecting the Angular JS Scope and required modules to be used for model binding between the view and the controller, making http requests etc.
    GroupController.$inject = ['$scope', '$http', '$location', '$mdDialog', '$localStorage', '$sessionStorage', '$window'];

    function GroupController($scope, $http, $location, $mdDialog, $localStorage, $sessionStorage, $window, $filter) {
        $scope.title = 'Group';
        $scope.groupTitle = "";
        $scope.userDetails = "";
        $scope.groups_details
        activate();

        function activate() {
            if ($sessionStorage.userLoginInfo) {
                $scope.userInfo = $sessionStorage.userLoginInfo;
            } else {
                $location.path('/login');
            }

        }

        $scope.members = [{ emailId: "" }];

        $scope.AddMember = function (member) {
            // alert("inside AddMember function");
            if (member == undefined) {
                $scope.members.push({});
            }
        }

        $scope.RemoveMember = function (member) {
            // alert("inside AddMember function");
            $scope.members.pop();
        }

        $scope.select = [];

        //Purpose: To proces the create poll request of clients of our application.
        //Input: $event to prevent the default JS behaviour of the link button.
        //Output: An alert showing the 'create poll' status .

        //Hardcoded the following data entries: pollType, category, createdby
        $scope.CreateGroup = function ($event) {
            var alert_text = "";
            $event.preventDefault();
            //alert("Inside createGroup");
            /*if ($scope.groups_details.indexOf($scope.groupTitle)>=0) {
                alert("Group name exists");
            }
            else {
                alert("Group name doesn't exist");
            }*/
            /* for (var grp in $scope.groups_details) {
                 if ($scope.groups_details[grp].name == $scope.groupTitle) {
                     $mdDialog.show(
                     $mdDialog.alert()
                       .parent(angular.element(document.querySelector('#popupContainer')))
                       .clickOutsideToClose(true)
                       .title('Group Name already exists. Please enter a new name')
                       .textContent(alert_text)
                       .ariaLabel('alert')
                       .ok('Ok')
                   );
                     return;
                 }
             }*/
            $scope.uL = [];
            var Group = { name: $scope.groupTitle, createdby: $scope.userInfo.userId };
            for (var i = 0; i < $scope.select.length; i++) {
                $scope.uL.push({ emailId: $scope.select[i] });
            }
            var groupDetails = { group: Group, UserList: $scope.uL };
            $scope.CreateGroupStatus = $http.post('WhatsUrSay/api/Groups/PostGroup', groupDetails).then(function success(response) {
                //alert(response);
                var alert_text = "";
                if (response.data) {
                    alert_text = "Group is created Successfully";
                    $mdDialog.show(
                    $mdDialog.alert()
                      .parent(angular.element(document.querySelector('#popupContainer')))
                      .clickOutsideToClose(true)
                      .title('Group Creation')
                      .textContent(alert_text)
                      .ariaLabel('alert')
                      .ok('Ok')
                  );
                    $location.path('/dashboard');
                } else {
                    alert_text = "Group creation failed";
                    $mdDialog.show(
                    $mdDialog.alert()
                      .parent(angular.element(document.querySelector('#popupContainer')))
                      .clickOutsideToClose(true)
                      .title('Group Creation')
                      .textContent(alert_text)
                      .ariaLabel('alert')
                      .ok('Ok')
                  );
                }


            }, function error(response) {
                alert(response);
                $location.path('/error');
            });
        };

        $scope.LoadMembers = function () {
            $http.get('WhatsUrSay/api/User/GetUsers').then(function success(response) {
                //alert("Load Members GroupController");
                $scope.userDetails = response.data;
            }, function error(response) {
                alert(response);
                $location.path('/error');
            });

            /* $http.get('api/Groups/GetGroups').then(function success(response) {
                 $scope.groups_details = response.data;
             }, function error(response) {
                 alert(response);
                 $location.path('/error');
             });*/
        }
    }
})();
