//henter data for en bruker og lister den ut
//laster inn rapportUser.html

(function () {
    angular
        .module("myApp")
        .controller("rapportUserController", function ($scope, $http, $routeParams) {

            var id = $routeParams.id;

            //henter navnet på en person basert på id
            $http.get("api/persons/" + id).then(function (response) {
                $scope.navn = response.data.navn;
            });

            //henter alle oppgaver til en bruker
            $http.get("items/" + id).then(function (response) {
                $scope.items = response.data;
            });

            //setter default sortering
            $scope.sorterkolonne = "Number";
            
            

        });
})();