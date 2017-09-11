"use strict";
angular.module("ClcWorldApp").factory("franchiseeServices",
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
                url: clcw.apiService + franchiseeUrl,
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
                url: clcw.apiService + franchiseeUrl + id
            }).then(function (response) {
                deferred.resolve(response.data.result);
            }, function (response) {
                deferred.reject(response.data.validationErrors);
            });
        }

        function create(franchisee) {
            var deferred = $q.defer();
            $http({
                method: "POST",
                url: clcw.apiService + franchiseeUrl,
                data: franchisee
            }).then(function (response) {
                deferred.resolve(response.data.result);
            }, function (response) {
                deferred.reject(response.data.validationErrors);
            });
        }

        function edit(franchisee) {
            var deferred = $q.defer();
            $http({
                method: "PUT",
                url: clcw.apiService + franchiseeUrl,
                data: franchisee
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
                url: clcw.apiService + franchiseeUrl + id
            }).then(function (response) {
                deferred.resolve(response.data.result);
            }, function (response) {
                deferred.reject(response.data.validationErrors);
            });

            return deferred.promise;
        }
    }
]);