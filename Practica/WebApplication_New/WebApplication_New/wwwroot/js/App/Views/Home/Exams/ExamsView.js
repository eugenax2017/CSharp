
class ExamsView
{
    get Title()
    {
        return this._title;
    }

    set Title(value)
    {
        this._title = value;
    }

    get Text()
    {
        return this._text;
    }

    set Text(value)
    {
        this._text = value;
    }

    get Date()
    {
        return this._date;
    }

    set Date(value)
    {
        this._date = value;
    }

    //get Subject()
    //{
    //    return this._subject;
    //}

    //set Subject(value)
    //{
    //    this._subject = value;
    //}

    get Exams()
    {
        return this._exams;
    }

    set Exams(value)
    {
        this._exams = value;
    }

    get ListSubjects()
    {
        return this._listSubjects;
    }

    set ListSubjects(value)
    {
        this._listSubjects = value;
    }

    get SearchText()
    {
        return this._searchText;
    }
    set SearchText(value)
    {
        this._searchText = value;
    }

    get SelectedItem()
    {
        return this._selectedItem;
    }
    set SelectedItem(value)
    {
        this._selectedItem = value;
    }

    set SelectedRows(value)
    {
        this._selectedRows = value;
    }

    get SelectedRows()
    {
        var returnValue = this.EmptyExam();

        try
        {
            var selectedRows = this.gridOptions.gridApi.selection.getSelectedRows();
            if (selectedRows.length > 0)
                returnValue = selectedRows[0];
        }
        catch (error)
        {
            returnValue = this.EmptyExam();
        }

        console.log(returnValue);
        return returnValue;
    }

    get IsLogon()
    {
        return Globals.IsLogon;
    }

    constructor(examService)
    {
        this._exams = [];
        //this._selectedRows = "";
        //this.SelectedRows = this.EmptySubject();
        this.ExamService = examService;
        this._date = new Date();
        this.isOpen = false; 
        this.simulateQuery = false;
        this.isDisabled = false;
        this._listSubjects = [];
        // list of `state` value/display objects
        this.loadAll();       
        //this.selectedItemChange = this.selectedItemChange;
        //this.searchTextChange = this.searchTextChange;
        
        this.gridOptions = {
            enableColumnMenus: false,
            enableHorizontalScrollbar: 0,
            enableVerticalScrollbar: 0,
            enableRowSelection: true,
            enableRowHeaderSelection: false,
            data: this.Exams,
            multiSelect: false,
            columnDefs: [
                { name: "Title", field: "title" },
                { name: "Text", field: "text" },
                { name: "Date", field: "date" },
                { name: "Subject", field: "subject.name" },
            ],
            onRegisterApi: function (gridApi)
            {
                this.gridApi = gridApi;
            }
        }       
    }

    querySearch(query)
    {
        var results = query ? this.ListSubjects.filter(this.createFilterFor(query)) : this.ListSubjects, deferred;   
        
        return results;       
    }

    loadAll()
    {     

        this.ExamService.GetAllSubjectsAsync((data) =>
        {
            for (let i in data)
            {                
                this.ListSubjects.push({ value: data[i], display: data[i].name });
            }            
        });        
    }

    /**
     * Create filter function for a query string
     */
    createFilterFor(query)
    {
        //var lowercaseQuery = query.toLowerCase();

        return function filterFn(subject)
        {
            return (subject.display.indexOf(query) === 0);
        };
    } 

    RequestExams()
    {
        this.ExamService.GetAllAsync((data) =>
        {
            this.LoadExams(data);
        });
    }

    LoadExams(data)
    {
        this.Exams.length = 0;
        for (let i in data)
        {
            this.Exams.push(data[i]);
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

    SaveExam(row)
    {
        if (!row.id)
        {
            if (this.SelectedItem)
            {
                var selectedSubject = this.SelectedItem.value;
                var newExam = new Exam(this.Title, this.Text, this.Date, selectedSubject.id);
                // or 
                //var newSubject = new Subject(this.Name, this.Email, this.Dni, parseInt(this.ChairNumber));

                this.ExamService.AddElementAsync(newExam, (data) =>
                {
                    if (data)
                    {
                        if (data.isSuccess)
                        {
                            this.RequestExams(); //this.gridOptions.data.push(data);
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
                console.log("Elige el subject!");
            }            
        }
        else
        {
            row.title = this.Title;
            row.text = this.Text;
            row.date = this.Date;
            row.subject = this.SelectedItem.id;

            this.ExamService.UpdateElementAsync(row, (data) =>
            {
                if (data)
                {
                    if (data.isSuccess)
                    {
                        this.RequestExams();
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
        this.ClearExam();
    }

    EditExam(row) //add check If chairNumber is number
    {
        if (row)
        {
            this.Title = row.title;
            this.Text = row.text;
            this.Date = row.date;            
            this.SelectedItem = row.subject.name;
        }
    }

    DeleteExam(row)
    { //https:///aspdotnetcodehelp.wordpress.com/2017/05/13/implementing-delete-functionality-in-uigrid/
        if (row)
        {
            this.ExamService.DeleteElementAsync(row, (data) =>
            {
                if (data)
                {
                    this.RequestExams(); // or this.gridOptions.data.indexOf(row) 
                    //this.gridOptions.data.(data);
                    console.log("DELETE-ing of data successfully!");
                }
            });
        }
    }

    EmptyExam()
    {
        var emptyExam = new Object();
        emptyExam.title = "";
        emptyExam.text = "";
        emptyExam.date = new Date();
        //emptyExam.subject = "";
        emptyExam.subjectId = "";
        return emptyExam;
    }

    ClearExam()
    {
        this.Title = "";
        this.Text = "";
        this.Date = new Date();
        //this.Subject = "";
        this.SelectedItem = "";
        this.RequestExams();
    }
}

ExamsView.$inject = ['examService'];

EstadisticaDeAlumnos.
    component('examsview', {
        templateUrl: 'js/App/Views/Home/Exams/ExamsView.html',
        controller: ('ExamsView', ExamsView),
        controllerAs: 'vm'
    });