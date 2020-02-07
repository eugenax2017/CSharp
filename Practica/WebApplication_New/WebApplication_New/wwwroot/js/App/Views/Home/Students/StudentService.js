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
                console.log("GET-ing of data failed");
            }
        );
    }

    AddElementAsync(element, callbackAction)
    {
        this.Http.post("/api/students", element).then(
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

    UpdateElementAsync(element, callbackAction)
    {
        this.Http.put(`/api/students/${element.id}`, element).then(
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