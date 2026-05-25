using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GuessTheMovie
{
    public class ResultList
    {

        public ObservableCollection<Result> Results { get; set; }

        public ResultList()
        {
            Results = new ObservableCollection<Result>
        {
           // new Result { Name = "Lionel Messi", Team = "Inter Miami" },
          //  new Result { Name = "Cristiano Ronaldo", Team = "Al Nassr" },
          //  new Result { Name = "Kylian Mbappé", Team = "Real Madrid" }
        };
        }


    }
}
