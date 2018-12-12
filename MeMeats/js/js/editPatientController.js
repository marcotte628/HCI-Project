
sqlQueryModule.controller("editPatientController", function ($scope, $http, $window) {

    $scope.getPatientData = function () {
        var pid = window.location.href.split('?')[1].split('=')[2];

        // api call to get patient data with id pid
        var url = '/EditPatient/GetData?pid=' + pid;
        var promise = $scope.executeQuery(url);
        promise.then(function (myList) {
        });
    };

    $scope.executeQuery = function (url) {
        var arr = $http.get(url).then(function (result) {
            var parts = result.data.split('\'');
            $scope.name = parts[5];
            $scope.DOB = parts[7];
            $scope.height = parseInt(parts[11]);
            $scope.weight = parseInt(parts[13]);
            $scope.notes = parts[15];
            return result.data;
        });
        return arr;
    };

    $scope.update = function () {
        // build url string
        var pid = window.location.href.split('?')[1].split('=')[2];
        var url = '/EditPatient/UpdateData?pid=' + pid + '&name=' + $scope.name + '&dob=' + $scope.DOB + '&height=' + $scope.height + '&weight=' + $scope.weight + '&note=' + $scope.notes;

        var promise = $scope.pushData(url);
        promise.then(function (stuff) {
        });
    };

    $scope.pushData = function (url) {
        var arr = $http.get(url).then(function (result) {
            var parts = result.data.split('\'');
            $scope.name = parts[5];
            $scope.DOB = parts[7];
            $scope.height = parseInt(parts[11]);
            $scope.weight = parseInt(parts[13]);
            $scope.notes = parts[15];
            return result.data;
        });
        return arr;
    };

    $scope.cancel = function () {
        $scope.getPatientData();
    };

    $scope.redirect = function (location) {
        var uid = window.location.href.split('?')[1].split('=')[1];

        if (location === 'home') {
            $window.location.href = '/Home?uid=' + uid;
        }
    };

    $scope.getPatientData();
});