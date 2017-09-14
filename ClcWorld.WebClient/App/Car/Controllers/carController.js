"use strict";
angular.module("ClcWorldApp").controller("carController", [
    "$scope", "$state", "carService", "masterTablesService", "$uibModal", function ($scope, $state, carService, masterTablesService, $uibModal) {
        var vm = this;
        vm.cars = [];
        vm.filter = { take: 10, page: 1, orderDirection: "ASC" };

        vm.attributes = [
            { displayName: "Id", attribute: "id", orderable: true },
            { displayName: "Mátricula", attribute: "registration", orderable: true },
            { displayName: "Módelo", attribute: "model", orderable: true },
            { displayName: "Kilometros", attribute: "kilometers", orderable: true },
            { displayName: "Concesionario", attribute: "nameFranchisee", orderable: true },
            { displayName: "Marca", attribute: "nameCarBrand", orderable: true }
        ];

        vm.getAll = getAll;
        vm.addOrUpdate = addOrUpdate;
        /*vm.edit = edit;
        vm.remove = remove;
        vm.get = get;*/

        init();

        function init() {
            getAll();
        }

        function getAll() {
            carService.getAll(vm.filter).then(function (res) {
                vm.cars = res.items;
                vm.total = res.total;
                vm.numOfPages = [];
                for (var i = 0; i * vm.filter.take < vm.total; i++) {
                    vm.numOfPages.push(i);
                }
            }, function (err) {

            });
        }

        function addOrUpdate(carId) {
            $uibModal.open({
                templateUrl: "/App/Car/Modals/carAddOrUpdate.html",
                controller: "carAddOrUpdateController",
                controllerAs: "carAddOrUpdateCtrl",
                replace: true,
                resolve: {
                    carId: function () {
                        return carId;
                    }
                }
            }).result.then(function () {
                getAll();
            });
        }

    }
]);
