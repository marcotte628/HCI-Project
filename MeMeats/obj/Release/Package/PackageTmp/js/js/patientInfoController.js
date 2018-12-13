
sqlQueryModule.controller("patientInfoController", function ($scope, $http, $window) {

    $scope.redirect = function (location) {
        var uid = window.location.href.split('?')[1].split('=')[1].split('&')[0];
        var pid = window.location.href.split('?')[1].split('=')[2];

        if (location === 'home') {
            $window.location.href = '/Home?uid=' + uid;
        } else if (location === 'edit') {
            $window.location.href = '/EditPatient?uid=' + uid + '&pid=' + pid;
        } else if (location === 'compare') {
            $window.location.href = '/ComparePatient?uid=' + uid + '&pid=' + pid;
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
            return result.data;
        });
        return arr;
    };

    $scope.getPatientData();

});