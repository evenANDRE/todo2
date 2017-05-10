var app = angular.module('myApp', ['ngRoute', 'ui.bootstrap']);

app.config(function ($routeProvider) {
    $routeProvider
        .when('/home', {
            templateUrl: 'Templates/home.html',
            controller: 'homeController'
        })
        .when('/home/:id', {
            templateUrl: 'Templates/homeUser.html',
            controller: 'homeUserController'
        })
        .when('/nyperson', {
            templateUrl: 'Templates/nyperson.html',
            controller: 'nypersonController'
        })
        .when('/rapport', {
            templateUrl: 'Templates/rapport.html',
            controller: 'rapportController'
        })
        .when('/rapport/:id', {
            templateUrl: 'Templates/rapportUser.html',
            controller: 'rapportUserController'
        })
        .otherwise({
            redirectTo: '/home'
        });
});

//denne settingen måtte gjøres på nyere angular for at routingen skulle fungere skikkelig
app.config(['$locationProvider', function ($locationProvider) {
    $locationProvider.hashPrefix('');
}]);

