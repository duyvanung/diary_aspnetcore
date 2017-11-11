using diary.Models;
using System;
using System.Linq;

namespace diary.Data
{
      public static class DbInitializer
      {
            public static void Initialize(diaryContext context)
            {
                  if (context.Users.Any())
                  {
                        return;
                  }

                  var users = new User[]
                  {
                        new User
                        {
                              ID = 1,
                              FirstName = "Khoa",
                              LastName = "Nguyen Anh",
                              Email = "khoa@oop.bk16.com",
                              Brithday = DateTime.Parse("1/1/1998"),
                              Username = "khoa",
                              Password = "123456",
                        },
                        new User
                        {
                              ID = 2,
                              FirstName = "Khoi",
                              LastName = "Tran Dang",
                              Email = "khoi@oop.bk16.com",
                              Brithday = DateTime.Parse("2/2/1998"),
                              Username = "khoi",
                              Password = "123456",
                        },
                        new User
                        {
                              ID = 3,
                              FirstName = "Duy",
                              LastName = "Ung Van",
                              Email = "duy@oop.bk16.com",
                              Brithday = DateTime.Parse("3/3/1998"),
                              Username = "duy",
                              Password = "123456",
                        },
                        new User
                        {
                              ID = 4,
                              FirstName = "Chi",
                              LastName = "Le Vinh",
                              Email = "chi@oop.bk16.com",
                              Brithday = DateTime.Parse("4/4/1998"),
                              Username = "chi",
                              Password = "123456",
                        }
                  };
                  // add user to database
                  foreach (User u in users)
                        context.Add(u);
                  context.SaveChanges();

                  var events = new Event[]
                  {
                        new Event
                        {
                              ID = 1,
                              UserID = 1,
                              Info = "Birthday",
                              StartDate = DateTime.Parse("1/1/2017"),
                              EndDate = DateTime.Parse("2/1/2017"),
                              Occurrence = Occurrency.once_a_year
                        },
                        new Event
                        {
                              ID = 2,
                              UserID = 2,
                              Info = "Birthday",
                              StartDate = DateTime.Parse("2/2/2017"),
                              EndDate = DateTime.Parse("3/2/2017"),
                              Occurrence = Occurrency.once_a_year
                        },
                        new Event
                        {
                              ID = 3,
                              UserID = 3,
                              Info = "Birthday",
                              StartDate = DateTime.Parse("3/3/2017"),
                              EndDate = DateTime.Parse("4/3/2017"),
                              Occurrence = Occurrency.once_a_year
                        },
                        new Event
                        {
                              ID = 4,
                              UserID = 4,
                              Info = "Birthday",
                              StartDate = DateTime.Parse("4/4/2017"),
                              EndDate = DateTime.Parse("5/4/2017"),
                              Occurrence = Occurrency.once_a_year
                        }
                  };
                  // add user to database
                  foreach (Event e in events)
                        context.Add(e);
                  context.SaveChanges();


                  var entries = new Entry[]
                  {
                        new Entry
                        {
                              ID = 1,
                              UserID = 1,
                              Content = "Di cong tac xa hoi",
                              Date = DateTime.Parse("11/11/2017"),
                              Mood = Mood.happy
                        },
                        new Entry
                        {
                              ID = 2,
                              UserID = 2,
                              Content = "Hoc oop",
                              Date = DateTime.Parse("11/11/2017"),
                              Mood = Mood.normal
                        },
                        new Entry
                        {
                              ID = 3,
                              UserID = 3,
                              Content = "On fackbook khuya",
                              Date = DateTime.Parse("11/11/2017"),
                              Mood = Mood.normal
                        },
                        new Entry
                        {
                              ID = 4,
                              UserID = 4,
                              Content = "Mat tieu",
                              Date = DateTime.Parse("11/11/2017"),
                              Mood = Mood.normal
                        }
                  };
                  // add user to database
                  foreach (Entry e in entries)
                        context.Add(e);
                  context.SaveChanges();
            }
      }
}