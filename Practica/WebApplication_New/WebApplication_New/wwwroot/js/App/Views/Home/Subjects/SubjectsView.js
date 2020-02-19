class SubjectsView
{

    get Name()
    {
        return this._name;
    }
    set Name(value)
    {
        this._name = value;
    }

    get Teacher()
    {
        return this._teacher;
    }
    set Teacher(value)
    {
        this._teacher = value;
    }   

    get Subjects()
    {
        return this._subjects;
    }
    set Subjects(value)
    {
        this._subjects = value;
    }

    set SelectedRows(value)
    {
        this._selectedRows = value;
    }

    get SelectedRows()
    {
        var returnValue = this.EmptySubject();

        try
        {
            var selectedRows = this.gridOptions.gridApi.selection.getSelectedRows();
            if (selectedRows.length > 0)
                returnValue = selectedRows[0];
        }
        catch (error)
        {
            returnValue = this.EmptySubject();
        }

        console.log(returnValue);
        return returnValue;
    }

    get IsLogon()
    {
        return Globals.IsLogon;
    }

    constructor(subjectService)
    {
        this._subjects = [];
        //this._selectedRows = "";
        this.SelectedRows = this.EmptySubject();
        this.SubjectService = subjectService;
        this.gridOptions = {
            enableColumnMenus: false,
            enableHorizontalScrollbar: 0,
            enableVerticalScrollbar: 0,
            enableRowSelection: true,
            enableRowHeaderSelection: false,
            data: this.Subjects,
            multiSelect: false,
            columnDefs: [
                { name: "Name", field: "name" },                
                { name: "Teacher", field: "teacher" },                
            ],
            onRegisterApi: function (gridApi)
            {
                this.gridApi = gridApi;
            }
        }
    }

    RequestSubjects()
    {
        this.SubjectService.GetAllAsync((data) =>
        {
            this.LoadSubjects(data);
        });
    }

    LoadSubjects(data)
    {
        this.Subjects.length = 0;
        for (let i in data)
        {
            this.Subjects.push(data[i]);
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

    SaveSubject(row)
    {
        if (!row.id)
        {
            var newSubject = new Subject(stName.value, stTeacher.value);
            // or 
            //var newSubject = new Subject(this.Name, this.Email, this.Dni, parseInt(this.ChairNumber));

            this.SubjectService.AddElementAsync(newSubject, (data) =>
            {
                if (data)
                {
                    if (data.isSuccess)
                    {
                        this.RequestSubjects(); //this.gridOptions.data.push(data);
                        console.log("POST-ing of data successfully!");
                    }
                    else
                    {
                        this.PrintErrors(data.validation.errors);
                        console.log("POST-ing of data is failed!");
                    }
                }
            });
        }
        else
        {
            row.name = this.Name;
            row.teacher = this.Teacher;           

            this.SubjectService.UpdateElementAsync(row, (data) =>
            {
                if (data)
                {
                    if (data.isSuccess)
                    {
                        this.RequestSubjects();
                        console.log("PUT-ing of data successfully!");
                    }
                    else
                    {
                        this.PrintErrors(data.validation.errors);
                        console.log("PUT-ing of data is failed!");
                    }
                }
            });
        }
        this.ClearSubject();       
    }

    EditSubject(row) //add check If chairNumber is number
    {
        if (row)
        {
            this.Name = row.name;
            this.Teacher = row.teacher;             
        }
    }

    DeleteSubject(row)
    { //https:///aspdotnetcodehelp.wordpress.com/2017/05/13/implementing-delete-functionality-in-uigrid/
        if (row)
        {
            this.SubjectService.DeleteElementAsync(row, (data) =>
            {
                if (data)
                {
                    this.RequestSubjects(); // or this.gridOptions.data.indexOf(row) 
                    //this.gridOptions.data.(data);
                    console.log("DELETE-ing of data successfully!");
                }
            });
        }
    }

    EmptySubject()
    {
        var emptySubject = new Object();
        emptySubject.name = "";
        emptySubject.teacher = "";        
        return emptySubject;
    }

    ClearSubject()
    {
        this.Name = "";
        this.Teacher = "";        
        this.RequestSubjects();
    }
}

SubjectsView.$inject = ['subjectService'];

EstadisticaDeAlumnos.
    component('subjectsview', {
        templateUrl: 'js/App/Views/Home/Subjects/SubjectsView.html',
        controller: ('SubjectsView', SubjectsView),
        controllerAs: 'vm'
    });