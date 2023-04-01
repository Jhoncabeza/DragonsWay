namespace DragonsWay.Logic
{
    public class Game
    {
        private char[,] _game;
        private bool _win;
        private string _text;
        public Game(int n, string text)
        {
            N = n;
            _text = text;
            _game = new char[N, N * 2];
            FillMaze(text);
        }

        public int N { get; }

        public bool Win { get => _win; set => _win = value; }

        public override string ToString()
        {
            var output = string.Empty;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N * 2; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        output += $" ";

                        for (int k = 0; k < N; k++)
                        {
                            output += k.ToString();
                        }

                        for (int k = 0; k < N; k++)
                        {
                            output += k.ToString();
                        }
                        output += $"\n{i}";

                    }
                    output += $"{_game[i, j]}";
                }
                if (i >= 0 && i < 9)
                {
                    output += $"\n{i + 1}";
                }
            }
            return output;
        }


        private void FillMaze(string text)
        {
            FillBorders();
            _win = TravelGame(text);
        }

        private void FillBorders()
        {

            int nC = N * 2;
            int nF = N - 1;
            char wall = char.Parse("█");
            char floorUp = char.Parse("▀");
            char floorDown = char.Parse("▄");



            //horizontal ->

            for (int i = 0; i < nC - 1; i++)
            {
                _game[0, i] = floorUp;
                _game[nF, i] = floorDown;
            }

            ////whiteboard space

            for (int i = 0; i < nC - 1; i++)
            {
                _game[1, i] = ' ';
            }

            _game[1, 19] = '█';

            //vertical !

            for (int i = 1; i < nF - 1; i++)
            {
                _game[i + 1, 0] = wall;
                _game[i, nC - 1] = wall;
            }

            for (int i = 2; i < nF - 1; i++)
            {
                for (int j = 1; j < nC - 1; j++)
                {
                    _game[i, j] = ' ';
                }

            }

            for (int i = 1; i < nC; i++)
            {
                _game[nF - 1, i] = ' ';
            }

            //corners
            _game[0, 0] = char.Parse("█");
            _game[0, nC - 1] = char.Parse("█");
            _game[nF, 0] = char.Parse("█");
            _game[nF, nC - 1] = char.Parse("█");
        }


        private bool TravelGame(string text)
        {
            char[] arrayText = text.ToCharArray();

            bool flag = true;
            int row = 1;
            int column = 0;
            int k = 0;
            char _rigth = char.Parse("→");
            char _bottom = char.Parse("↓");
            char wall = '█';
            int rigth = 1;
            int bottom = 1;



            while (flag && !(row == N - 2 && column == N * 2 - 1))
            {
                if (_game[row, column] == wall)
                {
                    flag = false;
                    return false;
                }
                else if (arrayText[k] == _rigth)
                {
                    _game[row, column] = _rigth;
                    column += rigth;
                }
                else if (arrayText[k] == _bottom)
                {
                    _game[row, column] = _bottom;
                    row += bottom;
                }
                else
                {
                    flag = false;
                }

                k++;
            }
            return true;
        }
    }


}