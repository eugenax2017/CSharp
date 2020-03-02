class Index {

    get IsLogon() {
        return Globals.IsLogon;
    }   
}
Index.$inject = ['$http'];

EstadisticaDeAlumnos.
    component('index', {
        templateUrl: './js/App/Views/index.html',
        controller: ('Index', Index),
        controllerAs: 'vm'
    });