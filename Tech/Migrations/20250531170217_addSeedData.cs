using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tech.Migrations
{
    /// <inheritdoc />
    public partial class addSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Departments_DepartmentId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_crsResults_Courses_crs_id",
                table: "crsResults");

            migrationBuilder.DropForeignKey(
                name: "FK_crsResults_Trainees_trainee_ID",
                table: "crsResults");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Courses_crs_id",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Departments_DepartmentId",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainees_Departments_DepartmentId",
                table: "Trainees");

            migrationBuilder.DropIndex(
                name: "IX_Trainees_DepartmentId",
                table: "Trainees");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_DepartmentId",
                table: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_Courses_DepartmentId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Trainees");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Trainees",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "dept_id",
                table: "Trainees",
                newName: "DeptId");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Instructors",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "dept_id",
                table: "Instructors",
                newName: "DeptId");

            migrationBuilder.RenameColumn(
                name: "crs_id",
                table: "Instructors",
                newName: "CrsId");

            migrationBuilder.RenameIndex(
                name: "IX_Instructors_crs_id",
                table: "Instructors",
                newName: "IX_Instructors_CrsId");

            migrationBuilder.RenameColumn(
                name: "trainee_ID",
                table: "crsResults",
                newName: "TraineeID");

            migrationBuilder.RenameColumn(
                name: "crs_id",
                table: "crsResults",
                newName: "CrsId");

            migrationBuilder.RenameIndex(
                name: "IX_crsResults_trainee_ID",
                table: "crsResults",
                newName: "IX_crsResults_TraineeID");

            migrationBuilder.RenameIndex(
                name: "IX_crsResults_crs_id",
                table: "crsResults",
                newName: "IX_crsResults_CrsId");

            migrationBuilder.RenameColumn(
                name: "dept_id",
                table: "Courses",
                newName: "DeptId");

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Manager", "Name" },
                values: new object[,]
                {
                    { 1, "Dr.Ali", "Computer Science" },
                    { 2, "Dr.Osama", "AI" },
                    { 3, "Dr.Omar", "Information System " }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Degree", "DeptId", "Hours", "MinDegree", "Name" },
                values: new object[,]
                {
                    { 1, 90.0, 1, 3f, 70.0, "C# Programming" },
                    { 2, 70.0, 1, 3f, 65.0, "OOP" },
                    { 3, 65.0, 2, 3f, 60.0, "Database" }
                });

            migrationBuilder.InsertData(
                table: "Trainees",
                columns: new[] { "Id", "Address", "DeptId", "Grade", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "ALex", 1, 3.2000000000000002, " ", "AHMED AHMED" },
                    { 2, "Cairo", 1, 3.1000000000000001, " ", "ALI ALI " },
                    { 3, "Damanhour", 2, 2.7000000000000002, " ", "OMAR OMAR" }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "Address", "CrsId", "DeptId", "ImageUrl", "Name", "Salary" },
                values: new object[,]
                {
                    { 1, "Alex", 1, 1, "ahmed.jpg", "Ahmed Selim", 7000m },
                    { 2, "Giza", 2, 2, "mohamed.png", "Mohamed", 5500m }
                });

            migrationBuilder.InsertData(
                table: "crsResults",
                columns: new[] { "Id", "CrsId", "Degree", "TraineeID" },
                values: new object[,]
                {
                    { 1, 1, 85.0, 1 },
                    { 2, 2, 78.0, 1 },
                    { 3, 1, 92.0, 2 },
                    { 4, 3, 88.0, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_DeptId",
                table: "Trainees",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_DeptId",
                table: "Instructors",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DeptId",
                table: "Courses",
                column: "DeptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Departments_DeptId",
                table: "Courses",
                column: "DeptId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_crsResults_Courses_CrsId",
                table: "crsResults",
                column: "CrsId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_crsResults_Trainees_TraineeID",
                table: "crsResults",
                column: "TraineeID",
                principalTable: "Trainees",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Courses_CrsId",
                table: "Instructors",
                column: "CrsId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Departments_DeptId",
                table: "Instructors",
                column: "DeptId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainees_Departments_DeptId",
                table: "Trainees",
                column: "DeptId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Departments_DeptId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_crsResults_Courses_CrsId",
                table: "crsResults");

            migrationBuilder.DropForeignKey(
                name: "FK_crsResults_Trainees_TraineeID",
                table: "crsResults");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Courses_CrsId",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Departments_DeptId",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainees_Departments_DeptId",
                table: "Trainees");

            migrationBuilder.DropIndex(
                name: "IX_Trainees_DeptId",
                table: "Trainees");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_DeptId",
                table: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_Courses_DeptId",
                table: "Courses");

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "crsResults",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "crsResults",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "crsResults",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "crsResults",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Trainees",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "DeptId",
                table: "Trainees",
                newName: "dept_id");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Instructors",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "DeptId",
                table: "Instructors",
                newName: "dept_id");

            migrationBuilder.RenameColumn(
                name: "CrsId",
                table: "Instructors",
                newName: "crs_id");

            migrationBuilder.RenameIndex(
                name: "IX_Instructors_CrsId",
                table: "Instructors",
                newName: "IX_Instructors_crs_id");

            migrationBuilder.RenameColumn(
                name: "TraineeID",
                table: "crsResults",
                newName: "trainee_ID");

            migrationBuilder.RenameColumn(
                name: "CrsId",
                table: "crsResults",
                newName: "crs_id");

            migrationBuilder.RenameIndex(
                name: "IX_crsResults_TraineeID",
                table: "crsResults",
                newName: "IX_crsResults_trainee_ID");

            migrationBuilder.RenameIndex(
                name: "IX_crsResults_CrsId",
                table: "crsResults",
                newName: "IX_crsResults_crs_id");

            migrationBuilder.RenameColumn(
                name: "DeptId",
                table: "Courses",
                newName: "dept_id");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Trainees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Instructors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_DepartmentId",
                table: "Trainees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_DepartmentId",
                table: "Instructors",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DepartmentId",
                table: "Courses",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Departments_DepartmentId",
                table: "Courses",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_crsResults_Courses_crs_id",
                table: "crsResults",
                column: "crs_id",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_crsResults_Trainees_trainee_ID",
                table: "crsResults",
                column: "trainee_ID",
                principalTable: "Trainees",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Courses_crs_id",
                table: "Instructors",
                column: "crs_id",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Departments_DepartmentId",
                table: "Instructors",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainees_Departments_DepartmentId",
                table: "Trainees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
