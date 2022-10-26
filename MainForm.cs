using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace approx_visualization
{
    public partial class MainForm : Form
    {
        public class Bresenham_Int
        {
            public Point p1, p2;

            public Bresenham_Int(Point p1, Point p2)
            {
                this.p1 = p1;
                this.p2 = p2;
            }

            public Point[] getPoints()
            {
                int ydiff = p2.Y - p1.Y, xdiff = p2.X - p1.X;
                int c = (int)Math.Sqrt(Math.Pow(xdiff, 2) + Math.Pow(ydiff, 2));
                var points = new Point[c];
                
                double x, y;

                points[0] = p1;

                for (double i = 1; i < c-1; i++)
                {
                    y = ydiff * (i / c);
                    x = xdiff * (i / c);
                    points[(int)i] = new Point((int)Math.Round(x) + p1.X, (int)Math.Round(y) + p1.Y);
                }

                points[c - 1] = p2;

                return points;
            }
        }

        private int fieldSize = 50;
        private int fieldCount = 1000 / 50;
        private bool[,] map;
        private bool draw = false;
        private Graphics graphics;
        private Pen pen;
        private int x = -1;
        private int y = -1;
        private int hold_x = -1;
        private int hold_y = -1;

        public MainForm()
        {
            InitializeComponent();
            graphics = panel.CreateGraphics();
            pen = new Pen(Color.White, 1);
            map = new bool[1000, 1000];
        }


        //obsluga panelu
        //przygotowanie do rysowania
        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            draw = true;
            x = e.X;
            y = e.Y;
            hold_x = e.X;
            hold_y = e.Y;
            map[x, y] = true;
        }
        //rysowanie
        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            if(draw && x!=-1 && y != -1)
            {
                graphics.DrawLine(pen,new Point(x,y), e.Location);
                x = e.X;
                y = e.Y;
                map[x, y] = true;
            }
        }
        //rysowanie wykonczenie
        private void panel_MouseUp(object sender, MouseEventArgs e)
        {
            graphics.DrawLine(pen, e.Location, new Point(hold_x, hold_y));
            Point[] bresenham = (new Bresenham_Int(new Point(e.X, e.Y), new Point(hold_x, hold_y)).getPoints());

            for(int i = 0; i < bresenham.Length; i++)
            {
                map[bresenham[i].X, bresenham[i].Y] = true;
            }

            draw = false;
            x = -1;
            y = -1;
            hold_x = -1;
            hold_y = -1;

        }
        //inicjalizacyjna kratka
        private void panel_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Graphics g = e.Graphics)
            {
                for (int i = 0; i < fieldCount; i++)
                {
                    graphics.DrawLine(new Pen(Color.DarkBlue, 1), new Point(0, i * fieldSize), new Point(1000, i * fieldSize));
                    graphics.DrawLine(new Pen(Color.DarkBlue, 1), new Point(i * fieldSize, 0), new Point(i * fieldSize, 1000));
                }
            }
        }

        private void draw_x(int _x, int _y, Color _c, float _s)
        {
            graphics.DrawLine(new Pen(_c, _s), new Point(_x * fieldSize, _y * fieldSize), new Point((_x + 1) * fieldSize, (_y + 1) * fieldSize));
            graphics.DrawLine(new Pen(_c, _s), new Point((_x + 1) * fieldSize, _y * fieldSize), new Point(_x * fieldSize, (_y + 1) * fieldSize));
        }

        //wyznaczanie obszaru brzegowego
        private bool analyze(int x,int y)
        {
            for(int i = 0; i < fieldSize; i++)
            {
                for(int j = 0; j < fieldSize; j++)
                {
                    if (map[x*fieldSize + i, y*fieldSize + j]) return true;
                }
            }
            return false;
        }

        private void EdgeArea(object sender, EventArgs e)
        {
            _edgeArea(Color.Orange,5);
        }

        private void _edgeArea(Color c,int s)
        {
            for (int i = 0; i < fieldCount; i++)
            {
                for (int j = 0; j < fieldCount; j++)
                {
                    if (analyze(i, j))
                    {
                        draw_x(i, j, c, s);
                    }
                }
            }
        }

        private void NegativeArea(object sender, EventArgs e)
        {
            _negativeArea(Color.Crimson,1);
        }


        private void _negativeArea(Color c, int s)
        {
            //definiujemy ograniczniki w przestrzeni 2D
            int[] lock_up = new int[fieldCount];
            int[] lock_left = new int[fieldCount];
            int[] lock_down = new int[fieldCount];
            int[] lock_right = new int[fieldCount];
            bool flag_up = false;
            bool flag_left = false;
            bool flag_down = false;
            bool flag_right = false;

            //przegladamy tablice pasami pionowymi, definiujemy ograniczniki gora dol dla kazdego pola
            for (int i = 0; i < fieldCount; i++)
            {
                for (int j = 0; j < fieldCount; j++)
                {
                    if (analyze(i, j) && !flag_up)
                    {
                        lock_up[i] = j;
                        flag_up = true;
                    }
                    if (j != 0)
                    {
                        if (analyze(i, fieldCount - j) && !flag_down)
                        {
                            lock_down[i] = fieldCount - j;
                            flag_down = true;
                        }

                    }

                }
                flag_up = false;
                flag_down = false;
            }
            //przegladamy przestrzen pasami poziomymi, definiujemy ograniczniki lewo prawo dla kazdego pola
            for (int i = 0; i < fieldCount; i++)
            {
                for (int j = 0; j < fieldCount; j++)
                {
                    if (analyze(j, i) && !flag_left)
                    {
                        lock_left[i] = j;
                        flag_left = true;
                    }
                    if (j != 0)
                    {
                        if (analyze(fieldCount - j, i) && !flag_right)
                        {
                            lock_right[i] = fieldCount - j;
                            flag_right = true;
                        }
                    }
                }
                flag_left = false;
                flag_right = false;
            }

            //przegladamy przestrzen uwzgledniajac ograniczniki
            for (int i = 0; i < fieldCount; i++)
            {
                for (int j = 0; j < fieldCount; j++)
                {
                    if (!analyze(i, j) && ((lock_up[i] >= j || j >= lock_down[i]) || (lock_left[j] >= i || i >= lock_right[j]))) draw_x(i, j, c, s);
                }
            }
        }


        private void positiveArea(object sender, EventArgs e)
        {
            _positiveArea(Color.DarkGreen,1);
        }

        private void _positiveArea(Color c, int s)
        {
            //definiujemy ograniczniki w przestrzeni 2D
            int[] lock_up = new int[fieldCount];
            int[] lock_left = new int[fieldCount];
            int[] lock_down = new int[fieldCount];
            int[] lock_right = new int[fieldCount];
            bool flag_up = false;
            bool flag_left = false;
            bool flag_down = false;
            bool flag_right = false;

            //przegladamy tablice pasami pionowymi, definiujemy ograniczniki gora dol dla kazdego pola
            for (int i = 0; i < fieldCount; i++)
            {
                for (int j = 0; j < fieldCount; j++)
                {
                    if (analyze(i, j) && !flag_up)
                    {
                        lock_up[i] = j;
                        flag_up = true;
                    }
                    if (j != 0)
                    {
                        if (analyze(i, fieldCount - j) && !flag_down)
                        {
                            lock_down[i] = fieldCount - j;
                            flag_down = true;
                        }

                    }

                }
                flag_up = false;
                flag_down = false;
            }
            //przegladamy przestrzen pasami poziomymi, definiujemy ograniczniki lewo prawo dla kazdego pola
            for (int i = 0; i < fieldCount; i++)
            {
                for (int j = 0; j < fieldCount; j++)
                {
                    if (analyze(j, i) && !flag_left)
                    {
                        lock_left[i] = j;
                        flag_left = true;
                    }
                    if (j != 0)
                    {
                        if (analyze(fieldCount - j, i) && !flag_right)
                        {
                            lock_right[i] = fieldCount - j;
                            flag_right = true;
                        }
                    }
                }
                flag_left = false;
                flag_right = false;
            }

            //przegladamy przestrzen uwzgledniajac ograniczniki
            for (int i = 0; i < fieldCount; i++)
            {
                for (int j = 0; j < fieldCount; j++)
                {
                    if (!analyze(i, j) && ((lock_up[i] < j && j < lock_down[i]) && (lock_left[j] < i && i < lock_right[j]))) draw_x(i, j, c, s);
                }
            }
        }

        private void infArea(object sender, EventArgs e)
        {
            _positiveArea(Color.LightBlue, 3);
        }

        private void supArea(object sender, EventArgs e)
        {
            _positiveArea(Color.LightCoral, 3);
            _edgeArea(Color.LightCoral, 3);
        }
    }
}
