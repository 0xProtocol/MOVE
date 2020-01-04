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

        public string PlayerName { get => _playerName; set => _playerName = value; }
        public int Points { get => _points; set => _points = value; }

        public Score(string playerName, int points)
        {
            _playerName = playerName;
            _points = points;
        }

        public override string ToString()
        {
            return $"{_playerName}; {_points}";
        }
    }
}
