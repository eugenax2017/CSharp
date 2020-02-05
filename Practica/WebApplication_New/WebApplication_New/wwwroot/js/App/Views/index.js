class Index {

    get Students() {
        return this._students;
    }
    set Students(value) {
        this._students = value;
    }

    set SelectedRows(value) {
        this._selectedRows = value;
    }  

    get SelectedRows() {
        var selectedRows = this.gridOptions.gridApi.selection.getSelectedRows();
        return selectedRows[0];
    }

    get IsLogon() {
        return Globals.IsLogon;
    }

    constructor($http) {
        this._students = [];
        this._selectedRows = "";
        this.Http = $http;
        this.gridOptions = {
            enableColumnMenus: false,
            enableHorizontalScrollbar: 0,
            enableVerticalScrollbar: 0,
            enableRowSelection: true,
            enableRowHeaderSelection: false,
            data: this.Students,
            multiSelect: false,
            onRegisterApi: function (gridApi) {
                this.gridApi = gridApi;
            }
        }      
    }

    RequestStudents() {
        this.Http.get("/api/students").then(
            (response) => {
                this.Students.length = 0;
                for (let i in response.data) {
                    this.Students.push(response.data[i]);
                }
            },
            function errorCallback(response) {
                console.log("POST-ing of data failed");
            }
        );
    }

     AddStudent() {        
        var newStudent = new Student(stName.value, stEmail.value, stDni.value, parseInt(stChairNumber.value));        
        this.Http.post("/api/students", newStudent).then(
            (response) => {  
                if (response.data) {
                    this.gridOptions.data.push(response.data);
                    console.log("POST-ing of data successfully!");                    
                }                                                
            },
            function errorCallback(response) {
                console.log("POST-ing of data failed");
            }
        );        
    }

    UpdateStudent() {         
        alert(this.SelectedRows.name);
    }
}
Index.$inject = ['$http'];

EstadisticaDeAlumnos.
    component('index', {
        templateUrl: './js/App/Views/index.html',
        controller: ('Index', Index),
        controllerAs: 'vm'
    });