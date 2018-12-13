
sqlQueryModule.controller("addPatientController", function ($scope, $http, $window) {

    $scope.redirect = function (location) {
        var uid = window.location.href.split('?')[1].split('=')[1];
        if (location === 'home') {
            $window.location.href = '/Home?uid=' + uid;
        }
    };


    $scope.add = function () {
        // build url string
        var url = '/AddPatient/CreateData?name=' + $scope.name + '&dob=' + $scope.DOB + '&height=' + $scope.height + '&weight=' + $scope.weight + '&note=' + $scope.notes;
        var uid = window.location.href.split('?')[1].split('=')[1];
        var promise = $scope.pushData(url);
        promise.then(function (stuff) {
            // redirect to patient info page
            $window.location.href = '/PatientInfo?uid=' + uid + '&pid=' + $scope.pid;
        });
    };

    $scope.pushData = function (url) {
        var arr = $http.get(url).then(function (result) {
            var parts = result.data.split('\'');
            console.log(parts);
            $scope.pid = parts[3];
            return result.data;
        });
        return arr;
    };

    $scope.reset = function () {
        $scope.name = "";
        $scope.DOB = "";
        $scope.height = null;
        $scope.weight = null;
        $scope.notes = "";
    };

});