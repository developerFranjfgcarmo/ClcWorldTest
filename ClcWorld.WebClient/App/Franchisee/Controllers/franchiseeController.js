"use strict";
angular.module("ClcWorldApp").controller("franchiseeController", [
    "$scope", "$state", "franchiseeServices", function ($scope, $state, franchiseeServices) {
        var vm = this;
        vm.franchisees = [];
        vm.filter = { take: 10, page: 1, orderDirection: "ASC" };

        self.attributes = [
            { displayName: "Id", attribute: "id", orderable: true },
        ];

        vm.getAll = getAll;
        /* vm.create = create;
         vm.edit = edit;
         vm.remove = remove;
         vm.get = get;*/

        init();

        function init() {
            getAll();
        }

        function getAll() {
            franchiseeServices.getAll(vm.filter).then(function (res) {
                vm.franchisees = res.items;
                vm.total = res.total;
                vm.numOfPages = [];
                for (var i = 0; i * vm.filter.take < vm.total; i++) {
                    vm.numOfPages.push(i);
                }
            }, function (err) {

            });
        }

    }
]);