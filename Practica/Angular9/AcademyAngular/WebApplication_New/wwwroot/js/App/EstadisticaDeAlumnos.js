var EstadisticaDeAlumnos = angular.module('EstadisticaDeAlumnos',
    ['ui.bootstrap',
        'ui.grid', 'ui.grid.selection',
        'ngRoute', 'ngMaterial', 'ngMessages']);

EstadisticaDeAlumnos.config(function ($routeProvider)
{
    $routeProvider.when('/', {
        templateUrl: './js/App/Views/Home/Students/StudentsView.html',
        controller: ('StudentsView', StudentsView),
        controllerAs: 'vm'
    });
    $routeProvider.when('/students', {
        templateUrl: './js/App/Views/Home/Students/StudentsView.html',
        controller: ('StudentsView', StudentsView),
        controllerAs: 'vm'
    });
    $routeProvider.when('/subjects', {
        templateUrl: './js/App/Views/Home/Subjects/SubjectsView.html',
        controller: ('SubjectsView', SubjectsView),
        controllerAs: 'vm'
    });
    $routeProvider.when('/exams', {
        templateUrl: './js/App/Views/Home/Exams/ExamsView.html',
        controller: ('ExamsView', ExamsView),
        controllerAs: 'vm'
    });
    $routeProvider.otherwise({
        redirectTo: '/'
    });
});

var Globals = new ClientGlobals();
