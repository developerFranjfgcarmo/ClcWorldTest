angular.module("ClcWorldApp", ["ngRoute", "ui.router", "ui.bootstrap", "ngSanitize", , "ngAnimate"]);
angular.module("ClcWorldApp").config(function ($stateProvider, $urlRouterProvider, $locationProvider) {
    $stateProvider.state("home",
    {
        url: "/home",
        controller: "homeController",
        controllerAs: "homeCtrl",
        templateUrl: "/App/home/home.html"
    });
    $locationProvider.html5Mode(true);
    $urlRouterProvider.otherwise("/home");
});