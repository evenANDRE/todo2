//gjør at menyvalget blir "active"
//laster ikke inn view til siden

(function () {
    angular
        .module("myApp")
        .controller("menuController", function ($scope, $location) {
            $scope.isActive = function (viewLocation) {
                return viewLocation === $location.path();
            }; 
        });
})();