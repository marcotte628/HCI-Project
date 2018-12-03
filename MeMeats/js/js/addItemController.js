
sqlQueryModule.controller("addItemController", function ($scope, $http, $window, $location) {

    $scope.init = function () {
        var uid = window.location.href.split('?')[1].split('=')[1];

        $scope.farm = result[0].Name;
        $scope.cut = result[0].Email;
        $scope.location = result[0].Password;
        $scope.amount = result[0].Username;
        $scope.price = result[0].Name;
    }

    $scope.save = function () {
        var url = '/AddItem/SaveNewItem?uid=' + uid + '&cut=' + $scope.cut + '&loc=' + $scope.location + '&amt=' + $scope.amount + '&price=' + $scope.price;
        var promise = $scope.executeQuery(url);
        promise.then(function (result) {
            console.log("success");
            console.log(result);
            if (result.length === 0) {
                alert("Server Error. Could not load profile information.");
            } else {

            }
        });
    }

    $scope.cancel = function () {

    }

    $scope.executeQuery = function (url) {
        var arr = $http.get(url).then(function (result) {
            $scope.tableDisplay = result.data[0];
            $scope.list = result.data;
            return result.data;
        });
        return arr;
    }


    $scope.init();
});