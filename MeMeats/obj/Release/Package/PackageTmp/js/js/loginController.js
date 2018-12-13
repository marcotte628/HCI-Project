
sqlQueryModule.controller("loginController", function ($scope, $http, $window) {

    $scope.login = function () {
        if ($scope.username === $scope.password) {
            $window.location.href = '/Home?uid=1';
        } else {
            alert("The Username must match the Password");
        }
        

    };

    $scope.register = function () {
        $window.location.href = '/Register';
    };
    

});