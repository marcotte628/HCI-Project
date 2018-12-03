sqlQueryModule.controller("navController", function ($scope, $http, $window, $location) {


    $scope.navigate = function (location) {
        var uid = window.location.href.split('?')[1].split('=')[1];
        if (location === 'home') {
            $window.location.href = '/Home?uid=' + uid;
        } else if (location === 'logout') {
            $window.location.href = '/';
        }
    }


});