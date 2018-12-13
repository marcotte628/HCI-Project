
sqlQueryModule.controller("comparePatientController", function ($scope, $http, $window) {


    $scope.redirect = function (location) {

        var uid = window.location.href.split('?')[1].split('=')[1].substring(0,1);
        var pid = window.location.href.split('?')[1].split('=')[2];
        if (location === 'home') {
            $window.location.href = '/Home?uid=' + uid;
        } else if(location === 'patient') {
            $window.location.href = '/PatientInfo?uid=' + uid + '&pid=' + pid;
        } 
    };

    $scope.getPatientData = function () {
        var pid = window.location.href.split('?')[1].split('=')[2];

        // api call to get patient data with id pid
        var url = '/PatientInfo/GetData?pid=' + pid;
        var promise = $scope.executeQuery(url);
        promise.then(function (myList) {
        });
    };

    $scope.executeQuery = function (url) {
        var arr = $http.get(url).then(function (result) {
            var parts = result.data.split('\'');
            $scope.name = parts[5];
            $scope.DOB = parts[7];
            $scope.lv = parts[9];
            $scope.height = parseInt(parts[11]);
            $scope.weight = parseInt(parts[13]);
            $scope.notes = parts[15];
            $scope.age = 2018 - parseInt($scope.DOB.split('/')[2]);
            return result.data;
        });
        return arr;
    };

    $scope.getPatientData();


});