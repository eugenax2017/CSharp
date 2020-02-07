class StudentsView
{

    get Students()
    {
        return this._students;
    }
    set Students(value)
    {
        this._students = value;
    }

    set SelectedRows(value)
    {
        this._selectedRows = value;
    }

    get SelectedRows()
    {
        var emptyStudent = new Object();
        emptyStudent.name = "",
        emptyStudent.email = "",
        emptyStudent.dni = "",
        emptyStudent.chairNumber = 0;

        try
        {
            var selectedRows = this.gridOptions.gridApi.selection.getSelectedRows();
            if (selectedRows.length > 0)
                return selectedRows[0];
        }
        catch (error)
        {
            return emptyStudent;
        }  

        return emptyStudent;
    }

    get IsLogon()
    {
        return Globals.IsLogon;
    }

    constructor(studentService)
    {
        this._students = [];
        this._selectedRows = "";
        this.StudentService = studentService;
        this.gridOptions = {
            enableColumnMenus: false,
            enableHorizontalScrollbar: 0,
            enableVerticalScrollbar: 0,
            enableRowSelection: true,
            enableRowHeaderSelection: false,
            data: this.Students,
            multiSelect: false,
            onRegisterApi: function (gridApi)
            {
                this.gridApi = gridApi;
            }
        }
    }

    RequestStudents()
    {
        this.StudentService.GetAllAsync((data) =>
        {
            this.LoadStudents(data);
        });
    }

    LoadStudents(data)
    {
        this.Students.length = 0;
        for (let i in data)
        {
            this.Students.push(data[i]);
        }
    }

    AddStudent()
    {
        var newStudent = new Student(stName.value, stEmail.value, stDni.value, parseInt(stChairNumber.value));
        
        this.StudentService.AddElementAsync(newStudent, (data) =>
        {
            if (data)
            {
                this.gridOptions.data.push(data);
                console.log("POST-ing of data successfully!");
                this.ClearForm();
            }
        });

        //this.Http.post("/api/students", newStudent).then(
        //    (response) =>
        //    {
        //        if (response.data)
        //        {
        //            this.gridOptions.data.push(response.data);
        //            console.log("POST-ing of data successfully!");
        //        }
        //    },
        //    function errorCallback(response)
        //    {
        //        console.log("POST-ing of data failed");
        //    }
        //);
    }


    UpdateStudent() //no funcciona
    {
        var row = this.SelectedRows;
        if (row)
        {
            this.StudentService.UpdateElementAsync(row, (data) =>
            {
                if (data)
                {
                    console.log("PUT-ing of data successfully!");
                    this.ClearForm();
                }
                    
            });
        }
    }

    DeleteStudent(row)
    { //https:///aspdotnetcodehelp.wordpress.com/2017/05/13/implementing-delete-functionality-in-uigrid/
        if (row)
        {
            alert("delete!");
        }
    }

    ClearForm()
    {
        stName.value = "";
        stEmail.value = "";
        stDni.value = "";
        stChairNumber.value = 0;
    }
}

StudentsView.$inject = ['studentService'];

EstadisticaDeAlumnos.
    component('studentsview', {
        templateUrl: 'js/App/Views/Home/Students/StudentsView.html',
        controller: ('StudentsView', StudentsView),
        controllerAs: 'vm'
    });