angular.module("ClcWorldApp").factory("carService",
[
    "$http", "$q", function ($http, $q) {
        return {
            getAll: getAll,
            get: get,
            create: create,
            edit: edit,
            remove: remove
        }

        function getAll(filter) {
            var deferred = $q.defer();
            $http({
                method: "GET",
                url: clcw.apiService + clcw.carUrl,
                params: filter
            }).then(function (response) {
                deferred.resolve(response.data.result);
            }, function (response) {
                deferred.reject(response.data.validationErrors);
            });

            return deferred.promise;
        }


        function get(id) {
            var deferred = $q.defer();
            $http({
                method: "GET",
                url: clcw.apiService + clcw.carUrl + id
            }).then(function (response) {
                deferred.resolve(response.data.result);
            }, function (response) {
                deferred.reject(response.data.validationErrors);
            });
        }

        function create(car) {
            var deferred = $q.defer();
            $http({
                method: "POST",
                url: clcw.apiService + clcw.carUrl,
                data: car
            }).then(function (response) {
                deferred.resolve(response.data.result);
            }, function (response) {
                deferred.reject(response.data.validationErrors);
            });
        }

        function edit(car) {
            var deferred = $q.defer();
            $http({
                method: "PUT",
                url: clcw.apiService + clcw.carUrl,
                data: car
            }).then(function (response) {
                deferred.resolve(response.data.result);
            }, function (response) {
                deferred.reject(response.data.validationErrors);
            });
        }

        function remove(id) {
            var deferred = $q.defer();

            $http({
                method: "DELETE",
                url: clcw.apiService + clcw.carUrl + id
            }).then(function (response) {
                deferred.resolve(response.data.result);
            }, function (response) {
                deferred.reject(response.data.validationErrors);
            });

            return deferred.promise;
        }
    }
]);