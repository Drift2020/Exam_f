using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Time.Model;

namespace Time.Code
{
    class GoogleAPI
    {


        public CalendarService service;
        public void Login()
        {



            string[] Scopes = { CalendarService.Scope.Calendar };
            string ApplicationName = "Google Calendar API .NET Quickstart";


            UserCredential credential;

            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Google Calendar API service.
            service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });



            



        }
        public ObservableCollection<NowDate> Set_events(string i, DateTime days, out string Logins)
        {
            EventsResource.ListRequest request = service.Events.List("primary");
            request.TimeMin = new DateTime(days.Year, days.Month, days.Day, 0, 0, 0);
            request.TimeMax = new DateTime(days.Year, days.Month, days.Day, 23, 0, 0);
            request.ShowDeleted = false;
            request.SingleEvents = true;
            //  request.MaxResults = int.Parse(i);
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // List events.
            Events events = request.Execute();

            ObservableCollection<NowDate> My_list = new ObservableCollection<NowDate>();

            Logins = events.Summary;
            if (events.Items != null && events.Items.Count > 0)
            {
                foreach (var eventItem in events.Items)
                {

                    My_list.Add(new NowDate() { Name = eventItem.Summary, Time = eventItem.Start.DateTime.ToString() });
                   
                }
            }
            return My_list;
        }

        public void Add_event(bool isAll,string _Summary,string _Location,string _Description, DateTime? Start, DateTime? End)
        {
            try
            {
                Event newEvent = null;
         if (isAll)
                    newEvent = new Event()
                    {

                        Summary = _Summary,
                        Location = _Location,
                        Description = _Description,
                        Start = new EventDateTime()
                        {
                            Date = Start.Value.Year.ToString() + "-" + Start.Value.Month.ToString() + '-' + Start.Value.Day.ToString(),
                           

                        },
                        End = new EventDateTime()
                        {//"2019-03-06"
                            Date = Start.Value.Year.ToString() + "-" + Start.Value.Month.ToString() + '-' + Start.Value.Day.ToString(),
                          
                        },

                    };
                else
             newEvent = new Event()
            {

                Summary = _Summary,
                Location = _Location,
                Description = _Description,
                Start = new EventDateTime()
                {
                    Date = Start.Value.Year.ToString()+"-"+ Start.Value.Month.ToString()+'-'+ Start.Value.Day.ToString(), DateTime = Start

                },
                End = new EventDateTime()
                {//"2019-03-06"
                    Date = End.Value.Year.ToString() + "-" + End.Value.Month.ToString() + '-' + End.Value.Day.ToString(), DateTime = End
                },

            };

                
            String calendarId = "primary";
            EventsResource.InsertRequest request = service.Events.Insert(newEvent, calendarId);
            Event createdEvent = request.Execute();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
