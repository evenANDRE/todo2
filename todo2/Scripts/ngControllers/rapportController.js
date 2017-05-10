//henter alle brukere og lister dem ut i view
//laster inn rapport.html

(function () {
    angular
        .module("myApp")
        .controller("rapportController", function ($scope, $http, $location) {

            //henter alle personer fra api
            $http.get("api/persons").then(function (response) {
                $scope.data = response.data;
            });

            //router folk inn til rapport for en bruker
            $scope.todoRaport = function (personId) {
                $location.path("/rapport/" + personId);
            };

        });
})();