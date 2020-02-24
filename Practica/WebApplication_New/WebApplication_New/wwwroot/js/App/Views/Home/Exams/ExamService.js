class ExamService
{

    constructor($http)
    {
        this.Http = $http;
    }

    GetAllAsync(callbackAction)
    {
        this.Http.get("/api/exams").then(
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

    GetAllSubjectsAsync(callbackAction)
    {
        this.Http.get("/api/subjects").then(
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
        this.Http.post("/api/exams", element).then(
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
        this.Http.put(`/api/exams/${element.id}`, element).then(
            (response) =>
            {
                callbackAction(response.data);
            },
            function errorCallback(response)
            {
                console.log("PUT-ing of data failed");
            }
        );
    }

    DeleteElementAsync(element, callbackAction)
    {
        this.Http.delete(`/api/exams/${element.id}`, element).then(
            (response) =>
            {
                callbackAction(response.data);
            },
            function errorCallback(response)
            {
                console.log("DELETE-ing of data failed");
            }
        );
    }
}


ExamService.$inject = ['$http'];

EstadisticaDeAlumnos.service("examService", ExamService);