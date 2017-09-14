angular.module("ClcWorldApp")
    .controller("carAddOrUpdateController",
    ["$scope", "masterTablesService", "carService", "carId", "$uibModalInstance",
        function ($scope, masterTablesService, carService, carId, $uibModalInstance) {
            var vm = this;
            //vars
            vm.errors = [];
            vm.franchisees = [];
            vm.carBrands = [];
            vm.car = {};
            vm.currentModel = {};
            //functions
            vm.save = save;
            vm.dismiss = dismiss;
            vm.modelIsValid = modelIsValid;
            init();

            function init() {
                getCarById(carId);

                masterTablesService.getCarBrand().then(function(data) {
                    vm.carBrands = data;
                });
                masterTablesService.getFranchisee().then(function (data) {
                    vm.franchisees = data;
                });
            }

            function getCarById(id) {
                if (id == undefined) {
                    return;
                }

                carService.get(id).then(function(data) {
                    vm.car = data;
                    vm.currentModel = angular.copy(data);
                });
            }

            function save() {

                if (vm.car.id == undefined) {
                    carService.create(vm.car).then(function (data) {
                        vm.car = data;
                        vm.currentModel = angular.copy(data);
                    }, function (errors) {
                        vm.errors = errors;
                    });
                } else {
                    carService.edit(vm.car).then(function (data) {
                        vm.car = data;
                        vm.currentModel = angular.copy(data);
                    }, function (errors) {
                        vm.errors = errors;
                    });
                }                
            }

            function dismiss() {
                $uibModalInstance.dismiss();
            }

            function modelIsValid() {
                return self.carAddOrUpdateCtrl.$valid && !angular.equals(vm.currentModel, vm.car);
            }
        }
    ]);