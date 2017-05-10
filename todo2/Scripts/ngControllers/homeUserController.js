//controller som legger inn nye punkter på listen til en bruker
//laster inn homeUser.html

(function () {
    angular
        .module("myApp")
        .controller("homeUserController", function ($scope, $http, $location, $routeParams) {
            var id = $routeParams.id;

            $http.get("api/persons/" + id).then(function (response) {
                $scope.navn = response.data.navn;
            });

            $scope.show = true;

            $scope.closeAlert = function (index) {
                $scope.show = false;
            };

            $scope.tittel = "";
            $scope.beskrivelse = "";
            $scope.produkt = "";
            $scope.type = "";
            $scope.items = [];

            $scope.addItem = function () {
                
                var item = { personId: id, Tittel: $scope.tittel, Beskrivelse: $scope.beskrivelse, Produkt: $scope.produkt, Type: $scope.type };
                

                $http.post(
                    "person/item",
                    JSON.stringify(item),
                    {
                        headers: {
                            'Content-Type': 'application/json'
                        }
                    }).then(function (response) {
                        $scope.items.push($scope.tittel);
                        $scope.tittel = "";
                        $scope.beskrivelse = "";
                        $scope.produkt = "";
                        $scope.type = "";
                    });
                

                
            };
           

        });
})();