var EstadisticaDeAlumnos = angular.module('EstadisticaDeAlumnos',
    ['ui.bootstrap',
        'ui.grid', 'ui.grid.selection', 'ngRoute']);

EstadisticaDeAlumnos.config(function($routeProvider) {
    $routeProvider.when("/", {
        templateUrl: "./js/App/Views/Home/Students/StudentsView.html",
        controller: ('StudentsView', StudentsView),
        controllerAs: 'vm'
    })
        .when("#!/students", {
        templateUrl: "./js/App/Views/Home/Students/StudentsView.html",
        controller: ('StudentsView', StudentsView),
        controllerAs: 'vm'
    })
        .when("#!/subjects", {
        templateUrl: "./js/App/Views/Home/Subjects/SubjectsView.html",
        controller: ('SubjectsView', SubjectsView),
        controllerAs: 'vm'            
    });
});

var Globals = new ClientGlobals();
