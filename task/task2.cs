using static System.Console;
class Point_3d{
    int x;
    int y;
    int z;
    public Point_3d(int dist_x,int dist_y,int dist_z){
        x=dist_x;
        y=dist_y;
        z=dist_z;
    }
    public dynamic ask_distance_to(Point_3d Maldives)//:)
    {
        //### Формула = корень из суммы квадратов разниц координат точек по каждой из осей
        double distance;
        distance=Math.Round(
            value:Math.Sqrt(
                Math.Pow((this.x-Maldives.x),2)+
                Math.Pow((this.y-Maldives.y),2)+
                Math.Pow((this.z-Maldives.z),2)),2);
        return distance;
    }
    public dynamic say_hello()
    {
        string output=$"[{this.x}, {this.y}, {this.z}]";
        return output;
    }
    public static void todo(){
        WriteLine("## Напишите программу, которая принимает на вход координаты двух точек и находит расстояние между ними в 3D пространстве.");
    }
    public static void homework_check(){
        Point_3d.todo();
        Dictionary<Point_3d,Point_3d> examples= new Dictionary<Point_3d,Point_3d>();
        examples.Add(new Point_3d(3,6,8),new Point_3d(2,1,-7));
        examples.Add(new Point_3d(7,-5,0), new Point_3d(1,-1,9));
        foreach (KeyValuePair<Point_3d,Point_3d> iter in examples)//...славься, Стаковерфлоу.
        {

            double __check=iter.Key.ask_distance_to(iter.Value);
        WriteLine($"Расстояние от точки {iter.Key.say_hello()} до {iter.Value.say_hello()}: {__check}");
        }
        }
}