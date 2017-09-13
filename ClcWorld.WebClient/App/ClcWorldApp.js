angular.module("ClcWorldApp", ["ngRoute", "ui.router", "ui.bootstrap", "ngSanitize", "ui.bootstrap", "ngAnimate"]);
angular.module("ClcWorldApp").config(function ($stateProvider, $urlRouterProvider, $locationProvider) {
    $stateProvider.state("home",
    {
        url: "/home",
        controller: "homeController",
        controllerAs: "homeCtrl",
        templateUrl: "/App/home/home.html"
    }).state("cars",
    {
        url: "/coches",
        controller: "carController",
        controllerAs: "carCtrl",
        templateUrl: "/App/car/carList.html"
    });
    $locationProvider.html5Mode(true);
    $urlRouterProvider.otherwise("/home");
});