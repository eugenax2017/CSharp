
class ExamsView
{
    constructor(examService)
    {
        this._exams = [];
        //this._selectedRows = "";
        //this.SelectedRows = this.EmptySubject();
        this.ExamService = examService;
        //this.gridOptions = {
        //    enableColumnMenus: false,
        //    enableHorizontalScrollbar: 0,
        //    enableVerticalScrollbar: 0,
        //    enableRowSelection: true,
        //    enableRowHeaderSelection: false,
        //    data: this.Subjects,
        //    multiSelect: false,
        //    columnDefs: [
        //        { name: "Name", field: "name" },
        //        { name: "Teacher", field: "teacher" },
        //    ],
        //    onRegisterApi: function (gridApi)
        //    {
        //        this.gridApi = gridApi;
        //    }
        //}
        
    }
}

SubjectsView.$inject = ['examService'];

EstadisticaDeAlumnos.
    component('examsview', {
        templateUrl: 'js/App/Views/Home/Exams/ExamsView.html',
        controller: ('ExamsView', ExamsView),
        controllerAs: 'vm'
    });