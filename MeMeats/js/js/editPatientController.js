﻿
sqlQueryModule.controller("editPatientController", function ($scope, $http, $window) {

    $scope.redirect = function (location) {
        var uid = window.location.href.split('?')[1].split('=')[1];

        if (location === 'home') {
            $window.location.href = '/Home?uid=' + uid;
        }
    }
});