using Assi__04;
using BenchmarkDotNet.Running;
using System.Data;
using System.Globalization;
using System.Linq.Expressions;
using System.Text;
using static System.Collections.Specialized.BitVector32;

namespace Assi__04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] sessionNames = { "C# Basics", "Arrays", "Functions", "Date and Time", "Exception Handling" };
            DateTime[] sessionDates =
            {
                new DateTime(2026, 9, 10, 18, 0, 0),
                new DateTime(2026, 9, 13, 18, 0, 0),
                new DateTime(2026, 9, 17, 18, 0, 0),
                new DateTime(2026, 9, 20, 18, 0, 0),
                new DateTime(2026, 9, 24, 18, 0, 0)
            };
            int[] sessionDurations = { 180, 240, 180, 240, 180 };



            int option;
            do
            {
                Console.WriteLine();
                Console.WriteLine("===================================");
                Console.WriteLine("     Academy Schedule Analyzer     ");
                Console.WriteLine("===================================");
                Console.WriteLine();
                Console.WriteLine("1. Display all sessions");
                Console.WriteLine("2. Search for a session");
                Console.WriteLine("3. Sort session names");
                Console.WriteLine("4. Reverse session names");
                Console.WriteLine("5. Find session index");
                Console.WriteLine("6. Check if session exists");
                Console.WriteLine("7. Show duration statistics");
                Console.WriteLine("8. Show session date details");
                Console.WriteLine("9. Show past and upcoming sessions");
                Console.WriteLine("10. Find next session");
                Console.WriteLine("11. Compare two session dates");
                Console.WriteLine("12. Read and validate a custom date");
                Console.WriteLine("13. Select session by index");
                Console.WriteLine("14. Validate session duration");
                Console.WriteLine("15. Generate report using string");
                Console.WriteLine("16. Generate report using StringBuilder");
                Console.WriteLine("0. Exit");
                Console.WriteLine();
                option = ReadMenuOption();
                Console.WriteLine();
                switch (option)
                {
                    case 1:
                        DisplaySessions(sessionNames, sessionDates, sessionDurations);
                        break;
                    case 2:
                        SearchSession(sessionNames, sessionDates, sessionDurations);
                        break;
                    case 3:
                        SortSessionNames(sessionNames);
                        break;
                    case 4:
                        ReverseSessionNames(sessionNames);
                        break;
                    case 5:
                        FindSessionIndex(sessionNames);
                        break;
                    case 6:
                        CheckIfSessionExists(sessionNames);
                        break;
                    case 7:
                        DisplayDurationStatistics(sessionDurations);
                        break;
                    case 8:
                        DisplaySessionDetails(sessionDurations, sessionDates, sessionNames);
                        break;
                    case 9:
                        DisplayPastAndUpcomingSessions(sessionNames, sessionDates);
                        break;
                    case 10:
                        FindNextSession(sessionNames, sessionDates);
                        break;
                    case 11:
                        DisplaySessionDateDifference(sessionNames, sessionDates);
                        break;
                    case 12:
                        DateTime date = ReadSessionDate();
                        Console.WriteLine(date);
                        break;
                    case 13:
                        SelectSessionByIndex(sessionNames);
                        break;
                    case 14:
                        try
                        {
                            ValidateSessionDuration();
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            Console.WriteLine("Input operation finished.");
                        }
                        break;
                    case 15:
                        Console.WriteLine(BuildReportUsingString(sessionNames, sessionDates, sessionDurations));
                        break;
                    case 16:
                        Console.WriteLine(BuildReportUsingStringBuilder(sessionNames, sessionDates, sessionDurations));
                        break;
                    case 0:
                        Console.WriteLine("Finished");
                        break;
                }
            } while (option != 0);





            // part 4.5
            //FindSession(sessionNames);


            // part 4.6
            //FindSessionIndexByCondition(sessionNames);



            // part 4.7
            //DemonstrateArrayCopy(sessionNames);



            // part 7.1
            //int x = 10;
            //Console.WriteLine($"Before => x = {x}");
            //DoubleValue(ref x);
            //Console.WriteLine($"After => x = {x}");

            // part 7.2
            //int index = 0;
            //int duration = 0;
            //Console.Write("Enter session name: ");
            //string? sessionName = Console.ReadLine();
            //if (string.IsNullOrWhiteSpace(sessionName))
            //{
            //    Console.WriteLine("Session name cannot be null");
            //    return;
            //}
            //bool isFound = TryGetSessionIndexAndDuration(sessionName, sessionNames, sessionDurations, out index, out duration);
            //Console.WriteLine($"isFound ? {isFound}");


            // part 7.3
            //int[] numbers = [10, 20, 30];
            //Console.WriteLine();
            //Console.WriteLine("Before:");
            //foreach (var number in numbers)
            //{
            //    Console.WriteLine(number);
            //}
            //Console.WriteLine();
            //ModifyFirstArrayElement(numbers);
            //Console.WriteLine("After:");
            //foreach (var number in numbers)
            //{
            //    Console.WriteLine(number);
            //}


            // part 8
            //Console.WriteLine(CalculateTotalDuration(120, 180));
            //Console.WriteLine(CalculateTotalDuration(120, 180, 240));
            //Console.WriteLine(CalculateTotalDuration(60, 90, 120, 180, 240));


            // part 13
            //DisplaySessionDateFormats(sessionDates, sessionNames);

        }
        public static void DisplaySessions(string[] sessNames, DateTime[] sessDates, int[] sessDuration)
        {
            if (IsInvalidScheduleData(sessNames, sessDates, sessDuration))
                return;
            for (int i = 0; i < sessDates.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {sessNames[i]}");
                Console.WriteLine($"Date: {sessDates[i].ToString("dd MMMM yyyy")}");
                Console.WriteLine($"Start Time: {sessDates[i].ToString("hh:mm tt")}");
                Console.WriteLine($"Duration: {sessDuration[i]} minutes");
                Console.WriteLine();
            }
        }
        private static bool IsInvalidScheduleData(string[] sessNames, DateTime[] sessDates, int[] sessDuration)
        {
            return sessNames is null || sessDates is null || sessDuration is null || sessNames.Length <= 0 || sessDates.Length <= 0 || sessDuration.Length <= 0;
        }
        public static void SearchSession(string[] sessNames, DateTime[] sessDates, int[] sessDuration)
        {
            Console.Write("Enter session name: ");
            string? sessName = Console.ReadLine();
            if (IsInvalidScheduleData(sessNames, sessDates, sessDuration))
                return;
            if (sessName is null)
                return;
            int indexOfSess = Array.IndexOf(sessNames, sessName);
            if (indexOfSess >= 0)
            {
                Console.WriteLine($"{sessNames[indexOfSess]}");
                Console.WriteLine($"Date: {sessDates[indexOfSess].ToString("dd MMMM yyyy")}");
                Console.WriteLine($"Start Time: {sessDates[indexOfSess].ToString("hh:mm tt")}");
                Console.WriteLine($"Duration: {sessDuration[indexOfSess]} minutes");
            }
            else
                Console.WriteLine("Session not found.");
        }
        public static void SortSessionNames(string[] sessionNames)
        {
            if (sessionNames is null || sessionNames.Length <= 0)
                return;
            string[] copySessionNames = new string[sessionNames.Length];
            Array.Copy(sessionNames, copySessionNames, sessionNames.Length);
            Array.Sort(copySessionNames);
            foreach (string sessionName in copySessionNames)
            {
                Console.WriteLine(sessionName);
            }
        }
        public static void ReverseSessionNames(string[] sessionNames)
        {
            if (sessionNames is null || sessionNames.Length <= 0)
                return;
            string[] copySessionNames = new string[sessionNames.Length];
            Array.Copy(sessionNames, copySessionNames, sessionNames.Length);
            Array.Reverse(copySessionNames);
            foreach (string sessionName in copySessionNames)
            {
                Console.WriteLine(sessionName);
            }
        }
        public static int GetTotalDuration(int[] sessDuration)
        {
            if ((sessDuration is null || sessDuration.Length <= 0))
                return -1;
            int total = 0;
            foreach (var duration in sessDuration)
            {
                total += duration;
            }
            return total;
        }
        public static int GetShortestDuration(int[] sessDuration)
        {
            if ((sessDuration is null || sessDuration.Length <= 0))
                return -1;
            int shortest = sessDuration[0];
            foreach (var duration in sessDuration)
            {
                if (duration < shortest)
                    shortest = duration;
            }
            return shortest;
        }
        public static int GetLongestDuration(int[] sessDuration)
        {
            if ((sessDuration is null || sessDuration.Length <= 0))
                return -1;
            int longest = sessDuration[0];
            foreach (var duration in sessDuration)
            {
                if (duration > longest)
                    longest = duration;
            }
            return longest;
        }
        public static double GetAverageDuration(int[] sessDuration)
        {
            if ((sessDuration is null || sessDuration.Length <= 0))
                return -1;
            int total = 0;
            foreach (var duration in sessDuration)
            {
                total += duration;
            }
            return total / (double)sessDuration.Length;
        }
        public static void DisplayDurationStatistics(int[] sessionDutaions)
        {
            double averageDuration = GetAverageDuration(sessionDutaions);
            Console.WriteLine($"Average duration: {averageDuration}");
            int longestDuration = GetLongestDuration(sessionDutaions);
            Console.WriteLine($"Longest duration: {longestDuration}");
            int shortestDuration = GetShortestDuration(sessionDutaions);
            Console.WriteLine($"Shortest duration: {shortestDuration}");
            int totalDuration = GetTotalDuration(sessionDutaions);
            Console.WriteLine($"Total duration: {totalDuration}");
            Console.WriteLine();
            DisplaySortedDurations(sessionDutaions);
            Console.WriteLine();
        }
        public static void FindSessionIndex(string[] sessionNames)
        {
            Console.Write("Enter session name: ");
            string? sessionName = Console.ReadLine();
            if (sessionNames is null || sessionNames.Length <= 0 || sessionName is null)
            {
                return;
            }
            int index = Array.IndexOf(sessionNames, sessionName);
            if (index < 0)
            {
                Console.WriteLine("Session not found");
                return;
            }
            Console.WriteLine($"Index: {index}");
        }
        public static void CheckIfSessionExists(string[] sessionNames)
        {
            Console.Write("Enter session name: ");
            string? sessionName = Console.ReadLine();
            if (sessionNames is null || sessionNames.Length <= 0 || sessionName is null)
            {
                return;
            }
            if (Array.Exists(sessionNames, name => name == sessionName))
            {
                Console.WriteLine("Session exists.");
            }
            else
                Console.WriteLine("Session does not exist.");
        }
        public static void DisplaySortedDurations(int[] sessDuration)
        {
            if (!(sessDuration is null || sessDuration.Length <= 0))
            {
                int[] copiedSessionDurations = new int[sessDuration.Length];
                Array.Copy(sessDuration, copiedSessionDurations, sessDuration.Length);
                Array.Sort(copiedSessionDurations);
                Console.WriteLine();
                Console.WriteLine("Sorted Session Durations");
                Console.WriteLine();
                foreach (var session in copiedSessionDurations)
                {
                    Console.WriteLine(session);
                }
            }
        }
        public static void DoubleValue(ref int value)
        {
            value = value * 2;
        }
        public static bool TryGetSessionIndexAndDuration(string sessionName, string[] sessionNames, int[] Durations, out int index, out int duration)
        {
            index = 0;
            duration = 0;
            if (!(sessionNames is null || Durations is null || Durations.Length <= 0 || sessionNames.Length <= 0 || string.IsNullOrWhiteSpace(sessionName)))
            {
                for (int i = 0; i < sessionNames.Length; i++)
                {
                    if (sessionName == sessionNames[i])
                    {
                        index = i;
                        duration = Durations[i];
                        Console.WriteLine($"Index: {index}");
                        Console.WriteLine($"Duration: {duration}");
                        return true;
                    }
                }
            }
            Console.WriteLine("Session not found");
            return false;
        }
        public static void ModifyFirstArrayElement(int[] array)
        {
            array[0] = 100;
        }
        public static int CalculateTotalDuration(params int[] durations)
        {
            int sum = 0;
            foreach (var durtion in durations)
            {
                sum += durtion;
            }
            return sum;
        }
        public static void DisplaySessionDetails(int[] durations, DateTime[] sessionDate, string[] sessionNames)
        {
            Console.Write("Enter session name: ");
            string? sessionName = Console.ReadLine();
            if (IsInvalidSessionData(durations, sessionNames, sessionName))
                return;
            for (int i = 0; i < sessionNames.Length; i++)
            {
                if (sessionName == sessionNames[i])
                {
                    Console.WriteLine($"Date: {sessionDate[i].ToString("dd MMMM yyyy")}");
                    Console.WriteLine($"Day: {sessionDate[i].DayOfWeek}");
                    Console.WriteLine($"Year: {sessionDate[i].Year}");
                    Console.WriteLine($"Month: {sessionDate[i].Month}");
                    Console.WriteLine($"Day Number: {sessionDate[i].Day}");
                    Console.WriteLine($"Start Time: {sessionDate[i].ToString("hh:mm tt")}");
                    Console.WriteLine($"Duration: {durations[i]} minutes");
                    DateTime timeSession = sessionDate[i];
                    int duration = durations[i];
                    DateTime endTime = GetSessionEndTime(sessionDate[i], durations[i]);
                    Console.WriteLine($"End Time: {endTime.ToString("hh:mm tt")}");
                    return;
                }
            }
            Console.WriteLine("Session not found");
        }
        private static bool IsInvalidSessionData(int[] durations, string[] sessionNames, string? sessionName)
        {
            return string.IsNullOrWhiteSpace(sessionName) || durations is null || sessionNames is null || durations.Length <= 0 || sessionNames.Length <= 0;
        }
        public static void DisplaySessionDateDifference(string[] sessionNames, DateTime[] sessionDates)
        {
            Console.Write("Enter first session name: ");
            string? session01 = Console.ReadLine();
            Console.Write("Enter second session name: ");
            string? session02 = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(session01) || string.IsNullOrWhiteSpace(session02) || sessionNames is null || sessionDates is null || sessionNames.Length <= 0 || sessionDates.Length <= 0)
            {
                return;
            }
            bool issSeion01Exis = false;
            bool issSeion02Exis = false;
            DateTime sessionOne = default;
            DateTime sessionTwo = default;
            for (int i = 0; i < sessionNames.Length; i++)
            {
                if (sessionNames[i] == session01)
                {
                    sessionOne = sessionDates[i];
                    issSeion01Exis = true;
                }
                if (sessionNames[i] == session02)
                {
                    sessionTwo = sessionDates[i];
                    issSeion02Exis = true;
                }
            }
            if (issSeion01Exis && issSeion02Exis)
            {
                TimeSpan ts = default;
                if (sessionOne > sessionTwo)
                {
                    ts = sessionOne - sessionTwo;
                }
                else
                {
                    ts = sessionTwo - sessionOne;
                }
                Console.WriteLine();
                Console.WriteLine($"First session: {session01}");
                Console.WriteLine($"Second session: {session02}");
                Console.WriteLine("Difference:");
                Console.WriteLine($"{ts.TotalDays} days");
                Console.WriteLine($"{ts.TotalHours} hours");
            }
            else
            {
                Console.WriteLine("Session not found");
                return;
            }
        }
        public static void DisplayPastAndUpcomingSessions(string[] sessionNames, DateTime[] sessionDates)
        {
            if (sessionNames is null || sessionDates is null || sessionNames.Length <= 0 || sessionDates.Length <= 0)
            {
                return;
            }
            DateTime dtNow = DateTime.Now;
            for (int i = 0; i < sessionNames.Length; i++)
            {
                if (sessionDates[i] > dtNow)
                    Console.WriteLine($"{sessionNames[i]}: Upcoming");
                else
                    Console.WriteLine($"{sessionNames[i]}: Past");
            }
        }
        public static void FindNextSession(string[] sessionNames, DateTime[] sessionDates)
        {
            if (sessionNames is null || sessionDates is null || sessionDates.Length <= 0 || sessionNames.Length <= 0)
                return;

            DateTime dtNow = DateTime.Now;
            TimeSpan nearestDifference = TimeSpan.MaxValue;
            int nearestIndex = -1;
            for (int i = 0; i < sessionDates.Length; i++)
            {
                if (sessionDates[i] > dtNow)
                {
                    TimeSpan difference = sessionDates[i] - dtNow;
                    if (difference < nearestDifference)
                    {
                        nearestDifference = difference;
                        nearestIndex = i;
                    }
                }
            }
            if (nearestIndex == -1)
            {
                Console.WriteLine("Not found");
                return;
            }
            Console.WriteLine("Next session:");
            Console.WriteLine(sessionNames[nearestIndex]);
            Console.WriteLine(sessionDates[nearestIndex].ToString("dd MMMM yyyy"));
            Console.WriteLine(sessionDates[nearestIndex].ToString("hh:mm tt"));
            Console.WriteLine("Time remaining:");
            Console.WriteLine($"{(nearestDifference).Days} Days");
            Console.WriteLine($"{(nearestDifference).Hours} Hours");
            return;
        }
        public static void DisplaySessionDateFormats(DateTime[] sessionDates, string[] sessionNames)
        {
            Console.Write("Enter session name: ");
            string? sessionName = Console.ReadLine();
            if (sessionNames is null || sessionNames.Length <= 0 || string.IsNullOrWhiteSpace(sessionName) || sessionDates is null || sessionDates.Length <= 0)
                return;
            for (int i = 0; i < sessionNames.Length; i++)
            {
                if (sessionNames[i] == sessionName)
                {
                    Console.WriteLine(sessionDates[i].ToString("yyyy-MM-dd"));
                    Console.WriteLine(sessionDates[i].ToString("dd/MM/yyyy"));
                    Console.WriteLine(sessionDates[i].ToString("dd MMMM yyyy"));
                    Console.WriteLine(sessionDates[i].ToString("dddd, dd MMMM yyyy"));
                    Console.WriteLine(sessionDates[i].ToString("hh:mm tt"));
                    return;
                }
            }
            Console.WriteLine("Session not found");
        }
        public static DateTime ReadSessionDate()
        {
            bool isParsed = false;
            DateTime dateTime;
            do
            {
                Console.Write("Enter DateTime(yyyy-MM-dd HH:mm): ");
                isParsed = DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime);
            } while (!isParsed);
            Console.WriteLine("Valid DateTime Format");
            return dateTime;
        }
        public static int ReadMenuOption()
        {
            Console.Write("Choose an option: ");
            while (true)
            {
                try
                {
                    string? option = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(option))
                    {
                        Console.WriteLine("Invalid menu option");
                        Console.Write("Try again: ");
                        continue;
                    }
                    int optionNumber = int.Parse(option);
                    if (optionNumber < 0)
                    {
                        Console.WriteLine("Option can not be negative");
                        Console.Write("Try again: ");
                        continue;
                    }
                    return optionNumber;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid menu option.");
                    Console.Write("Enter a number: ");
                }
            }
        }
        public static void SelectSessionByIndex(string[] sessionNames)
        {
            if (sessionNames is null || sessionNames.Length <= 0)
                return;
            Console.Write("Enter session index: ");
            bool isParsed = int.TryParse(Console.ReadLine(), out int sessionIndex);
            if (!isParsed)
            {
                Console.WriteLine("Invalid input");
                return;
            }
            try
            {
                Console.WriteLine($"Session: {sessionNames[sessionIndex]}");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("The selected session index is out of range.");
            }
        }
        public static void ValidateSessionDuration()
        {
            Console.Write("Enter duration: ");
            bool isParsed = int.TryParse(Console.ReadLine(), out int duration);
            if (!isParsed)
            {
                Console.WriteLine("Invalid input");
                return;
            }
            if (duration > 0)
                Console.WriteLine("Duration accepted");
            else
                throw new ArgumentException("Duration must be greater than zero.");
        }
        public static string? BuildReportUsingString(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
        {
            if (IsInvalidReportData(sessionNames, sessionDates, sessionDurations))
                return null;
            string msg = "";
            for (int i = 0; i < sessionNames.Length; i++)
            {
                msg += sessionNames[i] + " - " + sessionDates[i].ToString("dd/MM/yyyy hh:mm tt") + " - " + sessionDurations[i].ToString() + " minutes\n";
            }
            return msg;
        }
        private static bool IsInvalidReportData(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
        {
            return sessionNames is null || sessionDates is null || sessionDurations is null || sessionNames.Length <= 0 || sessionDates.Length <= 0 || sessionDurations.Length <= 0;
        }
        public static string? BuildReportUsingStringBuilder(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
        {
            if (IsInvalidReportData(sessionNames, sessionDates, sessionDurations))
                return null;
            StringBuilder msg = new StringBuilder();
            for (int i = 0; i < sessionNames.Length; i++)
            {
                msg.AppendLine(sessionNames[i] + " - " + sessionDates[i].ToString("dd/MM/yyyy hh:mm tt") + " - " + sessionDurations[i].ToString() + " minutes");
            }
            return msg.ToString();
        }
        public static DateTime GetSessionEndTime(DateTime startTime, int duration)
        {
            return startTime.AddMinutes(duration);
        }
        public static void FindSession(string[] sessionNames)
        {
            Console.Write("Enter session name: ");
            string? sessionName = Console.ReadLine();
            if (sessionNames is null || sessionNames.Length <= 0 || string.IsNullOrWhiteSpace(sessionName))
                return;
            string? foundSession = Array.Find(sessionNames, name => name == sessionName);
            if (foundSession == default)
            {
                Console.WriteLine("Session not found");
                return;
            }
            Console.WriteLine($"Session name: {sessionName}");
        }
        public static void FindSessionIndexByCondition(string[] sessionNames)
        {
            Console.Write("Enter session name: ");
            string? sessionName = Console.ReadLine();
            if (sessionNames is null || sessionNames.Length <= 0 || string.IsNullOrWhiteSpace(sessionName))
                return;
            int index = Array.FindIndex(sessionNames, name => name == sessionName);
            if (index == -1)
            {
                Console.WriteLine("Session not found");
                return;
            }
            Console.WriteLine($"Index: {index}");
        }
        public static void DemonstrateArrayCopy(string[] sessionNames)
        {
            if (sessionNames is null || sessionNames.Length <= 0)
                return;
            string[] copySessionNames = new string[sessionNames.Length];
            Array.Copy(sessionNames, copySessionNames, sessionNames.Length);
            copySessionNames[0] = "C++";
            Console.WriteLine("After change:\n");
            Console.WriteLine("Original array\n");
            foreach (string sessionName in sessionNames)
            {
                Console.WriteLine(sessionName);
            }
            Console.WriteLine();
            Console.WriteLine("Copied array\n");
            foreach (string sessionName in copySessionNames)
            {
                Console.WriteLine(sessionName);
            }
        }

    }
}
