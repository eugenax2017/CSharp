class StudentsView {
    Name = "";
    Email = "";
    Dni = "";
    ChairNumber = "";

    AddStudent() {
        newStudent = new Student(Name, Email, Dni, this.ChairNumber);

        newStudent.Save();
    }

}