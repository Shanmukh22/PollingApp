/*
Component :                             An AngularJS controller that invokes the methods defined in 'SurveyController.cs' to serve the client's requests in creating and getting the survey details.
Author:                                 Rajashekar Goud Korakoppula
Use of the component in system design:  Serves the 'create' and 'get' Survey requests of the clients 
Written and revised:                    11/22/2016
Reason for component existence:         Used for creating a survey and getting the details of required survey
*/

(function () {
    'use strict';
    //Reigstering the Controller with the Angular JS module defined for our application.
    angular
        .module('app')
        .controller('SurveyController', SurveyController);
    //Injecting the Angular JS Scope and required modules to be used for model binding between the view and the controller, making http requests etc.
    SurveyController.$inject = ['$scope', '$http', '$location', '$mdDialog', '$routeParams', '$localStorage', '$sessionStorage', '$window'];

    function SurveyController($scope, $http, $location, $mdDialog, $routeParams, $localStorage, $sessionStorage, $window) {
        $scope.title = 'Survey';
        $scope.surveyTitle = "";
        $scope.description = "";
        $scope.surveyType = "Private";
        $scope.groupNames = "";
        $scope.questions = [{ description: "", Answers: [{ description: "", count: 0 }, { description: "", count: 0 }] }]

        $scope.displayGroups = false;
        if ($sessionStorage.userLoginInfo) {
            $scope.userInfo = $sessionStorage.userLoginInfo;
        } else {
            $location.path('/login');
        }
        $scope.$watch(function () { return $sessionStorage.userLoginInfo }, function (newVal, oldVal) {
            if (oldVal !== newVal) {
                $scope.userInfo = $sessionStorage.userLoginInfo;
            }
        })
        $scope.AddQuestion = function () {

            $scope.questions.push({ description: "", Answers: [{ description: "", count: 0 }, { description: "", count: 0 }] });
            //$scope.Invalid = true;
        }

        $scope.RemoveQuestion = function () {
            $scope.questions.pop();
        }

        $scope.Invalid = true;
        $scope.AddOption = function (question) {


            if (question.Answers == null) {
                (question.Answers = []).push({ description: "", count: 0 });
            }
            else {
                question.Answers.push({ description: "", count: 0 });
                //$scope.Invalid = false;
            }

        }
        $scope.RemoveOption = function (question) {

            question.Answers.pop();

        }
        $scope.select = [];
        $scope.selectedGroups = [];
        $scope.groups = [];
        //$scope.LoadGroups = function () {

        //    $scope.groups = [{ Id: "1", Name: "DSE" }, { Id: "3", Name: "CS" }];
        //}

        $scope.TypeChanged = function () {
            $scope.select = [];
        }

        $scope.LoadGroups = function () {
            $http.get('WhatsUrSay/api/Groups/GetGroups')
            .then(function success(response) {
                var data = response.data;
                for (var i = 0; i < data.length; i++) {

                    $scope.groups.push({ Id: data[i].id, Name: data[i].name })

                }

                //Also getting the Survey details 

                /* $http.get('api/Survey/GetAllSurveys')
             .then(function success(response) {
                 $scope.surveysFromDb = response.data;
             }
             , function error(response) {
                 $location.path('/error');
             });*/
            }
            , function error(response) {
                $location.path('/error');
            });
        }



        $scope.CreateSurvey = function ($event) {
            var alert_text = "";
            $event.preventDefault();
            /*for (var p in $scope.surveysFromDb) {
                if ($scope.surveysFromDb[p].heading == $scope.surveyTitle) {
                    $mdDialog.show(
                    $mdDialog.alert()
                      .parent(angular.element(document.querySelector('#popupContainer')))
                      .clickOutsideToClose(true)
                      .title('Survey Name already exists. Please enter a new name')
                      .textContent(alert_text)
                      .ariaLabel('alert')
                      .ok('Ok')
                  );
                    return;
                }
            }*/
            if ($scope.surveyType == "Public") {
                $scope.surveyType = 1;
            } else if ($scope.surveyType == "Private") {
                $scope.surveyType = 2;

                for (var i = 0; i < $scope.select.length; i++) {
                    console.log($scope.select[i]);
                    $scope.selectedGroups.push({ id: "", activity_id: "", group_id: $scope.select[i], Activity: "", Group: "" })

                }
            }
            var activity = { heading: $scope.surveyTitle, description: $scope.description, type: $scope.surveyType, category: 2, createdby: $scope.userInfo.userId, Questions: $scope.questions, Activity_Group: $scope.selectedGroups };
            $scope.LoginStatus = $http.post('WhatsUrSay/api/Survey/PostSurvey', activity).then(function success(response) {
                console.log("success");
                //alert(response);
                var alert_text = "";
                if (response.data) {
                    alert_text = "Survey is created Successfully";
                    $mdDialog.show(
                    $mdDialog.alert()
                      .parent(angular.element(document.querySelector('#popupContainer')))
                      .clickOutsideToClose(true)
                      .title('Survey Creation')
                      .textContent(alert_text)
                      .ariaLabel('alert')
                      .ok('Ok')
                  );
                    $location.path('/dashboard');
                } else {
                    alert_text = "Survey creation failed";
                    $mdDialog.show(
                    $mdDialog.alert()
                      .parent(angular.element(document.querySelector('#popupContainer')))
                      .clickOutsideToClose(true)
                      .title('Survey Creation')
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
    }
}())