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
                url: clcw.apiService + "api/v1/cars",
                params: filter
            }).success(function (data) {
                deferred.resolve(data.result);
            }).error(function (data) {
                deferred.reject(data.validationErrors);
            });

            return deferred.promise;
        }

        function get(id) {
            var deferred = $q.defer();
            $http({
                method: "GET",
                url: clcw.apiService + "api/v1/cars" + id
            }).success(function (data) {
                deferred.resolve(data.result);
            }).error(function (data) {
                deferred.reject(data.validationErrors);
            });
        }

        function create(car) {
            var deferred = $q.defer();
            $http({
                method: "POST",
                url: clcw.apiService + "api/v1/cars",
                data: car
            }).success(function (data) {
                deferred.resolve(data.result);
            }).error(function (data) {
                deferred.reject(data.validationErrors);
            });
        }

        function edit(car) {
            var deferred = $q.defer();
            $http({
                method: "PUT",
                url: clcw.apiService + "api/v1/cars",
                data: car
            }).success(function (data) {
                deferred.resolve(data.result);
            }).error(function (data) {
                deferred.reject(data.validationErrors);
            });
        }

        function remove(id) {
            var deferred = $q.defer();

            $http({
                method: "DELETE",
                url: hf.config.serviceBase + "api/v1/car/" + id
            }).success(function (data) {
                deferred.resolve(data.result);
            }).error(function (data) {
                deferred.reject(data.validationErrors);
            });

            return deferred.promise;
        }
    }
]);