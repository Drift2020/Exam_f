﻿using Google.Apis.Auth.OAuth2;
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


        public CalendarService service=null;
      
        //public void Login2()
        //{


        //    GoogleSignInOptions gso = new GoogleSignInOptions.Builder(GoogleSignInOptions.DEFAULT_SIGN_IN)
        //.requestEmail()
        //.build();

        //    // Build a GoogleSignInClient with the options specified by gso.
        //    mGoogleSignInClient = GoogleSignIn.getClient(this, gso);


        //    // Check for existing Google Sign In account, if the user is already signed in
        //    // the GoogleSignInAccount will be non-null.
        //    GoogleSignInAccount account = GoogleSignIn.getLastSignedInAccount(this);
        //    updateUI(account);
        //}

        UserCredential credential;
        public void Login()
        {
           


            string[] Scopes = { CalendarService.Scope.Calendar };
            string ApplicationName = "Google Calendar API .NET Quickstart";



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
        public ObservableCollection<NowDate> Set_events( DateTime days, out string Logins)
        {
            try
            {
                EventsResource.ListRequest request = service.Events.List("primary");
                request.TimeMin = new DateTime(days.Year, days.Month, days.Day, 0, 0, 0);
                request.TimeMax = new DateTime(days.Year, days.Month, days.Day, 23, 59, 59);
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

                        bool temp = eventItem.Start.DateTime == eventItem.End.DateTime;





                        My_list.Add(new NowDate()
                        {
                            Summary = eventItem.Summary,
                            TimeStart = eventItem.Start.DateTime,
                            TimeEnd = eventItem.End.DateTime,
                            Time = eventItem.Start.DateTime == null ? null : eventItem.Start.DateTime == eventItem.End.DateTime ? String.Format("{0}:{1}",
                                 (eventItem.Start.DateTime.Value.Hour > 9 ? eventItem.Start.DateTime.Value.Hour.ToString() : "0" + eventItem.Start.DateTime.Value.Hour.ToString()),
                                  (eventItem.Start.DateTime.Value.Minute > 9 ? eventItem.Start.DateTime.Value.Minute.ToString() : "0" + eventItem.Start.DateTime.Value.Minute.ToString()))
                                  : String.Format("{0}:{1} - {2}:{3}",
                                 (eventItem.Start.DateTime.Value.Hour > 9 ? eventItem.Start.DateTime.Value.Hour.ToString() : "0" + eventItem.Start.DateTime.Value.Hour.ToString()),
                                  (eventItem.Start.DateTime.Value.Minute > 9 ? eventItem.Start.DateTime.Value.Minute.ToString() : "0" + eventItem.Start.DateTime.Value.Minute.ToString()),
                                  (eventItem.End.DateTime.Value.Hour > 9 ? eventItem.End.DateTime.Value.Hour.ToString() : "0" + eventItem.End.DateTime.Value.Hour.ToString()),
                                  (eventItem.End.DateTime.Value.Minute > 9 ? eventItem.End.DateTime.Value.Minute.ToString() : "0" + eventItem.End.DateTime.Value.Minute.ToString())

                                  ),
                            Location = eventItem.Location?.ToString(),
                            Description = eventItem.Description?.ToString(),
                            IsAll = temp,
                            Id = eventItem.Id

                        });

                    }
                }
                return My_list;
            }
            catch (Exception ex)
            {
              
                Log.Write(ex);
                Logins = "";
                return null;
#if test
                        System.Windows.MessageBox.Show(ex.Message, "Set_events end");
#endif
            }
           
        }

        public Event GetEvent(string id)
        {          
            return service.Events.Get("primary", id).Execute();
        }
        public void Delete_event(string eventId)
        {
            service.Events.Delete("primary", eventId).Execute();
        }

        public void Edit_event(bool isAll, string _Summary, string _Location, string _Description, DateTime? Start, DateTime? End, string idevent)
        {

            try
            {
            
                   
               

                // Update the event
                


                String calendarId = "primary";
                Event newEvent = service.Events.Get(calendarId, idevent).Execute();

              

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
                        {//"2009/02/26 18:37:58"
                            DateTime = DateTime.Parse(String.Format("{0}/{1}/{2} {3}:{4}:00",
                   Start.Value.Year.ToString(),
                   Start.Value.Month > 9 ? Start.Value.Month.ToString() : "0" + Start.Value.Month.ToString(),
                    Start.Value.Day > 9 ? Start.Value.Day.ToString() : "0" + Start.Value.Day.ToString(),
                   (Start.Value.Hour > 9 ? Start.Value.Hour.ToString() : "0" + Start.Value.Hour.ToString()),
                   (Start.Value.Minute > 9 ? Start.Value.Minute.ToString() : "0" + Start.Value.Minute.ToString()))),



                        },
                        End = new EventDateTime()
                        {//"2019-03-06"
                            DateTime = DateTime.Parse(String.Format("{0}/{1}/{2} {3}:{4}:00",
                   End.Value.Year.ToString(),
                   End.Value.Month > 9 ? End.Value.Month.ToString() : "0" + End.Value.Month.ToString(),
                    End.Value.Day > 9 ? End.Value.Day.ToString() : "0" + End.Value.Day.ToString(),

                   (End.Value.Hour > 9 ? End.Value.Hour.ToString() : "0" + End.Value.Hour.ToString()),
                   (End.Value.Minute > 9 ? End.Value.Minute.ToString() : "0" + End.Value.Minute.ToString()))),

                        },

                    };
              

                Event updatedEvent = service.Events.Update(newEvent, calendarId, idevent).Execute();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                {//"2009/02/26 18:37:58"
                    DateTime = DateTime.Parse(String.Format("{0}/{1}/{2} {3}:{4}:00",
                   Start.Value.Year.ToString(),
                   Start.Value.Month > 9 ? Start.Value.Month.ToString() : "0" + Start.Value.Month.ToString(),
                    Start.Value.Day > 9 ? Start.Value.Day.ToString() : "0" + Start.Value.Day.ToString(),
                   (Start.Value.Hour > 9 ? Start.Value.Hour.ToString() : "0" + Start.Value.Hour.ToString()),
                   (Start.Value.Minute > 9 ? Start.Value.Minute.ToString() : "0" + Start.Value.Minute.ToString()))),



                },
                End = new EventDateTime()
                {//"2019-03-06"
                    DateTime = DateTime.Parse(String.Format("{0}/{1}/{2} {3}:{4}:00",
                   End.Value.Year.ToString(),
                   End.Value.Month > 9 ? End.Value.Month.ToString() : "0" + End.Value.Month.ToString(),
                    End.Value.Day > 9 ? End.Value.Day.ToString() : "0" + End.Value.Day.ToString(),
             
                   (End.Value.Hour > 9 ? End.Value.Hour.ToString() : "0" + End.Value.Hour.ToString()),
                   (End.Value.Minute > 9 ? End.Value.Minute.ToString() : "0" + End.Value.Minute.ToString()))),
                   
                },

            };
                //Event newEvent = new Event()
                //{
                //    Summary = "Google I/O 2015",
                //    Location = "800 Howard St., San Francisco, CA 94103",
                //    Description = "A chance to hear more about Google's developer products.",
                //    Start = new EventDateTime()
                //    {
                //        DateTime = DateTime.Parse("2015-05-28T09:00:00-07:00"),
                //        TimeZone = "America/Los_Angeles",
                //    },
                //    End = new EventDateTime()
                //    {
                //        DateTime = DateTime.Parse("2015-05-28T17:00:00-07:00"),
                //        TimeZone = "America/Los_Angeles",
                //    },
                //};

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
