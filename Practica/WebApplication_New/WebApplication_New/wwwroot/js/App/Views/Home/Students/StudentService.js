class StudentService
{

    constructor($http)
    {
        this.Http = $http;
    }

    GetAllAsync(callbackAction)
    {
        this.Http.get("/api/students").then(
            (response) =>
            {
                callbackAction(response.data);
            },
            function errorCallback(response)
            {
                console.log("POST-ing of data failed");
            }
        );
    }
}

StudentService.$inject = ['$http'];

EstadisticaDeAlumnos.service("studentService", StudentService);