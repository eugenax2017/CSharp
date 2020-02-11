var EstadisticaDeAlumnos = angular.module('EstadisticaDeAlumnos',
    ['ui.bootstrap',
        'ui.grid', 'ui.grid.selection', 'ngRoute']);

//EstadisticaDeAlumnos.config(function ($routeProvider) {
//    $routeProvider.when("/", {
//        templateUrl: "main.htm"
//    })
//    .when("/london", {
//        templateUrl: "london.htm",
//        controller: "londonCtrl"
//    })
//    .when("/paris", {
//        templateUrl: "paris.htm",
//        controller: "parisCtrl"
//    });
//});

var Globals = new ClientGlobals();