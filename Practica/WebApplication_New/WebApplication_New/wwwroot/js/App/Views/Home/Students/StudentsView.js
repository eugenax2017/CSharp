class StudentsView
{

    get Name()
    {
        return this._name;
    }
    set Name(value)
    {
        this._name = value;
    }

    get Dni()
    {
        return this._dni;
    }
    set Dni(value)
    {
        this._dni = value;
    }

    get Email()
    {
        return this._email;
    }
    set Email(value)
    {
        this._email = value;
    }

    get ChairNumber()
    {
        return this._chairNumber;
    }
    set ChairNumber(value)
    {
        this._chairNumber = value;
    }

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
        var returnValue = this.EmptyStudent();

        try
        {
            var selectedRows = this.gridOptions.gridApi.selection.getSelectedRows();
            if (selectedRows.length > 0)
                returnValue = selectedRows[0];
        }
        catch (error)
        {
            returnValue = this.EmptyStudent();
        }  

        console.log(returnValue);
        return returnValue;
    }

    get IsLogon()
    {
        return Globals.IsLogon;
    }

    constructor(studentService)
    {
        this._students = [];
        //this._selectedRows = "";
        this.SelectedRows = this.EmptyStudent();
        this.StudentService = studentService;
        this.gridOptions = {
            enableColumnMenus: false,
            enableHorizontalScrollbar: 0,
            enableVerticalScrollbar: 0,
            enableRowSelection: true,
            enableRowHeaderSelection: false,
            data: this.Students,
            multiSelect: false,
            columnDefs: [
                { name: "Name", field: "name" },
                { name: "Dni", field: "dni" },
                { name: "Email", field: "email" },
                { name: "Chair", field: "chairNumber" },
            ],
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

    PrintErrors(errorArr) //don`t foget "this!"
    {
        if (errorArr.length > 0)
        {
            for (let i = 0; i < errorArr.length; i++)
            {
                //console.log(errorArr[i]);
                alert(errorArr[i]);
            }
        }
    }

    SaveStudent()
    {
        var newStudent = new Student(stName.value, stEmail.value, stDni.value, parseInt(stChairNumber.value));
        // or 
        //var newStudent = new Student(this.Name, this.Email, this.Dni, parseInt(this.ChairNumber));
        
        this.StudentService.AddElementAsync(newStudent, (data) =>
        {
            if (data)
            {                
                if (data.isSuccess)
                {
                    this.RequestStudents(); //this.gridOptions.data.push(data);
                    console.log("POST-ing of data successfully!");
                }
                else
                {
                    this.PrintErrors(data.validation.errors);
                    console.log("POST-ing of data is failed!");
                }
                this.SelectedRows = this.EmptyStudent();
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
    
    EditStudent(row) //add check If chairNumber is number
    {        
        if (row)
        {
            //var updStudent = new Student(stName.value, stEmail.value, stDni.value, parseInt(stChairNumber.value));
            //updStudent.Id = row.Id; 
            this.Name = row.name;
            this.Dni = row.dni; //stDni.value;
            this.ChairNumber = row.chairNumber; //stChairNumber.value;
            this.Email = row.email; //stEmail.value;
            this.StudentService.UpdateElementAsync(row, (data) =>
            {
                if (data)
                {
                    if (data.isSuccess)
                    {
                        this.RequestStudents();                        
                        console.log("PUT-ing of data successfully!"); 
                    }
                    else
                    {
                        this.PrintErrors(data.validation.errors);
                        console.log("PUT-ing of data is failed!");
                    }           
                    this.SelectedRows = this.EmptyStudent();                                        
                }                    
            });
        }
    }

    DeleteStudent(row)
    { //https:///aspdotnetcodehelp.wordpress.com/2017/05/13/implementing-delete-functionality-in-uigrid/
        if (row)
        {
            this.StudentService.DeleteElementAsync(row, (data) =>
            {
                if (data)
                {                    
                    this.RequestStudents(); // or this.gridOptions.data.indexOf(row) 
                    //this.gridOptions.data.(data);
                    console.log("DELETE-ing of data successfully!");
                }
            });            
        }
    }
       
    EmptyStudent()
    {
        var emptyStudent = new Object();
        emptyStudent.name = "";
        emptyStudent.email = "";
        emptyStudent.dni = "";
        emptyStudent.chairNumber = 0;
        return emptyStudent;
    }

    ClearStudent()
    {
        this.Dni = "";
        this.Name = "";
        this.Email = "";
        this.ChairNumber = 0;
    }
}

StudentsView.$inject = ['studentService'];

EstadisticaDeAlumnos.
    component('studentsview', {
        templateUrl: 'js/App/Views/Home/Students/StudentsView.html',
        controller: ('StudentsView', StudentsView),
        controllerAs: 'vm'
    });