var EstadisticaDeAlumnos = angular.module('EstadisticaDeAlumnos',
    ['ui.bootstrap',
        'ui.grid', 'ui.grid.selection', 'ngRoute']);

EstadisticaDeAlumnos.config(function ($routeProvider) {
    $routeProvider.when("/", {
        templateUrl: "default.html"
    })
    .when("/students", {
        templateUrl: "./js/App/Views/Home/Students/StudentsView.html",
        controller: "StudentsController",
        controllerAs: 'vm'
    })
        .when("/subjects", {
            templateUrl: "./js/App/Views/Home/Subjects/SubjectsView.html"       
    });
});

var Globals = new ClientGlobals();

