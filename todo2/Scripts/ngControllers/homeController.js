//default siden til appen, laster inn en liste med brukere som en kan velge for å legge inn todo items
//laster inn home.html

(function () {
    angular
        .module("myApp")
        .controller("homeController",function ($scope, $http, $location) {

            //hent data fra api
            $http.get("api/persons").then(function (response) {
                $scope.data = response.data;
            });

            //åpner opp todolisten for denne brukeren i en ny url
            $scope.openTodoList = function (id) {
                $location.path("/home/" + id);
            };
        });
})();