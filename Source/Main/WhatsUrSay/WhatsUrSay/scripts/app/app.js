/*
Component :                             An AngularJS module definition that is used to define the angular js application used in the application and the different routes
                                        identified in the application.
Author:                                 Abhinav Bhandaram
Use of the component in system design:  Angular JS application definition and routes defined in the application.
Written and revised:                    11/5/2016
Reason for component existence:         Angular JS application definition..
*/
(function () {
    'use strict';
    //Defining the agularjs application 'app' and the required dependencies for the application.
    var app = angular.module('app', ['ngRoute', 'ngMaterial', 'ngStorage']);
    //Defining the routes identified in the application.
    app.config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/login', {
            templateUrl: 'WhatsUrSay/features/Login/Login.html',
            controller: 'LoginController'
        }).when('/join', {
            templateUrl: 'WhatsUrSay/features/Login/Register.html',
            controller: 'RegisterController'
        }).when('/dashboard/', {
            templateUrl: 'WhatsUrSay/features/Home/Dashboard.html',
            controller: 'DashboardController'
        }).when('/error', {
            templateUrl: 'WhatsUrSay/features/Error/Error.html',
        }).when('/createPoll', {
            templateUrl: 'WhatsUrSay/features/Poll/CreatePoll.html'
        }).when('/createSurvey', {
            templateUrl: 'WhatsUrSay/features/Survey/CreateSurvey.html'
        }).when('/createGroup', {
            templateUrl: 'WhatsUrSay/features/Group/CreateGroup.html',
        }).when('/participatePoll/:id', {
            templateUrl: 'WhatsUrSay/features/Poll/ParticipateInPoll.html',
        }).when('/participateSurvey/:id', {
            templateUrl: 'WhatsUrSay/features/Survey/ParticpateSurvey.html',
        }).when('/viewSurveyResults/:id', {
            templateUrl: 'WhatsUrSay/features/Survey/ViewSurveyResults.html',
        }).when('/viewPollResults/:id', {
            templateUrl: 'WhatsUrSay/features/Poll/ViewPollResults.html',
        }).when('/editUserGroup/:id', {
            templateUrl: 'WhatsUrSay/features/Group/EditUserGroup.html',
            controller: "EditGroupController"
        }).when('/leadershiprequest', {
            templateUrl: 'WhatsUrSay/features/Admin/RequestGroupLeaderShip.html',
            controller: "LeaderShipController"
        }).otherwise({
            templateUrl: 'WhatsUrSay/features/Home/Home.html',
            controller: 'HomeController'
        })

    }]);
    app.directive('myRefresh', function ($location, $route) {
        return function (scope, element, attrs) {
            element.bind('click', function () {
                if (element[0] && element[0].href && element[0].href === $location.absUrl()) {
                    $route.reload();
                }
            });
        }
    });

})();