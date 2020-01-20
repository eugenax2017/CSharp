class Index 
{    

    get Books()
    {
        return this._books;
    }
    set Books(value)
    {
        this._books = value;
    }

    get IsLogon()
    {
        return Globals.IsLogon;
    }

    constructor($http)
    {
        this._books = [];
        this.Http = $http;
    }

    RequestBooks()
    {
        this.Http.get("/api/books").then(
            (response) =>
            {
                this.Books.length = 0;
                for (let i in response.data)
                {
                    this.Books.push(response.data[i]);
                }
            },
            function errorCallback(response)
            {
                console.log("POST-ing of data failed");
            }
        );
    }    
}
Index.$inject = ['$http'];

CrazyBooksApp.
    component('index', {
        templateUrl: './js/App/Views/index.html',
        controller: ('Index', Index),
        controllerAs: 'vm'
    });