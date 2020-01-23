using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOVE.Server.Debug.Formular
{
    class Score
    {
        string _playerName;
        int _points;
        DateTime _dateTime;

        public string PlayerName
        {
            get
            {
                return _playerName;
            }

            set
            {
                _playerName = value;
            }
        }

        public int Points
        {
            get
            {
                return _points;
            }

            set
            {
                _points = value;
            }
        }

        public DateTime DateTime
        {
            get
            {
                return _dateTime;
            }

            set
            {
                _dateTime = value;
            }
        }

        public Score(string playerName, int points, DateTime dateTime)
        {
            _playerName = playerName;
            _points = points;
            _dateTime = dateTime;
        }

        public override string ToString()
        {
            return $"{_playerName}; {_points}; {_dateTime}";
        }
    }
}
