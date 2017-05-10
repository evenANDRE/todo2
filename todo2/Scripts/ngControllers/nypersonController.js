//laster inn skjema for å registrere ny bruker, og lagrer info i DB
(function () {
    angular
        .module("myApp")
        .controller("nypersonController", function ($scope, $http, $location) {

                $scope.navn = "";
                $scope.epost = "";
                $scope.tlfnr = "";  

                $scope.users = [];

                $scope.addUser = function () {
                    var p = { navn: $scope.navn, epost: $scope.epost, tlfnr: $scope.tlfnr };

                    //sett inn data
                    $http.post("person/register", JSON.stringify(p),
                        {
                            headers: { 'Content-Type': 'application/json' }
                        }).then(function (response) {
                            console.log(response.data);
                            $scope.users.push({ navn: $scope.navn, id: response.data});
                            $scope.navn = "";
                            $scope.epost = "";
                            $scope.tlfnr = "";
                            
                        });


                };
        });
})();