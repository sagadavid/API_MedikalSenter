using Microsoft.EntityFrameworkCore.Migrations;

namespace API_MedikalSenter.Data
{
    public static class ExtraMigration
    {
        public static void Steps(MigrationBuilder migrationBuilder)
        {

            //Patient table triggers for concurrency
            migrationBuilder.Sql(
                @"
CREATE TRIGGER SetPatientTimeStampOnUpdate
AFTER UPDATE ON Patients
BEGIN 
UPDATE Patients
SET RowVersion = randomblob(8)
WHERE rowid = NEW.rowid;
END
");

            migrationBuilder.Sql(
           @"
CREATE TRIGGER SetPatientTimeStampOnInsert
AFTER INSERT ON Patients
BEGIN 
UPDATE Patients
SET RowVersion = randomblob(8)
WHERE rowid = NEW.rowid;
END
");

            //doctor table triggers for concurrency
            migrationBuilder.Sql(
                @"
CREATE TRIGGER SetDoctorTimeStampOnUpdate
AFTER UPDATE ON Doctors
BEGIN 
UPDATE Doctors
SET RowVersion = randomblob(8)
WHERE rowid = NEW.rowid;
END
");

            migrationBuilder.Sql(
           @"
CREATE TRIGGER SetDoctorTimeStampOnInsert
AFTER INSERT ON Doctors
BEGIN 
UPDATE Doctors
SET RowVersion = randomblob(8)
WHERE rowid = NEW.rowid;
END
");

        }
    }
}
