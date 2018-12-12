

sqlQueryModule.controller("homePageController", function ($scope, $http, $window, bootstrappedData) {
    $scope.list = bootstrappedData.list;
    $scope.tableDisplay = $scope.list[0];
    $scope.filteredList = $scope.list;

    $scope.GetData = function () {
        var uid = window.location.href.split('?')[1].split('=')[1];
        var url = '/Home/GetData?uid=' + uid;
        var promise = $scope.executeQuery(url);
        promise.then(function (myList) {
            console.log("list = " + myList);
            $scope.doFiltering(myList);
        });
    };

    $scope.executeQuery = function (url) {
        var arr = $http.get(url).then(function (result) {
            $scope.tableDisplay = result.data[0];
            $scope.list = result.data;
            return result.data;
        });
        return arr;
    };

    $scope.doFiltering = function (myList) {
        $scope.filteredList = [];
        $scope.currentPage = 1;
        $scope.numPerPage = 10;
        $scope.maxSize = 5;
        $scope.tableSize = $scope.list.length;

        $scope.$watch("currentPage + numPerPage", function () {
            var begin = ($scope.currentPage - 1) * $scope.numPerPage;
            var end = begin + $scope.numPerPage;
            $scope.filteredList = $scope.list.slice(begin, end);
        });
    };

    $scope.redirect = function (location, pid) {
        var uid = window.location.href.split('?')[1].split('=')[1];

        if (location === 'compare') {
            $window.location.href = '/ComparePatient?uid=' + uid + '&pid=' + pid;
        } else if (location === 'edit') {
            $window.location.href = '/EditPatient?uid=' + uid + '&pid=' + pid;
        } else if (location === 'add') {
            $window.location.href = '/AddPatient?uid=' + uid + '&pid=' + pid;
        } else if (location === 'show') {
            $window.location.href = '/PatientInfo?uid=' + uid + '&pid=' + pid;
        } else if (location === 'delete') {
            alert("Deleting patient with ID number " + pid);
        }
    };

});