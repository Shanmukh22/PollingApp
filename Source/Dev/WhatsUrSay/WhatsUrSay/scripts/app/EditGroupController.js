(function () {
    'use strict';
    //Reigstering the Controller with the Angular JS module defined for our application.
    angular
        .module('app')
        .controller('EditGroupController', EditGroupController);
    //Injecting the Angular JS Scope and required modules to be used for model binding between the view and the controller, making http requests etc.
    EditGroupController.$inject = ['$scope', '$http', '$location', '$mdDialog', '$routeParams', '$localStorage', '$sessionStorage', '$window'];

    function EditGroupController($scope, $http, $location, $mdDialog, $routeParams, $localStorage, $sessionStorage, $window) {
        activate();
        function activate() {
            if ($sessionStorage.userLoginInfo) {
                $scope.userInfo = $sessionStorage.userLoginInfo;
            } else {
                $location.path('/login');
            }
        }
        $scope.$watch(function () { return $sessionStorage.userLoginInfo }, function (newVal, oldVal) {
            if (oldVal !== newVal) {
                $scope.userInfo = $sessionStorage.userLoginInfo;
            }
        })

        $scope.ConvertToObject= function ()
        {
            $scope.UsersNotinGroup = [];
            $scope.addedUsers = [];
             $scope.selected = angular.fromJson($scope.selectedGroup);
             $scope.deletedUsers = [];
             for (var i = 0; i < $scope.users.length;i++)
             { var isPresent=false;
                 for (var j = 0; j < $scope.selected.User_Group.length;j++)
                 {
                     if ($scope.users[i].id == $scope.selected.User_Group[j].user_id)
                     {
                         isPresent = true;
                         break;
                     }
                 }

                 if (isPresent == false) {
                     $scope.UsersNotinGroup.push($scope.users[i]);
                 }

             }

        }
       

        $scope.LoadGroups=function()
        {
            $scope.title = 'Select Group to Edit';
            $scope.groupTitle = "";
            $scope.userId = $routeParams.id;
            $scope.groups = []
            //$scope.selectedGroup;
            $scope.deletedUsers = [];
            $scope.addedUsers = [];
            $scope.users = [];
            $scope.UsersNotinGroup = [];
            $scope.selected = new Object;
            $scope.GetGroupsStatus = $http.get('WhatsUrSay/api/Groups/GetGroupsByCreatedUserId/?userId=' + $scope.userId)
            .then(function success(response)
            {

                $scope.groups = response.data;

            
             }
           ,function error(response) {
               $location.path('/error');
           });

            $scope.GetUsersStatus = $http.get('WhatsUrSay/api/User/GetUsers')
            .then(function success(response) {

                $scope.users = response.data;


            }
           , function error(response) {
               $location.path('/error');
           });

        }



        //Purpose: To proces the create poll request of clients of our application.
        //Input: $event to prevent the default JS behaviour of the link button.
        //Output: An alert showing the 'create poll' status .

        //Hardcoded the following data entries: pollType, category, createdby
        $scope.UpdateGroup = function ($event) {
            $event.preventDefault();
          

            var deleteUserGroupList = { UserIdsDelete: $scope.deletedUsers, UserIdsAdd: $scope.addedUsers, GroupId: $scope.selected.id }
            $scope.CreateGroupStatus = $http.post('WhatsUrSay/api/Groups/PostDeleteAddUsersInGroup', deleteUserGroupList).then(function success(response) {
               
                var alert_text = "";
                if (response.status == 200) {
                    alert_text = "Users Updated Sucessfully";
                } else {
                    alert_text = "Users Updation failed ";
                }
                $mdDialog.show(
                    $mdDialog.alert()
                      .parent(angular.element(document.querySelector('#popupContainer')))
                      .clickOutsideToClose(true)
                      .title('Group Edit')
                      .textContent(alert_text)
                      .ariaLabel('alert')
                      .ok('Ok')
                  );
                $location.path("/dashboard");
            }, function error(response) {
                alert(response);
                $location.path('/error');
            });
        };
    }
})();
