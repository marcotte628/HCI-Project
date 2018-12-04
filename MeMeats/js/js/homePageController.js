

sqlQueryModule.controller("homePageController", function ($scope, $http, $window, bootstrappedData) {
    $scope.list = bootstrappedData.list;
    $scope.tableDisplay = $scope.list[0];
    $scope.filteredList = $scope.list;

    $scope.GetData = function (type) {
        
    $scope.searchButtonText = "Loading Results";
        var url = '/Home/GetData?info=' + info;
        var promise = $scope.executeQuery(url);
        promise.then(function (myList) {
            console.log("list = " + myList);
            $scope.doFiltering(myList);
        });
    }

    $scope.executeQuery = function (url) {
        var arr = $http.get(url).then(function (result) {
            $scope.tableDisplay = result.data[0];
            $scope.list = result.data;
            return result.data;
        });
        return arr;
    }

    $scope.doFiltering = function (myList) {
        $scope.filteredList = [];
        $scope.currentPage = 1;
        $scope.numPerPage = 10;
        $scope.maxSize = 5;
        $scope.tableSize = $scope.list.length;

        $scope.$watch("currentPage + numPerPage", function () {
            var begin = (($scope.currentPage - 1) * $scope.numPerPage)
            var end = begin + $scope.numPerPage;
            $scope.filteredList = $scope.list.slice(begin, end);
        });
    }

    $scope.redirect = function (location) {
        var uid = window.location.href.split('?')[1].split('=')[1];
        
        if (location === 'compare') {
            $window.location.href = '/ComparePatient?uid=' + uid;
        } else if (location === 'edit') {
            $window.location.href = '/EditPatient?uid=' + uid;
        }  else if (location === 'add') {
            $window.location.href = '/AddPatient?uid=' + uid;
        } else if (location === 'show') {
            $window.location.href = '/PatientInfo?uid=' + uid;
        } else if (location === 'delete') {
            alert("DELETE!");
        }
    }

});