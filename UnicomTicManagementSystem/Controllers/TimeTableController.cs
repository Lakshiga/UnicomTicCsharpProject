using System.Data;
using System.Data.SQLite;
using UnicomTicManagementSystem.Data;

namespace UnicomTicManagementSystem.Controllers
{
    public class TimetableController
    {
        private readonly TimeTableRepository repository = new TimeTableRepository();

        public DataTable GetSubjects()
        {
            using (var conn = DbCon.GetConnection())
            {
                string query = "SELECT SubjectName FROM Subjects"; // change table/column names if needed
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    using (var adapter = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public DataTable GetAllTimetables()
        {
            return repository.GetAllTimeTables();
        }

        public void AddTimetable(string subject, string timeSlot, string room)
        {
            repository.AddTimeTable(subject, timeSlot, room);
        }

        public void UpdateTimetable(int id, string subject, string timeSlot, string room)
        {
            repository.UpdateTimeTable(id, subject, timeSlot, room);
        }

        public void DeleteTimetable(int id)
        {
            repository.DeleteTimeTable(id);
        }
    }
}
